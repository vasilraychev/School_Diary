namespace School_Diary.Data.Models
{
    public class StudentsAuthentication
    {
        private string studentAuthenticationUsername;
        private string studentAuthenticationPassword;

        public int StudentAuthenticationId { get; set; }

        public int StudentId { get; set; }

        public string StudentAuthenticationUsername
        {
            get
            {
                return this.studentAuthenticationUsername;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Username cannot be empty!");
                }
                if (value.Length < 4)
                {
                    throw new ArgumentException("Username is too short! It should be at least 4 symbols.");
                }
                if (value.Length > 20)
                {
                    throw new ArgumentException("Username is too long! It should be a maximum of 20 symbols.");
                }
                this.studentAuthenticationUsername = value;
            }
        }

        public string StudentAuthenticationPassword
        {
            get
            {
                return this.studentAuthenticationPassword;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Password cannot be empty!");
                }
                if (value.Length < 6)
                {
                    throw new ArgumentException("Password is too short! It should be at least 6 symbols.");
                }
                if (value.Length > 25)
                {
                    throw new ArgumentException("Password is too long! It should be a maximum of 25 symbols.");
                }
                this.studentAuthenticationPassword = value;
            }
        }

        public bool IsDelete { get; set; }

        public virtual Student Student { get; set; } = null!;

        public string PrintStudentAuthentication()
        {
            return $"Username: {this.StudentAuthenticationUsername}";
        }
    }
}