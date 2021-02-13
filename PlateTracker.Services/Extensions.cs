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
                    .AddTransient<EmployeeMeasurementService, EmployeeMeasurementService>()
                    .AddTransient<TankMeasurementNominalService, TankMeasurementNominalService>()
                    .AddTransient<TankMeasurementService, TankMeasurementService>()
                    .AddTransient<TankTypeService, TankTypeService>()
                    .AddTransient<TankMeasurementTypeService, TankMeasurementTypeService>()
                    .AddTransient<LineService, LineService>()
                    .AddTransient<LineTypeService, LineTypeService>()
                    .AddTransient<LineTankTypeService, LineTankTypeService>()
                    .AddTransient<ChartService, ChartService>()

                    .AddAutoMapper(typeof(PlateTrackerMappingProfile).Assembly);
        }
    }
}