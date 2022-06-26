using eCommenceAPI.Application.IRepositories;
using eCommenceAPI.Persistence.Contexts;

namespace eCommenceAPI.Persistence.Repositories
{
    public class FileWriteRepository : WriteRepository<eCommenceAPI.Domain.Entities.File>, IFileWriteRepository
    {
        public FileWriteRepository(eCommenceAPIDbContext context) : base(context)
        {
        }
    }
}
