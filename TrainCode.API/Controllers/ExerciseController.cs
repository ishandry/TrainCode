using Microsoft.AspNetCore.Mvc;
using TrainCode.App;
using TrainCode.App.DTOs;
using TrainCode.Domain.Entities;

namespace TrainCode.API.Controllers
{
    [Route("api/[controller]")] // /api/Exercises
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly IExerciseService _exrService;

        public ExercisesController(IExerciseService exrService)
        {
            _exrService = exrService;
        }

        [HttpPost]
        public async Task<ActionResult<Exercise>> CreateExercise(Guid coachId, DateTime due, string description, Guid clientId)
        {
            var newEx = await _exrService.CreateExercise(coachId, new NewExerciseDto(due, description, clientId));
            return newEx;
        }

        //mark as done
        [HttpPost("done/{id}")]
        public async Task<ActionResult<ClientExerciseDto>> MarkAsDone(Guid id)
        {
            var ex = await _exrService.MarkAsDone(id);
            if (ex is null)
            {
                throw new Exception("Exercise not found");
            } else
            {
                return ex;
            }
        }

        //get by id 
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientExerciseDto>> GetExerciseById(Guid id)
        {
            var ex = await _exrService.GetExerciseById(id);
            return Ok(ex);
        }

        //get by coach id
        [HttpGet("coach/{id}")]
        public async Task<ActionResult<IEnumerable<CoachExerciseDto>>> GetCoachExercises(Guid id)
        {
            var exs = await _exrService.GetCoachExercises(id);
            return Ok(exs);
        }
    }
}
