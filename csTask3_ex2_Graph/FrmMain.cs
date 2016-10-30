using System;
using System.Drawing;
using System.Windows.Forms;
using csTask3_ex2_Graph.Properties;

/*
    Раскрасить граф минимальным количеством цветов. Каждая вершина должна быть
    помечена цветом, отличным от цвета смежных вершин.
*/
namespace csTask3_ex2_Graph
{
    /// <summary> Форма работы с графом
    /// </summary>
    public partial class FormMain : Form
    {
        private readonly Point[] _clickPoints = new Point[2];                
        private readonly GraphGui _graph;
    
        public FormMain()
        {
            InitializeComponent();
            Application.Idle += VisibleElems;
            _graph = new GraphGui(pnlGraph);
        }

        /// <summary> Запоминает координату начала "протягивания" дуги от одной вершины к другой
        /// </summary>
        private void pnlGraph_MouseDown(object sender, MouseEventArgs e)
        {
            if (rBtnDelArc.Checked || rBtnAddArc.Checked)
                _clickPoints[0] = new Point(e.X, e.Y);
        }

        /// <summary> Запоминает финальную точку "протягивания" дуги от одной вершины к другой
        /// и вызывает функцию добавления или удаления этой дуги
        /// В случае, если точки нажатия и "поднятия" мыши совпадают, выход из функции
        /// </summary>
        private void pnlGraph_MouseUp(object sender, MouseEventArgs e)
        {
            if (_clickPoints[0] == new Point(e.X, e.Y))
                return;            
            if (rBtnDelArc.Checked || rBtnAddArc.Checked) {
                _clickPoints[1] = new Point(e.X, e.Y);
                _graph.ActionArc(_clickPoints[0], _clickPoints[1], rBtnAddArc.Checked);
            }

        }

        /// <summary> Двойное нажатие позволяет добавить или удалить вершину из графа
        /// </summary>        
        private void pnlGraph_MouseDoubleClick(object sender, MouseEventArgs e)
        {   
            if (rBtnAddVertex.Checked)         
                _graph.AddVertices(new Point(e.X, e.Y));
            else if (rBtnDelVertex.Checked)
                _graph.DelVertices(new Point(e.X, e.Y));
        }

        /// <summary> Контроль доступа к элементам и отображения информации в зависимости от состояния формы
        /// </summary>
        private void VisibleElems(object sender, EventArgs e)
        {
            btnAction.Visible = rBtnClear.Checked || rBtnColorize.Checked;

            if (rBtnAddArc.Checked || rBtnDelArc.Checked)
                tbHelp.Text = @"Соедените две вершины, нажав кнопку мыши над одной и отпустив над другой";
            else if (rBtnAddVertex.Checked || rBtnDelVertex.Checked)
                tbHelp.Text = @"Используйте двойной клик мыши по нужной области";
            else
                tbHelp.Text = @"Используйте кнопку Выполнить для подтверждения";
            
        }

        /// <summary> Действия по нажатию на кнопку Выполнить
        /// Возможны только в случае выбора радиокнопок Colorize и Clear
        /// </summary>
        private void btnAction_Click(object sender, EventArgs e)
        {
            if (rBtnClear.Checked)
                _graph.Clear();
            else if (rBtnColorize.Checked && !_graph.Colorize())
                MessageBox.Show(Resources.FrmMain_GraphEmpty_info);
        }
    } // class FrmMain
}
