using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms.DataVisualization.Charting;

using OmniDriver;                                   // load Omnidriver for OceanOptics Spectrometer
using OOGdrv;                                       // load Driver for OceanOptics Monoscan


namespace MonoSeq
{
    public partial class frmMonoSeq : Form
    {

        // initialize external libraries
        MonoScan myMonoScan = new MonoScan();
        CCoWrapper wrapper = new CCoWrapper();

        // initialize own variables
        int integrationTime = 8000;                                     // the number of microseconds for the integration time
        //int numberOfPixels;                                           // number of CCD elements/pixels provided by the spectrometer
        int numberOfSpectrometers;                                      // actually attached and talking to us
        int selectedSpectrometer = 0;                                   // selected Spectrometer    
        double[] spectrumArray;                                         // array with intensity per Pixel in measured spectrum will be stored here            
        double[] wavelengthArray;                                       // array with nm for corresponding pixel
        int saturationevents = 0;                                       // increased by 1 if a recorded spectrum is saturated

        System.Data.DataTable SpectrumTable = new DataTable("SpectrumTable");   // Create datatable for data storage
        DataRow row;

        
        
        public frmMonoSeq()                                             // initialize Componets >> generated Code
        {
            InitializeComponent();
        }
                
        private void frmMonoSeq_Load(object sender, EventArgs e)        // run when the program window is first drawn
        {
            numberOfSpectrometers = wrapper.openAllSpectrometers();     // initialize wrapper to get total number of spectrometers attachted
            UpdateSpectrometerList();                                   // update combobox with attached spectrometers  
            UpdatePortList();                                           // update combobox with serial ports found
        }

        private void btnStartRun_Click(object sender, EventArgs e)
        {
            btnStartRun.Text = "Scan Started...";
            this.Update();
            // Adjust Chart area to scan area
            chartSpectrum.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chartSpectrum.ChartAreas[0].AxisX.Minimum = Convert.ToInt32(numericUpDownMonoScanStartWL.Value);
            chartSpectrum.ChartAreas[0].AxisX.Maximum = Convert.ToInt32(numericUpDownMonoScanEndWL.Value);
            chartSpectrum.ChartAreas[0].AxisY.Minimum = -100;

            // reset variables to remove data from previous rounds
            saturationevents = 0;                                                                       // reset saturationevents from previous runs
            SpectrumTable.Reset();                                                                      // Clear datatable from data of previous runs
            chartSpectrum.Series.Clear();                                                               // Clear chart from data of previous runs

            // read variables from interface
            integrationTime = Convert.ToInt32(numericUpDownSpectrometerIntegrationTime.Value * 1000);    // read integration time from input field
            wrapper.setIntegrationTime(selectedSpectrometer, integrationTime);                           // apply integration time   
            lblStatus.Text = wrapper.getFirmwareModel(selectedSpectrometer) + " Spectrometer selected."; // display selected spectrometer

            wrapper.setCorrectForElectricalDark(selectedSpectrometer, Convert.ToInt32(checkBoxElectricDarkCorrection.Checked));
            wrapper.setCorrectForDetectorNonlinearity(selectedSpectrometer, Convert.ToInt32(checkBoxNonLinearityCorrection.Checked));
            wrapper.setScansToAverage(selectedSpectrometer, Convert.ToInt32(numericUpDownSpectrometerScansToAverage.Value));
            ///lblStatus.Text = Convert.ToString(Convert.ToInt32(checkBoxNonLinearityCorrection.Checked));


            // get spectrum from spectrometer
            wavelengthArray = (double[])wrapper.getWavelengths(selectedSpectrometer);                    // get wavelenthts from spectrometer   
            spectrumArray = (double[])wrapper.getSpectrum(selectedSpectrometer);                         // get spectrum from spectrometer
            //numberOfPixels = spectrumArray.GetLength(0);                                                 // get spectrum length   
            
            // fill Datatable start
            SpectrumTable.Columns.Add("Wavelength");                                                     // add first column for wavelengths

            // insert first row for integration time data START
            row = SpectrumTable.NewRow();                                                                           
            row["Wavelength"] = "integrationTime in ms";
            SpectrumTable.Rows.Add(row);
            // insert first row for integration time data END

            // add wavelength values in first column START
            for (int i = 0; i < spectrumArray.GetLength(0); i++)
            {
                row = SpectrumTable.NewRow();
                row["Wavelength"] = wavelengthArray[i];
                //row["Wavelength"] = Math.Round(wavelengthArray[i], 2);
                SpectrumTable.Rows.Add(row);
            }
            // add wavelength values in first column END

            // add spectral data columns to datatable START
            for (decimal k = numericUpDownMonoScanStartWL.Value; k <= numericUpDownMonoScanEndWL.Value; k = k + numericUpDownMonoScanInterval.Value)
            {
                myMonoScan.setPositionNM(Convert.ToInt32(k));

                System.Threading.Thread.Sleep(500);
                
                spectrumArray = (double[])wrapper.getSpectrum(selectedSpectrometer);

                int specmax = wrapper.getMaximumIntensity(selectedSpectrometer);
                int specpercentil = Convert.ToInt32(specmax - (specmax * 0.05));
                if (spectrumArray.Max() > specpercentil)
                {
                    saturationevents = saturationevents + 1;
                }
                lblStatus.Text = saturationevents.ToString() + " Saturation events occured during scan.";

                SpectrumTable.Columns.Add(k.ToString());
                SpectrumTable.Rows[0][k.ToString()] = numericUpDownSpectrometerIntegrationTime.Value;
                SpectrumTable.AcceptChanges();

                for (int i = 0; i < spectrumArray.GetLength(0); i++)
                {
                    SpectrumTable.Rows[i + 1][k.ToString()] = spectrumArray[i];
                    SpectrumTable.AcceptChanges();
                }

                // add spectral data into series for chart START
                chartSpectrum.Series.Add(k.ToString());
                chartSpectrum.Series[k.ToString()].ChartType = SeriesChartType.Line;
                for (int l = 1; l < spectrumArray.GetLength(0); l++)
                {
                    chartSpectrum.Series[k.ToString()].Points.AddXY(Math.Round(wavelengthArray[l], 0), spectrumArray[l]);
                }
                this.Update();                                                  // Update Interface to dispaly chart
                // add spectral data into series for chart END
            }
            // add spectral data columns to datatable END

            // give warning when saturations occured during run
            if (saturationevents > 0)
            {
                MessageBox.Show("There have been " + saturationevents.ToString() + " scans that were saturated!");
            }

            
            //Write Datatable to csv file with comma separator
            if (saveFileDialogMonoSeq.ShowDialog() == System.Windows.Forms.DialogResult.OK) // write Datatable to file when dialog was accepted
            { 
            StringBuilder spectrumString = new StringBuilder();
            IEnumerable<string> columnNames = SpectrumTable.Columns.Cast<DataColumn>().Select(column => column.ColumnName);
            spectrumString.AppendLine(string.Join(",", columnNames));
            foreach (DataRow row in SpectrumTable.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                spectrumString.AppendLine(string.Join(",", fields));
            }
            File.WriteAllText(saveFileDialogMonoSeq.FileName, spectrumString.ToString());
            // Write Datatable end

            // Write Metadata to txt file, same name as csv but  with *.ini extension
            StringBuilder metadataString = new StringBuilder();
            metadataString.AppendLine("Timestamp, " + DateTime.Now.ToString());
            metadataString.AppendLine("Spectrometer, " + wrapper.getFirmwareModel(selectedSpectrometer));
            metadataString.AppendLine("Scans to Average, " + wrapper.getScansToAverage(selectedSpectrometer).ToString());
            metadataString.AppendLine("Boxcar, " + wrapper.getBoxcarWidth(selectedSpectrometer).ToString());
            metadataString.AppendLine("EDC, " + wrapper.getCorrectForElectricalDark(selectedSpectrometer).ToString());
            metadataString.AppendLine("NLC, " + wrapper.getCorrectForDetectorNonlinearity(selectedSpectrometer).ToString());
            metadataString.AppendLine("Itegration Time (as milliseconds), " + (wrapper.getIntegrationTime(selectedSpectrometer)/1000).ToString());
            metadataString.AppendLine("Saturationevents, " + saturationevents.ToString());
            metadataString.AppendLine("MonoScan Start, " + numericUpDownMonoScanStartWL.Value.ToString());
            metadataString.AppendLine("MonoScan END, " + numericUpDownMonoScanEndWL.Value.ToString());
            metadataString.AppendLine("MonoScan Interval, " + numericUpDownMonoScanInterval.Value.ToString());
            File.WriteAllText(Path.ChangeExtension(saveFileDialogMonoSeq.FileName,".txt"), metadataString.ToString());
            // Write Metadata End

   
            }
            btnStartRun.Text = "Start";
            this.Update();
        }   // main routine in in here

        private void btnRefreshSerialPortList_Click(object sender, EventArgs e)   // Update List of COM Ports, user might have attached new MonoScan
        {
            UpdatePortList();                       
        }       

        private void btnInitializeMonoScan_Click(object sender, EventArgs e)
        {
            btnInitializeMonoScan.Text = "initializing...";
            this.Update();
            try
            {
                myMonoScan.openConnection(comboBoxSerialPort.Text);
                myMonoScan.initialize();
                myMonoScan.setPositionNM(Convert.ToInt32(numericUpDownMonoScanStartWL.Value));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message+"\n\rProbably the Monoscan was already initialized");
            }
            btnInitializeMonoScan.Text = "Initialzie Monoscan";
            this.Update();
     

        }           // initialize Monoscan

        private void buttonRefreshSpectrometer_Click(object sender, EventArgs e)
        {
            UpdateSpectrometerList();
        }

        private void comboBoxSpectrometer_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedSpectrometer = comboBoxSpectrometer.SelectedIndex;
            lblStatus.Text = "Selected Spectrometer ID: " + selectedSpectrometer.ToString() + " Spectrometer Name = " + wrapper.getFirmwareModel(selectedSpectrometer);
        }

        private void numericUpDownMonoScanEndWL_ValueChanged(object sender, EventArgs e)
        {
            CheckWavelengthRelation();
            CheckIntervalLenght();

        }

        private void numericUpDownMonoScanStartWL_ValueChanged(object sender, EventArgs e)
        {
            CheckWavelengthRelation();
            CheckIntervalLenght();
        }

        private void CheckWavelengthRelation()              // test if start wavelength is smaller than end wavelength
        {
            if (numericUpDownMonoScanEndWL.Value <= numericUpDownMonoScanStartWL.Value)
            {                
                numericUpDownMonoScanEndWL.Value = numericUpDownMonoScanStartWL.Value + 1;
                MessageBox.Show("End Wavelength has to be bigger than Start Wavelength");
            }

        }

        private void CheckIntervalLenght()                  // test if interval lenght fits between start and end wavelength
        {
            if (numericUpDownMonoScanInterval.Value > numericUpDownMonoScanEndWL.Value - numericUpDownMonoScanStartWL.Value)
            {
                MessageBox.Show("Interval to smal to fit between start wavelength and end wavelength!");
                numericUpDownMonoScanStartWL.Value = 350;
                numericUpDownMonoScanEndWL.Value = 750;
                numericUpDownMonoScanInterval.Value = 25;
            }
        }                           

        private void UpdatePortList()                       // update combobox with available COM Ports
        {
            string[] ports = SerialPort.GetPortNames();     // generate helper string       
            comboBoxSerialPort.DataSource = ports;          // update combobox with available COM Ports    
        }

        private void numericUpDownMonoScanInterval_ValueChanged(object sender, EventArgs e)
        {
            CheckIntervalLenght();
        }

        private void buttonSpectrometerAutomaticIntegrationTime_Click(object sender, EventArgs e)
        {
            adjustIntegrationTime();
        }

        private void UpdateSpectrometerList()               // update combobox with available sepctrometers
        {
           string[] specs = new string[100];                // generate helper string, lenght 100 check for better solution

            wrapper.closeAllSpectrometers();                // close all spectrometer has to be called befor open, see API Docs
            wrapper.openAllSpectrometers();
            numberOfSpectrometers = wrapper.getNumberOfSpectrometersFound();

            if (numberOfSpectrometers != 0)                 // populate combobox
            {
                for (int i = 0; i < numberOfSpectrometers; i++)
                {
                    specs[i] = wrapper.getFirmwareModel(i);
                }
                comboBoxSpectrometer.DataSource = specs;
                comboBoxSpectrometer.SelectedIndex = 0;
                selectedSpectrometer = 0;
            }
            else
            {
                MessageBox.Show("No Spectrometers attached");
            }
        }

        private void adjustIntegrationTime()
        {
            double[] tempSpectrumArray = wrapper.getSpectrum(selectedSpectrometer);
            int maxIntensity = wrapper.getMaximumIntensity(selectedSpectrometer);
            int maxIntensity95 = Convert.ToInt32(maxIntensity * 0.95);
            double currentMaximum = tempSpectrumArray.Max();
            int myIntegrationtime;
            int tempIntegrationTime;

            wrapper.setIntegrationTime(selectedSpectrometer, Convert.ToInt32( numericUpDownSpectrometerIntegrationTime.Value * 1000));

            if (currentMaximum < maxIntensity95 )
            {
                // increase integrationtime by factor
                double factor = maxIntensity95 / currentMaximum;

                tempIntegrationTime = Convert.ToInt32(Convert.ToDouble(numericUpDownSpectrometerIntegrationTime.Value) * factor);

                myIntegrationtime = Clamp(tempIntegrationTime, Convert.ToInt32(numericUpDownSpectrometerIntegrationTime.Minimum), Convert.ToInt32(numericUpDownSpectrometerIntegrationTime.Maximum));

                numericUpDownSpectrometerIntegrationTime.Value = myIntegrationtime;             


            }
            else if (currentMaximum > maxIntensity95)
            {
                // reduce integrationtime by factor
                int maxcounter = 0;
                
                for ( int i =0; i < tempSpectrumArray.Length; i++)
                {
                    if (tempSpectrumArray[i]==currentMaximum)
                    {
                        maxcounter++;
                        lblStatus.Text = maxcounter.ToString();
                    }
                }

                if (maxcounter > 1)
                { 
                tempIntegrationTime = Convert.ToInt32(numericUpDownSpectrometerIntegrationTime.Value  / maxcounter * 9);

                myIntegrationtime = Clamp(tempIntegrationTime, Convert.ToInt32(numericUpDownSpectrometerIntegrationTime.Minimum), Convert.ToInt32(numericUpDownSpectrometerIntegrationTime.Maximum));

                numericUpDownSpectrometerIntegrationTime.Value = myIntegrationtime;
                }
            }
            else
            {
                // do nothing
            }

        }

        public static int Clamp(int value, int min, int max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }

        private void btnGoToStartPosition_Click(object sender, EventArgs e)
        {
            btnGoToStartPosition.Text = "going to " + numericUpDownMonoScanCustomWL.Value.ToString() + "...";
            this.Update();
            myMonoScan.setPositionNM(Convert.ToInt32(numericUpDownMonoScanCustomWL.Value));
            btnGoToStartPosition.Text = "Go To Position";
            this.Update();

        }




        private void buttonSpectrometerGetSpectrum_Click(object sender, EventArgs e)
        {
            // Adjust Chart area to scan area
            chartSpectrum.ChartAreas[0].AxisX.Minimum = Convert.ToInt32(numericUpDownMonoScanStartWL.Value);
            chartSpectrum.ChartAreas[0].AxisX.Maximum = Convert.ToInt32(numericUpDownMonoScanEndWL.Value);
            chartSpectrum.ChartAreas[0].AxisY.Minimum = -100;

            // reset variables to remove data from previous rounds
            saturationevents = 0;                                                                       // reset saturationevents from previous runs
            SpectrumTable.Reset();                                                                      // Clear datatable from data of previous runs
            chartSpectrum.Series.Clear();                                                               // Clear chart from data of previous runs

            // read variables from interface
            integrationTime = Convert.ToInt32(numericUpDownSpectrometerIntegrationTime.Value * 1000);    // read integration time from input field
            wrapper.setIntegrationTime(selectedSpectrometer, integrationTime);                           // apply integration time   
            lblStatus.Text = wrapper.getFirmwareModel(selectedSpectrometer) + " Spectrometer selected."; // display selected spectrometer

            wrapper.setCorrectForElectricalDark(selectedSpectrometer, Convert.ToInt32(checkBoxElectricDarkCorrection.Checked));
            wrapper.setCorrectForDetectorNonlinearity(selectedSpectrometer, Convert.ToInt32(checkBoxNonLinearityCorrection.Checked));
            lblStatus.Text = Convert.ToString(Convert.ToInt32(checkBoxNonLinearityCorrection.Checked));

            // get spectrum from spectrometer
            wavelengthArray = (double[])wrapper.getWavelengths(selectedSpectrometer);                    // get wavelenthts from spectrometer   
            spectrumArray = (double[])wrapper.getSpectrum(selectedSpectrometer);                         // get spectrum from spectrometer
                                                                                                         //numberOfPixels = spectrumArray.GetLength(0);                                                 // get spectrum length   

            // fill Datatable start
            SpectrumTable.Columns.Add("Wavelength");                                                     // add first column for wavelengths

            // insert first row for integration time data START
            row = SpectrumTable.NewRow();
            row["Wavelength"] = "integrationTime in ms";
            SpectrumTable.Rows.Add(row);
            // insert first row for integration time data END

            // add wavelength values in first column START
            for (int i = 0; i < spectrumArray.GetLength(0); i++)
            {
                row = SpectrumTable.NewRow();
                row["Wavelength"] = wavelengthArray[i];
                //row["Wavelength"] = Math.Round(wavelengthArray[i], 2);
                SpectrumTable.Rows.Add(row);
            }
            // add wavelength values in first column END

            // add spectral data columns to datatable START
            //for (decimal k = numericUpDownMonoScanStartWL.Value; k < numericUpDownMonoScanEndWL.Value; k = k + numericUpDownMonoScanInterval.Value)
            //{
                //myMonoScan.setPositionNM(Convert.ToInt32(k));
                spectrumArray = (double[])wrapper.getSpectrum(selectedSpectrometer);

                int specmax = wrapper.getMaximumIntensity(selectedSpectrometer);
                int specpercentil = Convert.ToInt32(specmax - (specmax * 0.05));
                if (spectrumArray.Max() > specpercentil)
                {
                    saturationevents = saturationevents + 1;
                }
                lblStatus.Text = saturationevents.ToString() + " Saturation events occured during scan.";

                //SpectrumTable.Columns.Add(k.ToString());
                //SpectrumTable.Rows[0][k.ToString()] = numericUpDownSpectrometerIntegrationTime.Value;
                //SpectrumTable.AcceptChanges();

                //for (int i = 0; i < spectrumArray.GetLength(0); i++)
               // {
                //    SpectrumTable.Rows[i + 1][k.ToString()] = spectrumArray[i];
               //     SpectrumTable.AcceptChanges();
                //}

                // add spectral data into series for chart START
                chartSpectrum.Series.Add("Spectrum");
                chartSpectrum.Series["Spectrum"].ChartType = SeriesChartType.Line;
                for (int l = 1; l < spectrumArray.GetLength(0); l++)
                {
                    chartSpectrum.Series["Spectrum"].Points.AddXY(Math.Round(wavelengthArray[l], 0), spectrumArray[l]);
                }
                this.Update();                                                  // Update Interface to dispaly chart
                // add spectral data into series for chart END
            //}
            // add spectral data columns to datatable END

            // give warning when saturations occured during run
            if (saturationevents > 0)
            {
                MessageBox.Show("There have been " + saturationevents.ToString() + " scans that were saturated!");
            }
        }
    }
}
