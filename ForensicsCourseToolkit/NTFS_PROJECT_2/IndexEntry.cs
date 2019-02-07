using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace NTFSLearning
{
    class IndexEntry
    {
        public int Lengthofentry;
        public byte[] MFTfileref = new byte[8];
        public byte[] lengthofthisentry = new byte[2];
        public byte[] filenamelength = new byte[2];
        public byte[] flags = new byte[4];
        public byte[] FileNameAttr;
        public string getFileNameAttrUnicodeName;
        /*
        * 0–7 MFT file reference for file name Yes
        8–9 Length of this entry Yes
        10–11 Length of $FILE_NAME attribute No
        12–15 Flags (see Table 13.16) Yes
        16+ $FILE_NAME Attribute (if length is > 0) Yes
        Last 8 bytes of entry, starting
        on an 8-byte boundary
        VCN of child node in $INDEX_ALLOCATION
        (field exists only if flag is set)
        * */
        public IndexEntry(int entryLength, byte[] entryDataArray)
        {
            Lengthofentry = entryLength;
            int count;
            ////MFTfileref
            count = 0;
            for (int i = 0; count < 8; i++)
            {
                if (i < Lengthofentry)
                {
                    MFTfileref[count] = entryDataArray[i];
                    count++;
                }
                else
                    break;
            }
            ////lengthofthisentry
            count = 0;
            for (int i = 8; count < 2; i++)
            {
                if (i < Lengthofentry)
                {
                    lengthofthisentry[count] = entryDataArray[i];
                    count++;
                }
                else
                    break;
            }
            ////filenamelength
            count = 0;
            for (int i = 10; count < 2; i++)
            {
                if (i < Lengthofentry)
                {
                    filenamelength[count] = entryDataArray[i];
                    count++;
                }
                else
                    break;
            }
            ////flags
            count = 0;
            for (int i = 10; count < 2; i++)
            {
                if (i < Lengthofentry)
                {
                    flags[count] = entryDataArray[i];
                    count++;
                }
                else
                    break;
            }

            CalculationUtilities calc =new CalculationUtilities();
            //$fileName
            FileNameAttr = new byte[calc.LittleIndianBytesToInt(filenamelength, 2)];
            count = 0;
            for (int i = 16; count < calc.LittleIndianBytesToInt(filenamelength, 2); i++)
            {
                if (i < Lengthofentry)
                {
                    FileNameAttr[count] = entryDataArray[i];
                    count++;
                }
                else
                    break;
            }

            if (calc.LittleIndianBytesToInt(filenamelength, 2) > 0)
            {
                FileName getFileNameAttr = new FileName(calc.LittleIndianBytesToInt(filenamelength, 2), FileNameAttr);
                getFileNameAttrUnicodeName = getFileNameAttr.UnicodeNameStr;
            }
            else
            { getFileNameAttrUnicodeName = ""; }


        }
    }
}