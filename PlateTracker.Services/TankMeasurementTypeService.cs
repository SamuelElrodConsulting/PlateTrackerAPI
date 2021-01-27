using Microsoft.Extensions.Logging;
using PlateTracker.data.Repositories;
using PlateTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PlateTracker.data.Models;
using AutoMapper;

namespace PlateTracker.Services
{
    public class TankMeasurementTypeService
    {
        ILogger<TankMeasurementTypeService> _logger;
        IMapper _mapper;
        TankMeasurementTypesRepository _tankMeasurementTypesRepository;
        public TankMeasurementTypeService(
            TankMeasurementTypesRepository tankMeasurementTypesRepository,
            IMapper mapper,
            ILogger<TankMeasurementTypeService> logger)
        {
            _mapper = mapper;
            _logger = logger;
            _tankMeasurementTypesRepository = tankMeasurementTypesRepository;
        }

        public IEnumerable<TankMeasurementTypeVM> GetTankMeasurementTypes()
        {
            List<TankMeasurementTypeVM> returnValues = new List<TankMeasurementTypeVM>();

            _tankMeasurementTypesRepository.GetTankMeasurementTypes().ToList().ForEach(t =>
            {
                var result = _mapper.Map<TankMeasurementType, TankMeasurementTypeVM>(t);
                returnValues.Add(result);
            });

            return returnValues;
        }
    }
}
