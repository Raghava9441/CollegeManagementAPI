using CollegeManagementAPI.Models;
using CollegeManagementAPI.Services.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CollegeManagementAPI.Services
{
    public class StudentService:IStudentService
    {
        private readonly IMongoCollection<Student> _StudentCollection;
        private readonly IOptions<DatabaseSettings> _dbSettings;

        public StudentService(IOptions<DatabaseSettings> dbSettings)
        {
            _dbSettings = dbSettings;
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _StudentCollection = mongoDatabase.GetCollection<Student>(dbSettings.Value.StudentCollectionName);
        }

        public async Task<IEnumerable<Student>> GetAllAsyc() =>
            await _StudentCollection.Find(_ => true).ToListAsync();

        public async Task<Student> GetById(string id) =>
            await _StudentCollection.Find(a => a.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Student student) =>
            await _StudentCollection.InsertOneAsync(student);

        public async Task UpdateAsync(string id, Student student) =>
            await _StudentCollection
            .ReplaceOneAsync(a => a.Id == id, student);

        public async Task DeleteAysnc(string id) =>
            await _StudentCollection.DeleteOneAsync(a => a.Id == id);
    }
}
