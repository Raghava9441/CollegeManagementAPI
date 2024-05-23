using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CollegeManagementAPI.Models
{
    public class User : BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public UserRole Role { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }

    public enum UserRole
    {
        Admin,
        Teacher,
        Student,
        Parent
    }
}
