using System;

namespace ForensicsCourseToolkit.Quizez
{
    public class InvalidInstructorPasswordException : Exception
    {
        public InvalidInstructorPasswordException()
        {
        }

        public InvalidInstructorPasswordException(string message)
            : base(message)
        {
        }

        public InvalidInstructorPasswordException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}