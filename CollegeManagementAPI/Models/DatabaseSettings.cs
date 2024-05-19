namespace CollegeManagementAPI.Models
{
    public class DatabaseSettings
    {
        public string? ConnectionString { get; set; }
        public string? DatabaseName { get; set; }
        public string? OrganizationsCollectionName { get; set; }
        public string? TeachersCollectionName { get; set; }
        public string? StudentCollectionName { get; set; }
        public string? ParentCollectionName { get; set; }
        public string? UserCollectionName { get; set; }

    }
}
