using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace NTFSLearning
{
    class REPARSE_POINT
    {
        public int att_length;
        public byte[] att_data;
        public byte[] typeflags = new byte[4];
        public byte[] sizeofdata = new byte[2];
        public byte[] unused = new byte[2];
        public byte[] offsettotargetname = new byte[2];
        public byte[] lengthofname = new byte[2];
        public byte[] offsettoprintname = new byte[2];
        public byte[] lengthofprint = new byte[2];
        public int calculateValue(byte[] littleIndianBytes, int no_of_bytes)
        {
            string valueString = "";
            for (int i = no_of_bytes - 1; i >= 0; i--)
            {
                valueString += littleIndianBytes[i].ToString("X2");
            }
            return Convert.ToInt32(valueString, 16);
        }


        public REPARSE_POINT(int attlength, byte[] attdata)
        {
            att_data = attdata;
            att_length = attlength;
            int count;
            ////typeflags
            count = 0;
            for (int i = 0; count < 4; i++)
            {
                if (i < attlength)
                {
                    typeflags[count] = attdata[i];
                    count++;
                }
                else
                    break;
            }
            ////sizeofdata
            count = 0;
            for (int i = 4; count < 2; i++)
            {
                if (i < attlength)
                {
                    sizeofdata[count] = attdata[i];
                    count++;
                }
                else
                    break;
            }
            ////unused
            count = 0;
            for (int i = 6; count < 2; i++)
            {
                if (i < attlength)
                {
                    unused[count] = attdata[i];
                    count++;
                }
                else
                    break;
            }

            ////offsettotargetname
            count = 0;
            for (int i = 8; count < 2; i++)
            {
                if (i < attlength)
                {
                    offsettotargetname[count] = attdata[i];
                    count++;
                }
                else
                    break;
            }
            ////lengthofname
            count = 0;
            for (int i = 10; count < 2; i++)
            {
                if (i < attlength)
                {
                    lengthofname[count] = attdata[i];
                    count++;
                }
                else
                    break;
            }
            ////offsettoprintname
            count = 0;
            for (int i = 12; count < 2; i++)
            {
                if (i < attlength)
                {
                    offsettoprintname[count] = attdata[i];
                    count++;
                }
                else
                    break;
            }
            ////lengthofprint
            count = 0;
            for (int i = 14; count < 2; i++)
            {
                if (i < attlength)
                {
                    lengthofprint[count] = attdata[i];
                    count++;
                }
                else
                    break;
            }
        }
    }
}