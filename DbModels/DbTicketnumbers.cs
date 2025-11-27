using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarStatusAPI.DbModels
{
    public class DbTicketnumbers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime ChangedDate { get; set; }

        [Required]
        [StringLength(30)]
        public string Current_Ticketnumber { get; set; }

        [Required]
        [StringLength(10)]
        public string Prefix { get; set; }



    }
}
