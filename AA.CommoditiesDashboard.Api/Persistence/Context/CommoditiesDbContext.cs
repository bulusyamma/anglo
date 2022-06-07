using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class CommoditiesDbContext : DbContext, ICommoditiesDbContext
    {
        public CommoditiesDbContext(DbContextOptions<CommoditiesDbContext> options)
            : base(options)
        {
        }

        public DbSet<DailyMetrics> DailyMetrics { get; set; }
        public DbSet<ModelCommodity> ModelCommodities { get; set; }

        ///TODO:
        //public new DbSet<User> User { get; set; }
        //public new DbSet<UserCredential> UserCredential { get; set; }

        public async Task<int> SaveChangesAsync() => await base.SaveChangesAsync();
    }
}
