namespace MAG_8000_Chart
{
    partial class frMAG8000
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.ctMAG8000 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.werteEinblendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartZurücksetzenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateiLadenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.ctMAG8000)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctMAG8000
            // 
            chartArea5.AxisX.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea5.AxisX.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea5.AxisX.MinorTickMark.LineColor = System.Drawing.Color.Silver;
            chartArea5.CursorX.IsUserEnabled = true;
            chartArea5.CursorX.IsUserSelectionEnabled = true;
            chartArea5.Name = "ChartArea1";
            this.ctMAG8000.ChartAreas.Add(chartArea5);
            this.ctMAG8000.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ctMAG8000.Dock = System.Windows.Forms.DockStyle.Fill;
            legend5.Alignment = System.Drawing.StringAlignment.Center;
            legend5.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend5.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend5.IsTextAutoFit = false;
            legend5.Name = "MAG 8000";
            legend5.TitleFont = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctMAG8000.Legends.Add(legend5);
            this.ctMAG8000.Location = new System.Drawing.Point(0, 24);
            this.ctMAG8000.Name = "ctMAG8000";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Legend = "MAG 8000";
            series5.Name = "MAG--8000##";
            this.ctMAG8000.Series.Add(series5);
            this.ctMAG8000.Size = new System.Drawing.Size(1284, 738);
            this.ctMAG8000.TabIndex = 0;
            this.ctMAG8000.Text = "chart1";
            this.ctMAG8000.DoubleClick += new System.EventHandler(this.chart1_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiLadenToolStripMenuItem,
            this.werteEinblendenToolStripMenuItem,
            this.chartZurücksetzenToolStripMenuItem,
            this.hilfeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1284, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // werteEinblendenToolStripMenuItem
            // 
            this.werteEinblendenToolStripMenuItem.Name = "werteEinblendenToolStripMenuItem";
            this.werteEinblendenToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.werteEinblendenToolStripMenuItem.Text = "Werte einblenden";
            this.werteEinblendenToolStripMenuItem.Click += new System.EventHandler(this.btnWerteAnzeigen_Click);
            // 
            // chartZurücksetzenToolStripMenuItem
            // 
            this.chartZurücksetzenToolStripMenuItem.Name = "chartZurücksetzenToolStripMenuItem";
            this.chartZurücksetzenToolStripMenuItem.Size = new System.Drawing.Size(119, 20);
            this.chartZurücksetzenToolStripMenuItem.Text = "Chart zurücksetzen";
            this.chartZurücksetzenToolStripMenuItem.Click += new System.EventHandler(this.btnChartReset_Click);
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.hilfeToolStripMenuItem.Text = "Hilfe";
            this.hilfeToolStripMenuItem.Click += new System.EventHandler(this.hilfeToolStripMenuItem_Click);
            // 
            // dateiLadenToolStripMenuItem
            // 
            this.dateiLadenToolStripMenuItem.Name = "dateiLadenToolStripMenuItem";
            this.dateiLadenToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.dateiLadenToolStripMenuItem.Text = "Datei laden";
            this.dateiLadenToolStripMenuItem.Click += new System.EventHandler(this.dateiLadenToolStripMenuItem_Click);
            // 
            // frMAG8000
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 762);
            this.Controls.Add(this.ctMAG8000);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frMAG8000";
            this.Text = "WASSERZÄHLER MAG 8000";
            ((System.ComponentModel.ISupportInitialize)(this.ctMAG8000)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart ctMAG8000;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem werteEinblendenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chartZurücksetzenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dateiLadenToolStripMenuItem;
    }
}

