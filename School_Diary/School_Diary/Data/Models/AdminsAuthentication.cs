namespace School_Diary.Data.Models
{
    public class AdminsAuthentication
    {
        public int AdminId { get; set; }

        public string AdminUsername { get; set; } = null!;

        public string AdminPassword { get; set; } = null!;
    }
}
