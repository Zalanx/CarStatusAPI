using CarStatusAPI.Models;
using CarStatusAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CarStatusAPI.Controller
{

    [Route("api/CarStatus")]
    [ApiController]
    public class CarStatusController(CarStatusRepo repo) : ControllerBase
    {

        [HttpGet("GetAllTickets")]
        public async Task GetSalesOrders()
        {
            await repo.GetAlTickets();
        }


        [HttpGet("GetTicketById")]
        public async Task GetTicket(int ticketId)
        {
            await repo.GetTicket(ticketId);
        }

        [HttpPost("CreateTicket")]
        public async Task CreateNewTicket()
        {
            await repo.CreateNewTicket();
        }

        [HttpPost("LoginUser")]
        public async Task LoginUser(DbUser user)
        {
            await repo.LoginUser(user);
        }

        [HttpPost("RegisterUser")]
        public async Task RegisterNewUser(DbUser user)
        {
            await repo.RegisterNewUser(user);
        }

    }
}
