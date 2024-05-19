using CollegeManagementAPI.Models;
using CollegeManagementAPI.Services.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Security.Cryptography;
using System.Text;

namespace CollegeManagementAPI.Services
{
    public class Userservice : IUserService
    {
        private readonly IMongoCollection<User> _userCollection;
        private readonly IOptions<DatabaseSettings> _dbSettings;

        public Userservice(IOptions<DatabaseSettings> dbSettings)
        {
            _dbSettings = dbSettings;
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _userCollection = mongoDatabase.GetCollection<User>(dbSettings.Value.UserCollectionName);
        }

        public async Task<User> Authenticate(string email, string password)
        {
            var user = await _userCollection.Find(u => u.Email == email).FirstOrDefaultAsync();
            if (user == null || !VerifyPasswordHash(password, user.PasswordHash))
                return null;

            return user;
        }
        public async Task<User> GetById(string id)
        {
            return await _userCollection.Find(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<User> Register(User user, string password)
        {
            if (await _userCollection.Find(u => u.Email == user.Email).AnyAsync())
                throw new ApplicationException("Username already exists");

            user.PasswordHash = CreatePasswordHash(password);
            await _userCollection.InsertOneAsync(user);
            return user;
        }

        private string CreatePasswordHash(string password)
        {
            using var hmac = new HMACSHA512();
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hash);
        }

        private bool VerifyPasswordHash(string password, string storedHash)
        {
            using var hmac = new HMACSHA512();
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hash) == storedHash;
        }
    }
}
