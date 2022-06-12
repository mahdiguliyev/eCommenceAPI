using eCommenceAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace eCommenceAPI.Application.IRepositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
