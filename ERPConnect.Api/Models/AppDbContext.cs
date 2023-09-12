using ERPConnect.Models.Entity_Tables;
using Microsoft.EntityFrameworkCore;

namespace ERPConnect.Api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {

        }
        public virtual DbSet<CompanyGroup> CompanyGroup { get; set; } = null!;
        public virtual DbSet<MenuItem> MenuItem { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
