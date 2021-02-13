using AutoMapper;
using Microsoft.Extensions.Logging;
using PlateTracker.data.Repositories;
using PlateTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PlateTracker.Services
{
    public class ChartService
    {
        TankMeasurementService _tankMeasurementService;
        private readonly IMapper _mapper;
        ILogger<ChartService> _logger;
        public ChartService(
            TankMeasurementService tankMeasurementService,
            IMapper mapper,
            ILogger<ChartService> logger)
        {
            _mapper = mapper;
            _logger = logger;
            _tankMeasurementService = tankMeasurementService;
        }

        public ChartVM GetChartInfoByTankMeasurementType(int tankTypeId, int tankMeasurementTypeId)
        {
            ChartVM returnValue = new ChartVM();
            var tanks = _tankMeasurementService.GetTankMeasurements().Where(t =>
                t.TankTypeId == tankTypeId &&
                t.TankMeasurementTypeId == tankMeasurementTypeId).OrderBy(m => m.TankMeasurementDatetime); ;

            returnValue.ChartStartDate = tanks.First().TankMeasurementDatetime;
            returnValue.ChartEndDate = tanks.Last().TankMeasurementDatetime;

            returnValue.LowValue = tanks.First().LowNominalValue;
            returnValue.IdealValue = tanks.First().IdealNominalValue;
            returnValue.HighValue = tanks.First().HighNominalValue;

            return returnValue;
        }
    }
}
