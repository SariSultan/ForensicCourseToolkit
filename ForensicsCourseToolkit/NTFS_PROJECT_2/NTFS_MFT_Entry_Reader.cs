using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RawDiskLib;

namespace NTFSLearning
{
    class NTFS_MFT_Entry_Reader
    {
        RawDisk NTFSdisk;
        NTFSBootSector bootSector;
        public NTFS_MFT_Entry_Reader(RawDisk disk,NTFSBootSector PartitionbootSector)
        {
            NTFSdisk = disk;
            bootSector = PartitionbootSector;
         }

    public byte[] GetMFT_Entry_by_ClusterNo(int ClusterNo)
        {
         byte[]  MFTEntryData = new byte[1024];
         byte[] clusterData=  NTFSdisk.ReadClusters(ClusterNo, 1);
        
        for (int i=0;i<1024;i++)
        {
            MFTEntryData[i] = clusterData[i];
        }
        
      


           return MFTEntryData;
        }

    public byte[] GetMFT_Entry_by_MFTIndex(int MFTIndex)
    {
        byte[] MFTEntryData = new byte[1024];
        byte[] blockData;

        
        /* Task: calculate the cluster no or sector no to can fetch data then decide to use read clustor or read sector

        try to calculate ClusterNo or sectorNo 
         * 
         * 
        */
        int sectoraddress = (bootSector.ClusterNoFirstMFT * bootSector.SectorsPerCluster) + 2 * MFTIndex;
        blockData = NTFSdisk.ReadSectors(sectoraddress, 2);

         
        
        /////////////////////////////////////////////////////////////////////////////////

        for (int i = 0; i < 1024; i++)
        {
           MFTEntryData[i] = blockData[i];
        }




        return MFTEntryData;
    }


    }
}
