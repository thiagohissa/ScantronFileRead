using System;
// Student Name: Thiago Maciel Hissa // Student ID: 101176085
namespace Assignment
{
    public class Student
    {
        private string id;
        private string answers;
        private int grade;

        public Student(string id, string answers)
        {
            this.id = id;
            this.answers = answers;
            this.grade = 0;
        }


        // Setters
        public void setId(string id)
        {
            this.id = id;
        }

        public void setAnswers(string answers)
        {
            this.answers = answers;
        }

        public void setGrade(int grade)
        {
            this.grade = grade;
        }

        // Getters
        public string getId()
        {
            return this.id;
        }

        public string getAnswers()
        {
            return this.answers;
        }

        public int getGrade()
        {
            return this.grade;
        }
    }
}
