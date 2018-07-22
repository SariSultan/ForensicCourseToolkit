using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTFSLearning;

namespace NTFSLearning
{
    class AttributeList
    {
        public int length = 72;
        public byte[] Array = new byte [72];
        public string attributeTypeStr;
        public string lengthOfEntryStr;
        public string lengthOfNameStr;
public string startingVCNStr;
public string offsetToNameStr;
public string fileReferenceStr;
public string attributeIdStr;

public AttributeList(int length, byte[] array)
{

byte[] attributeType = new byte[4];
for (int i = 0; i < 4; i++)
    attributeType[i] = array[i];

byte[] lengthOfEntry = new byte[2];
for (int i = 0; i < 2; i++)
    lengthOfEntry[i] = array[4 + i];


byte[] lengthOfName = new byte[1];
lengthOfName[0] = array[6];

byte[] offsetToName = new byte[1];
offsetToName[0] = array[7];

byte[] startingVCN = new byte[8];
    for (int i = 0; i < 8; i++)
    startingVCN[i] = array[8 + i];

byte[] fileReference = new byte[8];
    for (int i = 0; i < 8; i++)
    fileReference[i] = array[16 + i];

byte[] attributeId = new byte[1];
attributeId[0] = array[24];



//string attributeType_ = calculateValue(attributeType, 4);
//int x1 = Convert.ToInt32(calculateValue(attributeType, 4));

attributeTypeStr = "TEST";

 string lengthOfEntry_ = calculateValue(lengthOfEntry, 2);
lengthOfEntryStr= lengthOfEntry_.ToString();
string lengthOfName_ = calculateValue(lengthOfName, 1);
lengthOfNameStr = lengthOfName_.ToString();
string offsetToName_ = calculateValue(offsetToName, 1);
offsetToNameStr = offsetToName_.ToString();

string  startingVCN_ = calculateValue(startingVCN, 8);
startingVCNStr = startingVCN_.ToString();

string fileReference_ = calculateValue(fileReference, 8);
fileReferenceStr = fileReference_.ToString();

string attributeId_ = calculateValue(attributeId, 1);
attributeIdStr = attributeId_.ToString();







        }

        public string calculateValue(byte[] littleIndianBytes, int no_of_bytes)
        {
            string valueString = "";

            for (int i = no_of_bytes - 1; i >= 0; i--)
            {
                valueString += littleIndianBytes[i].ToString("X2");

            }

            return valueString;

        }

        public string attributeTypeX(int type)
        {
            string attrType = "";

            if (type == Convert.ToInt32("10", 16))
                attrType = "$STANDARD_INFORMATION";

            if (type == Convert.ToInt32("20", 16))
                attrType = "$ATTRIBUTE_LIST";

            if (type == Convert.ToInt32("30", 16))
                attrType = "$FILE_NAME";
            if (type == Convert.ToInt32("40", 16))
                attrType = "$OBJECT_ID";

            if (type == Convert.ToInt32("50", 16))
                attrType = "$SECURITY_DESCRIPTOR";
            if (type == Convert.ToInt32("60", 16))
                attrType = "$VOLUME_NAME";
            if (type == Convert.ToInt32("0", 16))
                attrType = "VOLUME_INFORMATION";

            if (type == Convert.ToInt32("80", 16))
                attrType = "$DATA";
            if (type == Convert.ToInt32("90", 16))
                attrType = "$INDEX_ROOT";

            if (type == Convert.ToInt32("A0", 16))
                attrType = "$INDEX_Allocation";

            if (type == Convert.ToInt32("B0", 16))
                attrType = "$BITMAP";
            if (type == Convert.ToInt32("C0", 16))
                attrType = "$REPARSE_POINT";//"$SYMBOLIC_LINK";
            if (type == Convert.ToInt32("D0", 16))
                attrType = "$EA_INFORMATION";
            if (type == Convert.ToInt32("E0", 16))
                attrType = "$EA";
            if (type == Convert.ToInt32("F0", 16))
                attrType = "$PROPERTY_SET";

            if (type == Convert.ToInt32("100", 16))
                attrType = "$LOGGESD_UTILITY_STREAM";
            return attrType;
        }


    }
}
