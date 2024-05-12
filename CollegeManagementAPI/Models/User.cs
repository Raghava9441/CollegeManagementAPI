namespace CollegeManagementAPI.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public UserRole Role { get; set; } 
    }
    public enum UserRole
    {
        Admin,
        Teacher,
        Student,
        Parent
    }
}
