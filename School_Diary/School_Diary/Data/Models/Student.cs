using System.Diagnostics.CodeAnalysis;

namespace School_Diary.Data.Models
{
    public class Student : IComparable<Student>
    {
        private string firstName;
        private string secondName;
        private string familyName;
        private int dateOfBirth;
        private int monthOfBirth;
        private int yearOfBirth;
        private string gender;
        private string country;
        private string city;

        public int StudentId { get; set; }

        public int GradeId { get; set; }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First name cannot be empty!");
                }
                if (!char.IsUpper(value[0]))
                {
                    throw new ArgumentException("The first letter of first name cannot be lower!");
                }
                if (value.Length < 2)
                {
                    throw new ArgumentException("First name is too short! It should be at least 2 letters.");
                }
                if (value.Length > 20)
                {
                    throw new ArgumentException("First name is too long! It should be a maximum of 20 letters.");
                }
                for (int i = 0; i < value.Length; i++)
                {
                    if (!char.IsLetter(value[i]) && value[i] != ' ')
                    {
                        throw new ArgumentException("First name should be in letters only!");
                    }
                }
                this.firstName = value;
            }
        }

        public string SecondName
        {
            get
            {
                return this.secondName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Second name cannot be empty!");
                }
                if (!char.IsUpper(value[0]))
                {
                    throw new ArgumentException("The first letter of second name cannot be lower!");
                }
                if (value.Length < 2)
                {
                    throw new ArgumentException("Second name is too short! It should be at least 2 letters.");
                }
                if (value.Length > 20)
                {
                    throw new ArgumentException("Second name is too long! It should be a maximum of 20 letters.");
                }
                for (int i = 0; i < value.Length; i++)
                {
                    if (!char.IsLetter(value[i]) && value[i] != ' ')
                    {
                        throw new ArgumentException("Second name should be in letters only!");
                    }
                }
                this.secondName = value;
            }
        }

        public string FamilyName
        {
            get
            {
                return this.familyName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Family name cannot be empty!");
                }
                if (!char.IsUpper(value[0]))
                {
                    throw new ArgumentException("The first letter of famiy name cannot be lower!");
                }
                if (value.Length < 2)
                {
                    throw new ArgumentException("Family name is too short! It should be at least 2 letters.");
                }
                if (value.Length > 20)
                {
                    throw new ArgumentException("Family name is too long! It should be a maximum of 20 letters.");
                }
                for (int i = 0; i < value.Length; i++)
                {
                    if (!char.IsLetter(value[i]) && value[i] != ' ')
                    {
                        throw new ArgumentException("Family name should be in letters only!");
                    }
                }
                this.familyName = value;
            }
        }

        public int DateOfBirth
        {
            get
            {
                return this.dateOfBirth;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Date of birth should be at least 1!");
                }
                if (value > 31)
                {
                    throw new ArgumentException("Date of birth should be a maximum of 31!");
                }
                this.dateOfBirth = value;
            }
        }

        public int MonthOfBirth
        {
            get
            {
                return this.monthOfBirth;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Month of birth should be at least 1!");
                }
                if (value > 12)
                {
                    throw new ArgumentException("Month of birth should be a maximum of 12!");
                }
                this.monthOfBirth = value;
            }
        }

        public int YearOfBirth
        {
            get
            {
                return this.yearOfBirth;
            }
            set
            {
                if (value < 1900)
                {
                    throw new ArgumentException("Year of birth should be at least 1900!");
                }
                if (value > 2023)
                {
                    throw new ArgumentException("Year of birth should be a maximum of 2023!");
                }
                this.yearOfBirth = value;
            }
        }

        public string Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                if (value != "Male" && value != "Female")
                {
                    throw new ArgumentException("Gender can only be Male or Female!");
                }
                this.gender = value;
            }
        }

        public string Country
        {
            get
            {
                return this.country;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Country cannot be empty!");
                }
                if (!char.IsUpper(value[0]))
                {
                    throw new ArgumentException("The first letter of country name cannot be lower!");
                }
                if (value.Length < 2)
                {
                    throw new ArgumentException("Country name is too short! It should be at least 2 letters.");
                }
                if (value.Length > 30)
                {
                    throw new ArgumentException("Country name is too long! It should be a maximum of 30 letters.");
                }
                for (int i = 0; i < value.Length; i++)
                {
                    if (!char.IsLetter(value[i]) && value[i] != ' ')
                    {
                        throw new ArgumentException("Country name should be in letters only!");
                    }
                }
                this.country = value;
            }
        }

        public string City
        {
            get
            {
                return this.city;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("City cannot be empty!");
                }
                if (!char.IsUpper(value[0]))
                {
                    throw new ArgumentException("The first letter of city name cannot be lower!");
                }
                if (value.Length < 2)
                {
                    throw new ArgumentException("City name is too short! It should be at least 2 letters.");
                }
                if (value.Length > 30)
                {
                    throw new ArgumentException("City name is too long! It should be a maximum of 30 letters.");
                }
                for (int i = 0; i < value.Length; i++)
                {
                    if (!char.IsLetter(value[i]) && value[i] != ' ')
                    {
                        throw new ArgumentException("City name should be in letters only!");
                    }
                }
                this.city = value;
            }
        }

        public bool IsDelete { get; set; }

        public virtual Grade Grade { get; set; } = null!;
        public virtual ICollection<StudentsAuthentication> StudentsAuthentications { get; set; } = new List<StudentsAuthentication>();
        public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();

        public string PrintStudent()
        {
            return $"{this.FirstName} {this.SecondName} {this.FamilyName}";
        }
        public string PrintStudentInfo()
        {
            return $"{this.DateOfBirth}.{this.MonthOfBirth}.{this.YearOfBirth}; {this.Gender}; {this.City}, {this.Country}";
        }

        public int CompareTo([AllowNull] Student other)
        {
            int result = this.FirstName.CompareTo(other.FirstName);
            if (result == 0)
            {
                result = this.FamilyName.CompareTo(other.FamilyName);
            }
            if (result == 0)
            {
                result = this.SecondName.CompareTo(other.SecondName);
            }
            return result;
        }
    }
}