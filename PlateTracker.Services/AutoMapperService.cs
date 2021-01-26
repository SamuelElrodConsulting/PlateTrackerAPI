using AutoMapper;
using PlateTracker.data.Models;
using PlateTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlateTracker.Services
{
    public class AutoMapperService
    {
        public IMapper IMapper { get; set; }
        public AutoMapperService()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<TankMeasurementNominal, TankMeasurementNominalVM>()
                .ReverseMap();
                cfg.CreateMap<TankMeasurementType, TankMeasurementTypeVM>()
                .ReverseMap();
                cfg.CreateMap<TankMeasurementTankType, TankMeasurementTankTypeVM>()
                .ReverseMap();
                cfg.CreateMap<TankMeasurement, TankMeasurementVM>()
                .ReverseMap();
                cfg.CreateMap<Employee, EmployeeVM>()
                .ReverseMap();
            });

            IMapper = config.CreateMapper();
        }
    }
}
