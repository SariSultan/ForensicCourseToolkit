﻿using System;

namespace ForensicsCourseToolkit.Quizez
{
    public class InvalidStudentPasswordException : Exception
    {
        public InvalidStudentPasswordException()
        {
        }

        public InvalidStudentPasswordException(string message)
            : base(message)
        {
        }

        public InvalidStudentPasswordException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}