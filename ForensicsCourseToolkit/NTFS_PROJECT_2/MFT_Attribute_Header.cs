using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTFSLearning
{
    //table 13.2
    public class MFT_Attribute_Header
    {


        public byte[] AttributeHeaderdata;
        int HeaderLength; //equall 22 for resident attributes and 64 for non residet attribute
        public int attrtypeIdentifier;
        public string atrrTypeStr;
        public int AttributeLenght;
        public int non_ResidentFlag;
        public int length_Name;
        public int offset_to_name;
        public string Flag; 
        //    0x0001 –Attribute is compressed
        //–0x4000 –Attribute is encrypted
        //–0x8000 –Attribute is sparse

        public int attributeId;

       
       public MFT_Attribute_Header(byte[] AttributeHeaderDataarray,int len)
        {
            AttributeHeaderdata = AttributeHeaderDataarray;
            HeaderLength = len;
            CalculationUtilities calc = new CalculationUtilities();
            byte[] fieldRang;
            fieldRang = new byte[4];
            int attrIndex = 0;
            for (int i = 0; i < 4; i++)
            {
                fieldRang[i] = AttributeHeaderdata[attrIndex];
                attrIndex++;
            }
            attrtypeIdentifier = calc.LittleIndianBytesToInt(fieldRang, 4);
            string attrType_string = calc.attributeType(attrtypeIdentifier);


            fieldRang = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                fieldRang[i] = AttributeHeaderdata[attrIndex];
                attrIndex++;
            }
            AttributeLenght = calc.LittleIndianBytesToInt(fieldRang, 4);

            non_ResidentFlag = AttributeHeaderdata[8];
            length_Name = AttributeHeaderdata[9];
           
           fieldRang=new byte[2];
           attrIndex = 10;
           for (int i = 0; i <1; i++)
           {
               fieldRang[i] = AttributeHeaderdata[attrIndex];
               attrIndex++;
           }



          
           attrIndex = 12;
           Flag="";
           for (int i = 0; i < 1; i++)
           {
               int val = AttributeHeaderdata[attrIndex];
               Flag += Convert.ToInt32(val.ToString(), 2);
               attrIndex++;
           }


           fieldRang = new byte[2];
           attrIndex = 14;
           for (int i = 0; i < 1; i++)
           {
               fieldRang[i] = AttributeHeaderdata[attrIndex];
               attrIndex++;
           }
           attributeId = calc.LittleIndianBytesToInt(fieldRang, 2);
          
        }
    
}
}
