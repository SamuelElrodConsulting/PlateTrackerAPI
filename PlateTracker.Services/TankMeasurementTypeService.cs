using Microsoft.Extensions.Logging;
using PlateTracker.data.Repositories;
using PlateTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PlateTracker.data.Models;

namespace PlateTracker.Services
{
    public class TankMeasurementTypeService
    {
        ILogger<TankMeasurementTypeService> _logger;
        TankMeasurementTypesRepository _tankMeasurementTypesRepository;
        public TankMeasurementTypeService(
            TankMeasurementTypesRepository tankMeasurementTypesRepository,
            ILogger<TankMeasurementTypeService> logger)
        {
            _logger = logger;
            _tankMeasurementTypesRepository = tankMeasurementTypesRepository;
        }

        public IEnumerable<TankMeasurementTypeVM> GetTankMeasurementTypes()
        {
            AutoMapperService mapper = new AutoMapperService();
            List<TankMeasurementTypeVM> returnValues = new List<TankMeasurementTypeVM>();

            _tankMeasurementTypesRepository.GetTankMeasurementTypes().ToList().ForEach(t =>
            {
                var result = mapper.IMapper.Map<TankMeasurementType, TankMeasurementTypeVM>(t);
                returnValues.Add(result);
            });

            return returnValues;
        }
    }
}
