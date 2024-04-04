namespace TrainCode.Persistence.Repositories
{
    using Microsoft.EntityFrameworkCore;

    using Domain.Entities;
    using App.Repositories;

    public class CoachRepository : ICoachRepository
    {
        private readonly TrainCodeDbContext _dbContext;

        public CoachRepository(TrainCodeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Coach>> GetAll()
        {
            return await _dbContext.Coaches.Include(c => c.Clients).ToListAsync();
        }
    }
}
