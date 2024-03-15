using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Final_and_Practical_Exam
{
    public class Answer
    {
        public int AnswerId { get; }
        public string AnswerText { get; }

        public Answer(int optionId, string optionText)
        {
            AnswerId = optionId;
            AnswerText = optionText;
        }
    }

}