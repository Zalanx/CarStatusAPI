using AutoMapper;
using CarStatusAPI.ApiModels;
using CarStatusAPI.DbModels;
using CarStatusAPI.DbModels.Enums;
using CarStatusAPI.Interface;
using CarStatusAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarStatusAPI.Repository
{
    public class CarStatusRepo(CarStatusDbContext dbContext, IMapper mapper, CarStatusRepoHelper helper) : ICarStatus
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

            var newTicketNumber = await helper.NewTicketNumber();

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

        public async Task<DbUser> LoginUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task RegisterNewUser(User user)
        {
            var existingUser = dbContext.DbUsers.FirstOrDefaultAsync(u => u.Username == user.Username);
            if (existingUser != null)
            {
                throw new Exception("Username already exists");
            }

            if (string.IsNullOrWhiteSpace(user.Password))
            {
                throw new Exception("You need a password to register");
            }

            var salt = helper.GenerateSalt();

            var newUser = new User()
            {
                CustomerName = user.CustomerName,
                Username = user.Username,
                Password = Convert.ToBase64String(helper.HashPassword(user.Password,salt)),
                IsAdmin = false,
            };

            await dbContext.SaveChangesAsync();


        }

        

    }
}
