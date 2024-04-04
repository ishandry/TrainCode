namespace TrainCode.App.Repositories
{
    using Domain.Entities;

    public interface ICoachRepository
    {
        Task<IEnumerable<Coach>> GetAll();
    }
}
