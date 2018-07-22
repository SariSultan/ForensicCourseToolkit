using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTFSLearning
{
    public class MFT_Attribute_Header_non_resident : MFT_Attribute_Header
    {
        //table 13.4


        public int StartingVCNRunList;
        public int EndingVCN;
        public int offsetToRunlist;
        public int compressionUnit;
        public int AllocatedSize_Attr_content;
        public int Actual_size_Attr_content;
        public int init_size_Attr_content;

       
        public MFT_Attribute_Header_non_resident(byte[] AttributeHeaderDataarray, int len) : base(AttributeHeaderDataarray, len)
        {
            CalculationUtilities calc = new CalculationUtilities();
            byte[] byterang = new byte[8];
            int countbytes = 0;
            //////////////////////StartingVCNRunList//////////////////////
            for (int i = 16; i <= 23; i++)
            {
                byterang[countbytes] = this.AttributeHeaderdata[i];
                countbytes++;
            }
            StartingVCNRunList = calc.LittleIndianBytesToInt(byterang, 8);

            countbytes = 0;
            byterang = new byte[8];
            //////////////////////EndingVCN//////////////////////
            for (int i = 24; i <= 31; i++)
            {
                byterang[countbytes] = this.AttributeHeaderdata[i];
                countbytes++;
            }
            EndingVCN = calc.LittleIndianBytesToInt(byterang, 8);

            countbytes = 0;
            byterang = new byte[2];
            ////////////////////// offsetToRunlist//////////////////////
            for (int i = 32; i <= 33; i++)
            {
                byterang[countbytes] = this.AttributeHeaderdata[i];
                countbytes++;
            }
            offsetToRunlist= calc.LittleIndianBytesToInt(byterang, 2);

            countbytes = 0;
            byterang = new byte[2];
            ////////////////////// compressionUnit//////////////////////
            for (int i = 34; i <= 35; i++)
            {
                byterang[countbytes] = this.AttributeHeaderdata[i];
                countbytes++;
            }
            compressionUnit = calc.LittleIndianBytesToInt(byterang, 2);

            ////////////////////// AllocatedSize_Attr_content//////////////////////
            countbytes = 0;
            byterang = new byte[8];
            for (int i = 40; i <= 47; i++)
            {
                byterang[countbytes] = this.AttributeHeaderdata[i];
                countbytes++;
            }
            AllocatedSize_Attr_content = calc.LittleIndianBytesToInt(byterang, 8);

            ////////////////////Actual_size_Attr_content/////////////////////////////
            countbytes = 0;
            byterang = new byte[8];
            for (int i = 48; i <= 55; i++)
            {
                byterang[countbytes] = this.AttributeHeaderdata[i];
                countbytes++;
            }
            Actual_size_Attr_content = calc.LittleIndianBytesToInt(byterang, 8);


            ////////////////////////init_size_Attr_content///////////////////
            countbytes = 0;
            byterang = new byte[8];
            for (int i = 56; i <= 63; i++)
            {
                byterang[countbytes] = this.AttributeHeaderdata[i];
                countbytes++;
            }
            init_size_Attr_content = calc.LittleIndianBytesToInt(byterang, 8);

          




        }
    }
}
