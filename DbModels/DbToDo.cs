using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CarStatusAPI.Models;

namespace CarStatusAPI.DbModels
{
    public class DbToDos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Todo { get; set; }

        [Required]
        public bool done { get; set; }

        public int DbTicketId { get; set; }

        [ForeignKey(nameof(DbTicketId))]
        public DbTicket Ticket { get; set; }

    }
}
