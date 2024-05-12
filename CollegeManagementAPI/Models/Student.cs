using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CollegeManagementAPI.Models
{
    public class Student:BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string RegistrationNumber { get; set; }
        public float Fee { get; set; }
        public float PendingFee { get; set; }
        public string Course { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Parent> Parents { get; set; }
    }
}
