namespace TrainCode.App.Repositories
{
    using Domain.Entities;

    public interface IExerciseRepository
    {
        Task<IEnumerable<Exercise>> GetAll();

        Task<Exercise?> GetById(Guid id);

        Task<IEnumerable<Exercise>> GetByCoachId(Guid id);

        Task<Exercise> Create(Exercise exercise);

        Task<Exercise> Update(Exercise exercise);
    }
}