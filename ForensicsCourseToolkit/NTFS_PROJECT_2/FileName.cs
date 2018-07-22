﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTFSLearning
{
    class FileName
    {
        public byte[] Array;
        public int length;

        public string fileReferenceStr;
        public string fileCreationTimeStr;
        public string fileModificationTimeStr;
        public string MFTmodificationTimeStr;
        public string fileAccessTimeStr;
        public string allocatedSizeofFileStr;
        public string realSizeOfFileStr;
        public string flagsStr;
        public string reparseValueStr;
        public string lengthOfNameStr;
        public string nameSpaceStr;
        public string nameStr;
        public string UnicodeNameStr;


        public DateTime dtfileCreationTime;
        public DateTime dtfileModificationTime;
        public DateTime dtMFTmodificationTime;
        public string dtnameSpace;
        public FileName(int len, byte[] array)
        {
            CalculationUtilities calc = new CalculationUtilities();

            Array = array;
            length = len;

            byte[] fileReference = new byte[8];
            for (int i = 0; i < 8 && i < len; i++)
                fileReference[i] = array[i];

            byte[] fileCreationTime = new byte[8];
            for (int i = 0; i < 8 && (i + 8) < len; i++)
                fileCreationTime[i] = array[8 + i];


            byte[] fileModificationTime = new byte[8];
            for (int i = 0; i < 8 && (i + 16) < len; i++)
                fileModificationTime[i] = array[16 + i];


            byte[] MFTmodificationTime = new byte[8];
            for (int i = 0; i < 8 && (i + 24) < len; i++)
                MFTmodificationTime[i] = array[24 + i];

            byte[] fileAccessTime = new byte[8];
            for (int i = 0; i < 8 && (i + 32) < len; i++)
                fileAccessTime[i] = array[32 + i];



            byte[] allocatedSizeofFile = new byte[8];
            for (int i = 0; i < 8 && (i + 40) < len; i++)
                allocatedSizeofFile[i] = array[40 + i];

            byte[] realSizeOfFile = new byte[8];
            for (int i = 0; i < 8; i++)
                realSizeOfFile[i] = array[48 + i];


            byte[] flags = new byte[4];
            for (int i = 0; i < 4 && (i + 56) < len; i++)
                flags[i] = array[56 + i];

            byte[] reparseValue = new byte[4];
            for (int i = 0; i < 4 && (i + 60) < len; i++)
                reparseValue[i] = array[60 + i];


            byte[] lengthOfName = new byte[1];

            lengthOfName[0] = array[64];

            byte[] nameSpace = new byte[1];
            nameSpace[0] = array[65];

            byte[] name = new byte[16];
            for (int i = 0; i < 16 && (i + 66) < len; i++)
                name[i] = array[66 + i];


            string fileReference_ = BitConverter.ToString(fileReference, 0);//calculateValue(fileReference, 8);
            fileReferenceStr = fileReference_.ToString();

            string fileCreationTime_ = BitConverter.ToString(fileCreationTime, 0);
            fileCreationTimeStr = fileCreationTime_.ToString();
            dtfileCreationTime = DateTime.FromFileTime(calc.LittleIndianBytesToInt64(fileCreationTime, 8));

            string fileModificationTime_ = BitConverter.ToString(fileModificationTime, 0);
            fileModificationTimeStr = fileModificationTime_.ToString();
            dtfileModificationTime = DateTime.FromFileTime(calc.LittleIndianBytesToInt64(fileModificationTime, 8));

            string MFTmodificationTime_ = BitConverter.ToString(MFTmodificationTime, 0);
            MFTmodificationTimeStr = MFTmodificationTime_.ToString();
            dtMFTmodificationTime = DateTime.FromFileTime(calc.LittleIndianBytesToInt64(MFTmodificationTime, 8));

            string fileAccessTime_ = BitConverter.ToString(fileAccessTime, 0);
            fileAccessTimeStr = fileAccessTime_.ToString();


            string allocatedSizeofFile_ = BitConverter.ToString(allocatedSizeofFile, 0);
            allocatedSizeofFileStr = allocatedSizeofFile_.ToString();

            string realSizeOfFile_ = BitConverter.ToString(realSizeOfFile, 0);
            realSizeOfFileStr = realSizeOfFile_.ToString();

            string flags_ = BitConverter.ToString(flags, 0);
            //int flagValue = calc.LittleIndianBytesToInt(flags, 4);
            /// flagsStr = flagsTypes(flagValue);

            flagsStr = flags_.ToString();


            string reparseValue_ = BitConverter.ToString(reparseValue, 0);
            reparseValueStr = reparseValue_.ToString();


            string lengthOfName_ = BitConverter.ToString(lengthOfName, 0);
            lengthOfNameStr = lengthOfName_.ToString();

            string nameSpace_ = BitConverter.ToString(nameSpace, 0);
            nameSpaceStr = nameSpace_.ToString();

            string name_ = BitConverter.ToString(name, 0);//dummy value for 66+
           UnicodeNameStr= Encoding.Unicode.GetString(name);
            nameStr = name_.ToString();

            if (nameSpace[0] == 0)
                dtnameSpace = "POSIX";
            else if (nameSpace[0] == 1)
                dtnameSpace = "WIN32";
            else if (nameSpace[0] == 2)
                dtnameSpace = "DOS";
            else if (nameSpace[0] == 3)
                dtnameSpace = "WIN32 & DOS";










        }

        public string calculateValue(byte[] littleIndianBytes, int no_of_bytes)
        {
            string valueString = "";

            for (int i = no_of_bytes - 1; i >= 0; i--)
            {
                valueString += " " + littleIndianBytes[i].ToString("X2");

            }

            return valueString;

        }

        public string flagsTypes(int flags_)
        {
            string flagstype = "";
            if (flags_ == 1)
            {

                flagstype = "Read Only";

            }

            if (flags_ == 2)
            {

                flagstype = "Hidden";

            }

            if (flags_ == 4)
            {

                flagstype = "System";

            }

            if (flags_ == 32) // 0x20
            {

                flagstype = "Archive";

            }

            if (flags_ == 64) // 0x40
            {

                flagstype = "Device";

            }

            if (flags_ == 128) // 0x80
            {

                flagstype = "Normal";

            }

            if (flags_ == 256) // 0x100
            {

                flagstype = "Temporary";

            }

            if (flags_ == 512) // 0x200
            {

                flagstype = "Sparse file";

            }

            if (flags_ == 1024) // 0x400
            {

                flagstype = "Reparse file";

            }

            if (flags_ == 2048) // 0x800
            {

                flagstype = "Complressed";

            }

            if (flags_ == 4096) // 0x1000
            {

                flagstype = "Offline";

            }

            if (flags_ == 8192) // 0x2000
            {

                flagstype = "Content is not being indexed for faster searches";

            }

            if (flags_ == 16384) // 0x4000
            {

                flagstype = "Encrypted";

            }

            return flagstype;

        }

    }
}
