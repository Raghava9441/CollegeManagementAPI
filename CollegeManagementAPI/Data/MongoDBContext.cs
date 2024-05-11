using CollegeManagementAPI.Models;
using MongoDB.Driver;

namespace CollegeManagementAPI.Data
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _database;

        public MongoDBContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<Organization> Organizations => _database.GetCollection<Organization>("Organizations");
    }
}
