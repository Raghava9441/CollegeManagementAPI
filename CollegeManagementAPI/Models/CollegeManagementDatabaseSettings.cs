namespace CollegeManagementAPI.Models
{
    public class CollegeManagementDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string OrganizationCollectionName { get; set; } = null!;
        public string TeacherCollectionName { get; set; } = null!;
        public string StudentsCollectionName { get; set; } = null!;
        public string ParentCollectionName { get; set; } = null!;

    }
}
