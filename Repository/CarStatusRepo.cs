using AutoMapper;
using CarStatusAPI.ApiModels;
using CarStatusAPI.Interface;
using CarStatusAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarStatusAPI.Repository
{
    public class CarStatusRepo(CarStatusDbContext dbContext, IMapper mapper) : ICarStatus
    {
        public async Task<List<Ticket>> GetAlTickets()
        {
            var dbTicket = dbContext.DbTickets.ToListAsync();

            return mapper.Map<List<Ticket>>(dbTicket);
        }

        public async Task<Ticket> GetTicket(int ticketId)
        {

            //Hier fehlt die Id -> AutoMapper 

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
    }
}
