using System;
using System.Windows.Forms;
using DeviceIOControlLib;
using ForensicsCourseToolkit.Framework_Project.Security;
using ForensicsCourseToolkit.Quizez;

namespace ForensicsCourseToolkit.Framework_Project
{
    [Serializable]
    public class RequiredDetails
    {
        public string StudentName { get; set; }
        public string StudentID { get; set; }
        public string ExamKey { get; set; }
        public string SharedKeyIS { get; set; }
        public string SequenceNumber { get; set; }
        public string VEncryptedWithKI { get; set; }

        public string TimeStamp { get; set; }

        public InstructorValidationData GetV(string instructorPassword)
        {
            try
            {
                return ExamHelper.GetVFromByteArray(VEncryptedWithKI, instructorPassword);
            }
            catch (Exception ex)
            {
                MessageBox.Show("IN GETV() ln 69");
                return null;
            }
        }




        public RequiredDetails()
        {

        }

        public RequiredDetails(string name, string ID, string examKey, string sharedKeyIS, DateTime timeStamp)
        {
            StudentName = name;
            StudentID = ID;
            ExamKey = examKey;
            Random aRandom = new Random();
            SequenceNumber = aRandom.Next().ToString();
            SharedKeyIS = sharedKeyIS;
            TimeStamp = TimeStampHelper.GetTimeStamp(timeStamp);
            EncryptDetails();
        }
        public RequiredDetails(string name, string ID, string examKey, string sharedKeyIS, int SN, DateTime timeStamp)
        {
            StudentName = name;
            StudentID = ID;
            ExamKey = examKey;
         
            SequenceNumber = SN.ToString();
            SharedKeyIS = sharedKeyIS;

            TimeStamp = TimeStampHelper.GetTimeStamp(timeStamp);

            EncryptDetails();
        }

        public void EncryptDetails()
        {
            StudentName = Crypto.AESGCM.SimpleEncryptWithPassword(StudentName, ExamKey);
            StudentID = Crypto.AESGCM.SimpleEncryptWithPassword(StudentID, ExamKey);
            SequenceNumber = Crypto.AESGCM.SimpleEncryptWithPassword(SequenceNumber, ExamKey);
            TimeStamp = Crypto.AESGCM.SimpleEncryptWithPassword(TimeStamp, ExamKey);
            if (SharedKeyIS != "" && SharedKeyIS != null)
            {
                SharedKeyIS = Crypto.AESGCM.SimpleEncryptWithPassword(SharedKeyIS, SharedKeyIS);
            }
            ExamKey = Crypto.AESGCM.SimpleEncryptWithPassword(ExamKey, ExamKey);
        }

        public void DecryptDetails(string examKey)
        {
            StudentName = Crypto.AESGCM.SimpleDecryptWithPassword(StudentName, examKey);
            StudentID = Crypto.AESGCM.SimpleDecryptWithPassword(StudentID, examKey);
            SequenceNumber = Crypto.AESGCM.SimpleDecryptWithPassword(SequenceNumber, examKey);
            TimeStamp = Crypto.AESGCM.SimpleDecryptWithPassword(TimeStamp, examKey);
            ExamKey = Crypto.AESGCM.SimpleDecryptWithPassword(ExamKey, examKey);


        }
        public void DecryptSharedKey(string sharedKeyIS)
        {
            if (SharedKeyIS != "" && sharedKeyIS != "" && SharedKeyIS != null && sharedKeyIS != null)
            {
                SharedKeyIS = Crypto.AESGCM.SimpleDecryptWithPassword(SharedKeyIS, sharedKeyIS);
            }
        }

    }
}