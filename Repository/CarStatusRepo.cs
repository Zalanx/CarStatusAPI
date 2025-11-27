using AutoMapper;
using CarStatusAPI.ApiModels;
using CarStatusAPI.DbModels;
using CarStatusAPI.Interface;
using CarStatusAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarStatusAPI.Repository
{
    public class CarStatusRepo(CarStatusDbContext dbContext, IMapper mapper) : ICarStatus
    {

        public async Task<List<Ticket>> GetAllTickets()
        {
            var dbTicket = dbContext.DbTickets.ToListAsync();

            return mapper.Map<List<Ticket>>(dbTicket);
        }

        public async Task<Ticket> GetTicket(int ticketNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<Ticket> CreateNewTicket()
        {
            throw new NotImplementedException();
        }

        public async Task<DbUser> LoginUser(DbUser user)
        {
            throw new NotImplementedException();
        }

        public async Task<DbUser> RegisterNewUser(DbUser user)
        {
            throw new NotImplementedException();
        }

        public async Task _ResetTicketNumbers()
        {
            string prefix = "WT-";

            var newTicket = new Ticketnumbers()
            {
                ChangedDate = DateTime.Now,
                Current_Ticketnumber = $"{prefix}20210",
                Prefix = prefix
            };

            var newDbTicket = mapper.Map<DbTicketnumbers>(newTicket);
            dbContext.DbTicketNumbers.Add(newDbTicket);
            await dbContext.SaveChangesAsync();
        }
    }
}
