using eCommenceAPI.Application.IRepositories;
using eCommenceAPI.Persistence.Contexts;

namespace eCommenceAPI.Persistence.Repositories
{
    public class FileReadRepository : ReadRepository<eCommenceAPI.Domain.Entities.File>, IFileReadRepository
    {
        public FileReadRepository(eCommenceAPIDbContext context) : base(context)
        {
        }
    }
}
