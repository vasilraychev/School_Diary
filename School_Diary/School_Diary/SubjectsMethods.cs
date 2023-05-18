using School_Diary.Data.Models;

namespace School_Diary
{
    public class SubjectsMethods
    {
        public static void AddSubject(int currentStudentId, SchoolDiaryContext data)
        {
            var allSubjects = data.Subjects.Where(x => x.StudentId == currentStudentId && x.IsDelete == false).ToList();
            var currentSubject = new Subject();
            currentSubject.StudentId = currentStudentId;
            Console.WriteLine("Subject Name");
            Console.WriteLine("For example: Maths");
            while (true)
            {
                Console.WriteLine("");
                Console.Write("Type: ");
                try
                {
                    string subject = Console.ReadLine();
                    for (int i = 0; i < allSubjects.Count; i++)
                    {
                        if (subject == allSubjects[i].SubjectName)
                        {
                            throw new ArgumentException("There cannot be two identical subjects!");
                        }
                    }
                    currentSubject.SubjectName = subject;
                    Console.Clear();
                    break;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Write all the information!");
                    Console.WriteLine("Try Again!");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Try Again");
                }
            }
            data.Subjects.Add(currentSubject);
            data.SaveChanges();
        }

        public static void RemoveSubject(int currentStudentId, SchoolDiaryContext data)
        {
            var allSubjects = data.Subjects.Where(x => x.StudentId == currentStudentId && x.IsDelete == false).ToList();
            allSubjects.Sort();
            int number = 0;
            Console.WriteLine("ALL SUBJECTS:");
            for (int i = 0; i < allSubjects.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {allSubjects[i].PrintSubject()}");
            }
            while (true)
            {
                Console.WriteLine("");
                Console.Write("Which Subject to be Removed: ");
                try
                {
                    number = int.Parse(Console.ReadLine());
                    if (number < 1 || number > allSubjects.Count)
                    {
                        throw new ArgumentException("There is no Subject on this number!");
                    }
                    Console.Clear();
                    break;
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
            int currentSubjectId = allSubjects[number - 1].SubjectId;
            data.Subjects.Where(x => x.SubjectId == currentSubjectId).FirstOrDefault().IsDelete = true;
            var currentSubjectMarks = data.Marks
                   .Where(x => x.SubjectId == currentSubjectId && x.IsDelete == false)
                   .ToList();
            for (int q = 0; q < currentSubjectMarks.Count; q++)
            {
                currentSubjectMarks[q].IsDelete = true;
            }
            data.SaveChanges();
        }

        public static void OpenSubject(int currentStudentId, int currentGradeId, SchoolDiaryContext data)
        {
            var allSubjects = data.Subjects.Where(x => x.StudentId == currentStudentId && x.IsDelete == false).ToList();
            allSubjects.Sort();
            int number = 0;
            Console.WriteLine("ALL SUBJECTS:");
            for (int i = 0; i < allSubjects.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {allSubjects[i].PrintSubject()}");
            }
            while (true)
            {
                Console.WriteLine("");
                Console.Write("Which Subject to be Open: ");
                try
                {
                    number = int.Parse(Console.ReadLine());
                    if (number < 1 || number > allSubjects.Count)
                    {
                        throw new ArgumentException("There is no Subject on this number!");
                    }
                    Console.Clear();
                    break;
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
            int currentSubjectId = allSubjects[number - 1].SubjectId;
            bool backToSubjects = true;
            while (backToSubjects != false)
            {
                var currentSubjectCount = data.Marks
                    .Where(x => x.SubjectId == currentSubjectId && x.IsDelete == false)
                    .ToList().Count;
                if (currentSubjectCount == 0)
                {
                    MarksViews.MarksEmpty(currentSubjectId, currentStudentId, currentGradeId, data, ref backToSubjects);
                }
                else
                {
                    MarksViews.MarksNotEmpty(currentSubjectId, currentStudentId, currentGradeId, data, ref backToSubjects);
                }
            }
        }

        public static void OpenSubjectStudentAuth(int currentStudentId, int currentGradeId, SchoolDiaryContext data)
        {
            var allSubjects = data.Subjects.Where(x => x.StudentId == currentStudentId && x.IsDelete == false).ToList();
            allSubjects.Sort();
            int number = 0;
            Console.WriteLine("ALL SUBJECTS:");
            for (int i = 0; i < allSubjects.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {allSubjects[i].PrintSubject()}");
            }
            while (true)
            {
                Console.WriteLine("");
                Console.Write("Which Subject to be Open: ");
                try
                {
                    number = int.Parse(Console.ReadLine());
                    if (number < 1 || number > allSubjects.Count)
                    {
                        throw new ArgumentException("There is no Subject on this number!");
                    }
                    Console.Clear();
                    break;
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
            int currentSubjectId = allSubjects[number - 1].SubjectId;
            bool backToSubjects = true;
            while (backToSubjects != false)
            {
                var currentSubjectCount = data.Marks
                    .Where(x => x.SubjectId == currentSubjectId && x.IsDelete == false)
                    .ToList().Count;
                if (currentSubjectCount == 0)
                {
                    MarksViews.MarksEmptyStudentAuth(currentSubjectId, currentStudentId, currentGradeId, data, ref backToSubjects);
                }
                else
                {
                    MarksViews.MarksNotEmptyStudentAuth(currentSubjectId, currentStudentId, currentGradeId, data, ref backToSubjects);
                }
            }
        }
    }
}