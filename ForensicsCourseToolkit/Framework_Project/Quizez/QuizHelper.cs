using ForensicsCourseToolkit.Framework_Project;
using ForensicsCourseToolkit.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using static ForensicsCourseToolkit.Quizez.QuizHelper;

namespace ForensicsCourseToolkit.Quizez
{
    public static class QuizHelper
    {
        public static int questionNumber = 1;
        private static bool addAnswers = true;
        private static bool addAssets = true;

        private static List<Question> FinalQuestions;

        public static void SetAddAnswers(bool value)
        {
            addAnswers = value;
        }
        public static void SetAddAssets(bool value)
        {
            addAssets = value;
        }
        public static void AddQuestionsToFlowLayout(List<QuestionForms> questionsList, ref FlowLayoutPanel flowLayout, ref RichTextBox rtb, ref Logger aLogger, ref List<Question> finalQuestions)
        {
            FinalQuestions = finalQuestions;
            RichTextBox aRtb = rtb;
            //int aquestionCounter = questionCounte;r
            foreach (var forms in questionsList)
            {
                Label generalDescriptionLabel = new Label();
                generalDescriptionLabel.Text = forms.questions[0].Description;
                generalDescriptionLabel.Font = new Font("Courier New", 14, FontStyle.Bold);
                generalDescriptionLabel.AutoSize = true;

                flowLayout.Controls.Add(generalDescriptionLabel);
                flowLayout.SetFlowBreak(generalDescriptionLabel, true);
                foreach (var question in forms.questions)
                {
                    Button question1Btn = new Button();
                    question1Btn.Tag = question;
                    question1Btn.AutoSize = true;
                    question1Btn.Text = "<- Add";
                    question1Btn.Click += (s, ee) =>
                    {
                        QuizHelper.AddQuestionTortb(ref aRtb, questionNumber++, (Question)((Button)s).Tag, addAssets, addAnswers);
                        FinalQuestions.Add((Question)((Button)s).Tag);

                    };
                    Label question1Lbl = new Label();
                    question1Lbl.Text = question.ToString();
                    question1Lbl.AutoSize = true;
                    Label question1Answer = new Label();
                    question1Answer.Text = question.Answer;
                    question1Answer.BackColor = Color.Green;
                    question1Answer.AutoSize = true;


                    flowLayout.Controls.Add(question1Btn);

                    flowLayout.Controls.Add(question1Lbl);

                    flowLayout.Controls.Add(question1Answer);
                    flowLayout.SetFlowBreak(question1Answer, true);
                }

            }
        }

        //public delegate string AnswerFunction( );
        //public delegate string QuestionAsset();
        public static char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K' };
        public enum InputValueType : int
        {
            Integer = 1,
            Double,
            HexVlaue,
            String,
        }

        public enum QuestionDifficulty : int
        {
            Easy = 1,
            Medium,
            Hard,
        }


        public static void AddQuestionTortb(ref RichTextBox rtb, int counter, Question aQuestion, bool addsrcMaterial = false, bool addAnswer = false)
        {
            int padright = 30;
            // 
            rtb.AppendText(System.Environment.NewLine);
            rtb.AppendText($"Question. {counter} [{aQuestion.Grades} " + ((aQuestion.Grades == 1) ? "Point" : "Points") + $"]:", new System.Drawing.Font("Courier New", 16, System.Drawing.FontStyle.Bold));
            rtb.AppendText(System.Environment.NewLine);
            if (addsrcMaterial)
            {
                rtb.AppendText(aQuestion.Asset, new System.Drawing.Font("Courier New", 8));
                rtb.AppendText(System.Environment.NewLine);
            }
            rtb.AppendText(aQuestion.ToString(), new System.Drawing.Font("Courier New", 12, FontStyle.Bold));
            rtb.AppendText(System.Environment.NewLine);

            rtb.AppendText($"{aQuestion.QuestionAltenativesDescription}".PadRight(padright));


            if (addAnswer)
            {
                rtb.AppendText(System.Environment.NewLine);
                rtb.AppendText($"[Answer:] {aQuestion.Answer} [Explanation:] {aQuestion.AnswerExplanation}", System.Drawing.Color.Green);
            }

            rtb.AppendText(System.Environment.NewLine);
        }

        public static void AddGradedQuestionToRtb(ref RichTextBox rtb, int counter, Question aQuestion,string instructorPassword, bool addAnswer = true, bool addExplanation=true)
        {
            bool correctAnswer = false;
            int padright = 30;
            // 
            rtb.AppendText(System.Environment.NewLine);
            rtb.AppendText($"Question. {counter} [{aQuestion.Grades} " + ((aQuestion.Grades == 1) ? "Point" : "Points") + $"]:", new System.Drawing.Font("Courier New", 16, System.Drawing.FontStyle.Bold));
            if (aQuestion.StudentAnsweredCorrectly(instructorPassword))
            {
                correctAnswer = true;
                rtb.AppendText($"(Correct)", new System.Drawing.Font("Courier New", 16, System.Drawing.FontStyle.Bold), Color.Green);
            }
            else
            {
                rtb.AppendText($"(Wrong)", new System.Drawing.Font("Courier New", 16, System.Drawing.FontStyle.Bold), Color.Red);
            }
            rtb.AppendText(System.Environment.NewLine);

            rtb.AppendText(aQuestion.ToString(), new System.Drawing.Font("Courier New", 12, FontStyle.Bold));
            rtb.AppendText(System.Environment.NewLine);

            rtb.AppendText($"{aQuestion.QuestionAltenativesDescription}".PadRight(padright));

            
            var cA = Framework_Project.Crypto.AESGCM.SimpleDecryptWithPassword(aQuestion.Answer, instructorPassword);
            var studentAns = "";
            if (aQuestion.GetType() == typeof(TrueFalseQuestion))
            {
                int option = ((TrueFalseQuestion)aQuestion).RandomChoice;
                
                var correctAnsTrueFalse = (aQuestion.Choices[option] != cA).ToString();

                studentAns = (aQuestion.StudentAnswer == correctAnsTrueFalse).ToString();
                rtb.AppendText(System.Environment.NewLine);
                rtb.AppendText($"[Student Answer:] {studentAns} ", new System.Drawing.Font("Courier New", 12, FontStyle.Bold), (correctAnswer ? Color.Green : Color.Red));
            }
            else
            {
                rtb.AppendText(System.Environment.NewLine);
                rtb.AppendText($"[Student Answer:] {aQuestion.StudentAnswer} ", new System.Drawing.Font("Courier New", 12, FontStyle.Bold), (correctAnswer ? Color.Green : Color.Red));
            }
           

            if (addAnswer && !correctAnswer)
            {
                rtb.AppendText(System.Environment.NewLine);
                rtb.AppendText($"[Correct Answer:] {Framework_Project.Crypto.AESGCM.SimpleDecryptWithPassword(aQuestion.Answer,instructorPassword)} ", System.Drawing.Color.Green);


            }
            if (addExplanation && !correctAnswer)
            {
                rtb.AppendText(System.Environment.NewLine);
                rtb.AppendText($"[Explanation:] {Framework_Project.Crypto.AESGCM.SimpleDecryptWithPassword(aQuestion.AnswerExplanation, instructorPassword)}", Color.Green);
            }


            rtb.AppendText(System.Environment.NewLine);
        }
    }
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

    [Serializable]
    public class QuestionForms
    {
        public QuestionForms()
        {

        }
        public List<Question> questions { get; set; }
        private TrueFalseQuestion aTrueFalseQuestion { get; set; }
        private MultipleChoiceQuestion aMultipleChoiceQuestion { get; set; }
        private ValueInputQuestion aValueInputQuestion { get; set; }
        public QuestionForms(Question aQuestion, InputValueType inputvaluetype)
        {
            aTrueFalseQuestion = new TrueFalseQuestion(aQuestion.Description, aQuestion.Asset, aQuestion.Answer, aQuestion.AnswerExplanation, aQuestion.Choices, aQuestion.Grades, aQuestion.Difficulty);
            aMultipleChoiceQuestion = new MultipleChoiceQuestion(aQuestion.Description, aQuestion.Asset, aQuestion.Answer, aQuestion.AnswerExplanation, aQuestion.Choices, aQuestion.Grades, aQuestion.Difficulty);
            aValueInputQuestion = new ValueInputQuestion(aQuestion.Description, aQuestion.Asset, aQuestion.Answer, aQuestion.AnswerExplanation, aQuestion.Choices, aQuestion.Grades, aQuestion.Difficulty, inputvaluetype);


            questions = new List<Question>()
            {
                aTrueFalseQuestion,
                aMultipleChoiceQuestion,
                aValueInputQuestion,
            };
        }
    }

    [Serializable]
    [XmlInclude(typeof(MultipleChoiceQuestion))]
    [XmlInclude(typeof(TrueFalseQuestion))]
    [XmlInclude(typeof(ValueInputQuestion))]
    public class Question
    {
        public int QuestionNumber { get; set; }
        public Question()
        {

        }
        public string QuestionAltenativesDescription { get; set; }
        //-------------------
        public string Description { get; set; }
        public string Asset { get; set; }
        public string Answer { get; set; }
        public string AnswerExplanation { get; set; }
        public List<string> Choices { get; set; }
        public double Grades { get; set; }
        public QuestionDifficulty Difficulty { get; set; }

        public string StudentAnswer { get; set; }

        public virtual bool StudentAnsweredCorrectly(string intructorPassword)
        {
            var correctAnswer = Framework_Project.Crypto.AESGCM.SimpleDecryptWithPassword(Answer, intructorPassword);
            if (this.GetType() == typeof(TrueFalseQuestion))
            {
                int option = ((TrueFalseQuestion)this).RandomChoice;
                if (Choices[option] == correctAnswer)
                    return (StudentAnswer == true.ToString());
                else
                    return (StudentAnswer == false.ToString());
            }
            // else if (this.GetType() == typeof(MultipleChoiceQuestion))
            {
                return correctAnswer == StudentAnswer;
            }

        }
        public Question(string questionDescription, string questionAsset, string correctAnswer, string answerDescription,
            List<string> questionchoices, double questionGrade, QuestionDifficulty questionDifficulty
            )
        {
            Description = questionDescription;
            Asset = questionAsset;
            Answer = correctAnswer;
            AnswerExplanation = answerDescription;
            Choices = questionchoices;
            Choices.Shuffle();
            Grades = questionGrade;
            Difficulty = questionDifficulty;

            if (questionchoices.Count <= 1)
            {
                throw new Exception($"[EXCEPTION] Number of choices for this questions i <=1, you need to provide more choices.");
            }
        }


        public override string ToString()
        {
            return $"{Description}";
        }
    }

    [Serializable]
    public class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion()
        {

        }
        public int RandomChoice { get; set; }

        public TrueFalseQuestion(string questionDescription, string questionAsset, string correctAnswer, string answerDescription,
          List<string> questionchoices, double questionGrade, QuestionDifficulty questionDifficulty
          ) : base(questionDescription, questionAsset, correctAnswer, answerDescription, questionchoices, questionGrade, questionDifficulty)
        {
            Random rnd = new Random();
            RandomChoice = rnd.Next(Choices.Count);
            QuestionAltenativesDescription = $"A. True\t\t B. False";
        }


        public override string ToString()
        {
            return $"[True/False]: {base.ToString()} is {Choices[RandomChoice]} ?";
        }
    }
    [Serializable]
    public class MultipleChoiceQuestion : Question
    {
        public MultipleChoiceQuestion()
        {

        }
        private int RandomChoice { get; set; }
        public MultipleChoiceQuestion(string questionDescription, string questionAsset, string correctAnswer, string answerDescription,
                 List<string> questionchoices, double questionGrade, QuestionDifficulty questionDifficulty
                 ) : base(questionDescription, questionAsset, correctAnswer, answerDescription, questionchoices, questionGrade, questionDifficulty)
        {
            Random rnd = new Random();
            RandomChoice = rnd.Next(Choices.Count);

            for (int i = 0; i < Choices.Count; i++)
            {
                QuestionAltenativesDescription = $"{QuestionAltenativesDescription} {letters[i]}. {Choices[i]} \t";
            }

        }

        public override string ToString()
        {
            return $"[Multiple Choice]: {base.ToString()}?";
        }
    }
    [Serializable]
    public class ValueInputQuestion : Question
    {
        public ValueInputQuestion()
        {

        }
        private InputValueType InputType { get; set; }
        public ValueInputQuestion(string questionDescription, string questionAsset, string correctAnswer, string answerDescription,
                 List<string> questionchoices, double questionGrade, QuestionDifficulty questionDifficulty, InputValueType inputtype
                 ) : base(questionDescription, questionAsset, correctAnswer, answerDescription, questionchoices, questionGrade, questionDifficulty)
        {
            InputType = inputtype;

            QuestionAltenativesDescription += $"_____________";
        }

        public override string ToString()
        {
            return $"[Input Value]: {base.ToString()}?";
        }
    }
}
