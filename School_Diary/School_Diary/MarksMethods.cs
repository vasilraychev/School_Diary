using School_Diary.Data.Models;

namespace School_Diary
{
    public class MarksMethods
    {
        public static void AddMark(int currentSubjectId, SchoolDiaryContext data)
        {
            var currentMark = new Mark();
            currentMark.SubjectId = currentSubjectId;
            Console.WriteLine("Mark Level");
            Console.WriteLine("For example: 2/3,70/4,25/5,50/6");
            while (true)
            {
                Console.WriteLine("");
                Console.Write("Type: ");
                try
                {
                    decimal mark = decimal.Parse(Console.ReadLine());
                    currentMark.MarkLevel = mark;
                    Console.Clear();
                    break;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Write all the information!");
                    Console.WriteLine("Try Again!");
                }
                catch (FormatException)
                {
                    Console.WriteLine("");
                    Console.WriteLine("The mark should be digits only!");
                    Console.WriteLine("Try Again!");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Try Again");
                }
            }
            Console.WriteLine("Date of Assessment/Month of Assessment/Year of Assessment");
            Console.WriteLine("For example: 02/05/2023");
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
                    currentMark.DateOfAssessment = date[0];
                    currentMark.MonthOfAssessment = date[1];
                    currentMark.YearOfAssessment = date[2];
                    Console.Clear();
                    break;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Write all the information!");
                    Console.WriteLine("Try Again!");
                }
                catch (FormatException)
                {
                    Console.WriteLine("");
                    Console.WriteLine("The date should be digits only!");
                    Console.WriteLine("Try Again!");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Try Again");
                }
            }
            data.Marks.Add(currentMark);
            data.SaveChanges();
        }

        public static void RemoveMark(int currentSubjectId, SchoolDiaryContext data)
        {
            var allMarks = data.Marks.Where(x => x.SubjectId == currentSubjectId && x.IsDelete == false).ToList();
            allMarks.Sort();
            int number = 0;
            Console.WriteLine("ALL MARKS:");
            for (int i = 0; i < allMarks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {allMarks[i].PrintMark()}");
            }
            while (true)
            {
                Console.WriteLine("");
                Console.Write("Which Mark to be Removed: ");
                try
                {
                    number = int.Parse(Console.ReadLine());
                    if (number < 1 || number > allMarks.Count)
                    {
                        throw new ArgumentException("There is no Mark on this number!");
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
            int currentMarkId = allMarks[number - 1].MarkId;
            data.Marks.Where(x => x.MarkId == currentMarkId).FirstOrDefault().IsDelete = true;
            data.SaveChanges();
        }
    }
}
