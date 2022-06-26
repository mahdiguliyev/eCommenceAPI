using eCommenceAPI.Application.IRepositories;
using eCommenceAPI.Domain.Entities;
using eCommenceAPI.Persistence.Contexts;

namespace eCommenceAPI.Persistence.Repositories
{
    public class InvoiceFileReadRepository : ReadRepository<InvoiceFile>, IInvoiceFileReadRepository
    {
        public InvoiceFileReadRepository(eCommenceAPIDbContext context) : base(context)
        {
        }
    }
}
