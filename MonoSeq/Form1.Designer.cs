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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnStartRun = new System.Windows.Forms.Button();
            this.chartSpectrum = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBoxMonoScan = new System.Windows.Forms.GroupBox();
            this.comboBoxSerialPort = new System.Windows.Forms.ComboBox();
            this.btnRefreshSerialPortList = new System.Windows.Forms.Button();
            this.btnInitializeMonoScan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartSpectrum)).BeginInit();
            this.groupBoxMonoScan.SuspendLayout();
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
            chartArea2.Name = "ChartArea1";
            this.chartSpectrum.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartSpectrum.Legends.Add(legend2);
            this.chartSpectrum.Location = new System.Drawing.Point(15, 13);
            this.chartSpectrum.Name = "chartSpectrum";
            this.chartSpectrum.Size = new System.Drawing.Size(898, 462);
            this.chartSpectrum.TabIndex = 2;
            this.chartSpectrum.Text = "chartSpectrum";
            // 
            // groupBoxMonoScan
            // 
            this.groupBoxMonoScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxMonoScan.Controls.Add(this.btnInitializeMonoScan);
            this.groupBoxMonoScan.Controls.Add(this.btnRefreshSerialPortList);
            this.groupBoxMonoScan.Controls.Add(this.comboBoxSerialPort);
            this.groupBoxMonoScan.Location = new System.Drawing.Point(511, 481);
            this.groupBoxMonoScan.Name = "groupBoxMonoScan";
            this.groupBoxMonoScan.Size = new System.Drawing.Size(402, 123);
            this.groupBoxMonoScan.TabIndex = 3;
            this.groupBoxMonoScan.TabStop = false;
            this.groupBoxMonoScan.Text = "Mono Scan";
            // 
            // comboBoxSerialPort
            // 
            this.comboBoxSerialPort.FormattingEnabled = true;
            this.comboBoxSerialPort.Location = new System.Drawing.Point(7, 20);
            this.comboBoxSerialPort.Name = "comboBoxSerialPort";
            this.comboBoxSerialPort.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSerialPort.TabIndex = 0;
            // 
            // btnRefreshSerialPortList
            // 
            this.btnRefreshSerialPortList.Location = new System.Drawing.Point(135, 17);
            this.btnRefreshSerialPortList.Name = "btnRefreshSerialPortList";
            this.btnRefreshSerialPortList.Size = new System.Drawing.Size(137, 23);
            this.btnRefreshSerialPortList.TabIndex = 1;
            this.btnRefreshSerialPortList.Text = "Refresh COM Ports";
            this.btnRefreshSerialPortList.UseVisualStyleBackColor = true;
            this.btnRefreshSerialPortList.Click += new System.EventHandler(this.btnRefreshSerialPortList_Click);
            // 
            // btnInitializeMonoScan
            // 
            this.btnInitializeMonoScan.Location = new System.Drawing.Point(7, 48);
            this.btnInitializeMonoScan.Name = "btnInitializeMonoScan";
            this.btnInitializeMonoScan.Size = new System.Drawing.Size(174, 23);
            this.btnInitializeMonoScan.TabIndex = 2;
            this.btnInitializeMonoScan.Text = "Initialize MonoScan";
            this.btnInitializeMonoScan.UseVisualStyleBackColor = true;
            this.btnInitializeMonoScan.Click += new System.EventHandler(this.btnInitializeMonoScan_Click);
            // 
            // frmMonoSeq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 613);
            this.Controls.Add(this.groupBoxMonoScan);
            this.Controls.Add(this.chartSpectrum);
            this.Controls.Add(this.btnStartRun);
            this.Controls.Add(this.lblStatus);
            this.Name = "frmMonoSeq";
            this.Text = "MonoSeq";
            this.Load += new System.EventHandler(this.frmMonoSeq_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartSpectrum)).EndInit();
            this.groupBoxMonoScan.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnStartRun;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSpectrum;
        private System.Windows.Forms.GroupBox groupBoxMonoScan;
        private System.Windows.Forms.Button btnRefreshSerialPortList;
        private System.Windows.Forms.ComboBox comboBoxSerialPort;
        private System.Windows.Forms.Button btnInitializeMonoScan;
    }
}

