using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICommoditiesDbContext
    {
        DbSet<DailyMetrics> DailyMetrics { get; set; }
        DbSet<ModelCommodity> ModelCommodities { get; set; }
        //DbSet<Model> Model { get; set; }

        Task<int> SaveChangesAsync();
    }
}
