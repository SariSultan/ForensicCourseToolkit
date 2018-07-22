using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTFSLearning
{
   public class MFT_Attribute
    {
        public int MFTStartingIndex;
        public int attrtypeIdentifier;
       public string atrrTypeStr;
       public int length;
       public byte[] attr_data;
       public int non_residentFlag;
      
       public MFT_Attribute_Header_Resident ResidentAttrHeader;
       public byte[] attr_Content;
       public int attr_content_size;

       public MFT_Attribute_Header_non_resident NonResidentAttrHeader;
       public List<RunList> RunLists = new List<RunList>();  //Clusters Chain


        public MFT_Attribute(int len, byte[] attrbut_data,int attrType,string typestr,int MFTIndex)
       {
           CalculationUtilities calc = new CalculationUtilities();
            length = len;
            attr_data = attrbut_data;
            attrtypeIdentifier = attrType;
            atrrTypeStr = typestr;
            MFTStartingIndex = MFTIndex;
             non_residentFlag = attr_data[8];
            byte[] AttributeHeaderdata;
            if (non_residentFlag == 0)
            {
                AttributeHeaderdata = new byte[22];
                for (int i = 0; i < 22; i++)
                {
                    AttributeHeaderdata[i] = attr_data[i]; 
                }
                ResidentAttrHeader = new MFT_Attribute_Header_Resident(AttributeHeaderdata, 22);
                attr_content_size = ResidentAttrHeader.ContentSize;
                attr_Content = new byte[attr_content_size];
                int count = 0;
                for (int i = ResidentAttrHeader.OffsetToContent; i < (ResidentAttrHeader.OffsetToContent+ResidentAttrHeader.ContentSize); i++)
                {
                   attr_Content[count]= attrbut_data[i];
                   count++;
                }
                
             
                
            }
            else if (non_residentFlag == 1)
            {
                AttributeHeaderdata = new byte[64];
                for (int i = 0; i < 64; i++)
                {
                    AttributeHeaderdata[i] = attr_data[i];
                }
                 NonResidentAttrHeader = new MFT_Attribute_Header_non_resident(AttributeHeaderdata, 64);
            
                
                 #region runlist


                 int RunlistIndex = NonResidentAttrHeader.offsetToRunlist;
                 do
                 {
                     int Runheadervalue = attrbut_data[RunlistIndex];
                     string RunHeader;
                     int no_bytes_inRunOffst;
                     int no_bytes_inRunLength;
                     if (Runheadervalue != 0)
                     {
                         RunHeader = attrbut_data[RunlistIndex].ToString("X2");
                         no_bytes_inRunOffst = Convert.ToInt32(RunHeader.Substring(0, 1), 16);
                         no_bytes_inRunLength = Convert.ToInt32(RunHeader.Substring(1, 1), 16);

                         int countbytes = 0;
                         byte[] byterang = new byte[no_bytes_inRunLength];
                         for (int i = (RunlistIndex + 1); i < (RunlistIndex + no_bytes_inRunLength+1); i++)
                         {
                             byterang[countbytes] = attrbut_data[i];
                             countbytes++;
                         }
                         int No_of_clusters = calc.LittleIndianBytesToInt(byterang, no_bytes_inRunLength);

                          countbytes = 0;
                          byterang = new byte[no_bytes_inRunOffst];
                          for (int i = (RunlistIndex + no_bytes_inRunLength + 1); i < (RunlistIndex + no_bytes_inRunLength + no_bytes_inRunOffst + 1); i++)
                         {
                             byterang[countbytes] = attrbut_data[i];
                             countbytes++;
                         }
                         int clusterNo = calc.LittleIndianBytesToInt(byterang, no_bytes_inRunOffst);

                         
                         RunList runlist = new RunList(clusterNo, No_of_clusters);
                         RunLists.Add(runlist);
                     }
                     else
                     {
                         break;
                     }

                     RunlistIndex = RunlistIndex + no_bytes_inRunOffst + no_bytes_inRunLength + 1;
                 } while (RunlistIndex <length);
                 #endregion

               
            }
        }




    }
}
