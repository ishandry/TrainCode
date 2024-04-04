using Microsoft.AspNetCore.Mvc;
using TrainCode.App;
using TrainCode.Domain.Entities;

namespace TrainCode.API.Controllers
{
    [Route("api/[controller]")] // /api/Coach
    [ApiController]
    public class CoachController : ControllerBase
    {
        private readonly ICoachService _coachService;
        public CoachController(ICoachService coachService)
        {
            _coachService = coachService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coach>>> GetCoaches()
        {
            var coaches = await _coachService.GetCoachesList();

            return Ok(coaches);
        }
    }
}
