using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace NTFSLearning
{
    class INDEX_ROOT
    {
        public int att_length;
        public byte[] att_data;
        public byte[] type = new byte[4];
        public byte[] sortingrule = new byte[4];
        public byte[] indexsizeinbytes = new byte[4];
        public byte[] indexsizeclust = new byte[1];
        public byte[] unused = new byte[3];
        public byte[] offsettoentrylist = new byte[4];
       public int _offsettoentrylist;
        public byte[] offsettoendused = new byte[4];
        public int _offsettoendused;
        public byte[] offsettoendalloc = new byte[4];
        public int _offsettoendalloc;
        public byte[] flags = new byte[4];

        public List<IndexEntry> IndexEntryList= new List<IndexEntry>();
        CalculationUtilities calc = new CalculationUtilities();
        public INDEX_ROOT(int attlength, byte[] attdata)
        {
            att_data = attdata;
            att_length=attlength;
            int count;
            ////type
            count = 0;
            for (int i = 0; count < 4; i++)
            {
                if (i < attlength)
                {
                    type[count] = attdata[i];
                    count++;
                }
                else
                    break;
            }
            ////sortingrule
            count = 0;
            for (int i = 4; count < 4; i++)
            {
                if (i < attlength)
                {
                    sortingrule[count] = attdata[i];
                    count++;
                }
                else
                    break;
            }
            ////indexsizeinbytes
            count = 0;
            for (int i = 8; count < 4; i++)
            {
                if (i < attlength)
                {
                    indexsizeinbytes[count] = attdata[i];
                    count++;
                }
                else
                    break;
            }
            ////indexsizeclust
            indexsizeclust[0] = attdata[12];

            ////unused
            count = 0;
            for (int i = 13; count < 3; i++)
            {
                if (i < attlength)
                {
                    unused[count] = attdata[i];
                    count++;
                }
                else
                    break;
            }
            ///////////node header ///////////////
            ////offsettoentrylist
            count = 0;
            for (int i = 16; count < 4; i++)
            {
                if (i < attlength)
                {
                    offsettoentrylist[count] = attdata[i];
                    count++;
                }
                else
                    break;
            }

            _offsettoentrylist = calc.LittleIndianBytesToInt(offsettoentrylist,4);
            ////offsettoendused
            count = 0;
            for (int i = 20; count < 4; i++)
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
            for (int i = 24; count < 4; i++)
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
            for (int i = 28; count < 4; i++)
            {
                if (i < attlength)
                {
                    flags[count] = attdata[i];
                    count++;
                }
                else
                    break;
            }


            ////////index entry List

            int startofNodeHeader = 16;

            int startofIndexEntryList = startofNodeHeader + _offsettoentrylist;
            int EndofIndexEntryList=startofNodeHeader+_offsettoendused;
            int index=startofIndexEntryList;
            do
            {
                byte[] lenth=new byte[2]   ;
                lenth[0] = att_data[index + 8];
                lenth[1] = att_data[index + 9];
                int entrylenth = calc.LittleIndianBytesToInt(lenth, 2);
                byte[] indexEntryData=new byte[entrylenth];
              
                for (int x=0;x<entrylenth;x++,index++)
                {indexEntryData[x]=att_data[index];
                }

                IndexEntry entry = new IndexEntry(entrylenth, indexEntryData);

                IndexEntryList.Add(entry);

            } while (index < EndofIndexEntryList);
        }


        


    }
}