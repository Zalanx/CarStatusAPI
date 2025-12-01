using CarStatusAPI.ApiModels;
using CarStatusAPI.DbModels.Enums;
using CarStatusAPI.Models;

namespace CarStatusAPI.Interface
{
    public interface ICarStatus
    {
        Task<List<Ticket>> GetAllTickets();
        Task<Ticket> GetTicket(string ticketId);
        Task<DbTicket> CreateNewTicket(Ticket ticket);

        Task<Ticket> UpdateTicket(string ticketnumber, CarStatusEnum newCarStatus);

        Task<DbUser> LoginUser(User user);
        Task<DbUser> RegisterNewUser(User user);

    }
}
