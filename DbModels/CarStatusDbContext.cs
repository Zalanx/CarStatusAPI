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
        public DbSet<DbUser> DbTicketNumbers { get; set; }


        //TODO: Hier noch ein update der Datenbank machen und die properties vom Ticketnumbers

    }
}
