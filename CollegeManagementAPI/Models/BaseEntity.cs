namespace CollegeManagementAPI.Models
{
    public class BaseEntity
    {
        public long AddedBy { get; set; }
        public long EditBy { get; set; }
        public DateTimeOffset AddedDate { get; set; }
        public DateTimeOffset EditedDate { get; set; }
        public Boolean IsDeleted { get; set; }
    }
}
