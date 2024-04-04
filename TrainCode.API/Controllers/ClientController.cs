using Microsoft.AspNetCore.Mvc;
using TrainCode.App.Client;

using TrainCode.Domain.Entities;

namespace TrainCode.API.Controllers
{
    [Route("api/[controller]")] // /api/Client
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            var clients = await _clientService.GetClientList();

            return Ok(clients);
        }
    }
}
