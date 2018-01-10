namespace MonoSeq
{
    partial class frmMonoSeq
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnStartRun = new System.Windows.Forms.Button();
            this.chartSpectrum = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartSpectrum)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 591);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Status";
            // 
            // btnStartRun
            // 
            this.btnStartRun.Location = new System.Drawing.Point(12, 541);
            this.btnStartRun.Name = "btnStartRun";
            this.btnStartRun.Size = new System.Drawing.Size(75, 23);
            this.btnStartRun.TabIndex = 1;
            this.btnStartRun.Text = "Start";
            this.btnStartRun.UseVisualStyleBackColor = true;
            this.btnStartRun.Click += new System.EventHandler(this.btnStartRun_Click);
            // 
            // chartSpectrum
            // 
            chartArea1.Name = "ChartArea1";
            this.chartSpectrum.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartSpectrum.Legends.Add(legend1);
            this.chartSpectrum.Location = new System.Drawing.Point(15, 13);
            this.chartSpectrum.Name = "chartSpectrum";
            this.chartSpectrum.Size = new System.Drawing.Size(898, 462);
            this.chartSpectrum.TabIndex = 2;
            this.chartSpectrum.Text = "chartSpectrum";
            // 
            // frmMonoSeq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 613);
            this.Controls.Add(this.chartSpectrum);
            this.Controls.Add(this.btnStartRun);
            this.Controls.Add(this.lblStatus);
            this.Name = "frmMonoSeq";
            this.Text = "MonoSeq";
            this.Load += new System.EventHandler(this.frmMonoSeq_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartSpectrum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnStartRun;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSpectrum;
    }
}

