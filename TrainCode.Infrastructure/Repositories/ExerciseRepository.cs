namespace TrainCode.Persistence.Repositories
{
    using Microsoft.EntityFrameworkCore;

    using Domain.Entities;
    using App.Repositories;
    using TrainCode.Domain.Enums;

    public class ExerciseRepository : IExerciseRepository
    {
        private readonly TrainCodeDbContext _dbContext;

        public ExerciseRepository(TrainCodeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Exercise>> GetAll()
        {
            return await _dbContext.Exercises.ToListAsync();
        }

        public async Task<Exercise?> GetById(Guid id)
        {
            return await _dbContext.Exercises.FindAsync(id);
        }

        public async Task<IEnumerable<Exercise>> GetByCoachId(Guid id)
        {
            var pendingExercises = await _dbContext.Exercises
                .Include(e => e.Client)
                .Where(e => e.CoachId == id && e.Status == ExerciseStatus.Pending)
                .OrderBy(e => e.DueDate)
                .ToListAsync();

            var otherExercises = await _dbContext.Exercises
                .Include(e => e.Client)
                .Where(e => e.CoachId == id && e.Status != ExerciseStatus.Pending)
                .OrderBy(e => e.DueDate)
                .ToListAsync();

            return pendingExercises.Concat(otherExercises);
        }

        public async Task<Exercise> Create(Exercise exercise)
        {
            var client = await _dbContext.Clients.FindAsync(exercise.ClientId);
            if (client is null)
            {
                throw new Exception("Client not found");
            }
            exercise.Client = client;
            _dbContext.Exercises.Add(exercise);
            await _dbContext.SaveChangesAsync();
            return exercise;
        }

        public async Task<Exercise> Update(Exercise exercise)
        {
            _dbContext.Exercises.Update(exercise);
            await _dbContext.SaveChangesAsync();
            return exercise;
        }
    }
}
