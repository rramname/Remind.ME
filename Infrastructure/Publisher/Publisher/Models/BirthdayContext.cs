using System;
using MongoDB.Driver;
using Publisher;
using Publisher.Models;

namespace PublisherService.Models
{
    public class BirthdayContext
    {
        private readonly IMongoDatabase _db;
        public BirthdayContext(IServiceProvider provider)
        {
            var config = (Configurations)provider.GetService(typeof(Configurations));

            var client = new MongoClient(config.MongoDB.ConnectionString);
            _db = client.GetDatabase(config.MongoDB.Database);
        }
        public IMongoCollection<Birthday> Records => _db.GetCollection<Birthday>("Birthday");
    }
}