namespace CapaPresentacion
{
    partial class GRAFICA
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGriedBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.dpt2 = new System.Windows.Forms.Label();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.dpt1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGriedBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(156, 49);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Horas_Detenida";
            series2.Points.Add(dataPoint2);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(695, 490);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(942, 287);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 58);
            this.button1.TabIndex = 1;
            this.button1.Text = "REGRESAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGriedBindingSource
            // 
            this.dataGriedBindingSource.DataSource = typeof(CapaPresentacion.DataGried);
            // 
            // dtp2
            // 
            this.dtp2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp2.Location = new System.Drawing.Point(881, 151);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(277, 26);
            this.dtp2.TabIndex = 3;
            // 
            // dpt2
            // 
            this.dpt2.AutoSize = true;
            this.dpt2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpt2.Location = new System.Drawing.Point(878, 111);
            this.dpt2.Name = "dpt2";
            this.dpt2.Size = new System.Drawing.Size(142, 25);
            this.dpt2.TabIndex = 5;
            this.dpt2.Text = "FECHAFINAL";
            // 
            // dtp1
            // 
            this.dtp1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp1.Location = new System.Drawing.Point(881, 70);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(277, 26);
            this.dtp1.TabIndex = 2;
            // 
            // dpt1
            // 
            this.dpt1.AutoSize = true;
            this.dpt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpt1.Location = new System.Drawing.Point(876, 24);
            this.dpt1.Name = "dpt1";
            this.dpt1.Size = new System.Drawing.Size(144, 25);
            this.dpt1.TabIndex = 4;
            this.dpt1.Text = "FECHAINICIO";
            this.dpt1.Click += new System.EventHandler(this.label1_Click);
            // 
            // GRAFICA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 602);
            this.Controls.Add(this.dpt2);
            this.Controls.Add(this.dpt1);
            this.Controls.Add(this.dtp2);
            this.Controls.Add(this.dtp1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chart1);
            this.Name = "GRAFICA";
            this.Text = "GRAFICA";
            this.Load += new System.EventHandler(this.GRAFICA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGriedBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.BindingSource dataGriedBindingSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dtp2;
        private System.Windows.Forms.Label dpt2;
        private System.Windows.Forms.DateTimePicker dtp1;
        private System.Windows.Forms.Label dpt1;
    }
}