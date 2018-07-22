using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RawDiskLib;
namespace NTFSLearning
{
    public partial class MainForm_NTFSLearning : Form
    {
        public MainForm_NTFSLearning()
        {
            InitializeComponent();
        }
        private static RawDisk disk;
        private static int _SelectedMFTIndex;
        private static NTFSBootSector _BootSector;
       private static NTFS_MFTHeader_Reader _MFTHeaderReader;
       private static byte[] _SelectedMFT;
       private static int _CurrentStartingoffsetAddress;
        #region global variables
       
       public static RawDisk SelectedNTFSDISK
       {
           get // this makes you to access value in form2
           {
               return disk;
           }
           set // this makes you to change value in form2
           {
               disk = value;
           }
       }

       public static int SelectedMFTIndex
       {
           get // this makes you to access value in form2
           {
               return _SelectedMFTIndex;
           }
           set // this makes you to change value in form2
           {
               _SelectedMFTIndex = value;
           }
       }

       public static NTFSBootSector BootSector
       {
           get // this makes you to access value in form2
           {
               return _BootSector;
           }
           set // this makes you to change value in form2
           {
               _BootSector = value;
           }
       }

       public static NTFS_MFTHeader_Reader MFTHeaderReader
       {
           get // this makes you to access value in form2
           {
               return _MFTHeaderReader;
           }
           set // this makes you to change value in form2
           {
               _MFTHeaderReader = value;
           }
       }

       public static byte[] SelectedMFT
       {
           get // this makes you to access value in form2
           {
               return _SelectedMFT;
           }
           set // this makes you to change value in form2
           {
               _SelectedMFT = value;
           }
       }
       public static int CurrentStartingoffsetAddress
       {
           get // this makes you to access value in form2
           {
               return _CurrentStartingoffsetAddress;
           }
           set // this makes you to change value in form2
           {
               _CurrentStartingoffsetAddress = value;
           }
       }  
        #endregion
     #region DataGride DataView Functions
     void DisplayBytesDataView(byte[] DataBytes, int Datasize, int offsetStartdecimal)
       {
           ClearHighlightedDataView();
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

        private void btnLoadBootSector_Click(object sender, EventArgs e)
        {
           
             BootSector = new NTFSBootSector(disk);
             grpBootsector.Visible = true;
             grpMFTMetadata.Visible = true;
             grpBootsector.Enabled = true;
           
            
            DisplayBytesDataView(BootSector.sectorData, disk.SectorSize, 0);
            grpMFTMetadata.Enabled = true;
          
        }
        //3	Jump to boot code
        private void button1_Click(object sender, EventArgs e)
        {   
            txtOutput.Text = txtOutput.Text + "Byte 0-2 : Jump code  " + Environment.NewLine;
            SelectValue_only_onDataView(BootSector.sectorData, disk.SectorSize, 0, 2, Color.Red);
            
          

        }
        //8	OEM Name
        private void button2_Click(object sender, EventArgs e)
        {
                       
            txtOutput.Text = txtOutput.Text + "Byte 3-10 : OEM Name "  + Environment.NewLine;
            SelectValue_only_onDataView(BootSector.sectorData, disk.SectorSize, 3, 10, Color.Red);
          
        }
        //2	Bytes Per Sector
        private void button3_Click(object sender, EventArgs e)
        {
            txtOutput.Text = txtOutput.Text + "Byte 11-12 : Bytes Per sector= " + BootSector.BytesPerSector.ToString() + Environment.NewLine;
            SelectValue_only_onDataView(BootSector.sectorData, disk.SectorSize, 11, 12, Color.Red);
        }
        //1	Sectors Per Cluster
        private void button4_Click(object sender, EventArgs e)
        {
            txtOutput.Text = txtOutput.Text + "Byte 13 : Sector per Cluster= " + BootSector.SectorsPerCluster+Environment.NewLine;
            SelectValue_only_onDataView(BootSector.sectorData, disk.SectorSize, 13, 13, Color.Red);
        }
        //2	Reserved Sectors
        private void button5_Click(object sender, EventArgs e)
        {
            txtOutput.Text = txtOutput.Text + "Bytes 14-15 : Reserved Sectors= " + BootSector.ReservedSectors + Environment.NewLine;
            SelectValue_only_onDataView(BootSector.sectorData, disk.SectorSize, 14, 15, Color.Red);
        }
        

        //3	always 0     
         private void button6_Click(object sender, EventArgs e)
        {
            txtOutput.Text = txtOutput.Text + "Bytes 16-18 : Always 0 Microsoft says it must be 0"  + Environment.NewLine;
            SelectValue_only_onDataView(BootSector.sectorData, disk.SectorSize, 16, 18, Color.Red);

        }
                //2	not used by NTFS  
                private void button7_Click(object sender, EventArgs e)
                 {
           
                    txtOutput.Text = txtOutput.Text + "Bytes 19- 20 Unused by NTFS " + Environment.NewLine;
                    SelectValue_only_onDataView(BootSector.sectorData, disk.SectorSize, 19, 20, Color.Red);
                }
                //1	Media Descriptor
                private void button8_Click(object sender, EventArgs e)
                {
                    txtOutput.Text = txtOutput.Text + "Byte 21 Media descriptor " + Environment.NewLine;
                    SelectValue_only_onDataView(BootSector.sectorData, disk.SectorSize, 21, 21, Color.Red);
                }
                //2	always 0
                private void button9_Click(object sender, EventArgs e)
                {
                     txtOutput.Text = txtOutput.Text + "Bytes 22-23 : Always 0 Microsoft says it must be 0" + Environment.NewLine;
                     SelectValue_only_onDataView(BootSector.sectorData, disk.SectorSize, 22,23, Color.Red);

                    
                }
                //2	Sectors Per Track
                private void button10_Click(object sender, EventArgs e)
                {
                    txtOutput.Text = txtOutput.Text + "Bytes 24-25 : Sectors per Track" + Environment.NewLine;
                    SelectValue_only_onDataView(BootSector.sectorData, disk.SectorSize, 24, 25, Color.Red);
                 
                }
                //2	Number Of Heads 
                private void button11_Click(object sender, EventArgs e)
                {
                    txtOutput.Text = txtOutput.Text + "Bytes 26-27 : Number Of Heads " + Environment.NewLine;
                    SelectValue_only_onDataView(BootSector.sectorData, disk.SectorSize, 26, 27, Color.Red);
                }
                //4	Hidden Sectors    
                private void button12_Click(object sender, EventArgs e)
                {
                    txtOutput.Text = txtOutput.Text + "Bytes 28-31 : Hidden Sectors   " + Environment.NewLine;
                    SelectValue_only_onDataView(BootSector.sectorData, disk.SectorSize, 28, 31, Color.Red);
                }
                //4	not used by NTFS  
                private void button13_Click(object sender, EventArgs e)
                {
                    txtOutput.Text = txtOutput.Text + "Bytes 32-35 : Unused by NTFS     " + Environment.NewLine;
                    SelectValue_only_onDataView(BootSector.sectorData, disk.SectorSize, 32, 35, Color.Red);
                }
                //4	not used by NTFS  
                private void button14_Click(object sender, EventArgs e)
                {
                    txtOutput.Text = txtOutput.Text + "Bytes 36-39 : Unused by NTFS     " + Environment.NewLine;
                    SelectValue_only_onDataView(BootSector.sectorData, disk.SectorSize, 36, 39, Color.Red);
                }
                //8	Total Sectors  
                private void button28_Click(object sender, EventArgs e)
                {
                    txtOutput.Text = txtOutput.Text + "Bytes 40-47:Total Sectors in File System "+BootSector.TotalSectors + Environment.NewLine;
                    SelectValue_only_onDataView(BootSector.sectorData, disk.SectorSize, 40, 47, Color.Red);
                }
                //8	Logical Cluster Number for the file $MFT  
                private void button27_Click(object sender, EventArgs e)
                {
                       txtOutput.Text = txtOutput.Text + "Bytes 48-55: Starting cluster address of $MFT =" + BootSector.ClusterNoFirstMFT.ToString("X2")+"hx" + Environment.NewLine;
                       SelectValue_only_onDataView(BootSector.sectorData, disk.SectorSize, 48,55 , Color.Red);
                }
                //8	Logical Cluster Number for the file $MFTMirr   
                private void button26_Click(object sender, EventArgs e)
                {
                    
                      txtOutput.Text = txtOutput.Text + "Bytes 56-63: Starting cluster address of MFT Mirror $DATA attribute $MFTMirr =" + BootSector.ClusterNoMFTMirr.ToString("X2") + "hx" + Environment.NewLine;
                      SelectValue_only_onDataView(BootSector.sectorData, disk.SectorSize, 56, 63, Color.Red);
                }
                //4	Clusters Per File Record Segment 
                private void button24_Click(object sender, EventArgs e)
                {

                    txtOutput.Text = txtOutput.Text + "Byte 64: Size of file record (MFT entry)= " + BootSector.MFTentrySize.ToString("X2") + "hx" + Environment.NewLine;
                      SelectValue_only_onDataView(BootSector.sectorData, disk.SectorSize, 64,64, Color.Red);
                
                    
                }
                //4	Clusters Per Index Block 
                private void button23_Click(object sender, EventArgs e)
                {

                    txtOutput.Text = txtOutput.Text + "Byte 68: Size of index record" + BootSector.indexRecordSize.ToString("X2") + "hx" + Environment.NewLine;
                    SelectValue_only_onDataView(BootSector.sectorData, disk.SectorSize, 68, 68, Color.Red);
                
                }
                //8	Volume Serial Number 
                private void button22_Click(object sender, EventArgs e)
                {
                    txtOutput.Text = txtOutput.Text + "Bytes 72-79:Volume Serial Number " + BootSector.indexRecordSize.ToString("X2") + "hx" + Environment.NewLine;
                    SelectValue_only_onDataView(BootSector.sectorData, disk.SectorSize, 72, 79, Color.Red);
                }
                //4	Checksum  
                private void button21_Click(object sender, EventArgs e)
                {
                    txtOutput.Text = txtOutput.Text + "Bytes 80-83: Checksum  " + Environment.NewLine;
                    SelectValue_only_onDataView(BootSector.sectorData, disk.SectorSize, 80, 83, Color.Red);
                     
                }
                //426	Bootstrap program code 
                private void button20_Click(object sender, EventArgs e)
                {
                    txtOutput.Text = txtOutput.Text + "Bytes 84-509: Bootstrap code  " + Environment.NewLine;
                    SelectValue_only_onDataView(BootSector.sectorData, disk.SectorSize, 84, 509, Color.Red);
                

                }
                //2	Signature bytes 
                private void button19_Click(object sender, EventArgs e)
                {
                    txtOutput.Text = txtOutput.Text + "Bytes 510-511:Signature (0xaa55) " + BootSector.indexRecordSize.ToString("X2") + "hx" + Environment.NewLine;
                    SelectValue_only_onDataView(BootSector.sectorData, disk.SectorSize, 510,511, Color.Red);
                
                }

               

                public byte[] GetMFT_Entry_by_ClusterNo(int ClusterNo)
                {
                    byte[] MFTEntryData = new byte[1024];
                    byte[] clusterData = disk.ReadClusters(ClusterNo, 1);

                    for (int i = 0; i < 1024; i++)
                    {
                        MFTEntryData[i] = clusterData[i];
                    }

                    return MFTEntryData;
                }

        /*print to output box array bytes 16 byte per ROW
         * */
                void PrintOutputHex16BytesRow(byte[] b ,int size)
                {
                    txtOutput.Text = "";
                    for (int i = 0; i < size ; i++)
                    {
                        txtOutput.Text = txtOutput.Text + b[i].ToString("X2") + " ";
                        if ((i > 0) && (i % 16 == 0)) txtOutput.Text = txtOutput.Text + Environment.NewLine;
                    }
                }
                
                private void button15_Click(object sender, EventArgs e)
                {
                    NTFS_MFT_Entry_Reader MFTReader = new NTFS_MFT_Entry_Reader(disk,BootSector);
                     SelectedMFT=GetMFT_Entry_by_ClusterNo(BootSector.ClusterNoFirstMFT);
                    txtOutput.Text=txtOutput.Text+ "Starting MFT at cluster " + BootSector.ClusterNoFirstMFT.ToString("X2")+Environment.NewLine;
                    CurrentStartingoffsetAddress = BootSector.ClusterNoFirstMFT * BootSector.BytesPerSector * BootSector.SectorsPerCluster;
                    DisplayBytesDataView(SelectedMFT, 1024, CurrentStartingoffsetAddress);
                    grpBootsector.Visible = false;
                    //grpMFTEntryHeader.Visible = true;
                    SelectedMFTIndex = 0;
                    GetMFTHeader_ofSelectedMFT(SelectedMFT);
                }

                private void button16_Click(object sender, EventArgs e)
                {
                    if (txtDriveLetter.Text.Length != 1) MessageBox.Show("No drive letter recognized");
                    else
                    {
                        char[] chars = txtDriveLetter.Text.ToCharArray();
                        char driveLetter = chars[0];
                        try
                        {
                            disk = new RawDisk(driveLetter);
                            // 1715
                            txtOutput.Text = " Disk DosDeviceName : " + disk.DosDeviceName + Environment.NewLine;
                            txtOutput.Text = txtOutput.Text + "Disk ClusterSize = " + disk.ClusterSize + "  Disk ClusterCount= " + disk.ClusterCount + Environment.NewLine;
                            txtOutput.Text = txtOutput.Text + "Disk SectorCount = " + disk.SectorCount + " Disk Sector Size=  " + disk.SectorSize + " SizeBytes= " + disk.SizeBytes + Environment.NewLine;
                            btnLoadBootSector.Enabled = true;
                            btnLoadBootSector.Visible = true;
                            grploadboot.Visible = true;
                            grp_.Visible = true;
                            grpMFTMetadata.Visible = true;
                            grpData.Visible = true;
                            
                        }
                        catch (Exception ex) { MessageBox.Show("No drive located or the drive is used by other device"); }
                      
                      
                    }
                }

                private void btnClear_Click(object sender, EventArgs e)
                {
                    txtOutput.Text = "";
                    ClearHighlightedDataView();
                }

        private  byte[] GET_andDisplayMFT_byIndexNumber(int MFTindex)
                {
                    NTFS_MFT_Entry_Reader MFTReader = new NTFS_MFT_Entry_Reader(disk, BootSector);
                    byte[] MFTEntry = MFTReader.GetMFT_Entry_by_MFTIndex(MFTindex);
                    CurrentStartingoffsetAddress = (BootSector.ClusterNoFirstMFT * BootSector.BytesPerSector * BootSector.SectorsPerCluster) + (MFTindex*1024);
                    txtOutput.Text = txtOutput.Text + " MFT " + MFTindex + " at offset address  " + CurrentStartingoffsetAddress.ToString("X2") + Environment.NewLine;

                    DisplayBytesDataView(MFTEntry, 1024, CurrentStartingoffsetAddress);
                    return MFTEntry;
        }
      
        
       private void GetMFTHeader_ofSelectedMFT(byte[] MFT)
        {
            byte[] MFTHeader = new byte[42];
            for (int i = 0; i < 42; i++)
            {
                MFTHeader[i] = MFT[i];
            }
          MFTHeaderReader = new NTFS_MFTHeader_Reader(MFTHeader);
            //grpMFTEntryHeader.Visible = true;
            btnGetMFTattributes.Visible = true;
            grpBootsector.Visible = false;
        }

                private void button37_Click(object sender, EventArgs e)
                {
                    SelectedMFTIndex = 1;
                   SelectedMFT= GET_andDisplayMFT_byIndexNumber(1);
                   GetMFTHeader_ofSelectedMFT(SelectedMFT);
                   
                }

                private void button15_Click_1(object sender, EventArgs e)
                {
                    SelectValue_onDataView(MFTHeaderReader.Headerdata, 42, 0, 3, Color.Red);
                    txtOutput.Text = txtOutput.Text + "Bytes 0-3 : MFT Signiture FILE" +Environment.NewLine;
        }

                private void button45_Click(object sender, EventArgs e)
                {
                    SelectValue_onDataView(MFTHeaderReader.Headerdata, 42, 0, 41, Color.Yellow);
                }

                private void button38_Click(object sender, EventArgs e)
                {
                    SelectedMFTIndex = 2;
                    SelectedMFT= GET_andDisplayMFT_byIndexNumber(2);
                    GetMFTHeader_ofSelectedMFT(SelectedMFT);
                }

                private void button41_Click(object sender, EventArgs e)
                {
                    SelectedMFTIndex = 3;

                    SelectedMFT = GET_andDisplayMFT_byIndexNumber(SelectedMFTIndex);
                    GetMFTHeader_ofSelectedMFT(SelectedMFT);
                }

                private void button40_Click(object sender, EventArgs e)
                {
                    SelectedMFTIndex = 4;
                    SelectedMFT = GET_andDisplayMFT_byIndexNumber(SelectedMFTIndex);
                    GetMFTHeader_ofSelectedMFT(SelectedMFT);
                }

                private void button39_Click(object sender, EventArgs e)
                {
                    SelectedMFTIndex = 5;
                    SelectedMFT = GET_andDisplayMFT_byIndexNumber(SelectedMFTIndex);
                    GetMFTHeader_ofSelectedMFT(SelectedMFT);
                }

                private void button44_Click(object sender, EventArgs e)
                {
                    SelectedMFTIndex = 6;
                    SelectedMFT = GET_andDisplayMFT_byIndexNumber(SelectedMFTIndex);
                    GetMFTHeader_ofSelectedMFT(SelectedMFT);
                }

                private void button43_Click(object sender, EventArgs e)
                {
                    SelectedMFTIndex = 7;
                    SelectedMFT = GET_andDisplayMFT_byIndexNumber(SelectedMFTIndex);
                    GetMFTHeader_ofSelectedMFT(SelectedMFT);
                }

                private void button42_Click(object sender, EventArgs e)
                {
                    SelectedMFTIndex = 8;
                    SelectedMFT = GET_andDisplayMFT_byIndexNumber(SelectedMFTIndex);
                    GetMFTHeader_ofSelectedMFT(SelectedMFT);
                }
                   
                private void button17_Click(object sender, EventArgs e)
                {//offset to fixup array
                    txtOutput.Text = txtOutput.Text + "Bytes 4-5 : Offset to fixup array =  " + MFTHeaderReader.OffsetFixupArray.ToString() + Environment.NewLine;
                    SelectValue_onDataView(MFTHeaderReader.Headerdata, 42, 4, 5, Color.Wheat);
                }

                private void button32_Click(object sender, EventArgs e)
                {//no of entries in fixup array
                    txtOutput.Text = txtOutput.Text + "Bytes 6-7 : Number of entries in fixup array =  " + MFTHeaderReader.NoEntryFixupArray.ToString() + Environment.NewLine;
                    SelectValue_onDataView(MFTHeaderReader.Headerdata, 42, 6, 7, Color.Brown);
                }

                private void button18_Click(object sender, EventArgs e)
                {//log file
                    txtOutput.Text = txtOutput.Text + "Bytes 8-15 : $LogFile Sequence number =  " + MFTHeaderReader.LogFileSeq.ToString() + Environment.NewLine;
                    SelectValue_onDataView(MFTHeaderReader.Headerdata, 42, 8, 15, Color.CadetBlue);
                }

                 private void button46_Click(object sender, EventArgs e)
                 {// sequence value
                    SelectValue_onDataView(MFTHeaderReader.Headerdata, 42, 16, 17, Color.Coral);
                    txtOutput.Text = txtOutput.Text + "Bytes 16-17 : Sequence value =  " + MFTHeaderReader.seqvalue.ToString() + Environment.NewLine;
                }

                private void button25_Click(object sender, EventArgs e)
                {//link count 
                    txtOutput.Text = txtOutput.Text + "Bytes 18-19 : Link count =  " + MFTHeaderReader.linkcount.ToString() + Environment.NewLine;
                    SelectValue_onDataView(MFTHeaderReader.Headerdata, 42, 18, 19, Color.Crimson);
                }

                private void button29_Click(object sender, EventArgs e)
                {
                    //offset to first attribute
                    SelectValue_onDataView(MFTHeaderReader.Headerdata, 42, 20, 21, Color.Lavender);
                    txtOutput.Text = txtOutput.Text + "Bytes 20-21 : Offset to firt attribute =  " + MFTHeaderReader.offsettoattr1.ToString() + Environment.NewLine;
                }

                private void button30_Click(object sender, EventArgs e)
                {
                    //flag (in use and directory)
                    SelectValue_onDataView(MFTHeaderReader.Headerdata, 42, 22, 23, Color.Orange);
                    txtOutput.Text = txtOutput.Text + "Bytes 22-23 : Flags (in-use and directory) =  " + MFTHeaderReader.flags.ToString() + Environment.NewLine;
                }

                private void button31_Click(object sender, EventArgs e)
                {
                    //used Size of MFT entry 
                    SelectValue_onDataView(MFTHeaderReader.Headerdata, 42, 24, 27, Color.LightBlue);
                    txtOutput.Text = txtOutput.Text + "Bytes 24-27 : Used size of MFT Entry =  " + MFTHeaderReader.MFTentrysize.ToString() + Environment.NewLine;
            
                }

                private void button35_Click(object sender, EventArgs e)
                {
                    //allocated size of MFT Entry
                    SelectValue_onDataView(MFTHeaderReader.Headerdata, 42, 28, 31, Color.LightGreen);
                    txtOutput.Text = txtOutput.Text + "Bytes 28-31 : Allocated size of MFT entry =  " + MFTHeaderReader.allMFTentry.ToString() + Environment.NewLine;
                 }

                private void button34_Click(object sender, EventArgs e)
                {
                    //file reference to base record
                    SelectValue_onDataView(MFTHeaderReader.Headerdata, 42, 32, 39, Color.LightPink);
                    txtOutput.Text = txtOutput.Text + "Bytes 32-39 : File reference to first record =  " + MFTHeaderReader.baserecordfileref.ToString() + Environment.NewLine;
                }

                private void button33_Click(object sender, EventArgs e)
                { //next attribute
                    SelectValue_onDataView(MFTHeaderReader.Headerdata, 42, 40, 41, Color.LightSeaGreen);
                    txtOutput.Text = txtOutput.Text + "Bytes 40-41 : Next Attribute ID =  " + MFTHeaderReader.nextattrid.ToString() + Environment.NewLine;
                }

                private void btnMFTbytxtIndex_Click(object sender, EventArgs e)
                {
                    if (txtMFTindex.Text.Length < 0)
                        MessageBox.Show("No Index have been entered ");
                    else
                    {
                        try
                        {
                            SelectedMFTIndex = Convert.ToInt32(txtMFTindex.Text);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Not Valid Index value have been entered ");
                        }

                    }

                    SelectedMFT = GET_andDisplayMFT_byIndexNumber(SelectedMFTIndex);
                    GetMFTHeader_ofSelectedMFT(SelectedMFT);
                   
                }

                private void button36_Click(object sender, EventArgs e)
                {
                    SelectedMFTIndex = 9;
                    SelectedMFT = GET_andDisplayMFT_byIndexNumber(SelectedMFTIndex);
                    GetMFTHeader_ofSelectedMFT(SelectedMFT);
                }

                private void Form1_Load(object sender, EventArgs e)
                {
                    this.Location = new Point(0, 0);
                    this.Size = Screen.PrimaryScreen.WorkingArea.Size;
                }

                private void btnGetMFTattributes_Click(object sender, EventArgs e)
                {
                    DisplayAttributes attributesDialoge = new DisplayAttributes();

                    attributesDialoge.ShowDialog(this);
                }

        

        private void dataView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}




