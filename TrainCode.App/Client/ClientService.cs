namespace TrainCode.App.Client
{
    using Domain.Entities;
    using Repositories;

    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<IEnumerable<Client>> GetClientList()
        {
            var newClients = new List<Client>
            {
                new Client(){ Id = new Guid(), FirstName = "John", LastName = "Doe"},
                new Client(){ Id = new Guid(), FirstName = "Dane", LastName = "Doff"}
            };

            //foreach (var client in newClients)
            //{
            //    _clientRepository.Add(client);
            //}
            //return newClients;
            return await _clientRepository.GetAll();
        }
    }
}
