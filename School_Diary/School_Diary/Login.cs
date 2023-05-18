using School_Diary.Data.Models;

namespace School_Diary
{
    public class Login
    {
        static void Main(string[] args)
        {
            SchoolDiaryContext data = new SchoolDiaryContext();
            if (data.AdminsAuthentications.ToList().Count == 0)
            {
                var admin = new AdminsAuthentication();
                admin.AdminUsername = "admin";
                admin.AdminPassword = "admin";
                data.AdminsAuthentications.Add(admin);
                data.SaveChanges();
            }
            Console.WriteLine("Hello, This is School Diary!");
            bool logout = true;
            while (logout != false)
            {
                Console.WriteLine();
                Console.Write("Username: ");
                string username = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();
                var allStudentsAuthentications = data.StudentsAuthentications.Where(x => x.IsDelete == false).ToList();
                try
                {
                    if (username == data.AdminsAuthentications.FirstOrDefault().AdminUsername && password == data.AdminsAuthentications.FirstOrDefault().AdminPassword)
                    {
                        Console.Clear();
                        bool leave = true;
                        while (leave != false)
                        {
                            var gradesCount = data.Grades.Where(x => x.IsDelete == false).ToList().Count;
                            if (gradesCount == 0)
                            {
                                GradesViews.GradesEmpty(data, ref leave);
                            }
                            else
                            {
                                GradesViews.GradesNotEmpty(data, ref leave);
                            }
                        }
                        logout = false;
                    }
                    else if (allStudentsAuthentications.Count != 0)
                    {
                        for (int i = 0; i < allStudentsAuthentications.Count; i++)
                        {
                            if (username == allStudentsAuthentications[i].StudentAuthenticationUsername && password == allStudentsAuthentications[i].StudentAuthenticationPassword)
                            {
                                Console.Clear();
                                bool leave = true;
                                while (leave != false)
                                {
                                    var currentStudent = data.Students.Where(x => x.StudentId == allStudentsAuthentications[i].StudentId && x.IsDelete == false).FirstOrDefault();
                                    var currentStudentSubjectsCount = data.Subjects.Where(x => x.StudentId == currentStudent.StudentId && x.IsDelete == false).ToList().Count;
                                    if (currentStudentSubjectsCount == 0)
                                    {
                                        SubjectsViews.SubjectsEmptyStudentAuth(currentStudent.StudentId, currentStudent.GradeId, data, ref leave);
                                    }
                                    else
                                    {
                                        SubjectsViews.SubjectsNotEmptyStudentAuth(currentStudent.StudentId, currentStudent.GradeId, data, ref leave);
                                    }
                                }
                                logout = false;
                                break;
                            }
                        }
                    }

                    if (logout == true)
                    {
                        throw new ArgumentException("Wrong Username or Password!");
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Try Again!");
                }
            }
            Console.WriteLine("Bye, Bye!");
        }
    }
}
