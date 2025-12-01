using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarStatusAPI.ApiModels
{
    public class User
    {
        public required string CustomerName { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }

        [JsonIgnore]
        public bool IsAdmin { get; set; }
    }
}
