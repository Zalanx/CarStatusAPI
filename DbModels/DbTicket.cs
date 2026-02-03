using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CarStatusAPI.ApiModels;
using CarStatusAPI.DbModels;
using CarStatusAPI.DbModels.Enums;

namespace CarStatusAPI.Models
{
    public class DbTicket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [StringLength(50)]
        public string Ticketnumber { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(30)]
        public string Car {  get; set; }

        [Required]
        public CarStatusEnum CarStatus { get; set; }
        
        public ICollection<DbToDos> ToDos { get; set; } = new List<DbToDos>();

    }
}
