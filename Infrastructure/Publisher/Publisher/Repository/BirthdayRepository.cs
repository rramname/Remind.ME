using System.Collections.Generic;
    using System.Threading.Tasks;
    using MongoDB.Driver;
    using MongoDB.Bson;
    
using Publisher.Models;
using PublisherService.Repository;
using System;
using PublisherService.Models;

namespace PublisherService{
    public class BirthdayRepository : IBirthdayRepository
    {
        private readonly BirthdayContext _context;
        public BirthdayRepository(IServiceProvider provider)
        {
            _context = (BirthdayContext)provider.GetService(typeof(BirthdayContext));
        }
        public List<Birthday> GetAll()
        {
            return  _context
                            .Records
                            .Find(_ => true)
                            .ToList();
        }

        public async Task Create(Birthday todo)
        {
            await _context.Records.InsertOneAsync(todo);
        }
        public async Task<long> GetNextId()
        {
            return await _context.Records.CountDocumentsAsync(new BsonDocument()) + 1;
        }

    }
}