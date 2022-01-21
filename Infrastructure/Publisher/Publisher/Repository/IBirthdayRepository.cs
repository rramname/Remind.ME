using System.Collections.Generic;
using System.Threading.Tasks;
using Publisher.Models;

namespace PublisherService.Repository
{
    public interface IBirthdayRepository
    {
        List<Birthday> GetAll();
        Task<long> GetNextId();

    }
}
