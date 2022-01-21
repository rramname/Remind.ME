using System.Collections.Generic;
using System.Threading.Tasks;
using BirthdayService.Models;

namespace BirthdayService.Repository
{
    public interface IBirthdayRepository
    {
        Task<IEnumerable<Birthday>> GetAllUsers();
        Task Create(Birthday todo);
        Task<long> GetNextId();

    }
}
