using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NTFSLearning
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("colBestBefore", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("colStatus", typeof(string)));

            dt.Columns["colStatus"].Expression = String.Format("IIF(colBestBefore < #{0}#, 'Ok','Not ok')", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            dt.Rows.Add(DateTime.Now.AddDays(-1));
            dt.Rows.Add(DateTime.Now.AddDays(1));
            dt.Rows.Add(DateTime.Now.AddDays(2));
            dt.Rows.Add(DateTime.Now.AddDays(-2));

            dataGridView1.DataSource = dt;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
