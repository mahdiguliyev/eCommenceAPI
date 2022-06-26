using eCommenceAPI.Application.IRepositories;
using eCommenceAPI.Domain.Entities;
using eCommenceAPI.Persistence.Contexts;

namespace eCommenceAPI.Persistence.Repositories
{
    public class ProductImageFileWriteRepository : WriteRepository<ProductImageFile>, IProductImageFileWriteRepository
    {
        public ProductImageFileWriteRepository(eCommenceAPIDbContext context) : base(context)
        {
        }
    }
}
