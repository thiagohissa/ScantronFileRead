using System;
using System.Collections.Generic;
using System.IO;

// Student Name: Thiago Maciel Hissa
// Student ID: 101176085

namespace Assignment
{

    class MainClass
    {

        static Student[] getInfoFromFile(out string correctAnswers)
        {
            int spaceIndex;
            string studentId, studentAnswer, line;
            List<Student> listOfStudents = new List<Student>();
            correctAnswers = "";

            try
            {
                StreamReader reader = new StreamReader("/Users/thiagohissa/Desktop/CurrentSemester/Assignment/Assignment/exam.txt");

                line = reader.ReadLine();
                correctAnswers = line;
                studentId = "-1";

                while (Convert.ToInt32(studentId) != 0){

                    line = reader.ReadLine();

                    if (line != "0" && line != null)
                    {
                        // Student ID
                        spaceIndex = line.IndexOf(' ');
                        studentId = line.Substring(0, spaceIndex);

                        // Student Answers
                        studentAnswer = line.Substring(spaceIndex, line.Length - spaceIndex);
                        studentAnswer = studentAnswer.Replace(" ", "");

                        Student student = new Student(studentId, studentAnswer);
                        listOfStudents.Add(student);
                    }
                    else
                    {
                        studentId = line; 
                    }
                }

                reader.Close();

            }
            catch (IOException error)
            {
                Console.WriteLine(error.Message);
            }
            Student[] arrayOFStudents = listOfStudents.ToArray();
            return arrayOFStudents;
        }


        static List<int> initListWithLength(int length)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < length; i++)
            {
                list.Add(0);
            }
            return list;
        }


        static int[] gradeStudents(string correctAnswers, Student[] arrayOfStudents)
        {
            int mark;
            char[] correct = correctAnswers.ToUpper().ToCharArray();

            List<int> questionsStats = initListWithLength(correctAnswers.Length);

            for (int i = 0; i < arrayOfStudents.Length; i++)
            {
                mark = 0;
                char[] answer = arrayOfStudents[i].getAnswers().ToUpper().ToCharArray();
                for (int j = 0; j < answer.Length; j++)
                {
                    if (answer[j] == correct[j])
                    {
                        mark += 4;
                        questionsStats[j] += 1;
                    }
                    else if (answer[j] != 'X')
                    {
                        mark += -1;
                    }
                }
                arrayOfStudents[i].setGrade(mark);
            }

            int[] stats = questionsStats.ToArray();
            return stats;
        }




        public static void Main(string[] args)
        {
            Student[] arrayOfStudents = getInfoFromFile(out string correctAnswers); 
            int[] stats = gradeStudents(correctAnswers, arrayOfStudents);

            // OUTPUT  
            Console.WriteLine("******************* MCQ STUDENT EXAM REPORT *******************");
            Console.WriteLine(" ");
            Console.WriteLine("Student Number \t \t \t Mark");

            for (int i = 0; i < arrayOfStudents.Length; i++)
            {
                Console.Write(" {0} \t \t \t \t ", arrayOfStudents[i].getId());
                Console.Write("{0}\n", arrayOfStudents[i].getGrade());
            }
            Console.WriteLine("\n \n");

            Console.WriteLine("The total number of examinations marked: {0}", arrayOfStudents.Length);
            Console.WriteLine("Number of correct answers for each question:");

            Console.Write("Question: 1 \t 2 \t 3 \t 4 \t 5 \t 6 \t 7 \t 8 \t 9 \t 10");
            Console.Write("\n#Correct: ");
            for (int i = 0; i < stats.Length / 2; i++)
            {
                Console.Write("{0} \t", stats[i]);
            }
            Console.WriteLine("\n");
            Console.Write("Question: 11 \t 12 \t 13 \t 14 \t 15 \t 16 \t 17 \t 18 \t 19 \t 20");
            Console.Write("\n#Correct: ");
            for (int i = 10; i < stats.Length; i++)
            {
                Console.Write("{0} \t", stats[i]);
            }
            Console.WriteLine("\n\n");

            Console.ReadKey();
        }
    }
}
