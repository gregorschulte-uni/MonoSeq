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

using OmniDriver;
using OOGdrv;


namespace MonoSeq
{
    public partial class frmMonoSeq : Form
    {

        // initialize external libraries
        MonoScan myMonoScan = new MonoScan();
        CCoWrapper wrapper = new CCoWrapper();

        // initialize own variables
        int integrationTime = 80000;                // the number of microseconds for the integration time
        int numberOfPixels;                         // number of CCD elements/pixels provided by the spectrometer
        int numberOfSpectrometers;                  // actually attached and talking to us
        int selectedSpectrometer = 0;               // selected Spectrometer    
        double[] spectrumArray, wavelengthArray;    // pixel values from the CCD elements and  wavelengths (in nanometers) corresponding to each CCD element

        System.Data.DataTable SpectrumTable = new DataTable("SpectrumTable");   // Create datatable for data storage
        //DataColumn column;                          // not used, can probably be deleted
        DataRow row;
        
        public frmMonoSeq()                         // initialize Componets >> generated Code
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
            while (chartSpectrum.Series.Count > 0) { chartSpectrum.Series.RemoveAt(0); }                 // delete all data from chart from previous runs

            integrationTime = Convert.ToInt32(numericUpDownSpectrometerIntegrationTime.Value * 1000);    // read integration time from input field
            wrapper.setIntegrationTime(selectedSpectrometer, integrationTime);                           // apply integration time   
            lblStatus.Text = wrapper.getFirmwareModel(selectedSpectrometer) + " Spectrometer selected."; // display selected spectrometer

            wavelengthArray = (double[])wrapper.getWavelengths(selectedSpectrometer);                    // get wavelenthts from spectrometer   
            spectrumArray = (double[])wrapper.getSpectrum(selectedSpectrometer);                         // get spectrum from spectrometer
            numberOfPixels = spectrumArray.GetLength(0);                                                 // get spectrum lenth   


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
                row["Wavelength"] = Math.Round(wavelengthArray[i], 2);
                SpectrumTable.Rows.Add(row);
            }
            // add wavelength values in first column END

            // add spectral data columns to datatable START
            for (decimal k = numericUpDownMonoScanStartWL.Value; k < numericUpDownMonoScanEndWL.Value; k = k + numericUpDownMonoScanInterval.Value)
            {
                myMonoScan.setPositionNM(Convert.ToInt32(k));
                spectrumArray = (double[])wrapper.getSpectrum(selectedSpectrometer);
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
                for (int l = 0; l < spectrumArray.GetLength(0); l++)
                {
                    chartSpectrum.Series[k.ToString()].Points.AddXY(Math.Round(wavelengthArray[l], 0), spectrumArray[l]);
                }
                this.Update();                                                  // Update Interface to dispaly chart
                // add spectral data into series for chart END
            }
            // add spectral data columns to datatable END

            //Write Datatable to csv file with comma separator
            saveFileDialogMonoSeq.ShowDialog();                                 // Dialog to get file location and name
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
            metadataString.AppendLine("Spectrometer, " + wrapper.getFirmwareModel(selectedSpectrometer));
            metadataString.AppendLine("Scans to Average, " + wrapper.getScansToAverage(selectedSpectrometer).ToString());
            metadataString.AppendLine("Boxcar, " + wrapper.getBoxcarWidth(selectedSpectrometer).ToString());
            File.WriteAllText(Path.ChangeExtension(saveFileDialogMonoSeq.FileName,".ini"), metadataString.ToString());
            // Write Metadata End

            // finally delete content of datatable for next round
            foreach (var column in SpectrumTable.Columns.Cast<DataColumn>().ToArray())
            {
                    SpectrumTable.Columns.Remove(column);
            }
            // delete datatable end         
            
            Console.WriteLine("");                  // just a point to stop for a breakpoint // can be removed         
        }

        private void btnRefreshSerialPortList_Click(object sender, EventArgs e)
        {
            UpdatePortList();                       // Update List of COM Ports, user might have attached new MonoScan
        }

        private void btnInitializeMonoScan_Click(object sender, EventArgs e)
        {
            myMonoScan.openConnection(comboBoxSerialPort.Text);
            myMonoScan.initialize();
            myMonoScan.setPositionNM(Convert.ToInt32(numericUpDownMonoScanStartWL.Value));
        }

        private void lblSpectrometerIntegrationTime_Click(object sender, EventArgs e)
        {

        }

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

        private void CheckIntervalLenght()
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
    }
}
