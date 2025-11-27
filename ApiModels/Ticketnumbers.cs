using System.ComponentModel.DataAnnotations;

namespace CarStatusAPI.ApiModels
{
    public class Ticketnumbers
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int ChangedDate { get; set; }

        [Required]
        public string Prefix { get; set; }

        
        
    }
}
