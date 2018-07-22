using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTFSLearning
{
    class INDEX_ALLOCATION
    {
        public int att_length;
        public byte[] att_data;
        //// index allocation values
        public byte[] signature = new byte[4];
        public byte[] offsettofixup = new byte[2];
        public byte[] numberofentries = new byte[2];
        public byte[] LSN = new byte[8];
        public byte[] VCN = new byte[8];
        //// node header values
        public byte[] offsettoentrylist = new byte[4];
        public int _offsettoentrylist;
        public byte[] offsettoendused = new byte[4];
        public int _offsettoendused;
        public byte[] offsettoendalloc = new byte[4];
        public int _offsettoendalloc;
        public byte[] flags = new byte[4];
        //// index entries
        public List<IndexEntry> IndexEntryList = new List<IndexEntry>();
        CalculationUtilities calc = new CalculationUtilities();


        public INDEX_ALLOCATION(int attlength, byte[] attdata)
        {
            att_data = attdata;
            att_length = attlength;
            int count;
            ////signature
            count = 0;
            for (int i = 0; count < 4; i++)
            {
                if (i < attlength)
                {
                    signature[count] = attdata[i];
                    count++;
                }
                else
                    break;
            }

            ////offsettofixup
            count = 0;
            for (int i = 4; count < 2; i++)
            {
                if (i < attlength)
                {
                    offsettofixup[count] = attdata[i];
                    count++;
                }
                else
                    break;
            }

            ////numberofentries
            count = 0;
            for (int i = 6; count < 2; i++)
            {
                if (i < attlength)
                {
                    numberofentries[count] = attdata[i];
                    count++;
                }
                else
                    break;
            }

            ////LSN
            count = 0;
            for (int i = 8; count < 8; i++)
            {
                if (i < attlength)
                {
                    LSN[count] = attdata[i];
                    count++;
                }
                else
                    break;
            }

            ////VCN
            count = 0;
            for (int i = 16; count < 8; i++)
            {
                if (i < attlength)
                {
                    VCN[count] = attdata[i];
                    count++;
                }
                else
                    break;
            }

            ///////////node header ///////////////
            ////offsettoentrylist
            count = 0;
            for (int i = 24; count < 4; i++)
            {
                if (i < attlength)
                {
                    offsettoentrylist[count] = attdata[i];
                    count++;
                }
                else
                    break;
            }

            _offsettoentrylist = calc.LittleIndianBytesToInt(offsettoentrylist, 4);
            ////offsettoendused
            count = 0;
            for (int i = 28; count < 4; i++)
            {
                if (i < attlength)
                {
                    offsettoendused[count] = attdata[i];
                    count++;
                }
                else
                    break;
            }

            _offsettoendused = calc.LittleIndianBytesToInt(offsettoendused, 4);
            ////offsettoendalloc
            count = 0;
            for (int i = 32; count < 4; i++)
            {
                if (i < attlength)
                {
                    offsettoendalloc[count] = attdata[i];
                    count++;
                }
                else
                    break;
            }
            _offsettoendalloc = calc.LittleIndianBytesToInt(offsettoendalloc, 4);
            ////flags
            count = 0;
            for (int i = 36; count < 4; i++)
            {
                if (i < attlength)
                {
                    flags[count] = attdata[i];
                    count++;
                }
                else
                    break;
            }

            ////////index entry List //////

            int startofNodeHeader = 24;

            int startofIndexEntryList = startofNodeHeader + _offsettoentrylist;
            int EndofIndexEntryList = startofNodeHeader + _offsettoendused;
            int index = startofIndexEntryList;
            do
            {
                byte[] lenth = new byte[2];
                lenth[0] = att_data[index + 8];
                lenth[1] = att_data[index + 9];
                int entrylenth = calc.LittleIndianBytesToInt(lenth, 2);
                byte[] indexEntryData = new byte[entrylenth];

                for (int x = 0; x < entrylenth; x++, index++)
                {
                    indexEntryData[x] = att_data[index];
                }

                IndexEntry entry = new IndexEntry(entrylenth, indexEntryData);

                IndexEntryList.Add(entry);

            } while (index < EndofIndexEntryList);


            

        }


    }
}
