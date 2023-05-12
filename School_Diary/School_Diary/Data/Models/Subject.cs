using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Diary.Data.Models
{
    internal class Subject
    {
        private string subjectName;

        public int SubjectId { get; set; }

        public int StudentId { get; set; }

        public string SubjectName
        {
            get
            {
                return this.subjectName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Subject cannot be empty!");
                }
                if (!char.IsUpper(value[0]))
                {
                    throw new ArgumentException("The first letter on subject name cannot be lower!");
                }
                if (value.Length < 2)
                {
                    throw new ArgumentException("Subject name is too short! It should be at least 2 letters.");
                }
                if (value.Length > 50)
                {
                    throw new ArgumentException("Subject name is too long! It should be a maximum of 50 letters.");
                }
                for (int i = 0; i < value.Length; i++)
                {
                    if (!char.IsLetter(value[i]) && value[i] != ' ')
                    {
                        throw new ArgumentException("Subject name should be in letters only!");
                    }
                }
                this.subjectName = value;
            }
        }

        public bool IsDelete { get; set; }

        public virtual ICollection<Mark> Marks { get; set; } = new List<Mark>();

        public virtual Student Student { get; set; } = null!;
    }
}
