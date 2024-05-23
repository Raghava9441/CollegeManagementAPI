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
            if (user == null)
            {
                Console.WriteLine("User not found");
                return null;
            }

            var salt = Convert.FromBase64String(user.PasswordSalt);
            if (!VerifyPasswordHash(password, user.PasswordHash, salt))
            {
                Console.WriteLine("Password verification failed");
                return null;
            }

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

            var (hash, salt) = CreatePasswordHash(password);
            user.PasswordHash = hash;
            user.PasswordSalt = Convert.ToBase64String(salt); // Store the salt

            await _userCollection.InsertOneAsync(user);
            return user;

        }

        public async Task<string> GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public async Task<User> GetUserWithRefreshToken(string refreshToken)
        {
            return await _userCollection.Find(u => u.RefreshToken == refreshToken).FirstOrDefaultAsync();
        }

        public async Task RevokeRefreshToken(User user)
        {
            user.RefreshToken = null;
            user.RefreshTokenExpiryTime = DateTime.MinValue;
            await _userCollection.ReplaceOneAsync(u => u.Id == user.Id, user);
        }
        private (string PasswordHash, byte[] Salt) CreatePasswordHash(string password)
        {
            using var hmac = new HMACSHA512();
            var salt = hmac.Key;
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return (Convert.ToBase64String(hash), salt);
        }

        private bool VerifyPasswordHash(string password, string storedHash, byte[] salt)
        {
            using var hmac = new HMACSHA512(salt);
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hash) == storedHash;
        }

    }
}
