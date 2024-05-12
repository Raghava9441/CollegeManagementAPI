namespace CollegeManagementAPI.Models
{
    public class DatabaseSettings
    {
        public string? ConnectionString { get; set; }
        public string? DatabaseName { get; set; }
        public string? OrganizationsCollectionName { get; set; }
        public string? TeachersCollectionName { get; set; }
    }
}
