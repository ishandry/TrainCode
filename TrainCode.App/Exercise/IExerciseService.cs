
namespace TrainCode.App
{
    using TrainCode.App.DTOs;

    public interface IExerciseService
    {
        Task<IEnumerable<CoachExerciseDto>> GetCoachExercises(Guid id);

        Task<ClientExerciseDto?> GetExerciseById(Guid id);

        Task<Domain.Entities.Exercise> CreateExercise(Guid coachId, NewExerciseDto exercise);

        Task<ClientExerciseDto?> MarkAsDone(Guid id);

        Task<Domain.Entities.Exercise> ValidateStatus(Domain.Entities.Exercise exercise);
    }
}
