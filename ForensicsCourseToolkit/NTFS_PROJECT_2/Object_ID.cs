using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTFSLearning
{
    class Object_ID
    {
        public byte[] Array;
        public int length;

            public string objectIDStr;
            public string birthVolumeIDStr;
            public string birthObjectIDStr;
            public string birthDomainIDStr;


            public Object_ID(int len, byte[] array)
            {
                Array = array;
                length = len;

                byte[] objectID = new byte[16];
                for (int i = 0; (i < 16 && i<len); i++)
                    objectID[i] = array[i];

                byte[] birthVolumeID = new byte[16];
                for (int i = 0; i < 16 && (i+16) < len; i++)
                    birthVolumeID[i] = array[16 + i];


                byte[] birthObjectID = new byte[16];
                for (int i = 0; i < 16 && (i + 32) < len; i++)
                    birthObjectID[i] = array[32 + i];


                byte[] birthDomainID = new byte[16];
                for (int i = 0; i < 16 && (i + 48) < len; i++)
                    birthDomainID[i] = array[48 + i];

                string objectID_ =BitConverter.ToString(objectID, 0);
                objectIDStr = objectID_.ToString();

                string birthVolumeID_ = BitConverter.ToString(birthVolumeID, 0);
                birthVolumeIDStr = birthVolumeID_.ToString();

                string birthObjectID_ = BitConverter.ToString(birthObjectID, 0);
                birthObjectIDStr = birthVolumeID_.ToString();

                string birthDomainID_ = BitConverter.ToString(birthDomainID, 0);
                birthDomainIDStr = birthVolumeID_.ToString();

            }



            public string calculateValue(byte[] littleIndianBytes, int no_of_bytes)
            {
                string valueString = "";

                for (int i = no_of_bytes - 1; i >= 0; i--)
                {
                    valueString += littleIndianBytes[i].ToString("X2");

                }

                return valueString;

            }

    }
}
