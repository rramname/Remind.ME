using System.Collections.Generic;
    using System.Threading.Tasks;
    using MongoDB.Driver;
    using MongoDB.Bson;
    using System.Linq;
    using BirthdayService.Models;
using BirthdayService.Repository;

namespace BirthdayService{
    public class BirthdayRepository : IBirthdayRepository
    {
        private readonly BirthdayContext _context;
        public BirthdayRepository(BirthdayContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Birthday>> GetAllUsers()
        {
            return await _context
                            .Users
                            .Find(_ => true)
                            .ToListAsync();
        }

        public async Task Create(Birthday todo)
        {
            await _context.Users.InsertOneAsync(todo);
        }
        public async Task<long> GetNextId()
        {
            return await _context.Users.CountDocumentsAsync(new BsonDocument()) + 1;
        }

    }
}