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

        public async Task<Ticket> GetTicket(string ticketNumber)
        {
            var dbTicket = await dbContext.DbTickets.FirstOrDefaultAsync(t => t.Ticketnumber == ticketNumber) ?? throw new Exception("No ticket found with this Ticket number");

            return mapper.Map<Ticket>(dbTicket);
        }

        public async Task<DbTicket> CreateNewTicket(Ticket ticket)
        {

            var newTicketNumber = await NewTicketNumber();

            var createdTicket = new Ticket()
            {
                Ticketnumber = newTicketNumber,
                CustomerName = ticket.CustomerName,
                Car = ticket.Car,
                CarStatus = CarStatusEnum.Warteschlange,
                ToDos = ticket.ToDos
            };

            var CreatedDbTicket = mapper.Map<DbTicket>(createdTicket);


            dbContext.DbTickets.Add(CreatedDbTicket);
            await dbContext.SaveChangesAsync();

            return CreatedDbTicket;
        }

        public async Task<Ticket> UpdateTicket(string ticketnumber, CarStatusEnum newCarStatus)
        {
            var dbTicket = await dbContext.DbTickets.FirstOrDefaultAsync(t => t.Ticketnumber == ticketnumber) ?? throw new Exception($"Ticket not found with ticketnumber {ticketnumber}");

            dbTicket.CarStatus = newCarStatus;
            await dbContext.SaveChangesAsync();

            return mapper.Map<Ticket>(dbTicket);
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

        private async Task<String> NewTicketNumber()
        {
            var currentDbTicketNumber = await dbContext.DbTicketNumbers.FirstOrDefaultAsync() ?? throw new Exception("No Ticket");
            var currentTicketNumber = mapper.Map<Ticketnumber>(currentDbTicketNumber);

            var oldTicketNumber = currentTicketNumber.Current_Ticketnumber;
            var prefix = currentTicketNumber.Prefix;


            var replacedNumber = oldTicketNumber.Replace(prefix, "");
            int numberParse = int.Parse(replacedNumber);
            int newTicketNumber = numberParse + 1;

            var TicketNumber = $"{prefix}{newTicketNumber}";


            var dbTicketNumbers =  await dbContext.DbTicketNumbers.FirstOrDefaultAsync();
            dbTicketNumbers!.Current_Ticketnumber = TicketNumber;
            await dbContext.SaveChangesAsync();

            return TicketNumber;

        }

    }
}
