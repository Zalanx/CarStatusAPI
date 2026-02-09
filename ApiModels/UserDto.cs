using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CarStatusAPI.ApiModels
{
    public class UserDto
    {
        [JsonIgnore]
        public string CustomerName { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        [JsonIgnore]
        public bool IsAdmin { get; set; }
    }
}
