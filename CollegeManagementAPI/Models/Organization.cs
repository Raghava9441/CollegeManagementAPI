using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CollegeManagementAPI.Models
{
    public class Organization:BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Adress { get; set; }
        public string Number { get; set; }
    }
}
