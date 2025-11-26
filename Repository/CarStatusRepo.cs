using CarStatusAPI.ApiModels;
using CarStatusAPI.Interface;
using CarStatusAPI.Models;

namespace CarStatusAPI.Repository
{
    public class CarStatusRepo(CarStatusDbContext dbContext) : ICarStatus
    {
        public Task<List<Ticket>> GetAlTickets()
        {
            List<Ticket> tickets = new List<Ticket>();

            foreach (var ticket in dbContext.DbTickets)
            {
                var newticket = new Ticket()
                {
                    Car = ticket.Car,
                    CarStatus = ticket.CarStatus,
                    CustomerName = ticket.CustomerName,
                    ToDos = ticket.ToDos
                };

                tickets.Add(newticket);
                return tickets;
            }
        }

        public Task<Ticket> GetTicket(int ticketId)
        {
            throw new NotImplementedException();
        }

        public Task<Ticket> CreateNewTicket()
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
