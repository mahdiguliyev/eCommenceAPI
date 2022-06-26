using eCommenceAPI.Application.IRepositories;
using eCommenceAPI.Domain.Entities;
using eCommenceAPI.Persistence.Contexts;

namespace eCommenceAPI.Persistence.Repositories
{
    public class InvoiceFileWriteRepository : WriteRepository<InvoiceFile>, IInvoiceFileWriteRepository
    {
        public InvoiceFileWriteRepository(eCommenceAPIDbContext context) : base(context)
        {
        }
    }
}
