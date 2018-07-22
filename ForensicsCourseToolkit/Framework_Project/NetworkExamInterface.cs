using ForensicsCourseToolkit.Framework_Project.Security;
using ForensicsCourseToolkit.Helpers;
using ForensicsCourseToolkit.Quizez;
using Hik.Communication.Scs.Communication.EndPoints;
using Hik.Communication.ScsServices.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForensicsCourseToolkit.Framework_Project
{
    [Serializable]
    public class ExamStatusUpdate
    {
        public ExamStatusUpdate()
        {

        }

        public ExamStatusUpdate(RequiredDetails details)
        {
            Details = details;
            sent = false;
            submitted = false;
        }
        public RequiredDetails Details { get; set; }
        public bool sent { get; set; }
        public string weSentHimExamDateAndDetails { get; set; }
        public string submittedExamDateandDetails { get; set; }
        public bool submitted { get; set; }
        public string ExamSubmission { get; set; }


        public void UpdateSendInfo(string sendInfo)
        {
            sent = true;
            weSentHimExamDateAndDetails = sendInfo;
        }

        public void UpdateSubmitInfo(string examSubmission, string submissionInfo)
        {
            submitted = true;
            ExamSubmission = examSubmission;
            submittedExamDateandDetails = submissionInfo;
        }
    }

    [Serializable]
    public class RequiredDetails
    {
        public string StudentName { get; set; }
        public string StudentID { get; set; }
        public string ExamKey { get; set; }
        public string SharedKeyIS { get; set; }
        public string SequenceNumber { get; set; }
        public string VEncryptedWithKI { get; set; }


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

        public RequiredDetails(string name, string ID, string examKey, string sharedKeyIS)
        {
            StudentName = name;
            StudentID = ID;
            ExamKey = examKey;
            Random aRandom = new Random();
            SequenceNumber = aRandom.Next().ToString();
            SharedKeyIS = sharedKeyIS;
            EncryptDetails();
        }
        public RequiredDetails(string name, string ID, string examKey, string sharedKeyIS, int SN)
        {
            StudentName = name;
            StudentID = ID;
            ExamKey = examKey;
         
            SequenceNumber = SN.ToString();
            SharedKeyIS = sharedKeyIS;
            EncryptDetails();
        }

        public void EncryptDetails()
        {
            StudentName = Crypto.AESGCM.SimpleEncryptWithPassword(StudentName, ExamKey);
            StudentID = Crypto.AESGCM.SimpleEncryptWithPassword(StudentID, ExamKey);
            SequenceNumber = Crypto.AESGCM.SimpleEncryptWithPassword(SequenceNumber, ExamKey);
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

    public delegate void UpdateStatusDelegate(List<ExamStatusUpdate> list);

    [ScsService(Version = "1.0.0.0")]
    public interface INetworkExamService
    {
        string GetExamCopyEncryptedZipped(RequiredDetails details);

        bool SubmitExamEncryptedZipped(string anExamSubmission, RequiredDetails details);
    }

    [ScsService(Version = "1.0.0.0")]
    public interface INetworkExamServiceTesting
    {
        string GetExamCopyEncryptedZipped(RequiredDetails details, int numberOfQuestions, int numberOfStds);

        bool SubmitExamEncryptedZipped(string anExamSubmission, RequiredDetails details, int numberofQuestions, int numberOfStds);
    }

    public class NetworkExamService : ScsService, INetworkExamService
    {
        //----------------------------VARS
        private ExaminationStudentsFilter Firewall;
        public SortedList<string, string> submittedFiles;
        public List<ExamStatusUpdate> ExamSubmissionZippedStringList { get; set; }
        private UpdateStatusDelegate UpdateMethod { get; set; }
        private Exam OriginalExamWithNoStdDetails { get; set; }
        private string ExamKey { get; set; }
        //private string InstructorPassword { get; set; }
        public Logger aLogger { get; set; }


        //-------------------------------CTOR
        public NetworkExamService(Exam examEmptyCopy, string examKey,
           ref Logger logger, UpdateStatusDelegate method, ExaminationStudentsFilter firewall)
        {
            OriginalExamWithNoStdDetails = examEmptyCopy;

            ExamKey = examKey;

            ExamSubmissionZippedStringList = new List<ExamStatusUpdate>();

            aLogger = logger;
            UpdateMethod = method;

            submittedFiles = new SortedList<string, string>();

            Firewall = firewall;
        }


        //------------------------ NETWORK INTERFACE METHODS

        private string GetIP()
        {
            var ip = CurrentClient.RemoteEndPoint.ToString();
            ip = ip.Replace("tcp://", "");
            ip = ip.Substring(0, ip.IndexOf(':'));
            return ip;
        }
        public string GetExamCopyEncryptedZipped(RequiredDetails details)
        {
            try
            {

                var ret = Firewall.GenerateExamCopyForSendingToStudent(OriginalExamWithNoStdDetails, details, GetIP());

                if (ret.Decision != FilterationResult.Accepted)
                {
                    aLogger.LogMessage($"Invalid Student Is Asking for Copy from [IP:] {this.CurrentClient.RemoteEndPoint} [ClientID:] {CurrentClient.ClientId} | CONNECTION WILL BE DROPPED. [Reason:] {ret.Decision.ToString()} ", LogMsgType.Verbose);
                    this.CurrentClient.Disconnect();

                    return null;
                }
                else
                {

                    var s = ExamSubmissionZippedStringList.
                        Where(x => x.Details.StudentID == details.StudentID).FirstOrDefault();
                    if (s == null)
                    {
                        lock (ExamSubmissionZippedStringList)
                        {
                            ExamSubmissionZippedStringList.Add(s = new ExamStatusUpdate(details));
                        }
                    }
                    lock (s)
                    {
                        s.UpdateSendInfo($"[{DateTime.Now}]a copy of the exam sent to [IP:] {this.CurrentClient.RemoteEndPoint} [StudentName:] {details.StudentName}, [ID:] {details.StudentID}");
                    }
                    aLogger.LogMessage($"a copy of the exam sent to [IP:] {this.CurrentClient.RemoteEndPoint} [StudentName:] {details.StudentName}, [ID:] {details.StudentID}", LogMsgType.Verbose);

                    UpdateMethod(ExamSubmissionZippedStringList);


                    return ret.ExamToSendForStudent; // this should include now V updated details
                }
            }
            catch (Exception ex)
            {
                aLogger.LogMessage(ex.Message + $"Used Details Are: StdID=[{details.StudentID}], SrcIP=[{CurrentClient.RemoteEndPoint}], ExamKey=[{details.ExamKey}], SharedKey=[{details.SharedKeyIS}]", LogMsgType.Warning);
                return null;
            }

        }
        public bool SubmitExamEncryptedZipped(string anExamSubmission, RequiredDetails details)
        {
          

            var ret = Firewall.IsValidSubmission(details, GetIP());

            if (ret != FilterationResult.Accepted)
            {
                aLogger.LogMessage($"Invalid Student Is Trying To Submit from [IP:] {this.CurrentClient.RemoteEndPoint} [ClientID:] {CurrentClient.ClientId} | CONNECTION WILL BE DROPPED. ", LogMsgType.Verbose);
                this.CurrentClient.Disconnect();
                return false;
            }


            var s = ExamSubmissionZippedStringList.
                Where(x => x.Details.StudentID
                 == details.StudentID).FirstOrDefault();
            if (s == null)
            {
                ExamSubmissionZippedStringList.Add(s = new ExamStatusUpdate(details));
            }
            s.UpdateSubmitInfo(anExamSubmission, $"[{DateTime.Now}]a copy of the exam sent to [IP:] {this.CurrentClient.RemoteEndPoint} [StudentName:] {details.StudentName}, [ID:] {details.StudentID}");


            try
            {
                submittedFiles.Add(details.StudentID, anExamSubmission);
                aLogger.LogMessage($"Exam Was Submitted By [StudentName:] {details.StudentName}, [ID:] {details.StudentID}", LogMsgType.Verbose);
            }
            catch (Exception ex)
            {
                aLogger.LogMessage($"STUDENT TRYING TO SUBMIT TWICE (EXAM DROPPED) [StudentName:] {details.StudentName}, [ID:] {details.StudentID}", LogMsgType.Error);
            }
            UpdateMethod(ExamSubmissionZippedStringList);
            return true;
        }

    }
    public class NetworkExamServicePerformanceTesting : ScsService, INetworkExamServiceTesting
    {
        //----------------------------VARS
        private SortedList<int, ExaminationStudentsFilter> Firewalls;
        public SortedList<string, string> submittedFiles;
        public List<ExamStatusUpdate> ExamSubmissionZippedStringList { get; set; }
        private UpdateStatusDelegate UpdateMethod { get; set; }
        private SortedList<int, Exam> OriginalExamWithNoStdDetails { get; set; }
        private string ExamKey { get; set; }
        //private string InstructorPassword { get; set; }
        //public Logger aLogger { get; set; }


        //-------------------------------CTOR
        public NetworkExamServicePerformanceTesting(SortedList<int, Exam> examEmptyCopies, string examKey,
            UpdateStatusDelegate method, SortedList<int, ExaminationStudentsFilter> firewalls)
        {
            OriginalExamWithNoStdDetails = examEmptyCopies;

            ExamKey = examKey;

            ExamSubmissionZippedStringList = new List<ExamStatusUpdate>();

            //   aLogger = logger;
            UpdateMethod = method;

            submittedFiles = new SortedList<string, string>();

            Firewalls = firewalls;
        }


        //------------------------ NETWORK INTERFACE METHODS

        private string GetIP()
        {
            var ip = CurrentClient.RemoteEndPoint.ToString();
            ip = ip.Replace("tcp://", "");
            ip = ip.Substring(0, ip.IndexOf(':'));
            return ip;
        }
        public string GetExamCopyEncryptedZipped(RequiredDetails details, int numberOfQuestions, int numberOfStds)
        {
            try
            {
                var ret = Firewalls[numberOfStds].GenerateExamCopyForSendingToStudent(OriginalExamWithNoStdDetails[numberOfQuestions], details, GetIP());

                if (ret.Decision != FilterationResult.Accepted)
                {

                    //  aLogger.LogMessage($"Invalid Student Is Asking for Copy from [IP:] {this.CurrentClient.RemoteEndPoint} [ClientID:] {CurrentClient.ClientId} | CONNECTION WILL BE DROPPED. [Reason:] {ret.Decision.ToString()} ", LogMsgType.Verbose);
                 //   this.CurrentClient.Disconnect();

                    return null;
                }
                else
                {
                    return ret.ExamToSendForStudent; // this should include now V updated details
                }
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
                //  aLogger.LogMessage(ex.Message + $"Used Details Are: StdID=[{details.StudentID}], SrcIP=[{CurrentClient.RemoteEndPoint}], ExamKey=[{details.ExamKey}], SharedKey=[{details.SharedKeyIS}]", LogMsgType.Warning);


            }

        }
        public bool SubmitExamEncryptedZipped(string anExamSubmission, RequiredDetails details, int numberofQuestions, int numberOfStudents)
        {
       

            var ret = Firewalls[numberOfStudents].IsValidSubmission(details, GetIP());

            if (ret != FilterationResult.Accepted)
            {
                //    aLogger.LogMessage($"Invalid Student Is Trying To Submit from [IP:] {this.CurrentClient.RemoteEndPoint} [ClientID:] {CurrentClient.ClientId} | CONNECTION WILL BE DROPPED. ", LogMsgType.Verbose);
               // this.CurrentClient.Disconnect();
                return false;
            }




            //var s = ExamSubmissionZippedStringList.
            //    Where(x => x.Details.StudentID
            //     == details.StudentID).FirstOrDefault();
            //if (s == null)
            // {
            //    ExamSubmissionZippedStringList.Add(s = new ExamStatusUpdate(details));
            // }
            // s.UpdateSubmitInfo(anExamSubmission, $"[{DateTime.Now}]a copy of the exam sent to [IP:] {this.CurrentClient.RemoteEndPoint} [StudentName:] {details.StudentName}, [ID:] {details.StudentID}");


            //   try
            //   {
            //       submittedFiles.Add(details.StudentID, anExamSubmission);
            //  aLogger.LogMessage($"Exam Was Submitted By [StudentName:] {details.StudentName}, [ID:] {details.StudentID}", LogMsgType.Verbose);
            //     }
            //    catch (Exception ex)
            //     {
            //  aLogger.LogMessage($"STUDENT TRYING TO SUBMIT TWICE (EXAM DROPPED) [StudentName:] {details.StudentName}, [ID:] {details.StudentID}", LogMsgType.Error);
            //    }
            //UpdateMethod(ExamSubmissionZippedStringList);
            return true;
        }

    }

}
