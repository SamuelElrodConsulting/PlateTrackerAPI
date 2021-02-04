﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlateTracker.data.Models;
using PlateTracker.data.Repositories;
using PlateTracker.Services;
using PlateTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlateTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TankMeasurementController : ControllerBase
    {
        private readonly ILogger<TankMeasurementController> _logger;
        private TankMeasurementService _tankMeasurementService;

        public TankMeasurementController(
            TankMeasurementService tankMeasurementService,
            ILogger<TankMeasurementController> logger)
        {
            _logger = logger;
            _tankMeasurementService = tankMeasurementService;
        }

        [HttpGet]
        public IEnumerable<TankMeasurementVM> Get()
        {
            return _tankMeasurementService.GetTankMeasurements();
        }

        [HttpGet]
        [Route("{TankTypeId}")]
        public IEnumerable<TankMeasurementVM> Get(int TankTypeId)
        {
            return _tankMeasurementService.GetTankMeasurements().Where(t => t.LineTankTypeId == TankTypeId);
        }

        [HttpGet]
        [Route("{TankTypeId}/{tankMeasurementTypeId}")]
        public IEnumerable<TankMeasurementVM> Get(int TankTypeId, int tankMeasurementTypeId)
        {
            return _tankMeasurementService.GetTankMeasurements().Where(t =>
            t.LineTankTypeId == TankTypeId &&
            t.TankMeasurementTypeId == tankMeasurementTypeId);
        }

        [HttpPost]
        public TankMeasurementVM Post(TankMeasurementVM newMeasurement)
        {
            var result = _tankMeasurementService.AddTankMeasurement(newMeasurement);
            return result;
        }
        [HttpPut]
        public TankMeasurementVM Put(TankMeasurementVM updateMeasurement)
        {
            var result = _tankMeasurementService.UpdateTankMeasurement(updateMeasurement);
            return result;
        }
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var result = _tankMeasurementService.DeleteTankMeasurement(id);
            return result;
        }
    }
}
