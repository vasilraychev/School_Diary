using School_Diary.Data.Models;

namespace School_Diary
{
    public class MarksViews
    {
        public static void MarksEmpty(int currentSubjectId, int currentStudentId, int currentGradeId, SchoolDiaryContext data, ref bool backToSubjects)
        {
            Console.WriteLine(data.Grades.Where(x => x.GradeId == currentGradeId).FirstOrDefault().PrintGrade());
            Console.WriteLine(data.Students.Where(x => x.StudentId == currentStudentId).FirstOrDefault().PrintStudent());
            Console.WriteLine(data.Subjects.Where(x => x.SubjectId == currentSubjectId).FirstOrDefault().PrintSubject());
            Console.WriteLine("ALL MARKS:");
            Console.WriteLine("EMPTY");
            Console.WriteLine("");
            Console.WriteLine("1. Add Mark");
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
                        MarksMethods.AddMark(currentSubjectId, data);
                        break;
                    }
                    else if (command == 2)
                    {
                        Console.Clear();
                        backToSubjects = false;
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

        public static void MarksNotEmpty(int currentSubjectId, int currentStudentId, int currentGradeId, SchoolDiaryContext data, ref bool backToSubjects)
        {
            Console.WriteLine(data.Grades.Where(x => x.GradeId == currentGradeId).FirstOrDefault().PrintGrade());
            Console.WriteLine(data.Students.Where(x => x.StudentId == currentStudentId).FirstOrDefault().PrintStudent());
            Console.WriteLine(data.Subjects.Where(x => x.SubjectId == currentSubjectId).FirstOrDefault().PrintSubject());
            Console.WriteLine("ALL MARKS:");
            var allMarks = data.Marks.Where(x => x.SubjectId == currentSubjectId && x.IsDelete == false).ToList();
            allMarks.Sort();
            for (int i = 0; i < allMarks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {allMarks[i].PrintMark()}");
            }
            Console.WriteLine("");
            Console.WriteLine("1. Add Mark");
            Console.WriteLine("2. Remove Mark");
            Console.WriteLine("3. Back");
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
                        MarksMethods.AddMark(currentSubjectId, data);
                        break;
                    }
                    else if (command == 2)
                    {
                        Console.Clear();
                        MarksMethods.RemoveMark(currentSubjectId, data);
                        break;
                    }
                    else if (command == 3)
                    {
                        Console.Clear();
                        backToSubjects = false;
                        break;
                    }
                    else
                    {
                        throw new ArgumentException("The command can only be 1, 2 or 3!");
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

        public static void MarksEmptyStudentAuth(int currentSubjectId, int currentStudentId, int currentGradeId, SchoolDiaryContext data, ref bool backToSubjects)
        {
            Console.WriteLine(data.Grades.Where(x => x.GradeId == currentGradeId).FirstOrDefault().PrintGrade());
            Console.WriteLine(data.Students.Where(x => x.StudentId == currentStudentId).FirstOrDefault().PrintStudent());
            Console.WriteLine(data.Subjects.Where(x => x.SubjectId == currentSubjectId).FirstOrDefault().PrintSubject());
            Console.WriteLine("ALL MARKS:");
            Console.WriteLine("EMPTY");
            Console.WriteLine("");
            Console.WriteLine("1. Back");
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
                        backToSubjects = false;
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

        public static void MarksNotEmptyStudentAuth(int currentSubjectId, int currentStudentId, int currentGradeId, SchoolDiaryContext data, ref bool backToSubjects)
        {
            Console.WriteLine(data.Grades.Where(x => x.GradeId == currentGradeId).FirstOrDefault().PrintGrade());
            Console.WriteLine(data.Students.Where(x => x.StudentId == currentStudentId).FirstOrDefault().PrintStudent());
            Console.WriteLine(data.Subjects.Where(x => x.SubjectId == currentSubjectId).FirstOrDefault().PrintSubject());
            Console.WriteLine("ALL MARKS:");
            var allMarks = data.Marks.Where(x => x.SubjectId == currentSubjectId && x.IsDelete == false).ToList();
            allMarks.Sort();
            for (int i = 0; i < allMarks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {allMarks[i].PrintMark()}");
            }
            Console.WriteLine("");
            Console.WriteLine("1. Back");
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
                        backToSubjects = false;
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
    }
}
