using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace parks
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoadForm lf = new LoadForm();
            lf.Show();
        }

        private void QueryButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            QueryForm qf = new QueryForm();
            qf.Show();
        }

      
    }
}
