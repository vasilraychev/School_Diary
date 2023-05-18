using School_Diary.Data.Models;

namespace School_Diary
{
    public class StudentsViews
    {
        public static void StudentsEmpty(int currentGradeId, SchoolDiaryContext data, ref bool backToGrades)
        {
            Console.WriteLine(data.Grades.Where(x => x.GradeId == currentGradeId).FirstOrDefault().PrintGrade());
            Console.WriteLine("ALL STUDENTS:");
            Console.WriteLine("EMPTY");
            Console.WriteLine("");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Back");
            while (true)
            {
                Console.WriteLine("");
                Console.Write("Command: ");
                try
                {
                    int command = int.Parse(Console.ReadLine());
                    if (command == 1)
                    {
                        Console.Clear();
                        StudentsMethods.AddStudent(currentGradeId, data);
                        break;
                    }
                    else if (command == 2)
                    {
                        Console.Clear();
                        backToGrades = false;
                        break;
                    }
                    else
                    {
                        throw new ArgumentException("The command can only be 1 or 2!");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("");
                    Console.WriteLine("The command should be in digits only!");
                    Console.WriteLine("Try Again!");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Try Again!");
                }
            }
        }
        public static void StudentsNotEmpty(int currentGradeId, SchoolDiaryContext data, ref bool backToGrades)
        {
            Console.WriteLine(data.Grades.Where(x => x.GradeId == currentGradeId).FirstOrDefault().PrintGrade());
            Console.WriteLine("ALL STUDENTS:");
            var allStudents = data.Students.Where(x => x.GradeId == currentGradeId && x.IsDelete == false).ToList();
            allStudents.Sort();
            for (int i = 0; i < allStudents.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {allStudents[i].PrintStudent()}");
            }
            Console.WriteLine("");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Open Student");
            Console.WriteLine("3. Remove Student");
            Console.WriteLine("4. Back");
            while (true)
            {
                Console.WriteLine("");
                Console.Write("Command: ");
                try
                {
                    int command = int.Parse(Console.ReadLine());
                    if (command == 1)
                    {
                        Console.Clear();
                        StudentsMethods.AddStudent(currentGradeId, data);
                        break;
                    }
                    else if (command == 2)
                    {
                        Console.Clear();
                        StudentsMethods.OpenStudent(currentGradeId, data);
                        break;
                    }
                    else if (command == 3)
                    {
                        Console.Clear();
                        StudentsMethods.RemoveStudent(currentGradeId, data);
                        break;
                    }
                    else if (command == 4)
                    {
                        Console.Clear();
                        backToGrades = false;
                        break;
                    }
                    else
                    {
                        throw new ArgumentException("The command can only be 1, 2, 3 or 4!");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("");
                    Console.WriteLine("The command should be in digits only!");
                    Console.WriteLine("Try Again!");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Try Again!");
                }
            }
        }
    }
}