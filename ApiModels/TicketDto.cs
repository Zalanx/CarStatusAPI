using CarStatusAPI.DbModels.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarStatusAPI.ApiModels
{
    public class TicketDto
    {
        [BindNever]
        public string? Ticketnumber { get; set; }

        public required string CustomerName { get; set; }

        public required string Car { get; set; }

        public CarStatusEnum CarStatus { get; set; }

        public required List<string> ToDos { get; set; }
    }
}
