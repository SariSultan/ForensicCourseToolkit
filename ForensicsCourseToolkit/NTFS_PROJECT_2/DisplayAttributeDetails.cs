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
    public partial class DisplayAttributeDetails : Form
    {
        public DisplayAttributeDetails()
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

         public MFT_Attribute Selected_Attribute;

       

        public void DisplayAttributeDetails_Load(object sender, EventArgs e)
        {
            Selected_Attribute = DisplayAttributes.SelectedAttribute;
            DisplayBytesDataView(MainForm_NTFSLearning.SelectedMFT, 1024, MainForm_NTFSLearning.CurrentStartingoffsetAddress);
            SelectValue_onDataView(Selected_Attribute.attr_data, Selected_Attribute.length, Selected_Attribute.MFTStartingIndex, (Selected_Attribute.MFTStartingIndex + Selected_Attribute.length - 1), Color.LightBlue);
        
           lblAttr_name.Text= Selected_Attribute.atrrTypeStr;
         
            
            if (Selected_Attribute.attrtypeIdentifier == Convert.ToInt32("10", 16)) //stander Information
            {
                if (Selected_Attribute.non_residentFlag == 0)
                    {
                /** for resident attribute  values to be used   */
                        Display_ResidentAttributeHeader();
                      STANDARD_INFORMATION STANDARD_INFORMATION_attr = new STANDARD_INFORMATION( Selected_Attribute.attr_content_size,Selected_Attribute.attr_Content);
                      Display_STANDARD_INFORMATION(STANDARD_INFORMATION_attr);
                      ////heighlit attribute content
                      SelectValue_onDataView(Selected_Attribute.attr_Content, Selected_Attribute.attr_content_size, Selected_Attribute.MFTStartingIndex + Selected_Attribute.ResidentAttrHeader.OffsetToContent, (Selected_Attribute.MFTStartingIndex + Selected_Attribute.ResidentAttrHeader.OffsetToContent + Selected_Attribute.attr_content_size - 1), Color.Khaki);
            
                    }
                 else if (Selected_Attribute.non_residentFlag == 1)
                    {
                        Display_Non_ResidentAttributeHeader();
             
                   }
             }
            else if (Selected_Attribute.attrtypeIdentifier == Convert.ToInt32("20", 16)) //$ATTRIBUTE_LIST

            {
                if (Selected_Attribute.non_residentFlag == 0)
                {
                    /** for resident attribute  values to be used   */
                    Display_ResidentAttributeHeader();
                    AttributeList x = new AttributeList(Selected_Attribute.attr_content_size, Selected_Attribute.attr_Content);
                    Display_ATTRIBUTE_LIST(x);
                    ////heighlit attribute content
                    SelectValue_onDataView(Selected_Attribute.attr_Content, Selected_Attribute.attr_content_size, Selected_Attribute.MFTStartingIndex + Selected_Attribute.ResidentAttrHeader.OffsetToContent, (Selected_Attribute.MFTStartingIndex + Selected_Attribute.ResidentAttrHeader.OffsetToContent + Selected_Attribute.attr_content_size - 1), Color.Khaki);

                }
                else if (Selected_Attribute.non_residentFlag == 1)
                {
                    Display_Non_ResidentAttributeHeader();
                  
                }
            }

            else if (Selected_Attribute.attrtypeIdentifier == Convert.ToInt32("30", 16)) //$FILE_NAME
            {
                if (Selected_Attribute.non_residentFlag == 0)
                {
                    /** for resident attribute  values to be used   */
                    Display_ResidentAttributeHeader();
                   
                      FileName  x = new FileName(Selected_Attribute.attr_content_size, Selected_Attribute.attr_Content);
                      Display_FileName(x);
                    ////heighlit attribute content
                    SelectValue_onDataView(Selected_Attribute.attr_Content, Selected_Attribute.attr_content_size, Selected_Attribute.MFTStartingIndex + Selected_Attribute.ResidentAttrHeader.OffsetToContent, (Selected_Attribute.MFTStartingIndex + Selected_Attribute.ResidentAttrHeader.OffsetToContent + Selected_Attribute.attr_content_size - 1), Color.Khaki);

                }
                else if (Selected_Attribute.non_residentFlag == 1)
                {
                    Display_Non_ResidentAttributeHeader();
                   
                }
            
            }
            else if (Selected_Attribute.attrtypeIdentifier == Convert.ToInt32("40", 16)) //$OBJECT_ID
            {
                if (Selected_Attribute.non_residentFlag == 0)
                {
                    /** for resident attribute  values to be used   */
                    Display_ResidentAttributeHeader();
                    Object_ID x=new Object_ID(Selected_Attribute.attr_content_size, Selected_Attribute.attr_Content);
                   
                   Display_Object_ID(x);
                    ////heighlit attribute content
                    SelectValue_onDataView(Selected_Attribute.attr_Content, Selected_Attribute.attr_content_size, Selected_Attribute.MFTStartingIndex + Selected_Attribute.ResidentAttrHeader.OffsetToContent, (Selected_Attribute.MFTStartingIndex + Selected_Attribute.ResidentAttrHeader.OffsetToContent + Selected_Attribute.attr_content_size - 1), Color.Khaki);

                }
                else if (Selected_Attribute.non_residentFlag == 1)
                {
                    
                    Display_Non_ResidentAttributeHeader();

                  
                }
            
            }
          

          
            else if (Selected_Attribute.attrtypeIdentifier == Convert.ToInt32("50", 16)) //"$SECURITY_DESCRIPTOR"
            {
                if (Selected_Attribute.non_residentFlag == 0)
                {
                    /** for resident attribute  values to be used   */
                    Display_ResidentAttributeHeader();

                    ////heighlit attribute content
                     SelectValue_onDataView(Selected_Attribute.attr_Content, Selected_Attribute.attr_content_size, Selected_Attribute.MFTStartingIndex + Selected_Attribute.ResidentAttrHeader.OffsetToContent, (Selected_Attribute.MFTStartingIndex + Selected_Attribute.ResidentAttrHeader.OffsetToContent + Selected_Attribute.attr_content_size - 1), Color.Khaki);

                }
                else if (Selected_Attribute.non_residentFlag == 1)
                {
                    /***non resident attribut   values to be used  */
                    Display_Non_ResidentAttributeHeader();

                }

            }

                    
            else if (Selected_Attribute.attrtypeIdentifier == Convert.ToInt32("60", 16)) //$VOLUME_NAME
            {
                if (Selected_Attribute.non_residentFlag == 0)
                {
                    /** for resident attribute  values to be used   */
                    Display_ResidentAttributeHeader();

                    VOLUME_INFORMATION x = new VOLUME_INFORMATION(Selected_Attribute.attr_content_size, Selected_Attribute.attr_Content);

                    Display_VOLUME_INFORMATION(x);
                    ////heighlit attribute content
                      SelectValue_onDataView(Selected_Attribute.attr_Content, Selected_Attribute.attr_content_size, Selected_Attribute.MFTStartingIndex + Selected_Attribute.ResidentAttrHeader.OffsetToContent, (Selected_Attribute.MFTStartingIndex + Selected_Attribute.ResidentAttrHeader.OffsetToContent + Selected_Attribute.attr_content_size - 1), Color.Khaki);

                }
                else if (Selected_Attribute.non_residentFlag == 1)
                {
                    /***non resident attribut   values to be used  */
                    Display_Non_ResidentAttributeHeader();

                }

            }

            
            else if (Selected_Attribute.attrtypeIdentifier == Convert.ToInt32("70", 16)) //VOLUME_INFORMATION
            {
                if (Selected_Attribute.non_residentFlag == 0)
                {
                    /** for resident attribute  values to be used   */
                    Display_ResidentAttributeHeader();

                    ////heighlit attribute content
                     SelectValue_onDataView(Selected_Attribute.attr_Content, Selected_Attribute.attr_content_size, Selected_Attribute.MFTStartingIndex + Selected_Attribute.ResidentAttrHeader.OffsetToContent, (Selected_Attribute.MFTStartingIndex + Selected_Attribute.ResidentAttrHeader.OffsetToContent + Selected_Attribute.attr_content_size - 1), Color.Khaki);

                }
                else if (Selected_Attribute.non_residentFlag == 1)
                {
                    /***non resident attribut   values to be used  */
                    Display_Non_ResidentAttributeHeader();
                                       
                }

            }

            else if (Selected_Attribute.attrtypeIdentifier == Convert.ToInt32("80", 16)) //$DATA
            {
                if (Selected_Attribute.non_residentFlag == 0)
                {
                    /** for resident attribute  values to be used   */
                    Display_ResidentAttributeHeader();

                    ////heighlit attribute content
                    SelectValue_onDataView(Selected_Attribute.attr_Content, Selected_Attribute.attr_content_size, Selected_Attribute.MFTStartingIndex + Selected_Attribute.ResidentAttrHeader.OffsetToContent, (Selected_Attribute.MFTStartingIndex + Selected_Attribute.ResidentAttrHeader.OffsetToContent + Selected_Attribute.attr_content_size - 1), Color.Khaki);

                }
                else if (Selected_Attribute.non_residentFlag == 1)
                {
                    /***non resident attribut   values to be used  */
                    Display_Non_ResidentAttributeHeader();


                }

            }
            else if (Selected_Attribute.attrtypeIdentifier == Convert.ToInt32("90", 16)) //$INDEX_ROOT
            {
                if (Selected_Attribute.non_residentFlag == 0)
                {
                    /** for resident attribute  values to be used   */
                    Display_ResidentAttributeHeader();

                    INDEX_ROOT x = new INDEX_ROOT(Selected_Attribute.attr_content_size, Selected_Attribute.attr_Content);
                    Display_INDEX_ROOT(x);
                    ////heighlit attribute content
                    SelectValue_onDataView(Selected_Attribute.attr_Content, Selected_Attribute.attr_content_size, Selected_Attribute.MFTStartingIndex + Selected_Attribute.ResidentAttrHeader.OffsetToContent, (Selected_Attribute.MFTStartingIndex + Selected_Attribute.ResidentAttrHeader.OffsetToContent + Selected_Attribute.attr_content_size - 1), Color.Khaki);

                }
                else if (Selected_Attribute.non_residentFlag == 1)
                {
                    /***non resident attribut   values to be used  */
                    Display_Non_ResidentAttributeHeader();

                    
                }

            }
          
            else if (Selected_Attribute.attrtypeIdentifier == Convert.ToInt32("A0", 16)) //$INDEX_Allocation
            {
                if (Selected_Attribute.non_residentFlag == 0)
                {
                    /** for resident attribute  values to be used   */
                    Display_ResidentAttributeHeader();
                              
                    ////heighlit attribute content
                    SelectValue_onDataView(Selected_Attribute.attr_Content, Selected_Attribute.attr_content_size, Selected_Attribute.MFTStartingIndex + Selected_Attribute.ResidentAttrHeader.OffsetToContent, (Selected_Attribute.MFTStartingIndex + Selected_Attribute.ResidentAttrHeader.OffsetToContent + Selected_Attribute.attr_content_size - 1), Color.Khaki);

                }
                else if (Selected_Attribute.non_residentFlag == 1)
                {
                    /***non resident attribut   values to be used  */
                    Display_Non_ResidentAttributeHeader();
                   
              
                }

            }
            else if (Selected_Attribute.attrtypeIdentifier == Convert.ToInt32("B0", 16)) //$BITMAP
            {
                if (Selected_Attribute.non_residentFlag == 0)
                {
                    /** for resident attribute  values to be used   */
                    Display_ResidentAttributeHeader();

                    ////heighlit attribute content
                     SelectValue_onDataView(Selected_Attribute.attr_Content, Selected_Attribute.attr_content_size, Selected_Attribute.MFTStartingIndex + Selected_Attribute.ResidentAttrHeader.OffsetToContent, (Selected_Attribute.MFTStartingIndex + Selected_Attribute.ResidentAttrHeader.OffsetToContent + Selected_Attribute.attr_content_size - 1), Color.Khaki);

                }
                else if (Selected_Attribute.non_residentFlag == 1)
                {
                    /***non resident attribut   values to be used  */
                    Display_Non_ResidentAttributeHeader();


                }

            }
            else if (Selected_Attribute.attrtypeIdentifier == Convert.ToInt32("C0", 16)) //$REPARSE_POINT
            {
                if (Selected_Attribute.non_residentFlag == 0)
                {
                    /** for resident attribute  values to be used   */
                    Display_ResidentAttributeHeader();
                    REPARSE_POINT x=new REPARSE_POINT(Selected_Attribute.attr_content_size, Selected_Attribute.attr_Content);
                    Display_REPARSE_POINT(x);
                    ////heighlit attribute content
                   SelectValue_onDataView(Selected_Attribute.attr_Content, Selected_Attribute.attr_content_size, Selected_Attribute.MFTStartingIndex + Selected_Attribute.ResidentAttrHeader.OffsetToContent, (Selected_Attribute.MFTStartingIndex + Selected_Attribute.ResidentAttrHeader.OffsetToContent + Selected_Attribute.attr_content_size - 1), Color.Khaki);

                }
                else if (Selected_Attribute.non_residentFlag == 1)
                {
                    /***non resident attribut   values to be used  */
                    Display_Non_ResidentAttributeHeader();


                    /*  for (int i = 0; i < Selected_Attribute.RunLists.Count; i++)
                      {  txtOutput.Text = txtOutput.Text +
                      }*/
                    //Run List " + Selected_Attribute.RunLists.Count;
                    // txtOutput.Text = Selected_Attribute.RunLists.ElementAt(0).startCluster.ToString("X2");
                    byte[] attrContent1 = Selected_Attribute.RunLists.ElementAt(0).GetData();
                    int attrcontent1 = Selected_Attribute.RunLists.ElementAt(0).dataSize;
                }

            }


            else if (Selected_Attribute.attrtypeIdentifier == Convert.ToInt32("D0", 16)) //$EA_INFORMATION
            {
                if (Selected_Attribute.non_residentFlag == 0)
                {
                    /** for resident attribute  values to be used   */
                    Display_ResidentAttributeHeader();

                    ////heighlit attribute content
                    //  SelectValue_onDataView(Selected_Attribute.attr_Content, Selected_Attribute.attr_content_size, Selected_Attribute.MFTStartingIndex + Selected_Attribute.ResidentAttrHeader.OffsetToContent, (Selected_Attribute.MFTStartingIndex + Selected_Attribute.ResidentAttrHeader.OffsetToContent + Selected_Attribute.attr_content_size - 1), Color.Khaki);

                }
                else if (Selected_Attribute.non_residentFlag == 1)
                {
                    /***non resident attribut   values to be used  */
                    Display_Non_ResidentAttributeHeader();


                    /*  for (int i = 0; i < Selected_Attribute.RunLists.Count; i++)
                      {  txtOutput.Text = txtOutput.Text +
                      }*/
                    //Run List " + Selected_Attribute.RunLists.Count;
                    // txtOutput.Text = Selected_Attribute.RunLists.ElementAt(0).startCluster.ToString("X2");
                    byte[] attrContent1 = Selected_Attribute.RunLists.ElementAt(0).GetData();
                    int attrcontent1 = Selected_Attribute.RunLists.ElementAt(0).dataSize;
                }

            }


            else if (Selected_Attribute.attrtypeIdentifier == Convert.ToInt32("E0", 16)) //$EA
            {
                if (Selected_Attribute.non_residentFlag == 0)
                {
                    /** for resident attribute  values to be used   */
                    Display_ResidentAttributeHeader();

                    ////heighlit attribute content
                    //  SelectValue_onDataView(Selected_Attribute.attr_Content, Selected_Attribute.attr_content_size, Selected_Attribute.MFTStartingIndex + Selected_Attribute.ResidentAttrHeader.OffsetToContent, (Selected_Attribute.MFTStartingIndex + Selected_Attribute.ResidentAttrHeader.OffsetToContent + Selected_Attribute.attr_content_size - 1), Color.Khaki);

                }
                else if (Selected_Attribute.non_residentFlag == 1)
                {
                    /***non resident attribut   values to be used  */
                    Display_Non_ResidentAttributeHeader();


                    /*  for (int i = 0; i < Selected_Attribute.RunLists.Count; i++)
                      {  txtOutput.Text = txtOutput.Text +
                      }*/
                    //Run List " + Selected_Attribute.RunLists.Count;
                    // txtOutput.Text = Selected_Attribute.RunLists.ElementAt(0).startCluster.ToString("X2");
                    byte[] attrContent1 = Selected_Attribute.RunLists.ElementAt(0).GetData();
                    int attrcontent1 = Selected_Attribute.RunLists.ElementAt(0).dataSize;
                }

            }
            else if (Selected_Attribute.attrtypeIdentifier == Convert.ToInt32("F0", 16)) //$PROPERTY_SET
            {
                if (Selected_Attribute.non_residentFlag == 0)
                {
                    /** for resident attribute  values to be used   */
                    Display_ResidentAttributeHeader();

                    ////heighlit attribute content
                    //  SelectValue_onDataView(Selected_Attribute.attr_Content, Selected_Attribute.attr_content_size, Selected_Attribute.MFTStartingIndex + Selected_Attribute.ResidentAttrHeader.OffsetToContent, (Selected_Attribute.MFTStartingIndex + Selected_Attribute.ResidentAttrHeader.OffsetToContent + Selected_Attribute.attr_content_size - 1), Color.Khaki);

                }
                else if (Selected_Attribute.non_residentFlag == 1)
                {
                    /***non resident attribut   values to be used  */
                    Display_Non_ResidentAttributeHeader();


                    /*  for (int i = 0; i < Selected_Attribute.RunLists.Count; i++)
                      {  txtOutput.Text = txtOutput.Text +
                      }*/
                    //Run List " + Selected_Attribute.RunLists.Count;
                    // txtOutput.Text = Selected_Attribute.RunLists.ElementAt(0).startCluster.ToString("X2");
                    byte[] attrContent1 = Selected_Attribute.RunLists.ElementAt(0).GetData();
                    int attrcontent1 = Selected_Attribute.RunLists.ElementAt(0).dataSize;
                }

            }
            else if (Selected_Attribute.attrtypeIdentifier == Convert.ToInt32("100", 16)) //$LOGGESD_UTILITY_STREAM
            {
                if (Selected_Attribute.non_residentFlag == 0)
                {
                    /** for resident attribute  values to be used   */
                    Display_ResidentAttributeHeader();

                    ////heighlit attribute content
                    //  SelectValue_onDataView(Selected_Attribute.attr_Content, Selected_Attribute.attr_content_size, Selected_Attribute.MFTStartingIndex + Selected_Attribute.ResidentAttrHeader.OffsetToContent, (Selected_Attribute.MFTStartingIndex + Selected_Attribute.ResidentAttrHeader.OffsetToContent + Selected_Attribute.attr_content_size - 1), Color.Khaki);

                }
                else if (Selected_Attribute.non_residentFlag == 1)
                {
                    /***non resident attribut   values to be used  */
                    Display_Non_ResidentAttributeHeader();


                    /*  for (int i = 0; i < Selected_Attribute.RunLists.Count; i++)
                      {  txtOutput.Text = txtOutput.Text +
                      }*/
                    //Run List " + Selected_Attribute.RunLists.Count;
                    // txtOutput.Text = Selected_Attribute.RunLists.ElementAt(0).startCluster.ToString("X2");
                    byte[] attrContent1 = Selected_Attribute.RunLists.ElementAt(0).GetData();
                    int attrcontent1 = Selected_Attribute.RunLists.ElementAt(0).dataSize;
                }

            }
           

          
          
        }

        void Display_ResidentAttributeHeader()
        { CalculationUtilities calc=new CalculationUtilities();
            txtOutput.Text=txtOutput.Text+"The Attribute is Resident Attribute have General Attribute header rom byte 0-15 then from byte 16-19 is size of content and from byte 20-21 is offset to content "+Environment.NewLine;
        txtOutput.Text=txtOutput.Text+" General Header Bytes 0-16 "+Environment.NewLine;
 txtOutput.Text = txtOutput.Text +"---------------------------------------------------------------------"+Environment.NewLine;
            txtOutput.Text=txtOutput.Text+"Bytes 0–3 Attribute type identifier "+Selected_Attribute.attrtypeIdentifier.ToString("X2")+"-->"+Selected_Attribute.atrrTypeStr+Environment.NewLine;
txtOutput.Text=txtOutput.Text+"Bytes 4–7 Length of attribute  ="+ Selected_Attribute.length + Environment.NewLine;
txtOutput.Text=txtOutput.Text+"Bytes 8–8 Non-resident flag "+Selected_Attribute.non_residentFlag +Environment.NewLine;
txtOutput.Text=txtOutput.Text+"Bytes 9–9 Length of name "+Selected_Attribute.ResidentAttrHeader.length_Name +Environment.NewLine;
txtOutput.Text=txtOutput.Text+"Bytes 10–11 Offset to name "+Selected_Attribute.ResidentAttrHeader.offset_to_name +Environment.NewLine;
txtOutput.Text=txtOutput.Text+"Bytes 12–13 Flags "+Selected_Attribute.ResidentAttrHeader.Flag +Environment.NewLine;
txtOutput.Text=txtOutput.Text+"Bytes 14–15 Attribute identifier "+Selected_Attribute.ResidentAttrHeader.attributeId +Environment.NewLine;
txtOutput.Text = txtOutput.Text + "Resident attribute  Header cont. Bytes 16-21" + Environment.NewLine;
txtOutput.Text = txtOutput.Text +"---------------------------------------------------------------------"+Environment.NewLine;
txtOutput.Text=txtOutput.Text+"Bytes 16–19 Size of content "+Selected_Attribute.ResidentAttrHeader.ContentSize + Environment.NewLine;
txtOutput.Text = txtOutput.Text + "Bytes 20–21 Offset " +Selected_Attribute.ResidentAttrHeader.OffsetToContent+ Environment.NewLine; 





        }
        void Display_Non_ResidentAttributeHeader()
        {
            CalculationUtilities calc = new CalculationUtilities();
            txtOutput.Text = txtOutput.Text + "The Attribute is Non Resident Attribute have General Attribute header rom byte 0-15 then from byte 16-63 is the remaining header of non resident Attribute " + Environment.NewLine;
            txtOutput.Text = txtOutput.Text + "General Header 0-5 " + Environment.NewLine;
           txtOutput.Text = txtOutput.Text +"---------------------------------------------------------------------"+Environment.NewLine;
            txtOutput.Text = txtOutput.Text + "Bytes 0–3 Attribute type identifier " + Selected_Attribute.attrtypeIdentifier.ToString("X2") + "-->" + Selected_Attribute.atrrTypeStr + Environment.NewLine;
            txtOutput.Text = txtOutput.Text + "Bytes 4–7 Length of attribute  =" + Selected_Attribute.length + Environment.NewLine;
            txtOutput.Text = txtOutput.Text + "Bytes 8–8 Non-resident flag " + Selected_Attribute.non_residentFlag + Environment.NewLine;
            txtOutput.Text = txtOutput.Text + "Bytes 9–9 Length of name " + Selected_Attribute.NonResidentAttrHeader.length_Name + Environment.NewLine;
            txtOutput.Text = txtOutput.Text + "Bytes 10–11 Offset to name " + Selected_Attribute.NonResidentAttrHeader.offset_to_name + Environment.NewLine;
            txtOutput.Text = txtOutput.Text + "Bytes 12–13 Flags " + Selected_Attribute.NonResidentAttrHeader.Flag + Environment.NewLine;
            txtOutput.Text = txtOutput.Text + "Bytes 14–15 Attribute identifier " + Selected_Attribute.NonResidentAttrHeader.attributeId + Environment.NewLine;
            
            txtOutput.Text = txtOutput.Text + "Non Resident attribute  Header Bytes  16-63" + Environment.NewLine;
             txtOutput.Text = txtOutput.Text +"---------------------------------------------------------------------"+Environment.NewLine;

            txtOutput.Text = txtOutput.Text +"Bytes 16–23 Starting Virtual Cluster Number (VCN) of the runlist "+Environment.NewLine;
  txtOutput.Text = txtOutput.Text +"Bytes 24–31 Ending VCN of the runlist "+Environment.NewLine;
  txtOutput.Text = txtOutput.Text +"Bytes 32–33 Offset to the runlist  "+Environment.NewLine;
  txtOutput.Text = txtOutput.Text +"Bytes 34–35 Compression unit size  "+Environment.NewLine;
  txtOutput.Text = txtOutput.Text +"Bytes 36–39 Unused  "+Environment.NewLine;
  txtOutput.Text = txtOutput.Text +"Bytes 40–47 Allocated size of attribute content  "+Environment.NewLine;
  txtOutput.Text = txtOutput.Text +"Bytes 48–55 Actual size of attribute content "+Environment.NewLine;
  txtOutput.Text = txtOutput.Text + "Bytes56–63 Initialized size of attribute content" + Environment.NewLine;

            txtOutput.Text = txtOutput.Text + "The RunList contains " + Selected_Attribute.RunLists.Count + " cluster chain" + Environment.NewLine;
           
            Display_RunList();
            dataGridView1.Visible = false;
            label1.Text = "Run List ";
            btnLoadNonResident.Visible = true;


        }

        void Display_RunList()
        {
            RunlistGridView.Visible = true;
            for (int i = 0; i < Selected_Attribute.RunLists.Count; i++)
            {
                RunlistGridView.RowCount++;

                RunlistGridView.Rows[i].Cells[0].Value = i;
                RunlistGridView.Rows[i].Cells[1].Value = Selected_Attribute.RunLists.ElementAt(i).startCluster.ToString("X2")+"x";
                RunlistGridView.Rows[i].Cells[2].Value = Selected_Attribute.RunLists.ElementAt(i).Len;

            }
        
        }
        void Display_STANDARD_INFORMATION(STANDARD_INFORMATION x)
        {
             CalculationUtilities calc = new CalculationUtilities();
            dataGridView1.RowCount++;


            dataGridView1.Rows[0].Cells[0].Value = "0-7";

            dataGridView1.Rows[0].Cells[1].Value = "Creation time";

            dataGridView1.Rows[0].Cells[2].Value = calc.GetStringBytes(x.creationtime, 8);
            dataGridView1.Rows[0].Cells[3].Value = x.creationtimeValue;

            dataGridView1.RowCount++;

            dataGridView1.Rows[1].Cells[0].Value = "8-15";

            dataGridView1.Rows[1].Cells[1].Value = "file alter time";

            dataGridView1.Rows[1].Cells[2].Value = calc.GetStringBytes(x.filealtertime, 8);
            dataGridView1.Rows[1].Cells[3].Value = x.filealtertimeValue;

            dataGridView1.RowCount++;

            dataGridView1.Rows[2].Cells[0].Value = "16-23";

            dataGridView1.Rows[2].Cells[1].Value = "MFT Altered time";

            dataGridView1.Rows[2].Cells[2].Value = calc.GetStringBytes(x.MFTaltertime, 8);
            dataGridView1.Rows[2].Cells[3].Value = x.MFTaltertimeValue;
            dataGridView1.RowCount++;

            dataGridView1.Rows[3].Cells[0].Value = "24-31";

            dataGridView1.Rows[3].Cells[1].Value = "file accessed time";

            dataGridView1.Rows[3].Cells[2].Value = calc.GetStringBytes(x.fileaccesstime, 8);
            dataGridView1.Rows[3].Cells[3].Value = x.fileaccesstimeValue;
            dataGridView1.RowCount++;

            dataGridView1.Rows[4].Cells[0].Value = "32-35";

            dataGridView1.Rows[4].Cells[1].Value = "flags";

            dataGridView1.Rows[4].Cells[2].Value = calc.GetStringBytes(x.flags, 4);

            dataGridView1.RowCount++;

            dataGridView1.Rows[5].Cells[0].Value = "36-39";

            dataGridView1.Rows[5].Cells[1].Value = "maximum number of versions";

            dataGridView1.Rows[5].Cells[2].Value = calc.GetStringBytes(x.maxnoversions, 4);

            dataGridView1.RowCount++;

            dataGridView1.Rows[6].Cells[0].Value = "40-43";

            dataGridView1.Rows[6].Cells[1].Value = "version no";

            dataGridView1.Rows[6].Cells[2].Value = calc.GetStringBytes(x.versionno, 4);

            dataGridView1.RowCount++;

            dataGridView1.Rows[6].Cells[0].Value = "44-47";

            dataGridView1.Rows[6].Cells[1].Value = "class id";

            dataGridView1.Rows[6].Cells[2].Value = calc.GetStringBytes(x.classid, 4);


        }


         void Display_ATTRIBUTE_LIST(AttributeList x)
         {
             dataGridView1.RowCount++;
             dataGridView1.Rows[0].Cells[0].Value = "0-3";
             dataGridView1.Rows[0].Cells[1].Value = "Attribute Type";
             dataGridView1.Rows[0].Cells[2].Value = x.attributeTypeStr;
             dataGridView1.RowCount++;
             dataGridView1.Rows[1].Cells[0].Value = "4-5";
             dataGridView1.Rows[1].Cells[1].Value = "Length of this entry";
             dataGridView1.Rows[1].Cells[2].Value = x.lengthOfEntryStr;

             dataGridView1.RowCount++;
             dataGridView1.Rows[2].Cells[0].Value = "6-6";
             dataGridView1.Rows[2].Cells[1].Value = "length Of Name";
             dataGridView1.Rows[2].Cells[2].Value = x.lengthOfNameStr;

             dataGridView1.RowCount++;
             dataGridView1.Rows[3].Cells[0].Value = "7-7";
             dataGridView1.Rows[3].Cells[1].Value = "Offset To Name (relative to start of this entry";
             dataGridView1.Rows[3].Cells[2].Value = x.offsetToNameStr;
             dataGridView1.RowCount++;
             dataGridView1.Rows[4].Cells[0].Value = "8-15";
             dataGridView1.Rows[4].Cells[1].Value = "Starting VCN in attribute";
             dataGridView1.Rows[4].Cells[2].Value = x.startingVCNStr;
             dataGridView1.RowCount++;
             dataGridView1.Rows[5].Cells[0].Value = "16-23";
             dataGridView1.Rows[5].Cells[1].Value = "File Reference where attribute is located";
             dataGridView1.Rows[5].Cells[2].Value = x.fileReferenceStr;

             dataGridView1.RowCount++;
             dataGridView1.Rows[6].Cells[0].Value = "24-24";
             dataGridView1.Rows[6].Cells[1].Value = "Attribute Id";
             dataGridView1.Rows[6].Cells[2].Value = x.attributeIdStr;
                   
        }

         void Display_FileName(FileName x)
         {
             dataGridView1.RowCount++;
             dataGridView1.Rows[0].Cells[0].Value = "0-7";
             dataGridView1.Rows[0].Cells[1].Value = "File Reference of parent directory";
             dataGridView1.Rows[0].Cells[2].Value = x.fileReferenceStr;
             dataGridView1.RowCount++;
             dataGridView1.Rows[1].Cells[0].Value = "8-15";
             dataGridView1.Rows[1].Cells[1].Value = "file Creation Time";
             dataGridView1.Rows[1].Cells[2].Value = x.fileCreationTimeStr;
             dataGridView1.Rows[1].Cells[3].Value = x.dtfileCreationTime;

             dataGridView1.RowCount++;
             dataGridView1.Rows[2].Cells[0].Value = "16-23";
             dataGridView1.Rows[2].Cells[1].Value = "File Modification TimeS";
             dataGridView1.Rows[2].Cells[2].Value = x.fileModificationTimeStr;
             dataGridView1.Rows[2].Cells[3].Value = x.dtfileModificationTime;

             dataGridView1.RowCount++;
             dataGridView1.Rows[3].Cells[0].Value = "24-31";
             dataGridView1.Rows[3].Cells[1].Value = "MFT Modification Time";
             dataGridView1.Rows[3].Cells[2].Value = x.MFTmodificationTimeStr;
             dataGridView1.Rows[3].Cells[3].Value = x.dtMFTmodificationTime;
             dataGridView1.RowCount++;
             dataGridView1.Rows[4].Cells[0].Value = "32-39";
             dataGridView1.Rows[4].Cells[1].Value = "File Access Time";
             dataGridView1.Rows[4].Cells[2].Value = x.fileAccessTimeStr;


             dataGridView1.RowCount++;
             dataGridView1.Rows[5].Cells[0].Value = "40-47";
             dataGridView1.Rows[5].Cells[1].Value = "Allocated Size of File";
             dataGridView1.Rows[5].Cells[2].Value = x.allocatedSizeofFileStr;

             dataGridView1.RowCount++;
             dataGridView1.Rows[6].Cells[0].Value = "48-55";
             dataGridView1.Rows[6].Cells[1].Value = "Real Size of File";
             dataGridView1.Rows[6].Cells[2].Value = x.realSizeOfFileStr;


             dataGridView1.RowCount++;
             dataGridView1.Rows[7].Cells[0].Value = "56-59";
             dataGridView1.Rows[7].Cells[1].Value = "Flags";
             dataGridView1.Rows[7].Cells[2].Value = x.flagsStr;

             dataGridView1.RowCount++;
             dataGridView1.Rows[8].Cells[0].Value = "60-63";
             dataGridView1.Rows[8].Cells[1].Value = "Reparse Value";
             dataGridView1.Rows[8].Cells[2].Value = x.reparseValueStr;


             dataGridView1.RowCount++;
             dataGridView1.Rows[9].Cells[0].Value = "64-64";
             dataGridView1.Rows[9].Cells[1].Value = "Length of Name";
             dataGridView1.Rows[9].Cells[2].Value = x.lengthOfNameStr;

             dataGridView1.RowCount++;

             dataGridView1.Rows[10].Cells[0].Value = "65-65";

             dataGridView1.Rows[10].Cells[1].Value = "Namespace";

             dataGridView1.Rows[10].Cells[2].Value = x.nameSpaceStr;

             dataGridView1.Rows[10].Cells[3].Value = x.dtnameSpace;


             dataGridView1.RowCount++;
             dataGridView1.Rows[11].Cells[0].Value = "66+";
             dataGridView1.Rows[11].Cells[1].Value = "Name";
             dataGridView1.Rows[11].Cells[2].Value = x.nameStr;
             dataGridView1.Rows[11].Cells[3].Value = x.UnicodeNameStr;
                
         
         }


        void Display_Object_ID(Object_ID x)  
        {
                    dataGridView1.RowCount++;
                    dataGridView1.Rows[0].Cells[0].Value = "0-15";
                    dataGridView1.Rows[0].Cells[1].Value = "Object ID";
                    dataGridView1.Rows[0].Cells[2].Value = x.objectIDStr;
                    dataGridView1.RowCount++;
                    dataGridView1.Rows[1].Cells[0].Value = "16-31";
                    dataGridView1.Rows[1].Cells[1].Value = "Birth Volume ID";
                    dataGridView1.Rows[1].Cells[2].Value = x.birthVolumeIDStr;

                    dataGridView1.RowCount++;
                    dataGridView1.Rows[2].Cells[0].Value = "32-47";
                    dataGridView1.Rows[2].Cells[1].Value = "Birth Object ID";
                    dataGridView1.Rows[2].Cells[2].Value = x.birthObjectIDStr;

                    dataGridView1.RowCount++;
                    dataGridView1.Rows[3].Cells[0].Value = "48-63";
                    dataGridView1.Rows[3].Cells[1].Value = "Birth Domain ID";
                    dataGridView1.Rows[3].Cells[2].Value = x.birthDomainIDStr;
        }


        void Display_INDEX_ROOT(INDEX_ROOT x)
        {
            CalculationUtilities calc = new CalculationUtilities();
            dataGridView1.RowCount++;
            dataGridView1.Rows[0].Cells[0].Value = "0-15";
            dataGridView1.Rows[0].Cells[1].Value = "Index Root Header ";
            dataGridView1.Rows[0].Cells[0].Style.BackColor = Color.Red;
            dataGridView1.Rows[0].Cells[1].Style.BackColor = Color.Red; 
            dataGridView1.Rows[0].Cells[2].Style.BackColor = Color.Red;
            dataGridView1.Rows[0].Cells[3].Style.BackColor = Color.Red;
                      
            dataGridView1.RowCount++;
                    dataGridView1.Rows[1].Cells[0].Value = "0-3";
                    dataGridView1.Rows[1].Cells[1].Value = "Type of attribute in index ";
                    dataGridView1.Rows[1].Cells[2].Value = BitConverter.ToString(x.type, 0);

                    dataGridView1.RowCount++;
                    dataGridView1.Rows[2].Cells[0].Value = "4-7";
                    dataGridView1.Rows[2].Cells[1].Value = "Collation sorting rule ";
                    dataGridView1.Rows[2].Cells[2].Value = BitConverter.ToString(x.sortingrule, 0);

                    dataGridView1.RowCount++;
                    dataGridView1.Rows[3].Cells[0].Value = "8-11";
                    dataGridView1.Rows[3].Cells[1].Value = "Size of each index record";
                    dataGridView1.Rows[3].Cells[2].Value = BitConverter.ToString(x.indexsizeinbytes, 0);
                    dataGridView1.Rows[3].Cells[3].Value =calc.LittleIndianBytesToInt(x.indexsizeinbytes, 4);

                    dataGridView1.RowCount++;
                    dataGridView1.Rows[4].Cells[0].Value = "12";
                    dataGridView1.Rows[4].Cells[1].Value = "Size of each index record in clusters";
                    dataGridView1.Rows[4].Cells[2].Value = BitConverter.ToString(x.indexsizeclust, 0);
                    dataGridView1.Rows[4].Cells[3].Value = calc.LittleIndianBytesToInt(x.indexsizeclust, 1);

                    dataGridView1.RowCount++;
                    dataGridView1.Rows[5].Cells[0].Value = "13-15";
                    dataGridView1.Rows[5].Cells[1].Value = "Unused";

                    dataGridView1.RowCount++;
                    dataGridView1.Rows[6].Cells[0].Value = "16-31";
                    dataGridView1.Rows[6].Cells[1].Value = "Index Node Header ";
                    dataGridView1.Rows[6].Cells[0].Style.BackColor = Color.Red;
                    dataGridView1.Rows[6].Cells[1].Style.BackColor = Color.Red;
                    dataGridView1.Rows[6].Cells[2].Style.BackColor = Color.Red;
                    dataGridView1.Rows[6].Cells[3].Style.BackColor = Color.Red;

            ///Node Header////
            ///

                    dataGridView1.RowCount++;
                    dataGridView1.Rows[7].Cells[0].Value = "0-3";
                    dataGridView1.Rows[7].Cells[1].Value = "Offset to start of index entry list";
                    dataGridView1.Rows[7].Cells[2].Value = BitConverter.ToString(x.offsettoentrylist, 0);
                    dataGridView1.Rows[7].Cells[3].Value = calc.LittleIndianBytesToInt(x.offsettoentrylist, 4);

                    dataGridView1.RowCount++;
                    dataGridView1.Rows[8].Cells[0].Value = "4-7";
                    dataGridView1.Rows[8].Cells[1].Value = "Offset to end of used portion of index entry list";
                    dataGridView1.Rows[8].Cells[2].Value = BitConverter.ToString(x.offsettoendused, 0);
                    dataGridView1.Rows[8].Cells[3].Value = calc.LittleIndianBytesToInt(x.offsettoendused, 4);



                    dataGridView1.RowCount++;
                    dataGridView1.Rows[8].Cells[0].Value = "8-11";
                    dataGridView1.Rows[8].Cells[1].Value = " Offset to end of allocated index entry list buffer";
                    dataGridView1.Rows[8].Cells[2].Value = BitConverter.ToString(x.offsettoendalloc, 0);
                    dataGridView1.Rows[8].Cells[3].Value = calc.LittleIndianBytesToInt(x.offsettoendalloc, 4);


                    dataGridView1.RowCount++;
                    dataGridView1.Rows[9].Cells[0].Value = "12-15";
                    dataGridView1.Rows[9].Cells[1].Value = " Flags";
                    dataGridView1.Rows[9].Cells[2].Value = BitConverter.ToString(x.flags, 0);
                 //   dataGridView1.Rows[9].Cells[3].Value = calc.LittleIndianBytesToInt(x.offsettoendalloc, 4);
                    int RowCount = 10;
                    for (int i = 0; i < x.IndexEntryList.Count; i++)
                    {
                        dataGridView1.RowCount++;
                        dataGridView1.Rows[RowCount].Cells[0].Value = "";
                        dataGridView1.Rows[RowCount].Cells[1].Value = "Index Entry  " + i;
                        dataGridView1.Rows[RowCount].Cells[0].Style.BackColor = Color.Red;
                        dataGridView1.Rows[RowCount].Cells[1].Style.BackColor = Color.Red;
                        dataGridView1.Rows[RowCount].Cells[2].Style.BackColor = Color.Red;
                        dataGridView1.Rows[RowCount].Cells[3].Style.BackColor = Color.Red;
                        RowCount++;

                        dataGridView1.RowCount++;
                        dataGridView1.Rows[RowCount].Cells[0].Value = "0-7";
                        dataGridView1.Rows[RowCount].Cells[1].Value = "MFT file reference for file name";
                        dataGridView1.Rows[RowCount].Cells[2].Value = BitConverter.ToString(x.IndexEntryList.ElementAt(i).MFTfileref, 0);
                        // dataGridView1.Rows[RowCount].Cells[3].Value =
                        RowCount++;

                        dataGridView1.RowCount++;
                        dataGridView1.Rows[RowCount].Cells[0].Value = "8-9";
                        dataGridView1.Rows[RowCount].Cells[1].Value = "Length of this entry";
                        dataGridView1.Rows[RowCount].Cells[2].Value = BitConverter.ToString(x.IndexEntryList.ElementAt(i).lengthofthisentry, 0);
                        dataGridView1.Rows[RowCount].Cells[3].Value = x.IndexEntryList.ElementAt(i).Lengthofentry;
                        RowCount++;

                        dataGridView1.RowCount++;
                        dataGridView1.Rows[RowCount].Cells[0].Value = "10-11";
                        dataGridView1.Rows[RowCount].Cells[1].Value = "Length of $FILE_NAME attribute";
                        dataGridView1.Rows[RowCount].Cells[2].Value = BitConverter.ToString(x.IndexEntryList.ElementAt(i).filenamelength, 0);
                        dataGridView1.Rows[RowCount].Cells[3].Value = calc.LittleIndianBytesToInt(x.IndexEntryList.ElementAt(i).filenamelength, 2);
                        RowCount++;

                        dataGridView1.RowCount++;
                        dataGridView1.Rows[RowCount].Cells[0].Value = "12-15";
                        dataGridView1.Rows[RowCount].Cells[1].Value = "Flags";
                        dataGridView1.Rows[RowCount].Cells[2].Value = BitConverter.ToString(x.IndexEntryList.ElementAt(i).flags, 0);
                        //    dataGridView1.Rows[RowCount - 1].Cells[3].Value =
                        RowCount++;

                        dataGridView1.RowCount++;
                        dataGridView1.Rows[RowCount].Cells[0].Value = "16+";
                        dataGridView1.Rows[RowCount].Cells[1].Value = "$FILE_NAME Attribute";
                        dataGridView1.Rows[RowCount].Cells[2].Value = BitConverter.ToString(x.IndexEntryList.ElementAt(i).FileNameAttr, 0);
                        dataGridView1.Rows[RowCount].Cells[3].Value = x.IndexEntryList.ElementAt(i).getFileNameAttrUnicodeName;
                        RowCount++;


                    
                    }


        }

        void Display_REPARSE_POINT(REPARSE_POINT x)
        {
            dataGridView1.RowCount++;
            dataGridView1.Rows[0].Cells[0].Value = "0-3";
            dataGridView1.Rows[0].Cells[1].Value = "Reparse type flags";
            dataGridView1.Rows[0].Cells[2].Value = x.typeflags;
            dataGridView1.RowCount++;
            dataGridView1.Rows[1].Cells[0].Value = "4-5";
            dataGridView1.Rows[1].Cells[1].Value = "Size of Reparse data";
            dataGridView1.Rows[1].Cells[2].Value = x.sizeofdata;
            dataGridView1.RowCount++;
            dataGridView1.Rows[2].Cells[0].Value = "6-7";
            dataGridView1.Rows[2].Cells[1].Value = "Unused No";
            dataGridView1.Rows[2].Cells[2].Value = x.unused;
            dataGridView1.RowCount++;
            dataGridView1.Rows[3].Cells[0].Value = "8-9";
            dataGridView1.Rows[3].Cells[1].Value = "Offset to target name";
            dataGridView1.Rows[3].Cells[2].Value = x.offsettotargetname;
            dataGridView1.RowCount++;
            dataGridView1.Rows[3].Cells[0].Value = "10-11";
            dataGridView1.Rows[3].Cells[1].Value = "Length of target name";
            dataGridView1.Rows[3].Cells[2].Value = x.lengthofname;
            dataGridView1.RowCount++;
            dataGridView1.Rows[3].Cells[0].Value = "12-13";
            dataGridView1.Rows[3].Cells[1].Value = "Offset to print name of target";
            dataGridView1.Rows[3].Cells[2].Value = x.offsettoprintname;
            dataGridView1.RowCount++;
            dataGridView1.Rows[3].Cells[0].Value = "14-15";
            dataGridView1.Rows[3].Cells[1].Value = "Length of print name";
            dataGridView1.Rows[3].Cells[2].Value = x.lengthofprint;
        }

        void Display_VOLUME_INFORMATION(VOLUME_INFORMATION x)
        {
            dataGridView1.RowCount++;
            dataGridView1.Rows[0].Cells[0].Value = "0-7";
            dataGridView1.Rows[0].Cells[1].Value = "unused";
            dataGridView1.Rows[0].Cells[2].Value = x.unused;
            dataGridView1.RowCount++;
            dataGridView1.Rows[1].Cells[0].Value = "8-8";
            dataGridView1.Rows[1].Cells[1].Value = "Major version";
            dataGridView1.Rows[1].Cells[2].Value = x.majorversion;
            dataGridView1.RowCount++;
            dataGridView1.Rows[2].Cells[0].Value = "9-9";
            dataGridView1.Rows[2].Cells[1].Value = "Minor version";
            dataGridView1.Rows[2].Cells[2].Value = x.minorversion;
            dataGridView1.RowCount++;
            dataGridView1.Rows[3].Cells[0].Value = "10-11";
            dataGridView1.Rows[3].Cells[1].Value = "Flags";
            dataGridView1.Rows[3].Cells[2].Value = x.flags;
        }

        void Display_INDEX_ALLOCATION(INDEX_ALLOCATION x)
        {
            


            CalculationUtilities calc = new CalculationUtilities();
            dataGridView1.RowCount++;
            dataGridView1.Rows[0].Cells[0].Value = "0-24";
            dataGridView1.Rows[0].Cells[1].Value = "Index Record Header ";
            dataGridView1.Rows[0].Cells[0].Style.BackColor = Color.Red;
            dataGridView1.Rows[0].Cells[1].Style.BackColor = Color.Red;
            dataGridView1.Rows[0].Cells[2].Style.BackColor = Color.Red;
            dataGridView1.Rows[0].Cells[3].Style.BackColor = Color.Red;

            dataGridView1.RowCount++;
            dataGridView1.Rows[1].Cells[0].Value = "0-3";
            dataGridView1.Rows[1].Cells[1].Value = "Signature value 'INDX'";
            dataGridView1.Rows[1].Cells[2].Value = BitConverter.ToString(x.signature, 0);

            dataGridView1.RowCount++;
            dataGridView1.Rows[2].Cells[0].Value = "4-5";
            dataGridView1.Rows[2].Cells[1].Value = "Offset to fixup array";
            dataGridView1.Rows[2].Cells[2].Value = BitConverter.ToString(x.offsettofixup, 0);
            dataGridView1.Rows[2].Cells[3].Value = calc.LittleIndianBytesToInt(x.offsettofixup, 2);

            dataGridView1.RowCount++;
            dataGridView1.Rows[3].Cells[0].Value = "6-7";
            dataGridView1.Rows[3].Cells[1].Value = "Number of Entries in fixup array";
            dataGridView1.Rows[3].Cells[2].Value = BitConverter.ToString(x.numberofentries, 0);
            dataGridView1.Rows[3].Cells[3].Value = calc.LittleIndianBytesToInt(x.numberofentries, 2);

            dataGridView1.RowCount++;
            dataGridView1.Rows[4].Cells[0].Value = "8-15";
            dataGridView1.Rows[4].Cells[1].Value = "$Logfile Sequence Number (LSN)";
            dataGridView1.Rows[4].Cells[2].Value = BitConverter.ToString(x.LSN, 0);
            

            dataGridView1.RowCount++;
            dataGridView1.Rows[5].Cells[0].Value = "16-23";
            dataGridView1.Rows[5].Cells[1].Value = "The VCN of this record in the full index stream";
            dataGridView1.Rows[4].Cells[2].Value = BitConverter.ToString(x.VCN, 0);

            dataGridView1.RowCount++;
            dataGridView1.Rows[6].Cells[0].Value = "24-40";
            dataGridView1.Rows[6].Cells[1].Value = "Index Node Header ";
            dataGridView1.Rows[6].Cells[0].Style.BackColor = Color.Red;
            dataGridView1.Rows[6].Cells[1].Style.BackColor = Color.Red;
            dataGridView1.Rows[6].Cells[2].Style.BackColor = Color.Red;
            dataGridView1.Rows[6].Cells[3].Style.BackColor = Color.Red;

            // Node Header/////

             dataGridView1.RowCount++;
            dataGridView1.Rows[7].Cells[0].Value = "0-3";
            dataGridView1.Rows[7].Cells[1].Value = "Offset to start of index entry list";
            dataGridView1.Rows[7].Cells[2].Value = BitConverter.ToString(x.offsettoentrylist, 0);
            dataGridView1.Rows[7].Cells[3].Value = calc.LittleIndianBytesToInt(x.offsettoentrylist, 4);

            dataGridView1.RowCount++;
            dataGridView1.Rows[8].Cells[0].Value = "4-7";
            dataGridView1.Rows[8].Cells[1].Value = "Offset to end of used portion of index entry list";
            dataGridView1.Rows[8].Cells[2].Value = BitConverter.ToString(x.offsettoendused, 0);
            dataGridView1.Rows[8].Cells[3].Value = calc.LittleIndianBytesToInt(x.offsettoendused, 4);



            dataGridView1.RowCount++;
            dataGridView1.Rows[8].Cells[0].Value = "8-11";
            dataGridView1.Rows[8].Cells[1].Value = " Offset to end of allocated index entry list buffer";
            dataGridView1.Rows[8].Cells[2].Value = BitConverter.ToString(x.offsettoendalloc, 0);
            dataGridView1.Rows[8].Cells[3].Value = calc.LittleIndianBytesToInt(x.offsettoendalloc, 4);


            dataGridView1.RowCount++;
            dataGridView1.Rows[9].Cells[0].Value = "12-15";
            dataGridView1.Rows[9].Cells[1].Value = " Flags";
            dataGridView1.Rows[9].Cells[2].Value = BitConverter.ToString(x.flags, 0);
            dataGridView1.Rows[9].Cells[3].Value = calc.LittleIndianBytesToInt(x.offsettoendalloc, 4);

            int RowCount = 10;
            for (int i = 0; i < x.IndexEntryList.Count; i++)
            {
                dataGridView1.RowCount++;
                dataGridView1.Rows[RowCount].Cells[0].Value = "";
                dataGridView1.Rows[RowCount].Cells[1].Value = "Index Entry  " + i;
                dataGridView1.Rows[RowCount].Cells[0].Style.BackColor = Color.Red;
                dataGridView1.Rows[RowCount].Cells[1].Style.BackColor = Color.Red;
                dataGridView1.Rows[RowCount].Cells[2].Style.BackColor = Color.Red;
                dataGridView1.Rows[RowCount].Cells[3].Style.BackColor = Color.Red;
                RowCount++;

                dataGridView1.RowCount++;
                dataGridView1.Rows[RowCount].Cells[0].Value = "0-7";
                dataGridView1.Rows[RowCount].Cells[1].Value = "MFT file reference for file name";
                dataGridView1.Rows[RowCount].Cells[2].Value = BitConverter.ToString(x.IndexEntryList.ElementAt(i).MFTfileref, 0);
               // dataGridView1.Rows[RowCount].Cells[3].Value =
                RowCount++;

               dataGridView1.RowCount++;
                dataGridView1.Rows[RowCount].Cells[0].Value = "8-9";
                dataGridView1.Rows[RowCount].Cells[1].Value = "Length of this entry";
                dataGridView1.Rows[RowCount].Cells[2].Value = BitConverter.ToString(x.IndexEntryList.ElementAt(i).lengthofthisentry, 0);
             dataGridView1.Rows[RowCount].Cells[3].Value = x.IndexEntryList.ElementAt(i).Lengthofentry;
                RowCount++;

                dataGridView1.RowCount++;
               dataGridView1.Rows[RowCount].Cells[0].Value = "10-11";
                dataGridView1.Rows[RowCount].Cells[1].Value = "Length of $FILE_NAME attribute";
                dataGridView1.Rows[RowCount].Cells[2].Value = BitConverter.ToString(x.IndexEntryList.ElementAt(i).filenamelength, 0);
                dataGridView1.Rows[RowCount].Cells[3].Value = calc.LittleIndianBytesToInt(x.IndexEntryList.ElementAt(i).filenamelength, 2);
              RowCount++;

               dataGridView1.RowCount++;
                dataGridView1.Rows[RowCount].Cells[0].Value = "12-15";
                dataGridView1.Rows[RowCount].Cells[1].Value = "Flags";
                dataGridView1.Rows[RowCount].Cells[2].Value = BitConverter.ToString(x.IndexEntryList.ElementAt(i).flags, 0);
            //    dataGridView1.Rows[RowCount - 1].Cells[3].Value =
               RowCount++;

                dataGridView1.RowCount++;
                dataGridView1.Rows[RowCount].Cells[0].Value = "16+";
                dataGridView1.Rows[RowCount].Cells[1].Value = "$FILE_NAME Attribute";
                dataGridView1.Rows[RowCount].Cells[2].Value = BitConverter.ToString(x.IndexEntryList.ElementAt(i).FileNameAttr, 0);
                dataGridView1.Rows[RowCount].Cells[3].Value = x.IndexEntryList.ElementAt(i).getFileNameAttrUnicodeName;
               RowCount++;


            }


        }

        void Dispaly_NonResidentAttributeContent()
        {
            RunlistGridView.Visible = false;
            label1.Text = "Attribute Non Resident Content";
            dataGridView1.Visible = true;
            btnLoadNonResident.Visible = false;

         
            if (Selected_Attribute.attrtypeIdentifier == Convert.ToInt32("A0", 16)) //$INDEX_Allocation
            {
                INDEX_ALLOCATION x = new INDEX_ALLOCATION(Selected_Attribute.RunLists.ElementAt(0).dataSize, Selected_Attribute.RunLists.ElementAt(0).GetData());
                Display_INDEX_ALLOCATION(x);
            }

            ////other non residents attribute to be here
            }
        private void btnLoadNonResident_Click(object sender, EventArgs e)
        {  int offsetaddrescluster = Selected_Attribute.RunLists.ElementAt(0).startCluster * MainForm_NTFSLearning.BootSector.BytesPerSector * MainForm_NTFSLearning.BootSector.SectorsPerCluster;
            int Bytelength= Selected_Attribute.RunLists.ElementAt(0).dataSize;
           
            if (Selected_Attribute.RunLists.ElementAt(0).Len < 10)
            {
                DisplayBytesDataView(Selected_Attribute.RunLists.ElementAt(0).GetData(), Bytelength, offsetaddrescluster);
                SelectValue_onDataView(Selected_Attribute.RunLists.ElementAt(0).GetData(),Bytelength, 0,Bytelength-1,Color.Khaki);
                ClearHighlightedDataView();

                Dispaly_NonResidentAttributeContent();
            }
            else
                MessageBox.Show("Data is too big to be displayed its " + Bytelength + " bytes starting at Cluster "+Selected_Attribute.RunLists.ElementAt(0).startCluster.ToString("X2")+ "  at offset address  " + offsetaddrescluster.ToString("X2"));
            

        }
    }
}
