using System.ComponentModel.DataAnnotations;

namespace CarStatusAPI.ApiModels
{
    public class Ticket
    {
        [Required]
        public int Ticketnumber { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string Car { get; set; }

        [Required]
        public string CarStatus { get; set; }

        [Required]
        public List<string> ToDos { get; set; }
    }
}
