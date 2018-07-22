using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using ForensicsCourseToolkit.Helpers;

namespace ForensicsCourseToolkit.Filesystems
{
    class NTFSBootSector : IHaveStructure, IHaveStartAddress, IHaveExactSize, IHaveCommonProps
    {
        public List<StructureUnit> Structure { get; set; } = new List<StructureUnit>
        {
                //BASED ON SLIDE 10, cpe547, dr. ayed salman
            new StructureUnit
            {
                Order = 1,
                UnitDescription = "Jump Boot Code",
                FixedValue = false,
                UnitColor = Color.Aqua,
                //MicrosoftFiledCode = "BS_jmpBoot",
                OffsetByte = 0,
                SizeBytes = 3,
            },
            new StructureUnit
            {
                Order = 2,
                UnitDescription = "Name in ASCII",
                FixedValue = false,
                UnitColor = Color.Beige,
                Type = UnitType.Ascii,
               // MicrosoftFiledCode = "BS_OEMName",
                OffsetByte = 3,
                SizeBytes = 8,
            },
            new StructureUnit
            {
                Order = 3,
                UnitDescription = "Bytes per Sector",
                FixedValue = false,
                UnitColor = Color.Blue,
                Type = UnitType.LittleEndianHex,
              //  MicrosoftFiledCode = "BPB_BytsPerSec",
                OffsetByte = 0x0B, //11
                SizeBytes = 2,
            },
            new StructureUnit
            {
                Order = 4,
                UnitDescription = "Sectors per Cluster",
                FixedValue = false,
                UnitColor = Color.BlueViolet,
               // MicrosoftFiledCode = "BPB_SecPerClus",
                OffsetByte = 0x0D, // 13
                SizeBytes = 1,
            },
            new StructureUnit
            {
                Order = 5,
                UnitDescription = "Size of reserved area (in sectors)", //COUPLED DO NOT CHANGE ORDER
                FixedValue = false,
                UnitColor = Color.BurlyWood,
                Type = UnitType.SizeInSectorsLittleEndian,
               // MicrosoftFiledCode = "BPB_RsvdSecCnt",
                OffsetByte = 0x0E, //14
                SizeBytes = 2,
            },
            new StructureUnit
            {
                Order = 6,
                UnitDescription = "ALWAYS ZERO",
                FixedValue = true,
                Value = "000000",
                UnitColor = Color.Chartreuse,
                OffsetByte = 0x10, // 16
                SizeBytes = 3,
            },
            new StructureUnit
            {
                Order = 7,
                UnitDescription = "Not used by NTFS",
                FixedValue = false,
                UnitColor = Color.Coral,
                OffsetByte = 0x13,
                SizeBytes = 2,
            },
            new StructureUnit
            {
                Order = 8,
                UnitDescription = "Media Descriptor",
                FixedValue = false,
                UnitColor = Color.Crimson,
                OffsetByte = 0x15 ,
                SizeBytes = 1
            },
            new StructureUnit
            {
                Order = 9,
                UnitDescription = "Always Zero",
                FixedValue = false,
                UnitColor = Color.DarkCyan,
                OffsetByte = 0x16,
                SizeBytes = 2,
            },
            new StructureUnit
            {
                Order = 10,
                UnitDescription = "Sectors Per Track",
                FixedValue = false,
                UnitColor = Color.DarkGray,
                OffsetByte = 0x18,
                SizeBytes = 2
            },
            new StructureUnit
            {
                Order = 11,
                UnitDescription = "Number of Heads",
                FixedValue = false,
                UnitColor = Color.Yellow,
                OffsetByte = 0x1A, //26
                SizeBytes = 2,
            },
            new StructureUnit
            {
                Order = 12,
                UnitDescription = "Number of hidden sectors ",
                FixedValue = false,
                UnitColor = Color.DarkRed,
                OffsetByte = 0x1C,//28
                SizeBytes = 4
            },
            new StructureUnit
            {
                Order = 13,
                UnitDescription = "Not used by NTFS",
                FixedValue = false,
                UnitColor = Color.BlueViolet,
                OffsetByte = 0x20, //32
                SizeBytes = 4
            },
        new StructureUnit
            {
                Order = 14,
                UnitDescription = "Not used by NTFS",
                FixedValue = false,
                UnitColor = Color.CadetBlue,
                OffsetByte = 0x24,
                SizeBytes = 4
            },
                new StructureUnit
            {
                Order = 15,
                UnitDescription = "Total Sectors",
                FixedValue = false,
                UnitColor = Color.Chocolate,
                OffsetByte = 0x28,
                SizeBytes = 8,
                Type = UnitType.LittleEndianHex,
            },
        new StructureUnit
            {
                Order = 16,
                UnitDescription = "Logical Cluster Number LCN for $MFT",
                FixedValue = false,
                UnitColor = Color.Crimson,
                OffsetByte = 0x30,
                SizeBytes = 8,
                Type = UnitType.LittleEndianHex,
            },
        new StructureUnit
            {
                Order = 17,
                UnitDescription = "Logical Cluster Number LCN for $MFTMirr",
                FixedValue = false,
                UnitColor = Color.LightCoral,
                OffsetByte = 0x38,
                SizeBytes = 8,
                Type = UnitType.LittleEndianHex,
            },
                new StructureUnit
            {
                Order = 18,
                UnitDescription = "Clusters per file record segment",
                FixedValue = false,
                UnitColor = Color.SandyBrown,
                OffsetByte = 0x40,
                SizeBytes = 4,
                Type = UnitType.LittleEndianHex,
            },
              new StructureUnit
            {
                Order = 19,
                UnitDescription = "Clusters Per Index Block",
                FixedValue = false,
                UnitColor = Color.SeaGreen,
                OffsetByte = 0x44,
                SizeBytes = 4,
                Type = UnitType.LittleEndianHex,
            },
            new StructureUnit
            {
                Order = 20,
                UnitDescription = "Volume Serial Number",
                FixedValue = false,
                UnitColor = Color.DeepSkyBlue,
                OffsetByte = 0x48,
                SizeBytes = 8,
                Type = UnitType.Ascii,
            },
            new StructureUnit
            {
                Order = 21,
                UnitDescription = "Check Sum",
                FixedValue = false,
                UnitColor = Color.Azure,
                OffsetByte = 0x50,
                SizeBytes = 4,
            },
            new StructureUnit
            {
                Order = 22,
                UnitDescription = "BootStap Program Code",
                FixedValue = false,
                UnitColor = Color.Green,
                OffsetByte = 0x54,
                SizeBytes = 426,
            },
        new StructureUnit
            {
                Order = 23,
                UnitDescription = "Signature bytes",
                FixedValue = false,
                UnitColor = Color.Brown,
                OffsetByte = 0x1FE,
                SizeBytes = 2,
            },

        };
        public int StartAddress { get; set; }
        public int GetExpectedSize()
        {
            return Common.BootSectorSizeBytes;
        }

        public Logger Logger { get; set; }
        public string RawValue { get; set; }
        public int Size => Common.BootSectorSizeBytes;
        public string Description { get; set; }



        public NTFSBootSector()
        {
        }


        public int GetMaxNumberOfRootDirectories()
        {
            return Conversion.HexLittleEndianToInt(Structure[6].Value);
        }

        public int GetNumberOfSectorsPerCluser()
        {
            return Conversion.HexLittleEndianToInt(Structure[3].Value);
        }


        private int GetReservedAreaSizeByte()
        {
            if (Structure == null)
            {
                throw new Exception("Cannot find boot sector start location before loading the structure");
            }
            return Conversion.HexLittleEndianToInt(Structure[4].Value) * Common.BlockSizeInBytes;
        }








        public StructureUnit GetFieldByMicrosoftCode(string microsoftCode, List<StructureUnit> structure)
        {
            return (from x in Structure where x.MicrosoftFiledCode.Trim().ToLower() == microsoftCode.Trim().ToLower() select x).First();
        }

        public int GetFieldValueasIntbyMicrosoftCode(string microsoftCode, List<StructureUnit> structure)
        {
            return Helpers.Conversion.HexLittleEndianToInt(GetFieldByMicrosoftCode(microsoftCode, structure).Value);
        }

        private int _totalSectors = 0;

    }
}
