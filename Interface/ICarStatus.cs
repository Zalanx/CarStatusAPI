using CarStatusAPI.ApiModels;
using CarStatusAPI.DbModels.Enums;
using CarStatusAPI.Models;

namespace CarStatusAPI.Interface
{
    public interface ICarStatus
    {
        Task<List<TicketDto>> GetAllTickets();
        Task<TicketDto> GetTicket(string ticketNumber);
        Task<List<TicketDto>> GetTicketsForUserById(int userId);
        Task<int> GetUserIdByUsername(string username);
        Task<TicketDto> CreateNewTicket(CreateTicketDto ticket);
        Task<TicketDto> UpdateTicket(string ticketNumber, CarStatusEnum newCarStatus, List<ToDoDto> todo, string car, string customerName);
        Task<DbUser> LoginUser(UserDto user);
        Task RegisterNewUser(UserDto user);

    }
}
