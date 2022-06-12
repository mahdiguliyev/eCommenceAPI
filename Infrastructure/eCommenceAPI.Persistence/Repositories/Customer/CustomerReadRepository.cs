using eCommenceAPI.Application.IRepositories;
using eCommenceAPI.Domain.Entities;
using eCommenceAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommenceAPI.Persistence.Repositories
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(eCommenceAPIDbContext context) : base(context)
        {
        }
    }
}
