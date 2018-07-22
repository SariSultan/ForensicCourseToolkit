using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RawDiskLib;

namespace NTFSLearning
{
   public  class NTFSBootSector
    {
        /* done Task: calculate the Bootsector data slide 10  book pg 272*/
        
       public byte[] sectorData;
       public int BytesPerSector;
       public int SectorsPerCluster;
       public int ClusterNoFirstMFT;
       public int ReservedSectors;
       public int TotalSectors;
       public int ClusterNoMFTMirr;
       public int MFTentrySize;
       public int indexRecordSize;
       private int calculateValue(byte[] littleIndianBytes, int no_of_bytes)
       {
           string valueString = "";

           for (int i = no_of_bytes - 1; i >= 0; i--)
           {
               valueString += littleIndianBytes[i].ToString("X2");

           }

           return Convert.ToInt32(valueString,16);

       }


       public  NTFSBootSector(RawDisk disk)
        {
            CalculationUtilities calc = new CalculationUtilities();
            sectorData = new byte[disk.SectorSize];
            sectorData = disk.ReadSectors(0, 1);

            ////calculate BytesPerSector/////
            byte[] noBytesPerSector = new byte[2];
            int count = 0;
            for (int i = 11; count < 2; i++)
            {
                noBytesPerSector[count] = sectorData[i];
                count++;
            }
            BytesPerSector = calc.LittleIndianBytesToInt(noBytesPerSector, 2);

            //BytesPerSector =  512;

            ////////////////////////////

            /////calculate  SectorsPerCluster/////

            byte[] noSectorsPerCluster = new byte[1];
            noSectorsPerCluster[0] = sectorData[13];
            SectorsPerCluster = calc.LittleIndianBytesToInt(noSectorsPerCluster, 1);
            // SectorsPerCluster = 8;


            ////// calculate ReservedSectors ////

            byte[] noReservedSectors = new byte[2];
             count = 0;
            for (int i = 14; count < 2; i++)
            {
                noReservedSectors[count] = sectorData[i];
                count++;
            }
            ReservedSectors = calc.LittleIndianBytesToInt(noReservedSectors, 2);

            ///////// calculate TotalSectors ////////

            byte[] noTotalSectors = new byte[8];
             count = 0;
            for (int i = 40; count < 8; i++)
            {
                noTotalSectors[count] = sectorData[i];
                count++;
            }
            TotalSectors = calc.LittleIndianBytesToInt(noTotalSectors, 8);


            ////////////////////////////////
            ///calculate     Cluster_Number_FistMFT
            //ClusterNoFirstMFT = 8277;

            byte[] Cluster_Number_FistMFTBytes =new byte[8];  
             count=0;
           for (int i=48;count<8;i++)
            {Cluster_Number_FistMFTBytes[count]=sectorData[i];
              count++;
            }
           ClusterNoFirstMFT = calc.LittleIndianBytesToInt(Cluster_Number_FistMFTBytes, 8);

            ////// calculate ClusterNoMFTMirr //////

            byte[] noClusterNoMFTMirr = new byte[8];
            count = 0;
            for (int i = 56; count < 8; i++)
            {
                noClusterNoMFTMirr[count] = sectorData[i];
                count++;
            }
            ClusterNoMFTMirr = calc.LittleIndianBytesToInt(noClusterNoMFTMirr, 8);

            //////// calculate MFTentrySize ///////
            byte[] noMFTentrySize = new byte[1];
            noMFTentrySize[0] = sectorData[64];
            MFTentrySize = calc.LittleIndianBytesToInt(noMFTentrySize, 1);

            //////// calculate indexRecordSize //////
            byte[] noindexRecordSize = new byte[1];
            noindexRecordSize[0] = sectorData[68];
            indexRecordSize = calc.LittleIndianBytesToInt(noindexRecordSize, 1);


        }


    }

   
}
