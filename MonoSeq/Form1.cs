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
        MonoScan myMonoScan = new MonoScan();
        CCoWrapper wrapper = new CCoWrapper();

        int integrationTime = 80000;                // the number of microseconds for the integration time
        int numberOfPixels;                         // number of CCD elements/pixels provided by the spectrometer
        int numberOfSpectrometers;                  // actually attached and talking to us
        int selectedSpectrometer = 0;               // selected Spectrometer    
        double[] spectrumArray, wavelengthArray;    // pixel values from the CCD elements and  wavelengths (in nanometers) corresponding to each CCD element

        int startScanWavelenght = 200;              // default start wavelenght set to 200nm
        int endScanWavelenght = 800;                // default end wavelenght set to 8000
        int scanInterval = 10;                      // default wavelenght interval seet to 10nm




        System.Data.DataTable SpectrumTable = new DataTable("SpectrumTable");
        DataColumn column;
        DataRow row;

        public frmMonoSeq()
        {
            InitializeComponent();
        }

        private void btnStartRun_Click(object sender, EventArgs e)


        {

            while (chartSpectrum.Series.Count > 0) { chartSpectrum.Series.RemoveAt(0); }

            integrationTime = Convert.ToInt32(numericUpDownSpectrometerIntegrationTime.Value * 1000);


            wrapper.setIntegrationTime(selectedSpectrometer, integrationTime);
            lblStatus.Text = wrapper.getFirmwareModel(selectedSpectrometer) + " Spectrometer selected.";

            spectrumArray = (double[])wrapper.getSpectrum(selectedSpectrometer);

            numberOfPixels = spectrumArray.GetLength(0);

            wavelengthArray = (double[])wrapper.getWavelengths(selectedSpectrometer);

            SpectrumTable.Columns.Add("Wavelength");
            row = SpectrumTable.NewRow();
            row["Wavelength"] = "integrationTime in ms";
            SpectrumTable.Rows.Add(row);

            for (int i = 0; i < spectrumArray.GetLength(0); i++)
            {
                row = SpectrumTable.NewRow();
                row["Wavelength"] = Math.Round(wavelengthArray[i], 2);

                SpectrumTable.Rows.Add(row);
            }

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

                chartSpectrum.Series.Add(k.ToString());

                chartSpectrum.Series[k.ToString()].ChartType = SeriesChartType.Line;
                for (int l = 0; l < spectrumArray.GetLength(0); l++)
                {
                    chartSpectrum.Series[k.ToString()].Points.AddXY(Math.Round(wavelengthArray[l], 0), spectrumArray[l]);
                }
                this.Update();


            }



            saveFileDialogMonoSeq.ShowDialog();
            /////
            // Write Datatable to file Start
            
            ////
            StringBuilder sb = new StringBuilder();
            IEnumerable<string> columnNames = SpectrumTable.Columns.Cast<DataColumn>().Select(column => column.ColumnName);
            sb.AppendLine(string.Join(",", columnNames));
            foreach (DataRow row in SpectrumTable.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                sb.AppendLine(string.Join(",", fields));
            }
            File.WriteAllText(saveFileDialogMonoSeq.FileName, sb.ToString());
            /////
            //Write Datatable to file End
            ////



            foreach (var column in SpectrumTable.Columns.Cast<DataColumn>().ToArray())
            {
                //if (SpectrumTable.AsEnumerable().All(dr => dr.IsNull(column)))
                    SpectrumTable.Columns.Remove(column);
            }

            




            Console.WriteLine("");


        }

        private void btnRefreshSerialPortList_Click(object sender, EventArgs e)
        {
            updatePortList();
        }

        private void frmMonoSeq_Load(object sender, EventArgs e)
        {



            numberOfSpectrometers = wrapper.openAllSpectrometers();

            updatePortList();

            updateSpectrometerList();
            // update number of spectrometers attached to the Computer
            //lblStatus.Text = numberOfSpectrometers.ToString() +" Spectrometer(s) found.";      // update the Status Label

        }

        private void btnInitializeMonoScan_Click(object sender, EventArgs e)
        {
            myMonoScan.openConnection(comboBoxSerialPort.Text);
            myMonoScan.initialize();
            myMonoScan.setPositionNM(532);
        }

        private void lblSpectrometerIntegrationTime_Click(object sender, EventArgs e)
        {

        }

        private void buttonRefreshSpectrometer_Click(object sender, EventArgs e)
        {
            updateSpectrometerList();


        }

        private void updateSpectrometerList()
        {
            //comboBoxSpectrometer.Dispose();
            string[] specs = new string[100];

            wrapper.closeAllSpectrometers();
            wrapper.openAllSpectrometers();
            numberOfSpectrometers = wrapper.getNumberOfSpectrometersFound();

            if (numberOfSpectrometers != 0)
            {

                for (int i = 0; i < numberOfSpectrometers; i++)
                {
                    specs[i] = wrapper.getFirmwareModel(i);
                }

                comboBoxSpectrometer.DataSource = specs;
                comboBoxSpectrometer.SelectedIndex = 0;
            }

            else
            {
                MessageBox.Show("No Spectrometers attached");
            }




        }

        private void comboBoxSpectrometer_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedSpectrometer = comboBoxSpectrometer.SelectedIndex;
            lblStatus.Text = "Selected Spectrometer ID: " + selectedSpectrometer.ToString() + " Spectrometer Name = " + wrapper.getFirmwareModel(selectedSpectrometer);
        }

        private void numericUpDownMonoScanEndWL_ValueChanged(object sender, EventArgs e)
        {
            checkWavelengthRelation();
        }

        private void numericUpDownMonoScanStartWL_ValueChanged(object sender, EventArgs e)
        {
            checkWavelengthRelation();
        }

        private void checkWavelengthRelation()

        {
            if (numericUpDownMonoScanEndWL.Value <= numericUpDownMonoScanStartWL.Value)
            {
                
                numericUpDownMonoScanEndWL.Value = numericUpDownMonoScanStartWL.Value + 1;

                MessageBox.Show("End Wavelenght has to be bigger than Start Wavelenght");

            }

        }

        private void updatePortList()
        {
            string[] ports = SerialPort.GetPortNames();            
            comboBoxSerialPort.DataSource = ports;
        }
    }
}
