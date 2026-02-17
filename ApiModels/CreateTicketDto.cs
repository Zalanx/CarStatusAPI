using CarStatusAPI.DbModels.Enums;

namespace CarStatusAPI.ApiModels
{
    public class CreateTicketDto
    {
        public required int UserId { get; set; }
        public required string CustomerName { get; set; }

        public required string Car { get; set; }

        public CarStatusEnum CarStatus { get; set; }

        public required List<ToDoDto> ToDos { get; set; }
    }
}
