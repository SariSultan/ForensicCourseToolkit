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
    public partial class DisplayAttributes : Form
    {
        public DisplayAttributes()
        {
            InitializeComponent();
        }
        #region DataGride DataView Functions
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

        void SelectValue_only_onDataView(byte[] DataBytes, int Datasize, int StartIndex, int EndIndex, Color color)
        {
            ClearHighlightedDataView();
            for (int i = StartIndex; i <= EndIndex; i++)
            {
                int rowindex = (i / 16);
                int cellindex = (i % 16) + 1;
                dataView.Rows[rowindex].Cells[cellindex].Style.BackColor = color;
            }
        }

        void SelectValue_onDataView(byte[] DataBytes, int Datasize, int StartIndex, int EndIndex, Color color)
        {

            for (int i = StartIndex; i <= EndIndex; i++)
            {
                int rowindex = (i / 16);
                int cellindex = (i % 16) + 1;
                dataView.Rows[rowindex].Cells[cellindex].Style.BackColor = color;
            }
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
        #endregion

         private  int SelectedMFTIndex;
   
       private  NTFS_MFTHeader_Reader SelectedMFTHeader;
       private  byte[] SelectedMFT;
       private  int CurrentStartingoffset;
        private void DisplayAttributes_Load(object sender, EventArgs e)
        {
            SelectedMFT = MainForm_NTFSLearning.SelectedMFT;
            CurrentStartingoffset = MainForm_NTFSLearning.CurrentStartingoffsetAddress;
            SelectedMFTHeader = MainForm_NTFSLearning.MFTHeaderReader;
            DisplayBytesDataView(SelectedMFT, 1024,CurrentStartingoffset);

           
        
        }

        private void button45_Click(object sender, EventArgs e)
        {
            txtOutput.Text = "MFT Header is 42 Bytes " + Environment.NewLine;
            SelectValue_onDataView(MainForm_NTFSLearning.MFTHeaderReader.Headerdata, 42, 0, 41, Color.Yellow);
            grpMFTEntryHeader.Visible = true;
            button45.Enabled = false;
            
        }
        private void button15_Click_1(object sender, EventArgs e)
        {
            SelectValue_onDataView(MainForm_NTFSLearning.MFTHeaderReader.Headerdata, 42, 0, 3, Color.Red);
            txtOutput.Text = txtOutput.Text + "Bytes 0-3 : MFT Signiture FILE" + Environment.NewLine;
        }

        


        private void button17_Click(object sender, EventArgs e)
        {//offset to fixup array
            txtOutput.Text = txtOutput.Text + "Bytes 4-5 : Offset to fixup array =  " + MainForm_NTFSLearning.MFTHeaderReader.OffsetFixupArray.ToString() + Environment.NewLine;
            SelectValue_onDataView(MainForm_NTFSLearning.MFTHeaderReader.Headerdata, 42, 4, 5, Color.Wheat);
        }

        private void button32_Click(object sender, EventArgs e)
        {//no of entries in fixup array
            txtOutput.Text = txtOutput.Text + "Bytes 6-7 : Number of entries in fixup array =  " + MainForm_NTFSLearning.MFTHeaderReader.NoEntryFixupArray.ToString() + Environment.NewLine;
            SelectValue_onDataView(MainForm_NTFSLearning.MFTHeaderReader.Headerdata, 42, 6, 7, Color.Brown);
        }

        private void button18_Click(object sender, EventArgs e)
        {//log file
            txtOutput.Text = txtOutput.Text + "Bytes 8-15 : $LogFile Sequence number =  " + MainForm_NTFSLearning.MFTHeaderReader.LogFileSeq.ToString() + Environment.NewLine;
            SelectValue_onDataView(MainForm_NTFSLearning.MFTHeaderReader.Headerdata, 42, 8, 15, Color.CadetBlue);
        }

        private void button46_Click(object sender, EventArgs e)
        {// sequence value
            SelectValue_onDataView(MainForm_NTFSLearning.MFTHeaderReader.Headerdata, 42, 16, 17, Color.Coral);
            txtOutput.Text = txtOutput.Text + "Bytes 16-17 : Sequence value =  " + MainForm_NTFSLearning.MFTHeaderReader.seqvalue.ToString() + Environment.NewLine;
        }

        private void button25_Click(object sender, EventArgs e)
        {//link count 
            txtOutput.Text = txtOutput.Text + "Bytes 18-19 : Link count =  " + MainForm_NTFSLearning.MFTHeaderReader.linkcount.ToString() + Environment.NewLine;
            SelectValue_onDataView(MainForm_NTFSLearning.MFTHeaderReader.Headerdata, 42, 18, 19, Color.Crimson);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            //offset to first attribute
            SelectValue_onDataView(MainForm_NTFSLearning.MFTHeaderReader.Headerdata, 42, 20, 21, Color.Lavender);
            txtOutput.Text = txtOutput.Text + "Bytes 20-21 : Offset to firt attribute =  " + MainForm_NTFSLearning.MFTHeaderReader.offsettoattr1.ToString() + Environment.NewLine;
        }

        private void button30_Click(object sender, EventArgs e)
        {
            //flag (in use and directory)
            SelectValue_onDataView(MainForm_NTFSLearning.MFTHeaderReader.Headerdata, 42, 22, 23, Color.Orange);
            txtOutput.Text = txtOutput.Text + "Bytes 22-23 : Flags (in-use and directory) =  " + MainForm_NTFSLearning.MFTHeaderReader.flags.ToString() + Environment.NewLine;
        }

        private void button31_Click(object sender, EventArgs e)
        {
            //used Size of MFT entry 
            SelectValue_onDataView(MainForm_NTFSLearning.MFTHeaderReader.Headerdata, 42, 24, 27, Color.LightBlue);
            txtOutput.Text = txtOutput.Text + "Bytes 24-27 : Used size of MFT Entry =  " + MainForm_NTFSLearning.MFTHeaderReader.MFTentrysize.ToString() + Environment.NewLine;

        }

        private void button35_Click(object sender, EventArgs e)
        {
            //allocated size of MFT Entry
            SelectValue_onDataView(MainForm_NTFSLearning.MFTHeaderReader.Headerdata, 42, 28, 31, Color.LightGreen);
            txtOutput.Text = txtOutput.Text + "Bytes 28-31 : Allocated size of MFT entry =  " + MainForm_NTFSLearning.MFTHeaderReader.allMFTentry.ToString() + Environment.NewLine;
        }

        private void button34_Click(object sender, EventArgs e)
        {
            //file reference to base record
            SelectValue_onDataView(MainForm_NTFSLearning.MFTHeaderReader.Headerdata, 42, 32, 39, Color.LightPink);
            txtOutput.Text = txtOutput.Text + "Bytes 32-39 : File reference to first record =  " + MainForm_NTFSLearning.MFTHeaderReader.baserecordfileref.ToString() + Environment.NewLine;
        }

        private void button33_Click(object sender, EventArgs e)
        { //next attribute
            SelectValue_onDataView(MainForm_NTFSLearning.MFTHeaderReader.Headerdata, 42, 40, 41, Color.LightSeaGreen);
            txtOutput.Text = txtOutput.Text + "Bytes 40-41 : Next Attribute ID =  " + MainForm_NTFSLearning.MFTHeaderReader.nextattrid.ToString() + Environment.NewLine;
        }

        private void button32_Click_1(object sender, EventArgs e)
        {
            //no of entries in fixup array
            txtOutput.Text = txtOutput.Text + "Bytes 6-7 : Number of entries in fixup array =  " + MainForm_NTFSLearning.MFTHeaderReader.NoEntryFixupArray.ToString() + Environment.NewLine;
            SelectValue_onDataView(MainForm_NTFSLearning.MFTHeaderReader.Headerdata, 42, 6, 7, Color.Brown);
               
        }
        List<MFT_Attribute> Attributelist = new List<MFT_Attribute>();
        private void btnGetAttributes_Click(object sender, EventArgs e)
        { Random randonGen = new Random();
            int MFTIndex = SelectedMFTHeader.offsettoattr1;
            CalculationUtilities calc = new CalculationUtilities();

            txtOutput.Text = txtOutput.Text + "The MFT have the Folowing Attributes :" + Environment.NewLine;
           do{

            
            int attr_len;
            int attr_type;
            byte[] attr_all;
            byte[] attrlen =new byte[4];
            byte[] attrtype=new byte[4];

            int typeLenMFTIndex = MFTIndex;
            for (int i=0;i<4;i++)
            {
                attrtype[i] = SelectedMFT[typeLenMFTIndex];
                typeLenMFTIndex++;
            }
            attr_type = calc.LittleIndianBytesToInt(attrtype, 4);
            string attrType_string=calc.attributeType(attr_type);

            if (attrType_string == null) break;
            for (int i = 0; i < 4; i++)
            {
                attrlen[i] = SelectedMFT[typeLenMFTIndex];
                typeLenMFTIndex++;
            }
            attr_len = calc.LittleIndianBytesToInt(attrlen, 4);
            attr_all = new byte[attr_len];

            int MFTattrIndex = MFTIndex;
            for (int i = 0; i < attr_len; i++)
            {
                attr_all[i] = SelectedMFT[MFTattrIndex];
                MFTattrIndex++;
            }

                       
            Color randomColor = Color.FromArgb(randonGen.Next(255), randonGen.Next(255), randonGen.Next(255));
            SelectValue_onDataView(attr_all, attr_len, MFTIndex, MFTattrIndex, randomColor);
            txtOutput.Text = txtOutput.Text + attrType_string  + Environment.NewLine;

            Button btnAttr = new Button();
            btnAttr.Text = attrType_string;
            btnAttr.Size = btnGetAttributes.Size;
            btnAttr.BackColor = randomColor;
            int btnLocX = btnGetAttributes.Location.X;
            int BtnLocY = btnGetAttributes.Location.Y+(btnGetAttributes.Size.Height * Attributelist.Count) + 35;
            btnAttr.Location = new Point(btnLocX, BtnLocY);
            btnAttr.Name = "btnAttr_" + Attributelist.Count;
             
            btnAttr.Click +=  new EventHandler(btnAttr_Click);
               
         
            this.Controls.Add(btnAttr);
             


            MFT_Attribute Attr = new MFT_Attribute(attr_len, attr_all, attr_type, attrType_string,MFTIndex);

            Attributelist.Add(Attr);
            MFTIndex = MFTattrIndex;
           } while (MFTIndex<1024);

           btnGetAttributes.Enabled = false;
        }

        private static MFT_Attribute _SelectedAttribute;

        public static MFT_Attribute SelectedAttribute
        {
            get // this makes you to access value in form2
            {
                return _SelectedAttribute;
            }
            set // this makes you to change value in form2
            {
                _SelectedAttribute = value;
            }
        }

        void btnAttr_Click(object sender, EventArgs e)
        {
         int attrListSelectedIndex = Convert.ToInt32(((Button)sender).Name.Substring(8));
         SelectedAttribute = (MFT_Attribute)Attributelist.ElementAt(attrListSelectedIndex);

        // txtOutput.Text = attrListSelectedIndex.ToString();
           DisplayAttributeDetails attributesDialoge = new DisplayAttributeDetails();
            attributesDialoge.ShowDialog(this);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtOutput.Text = "";
          //  ClearHighlightedDataView();
        }
        
    }
}
