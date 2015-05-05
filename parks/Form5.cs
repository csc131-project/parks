using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;
using Excel = Microsoft.Office.Interop.Excel;



namespace parks
{
    
    public partial class QueryForm : Form
    {
        DataTable dk = new DataTable();

        public QueryForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable outTable = new DataTable();
            string _park = comboBox1.SelectedItem.ToString();
            string _interval = comboBox2.SelectedItem.ToString();
            string _sMonth = comboBox3.SelectedItem.ToString();
            string _eMonth = comboBox4.SelectedItem.ToString();
            string _sYear = comboBox5.SelectedItem.ToString();
            string _eYear = comboBox6.SelectedItem.ToString();
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\administrator.INTERHANGMAN\Documents\parks.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM "+_park+" WHERE Year >= @_sYear AND Year <= @_eYear", con);
            cmd.Parameters.Add(new SqlParameter("_sYear", _sYear));
            cmd.Parameters.Add(new SqlParameter("_eYear", _eYear));

            SqlDataAdapter query = new SqlDataAdapter(cmd);
            query.Fill(outTable);
            dk = GenerateTransposedTable(outTable);
            dataGridView1.DataSource = dk;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.DataSource = dk;

            chart1.Series.Add(dk.Columns[1].ToString());
            chart1.Series[dk.Columns[1].ToString()].XValueMember = "Year";
            chart1.Series[dk.Columns[1].ToString()].YValueMembers = dk.Columns[1].ToString();

            chart1.DataBind();  
        }

       
        private DataTable GenerateTransposedTable(DataTable inputTable)
        {
            DataTable outputTable = new DataTable();

            // Add columns by looping rows

            // Header row's first column is same as in inputTable
            outputTable.Columns.Add(inputTable.Columns[0].ColumnName.ToString());

            //Header row's second column onwards, 'inputTable's first column taken
            foreach (DataRow inRow in inputTable.Rows)
            {
                string newColName = inRow[0].ToString();
                outputTable.Columns.Add(newColName);
            }

            // Add rows by looping columns        
            for (int rCount = 1; rCount <= inputTable.Columns.Count - 1; rCount++)
            {
                DataRow newRow = outputTable.NewRow();

                // First column is inputTable's Header row's second column
                newRow[0] = inputTable.Columns[rCount].ColumnName.ToString();
                for (int cCount = 0; cCount <= inputTable.Rows.Count - 1; cCount++)
                {
                    string colValue = inputTable.Rows[cCount][rCount].ToString();
                    newRow[cCount + 1] = colValue;
                }
                outputTable.Rows.Add(newRow);
            }

            return outputTable;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataSet dset = new DataSet();
            dset.Tables.Add(dk);

            ExportDataSetToExcel(dset);
          
        } 

        /// This method takes DataSet as input paramenter and it exports the same to excel
        /// </summary>
        /// <param name="ds"></param>
        private void ExportDataSetToExcel(DataSet ds)
        {
            //Creae an Excel application instance
            Excel.Application excelApp = new Excel.Application();

            //Create an Excel workbook instance and open it from the predefined location
            Excel.Workbook excelWorkBook = excelApp.Workbooks.Open(@"C:\data.xls");

            foreach (DataTable table in ds.Tables)
            {
                //Add a new worksheet to workbook with the Datatable name
                Excel.Worksheet excelWorkSheet = excelWorkBook.Sheets.Add();
                excelWorkSheet.Name = table.TableName;

                for (int i = 1; i < table.Columns.Count + 1; i++)
                {
                    excelWorkSheet.Cells[1, i] = table.Columns[i - 1].ColumnName;
                }

                for (int j = 0; j < table.Rows.Count; j++)
                {
                    for (int k = 0; k < table.Columns.Count; k++)
                    {
                        excelWorkSheet.Cells[j + 2, k + 1] = table.Rows[j].ItemArray[k].ToString();
                    }
                }
            }

            excelWorkBook.Save();
            excelWorkBook.Close();
            excelApp.Quit();
        }

    }
}
