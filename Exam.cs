using System;
using System.Collections.Generic;
using static Question;

namespace Final_and_Practical_Exam
{

    public abstract class Exam
    {
        protected List<Question> Questions { get; set; }
        public DateTime TimeOfExam { get; set; }
        public int NumberOfQuestions { get; set; }
        public Subject AssociatedSubject { get; set; }

        public Exam()
        {
            Questions = new List<Question>();
        }

        protected abstract void AddSomeQuestions();

        public void AddQuestions()
        {
            Console.WriteLine("Enter the questions and answers for the exam. Enter 'done' to finish.");
            while (true)
            {
                AddSomeQuestions();
                Console.Write("Add another question? (yes/no): ");
                string choice = Console.ReadLine();
                if (choice.ToLower() == "no")
                    break;
            }
        }

        public virtual void TakeTest()
        {
            Console.WriteLine("Taking the exam...");
        }
    }

    public class FinalExam : Exam
    {
        public int Grade { get; private set; }

        public FinalExam()
        {
        }

        protected override void AddSomeQuestions()
        {
            Console.WriteLine("Enter the question type (MCQ/TrueFalse): ");
            string type = Console.ReadLine();

            if (type.Equals("MCQ", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Enter the MCQ question: ");
                string question = Console.ReadLine();

                Console.Write("Enter the correct option ID: ");
                int correctOptionId = int.Parse(Console.ReadLine());

                List<Answer> options = new List<Answer>();
                for (int i = 1; i <= 4; i++)
                {
                    Console.Write($"Enter option ID {i}: ");
                    int optionId = int.Parse(Console.ReadLine());
                    Console.Write($"Enter option text: ");
                    string optionText = Console.ReadLine();
                    options.Add(new Answer(optionId, optionText));
                }

                Questions.Add(new MultipleChoiceQuestion(question, "", 1, options, new Answer(correctOptionId, "")));
            }
            else if (type.Equals("TrueFalse", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Enter the True/False question: ");
                string question = Console.ReadLine();

                Console.Write("Enter the correct answer (True/False): ");
                string correctAnswerText = Console.ReadLine();

                Questions.Add(new TrueFalseQuestion(question, "", 1, new List<Answer>(), new Answer(1, correctAnswerText)));
            }
            else
            {
                Console.WriteLine("Invalid question type.");
            }
        }

        public override void TakeTest()
        {
            Console.WriteLine("Final Exam:");

            int totalQuestions = Questions.Count;
            int correctAnswers = 0;

            foreach (var question in Questions)
            {
                Console.WriteLine(question.Body);
                question.DisplayAnswers();
                Console.Write("Your answer: ");
                string userAnswer = Console.ReadLine();

                if (question.IsCorrectAnswer(userAnswer))
                {
                    correctAnswers++;
                }
            }

            double percentage = ((double)correctAnswers / totalQuestions) * 100;
            Console.WriteLine($"\nYour grade: {percentage}%");
        }
    }

    public class PracticalExam : Exam
    {
        public PracticalExam()
        {
        }

        protected override void AddSomeQuestions()
        {
            Console.Write("Enter the MCQ question: ");
            string question = Console.ReadLine();

            Console.Write("Enter the correct option ID: ");
            int correctOptionId = int.Parse(Console.ReadLine());

            List<Answer> options = new List<Answer>();
            for (int i = 1; i <= 4; i++)
            {
                Console.Write($"Enter option ID {i}: ");
                int optionId = int.Parse(Console.ReadLine());
                Console.Write($"Enter option text: ");
                string optionText = Console.ReadLine();
                options.Add(new Answer(optionId, optionText));
            }

            Questions.Add(new MultipleChoiceQuestion(question, "", 1, options, new Answer(correctOptionId, "")));
        }

        public override void TakeTest()
        {
            Console.WriteLine("Practical Exam:");

            int totalQuestions = Questions.Count;
            int correctAnswers = 0;

            foreach (var question in Questions)
            {
                Console.WriteLine(question.Body);
                question.DisplayAnswers();
                Console.Write("Your answer: ");
                string userAnswer = Console.ReadLine();

                if (question.IsCorrectAnswer(userAnswer))
                {
                    correctAnswers++;
                }
            }

            double percentage = ((double)correctAnswers / totalQuestions) * 100;
            Console.WriteLine($"\nYour grade: {percentage}%");
        }
    }
}