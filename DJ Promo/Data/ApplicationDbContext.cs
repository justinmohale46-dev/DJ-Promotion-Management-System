using Microsoft.EntityFrameworkCore;
using DJ_Promo.Models;

namespace DJ_Promo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<DJ> DJ { get; set; }
        public DbSet<Venue> Venue { get; set; }
        public DbSet<Gig> Gig { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships exactly as in your SQL
            modelBuilder.Entity<Gig>()
                .HasOne(g => g.DJ)
                .WithMany(d => d.Gigs)
                .HasForeignKey(g => g.DJID);

            modelBuilder.Entity<Gig>()
                .HasOne(g => g.Venue)
                .WithMany(v => v.Gigs)
                .HasForeignKey(g => g.VenueID);
        }
    }
}