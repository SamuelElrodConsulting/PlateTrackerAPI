using Microsoft.Extensions.Logging;
using PlateTracker.data.Models;
using PlateTracker.data.Repositories;
using PlateTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper;

namespace PlateTracker.Services
{
    public class TankMeasurementTankTypeService
    {
        ILogger<TankMeasurementTankTypeService> _logger;
        TankMeasurementTankTypeRepository _tankMeasurementTankTypeRepository;
        IMapper _mapper;

        public TankMeasurementTankTypeService(
            TankMeasurementTankTypeRepository tankMeasurementTankTypeRepository,
            IMapper mapper,
            ILogger<TankMeasurementTankTypeService> logger)
        {
            _mapper = mapper;
            _logger = logger;
            _tankMeasurementTankTypeRepository = tankMeasurementTankTypeRepository;
        }

        public IEnumerable<TankMeasurementTankTypeVM> GetTankMeasurementTankTypes()
        {
            List<TankMeasurementTankTypeVM> returnValues = new List<TankMeasurementTankTypeVM>();

            var tankTypesAsDTO = _tankMeasurementTankTypeRepository.GetTankMeasurementTankTypes();
            tankTypesAsDTO.ToList().ForEach(n =>
            {
                var tankTypeAsVM = _mapper.Map<TankMeasurementTankType, TankMeasurementTankTypeVM>(n);
                returnValues.Add(tankTypeAsVM);
            });

            return returnValues;
        }
    }
}
