﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ForensicsCourseToolkit.Filesystems;
using ForensicsCourseToolkit.Helpers;

namespace ForensicsCourseToolkit
{
    public partial class fatFrm : Form
    {
        #region VARIABLES

        private Logger aLogger;
        private Mbr anMbr;
        private List<Vbr> vbrsList;
        private List<BootSector> bootSectors;
        private string fileName = "";

        #endregion
        #region INITIALIZATION

        public fatFrm()
        {
            InitializeComponent();
            richTextBox1.WordWrap = false;

            aLogger = new Logger(ref richTextBox1);

            treeView1.NodeMouseDoubleClick += TreeView1_NodeMouseDoubleClick;
        }

        private void TreeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var startAddress = int.Parse(e.Node.Name);

            if (e.Node.Text.Contains("DELETED"))
            {
                restoreFileBtn.Visible = true;
            }
            else
            {
                restoreFileBtn.Visible = false;
            }

            var index = richTextBox1.Find(startAddress.ToString("X8"));

            if (index > 0)
            {
                richTextBox1.SelectionStart = index;
                richTextBox1.ScrollToCaret();
            }
        }



        #endregion

        #region BUTTONS EVENTS

        private void openImageBtn_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                aLogger.LogMessage("Did not select a file!", LogMsgType.Debug);
                anMbr = null;

                return;
            }
            fileName = openFileDialog.FileName;
            if (!ReadImage(fileName))
                return;
            parseVbr();
        }

        #endregion BUTTONS EVENTS

        #region RTB EVENTS

        private void richTextBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //click event
                //MessageBox.Show("you got it!");
                var contextMenu = new ContextMenu();
                var menuItem = new MenuItem("Cut");
                menuItem.Click += RtbExtensions.CutAction;
                contextMenu.MenuItems.Add(menuItem);
                menuItem = new MenuItem("Copy");
                menuItem.Click += RtbExtensions.CopyAction;
                contextMenu.MenuItems.Add(menuItem);
                menuItem = new MenuItem("Paste");
                menuItem.Click += RtbExtensions.PasteAction;
                contextMenu.MenuItems.Add(menuItem);

                menuItem = new MenuItem("Covert Value to Int (Little Endian)");
                menuItem.Click += RtbExtensions.LittleEndiaCovert;
                contextMenu.MenuItems.Add(menuItem);


                richTextBox1.ContextMenu = contextMenu;
            }
        }

        #endregion RTB EVENTS

        private bool ReadImage(string fileName)
        {
            aLogger.LogMessage($" Opening file [{fileName}]", LogMsgType.Verbose);

            // anMbr = Mbr.ParseMbr(fileName, ref aLogger);
            anMbr = Common.GetUnit<Mbr>(fileName, ref aLogger, 0, "MBR", null);
            if (anMbr == null)
            {
                aLogger.LogMessage($"Unable to read MBR from file [{fileName}], Operation Terminated!", LogMsgType.Error);
                return false;
            }
            aLogger.LogMessage($"Image [{fileName}], Loaded Successfully.", LogMsgType.Verbose);
            return true;
        }

        private void parseVbr()
        {
            var vbrRAWList = (from u in anMbr.Structure
                              where u.Type == UnitType.Vbr
                              select u).ToList();

            if (vbrRAWList.Count == 0)
            {
                aLogger.LogMessage("vbr list is empty, end function!", LogMsgType.Warning);
                return;
            }
            vbrsList = new List<Vbr>();
            foreach (var v in vbrRAWList)
            {
                //var aVbr = new Vbr(v.Value, $"VBR[{(v.Order - 1).ToString("X2")}]", ref aLogger);
                var aVbr = Common.GetUnit<Vbr>(v.Value, ref aLogger, -1, $"VBR[{(v.Order - 1).ToString("X2")}]", null);
                if (!aVbr.IsEmptyPartition())
                { vbrsList.Add(aVbr); }
            }
        }

        private void printVbrsBtn_Click(object sender, EventArgs e)
        {
            if (anMbr == null)
            {
                aLogger.LogMessage("mbr is empty (maybe not loaded yet!), end function!", LogMsgType.Warning);
                return;
            }

            if (vbrsList == null)
            {
                aLogger.LogMessage("vbr list is empty, end function!", LogMsgType.Warning);
                return;
            }
            if (vbrsList.Count == 0)
            {
                aLogger.LogMessage("vbr list is empty, end function!", LogMsgType.Warning);
                return;
            }
            foreach (var v in vbrsList)
            {
                Printer.PrintHorizentalLine(ref richTextBox1, 80, '-', true);
                richTextBox1.AppendText($"Printing {v.Description}", Color.Magenta, true);
                richTextBox1.AppendText("\n");
                Printer.PrintHorizentalLine(ref richTextBox1, 80, '-', true);
                if (!v.IsEmptyPartition())
                    Printer.PrintStructureValues(v.Structure, ref richTextBox1, ref aLogger);
            }
        }

        private void showVbrStructureBtn_Click(object sender, EventArgs e)
        {
            Printer.PrintEmptyStructure<Vbr>(ref aLogger, ref richTextBox1);
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void showBootSectorStructureBtn_Click(object sender, EventArgs e)
        {
            Printer.PrintEmptyStructure<BootSector>(ref aLogger, ref richTextBox1);
        }

        private void PrintBootSectorsBtn_Click(object sender, EventArgs e)
        {
            if (anMbr == null)
            {
                aLogger.LogMessage("mbr is empty (maybe not loaded yet!), end function!", LogMsgType.Warning);
                return;
            }
            if (vbrsList == null)
            {
                aLogger.LogMessage("vbr list is empty, end function!", LogMsgType.Warning);
                return;
            }
            if (vbrsList.Count == 0)
            {
                aLogger.LogMessage("vbr list is empty, end function!", LogMsgType.Warning);
                return;
            }
            Helpers.Printer.PrintVbrListWithBootSectors(fileName, ref vbrsList, ref aLogger, ref richTextBox1, true);
            //Helpers.Printer.PrintVbrListWithBootSectors();
            //foreach (var vbr in vbrsList)
            //{

            //    var bs = BootSector.ParseBootSector(fileName, vbr, ref aLogger);
            //    if (bs.IsEmpty)
            //    {
            //        richTextBox1.AppendText($"Printing {bs.BootSectorDescription}", Color.DarkCyan, true);
            //        richTextBox1.AppendText("\n");
            //    }
            //    else
            //    {
            //        Printer.PrintHorizentalLine(ref richTextBox1, 80, '-', true);
            //        richTextBox1.AppendText($"Printing {bs.BootSectorDescription}", Color.DarkCyan, true);
            //        richTextBox1.AppendText("\n");
            //        Printer.PrintHorizentalLine(ref richTextBox1, 80, '-', true);



            //        richTextBox1.AppendText("\n");
            //    }
            //}
        }

        private void PrintBootSectorVals_Click(object sender, EventArgs e)
        {
            if (anMbr == null)
            {
                aLogger.LogMessage("mbr is empty (maybe not loaded yet!), end function!", LogMsgType.Warning);
                return;
            }
            if (vbrsList == null)
            {
                aLogger.LogMessage("vbr list is empty, end function!", LogMsgType.Warning);
                return;
            }
            if (vbrsList.Count == 0)
            {
                aLogger.LogMessage("vbr list is empty, end function!", LogMsgType.Warning);
                return;
            }

            Helpers.Printer.PrintVbrListWithBootSectors(fileName, ref vbrsList, ref aLogger, ref richTextBox1, false);
        }



        private void FatDirectoryStructureBtn_Click(object sender, EventArgs e)
        {
            Printer.PrintEmptyStructure<FatDirectoryArea>(ref aLogger, ref richTextBox1);
        }

        List<FatDirectoryArea> RootDirectoryEntries = new List<FatDirectoryArea>();

        public void ParseRootDirectoryEntries()
        {
            foreach (var bs in bootSectors)
            {
                int dataAreaStartLoc = bs.GetRootDirectoryStartByte();//this should be equal to the start address inside the directory

                List<FatDirectoryArea> longNames = new List<FatDirectoryArea>();
                while (true)
                {
                    var directory = Common.GetUnit<FatDirectoryArea>(fileName, ref aLogger, dataAreaStartLoc,
                       "DirectoryArea-" + bs.Description, bs);

                    dataAreaStartLoc += Common.FatDirectoryAreaSizeBytes;
                    if (directory.IsEmpty) break;

                    if (directory.IsThisEntryaLongFileName())
                    {
                        longNames.Add(directory);
                    }
                    else
                    {
                        if (longNames.Count > 0)
                        {
                            directory.LongFileNames = longNames;
                            longNames = new List<FatDirectoryArea>();
                        }
                        RootDirectoryEntries.Add(directory);

                    }

                    if (directory.IsThisEntryaDirectory())
                    {
                        var childrenStartLoc = directory.GetDataLocation();
                        ParseChildren(ref directory, bs);
                    }

                }
            }
        }

        void ParseChildren(ref FatDirectoryArea parent, BootSector bs)
        {
            if (!parent.IsThisEntryaDirectory()) return;
            int dataAreaStartLoc = parent.GetDataLocation();
            List<FatDirectoryArea> longNames = new List<FatDirectoryArea>();
            while (true)
            {
                var directory = Common.GetUnit<FatDirectoryArea>(fileName, ref aLogger, dataAreaStartLoc,
                       "[Child]DirectoryArea-" + parent.Description, bs);

                dataAreaStartLoc += Common.FatDirectoryAreaSizeBytes;
                if (directory.IsEmpty) break;

                if (directory.IsThisEntryaLongFileName())
                {
                    longNames.Add(directory);
                }
                else
                {
                    if (longNames.Count > 0)
                    {
                        directory.LongFileNames = longNames;
                        longNames = new List<FatDirectoryArea>();
                    }
                    parent.ChildrenList.Add(directory);
                }

                //if (directory.IsThisEntryaDirectory())
                //{
                //    ParseChildren(ref directory,  bs);
                //}
            }
        }
        private void FatTableBtn_Click(object sender, EventArgs e)
        {
            ParseBootSector();
            if (bootSectors.Count == 0)
            {
                aLogger.LogMessage($"{System.Reflection.MethodBase.GetCurrentMethod().Name.ToString()}:: Empty bootSectors list, operation terminated! ", LogMsgType.Error);
                return;
            }
            ParseRootDirectoryEntries();

            foreach (var directory in RootDirectoryEntries)
            {
                if (directory.IsThisEntryaDirectory())
                {
                    richTextBox1.AppendText("\n[DIRECTORY]\n");
                }
                else if (directory.IsThisEntryanArchive())
                {

                    if (directory.IsThisEntryADeletedArchive())
                    {
                        richTextBox1.AppendText("\n[DELETED FILE]\n");
                    }
                    else
                    {
                        richTextBox1.AppendText("\n[NORMAL FILE]\n");
                    }
                }

                //printing hex table
                HexPrinter aHexPrinter = new HexPrinter(ref richTextBox1, 32, directory.StartAddress, ref aLogger);
                aHexPrinter.PrintColoredStructure(directory);


                //printing values
                Helpers.Printer.PrintStructureValues(directory.Structure, ref richTextBox1, ref aLogger);




                aLogger.LogMessage($"DATA IS LOCATED @{directory.GetDataLocation().ToString("X8")}", LogMsgType.Debug);


                if (directory.LongFileNames?.Count > 0)
                {
                    richTextBox1.AppendText($"\n [START]******************** Printing long file name entries for the previous one ************ \n", Color.Red);
                    int counter = 1;
                    foreach (var longNameEntry in directory.LongFileNames)
                    {
                        richTextBox1.AppendText($"|---- Printing Long Name Entry [{counter}] \n");
                        //printing hex table
                        HexPrinter aHexPrinter2 = new HexPrinter(ref richTextBox1, 32, longNameEntry.StartAddress, ref aLogger);
                        aHexPrinter2.PrintColoredStructure(longNameEntry);

                        //printing values
                        Helpers.Printer.PrintStructureValues(longNameEntry.Structure, ref richTextBox1, ref aLogger);
                        richTextBox1.AppendText($"|---- [DONE] Printing Long Name Entry [{counter}] \n");
                        counter++;
                    }
                    richTextBox1.AppendText($"\n [END]******************** Printing long file name entries  ************ \n", Color.Red);
                }


                if (directory.ChildrenList?.Count > 0)
                {
                    richTextBox1.AppendText($"\n [START]******************** Printing subfolder entries ************ \n", Color.Violet);
                    int counter = 1;
                    foreach (var child in directory.ChildrenList)
                    {
                        richTextBox1.AppendText($"|---- Printing subfolder Entry [{counter}] \n");
                        //printing hex table
                        HexPrinter aHexPrinter2 = new HexPrinter(ref richTextBox1, 32, child.StartAddress, ref aLogger);
                        aHexPrinter2.PrintColoredStructure(child);

                        //printing values
                        Helpers.Printer.PrintStructureValues(child.Structure, ref richTextBox1, ref aLogger);

                        aLogger.LogMessage($"DATA IS LOCATED @{child.GetDataLocation().ToString("X8")}", LogMsgType.Debug);


                        richTextBox1.AppendText($"|---- [DONE] Printing subfolder Entry [{counter}] \n");
                        counter++;
                    }
                    richTextBox1.AppendText($"\n [END]******************** Printing long file name entries  ************ \n", Color.Violet);
                }
                richTextBox1.AppendText("\n\n\n");
            }
        }

        private void ParseBootSector()
        {
            if (anMbr == null)
            {
                aLogger.LogMessage("mbr is empty (maybe not loaded yet!), end function!", LogMsgType.Warning);
                return;
            }
            if (vbrsList == null)
            {
                aLogger.LogMessage("vbr list is empty, end function!", LogMsgType.Warning);
                return;
            }
            if (vbrsList.Count == 0)
            {
                aLogger.LogMessage("vbr list is empty, end function!", LogMsgType.Warning);
                return;
            }
            bootSectors = new List<BootSector>();
            foreach (var vbr in vbrsList)
            {
                var bs = Common.GetUnit<BootSector>(fileName, ref aLogger, vbr.BootSectorStartLocationByte(), $"Boot sector {vbr.Description}", null);
                if (!(vbr.IsEmptyPartition()))
                    bootSectors.Add(bs);
            }
        }

        private void FatValuesBtn_Click(object sender, EventArgs e)
        {

            if (bootSectors?.Count == 0)
            {
                aLogger.LogMessage($"{System.Reflection.MethodBase.GetCurrentMethod().Name.ToString()}:: Empty bootSectors list, operation terminated! ", LogMsgType.Error);
                return;
            }
            else
            {
                foreach (var rootDirectoryEntry in RootDirectoryEntries.Where(x => x.GetFileSize() > 0 && !x.IsThisEntryaDirectory()))
                {
                    AddEntryAndItsChildren(rootDirectoryEntry);
                }
            }

        }

        private void AddEntryAndItsChildren(FatDirectoryArea rootDirectoryEntry)
        {
            var tvn = treeView1.Nodes.Add(rootDirectoryEntry.StartAddress.ToString(), rootDirectoryEntry.GetEntryName());



            foreach (var child in rootDirectoryEntry.ChildrenList)
            {

                var newNode = tvn.Nodes.Add(child.StartAddress.ToString(), child.GetEntryName());

            }
        }

        private void fatTablesBtn_Click(object sender, EventArgs e)
        {
            if (bootSectors == null)
            {
                ParseBootSector();
            }



            int counter = 1;
            foreach (var bootSector in bootSectors)
            {
                richTextBox1.AppendText($"Printing FAT TABLEs for Boot Secort [{counter++}]\n\n");
                for (int i = 0; i < bootSector.GetNumberOfFats(); i++)
                {
                    /*
                    //BUG: ERROR FOR LARGE FAT32 IMAGES. @THANKS TO THE ANONYMOUS REVIEWER. 
                    //FIX: CHECK FOR THE FAT SIZE BEFORE, IF IT WAS BIGGER THAN A SPECIFIC
                    //THRESOLD, ASK TO EXPORT IT TO FILE. 
                    var maxAllowedFatSizeInBytes = 1024;
                    var startAddress = bootSector.GetFatTableStartByte(i);
                    if (bootSector.FatSizeInBytes() > maxAllowedFatSizeInBytes && false)
                    {
                        if (DialogResult.Yes == MessageBox.Show(
                                $"The FAT size #{i} is too big to be displayed, would you like to export to file?",
                                "Too big to display."
                                , MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                        )
                        {
                            SaveFileDialog adialog = new SaveFileDialog();
                            adialog.Filter = "Text File (*.txt)|*.txt";
                            adialog.DefaultExt = "txt";
                            adialog.AddExtension = true;
                            if (adialog.ShowDialog() == DialogResult.OK)
                            {
                                Common.ReadBytesFromImageAsHexAndSaveToFile(fileName,
                                    bootSector.GetFatTableStartByte(i),bootSector.FatSizeInBytes(),adialog.FileName,ref aLogger);
                                MessageBox.Show($"Done, check the file location! [{adialog.FileName}]");
                            }
                        }
                    }
                    else
                    {
                    */
                        FatTable aFatTable = new FatTable(fileName, bootSector, $"Fat Table {i}", i);
                        var numberOfBytesToDisplay = 512;

                        richTextBox1.AppendText($"Printing FAT TABLE{i}\n\n");
                        HexPrinter aHexPrinter = new HexPrinter(ref richTextBox1, 32, aFatTable.StartAddress, ref aLogger);
                        richTextBox1.AppendText($"\tFirst {numberOfBytesToDisplay} bytes of FAT table {i} \n",Color.Blue);
                        aHexPrinter.PrintValue(aFatTable.RawValue.Substring(0, numberOfBytesToDisplay*2), Color.White);
                        
                        richTextBox1.AppendText("\n");

                        aHexPrinter = new HexPrinter(ref richTextBox1, 32, aFatTable.StartAddress + (aFatTable.RawValue.Length / 2) - numberOfBytesToDisplay, ref aLogger);
                        richTextBox1.AppendText($"\n\tLast {numberOfBytesToDisplay} bytes of FAT table {i} \n",Color.Blue);
                        aHexPrinter.PrintValue(aFatTable.RawValue.Substring(aFatTable.RawValue.Length - (numberOfBytesToDisplay*2), numberOfBytesToDisplay*2), Color.White);

                        richTextBox1.SuspendLayout();
                        for (int index = 0; index < aFatTable.ParsedEntries.Count; index++)
                        {
                            var parsedEntry = aFatTable.ParsedEntries[index];
                            if (parsedEntry != "000000")
                            {
                                //richTextBox1.AppendText("\n"+parsedEntry);
                                //0 1 2 3 4 5 
                                //u v w x y z
                                // xuv & yzw
                                string fisrtEntry = parsedEntry[3].ToString() + parsedEntry[0].ToString() +
                                                    parsedEntry[1].ToString();

                                var firstEntryType = CehckFat12EntryValue(fisrtEntry);

                                string secondEntry = parsedEntry[4].ToString() + parsedEntry[5].ToString() +
                                                     parsedEntry[2].ToString();

                                var firstdatalocByte = aFatTable.ParentBootSector.FirstDataSectorByte() +
                                                        (index * 2) *
                                                        aFatTable.ParentBootSector.GetNumberOfSectorsPerCluser() *
                                                        aFatTable.ParentBootSector.BytesPerSector();
                                richTextBox1.AppendText(
                                    $"\n [{index}] {fisrtEntry}:\t {firstEntryType}  \t Data Loca={firstdatalocByte.ToString("X8")}");

                                var seconddatalocByte = aFatTable.ParentBootSector.FirstDataSectorByte() +
                                                        (index * 2 + 1) *
                                                        aFatTable.ParentBootSector.GetNumberOfSectorsPerCluser() *
                                                        aFatTable.ParentBootSector.BytesPerSector();
                                var secondEntryType = CehckFat12EntryValue(secondEntry);
                                richTextBox1.AppendText(
                                    $"\n [{index + 1}] {secondEntry}:\t {secondEntryType}  \t Data Loca={seconddatalocByte.ToString("X8")}");
                            }
                            else
                            {
                                richTextBox1.AppendText(
                                    $"\n reached last file (stopped to save space), two vals ={parsedEntry} ");
                                break;
                            }
                        }
                        richTextBox1.ResumeLayout();
                        richTextBox1.AppendText("\n\n");
                    }
               // }
            }
        }

        public enum Fat12EntryType : short
        {
            Empty = 0, //000
            ClusterInUseNextNum,//002-FEF: cluster in use; the value given is the number of the next cluster in the file,
            Reserved,// FF0-FF6: reserved,
            BadCluster,//FF7: bad cluster
            ClusterInUseLast,//FF8-FFF: cluster in use, the last one in this file.
            NotParsedCorrectly
        }
        public Fat12EntryType CehckFat12EntryValue(string entry3hexchars)
        {
            int val = int.Parse("0" + entry3hexchars, NumberStyles.HexNumber);
            if (val == 0)
                return Fat12EntryType.Empty;
            else if (val >= 002 && val <= 0xFEF)
                return Fat12EntryType.ClusterInUseNextNum;
            else if (val >= 0xFF0 && val <= 0xFF6)
                return Fat12EntryType.Reserved;
            else if (val == 0xff7)
                return Fat12EntryType.BadCluster;
            else if (val >= 0xff8 && val <= 0xfff)
                return Fat12EntryType.ClusterInUseLast;
            else
                return Fat12EntryType.NotParsedCorrectly;
        }

        private void DeletedFilesBtn_Click(object sender, EventArgs e)
        {
            if (!treeView1.SelectedNode.Text.Contains("DELETED"))
            {
                MessageBox.Show("Please try to resotre a deleted file instead.");
            }

            var startAddressInNode = int.Parse(treeView1.SelectedNode.Name);

            var entry = RootDirectoryEntries.Where(x => x.StartAddress == startAddressInNode).FirstOrDefault();

            var dataLocation = entry.GetDataLocation();
            var size = entry.GetFileSize();

            byte[] test = new byte[size];
            using (BinaryReader reader = new BinaryReader(new FileStream(fileName, FileMode.Open)))
            {
                reader.BaseStream.Seek(dataLocation, SeekOrigin.Begin);
                reader.Read(test, 0, size);
            }

            var saveFileDial = new SaveFileDialog();
            saveFileDial.FileName = entry.GetEntryName();
            if (saveFileDial.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(saveFileDial.FileName, test);
            }


        }


    }
}