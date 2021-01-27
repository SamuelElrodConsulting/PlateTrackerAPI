using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace PlateTracker.Services
{
    public static class Extensions
    {
        public static IServiceCollection RegisterServicesAssembly(this IServiceCollection services)
        {
            return
                services
                    .AddTransient<AutoMapperService, AutoMapperService>()
                    .AddTransient<EmployeeMeasurementService, EmployeeMeasurementService>()
                    .AddTransient<TankMeasurementNominalService, TankMeasurementNominalService>()
                    .AddTransient<TankMeasurementService, TankMeasurementService>()
                    .AddTransient<TankMeasurementTankTypeService, TankMeasurementTankTypeService>()
                    .AddTransient<TankMeasurementTypeService, TankMeasurementTypeService>()

                    .AddAutoMapper(typeof(PlateTrackerMappingProfile).Assembly);
        }
    }
}