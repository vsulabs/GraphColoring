using System.Drawing;
using System.Windows.Forms;

namespace csTask3_ex2_Graph
{
    /// <summary> Класс, связывающий граф и GUI реализациею; 
    /// с возможностю иллюстрации графа на компоненте Panel
    /// </summary>
    class GraphGui: Graph
    {
        /// <summary> Панель, на которой происходит отрисовка графики
        /// </summary>
        private readonly Panel _panel;
        
        /// <summary> Конструктор, инициализирующий граф начальными значениями
        /// </summary>
        /// <param name="panel">Панель, на которой происходит отрисовка графии</param>
        public GraphGui(Panel panel)
        {
            _panel = panel;            
        }

        /// <summary> Добавление вершины в граф
        /// </summary>
        /// <param name="pos">Точка привязки вершины к панели</param>
        /// <returns>TRUE, если удаление прошло успешно</returns>
        public new bool AddVertices(Point pos)
        {
            if (!base.AddVertices(pos))
                return false;                        
            Draw();
            return true;
        }

        /// <summary> Удаляет вершину из графа
        /// </summary>
        /// <param name="pos">Точка, которая должна описывать удаляемую вершину, попадая в ее радиус</param>
        /// <returns>TRUE, если удаление прошло успешно</returns>
        public new bool DelVertices(Point pos)
        {            
            if (!base.DelVertices(pos))
                return false;         
            Draw();
            return true;
        }        

        /// <summary> Работа с дугами. В зависимости от параметра позволяет удалить или добавить дугу
        /// </summary>
        /// <param name="one">Первая вершина дуги</param>
        /// <param name="two">Вторая вершина дуги</param>
        /// <param name="isAddAction">Действие над дугой. TRUE, если добавление; FASLE, если удаление</param>
        /// <returns>TRUE, если работа с вершинами прошла успешно</returns>
        public bool ActionArc(Point one, Point two, bool isAddAction)
        {
            if (!ActionArc(ref one, ref two, isAddAction))
                return false;            
            Draw();
            return true;
        }
        
        /// <summary> Очищает панель открисовки и удаляет всю информацию о графе.
        /// </summary>
        public new void Clear()
        {
            ClearPanel();
            base.Clear();
        }

        /// <summary> Перерисовка панели цветом фона (закрашиваются все вершины и дуги)
        /// </summary>
        private void ClearPanel()
        {
            _panel.CreateGraphics().FillRectangle( new SolidBrush(_panel.BackColor), 
                0, 0, _panel.Width, _panel.Height);
        }

        /// <summary> Изображение на панели всех вершин и дуг графа
        /// </summary>
        private void Draw()
        {
            ClearPanel();            
            for (int i = 0; i < Size; ++i)
                for (int j = 0; j < Size; ++j)
                    if (Matr[i, j]) // отображение дуг
                        DrawArc(IntToColor(), Vertices[i].Coord, Vertices[j].Coord);
            foreach (var v in Vertices) // отображение вершин            
                DrawVertex(IntToColor(v.Color), v.Coord);
        }

        /// <summary> Раскраска графа. Вызов рекурсивного алгоритма для присвоения вершинам цветов
        /// и отображение на форме в соответствии с присвоенными цветами
        /// </summary>
        public new bool Colorize()
        {
            if (Vertices.Count == 0)
                return false;
            base.Colorize();                      
            Draw();
            SetDefaultColors();
            return true;
        }

        /// <summary> Изображение вершины на панели. 
        /// </summary>
        /// <param name="c">Цвет вершины</param>
        /// <param name="coord">Координаты вершины</param>
        private void DrawVertex(Color c, Point coord)
        {
            _panel.CreateGraphics().FillEllipse(
                new SolidBrush(c),
                coord.X - Vertex.Radius,
                coord.Y - Vertex.Radius,
                Vertex.Radius * 2,
                Vertex.Radius * 2);
        }

        /// <summary> Изображение дуги на панели, соединяющей две вершины
        /// </summary>
        /// <param name="c">Цвет дуги</param>
        /// <param name="one">Первая веришина</param>
        /// <param name="two">Вторая вершина</param>
        private void DrawArc(Color c, Point one, Point two)
        {
            _panel.CreateGraphics().DrawLine(new Pen(c, 3), one, two);
        }
       
        /// <summary> Отображение целого числа в множество цветов
        /// </summary>
        /// <param name="num">Целое число, которому в соответствие ставится цвет</param>
        /// <returns></returns>
        private static Color IntToColor(int num = 0)
        {
            switch (num)
            {
            #region palitra
                case 1:
                    return Color.Aquamarine;
                case 2:
                    return Color.Aqua;                    
                case 3:
                    return Color.Brown;
                case 4:
                    return Color.CornflowerBlue;
                case 5:
                    return Color.BurlyWood;
                case 6:
                    return Color.Chocolate;
                case 7:
                    return Color.CadetBlue;
                case 8:
                    return Color.DarkCyan;
                case 9:
                    return Color.Honeydew;
                case 10:
                    return Color.Orchid;
                case 11:
                    return Color.Orchid;
                case 12:
                    return Color.Tomato;
                case 13:
                    return Color.Tan;
                case 14:
                    return Color.DarkTurquoise;
                case 15:
                    return Color.PaleTurquoise;
                case 16:
                    return Color.SeaGreen;
                case 17:
                    return Color.SandyBrown;                
                case 18:
                    return Color.SkyBlue;
                case 19:
                    return Color.Peru;
                case 20:
                    return Color.Plum;
                case 21:
                    return Color.IndianRed;
                case 22:
                    return Color.PaleVioletRed;
                case 23:
                    return Color.RoyalBlue;
                case 24:
                    return Color.NavajoWhite;
                case 25:
                    return Color.Gold;

                default:
                    return Color.FromArgb(40, 59, 81);
            #endregion
            }
        }

    }
}
