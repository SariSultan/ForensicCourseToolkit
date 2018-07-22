using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace NTFSLearning
{
    class VOLUME_INFORMATION
    {
        public int att_length = 12;
        public byte[] att_data = new byte[12];
        public byte[] unused = new byte[8];
        public byte[] majorversion = new byte[1];
        public byte[] minorversion = new byte[1];
        public byte[] flags = new byte[2];
        public string ftype;

        public int calculateValue(byte[] littleIndianBytes, int no_of_bytes)
        {
            string valueString = "";
            for (int i = no_of_bytes - 1; i >= 0; i--)
            {
                valueString += littleIndianBytes[i].ToString("X2");
            }
            return Convert.ToInt32(valueString, 16);
        }

        public VOLUME_INFORMATION(int attlength, byte[] attdata)
        {
            int count;
            ////unused
            count = 0;
            for (int i = 7; count < 8; i--)
            {
                if (i < attlength)
                {
                    unused[count] = attdata[i];
                    count++;
                }
                else
                    break;
            }
            ////majorversion
            majorversion[0] = attdata[8];
            ////minorversion
            minorversion[0] = attdata[9];
            ////flags
            count = 0;
            for (int i = 10; count < 2; i++)
            {
                if (i < attlength)
                {
                    flags[count] = attdata[i];
                    count++;
                }
                else
                    break;
            }
            /// flags type
            int flagstype = calculateValue(flags, 2);
            if (flagstype == 1) // ox0001
            {
                ftype = "Dirty";
            }
            if (flagstype == 2) // ox0002
            {
                ftype = "Resize logfile";
            }
            if (flagstype == 4) // ox0004
            {
                ftype = "Upgrade volume";
            }
            if (flagstype == 8) // ox0008
            {
                ftype = "Mounted in NT";
            }
            if (flagstype == 16) // ox0010
            {
                ftype = "Deleting change journal";
            }
            if (flagstype == 32) // ox0020
            {
                ftype = "Reoair object IDs";
            }
            if (flagstype == 32768) // ox8000
            {
                ftype = "Modified by chkdsk";
            }

        }

    }
}