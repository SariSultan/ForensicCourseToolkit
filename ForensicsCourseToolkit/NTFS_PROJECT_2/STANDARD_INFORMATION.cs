using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
　
namespace NTFSLearning
{
class STANDARD_INFORMATION
{
public int att_length = 72;
public byte[] att_data = new byte[72];
public byte[] creationtime = new byte[8];
public byte[] filealtertime = new byte[8];
public byte[] MFTaltertime = new byte[8];
public byte[] fileaccesstime = new byte[8];
public byte[] flags = new byte[4];
public byte[] maxnoversions = new byte[4];
public byte[] versionno = new byte[4];
public byte[] classid = new byte[4];
public byte[] ownerid = new byte[4];
public byte[] securityid = new byte[4];
public byte[] quotacharged = new byte[8];
public byte[] USN = new byte[8];
 Int64 creationtime_;
 Int64 filealtertime_;
 Int64 MFTaltertime_;
 Int64 fileaccesstime_;
public DateTime creationtimeValue;
public DateTime MFTaltertimeValue;
public DateTime filealtertimeValue;
public DateTime fileaccesstimeValue;
//public int flags_ ;
//public int maxnoversions_ ;
//public int versionno_;
//public int classid_;
//public int ownerid_;
//public int securityid_;
//public int quotacharged_;
//public int USN_;
public string flagstype ;

　
public STANDARD_INFORMATION(int attlength, byte[] attdata)
{
    CalculationUtilities calc = new CalculationUtilities();
int count;
////creationtime
count = 0;
for (int i = 0; count < 8; i++)
{
if (i < attlength)
{
creationtime[count] = attdata[i];
count++;
}
else
break;
}
creationtime_ = calc.LittleIndianBytesToInt64(creationtime, 8);
 creationtimeValue = DateTime.FromFileTime(creationtime_);
////filealtertime
count = 0;
for (int i = 8; count < 8; i++)
{
if (i < attlength)
{
filealtertime[count] = attdata[i];
count++;
}
else
break;
}
filealtertime_ = calc.LittleIndianBytesToInt64(filealtertime, 8);
filealtertimeValue = DateTime.FromFileTime(filealtertime_);
////MFTaltertime
count = 0;
for (int i = 16; count < 8; i++)
{
if (i < attlength)
{
MFTaltertime[count] = attdata[i];
count++;
}
else
break;
}
MFTaltertime_ =calc.LittleIndianBytesToInt64(MFTaltertime, 8);
 MFTaltertimeValue = DateTime.FromFileTime(MFTaltertime_);
////fileaccesstime
count = 0;
for (int i = 24; count < 8; i++)
{
if (i < attlength)
{
fileaccesstime[count] = attdata[i];
count++;
}
else
break;
}
fileaccesstime_ =calc.LittleIndianBytesToInt64(fileaccesstime, 8);
fileaccesstimeValue = DateTime.FromFileTime(fileaccesstime_);
　
////flags
count = 0;
for (int i = 35; count < 4; i--)
{
if (i < attlength)
{
flags[count] = attdata[i];
count++;
}
else
break;
}
////maxnoversions
count = 0;
for (int i = 39; count < 4; i--)
{
if (i < attlength)
{
maxnoversions[count] = attdata[i];
count++;
}
else
break;
}
////versionno
count = 0;
for (int i = 43; count < 4; i--)
{
if (i < attlength)
{
versionno[count] = attdata[i];
count++;
}
else
break;
}
////classid
count = 0;
for (int i = 47; count < 4; i--)
{
if (i < attlength)
{
classid[count] = attdata[i];
count++;
}
else
break;
}
////ownerid
count = 0;
for (int i = 51; count < 4; i--)
{
if (i < attlength)
{
ownerid[count] = attdata[i];
count++;
}
else
break;
}
////securityid
count = 0;
for (int i = 55; count < 4; i--)
{
if (i < attlength)
{
securityid[count] = attdata[i];
count++;
}
else
break;
}
////quotacharged
count = 0;
for (int i = 63; count < 8; i--)
{
if (i < attlength)
{
quotacharged[count] = attdata[i];
count++;
}
else
break;
}
////USN
count = 0;
for (int i = 71; count < 8; i--)
{
if (i < attlength)
{
quotacharged[count] = attdata[i];
count++;
}
else
break;
}
　
//flags_ = calculateValue(flags, 4);
//maxnoversions_ = calculateValue(maxnoversions, 4);
//versionno_ = calculateValue(versionno, 4);
//classid_ = calculateValue(classid, 4);
//ownerid_ = calculateValue(ownerid, 4);
//securityid_ = calculateValue(securityid, 4);
//quotacharged_ = calculateValue(quotacharged, 8);
//USN_ = calculateValue(USN, 8);
//flagstype = "";
　
　
//creationtime calculation
//long creationtime1 = creationtime_.ToFileTimeUtc();
　
//flags types
//if (flags_ == 1)
//{
// flagstype = "Read Only";
//}
//if (flags_ == 2)
//{
// flagstype = "Hidden";
//}
//if (flags_ == 4)
//{
// flagstype = "System";
//}
//if (flags_ == 32) // 0x20
//{
// flagstype = "Archive";
//}
//if (flags_ == 64) // 0x40
//{
// flagstype = "Device";
//}
//if (flags_ == 128) // 0x80
//{
// flagstype = "Normal";
//}
//if (flags_ == 256) // 0x100
//{
// flagstype = "Temporary";
//}
//if (flags_ == 512) // 0x200
//{
// flagstype = "Sparse file";
//}
//if (flags_ == 1024) // 0x400
//{
// flagstype = "Reparse file";
//}
//if (flags_ == 2048) // 0x800
//{
// flagstype = "Complressed";
//}
//if (flags_ == 4096) // 0x1000
//{
// flagstype = "Offline";
//}
//if (flags_ == 8192) // 0x2000
//{
// flagstype = "Content is not being indexed for faster searches";
//}
//if (flags_ == 16384) // 0x4000
//{
// flagstype = "Encrypted";
//}
　
//return creationtime_.ToString;
　
　
}
}
}

