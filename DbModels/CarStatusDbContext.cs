using CarStatusAPI.DbModels;
using Microsoft.EntityFrameworkCore;

namespace CarStatusAPI.Models
{
    public class CarStatusDbContext : DbContext
    {

        public CarStatusDbContext(DbContextOptions<CarStatusDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=NB0432\\SQLEXPRESS;Database=CarStatusDb;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        } 

        public DbSet<DbTicket> DbTickets { get; set; }
        public DbSet<DbUser> DbUsers { get; set; }
        public DbSet<DbTicketnumber> DbTicketNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbTicket>()
                .Property(t => t.CarStatus)
                .HasConversion<string>();
        }

    }
}
