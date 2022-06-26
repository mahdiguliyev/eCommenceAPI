using eCommenceAPI.Application.IRepositories;
using eCommenceAPI.Domain.Entities;
using eCommenceAPI.Persistence.Contexts;

namespace eCommenceAPI.Persistence.Repositories
{
    public class ProductImageFileReadRepository : ReadRepository<ProductImageFile>, IProductImageFileReadRepository
    {
        public ProductImageFileReadRepository(eCommenceAPIDbContext context) : base(context)
        {
        }
    }
}
