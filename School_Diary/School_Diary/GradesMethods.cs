using School_Diary.Data.Models;

namespace School_Diary
{
    public class GradesMethods
    {
        public static void AddGrade(SchoolDiaryContext data)
        {
            var allGrades = data.Grades.Where(x => x.IsDelete == false).ToList();
            var currentGrade = new Grade();
            Console.WriteLine("Grade Number/Grade Name");
            Console.WriteLine("For example: 8/D; 11/A; 9/Lion");
            while (true)
            {
                Console.WriteLine("");
                Console.Write("Type: ");
                try
                {
                    List<string> grade = Console.ReadLine().Split('/').ToList();
                    for (int i = 0; i < allGrades.Count; i++)
                    {
                        if (int.Parse(grade[0]) == allGrades[i].GradeNumber && grade[1] == allGrades[i].GradeName)
                        {
                            throw new ArgumentException("There cannot be two identical grades!");
                        }
                    }
                    if (grade.Count > 2)
                    {
                        throw new ArgumentException("See example!");
                    }
                    currentGrade.GradeNumber = int.Parse(grade[0]);
                    currentGrade.GradeName = grade[1];
                    Console.Clear();
                    break;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Write all information!");
                    Console.WriteLine("Try Again!");
                }
                catch (FormatException)
                {
                    Console.WriteLine("");
                    Console.WriteLine("The grade should be in digits only!");
                    Console.WriteLine("Try Again!");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Try Again!");
                }
            }
            data.Grades.Add(currentGrade);
            data.SaveChanges();
        }

        public static void RemoveGrade(SchoolDiaryContext data)
        {
            var allGrades = data.Grades.Where(x => x.IsDelete == false).ToList();
            allGrades.Sort();
            int number = 0;
            Console.WriteLine("ALL GRADES:");
            for (int i = 0; i < allGrades.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {allGrades[i].PrintGrade()}");
            }
            while (true)
            {
                Console.WriteLine("");
                Console.Write("Which Grade to be Removed: ");
                try
                {
                    number = int.Parse(Console.ReadLine());
                    if (number < 1 || number > allGrades.Count)
                    {
                        throw new ArgumentException("There is no grade on this number!");
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
            int currentGradeId = allGrades[number - 1].GradeId; 
            data.Grades.Where(x => x.GradeId == currentGradeId).FirstOrDefault().IsDelete = true;
            var currentGradeStudents = data.Students
                .Where(x => x.GradeId == currentGradeId && x.IsDelete == false)
                .ToList();
            for (int y = 0; y < currentGradeStudents.Count; y++)
            {
                currentGradeStudents[y].IsDelete = true;
                data.StudentsAuthentications.Where(x => x.StudentId == currentGradeStudents[y].StudentId).FirstOrDefault().IsDelete = true;
                var currentGradeStudentSubjects = data.Subjects
                    .Where(x => x.StudentId == currentGradeStudents[y].StudentId && x.IsDelete == false)
                    .ToList();
                for (int u = 0; u < currentGradeStudentSubjects.Count; u++)
                {
                    currentGradeStudentSubjects[u].IsDelete = true;
                    var currentGradeStudentSubjectMarks = data.Marks
                        .Where(x => x.SubjectId == currentGradeStudentSubjects[u].SubjectId && x.IsDelete == false)
                        .ToList();
                    for (int q = 0; q < currentGradeStudentSubjectMarks.Count; q++)
                    {
                        currentGradeStudentSubjectMarks[q].IsDelete = true;
                    }
                }
            }
            data.SaveChanges();
        }

        public static void OpenGrade(SchoolDiaryContext data)
        {
            var allGrades = data.Grades.Where(x => x.IsDelete == false).ToList();
            allGrades.Sort();
            int number = 0;
            Console.WriteLine("ALL GRADES:");
            for (int i = 0; i < allGrades.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {allGrades[i].PrintGrade()}");
            }
            while (true)
            {
                Console.WriteLine("");
                Console.Write("Which Grade to be Open: ");
                try
                {
                    number = int.Parse(Console.ReadLine());
                    if (number < 1 || number > allGrades.Count)
                    {
                        throw new ArgumentException("There is no grade on this number!");
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
            int currentGradeId = allGrades[number - 1].GradeId;
            bool backToGrades = true;
            while (backToGrades != false)
            {
                var currentGradeCount = data.Students
                    .Where(x => x.GradeId == currentGradeId && x.IsDelete == false)
                    .ToList().Count;
                if (currentGradeCount == 0)
                {
                    StudentsViews.StudentsEmpty(currentGradeId, data, ref backToGrades);
                }
                else
                {
                    StudentsViews.StudentsNotEmpty(currentGradeId, data, ref backToGrades);
                }
            }
        }
    }
}