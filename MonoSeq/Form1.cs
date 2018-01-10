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
using System.Windows.Forms.DataVisualization.Charting;


namespace MonoSeq
{
    public partial class frmMonoSeq : Form
    {

        OmniDriver.CCoWrapper wrapper = new OmniDriver.CCoWrapper();

        int integrationTime = 80000;                // the number of microseconds for the integration time
        int numberOfPixels;                         // number of CCD elements/pixels provided by the spectrometer
        int numberOfSpectrometers;                  // actually attached and talking to us
        int selectedSpectrometer = 0;               // selected Spectrometer    
        double[] spectrumArray, wavelengthArray;    // pixel values from the CCD elements and  wavelengths (in nanometers) corresponding to each CCD element


        System.Data.DataTable SpectrumTable = new DataTable("SpectrumTable");
        DataColumn column;
        DataRow row;

        public frmMonoSeq()
        {
            InitializeComponent();
        }

        private void btnStartRun_Click(object sender, EventArgs e)
        {
            wrapper.setIntegrationTime(selectedSpectrometer, integrationTime);
            lblStatus.Text = wrapper.getFirmwareModel(selectedSpectrometer) + " Spectrometer selected.";

            spectrumArray = (double[])wrapper.getSpectrum(selectedSpectrometer);

            numberOfPixels = spectrumArray.GetLength(0);

            wavelengthArray = (double[])wrapper.getWavelengths(selectedSpectrometer);

            SpectrumTable.Columns.Add("Wavelenght");
            for (int i = 0; i < spectrumArray.GetLength(0); i++)
            {
                row = SpectrumTable.NewRow();
                row["Wavelenght"] = Math.Round(wavelengthArray[i], 2);

                SpectrumTable.Rows.Add(row);
            }

            for (int k = 100; k < 1000; k = k + 100)
            {
                spectrumArray = (double[])wrapper.getSpectrum(selectedSpectrometer);

                SpectrumTable.Columns.Add(k.ToString());
                for (int i = 0; i < spectrumArray.GetLength(0); i++)
                {
                    SpectrumTable.Rows[i][k.ToString()] = spectrumArray[i];
                    SpectrumTable.AcceptChanges();
                }

                chartSpectrum.Series.Add(k.ToString());

                chartSpectrum.Series[k.ToString()].ChartType = SeriesChartType.Line;
                for (int l = 0; l < spectrumArray.GetLength(0); l++)
                {
                    chartSpectrum.Series[k.ToString()].Points.AddXY(Math.Round(wavelengthArray[l], 0), spectrumArray[l]);
                }


            }


            /////
            //Write Datatable to file Start
            ////
            StringBuilder sb = new StringBuilder();
            IEnumerable<string> columnNames = SpectrumTable.Columns.Cast<DataColumn>().Select(column => column.ColumnName);
            sb.AppendLine(string.Join(",", columnNames));
            foreach (DataRow row in SpectrumTable.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                sb.AppendLine(string.Join(",", fields));
            }
            File.WriteAllText("C:\\temp\\test.csv", sb.ToString());
            /////
            //Write Datatable to file End
            ////






        }

        private void frmMonoSeq_Load(object sender, EventArgs e)
        {

            numberOfSpectrometers = wrapper.openAllSpectrometers();                            // update number of spectrometers attached to the Computer
            lblStatus.Text = numberOfSpectrometers.ToString() +" Spectrometer(s) found.";      // update the Status Label

        }
    }
}
