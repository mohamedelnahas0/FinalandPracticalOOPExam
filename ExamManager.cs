using Final_and_Practical_Exam;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Final_and_Practical_Exam
{
    public static class ExamManager
    {
        public static void StartExam()
        {

            Console.Write("Enter Subject number: ");
            int subjectId = int.Parse(Console.ReadLine());

            Console.Write("Enter Subject Name: ");
            string subjectName = Console.ReadLine();

            Console.Write("Enter date of your Exam: ");
            DateTime timeOfExam = DateTime.Parse(Console.ReadLine());

            Subject subject = new Subject(subjectId, subjectName);


            Console.WriteLine("Choose the type of exam:");
            Console.WriteLine("1. Final Exam");
            Console.WriteLine("2. Practical Exam");

            Console.Write("Enter your choice (1 or 2): ");
            string choice = Console.ReadLine();

            Exam exam;

            switch (choice)
            {
                case "1":
                    exam = new FinalExam();
                    break;
                case "2":
                    exam = new PracticalExam();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Exiting...");
                    return;
            }


            subject.CreateExam(exam);


            if (exam is FinalExam finalExam)
            {
                finalExam.TimeOfExam = timeOfExam;
            }
            else if (exam is PracticalExam practicalExam)
            {
                practicalExam.TimeOfExam = timeOfExam;
            }


            exam.AddQuestions();


            exam.TakeTest();
        }
    }
}