using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTFSLearning
{
  public  class MFT_Attribute_Header_Resident : MFT_Attribute_Header
    {
        public int ContentSize;
        public int OffsetToContent;
     
      //table 13.3
        public MFT_Attribute_Header_Resident(byte[] AttributeHeaderDataarray, int len)
           : base(AttributeHeaderDataarray, len)
        {
            CalculationUtilities calc = new CalculationUtilities();
            int countbytes = 0;
            byte[] byterang=new byte[4];

            //////////////////////ContentSize//////////////////////
            for (int i=16;i<=19;i++)
            {
               byterang[countbytes] = this.AttributeHeaderdata[i];
               countbytes++;
            }
            ContentSize = calc.LittleIndianBytesToInt(byterang, 4);

            /////////////////////OffsetToContent///////////////////////
            countbytes = 0; 
            for (int i = 20; i <= 21; i++)
            {
                byterang[countbytes] = this.AttributeHeaderdata[i];
                countbytes++;
            }
            OffsetToContent = calc.LittleIndianBytesToInt(byterang, 2);

            
        }
    }
}
