namespace TrainCode.Persistence.Repositories
{
    using Microsoft.EntityFrameworkCore;

    using Domain.Entities;
    using App.Repositories;
    using System;

    public class ClientRepository : IClientRepository
    {
        private readonly TrainCodeDbContext _dbContext;

        public ClientRepository(TrainCodeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Client client)
        {
            _dbContext.Clients.Add(client);
            _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await _dbContext.Clients.ToListAsync();
        }

        async Task<Client> IClientRepository.GetById(Guid id)
        {
            return await _dbContext.Clients.FindAsync(id);
        }
    }
}
