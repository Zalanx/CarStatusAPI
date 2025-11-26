using CarStatusAPI.Models;

namespace CarStatusAPI.Interface
{
    public interface ICarStatus
    {
        Task<List<DbTicket>> GetAlTickets();
        Task<DbTicket> GetTicket(int ticketId);
        Task<DbTicket> CreateNewTicket();

        Task<DbUser> LoginUser(DbUser user);
        Task<DbUser> RegisterNewUser(DbUser user);

    }
}
