namespace TrainCode.App.Repositories
{
    using Domain.Entities;

    public interface IClientRepository
    {
        void Add(Client client);

        Task<IEnumerable<Client>> GetAll();

        Task<Client> GetById(Guid id);
    }
}