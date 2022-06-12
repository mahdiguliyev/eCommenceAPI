using eCommenceAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace eCommenceAPI.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<eCommenceAPIDbContext>
    {
        public eCommenceAPIDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<eCommenceAPIDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
