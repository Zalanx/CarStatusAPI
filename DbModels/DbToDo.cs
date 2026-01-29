using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarStatusAPI.DbModels
{
    public class DbToDos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Required]
        public int DbUserId { get; set; }
        [Required]
        public string Todo { get; set; }

        [Required]
        public bool done { get; set; }

    }
}
