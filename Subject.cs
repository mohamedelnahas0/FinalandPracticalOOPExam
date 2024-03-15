using Final_and_Practical_Exam;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Final_and_Practical_Exam
{

    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam SubjectExam { get; set; }

        public Subject(int id, string name)
        {
            SubjectId = id;
            SubjectName = name;
        }

        public void CreateExam(Exam exam)
        {
            SubjectExam = exam;
        }
    }

}