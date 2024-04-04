namespace TrainCode.App.Client
{
    using Domain.Entities;

    public interface IClientService
    {
        Task<IEnumerable<Client>> GetClientList();
    }
}
