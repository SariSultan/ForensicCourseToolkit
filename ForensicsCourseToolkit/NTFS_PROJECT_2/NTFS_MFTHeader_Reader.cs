using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTFSLearning
{

  public  class NTFS_MFTHeader_Reader
    {
        /* done  Task: implment the 42 bytes  MFT Entry Header as slide 18  book pg 254*/

        public byte[] Headerdata = new byte[42];
        public int  OffsetFixupArray;
        public int  NoEntryFixupArray;
        public int  LogFileSeq;
        public int  seqvalue;
        public int  linkcount;
        public int  offsettoattr1;
        public int  flags;
        public int  MFTentrysize;
        public int  allMFTentry;
        public int  baserecordfileref;
        public int  nextattrid;
        
        
        public NTFS_MFTHeader_Reader(byte[] headerDataarray)
        {
            CalculationUtilities calc = new CalculationUtilities();
            Headerdata = headerDataarray;

            ///////// OffsetFixupArray //////////
            byte[] noOffsetFixupArray = new byte[2];
            int count = 0;
            for (int i = 4; count < 2; i++)
            {
               noOffsetFixupArray[count] = Headerdata[i];
                count++;
            }
            OffsetFixupArray = calc.LittleIndianBytesToInt(noOffsetFixupArray, 2);

            /////// NoEntryFixupArray ///////
            byte[] noNoEntryFixupArray = new byte[2];
            count = 0;
            for (int i = 6; count < 2; i++)
            {
                noNoEntryFixupArray[count] = Headerdata[i];
                count++;
            }
            NoEntryFixupArray = calc.LittleIndianBytesToInt(noNoEntryFixupArray, 2);

            /////// LogFileSeq /////////
            byte[] noLogFileSeq = new byte[8];
            count = 0;
            for (int i = 8; count < 2; i++)
            {
                noLogFileSeq[count] = Headerdata[i];
                count++;
            }
            LogFileSeq = calc.LittleIndianBytesToInt(noLogFileSeq, 8);

            ///////// seqvalue /////////////
            byte[] noseqvalue = new byte[2];
            count = 0;
            for (int i = 16; count < 2; i++)
            {
                noseqvalue[count] = Headerdata[i];
                count++;
            }
            seqvalue = calc.LittleIndianBytesToInt(noseqvalue, 2);

            ///////linkcount ///////////
            byte[] nolinkcount = new byte[2];
            count = 0;
            for (int i = 18; count < 2; i++)
            {
                nolinkcount[count] = Headerdata[i];
                count++;
            }
            linkcount = calc.LittleIndianBytesToInt(nolinkcount, 2);

            /////// offsettoattr1 /////////
            byte[] nooffsettoattr1 = new byte[2];
            count = 0;
            for (int i = 20; count < 2; i++)
            {
                nooffsettoattr1[count] = Headerdata[i];
                count++;
            }
            offsettoattr1 = calc.LittleIndianBytesToInt(nooffsettoattr1, 2);

            ////// flags /////////
            byte[] noflags = new byte[2];
            count = 0;
            for (int i = 22; count < 2; i++)
            {
                noflags[count] = Headerdata[i];
                count++;
            }
            flags = calc.LittleIndianBytesToInt(noflags, 2);

            ////// MFTentrysize /////////
            byte[] noMFTentrysize = new byte[4];
            count = 0;
            for (int i = 24; count < 4; i++)
            {
                noMFTentrysize[count] = Headerdata[i];
                count++;
            }
            MFTentrysize = calc.LittleIndianBytesToInt(noMFTentrysize, 4);

            ///// allMFTentry ///////
            byte[] noallMFTentry = new byte[4];
            count = 0;
            for (int i = 28; count < 4; i++)
            {
                noallMFTentry[count] = Headerdata[i];
                count++;
            }
            allMFTentry = calc.LittleIndianBytesToInt(noallMFTentry, 4);

            ////// baserecordfileref ///////
            byte[] nobaserecordfileref = new byte[8];
            count = 0;
            for (int i = 32; count < 8; i++)
            {
                nobaserecordfileref[count] = Headerdata[i];
                count++;
            }
            baserecordfileref = calc.LittleIndianBytesToInt(nobaserecordfileref, 8);

            //// nextattrid ////////
            byte[] nonextattrid = new byte[2];
            count = 0;
            for (int i = 40; count < 2; i++)
            {
                nonextattrid[count] = Headerdata[i];
                count++;
            }
            nextattrid = calc.LittleIndianBytesToInt(nonextattrid, 2);


        }

    }
}
