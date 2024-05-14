using CollegeManagementAPI.Models;
using CollegeManagementAPI.Services.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CollegeManagementAPI.Services
{
    public class ParentService:IParentService
    {
        private readonly IMongoCollection<Parent> _parentCollection;
        private readonly IOptions<DatabaseSettings> _dbSettings;

        public ParentService(IOptions<DatabaseSettings> dbSettings)
        {
            _dbSettings = dbSettings;
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _parentCollection = mongoDatabase.GetCollection<Parent>(dbSettings.Value.ParentCollectionName);
        }

        public async Task<IEnumerable<Parent>> GetAllAsyc() =>
            await _parentCollection.Find(_ => true).ToListAsync();

        public async Task<Parent> GetById(string id) =>
            await _parentCollection.Find(a => a.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Parent parent) =>
            await _parentCollection.InsertOneAsync(parent);

        public async Task UpdateAsync(string id, Parent parent) =>
            await _parentCollection
            .ReplaceOneAsync(a => a.Id == id, parent);

        public async Task DeleteAysnc(string id) =>
            await _parentCollection.DeleteOneAsync(a => a.Id == id);
    }
}
