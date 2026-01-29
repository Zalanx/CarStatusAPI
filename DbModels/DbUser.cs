using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using CarStatusAPI.DbModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CarStatusAPI.Models
{
    public class DbUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [JsonIgnore]
        public string? Salt { get; set; }

        [Required]
        public bool IsAdmin { get; set; }

        [Required]
        public List<ToDoDto> ToDos { get; set; }
    }
}
