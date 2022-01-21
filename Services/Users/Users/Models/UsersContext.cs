using System;
using MongoDB.Driver;

namespace UsersService.Models
{
    public class UsersContext
    {
        private readonly IMongoDatabase _db;
        public UsersContext(MongoDBConfig config)
        {
            var client = new MongoClient(config.ConnectionString);
            _db = client.GetDatabase(config.Database);
        }
        public IMongoCollection<Users> Users => _db.GetCollection<Users>("Users");
    }
}