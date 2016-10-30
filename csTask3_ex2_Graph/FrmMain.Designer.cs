namespace csTask3_ex2_Graph
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlGraph = new System.Windows.Forms.Panel();
            this.gbGraphAction = new System.Windows.Forms.GroupBox();
            this.tbHelp = new System.Windows.Forms.TextBox();
            this.rBtnClear = new System.Windows.Forms.RadioButton();
            this.rBtnColorize = new System.Windows.Forms.RadioButton();
            this.btnAction = new System.Windows.Forms.Button();
            this.rBtnDelArc = new System.Windows.Forms.RadioButton();
            this.rBtnAddArc = new System.Windows.Forms.RadioButton();
            this.rBtnDelVertex = new System.Windows.Forms.RadioButton();
            this.rBtnAddVertex = new System.Windows.Forms.RadioButton();
            this.pnlMain.SuspendLayout();
            this.gbGraphAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlGraph);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(800, 538);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlGraph
            // 
            this.pnlGraph.BackColor = System.Drawing.Color.White;
            this.pnlGraph.Location = new System.Drawing.Point(4, 4);
            this.pnlGraph.Name = "pnlGraph";
            this.pnlGraph.Size = new System.Drawing.Size(522, 500);
            this.pnlGraph.TabIndex = 0;
            this.pnlGraph.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pnlGraph_MouseDoubleClick);
            this.pnlGraph.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlGraph_MouseDown);
            this.pnlGraph.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlGraph_MouseUp);
            // 
            // gbGraphAction
            // 
            this.gbGraphAction.Controls.Add(this.tbHelp);
            this.gbGraphAction.Controls.Add(this.rBtnClear);
            this.gbGraphAction.Controls.Add(this.rBtnColorize);
            this.gbGraphAction.Controls.Add(this.btnAction);
            this.gbGraphAction.Controls.Add(this.rBtnDelArc);
            this.gbGraphAction.Controls.Add(this.rBtnAddArc);
            this.gbGraphAction.Controls.Add(this.rBtnDelVertex);
            this.gbGraphAction.Controls.Add(this.rBtnAddVertex);
            this.gbGraphAction.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbGraphAction.Location = new System.Drawing.Point(597, 0);
            this.gbGraphAction.Name = "gbGraphAction";
            this.gbGraphAction.Size = new System.Drawing.Size(203, 538);
            this.gbGraphAction.TabIndex = 1;
            this.gbGraphAction.TabStop = false;
            this.gbGraphAction.Text = "Действия";
            // 
            // tbHelp
            // 
            this.tbHelp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbHelp.Location = new System.Drawing.Point(3, 272);
            this.tbHelp.Multiline = true;
            this.tbHelp.Name = "tbHelp";
            this.tbHelp.ReadOnly = true;
            this.tbHelp.Size = new System.Drawing.Size(197, 263);
            this.tbHelp.TabIndex = 7;
            // 
            // rBtnClear
            // 
            this.rBtnClear.AutoSize = true;
            this.rBtnClear.Location = new System.Drawing.Point(6, 135);
            this.rBtnClear.Name = "rBtnClear";
            this.rBtnClear.Size = new System.Drawing.Size(72, 17);
            this.rBtnClear.TabIndex = 6;
            this.rBtnClear.TabStop = true;
            this.rBtnClear.Text = "Очистить";
            this.rBtnClear.UseVisualStyleBackColor = true;
            // 
            // rBtnColorize
            // 
            this.rBtnColorize.AutoSize = true;
            this.rBtnColorize.Location = new System.Drawing.Point(6, 112);
            this.rBtnColorize.Name = "rBtnColorize";
            this.rBtnColorize.Size = new System.Drawing.Size(113, 17);
            this.rBtnColorize.TabIndex = 5;
            this.rBtnColorize.TabStop = true;
            this.rBtnColorize.Text = "Раскрасить граф";
            this.rBtnColorize.UseVisualStyleBackColor = true;
            // 
            // btnAction
            // 
            this.btnAction.Location = new System.Drawing.Point(52, 175);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(75, 23);
            this.btnAction.TabIndex = 4;
            this.btnAction.Text = "Выполнить";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // rBtnDelArc
            // 
            this.rBtnDelArc.AutoSize = true;
            this.rBtnDelArc.Location = new System.Drawing.Point(6, 89);
            this.rBtnDelArc.Name = "rBtnDelArc";
            this.rBtnDelArc.Size = new System.Drawing.Size(92, 17);
            this.rBtnDelArc.TabIndex = 3;
            this.rBtnDelArc.TabStop = true;
            this.rBtnDelArc.Text = "Удалить дугу";
            this.rBtnDelArc.UseVisualStyleBackColor = true;
            // 
            // rBtnAddArc
            // 
            this.rBtnAddArc.AutoSize = true;
            this.rBtnAddArc.Location = new System.Drawing.Point(6, 66);
            this.rBtnAddArc.Name = "rBtnAddArc";
            this.rBtnAddArc.Size = new System.Drawing.Size(99, 17);
            this.rBtnAddArc.TabIndex = 2;
            this.rBtnAddArc.TabStop = true;
            this.rBtnAddArc.Text = "Добавить дугу";
            this.rBtnAddArc.UseVisualStyleBackColor = true;
            // 
            // rBtnDelVertex
            // 
            this.rBtnDelVertex.AutoSize = true;
            this.rBtnDelVertex.Location = new System.Drawing.Point(6, 43);
            this.rBtnDelVertex.Name = "rBtnDelVertex";
            this.rBtnDelVertex.Size = new System.Drawing.Size(114, 17);
            this.rBtnDelVertex.TabIndex = 1;
            this.rBtnDelVertex.TabStop = true;
            this.rBtnDelVertex.Text = "Удалить вершину";
            this.rBtnDelVertex.UseVisualStyleBackColor = true;
            // 
            // rBtnAddVertex
            // 
            this.rBtnAddVertex.AutoSize = true;
            this.rBtnAddVertex.Location = new System.Drawing.Point(6, 20);
            this.rBtnAddVertex.Name = "rBtnAddVertex";
            this.rBtnAddVertex.Size = new System.Drawing.Size(121, 17);
            this.rBtnAddVertex.TabIndex = 0;
            this.rBtnAddVertex.TabStop = true;
            this.rBtnAddVertex.Text = "Добавить вершину";
            this.rBtnAddVertex.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 538);
            this.Controls.Add(this.gbGraphAction);
            this.Controls.Add(this.pnlMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Раскраска графа";
            this.pnlMain.ResumeLayout(false);
            this.gbGraphAction.ResumeLayout(false);
            this.gbGraphAction.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlGraph;
        private System.Windows.Forms.GroupBox gbGraphAction;
        private System.Windows.Forms.RadioButton rBtnColorize;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.RadioButton rBtnDelArc;
        private System.Windows.Forms.RadioButton rBtnAddArc;
        private System.Windows.Forms.RadioButton rBtnDelVertex;
        private System.Windows.Forms.RadioButton rBtnAddVertex;
        private System.Windows.Forms.RadioButton rBtnClear;
        private System.Windows.Forms.TextBox tbHelp;
    }
}

