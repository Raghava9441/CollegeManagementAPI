using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CollegeManagementAPI.Models
{
    public class Teacher:BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string OrganizationId { get; set; }
        public string Subject { get; set; }
        public string FirtName { get; set; }
        public string lastname { get; set; }
        public string Age { get; set; }
        public string Experience { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
