namespace TrainCode.Persistence
{
    using Microsoft.EntityFrameworkCore;

    using TrainCode.Domain.Entities;
    public class TrainCodeDbContext: DbContext
    {
        public TrainCodeDbContext(DbContextOptions<TrainCodeDbContext> options): base(options)
        {
        }
        public DbSet<Coach> Coaches { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Exercise> Exercises { get; set; }

    }
}
