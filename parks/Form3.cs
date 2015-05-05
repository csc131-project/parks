using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace parks
{
    public partial class LoadForm : Form
    {
        public LoadForm()
        {
            InitializeComponent();
        }

        private void buttonFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBoxPath.Text = openFileDialog1.FileName;
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            DataTable dp = new DataTable();
            DataTable ds = new DataTable();
            DataTable dt = new DataTable();
            DataTable dy = new DataTable();
            DataTable dz = new DataTable();
            string dbtable = "";
            string pathCon = "Provider= Microsoft.ACE.OLEDB.12.0;Data Source=" + textBoxPath.Text + ";Extended Properties=\"Excel 12.0 Xml;HDR=Yes;\";";
            OleDbConnection con = new OleDbConnection(pathCon);

            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter("Select * from [" + textBoxSheet.Text + "$]", con);

            myDataAdapter.Fill(dt);

            if (comboBox1.SelectedItem.ToString() == "Carnegie")
            {
               
                if (checkBox1.Checked)
                {
                    ds = GenerateTransposedTable(dt);
                    dz = RemoveColumns(ds);
                    dbtable = "Carnegie";
                }
                else
                {
                    dz = FilterData44nineFront(dt);
                    dbtable = "carnegie_daily";
                }
            }
            else if(comboBox1.SelectedItem.ToString() == "Clay_Pit")
            {
                
                if (checkBox1.Checked)
                {
                    ds = GenerateTransposedTable(dt);
                    dz = RemoveColumns(ds);
                    dbtable = "Clay_Pit";
                }
                else
                {
                    dz = FilterData44nineFront(dt);
                    dbtable = "clay_pit_daily";
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "Heber_Dunes")
            {
                
                if (checkBox1.Checked)
                {
                    ds = GenerateTransposedTable(dt);
                    dz = RemoveColumns(ds);
                    dbtable = "Heber_Dunes";
                }
                else
                {
                    dz = FilterData44nineFront(dt);
                    dbtable = "huber_dunes_daily";
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "Hungry_Valley")
            {
                
                if (checkBox1.Checked)
                {
                    ds = GenerateTransposedTable(dt);
                    dz = RemoveColumns(ds);
                    dbtable = "Hungry_Valley";
                }
                else
                {
                    dz = FilterData44nineFront(dt);
                    dbtable = "hungry_valley_daily";
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "Oceano_Dunes")
            {
               
                if (checkBox1.Checked)
                {
                    ds = GenerateTransposedTable(dt);
                    dz = RemoveColumns(ds);
                    dbtable = "Oceano_Dunes";
                }
                else
                {
                    dz = FilterData44nineFront(dt);
                    dbtable = "oceano_dunes_daily";
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "Ocotillo_Wells")
            {
                
                if (checkBox1.Checked)
                {
                    ds = GenerateTransposedTable(dt);
                    dz = RemoveColumns(ds);
                    dbtable = "Ocotillo_Wells";
                }
                else
                {
                    dz = FilterData44nineFront(dt);
                    dbtable = "ocotillo_wells_daily";
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "Prairie_City")
            {
                
                if (checkBox1.Checked)
                {
                    ds = GenerateTransposedTable(dt);
                    dz = RemoveColumns(ds);
                    dbtable = "Prairie_City";
                }
                else
                {
                    dz = FilterData44nineFront(dt);
                    dbtable = "prairie_sample_daily";
                }
            }

            dy = parseElementsToInt(dz);

            dataGridView1.DataSource = dy;
            
            SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\administrator.INTERHANGMAN\Documents\parks.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            conn.Open();
            SqlBulkCopy bulkExcel = new SqlBulkCopy(conn);

            bulkExcel.DestinationTableName = dbtable;

            bulkExcel.WriteToServer(dy);
            
            conn.Close();
            
        }

        public DataTable GenerateTransposedTable(DataTable inputTable)
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
            for (int rCount = 1; rCount < inputTable.Columns.Count - 1; rCount++)
            {
                DataRow newRow = outputTable.NewRow();

                // First column is inputTable's Header row's second column
                newRow[0] = inputTable.Columns[rCount].ColumnName.ToString();
                for (int cCount = 0; cCount < inputTable.Rows.Count - 1; cCount++)
                {
                    string colValue = inputTable.Rows[cCount][rCount].ToString();
                    newRow[cCount + 1] = colValue;
                }
                outputTable.Rows.Add(newRow);
            }

            return outputTable;
        }

        //function to remove headers and trilers from 449 front
        private DataTable FilterData44nineFront(DataTable dx)
        {
            for (int i = 0; i < 9; i++)
            {
                dx.Rows[i].Delete();
            }

            for (int k=dx.Rows.Count-1; k>39; k--)
            {
                dx.Rows[k].Delete();
            }

            for (int j = dx.Columns.Count - 1; j > 12; j--)
            {
                dx.Columns.Remove(dx.Columns[j]);
            }

            DataColumn col = dx.Columns.Add("id", System.Type.GetType("System.Int32"));
            col.SetOrdinal(0);

            return dx;
        }

        // function to remove unneeded columns after excel park svra sheet is read
        private DataTable RemoveColumns(DataTable dv)
        {
            for (int j=dv.Columns.Count-1; j>12; j--)
            {
                dv.Columns.Remove(dv.Columns[j]);
            }
            return dv;
        }

        // function to parse each element on DataTable object to integer
        private DataTable parseElementsToInt(DataTable du)
        {
                DataTable dw = new DataTable(); 
                dw = du.Clone();

                for(int i = 0; i < dw.Columns.Count - 1; i++)
                {
                    dw.Columns[i].DataType = typeof(Int32);
                }

                foreach (DataRow row in du.Rows)
                {
                    dw.ImportRow(row);
                }
            
                return dw;
        }

    }
} 
