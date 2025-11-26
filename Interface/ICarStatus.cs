using CarStatusAPI.Models;

namespace CarStatusAPI.Interface
{
    public interface ICarStatus
    {
        Task<List<DbTicket>> GetAlTickets();
        Task<DbTicket> GetTicket(int ticketId);
        Task<DbTicket> CreateNewTicket();

        Task<DbUser> LoginUser(string username, string password);
        Task<DbUser> RegisterNewUser(string Username, string Password);

        


    }S
}
