using Microsoft.EntityFrameworkCore;
using footballClubMass.Models;

namespace footballClubMass.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Employer> Employers { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}