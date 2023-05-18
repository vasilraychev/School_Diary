using School_Diary.Data.Models;

namespace School_Diary
{
    public class SubjectsViews
    {
        public static void SubjectsEmpty(int currentStudentId, int currentGradeId, SchoolDiaryContext data, ref bool backToStudents)
        {
            Console.WriteLine(data.Grades.Where(x => x.GradeId == currentGradeId).FirstOrDefault().PrintGrade());
            Console.WriteLine(data.Students.Where(x => x.StudentId == currentStudentId).FirstOrDefault().PrintStudent());
            Console.WriteLine(data.Students.Where(x => x.StudentId == currentStudentId).FirstOrDefault().PrintStudentInfo());
            Console.WriteLine(data.StudentsAuthentications.Where(x => x.StudentId == currentStudentId).FirstOrDefault().PrintStudentAuthentication());
            Console.WriteLine("ALL SUBJECTS:");
            Console.WriteLine("EMPTY");
            Console.WriteLine("");
            Console.WriteLine("1. Add Subject");
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
                        SubjectsMethods.AddSubject(currentStudentId, data);
                        break;
                    }
                    else if (command == 2)
                    {
                        Console.Clear();
                        backToStudents = false;
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
        public static void SubjectsNotEmpty(int currentStudentId, int currentGradeId, SchoolDiaryContext data, ref bool backToStudents)
        {
            Console.WriteLine(data.Grades.Where(x => x.GradeId == currentGradeId).FirstOrDefault().PrintGrade());
            Console.WriteLine(data.Students.Where(x => x.StudentId == currentStudentId).FirstOrDefault().PrintStudent());
            Console.WriteLine(data.Students.Where(x => x.StudentId == currentStudentId).FirstOrDefault().PrintStudentInfo());
            Console.WriteLine(data.StudentsAuthentications.Where(x => x.StudentId == currentStudentId).FirstOrDefault().PrintStudentAuthentication());
            Console.WriteLine("ALL SUBJECTS:");
            var allSubjects = data.Subjects.Where(x => x.StudentId == currentStudentId && x.IsDelete == false).ToList();
            allSubjects.Sort();
            for (int i = 0; i < allSubjects.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {allSubjects[i].PrintSubject()}");
            }
            Console.WriteLine("");
            Console.WriteLine("1. Add Subject");
            Console.WriteLine("2. Open Subject");
            Console.WriteLine("3. Remove Subject");
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
                        SubjectsMethods.AddSubject(currentStudentId, data);
                        break;
                    }
                    else if (command == 2)
                    {
                        Console.Clear();
                        SubjectsMethods.OpenSubject(currentStudentId, currentGradeId, data);
                        break;
                    }
                    else if (command == 3)
                    {
                        Console.Clear();
                        SubjectsMethods.RemoveSubject(currentStudentId, data);
                        break;
                    }
                    else if (command == 4)
                    {
                        Console.Clear();
                        backToStudents = false;
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

        public static void SubjectsEmptyStudentAuth(int currentStudentId, int currentGradeId, SchoolDiaryContext data, ref bool leave)
        {
            Console.WriteLine(data.Grades.Where(x => x.GradeId == currentGradeId).FirstOrDefault().PrintGrade());
            Console.WriteLine(data.Students.Where(x => x.StudentId == currentStudentId).FirstOrDefault().PrintStudent());
            Console.WriteLine(data.Students.Where(x => x.StudentId == currentStudentId).FirstOrDefault().PrintStudentInfo());
            Console.WriteLine(data.StudentsAuthentications.Where(x => x.StudentId == currentStudentId).FirstOrDefault().PrintStudentAuthentication());
            Console.WriteLine("ALL SUBJECTS:");
            Console.WriteLine("EMPTY");
            Console.WriteLine("");
            Console.WriteLine("1. Leave");
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
                        leave = false;
                        break;
                    }
                    else
                    {
                        throw new ArgumentException("The command can only be 1!");
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

        public static void SubjectsNotEmptyStudentAuth(int currentStudentId, int currentGradeId, SchoolDiaryContext data, ref bool leave)
        {
            Console.WriteLine(data.Grades.Where(x => x.GradeId == currentGradeId).FirstOrDefault().PrintGrade());
            Console.WriteLine(data.Students.Where(x => x.StudentId == currentStudentId).FirstOrDefault().PrintStudent());
            Console.WriteLine(data.Students.Where(x => x.StudentId == currentStudentId).FirstOrDefault().PrintStudentInfo());
            Console.WriteLine(data.StudentsAuthentications.Where(x => x.StudentId == currentStudentId).FirstOrDefault().PrintStudentAuthentication());
            Console.WriteLine("ALL SUBJECTS:");
            var allSubjects = data.Subjects.Where(x => x.StudentId == currentStudentId && x.IsDelete == false).ToList();
            allSubjects.Sort();
            for (int i = 0; i < allSubjects.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {allSubjects[i].PrintSubject()}");
            }
            Console.WriteLine("");
            Console.WriteLine("1. Open Subject");
            Console.WriteLine("2. Leave");
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
                        SubjectsMethods.OpenSubjectStudentAuth(currentStudentId, currentGradeId, data);
                        break;
                    }
                    else if (command == 2)
                    {
                        Console.Clear();
                        leave = false;
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
    }
}