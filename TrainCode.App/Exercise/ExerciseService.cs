namespace TrainCode.App.Exercise
{
    using Domain.Entities;
    using System.Threading.Tasks;
    using TrainCode.App.DTOs;
    using TrainCode.App.Repositories;
    public class ExerciseService: IExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IClientRepository _clientRepository;

        public ExerciseService(IExerciseRepository exerciseRepository, IClientRepository clientRepository)
        {
            _exerciseRepository = exerciseRepository;
            _clientRepository = clientRepository;
        }

        public async Task<Exercise> CreateExercise(Guid coachId, NewExerciseDto exercise)
        {
            Exercise newExx = new Exercise(
                Guid.NewGuid(),
                coachId,
                exercise.DueDate,
                exercise.Description,
                Domain.Enums.ExerciseStatus.Pending,
                exercise.ClientId
                );
            await _exerciseRepository.Create(newExx);
            return newExx;
        }

        public async Task<IEnumerable<CoachExerciseDto>> GetCoachExercises(Guid id)
        {
            var result = await _exerciseRepository.GetByCoachId(id);
            foreach (var exercise in result)
            {
                ValidateStatus(exercise);
            }
            return result.Select(e => new CoachExerciseDto(e));
        }

        public async Task<ClientExerciseDto?> GetExerciseById(Guid id)
        {
            var result = await _exerciseRepository.GetById(id);
            if (result is null)
            {
                throw new Exception("Exercise not found");
            }
            return new ClientExerciseDto(result);
        }

        public async Task<ClientExerciseDto?> MarkAsDone(Guid id)
        {
            var exercise = await _exerciseRepository.GetById(id);
            if (exercise is null)
            {
                return null;
            }

            var result = exercise.CompleteExercise();

            if (result.IsSuccess)
            {
                if (result.IsUpdated)
                {
                    await _exerciseRepository.Update(exercise);
                }
                return new ClientExerciseDto(exercise);
            }

            return null;

        }

        public async Task<Exercise> ValidateStatus(Exercise exercise)
        {
             var result = exercise.CheckExerciseExpiration();

             if (result.IsUpdated)
             {
                await _exerciseRepository.Update(exercise);
                
             }
            return exercise;
        }
    }
}
