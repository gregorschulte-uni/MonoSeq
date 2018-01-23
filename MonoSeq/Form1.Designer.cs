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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnStartRun = new System.Windows.Forms.Button();
            this.chartSpectrum = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBoxMonoScan = new System.Windows.Forms.GroupBox();
            this.numericUpDownMonoScanCustomWL = new System.Windows.Forms.NumericUpDown();
            this.btnGoToStartPosition = new System.Windows.Forms.Button();
            this.lblMonoScanInterval = new System.Windows.Forms.Label();
            this.numericUpDownMonoScanInterval = new System.Windows.Forms.NumericUpDown();
            this.lblMonoScanEndWL = new System.Windows.Forms.Label();
            this.lblMonoScanStartWL = new System.Windows.Forms.Label();
            this.numericUpDownMonoScanEndWL = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMonoScanStartWL = new System.Windows.Forms.NumericUpDown();
            this.btnInitializeMonoScan = new System.Windows.Forms.Button();
            this.btnRefreshSerialPortList = new System.Windows.Forms.Button();
            this.comboBoxSerialPort = new System.Windows.Forms.ComboBox();
            this.groupBoxSpectrometer = new System.Windows.Forms.GroupBox();
            this.buttonSpectrometerGetSpectrum = new System.Windows.Forms.Button();
            this.checkBoxNonLinearityCorrection = new System.Windows.Forms.CheckBox();
            this.checkBoxElectricDarkCorrection = new System.Windows.Forms.CheckBox();
            this.buttonSpectrometerAutomaticIntegrationTime = new System.Windows.Forms.Button();
            this.lblSpectrometerIntegrationTime = new System.Windows.Forms.Label();
            this.numericUpDownSpectrometerIntegrationTime = new System.Windows.Forms.NumericUpDown();
            this.buttonRefreshSpectrometer = new System.Windows.Forms.Button();
            this.comboBoxSpectrometer = new System.Windows.Forms.ComboBox();
            this.saveFileDialogMonoSeq = new System.Windows.Forms.SaveFileDialog();
            this.numericUpDownSpectrometerScansToAverage = new System.Windows.Forms.NumericUpDown();
            this.lblSpectrometerScansToAverage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartSpectrum)).BeginInit();
            this.groupBoxMonoScan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMonoScanCustomWL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMonoScanInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMonoScanEndWL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMonoScanStartWL)).BeginInit();
            this.groupBoxSpectrometer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpectrometerIntegrationTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpectrometerScansToAverage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 491);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Status";
            // 
            // btnStartRun
            // 
            this.btnStartRun.Location = new System.Drawing.Point(771, 486);
            this.btnStartRun.Name = "btnStartRun";
            this.btnStartRun.Size = new System.Drawing.Size(136, 23);
            this.btnStartRun.TabIndex = 1;
            this.btnStartRun.Text = "Start";
            this.btnStartRun.UseVisualStyleBackColor = true;
            this.btnStartRun.Click += new System.EventHandler(this.btnStartRun_Click);
            // 
            // chartSpectrum
            // 
            chartArea3.Name = "ChartArea1";
            this.chartSpectrum.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartSpectrum.Legends.Add(legend3);
            this.chartSpectrum.Location = new System.Drawing.Point(15, 12);
            this.chartSpectrum.Name = "chartSpectrum";
            this.chartSpectrum.Size = new System.Drawing.Size(898, 462);
            this.chartSpectrum.TabIndex = 2;
            this.chartSpectrum.Text = "chartSpectrum";
            // 
            // groupBoxMonoScan
            // 
            this.groupBoxMonoScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxMonoScan.Controls.Add(this.numericUpDownMonoScanCustomWL);
            this.groupBoxMonoScan.Controls.Add(this.btnGoToStartPosition);
            this.groupBoxMonoScan.Controls.Add(this.lblMonoScanInterval);
            this.groupBoxMonoScan.Controls.Add(this.numericUpDownMonoScanInterval);
            this.groupBoxMonoScan.Controls.Add(this.lblMonoScanEndWL);
            this.groupBoxMonoScan.Controls.Add(this.lblMonoScanStartWL);
            this.groupBoxMonoScan.Controls.Add(this.numericUpDownMonoScanEndWL);
            this.groupBoxMonoScan.Controls.Add(this.numericUpDownMonoScanStartWL);
            this.groupBoxMonoScan.Controls.Add(this.btnInitializeMonoScan);
            this.groupBoxMonoScan.Controls.Add(this.btnRefreshSerialPortList);
            this.groupBoxMonoScan.Controls.Add(this.comboBoxSerialPort);
            this.groupBoxMonoScan.Location = new System.Drawing.Point(511, 512);
            this.groupBoxMonoScan.Name = "groupBoxMonoScan";
            this.groupBoxMonoScan.Size = new System.Drawing.Size(402, 159);
            this.groupBoxMonoScan.TabIndex = 3;
            this.groupBoxMonoScan.TabStop = false;
            this.groupBoxMonoScan.Text = "Mono Scan";
            // 
            // numericUpDownMonoScanCustomWL
            // 
            this.numericUpDownMonoScanCustomWL.Location = new System.Drawing.Point(133, 51);
            this.numericUpDownMonoScanCustomWL.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.numericUpDownMonoScanCustomWL.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownMonoScanCustomWL.Name = "numericUpDownMonoScanCustomWL";
            this.numericUpDownMonoScanCustomWL.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownMonoScanCustomWL.TabIndex = 10;
            this.numericUpDownMonoScanCustomWL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownMonoScanCustomWL.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // btnGoToStartPosition
            // 
            this.btnGoToStartPosition.Location = new System.Drawing.Point(260, 50);
            this.btnGoToStartPosition.Name = "btnGoToStartPosition";
            this.btnGoToStartPosition.Size = new System.Drawing.Size(136, 22);
            this.btnGoToStartPosition.TabIndex = 9;
            this.btnGoToStartPosition.Text = "Go To Position";
            this.btnGoToStartPosition.UseVisualStyleBackColor = true;
            this.btnGoToStartPosition.Click += new System.EventHandler(this.btnGoToStartPosition_Click);
            // 
            // lblMonoScanInterval
            // 
            this.lblMonoScanInterval.AutoSize = true;
            this.lblMonoScanInterval.Location = new System.Drawing.Point(136, 133);
            this.lblMonoScanInterval.Name = "lblMonoScanInterval";
            this.lblMonoScanInterval.Size = new System.Drawing.Size(42, 13);
            this.lblMonoScanInterval.TabIndex = 8;
            this.lblMonoScanInterval.Text = "Interval";
            // 
            // numericUpDownMonoScanInterval
            // 
            this.numericUpDownMonoScanInterval.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownMonoScanInterval.Location = new System.Drawing.Point(7, 131);
            this.numericUpDownMonoScanInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMonoScanInterval.Name = "numericUpDownMonoScanInterval";
            this.numericUpDownMonoScanInterval.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownMonoScanInterval.TabIndex = 7;
            this.numericUpDownMonoScanInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownMonoScanInterval.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numericUpDownMonoScanInterval.ValueChanged += new System.EventHandler(this.numericUpDownMonoScanInterval_ValueChanged);
            // 
            // lblMonoScanEndWL
            // 
            this.lblMonoScanEndWL.AutoSize = true;
            this.lblMonoScanEndWL.Location = new System.Drawing.Point(136, 106);
            this.lblMonoScanEndWL.Name = "lblMonoScanEndWL";
            this.lblMonoScanEndWL.Size = new System.Drawing.Size(87, 13);
            this.lblMonoScanEndWL.TabIndex = 6;
            this.lblMonoScanEndWL.Text = "End Wavelenght";
            // 
            // lblMonoScanStartWL
            // 
            this.lblMonoScanStartWL.AutoSize = true;
            this.lblMonoScanStartWL.Location = new System.Drawing.Point(136, 80);
            this.lblMonoScanStartWL.Name = "lblMonoScanStartWL";
            this.lblMonoScanStartWL.Size = new System.Drawing.Size(90, 13);
            this.lblMonoScanStartWL.TabIndex = 5;
            this.lblMonoScanStartWL.Text = "Start Wavelenght";
            // 
            // numericUpDownMonoScanEndWL
            // 
            this.numericUpDownMonoScanEndWL.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownMonoScanEndWL.Location = new System.Drawing.Point(7, 104);
            this.numericUpDownMonoScanEndWL.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.numericUpDownMonoScanEndWL.Minimum = new decimal(new int[] {
            210,
            0,
            0,
            0});
            this.numericUpDownMonoScanEndWL.Name = "numericUpDownMonoScanEndWL";
            this.numericUpDownMonoScanEndWL.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownMonoScanEndWL.TabIndex = 4;
            this.numericUpDownMonoScanEndWL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownMonoScanEndWL.Value = new decimal(new int[] {
            750,
            0,
            0,
            0});
            this.numericUpDownMonoScanEndWL.ValueChanged += new System.EventHandler(this.numericUpDownMonoScanEndWL_ValueChanged);
            // 
            // numericUpDownMonoScanStartWL
            // 
            this.numericUpDownMonoScanStartWL.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownMonoScanStartWL.Location = new System.Drawing.Point(7, 78);
            this.numericUpDownMonoScanStartWL.Maximum = new decimal(new int[] {
            790,
            0,
            0,
            0});
            this.numericUpDownMonoScanStartWL.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownMonoScanStartWL.Name = "numericUpDownMonoScanStartWL";
            this.numericUpDownMonoScanStartWL.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownMonoScanStartWL.TabIndex = 3;
            this.numericUpDownMonoScanStartWL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownMonoScanStartWL.Value = new decimal(new int[] {
            350,
            0,
            0,
            0});
            this.numericUpDownMonoScanStartWL.ValueChanged += new System.EventHandler(this.numericUpDownMonoScanStartWL_ValueChanged);
            // 
            // btnInitializeMonoScan
            // 
            this.btnInitializeMonoScan.Location = new System.Drawing.Point(7, 51);
            this.btnInitializeMonoScan.Name = "btnInitializeMonoScan";
            this.btnInitializeMonoScan.Size = new System.Drawing.Size(120, 21);
            this.btnInitializeMonoScan.TabIndex = 2;
            this.btnInitializeMonoScan.Text = "Initialize MonoScan";
            this.btnInitializeMonoScan.UseVisualStyleBackColor = true;
            this.btnInitializeMonoScan.Click += new System.EventHandler(this.btnInitializeMonoScan_Click);
            // 
            // btnRefreshSerialPortList
            // 
            this.btnRefreshSerialPortList.Location = new System.Drawing.Point(134, 20);
            this.btnRefreshSerialPortList.Name = "btnRefreshSerialPortList";
            this.btnRefreshSerialPortList.Size = new System.Drawing.Size(120, 25);
            this.btnRefreshSerialPortList.TabIndex = 1;
            this.btnRefreshSerialPortList.Text = "Refresh COM Ports";
            this.btnRefreshSerialPortList.UseVisualStyleBackColor = true;
            this.btnRefreshSerialPortList.Click += new System.EventHandler(this.btnRefreshSerialPortList_Click);
            // 
            // comboBoxSerialPort
            // 
            this.comboBoxSerialPort.FormattingEnabled = true;
            this.comboBoxSerialPort.Location = new System.Drawing.Point(7, 20);
            this.comboBoxSerialPort.Name = "comboBoxSerialPort";
            this.comboBoxSerialPort.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSerialPort.TabIndex = 0;
            // 
            // groupBoxSpectrometer
            // 
            this.groupBoxSpectrometer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxSpectrometer.Controls.Add(this.lblSpectrometerScansToAverage);
            this.groupBoxSpectrometer.Controls.Add(this.numericUpDownSpectrometerScansToAverage);
            this.groupBoxSpectrometer.Controls.Add(this.buttonSpectrometerGetSpectrum);
            this.groupBoxSpectrometer.Controls.Add(this.checkBoxNonLinearityCorrection);
            this.groupBoxSpectrometer.Controls.Add(this.checkBoxElectricDarkCorrection);
            this.groupBoxSpectrometer.Controls.Add(this.buttonSpectrometerAutomaticIntegrationTime);
            this.groupBoxSpectrometer.Controls.Add(this.lblSpectrometerIntegrationTime);
            this.groupBoxSpectrometer.Controls.Add(this.numericUpDownSpectrometerIntegrationTime);
            this.groupBoxSpectrometer.Controls.Add(this.buttonRefreshSpectrometer);
            this.groupBoxSpectrometer.Controls.Add(this.comboBoxSpectrometer);
            this.groupBoxSpectrometer.Location = new System.Drawing.Point(12, 512);
            this.groupBoxSpectrometer.Name = "groupBoxSpectrometer";
            this.groupBoxSpectrometer.Size = new System.Drawing.Size(481, 159);
            this.groupBoxSpectrometer.TabIndex = 4;
            this.groupBoxSpectrometer.TabStop = false;
            this.groupBoxSpectrometer.Text = "Spectrometer";
            // 
            // buttonSpectrometerGetSpectrum
            // 
            this.buttonSpectrometerGetSpectrum.Location = new System.Drawing.Point(336, 20);
            this.buttonSpectrometerGetSpectrum.Name = "buttonSpectrometerGetSpectrum";
            this.buttonSpectrometerGetSpectrum.Size = new System.Drawing.Size(139, 27);
            this.buttonSpectrometerGetSpectrum.TabIndex = 7;
            this.buttonSpectrometerGetSpectrum.Text = "Get Single Spectrum";
            this.buttonSpectrometerGetSpectrum.UseVisualStyleBackColor = true;
            this.buttonSpectrometerGetSpectrum.Click += new System.EventHandler(this.buttonSpectrometerGetSpectrum_Click);
            // 
            // checkBoxNonLinearityCorrection
            // 
            this.checkBoxNonLinearityCorrection.AutoSize = true;
            this.checkBoxNonLinearityCorrection.Checked = true;
            this.checkBoxNonLinearityCorrection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNonLinearityCorrection.Location = new System.Drawing.Point(14, 131);
            this.checkBoxNonLinearityCorrection.Name = "checkBoxNonLinearityCorrection";
            this.checkBoxNonLinearityCorrection.Size = new System.Drawing.Size(139, 17);
            this.checkBoxNonLinearityCorrection.TabIndex = 6;
            this.checkBoxNonLinearityCorrection.Text = "Non Linearity Correction";
            this.checkBoxNonLinearityCorrection.UseVisualStyleBackColor = true;
            // 
            // checkBoxElectricDarkCorrection
            // 
            this.checkBoxElectricDarkCorrection.AutoSize = true;
            this.checkBoxElectricDarkCorrection.Checked = true;
            this.checkBoxElectricDarkCorrection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxElectricDarkCorrection.Location = new System.Drawing.Point(14, 107);
            this.checkBoxElectricDarkCorrection.Name = "checkBoxElectricDarkCorrection";
            this.checkBoxElectricDarkCorrection.Size = new System.Drawing.Size(138, 17);
            this.checkBoxElectricDarkCorrection.TabIndex = 5;
            this.checkBoxElectricDarkCorrection.Text = "Electric Dark Correction";
            this.checkBoxElectricDarkCorrection.UseVisualStyleBackColor = true;
            // 
            // buttonSpectrometerAutomaticIntegrationTime
            // 
            this.buttonSpectrometerAutomaticIntegrationTime.Enabled = false;
            this.buttonSpectrometerAutomaticIntegrationTime.Location = new System.Drawing.Point(336, 48);
            this.buttonSpectrometerAutomaticIntegrationTime.Name = "buttonSpectrometerAutomaticIntegrationTime";
            this.buttonSpectrometerAutomaticIntegrationTime.Size = new System.Drawing.Size(139, 23);
            this.buttonSpectrometerAutomaticIntegrationTime.TabIndex = 4;
            this.buttonSpectrometerAutomaticIntegrationTime.Text = "Auto Integration Time";
            this.buttonSpectrometerAutomaticIntegrationTime.UseVisualStyleBackColor = true;
            this.buttonSpectrometerAutomaticIntegrationTime.Click += new System.EventHandler(this.buttonSpectrometerAutomaticIntegrationTime_Click);
            // 
            // lblSpectrometerIntegrationTime
            // 
            this.lblSpectrometerIntegrationTime.AutoSize = true;
            this.lblSpectrometerIntegrationTime.Location = new System.Drawing.Point(141, 50);
            this.lblSpectrometerIntegrationTime.Name = "lblSpectrometerIntegrationTime";
            this.lblSpectrometerIntegrationTime.Size = new System.Drawing.Size(159, 13);
            this.lblSpectrometerIntegrationTime.TabIndex = 3;
            this.lblSpectrometerIntegrationTime.Text = "Integration Time (in milliseconds)";
            // 
            // numericUpDownSpectrometerIntegrationTime
            // 
            this.numericUpDownSpectrometerIntegrationTime.Location = new System.Drawing.Point(14, 48);
            this.numericUpDownSpectrometerIntegrationTime.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownSpectrometerIntegrationTime.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDownSpectrometerIntegrationTime.Name = "numericUpDownSpectrometerIntegrationTime";
            this.numericUpDownSpectrometerIntegrationTime.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownSpectrometerIntegrationTime.TabIndex = 2;
            this.numericUpDownSpectrometerIntegrationTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownSpectrometerIntegrationTime.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // buttonRefreshSpectrometer
            // 
            this.buttonRefreshSpectrometer.Location = new System.Drawing.Point(141, 20);
            this.buttonRefreshSpectrometer.Name = "buttonRefreshSpectrometer";
            this.buttonRefreshSpectrometer.Size = new System.Drawing.Size(189, 27);
            this.buttonRefreshSpectrometer.TabIndex = 1;
            this.buttonRefreshSpectrometer.Text = "Refresh Spectrometers";
            this.buttonRefreshSpectrometer.UseVisualStyleBackColor = true;
            this.buttonRefreshSpectrometer.Click += new System.EventHandler(this.buttonRefreshSpectrometer_Click);
            // 
            // comboBoxSpectrometer
            // 
            this.comboBoxSpectrometer.FormattingEnabled = true;
            this.comboBoxSpectrometer.Location = new System.Drawing.Point(14, 20);
            this.comboBoxSpectrometer.Name = "comboBoxSpectrometer";
            this.comboBoxSpectrometer.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSpectrometer.TabIndex = 0;
            this.comboBoxSpectrometer.SelectedIndexChanged += new System.EventHandler(this.comboBoxSpectrometer_SelectedIndexChanged);
            // 
            // saveFileDialogMonoSeq
            // 
            this.saveFileDialogMonoSeq.Filter = "csv Files|*.csv|All Files|*.*";
            this.saveFileDialogMonoSeq.RestoreDirectory = true;
            this.saveFileDialogMonoSeq.ShowHelp = true;
            // 
            // numericUpDownSpectrometerScansToAverage
            // 
            this.numericUpDownSpectrometerScansToAverage.Location = new System.Drawing.Point(13, 78);
            this.numericUpDownSpectrometerScansToAverage.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownSpectrometerScansToAverage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSpectrometerScansToAverage.Name = "numericUpDownSpectrometerScansToAverage";
            this.numericUpDownSpectrometerScansToAverage.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownSpectrometerScansToAverage.TabIndex = 8;
            this.numericUpDownSpectrometerScansToAverage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownSpectrometerScansToAverage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblSpectrometerScansToAverage
            // 
            this.lblSpectrometerScansToAverage.AutoSize = true;
            this.lblSpectrometerScansToAverage.Location = new System.Drawing.Point(141, 80);
            this.lblSpectrometerScansToAverage.Name = "lblSpectrometerScansToAverage";
            this.lblSpectrometerScansToAverage.Size = new System.Drawing.Size(92, 13);
            this.lblSpectrometerScansToAverage.TabIndex = 9;
            this.lblSpectrometerScansToAverage.Text = "Scans to Average";
            // 
            // frmMonoSeq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 683);
            this.Controls.Add(this.groupBoxSpectrometer);
            this.Controls.Add(this.groupBoxMonoScan);
            this.Controls.Add(this.chartSpectrum);
            this.Controls.Add(this.btnStartRun);
            this.Controls.Add(this.lblStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMonoSeq";
            this.Text = "MonoSeq";
            this.Load += new System.EventHandler(this.frmMonoSeq_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartSpectrum)).EndInit();
            this.groupBoxMonoScan.ResumeLayout(false);
            this.groupBoxMonoScan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMonoScanCustomWL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMonoScanInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMonoScanEndWL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMonoScanStartWL)).EndInit();
            this.groupBoxSpectrometer.ResumeLayout(false);
            this.groupBoxSpectrometer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpectrometerIntegrationTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpectrometerScansToAverage)).EndInit();
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
        private System.Windows.Forms.GroupBox groupBoxSpectrometer;
        private System.Windows.Forms.Label lblSpectrometerIntegrationTime;
        private System.Windows.Forms.NumericUpDown numericUpDownSpectrometerIntegrationTime;
        private System.Windows.Forms.Button buttonRefreshSpectrometer;
        private System.Windows.Forms.ComboBox comboBoxSpectrometer;
        private System.Windows.Forms.NumericUpDown numericUpDownMonoScanEndWL;
        private System.Windows.Forms.NumericUpDown numericUpDownMonoScanStartWL;
        private System.Windows.Forms.Label lblMonoScanInterval;
        private System.Windows.Forms.NumericUpDown numericUpDownMonoScanInterval;
        private System.Windows.Forms.Label lblMonoScanEndWL;
        private System.Windows.Forms.Label lblMonoScanStartWL;
        private System.Windows.Forms.Button buttonSpectrometerAutomaticIntegrationTime;
        private System.Windows.Forms.SaveFileDialog saveFileDialogMonoSeq;
        private System.Windows.Forms.CheckBox checkBoxNonLinearityCorrection;
        private System.Windows.Forms.CheckBox checkBoxElectricDarkCorrection;
        private System.Windows.Forms.Button btnGoToStartPosition;
        private System.Windows.Forms.NumericUpDown numericUpDownMonoScanCustomWL;
        private System.Windows.Forms.Button buttonSpectrometerGetSpectrum;
        private System.Windows.Forms.Label lblSpectrometerScansToAverage;
        private System.Windows.Forms.NumericUpDown numericUpDownSpectrometerScansToAverage;
    }
}

