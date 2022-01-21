using System.Collections.Generic;
using System.Threading.Tasks;
using UsersService.Models;

namespace UsersService.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<Users>> GetAllUsers();
        Task Create(Users todo);
        Task<long> GetNextId();

    }
}
