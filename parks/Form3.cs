﻿using System;
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
            string pathCon = "Provider= Microsoft.ACE.OLEDB.12.0;Data Source=" + textBoxPath.Text + ";Extended Properties=\"Excel 12.0 Xml;HDR=Yes;\";";
            OleDbConnection con = new OleDbConnection(pathCon);

            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter("Select * from [" + textBoxSheet.Text + "$]", con);
            DataTable dt = new DataTable();

            myDataAdapter.Fill(dt);

            //DataTable dy = FilterData44nineBack(dt);

            //DataTable dz = RemoveTrailers(dt); 

            DataTable ds = GenerateTransposedTable(dt);

            DataTable dz = RemoveColumns(ds);

            dataGridView1.DataSource = dz;

            SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\administrator.INTERHANGMAN\Documents\parks.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            conn.Open();
            SqlBulkCopy bulkExcel = new SqlBulkCopy(conn);

            bulkExcel.DestinationTableName = "Clay_Pit";

            bulkExcel.WriteToServer(dz);

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

        private DataTable FilterData44nineBack(DataTable dx)
        {
            for (int i = 0; i < 9; i++)
            {
                dx.Rows[i].Delete();
            }

            for (int k=dx.Rows.Count-1; k>40; k--)
            {
                dx.Rows[k].Delete();
            }

            for (int j = dx.Columns.Count - 1; j > 12; j--)
            {
                dx.Columns.Remove(dx.Columns[j]);
            }
            return dx;
        }

        private DataTable RemoveTrailers(DataTable dw)
        {
            for (int k=dw.Rows.Count-1; k>11; k--)
            {
                dw.Rows[k].Delete();
            }

            return dw;
        }

        private DataTable RemoveColumns(DataTable dv)
        {
            for (int j=dv.Columns.Count-1; j>12; j--)
            {
                dv.Columns.Remove(dv.Columns[j]);
            }
            return dv;
        }

    }
} 
