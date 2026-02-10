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
        private DbUser loggedInUser;

        public async Task<List<TicketDto>> GetAllTickets()
        {
            var dbTickets = await dbContext.DbTickets.ToListAsync();

            foreach (var ticket in dbTickets)
            {
                ticket.ToDos = await dbContext.DbToDos.Where(t => t.DbTicketId == ticket.Id).ToListAsync();
            }

            
            return mapper.Map<List<TicketDto>>(dbTickets);
        }

        public async Task<TicketDto> GetTicket(string ticketNumber)
        {
            var dbTicket = await dbContext.DbTickets.FirstOrDefaultAsync(t => t.Ticketnumber == ticketNumber) ?? throw new Exception("No ticket found with this Ticket number");

            return mapper.Map<TicketDto>(dbTicket);
        }

        public async Task<List<TicketDto>> GetTicketsForUserById(int userId)
        {
            List<TicketDto> returnableList = new();

            var loggedInUser = await dbContext.DbUsers.FirstOrDefaultAsync(u => u.Id == userId) ?? throw new KeyNotFoundException("User not found, wrong ID");

            var ticketsForUser = await dbContext.DbTickets.Where(t => t.UserId == loggedInUser.Id)
                .Include(dbTicket => dbTicket.ToDos).ToListAsync();

            foreach (var ticket in ticketsForUser)
            {
                var returnableTicket = new TicketDto()
                {
                    Ticketnumber = ticket.Ticketnumber,
                    Car = ticket.Car,
                    CustomerName = ticket.CustomerName,
                    CarStatus = ticket.CarStatus,
                    UserId = ticket.UserId,
                    ToDos = ticket.ToDos.Select(t => new ToDoDto()
                    {
                        Task = t.Todo,
                        Done = t.done,
                    }).ToList()
                };

                returnableList.Add(returnableTicket);
            }

            return returnableList;
        }

        public async Task<TicketDto> CreateNewTicket(CreateTicketDto ticket)
        {
            var toDoDtoList = new List<ToDoDto>();

            var newTicketNumber = await helper.NewTicketNumber();

            foreach (var todo in ticket.ToDos)
            {
                var newTodo = new ToDoDto()
                {
                    Done = todo.Done,
                    Task = todo.Task
                };

                toDoDtoList.Add(newTodo);
            }

            var createdTicket = new TicketDto()
            {
                Ticketnumber = newTicketNumber,
                CustomerName = ticket.CustomerName,
                Car = ticket.Car,
                CarStatus = CarStatusEnum.Warteschlange,
                ToDos = toDoDtoList,
                UserId = loggedInUser.Id // noch gedanken machen ob funktion die mein wert ändert 
            };

            var CreatedDbTicket = mapper.Map<DbTicket>(createdTicket);


            dbContext.DbTickets.Add(CreatedDbTicket);
            await dbContext.SaveChangesAsync();

            return createdTicket;
        }

        public async Task<TicketDto> UpdateTicket(string ticketnumber, CarStatusEnum newCarStatus, List<ToDoDto> todos, string? car, string? customerName)
        {
            List<DbToDos> dbToDos = new();

            var dbTicket = await dbContext.DbTickets.FirstOrDefaultAsync(t => t.Ticketnumber == ticketnumber) ?? throw new Exception($"Ticket not found with ticketnumber {ticketnumber}");

            foreach (var todo in todos)
            {
                var dbToDoModel = new DbToDos()
                {
                    DbTicketId = dbTicket.Id,
                    done = todo.Done

                };

                dbToDos.Add(dbToDoModel);
            }

            

            dbTicket.CarStatus = newCarStatus;
            dbTicket.Car = car ?? dbTicket.Car;
            dbTicket.CustomerName = customerName ?? dbTicket.CustomerName;
            dbTicket.ToDos = dbToDos;
            await dbContext.SaveChangesAsync();

            return mapper.Map<TicketDto>(dbTicket);
        }

        public async Task<DbUser> LoginUser(UserDto user)
        {
            var dbUser = await dbContext.DbUsers.FirstOrDefaultAsync(u => u.Username == user.Username) ??
                         throw new Exception("No User found. Wrong Username");

            var isCorrectPassword = helper.CompareHashedPasswords(user.Password, dbUser.Password,
                Convert.FromBase64String(dbUser.Salt!));

            if (isCorrectPassword == false)
            {
                throw new Exception("Wrong password");
            }

            loggedInUser = dbUser;
            return dbUser;
        }

        public async Task RegisterNewUser(UserDto user)
        {
            var existingUser = await dbContext.DbUsers.FirstOrDefaultAsync(u => u.Username == user.Username);
            if (existingUser != null)
            {
                throw new Exception("Username already exists");
            }

            if (string.IsNullOrWhiteSpace(user.Password))
            {
                throw new Exception("You need a password to register");
            }

            var salt = helper.GenerateSalt();



            var newUser = new UserDto()
            {
                CustomerName = user.CustomerName,
                Username = user.Username,
                Password = Convert.ToBase64String(helper.HashPassword(user.Password, salt)),
                IsAdmin = false,
            };

            var newDbUser = mapper.Map<DbUser>(newUser);

            newDbUser.Salt = Convert.ToBase64String(salt);

            dbContext.Add(newDbUser);
            await dbContext.SaveChangesAsync();

        }

    }
}
