using AutoMapper;
using PlateTracker.data.Models;
using PlateTracker.ViewModels;

namespace PlateTracker.Services
{
    public class PlateTrackerMappingProfile : Profile
    {
        public PlateTrackerMappingProfile()
        {
            CreateMap<TankMeasurementNominal, TankMeasurementNominalVM>()
                .ReverseMap();
            CreateMap<TankMeasurementType, TankMeasurementTypeVM>()
                .ReverseMap();
            CreateMap<TankMeasurementTankType, TankMeasurementTankTypeVM>()
                .ReverseMap();
            CreateMap<TankMeasurement, TankMeasurementVM>()
                .ReverseMap();
            CreateMap<Employee, EmployeeVM>()
                .ReverseMap();
        }
    }
}
