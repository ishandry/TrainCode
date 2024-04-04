namespace TrainCode.App
{
    using Domain.Entities;

    public interface ICoachService
    {
        Task<IEnumerable<Coach>> GetCoachesList();
    }
}
