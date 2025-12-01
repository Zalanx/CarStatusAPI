using CarStatusAPI.ApiModels;
using CarStatusAPI.Models;

namespace CarStatusAPI.Interface
{
    public interface ICarStatus
    {
        Task<List<Ticket>> GetAllTickets();
        Task<Ticket> GetTicket(string ticketId);
        Task<DbTicket> CreateNewTicket(Ticket ticket);

        Task<Ticket> UpdateTicket(Ticket ticket);

        Task<DbUser> LoginUser(DbUser user);
        Task<DbUser> RegisterNewUser(DbUser user);

        Task ResetTicketNumbers();
    }
}
