using School_Diary.Data.Models;

namespace School_Diary
{
    public class StudentsMethods
    {
        public static void AddStudent(int currentGradeId, SchoolDiaryContext data)
        {
            var allStudentAuthentication = data.StudentsAuthentications.Where(x => x.IsDelete == false).ToList();
            var currentStudent = new Student();
            var currentStudentAuthentication = new StudentsAuthentication();
            currentStudent.GradeId = currentGradeId;
            Console.WriteLine("First Name/Second Name/Family Name");
            Console.WriteLine("For example: Ivan/Vasilev/Todorov");
            while (true)
            {
                Console.WriteLine("");
                Console.Write("Type: ");
                try
                {
                    List<string> name = Console.ReadLine().Split('/').ToList();
                    if (name.Count > 3)
                    {
                        throw new ArgumentException("See example!");
                    }
                    currentStudent.FirstName = name[0];
                    currentStudent.SecondName = name[1];
                    currentStudent.FamilyName = name[2];
                    Console.Clear();
                    break;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Write all information!");
                    Console.WriteLine("Try Again!");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Try Again!");
                }
            }
            Console.WriteLine("Date of Birth/Month of Birth/Year of Birth");
            Console.WriteLine("For example: 02/05/2002");
            while (true)
            {
                Console.WriteLine("");
                Console.Write("Type: ");
                try
                {
                    List<int> date = Console.ReadLine().Split('/').Select(int.Parse).ToList();
                    if (date.Count > 3)
                    {
                        throw new ArgumentException("See example!");
                    }
                    currentStudent.DateOfBirth = date[0];
                    currentStudent.MonthOfBirth = date[1];
                    currentStudent.YearOfBirth = date[2];
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
                    Console.WriteLine("The date should be in digits only!");
                    Console.WriteLine("Try Again!");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Try Again");
                }
            }
            Console.WriteLine("Male or Female");
            Console.WriteLine("For example: Male");
            while (true)
            {
                Console.WriteLine("");
                Console.Write("Type: ");
                try
                {
                    string gender = Console.ReadLine();
                    currentStudent.Gender = gender;
                    Console.Clear();
                    break;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Write all information!");
                    Console.WriteLine("Try Again!");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Try Again");
                }
            }
            Console.WriteLine("City/Country");
            Console.WriteLine("For example: Sofia/Bulgaria");
            while (true)
            {
                Console.WriteLine("");
                Console.Write("Type: ");
                try
                {
                    List<string> place = Console.ReadLine().Split('/').ToList();
                    if (place.Count > 2)
                    {
                        throw new ArgumentException("See example!");
                    }
                    currentStudent.City = place[0];
                    currentStudent.Country = place[1];
                    Console.Clear();
                    break;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Write all information!");
                    Console.WriteLine("Try Again!");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Try Again");
                }
            }
            Console.WriteLine("Username");
            Console.WriteLine("For example: vasilRaychev");
            while (true)
            {
                Console.WriteLine("");
                Console.Write("Type: ");
                try
                {
                    string username = Console.ReadLine();
                    if (username == "admin")
                    {
                        throw new ArgumentException("Username cannot be admin!");
                    }
                    for (int i = 0; i < allStudentAuthentication.Count; i++)
                    {
                        if (username == allStudentAuthentication[i].StudentAuthenticationUsername)
                        {
                            throw new ArgumentException("There cannot be two identical usernames!");
                        }
                    }
                    currentStudentAuthentication.StudentAuthenticationUsername = username;
                    Console.Clear();
                    break;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Write all information!");
                    Console.WriteLine("Try Again!");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Try Again!");
                }
            }
            Console.WriteLine("Password");
            Console.WriteLine("For example: Hjsdf12@");
            while (true)
            {
                Console.WriteLine("");
                Console.Write("Type: ");
                try
                {
                    string password = Console.ReadLine();
                    currentStudentAuthentication.StudentAuthenticationPassword = password;
                    Console.Clear();
                    break;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Write all information!");
                    Console.WriteLine("Try Again!");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Try Again!");
                }
            }
            data.Students.Add(currentStudent);
            data.SaveChanges();
            currentStudentAuthentication.StudentId = data.Students.ToList().Count;
            data.StudentsAuthentications.Add(currentStudentAuthentication);
            data.SaveChanges();
        }

        public static void RemoveStudent(int currentGradeId, SchoolDiaryContext data)
        {
            var allStudents = data.Students.Where(x => x.GradeId == currentGradeId && x.IsDelete == false).ToList();
            allStudents.Sort();
            int number = 0;
            Console.WriteLine("ALL STUDENTS:");
            for (int i = 0; i < allStudents.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {allStudents[i].PrintStudent()}");
            }
            while (true)
            {
                Console.WriteLine("");
                Console.Write("Which Student to be Removed: ");
                try
                {
                    number = int.Parse(Console.ReadLine());
                    if (number < 1 || number > allStudents.Count)
                    {
                        throw new ArgumentException("There is no Student on this number!");
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
            int currentStudentId = allStudents[number - 1].StudentId;
            data.Students.Where(x => x.StudentId == currentStudentId).FirstOrDefault().IsDelete = true;
            data.StudentsAuthentications.Where(x => x.StudentId == currentStudentId).FirstOrDefault().IsDelete = true;
            var currentStudentSubjects = data.Subjects
                   .Where(x => x.StudentId == currentStudentId && x.IsDelete == false)
                   .ToList();
            for (int u = 0; u < currentStudentSubjects.Count; u++)
            {
                currentStudentSubjects[u].IsDelete = true;
                var currentStudentSubjectMarks = data.Marks
                    .Where(x => x.SubjectId == currentStudentSubjects[u].SubjectId && x.IsDelete == false)
                    .ToList();
                for (int q = 0; q < currentStudentSubjectMarks.Count; q++)
                {
                    currentStudentSubjectMarks[q].IsDelete = true;
                }
            }
            data.SaveChanges();
        }

        public static void OpenStudent(int currentGradeId, SchoolDiaryContext data)
        {
            var allStudents = data.Students.Where(x => x.GradeId == currentGradeId && x.IsDelete == false).ToList();
            allStudents.Sort();
            int number = 0;
            Console.WriteLine("ALL STUDENTS:");
            for (int i = 0; i < allStudents.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {allStudents[i].PrintStudent()}");
            }
            while (true)
            {
                Console.WriteLine("");
                Console.Write("Which Student to be Open: ");
                try
                {
                    number = int.Parse(Console.ReadLine());
                    if (number < 1 || number > allStudents.Count)
                    {
                        throw new ArgumentException("There is no student on this number!");
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
            int currentStudentId = allStudents[number - 1].StudentId;
            bool backToStudents = true;
            while (backToStudents != false)
            {
                var currentStudentCount = data.Subjects
                    .Where(x => x.StudentId == currentStudentId && x.IsDelete == false)
                    .ToList().Count;
                if (currentStudentCount == 0)
                {
                    SubjectsViews.SubjectsEmpty(currentStudentId, currentGradeId, data, ref backToStudents);
                }
                else
                {
                    SubjectsViews.SubjectsNotEmpty(currentStudentId, currentGradeId, data, ref backToStudents);
                }
            }
        }
    }
}