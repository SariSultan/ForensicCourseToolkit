using System;
using System.Collections.Generic;
using ForensicsCourseToolkit.Framework_Project;

namespace ForensicsCourseToolkit.Quizez
{
    [Serializable]
    public class Exam
    {
        public Exam()
        {

        }
        public RequiredDetails RequiredStudentDetails { get; set; }
        public List<Question> QuestionsList { get; set; }
        public string ExamDescription { get; set; }
        public int ExamDuration { get; set; }

        public List<string> ExamLog { get; set; }

        public Exam(List<Question> questions, string instructorPassword, string examDescription, int examDurationsMins)
        {
            QuestionsList = questions;
            ExamDescription = examDescription;
            ExamDuration = examDurationsMins;

            try
            {
                foreach (var q in QuestionsList)
                {
                    q.Answer = Framework_Project.Crypto.AESGCM.SimpleEncryptWithPassword(q.Answer, instructorPassword);
                    q.AnswerExplanation = Framework_Project.Crypto.AESGCM.SimpleEncryptWithPassword(q.AnswerExplanation, instructorPassword);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("[Exception while encryption answers] + [inner] " + ex.ToString());
            }

            int qnCnt = 1;
            foreach (var q in questions)
            {
                q.QuestionNumber = qnCnt++;
            }
        }

        public string GetExamGrade(string instructorPassword)
        {
            double grade = 0;
            double maxGrade = 0;

            foreach (var q in QuestionsList)
            {
                maxGrade += q.Grades;
                grade += (q.StudentAnsweredCorrectly(instructorPassword)) ? q.Grades : 0;
            }
            return $"{grade}/{maxGrade}";
        }
    }
}