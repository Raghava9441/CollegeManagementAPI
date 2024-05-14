using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using DnsClient.Internal;

namespace CollegeManagementAPI.Models
{
    public class Parent:BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Phonenumber { get; set; }
        public string Email { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> StudentIds { get; set; }
    }
}
