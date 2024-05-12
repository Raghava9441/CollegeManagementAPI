using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CollegeManagementAPI.Models
{
    public class Organization:BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRequired]
        public string Name { get; set; }

        [BsonRequired]
        public string Category { get; set; }

        [BsonRequired]
        public string Address { get; set; }

        [BsonRequired]
        public string Number { get; set; }
    }
}
