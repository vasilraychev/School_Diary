using System.Diagnostics.CodeAnalysis;

namespace School_Diary.Data.Models
{
    public class Mark : IComparable<Mark>
    {
        private decimal markLevel;
        private int dateOfAssessment;
        private int monthOfAssessment;
        private int yearOfAssessment;
        public int MarkId { get; set; }

        public int SubjectId { get; set; }

        public decimal MarkLevel
        {
            get
            {
                return this.markLevel;
            }
            set
            {
                if (value < 2)
                {
                    throw new ArgumentException("The lowest mark is 2!");
                }
                if (value > 6)
                {
                    throw new ArgumentException("The highest mark is 6!");
                }
                this.markLevel = value;
            }
        }

        public int DateOfAssessment
        {
            get
            {
                return this.dateOfAssessment;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Date of assessment should be at least 1!");
                }
                if (value > 31)
                {
                    throw new ArgumentException("Date of assessment should be a maximum of 31!");
                }
                this.dateOfAssessment = value;
            }
        }

        public int MonthOfAssessment
        {
            get
            {
                return this.monthOfAssessment;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Month of assessment should be at least 1!");
                }
                if (value > 12)
                {
                    throw new ArgumentException("Month of assessment should be a maximum of 12!");
                }
                this.monthOfAssessment = value;
            }
        }

        public int YearOfAssessment
        {
            get
            {
                return this.yearOfAssessment;
            }
            set
            {
                if (value < 2010)
                {
                    throw new ArgumentException("Year of assessment should be at least 2010!");
                }
                if (value > 2023)
                {
                    throw new ArgumentException("Year of assessment should be a maximum of 2023!");
                }
                this.yearOfAssessment = value;
            }
        }

        public bool IsDelete { get; set; }

        public virtual Subject Subject { get; set; } = null!;

        public string PrintMark()
        {
            return $"{this.MarkLevel} - {this.DateOfAssessment}.{this.MonthOfAssessment}.{this.YearOfAssessment}";
        }

        public int CompareTo([AllowNull] Mark other)
        {
            int result = this.YearOfAssessment.CompareTo(other.YearOfAssessment);
            if (result == 0)
            {
                result = this.MonthOfAssessment.CompareTo(other.MonthOfAssessment);
            }
            if (result == 0)
            {
                result = this.DateOfAssessment.CompareTo(other.DateOfAssessment);
            }
            return result;
        }
    }
}