using School_Diary.Data.Models;

namespace School_Diary
{
    public class GradesViews
    {
        public static void GradesEmpty(SchoolDiaryContext data, ref bool leave)
        {
            Console.WriteLine("ALL GRADES:");
            Console.WriteLine("EMPTY");
            Console.WriteLine("");
            Console.WriteLine("1. Add Grade");
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
                        GradesMethods.AddGrade(data);
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
        public static void GradesNotEmpty(SchoolDiaryContext data, ref bool leave)
        {
            Console.WriteLine("ALL GRADES:");
            var allGrades = data.Grades.Where(x => x.IsDelete == false).ToList();
            allGrades.Sort();
            for (int i = 0; i < allGrades.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {allGrades[i].PrintGrade()}");
            }
            Console.WriteLine("");
            Console.WriteLine("1. Add Grade");
            Console.WriteLine("2. Open Grade");
            Console.WriteLine("3. Remove Grade");
            Console.WriteLine("4. Leave");
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
                        GradesMethods.AddGrade(data);
                        break;
                    }
                    else if (command == 2)
                    {
                        Console.Clear();
                        GradesMethods.OpenGrade(data);
                        break;
                    }
                    else if (command == 3)
                    {
                        Console.Clear();
                        GradesMethods.RemoveGrade(data);
                        break;
                    }
                    else if (command == 4)
                    {
                        Console.Clear();
                        leave = false;
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
