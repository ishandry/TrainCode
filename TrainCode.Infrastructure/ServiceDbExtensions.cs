namespace TrainCode.Persistence
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.EntityFrameworkCore;

    public static class ServiceDbExtensions
    {
        public static void InjectTrainCodeDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<TrainCodeDbContext>(options =>
                 options.UseSqlServer(connectionString));
        }
    }
}
