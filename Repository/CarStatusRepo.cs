using CarStatusAPI.Interface;
using CarStatusAPI.Models;

namespace CarStatusAPI.Repository
{
    public class CarStatusRepo : ICarStatus
    {
        public Task<List<DbTicket>> GetAlTickets()
        {
            throw new NotImplementedException();
        }

        public Task<DbTicket> GetTicket(int ticketId)
        {
            throw new NotImplementedException();
        }

        public Task<DbTicket> CreateNewTicket()
        {
            throw new NotImplementedException();
        }

        public Task<DbUser> LoginUser(DbUser user)
        {
            throw new NotImplementedException();
        }

        public Task<DbUser> RegisterNewUser(DbUser user)
        {
            throw new NotImplementedException();
        }
    }
}
