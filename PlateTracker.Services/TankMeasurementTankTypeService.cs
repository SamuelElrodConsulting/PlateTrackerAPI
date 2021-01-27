using Microsoft.Extensions.Logging;
using PlateTracker.data.Models;
using PlateTracker.data.Repositories;
using PlateTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PlateTracker.Services
{
    public class TankMeasurementTankTypeService
    {
        ILogger<TankMeasurementTankTypeService> _logger;
        TankMeasurementTankTypeRepository _tankMeasurementTankTypeRepository;

        public TankMeasurementTankTypeService(
            TankMeasurementTankTypeRepository tankMeasurementTankTypeRepository,
            ILogger<TankMeasurementTankTypeService> logger)
        {
            _logger = logger;
            _tankMeasurementTankTypeRepository = tankMeasurementTankTypeRepository;
        }

        public IEnumerable<TankMeasurementTankTypeVM> GetTankMeasurementTankTypes()
        {
            AutoMapperService mapper = new AutoMapperService();
            List<TankMeasurementTankTypeVM> returnValues = new List<TankMeasurementTankTypeVM>();

            var tankTypesAsDTO = _tankMeasurementTankTypeRepository.GetTankMeasurementTankTypes();
            tankTypesAsDTO.ToList().ForEach(n =>
            {
                var tankTypeAsVM = mapper.IMapper.Map<TankMeasurementTankType, TankMeasurementTankTypeVM>(n);
                returnValues.Add(tankTypeAsVM);
            });

            return returnValues;
        }
    }
}
