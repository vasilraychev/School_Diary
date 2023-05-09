using System.Diagnostics.CodeAnalysis;

namespace School_Diary.Data.Models;

public class Grade : IComparable<Grade>
{
    private int gradeNumber;
    private string gradeName;

    public int GradeId { get; set; }

    public int GradeNumber
    {
        get
        {
            return this.gradeNumber;
        }
        set
        {
            if (value < 1)
            {
                throw new ArgumentException("The grade should be at least 1!");
            }
            if (value > 12)
            {
                throw new ArgumentException("The grade should be at maximum 12!");
            }
            this.gradeNumber = value;
        }
    }

    public string GradeName
    {
        get
        {
            return this.gradeName;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("The grade name cannot be empty!");
            }
            if (!char.IsUpper(value[0]))
            {
                throw new ArgumentException("The first letter on grade name cannot be lower!");
            }
            if (value.Length < 1)
            {
                throw new ArgumentException("The grade name is too short! It should be at least 1 letter.");
            }
            if (value.Length > 20)
            {
                throw new ArgumentException("Тhe grade name is too long! It should be at maximum 20 letter.");
            }
            for (int i = 0; i < value.Length; i++)
            {
                if (!char.IsLetter(value[i]) && value[i] != ' ')
                {
                    throw new ArgumentException("The grade name should be in letters only!");
                }
            }
            this.gradeName = value;
        }
    }

    public bool IsDelete { get; set; }

    public virtual ICollection<Student> Students { get; } = new List<Student>();

    public string PrintGrade()
    {
        return $"{this.GradeNumber} {this.GradeName}";
    }

    public int CompareTo([AllowNull] Grade other)
    {
        int result = this.GradeNumber.CompareTo(other.GradeNumber);
        if (result == 0)
        {
            result = this.GradeName.CompareTo(other.GradeName);
        }
        return result;
    }
}
