using CarStatusAPI.ApiModels;
using CarStatusAPI.Models;

namespace CarStatusAPI.Interface
{
    public interface ICarStatus
    {
        Task<List<Ticket>> GetAlTickets();
        Task<Ticket> GetTicket(int ticketId);
        Task<Ticket> CreateNewTicket();

        Task<DbUser> LoginUser(DbUser user);
        Task<DbUser> RegisterNewUser(DbUser user);

    }
}
