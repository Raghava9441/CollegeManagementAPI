using CollegeManagementAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CollegeManagementAPI.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IMongoCollection<Teacher> _TeacherCollection;
        private readonly IOptions<DatabaseSettings> _dbSettings;

        public TeacherService(IOptions<DatabaseSettings> dbSettings)
        {
            _dbSettings = dbSettings;
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _TeacherCollection = mongoDatabase.GetCollection<Teacher>(dbSettings.Value.TeachersCollectionName);
        }

        public async Task<IEnumerable<Teacher>> GetAllAsyc() =>
            await _TeacherCollection.Find(_ => true).ToListAsync();

        public async Task<Teacher> GetById(string id) =>
            await _TeacherCollection.Find(a => a.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Teacher teacher) =>
            await _TeacherCollection.InsertOneAsync(teacher);

        public async Task UpdateAsync(string id, Teacher teacher) =>
            await _TeacherCollection
            .ReplaceOneAsync(a => a.Id == id, teacher);

        public async Task DeleteAysnc(string id) =>
            await _TeacherCollection.DeleteOneAsync(a => a.Id == id);
    }
}
