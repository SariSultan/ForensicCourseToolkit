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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        void DisplayBytesDataView(byte[] DataBytes, int Datasize, int offsetStartdecimal)
        {
            int FirstDataColunm = 1;

            int offsetValue = offsetStartdecimal;
            double no_ofRows = Math.Ceiling((double)Datasize / 16);
            int dataIndex = 0;
            for (int r = 0; r < no_ofRows; r++)
            {
                dataView.Rows.Add();
                dataView.Rows[r].Cells[0].Value = offsetValue.ToString("X2");

                for (int i = 0; i < 16; i++)
                {
                    if (dataIndex >= Datasize) break;
                    dataView.Rows[r].Cells[FirstDataColunm + i].Value = DataBytes[dataIndex].ToString("X2");
                    dataIndex++;
                    offsetValue++;

                }


            }
        }

        void SelectValue_only_onDataView(byte[] DataBytes, int Datasize, int StartIndex,int EndIndex,Color color)
        {
            for (int i = StartIndex; i <= EndIndex; i++)
            {
                int rowindex = (i / 16);
                int cellindex = (i % 16) + 1;
                dataView.Rows[rowindex].Cells[cellindex].Style.BackColor = color;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {/// function parameters
            byte[] DataBytes = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17,18, 19, 20, 21, 22, 23, 24 };
            int Datasize=25;
            int offsetStartdecimal = 65536;
           ////////

            DisplayBytesDataView(DataBytes, Datasize, offsetStartdecimal);

            SelectValue_only_onDataView(DataBytes, Datasize, 1, 5, Color.Red);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

       private void ClearHighlightedDataView()
        {
            for (int i = 0; i < dataView.Rows.Count; i++)
            {
                for (int j = 0; j < dataView.ColumnCount; j++)
                {
                    dataView.Rows[i].Cells[j].Style.BackColor = Color.White;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ClearHighlightedDataView();
            
        }
    }
}
