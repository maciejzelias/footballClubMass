using Microsoft.EntityFrameworkCore;
using footballClubMass.Models;

namespace footballClubMass.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<SetPieceCoach> setPieceCoaches { get; set; }
        public DbSet<MotorCoach> motorCoaches { get; set; }

        public DbSet<PlayerContract> playerContracts { get; set; }
        public DbSet<CoachContract> coachContracts { get; set; }
        public DbSet<Page> pages { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=my-db-file.db");
            }
        }
    }

}