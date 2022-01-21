using System;
using MongoDB.Driver;

namespace BirthdayService.Models
{
    public class BirthdayContext
    {
        private readonly IMongoDatabase _db;
        public BirthdayContext(MongoDBConfig config)
        {
            var client = new MongoClient(config.ConnectionString);
            _db = client.GetDatabase(config.Database);
        }
        public IMongoCollection<Birthday> Users => _db.GetCollection<Birthday>("Birthday");
    }
}