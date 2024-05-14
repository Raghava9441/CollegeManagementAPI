using CollegeManagementAPI.Models;
using CollegeManagementAPI.Services.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CollegeManagementAPI.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IMongoCollection<Organization> _OrganizationCollection;
        private readonly IOptions<DatabaseSettings> _dbSettings;

        public OrganizationService(IOptions<DatabaseSettings> dbSettings)
        {
            _dbSettings = dbSettings;
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _OrganizationCollection = mongoDatabase.GetCollection<Organization>(dbSettings.Value.OrganizationsCollectionName);
        }

        public async Task<IEnumerable<Organization>> GetAllAsyc() =>
            await _OrganizationCollection.Find(_ => true).ToListAsync();

        public async Task<Organization> GetById(string id) =>
            await _OrganizationCollection.Find(a => a.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Organization Category) =>
            await _OrganizationCollection.InsertOneAsync(Category);

        public async Task UpdateAsync(string id, Organization Category) =>
            await _OrganizationCollection
            .ReplaceOneAsync(a => a.Id == id, Category);

        public async Task DeleteAysnc(string id) =>
            await _OrganizationCollection.DeleteOneAsync(a => a.Id == id);
    }
}
