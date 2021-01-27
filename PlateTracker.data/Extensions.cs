using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PlateTracker.data.Models;
using PlateTracker.data.Repositories;

namespace PlateTracker.data
{
    public static class Extensions
    {
        public static IServiceCollection RegisterDataAssembly(this IServiceCollection services, string connectionString)
        {
            return
                services
                    .AddTransient<EmployeeRepository, EmployeeRepository>()
                    .AddTransient<TankMeasurementNominalRepository, TankMeasurementNominalRepository>()
                    .AddTransient<TankMeasurementRepository, TankMeasurementRepository>()
                    .AddTransient<TankMeasurementTankTypeRepository, TankMeasurementTankTypeRepository>()
                    .AddTransient<TankMeasurementTypesRepository, TankMeasurementTypesRepository>()

                    .AddDbContext<TechnicalPlatingContext>(opts =>
                    {
                        opts
                            .UseLazyLoadingProxies()
                            .UseSqlServer(connectionString);
                    });
        }
    }
}
