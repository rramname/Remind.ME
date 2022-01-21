using System.Collections.Generic;
    using System.Threading.Tasks;
    using MongoDB.Driver;
    using MongoDB.Bson;
    using System.Linq;
    using UsersService.Models;
using UsersService.Repository;

namespace UsersService{
    public class UsersRepository : IUserRepository
    {
        private readonly UsersContext _context;
        public UsersRepository(UsersContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Users>> GetAllUsers()
        {
            return await _context
                            .Users
                            .Find(_ => true)
                            .ToListAsync();
        }

        public async Task Create(Users todo)
        {
            await _context.Users.InsertOneAsync(todo);
        }
        public async Task<long> GetNextId()
        {
            return await _context.Users.CountDocumentsAsync(new BsonDocument()) + 1;
        }

    }
}