using System.ComponentModel.DataAnnotations;

namespace CarStatusAPI.Models
{
    public class DbTicket
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public int Ticketnumber { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(30)]
        public string Car {  get; set; }

        [Required]
        [StringLength(30)]
        public string CarStatus { get; set; }

        [Required]
        public List<string> ToDos { get; set; }
    }
}
