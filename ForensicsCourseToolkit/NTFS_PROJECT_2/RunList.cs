using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTFSLearning
{
   public  class RunList
    {
        public int startCluster;
        public int Len;
        public int dataSize;

        public RunList(int start_cluster, int lengthofClusters)
        {
            startCluster = start_cluster;
            Len = lengthofClusters;

            dataSize = Len * MainForm_NTFSLearning.BootSector.BytesPerSector * MainForm_NTFSLearning.BootSector.SectorsPerCluster;
        }
        public byte[] GetData()
        {
           return  MainForm_NTFSLearning.SelectedNTFSDISK.ReadClusters(startCluster, Len);
        }


    }
}
