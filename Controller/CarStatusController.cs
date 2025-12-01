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
        public async Task<List<Ticket>> GetAllTickets()
        {
           return await repo.GetAllTickets();
        }


        [HttpGet("GetTicketById")]
        public async Task<Ticket> GetTicket(string ticketId)
        {
            return await repo.GetTicket(ticketId);
        }

        [HttpPost("CreateTicket")]
        public async Task<DbTicket> CreateNewTicket(Ticket ticket)
        {
            return await repo.CreateNewTicket(ticket);
        }

        [HttpPost("LoginUser")]
        public async Task<DbUser> LoginUser(User user)
        {
            return await repo.LoginUser(user);
        }

        [HttpPost("RegisterUser")]
        public async Task RegisterNewUser(User user)
        { 
            await repo.RegisterNewUser(user);
        }

        [HttpPatch("UpdateTicket")]
        public async Task<Ticket> UpdateTicket(string ticketnumber, CarStatusEnum newCarStatus)
        {
            return await repo.UpdateTicket(ticketnumber, newCarStatus);
        }


    }
}
