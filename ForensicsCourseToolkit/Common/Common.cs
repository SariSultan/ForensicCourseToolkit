using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using ForensicsCourseToolkit.Helpers;

namespace ForensicsCourseToolkit.Filesystems
{
    public static class Common
    {
        public static int BlockSizeInBytes = 512;
        public static int MbrSizeBytes = int.Parse("01FF", NumberStyles.HexNumber) + 1; //cze 0 indexed
        public static int VbrSizeBytes = int.Parse("000F", NumberStyles.HexNumber) + 1; //cze 0 indexed
        public static int BootSectorSizeBytes = int.Parse("01FF", NumberStyles.HexNumber) + 1; //cze 0 indexed
        public static int FatDirectoryAreaSizeBytes = int.Parse("001F", NumberStyles.HexNumber) + 1; //cze 0 indexed

        public static string CutBytesOLD(string originalBytesHex, string unitStartLocationHex, string unitEndLocationHex)
        {
            var startVal = int.Parse(unitStartLocationHex, NumberStyles.HexNumber);
            startVal *= 2;
            var endVal = int.Parse(unitEndLocationHex, NumberStyles.HexNumber) + 1; //cze 0 indexed
            endVal *= 2;
            return originalBytesHex.Substring(startVal, endVal - startVal);
        }

        public static string CutBytes(string originalBytesHex, int offset, int size)
        {
            var startVal = offset * 2;
            var endVal = startVal + size * 2;
            return originalBytesHex.Substring(startVal, endVal - startVal);//inclusive counting and each hex is 2 chars
        }

        public static string ReadBytesFromImageAsHex(string fileName, int startAddress, int sizeToRead, ref Logger aLogger)
        {
            try
            {
                var hex = "";
                using (var fs = new FileStream(fileName, FileMode.Open))
                {
                    byte[] buf = new byte[sizeToRead];
                    fs.Seek(startAddress, SeekOrigin.Begin);

                    fs.Read(buf, 0, sizeToRead);

                    int hexIn;
                    // for (var i = 0; ((hexIn = fs.ReadByte()) != -1) && (i < sizeToRead); i++)
                    //for(var i=0; i<sizeToRead;i++)
                    //{
                    //     hex += $"{buf[i]:X2}";
                    // }
                   hex = BitConverter.ToString(buf).Replace("-", string.Empty);

                }
                return hex;
            }
            catch (Exception ex)
            {
                aLogger.LogMessage(ex.Message, LogMsgType.Fatal);
                return null;
            }
        }
        public static bool ReadBytesFromImageAsHexAndSaveToFile(string fileName, int startAddress, int sizeToRead, string saveFileName, ref Logger aLogger)
        {
            try
            {
                using (var fs = new FileStream(fileName, FileMode.Open))
                using (var fd = new FileStream(saveFileName, FileMode.Create))
                {

                    byte[] buf = new byte[sizeToRead];
                    fs.Seek(startAddress, SeekOrigin.Begin);

                    fs.Read(buf, 0, sizeToRead);
                    fd.Write(buf, 0, sizeToRead);
                }
            }
            catch (Exception ex)
            {
                aLogger.LogMessage(ex.Message, LogMsgType.Fatal);
                return false;
            }
            return false;
        }
        public static void ParseStructureUnits(List<StructureUnit> aStructure, string rawHex, Logger aLogger)
        {
            foreach (var unit in aStructure)
            {
                try
                {
                    //var temp = Common.CutBytes(rawHex, unit.UnitStartLocationHex, unit.UnitEndLocationHex);


                    var temp = Common.CutBytes(rawHex, unit.OffsetByte, unit.SizeBytes);
                    if (unit.FixedValue)
                    {
                        if (unit.Value != temp.ToUpper())
                        {
                            aLogger.LogMessage(
                                $"{MethodBase.GetCurrentMethod().Name}:: unit [{unit.UnitDescription}] from loc=[{unit.OffsetByte.ToString("X4")}] to [{(unit.OffsetByte + unit.SizeBytes).ToString("X4")}] the value should equal {unit.Value} but it is {temp}... OPERATION TERMINATED!",
                                LogMsgType.Fatal);
                            return;
                        }
                    }
                    unit.Value = temp;
                }
                catch (Exception ex)
                {
                    aLogger.LogMessage(
                        $"{MethodBase.GetCurrentMethod().Name}:: Unable to parse mbr unit [{unit.UnitDescription}] from loc=[{unit.OffsetByte.ToString("X4")}] to [{(unit.OffsetByte + unit.SizeBytes).ToString("X4")}] ... OPERATION TERMINATED! \n {ex.ToString()}",
                        LogMsgType.Fatal);
                    return;
                }
            }
        }


        public static T GetUnit<T>(string fileName, ref Logger aLogger, int startAddress, string description, IHaveStructure myParent) where T : IHaveStructure, IHaveCommonProps, new()
        {
            var instance = Activator.CreateInstance<T>();
            try
            {
                var unitStartAddress = startAddress;
                instance.Description = description;
                instance.Logger = aLogger;

                if (instance is IHaveStartAddress)
                {
                    (instance as IHaveStartAddress).StartAddress = startAddress;
                }
                //IF THE START ADDRESS IS -1 THEN THE FILE NAME IS THE HEX VALUE
                instance.RawValue = (startAddress == -1)
                    ? fileName
                    : ReadBytesFromImageAsHex(fileName, unitStartAddress, instance.Size, ref aLogger);

                if (instance is IHaveExactSize)
                {
                    var expectedSizeInHex = (instance as IHaveExactSize).GetExpectedSize() * 2;
                    var checkerSize = instance.RawValue.Length;
                    if (checkerSize != expectedSizeInHex)
                    {
                        var err =
                            $"in {System.Reflection.MethodBase.GetCurrentMethod().Name}, Structure unit has fixed size of [{expectedSizeInHex}] but the actual size is[{checkerSize}]...Operation Terminated ";
                        aLogger.LogMessage(err, LogMsgType.Fatal);
                        throw new Exception(err);
                    }
                }

                if (instance.Structure != null)
                {
                    ParseStructureUnits(instance.Structure, instance.RawValue, aLogger);
                }
                else
                {
                    aLogger.LogMessage(
                        $"in {System.Reflection.MethodBase.GetCurrentMethod().Name}, Structure list is empty...Operation Terminated ",
                        LogMsgType.Fatal);
                }

                if (instance is BootSector)
                {
                    (instance as BootSector).DetermineFatType();
                }
                if (instance is FatDirectoryArea)
                {
                    if (myParent is BootSector)
                    {
                        var i = instance as FatDirectoryArea;
                        if (i.IsThisEntryaLongFileName())
                        {
                            i.Structure = i.LongFileNameStructure;
                            ParseStructureUnits(i.Structure, i.RawValue, aLogger);
                        }
                        var mp = myParent as BootSector;

                        i.MaxNumofRootDirectories = mp.GetMaxNumberOfRootDirectories();
                        i.SectorsPerCluster = mp.GetNumberOfSectorsPerCluser();
                        i.RootDirectoryStartAddress = mp.GetRootDirectoryStartByte();
                    }
                    else
                    {
                        var err =
                            $"in {System.Reflection.MethodBase.GetCurrentMethod().Name}, You forget to pass bootsector parent? normally its null. Operation terminated. ";
                        aLogger.LogMessage(err, LogMsgType.Fatal);
                        throw new Exception("err");
                    }
                }
                return instance;
            }
            catch (Exception ex)
            {
                aLogger.LogMessage(ex.Message, LogMsgType.Fatal);
                return instance;
            }
        }
    }
}