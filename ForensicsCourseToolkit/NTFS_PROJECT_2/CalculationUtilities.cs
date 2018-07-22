using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTFSLearning
{
    class CalculationUtilities
    {
        public CalculationUtilities()
        { 
        }

        public string GetStringBytes(byte[] ArrayofBytes, int no_of_bytes)
        {
            string bytesStringValue = "";
            for (int i = 0; i < no_of_bytes; i++)
            {
                bytesStringValue = bytesStringValue + ArrayofBytes[i].ToString("X2") + "  ";
            }

            return bytesStringValue;
        }

        public int LittleIndianBytesToInt(byte[] littleIndianBytes ,int no_of_bytes)
        {
            string valueString="";
            
            for (int i = no_of_bytes - 1; i >= 0; i--)
            {
                valueString += littleIndianBytes[i].ToString("X2");

            }
             
            return Convert.ToInt32(valueString,16);
             
        }

        public Int64 LittleIndianBytesToInt64(byte[] littleIndianBytes, int no_of_bytes)
        {
            string valueString = "";

            for (int i = no_of_bytes - 1; i >= 0; i--)
            {
                valueString += littleIndianBytes[i].ToString("X2");

            }

            return Convert.ToInt64(valueString, 16);

        }



        public string attributeType(int type)
        {

            string attrType = "";

            if (type == Convert.ToInt32("10", 16))

                attrType = "$STANDARD_INFORMATION";

            else if (type == Convert.ToInt32("20", 16))

                attrType = "$ATTRIBUTE_LIST";

            else if (type == Convert.ToInt32("30", 16))

                attrType = "$FILE_NAME";

            else if (type == Convert.ToInt32("40", 16))

                attrType = "$OBJECT_ID";

            else if (type == Convert.ToInt32("50", 16))

                attrType = "$SECURITY_DESCRIPTOR";

            else if (type == Convert.ToInt32("60", 16))

                attrType = "$VOLUME_NAME";

            else if (type == Convert.ToInt32("70", 16))

                attrType = "VOLUME_INFORMATION";

            else if (type == Convert.ToInt32("80", 16))

                attrType = "$DATA";

            else if (type == Convert.ToInt32("90", 16))

                attrType = "$INDEX_ROOT";

            else if (type == Convert.ToInt32("A0", 16))

                attrType = "$INDEX_Allocation";

            else if (type == Convert.ToInt32("B0", 16))

                attrType = "$BITMAP";

            else if (type == Convert.ToInt32("C0", 16))

                attrType = "$REPARSE_POINT";//"$SYMBOLIC_LINK";

            else if (type == Convert.ToInt32("D0", 16))

                attrType = "$EA_INFORMATION";

            else if (type == Convert.ToInt32("E0", 16))

                attrType = "$EA";

            else if (type == Convert.ToInt32("F0", 16))

                attrType = "$PROPERTY_SET";

            else if (type == Convert.ToInt32("100", 16))

                attrType = "$LOGGESD_UTILITY_STREAM";

            else attrType = null;
            return attrType;

        }
    }
}
