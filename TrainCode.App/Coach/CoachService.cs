namespace TrainCode.App.Client
{
    using Domain.Entities;
    using Repositories;

    public class CoachService : ICoachService
    {
        private readonly ICoachRepository _coachRepository;

        public CoachService(ICoachRepository coachRepository)
        {
            _coachRepository = coachRepository;
        }

        public async Task<IEnumerable<Coach>> GetCoachesList()
        {
            return await _coachRepository.GetAll();
        }
    }
}
