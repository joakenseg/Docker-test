using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebDockerTest.Models;

namespace WebDockerTest.Services
{
    public interface IUserService
    {
        Task<List<Users>> GetAsync();
        Task<Users> GetAsync(string id);
        Task CreateAsync(Users newUser);
        Task RemoveAsync(string id);
    }

    public class UserService : IUserService
    {
        private readonly IMongoCollection<Users> _users;

        public UserService(IMongoClient mongoClient, IOptions<MongoDbSettings> settings)
        {
            var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
            _users = database.GetCollection<Users>("users");
        }

        public async Task<List<Users>> GetAsync() =>
            await _users.Find(user => true).ToListAsync();

        public async Task<Users> GetAsync(string id) =>
            await _users.Find(user => user.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Users newUser) =>
            await _users.InsertOneAsync(newUser);

        public async Task RemoveAsync(string id) =>
            await _users.DeleteOneAsync(user => user.Id == id);
    }
}
