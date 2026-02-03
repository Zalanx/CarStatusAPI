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
                optionsBuilder.UseSqlServer(
                    "Server=NB0432\\SQLEXPRESS;Database=CarStatusDb;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        // DbSets
        public DbSet<DbTicket> DbTickets { get; set; }
        public DbSet<DbUser> DbUsers { get; set; }
        public DbSet<DbTicketnumber> DbTicketNumbers { get; set; }
        public DbSet<DbToDos> DbToDos { get; set; } // 🔹 Add Todos DbSet

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ticket CarStatus als String speichern
            modelBuilder.Entity<DbTicket>()
                .Property(t => t.CarStatus)
                .HasConversion<string>();

            // 1:N Beziehung DbTicket -> DbToDos
            modelBuilder.Entity<DbToDos>()
                .HasOne(t => t.Ticket)           // jedes ToDo hat ein Ticket
                .WithMany(t => t.ToDos)          // ein Ticket hat viele Todos
                .HasForeignKey(t => t.DbTicketId) // FK Spalte in DbToDos
                .OnDelete(DeleteBehavior.Cascade); // optional: löscht Todos, wenn Ticket gelöscht wird

            base.OnModelCreating(modelBuilder);
        }
    }
}