using AutoMapper;
using CarStatusAPI.ApiModels;
using CarStatusAPI.DbModels;
using CarStatusAPI.DbModels.Enums;
using CarStatusAPI.Interface;
using CarStatusAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarStatusAPI.Repository
{
    public class CarStatusRepo(CarStatusDbContext dbContext, IMapper mapper) : ICarStatus
    {

        public async Task<List<Ticket>> GetAllTickets()
        {
            var dbTicket = await dbContext.DbTickets.ToListAsync();

            return mapper.Map<List<Ticket>>(dbTicket);
        }

        public async Task<Ticket> GetTicket(int ticketNumber)
        {
            var dbTicket = await dbContext.DbTickets.FirstOrDefaultAsync(t => t.Ticketnumber == ticketNumber) ?? throw new Exception("No ticket found with this Ticket number");

            return mapper.Map<Ticket>(dbTicket);
        }

        public async Task<DbTicket> CreateNewTicket(Ticket ticket)
        {

            var createdTicket = new Ticket()
            {
                
                CustomerName = ticket.CustomerName,
                Car = ticket.Car,
                CarStatus = CarStatusEnum.Warteschlange,
                ToDos = new List<string>()
            };



            throw new NotImplementedException();
        }

        public async Task<Ticket> UpdateTicket(Ticket ticket)
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

        public async Task ResetTicketNumbers()
        {
            string prefix = "WT-";

            var newTicket = new Ticketnumber()
            {
                ChangedDate = DateTime.Now,
                Current_Ticketnumber = $"{prefix}20210",
                Prefix = prefix
            };

            var newDbTicket = mapper.Map<DbTicketnumber>(newTicket);
            dbContext.DbTicketNumbers.Add(newDbTicket);
            await dbContext.SaveChangesAsync();
        }
    }
}
