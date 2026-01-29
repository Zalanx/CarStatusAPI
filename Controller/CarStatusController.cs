using CarStatusAPI.ApiModels;
using CarStatusAPI.DbModels.Enums;
using CarStatusAPI.Interface;
using CarStatusAPI.Models;
using CarStatusAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CarStatusAPI.Controller
{

    [Route("api/CarStatus")]
    [ApiController]
    public class CarStatusController(ICarStatus repo) : ControllerBase
    {

        [HttpGet("GetAllTickets")]
        public async Task<List<TicketDto>> GetAllTickets()
        {
           return await repo.GetAllTickets();
        }


        [HttpGet("GetTicketById")]
        public async Task<TicketDto> GetTicket(string ticketId)
        {
            return await repo.GetTicket(ticketId);
        }

        [HttpPost("CreateTicket")]
        public async Task<TicketDto> CreateNewTicket(CreateTicketDto ticket)
        {
            return await repo.CreateNewTicket(ticket);
        }

        [HttpPost("LoginUser")]
        public async Task<DbUser> LoginUser(UserDto user)
        {
            return await repo.LoginUser(user);
        }

        [HttpPost("RegisterUser")]
        public async Task RegisterNewUser(UserDto user)
        { 
            await repo.RegisterNewUser(user);
        }

        [HttpPatch("UpdateTicket")]
        public async Task<TicketDto> UpdateTicket(string ticketnumber, CarStatusEnum newCarStatus,  List<ToDoDto> todos, string car, string customerName)
        {
            return await repo.UpdateTicket(ticketnumber, newCarStatus, todos, car, customerName);
        }


    }
}
