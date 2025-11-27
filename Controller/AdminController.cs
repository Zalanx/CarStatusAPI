using CarStatusAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CarStatusAPI.Controller
{
    [Route("api/CarStatus")]
    [ApiController]
    public class AdminController(CarStatusRepo repo) : ControllerBase
    {
        [HttpPost("ResetTicketNumbers")]
        public async Task ResetTicketNumbers()
        {
            await repo._ResetTicketNumbers();
        }
    }
}
