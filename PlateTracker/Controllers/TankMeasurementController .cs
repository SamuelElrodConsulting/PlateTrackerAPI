using Microsoft.AspNetCore.Mvc;
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

        public TankMeasurementController(ILogger<TankMeasurementController> logger)
        {
            _logger = logger;
            _tankMeasurementService = new TankMeasurementService(logger);
        }

        [HttpGet]
        public IEnumerable<TankMeasurementVM> Get()
        {
            return _tankMeasurementService.GetTankMeasurements();
        }

        [HttpGet]
        [Route("{tankMeasurementTankTypeId}")]
        public IEnumerable<TankMeasurementVM> Get(int tankMeasurementTankTypeId)
        {
            return _tankMeasurementService.GetTankMeasurements().Where(t=>t.TankMeasurementTankTypeId== tankMeasurementTankTypeId);
        }

        [HttpGet]
        [Route("{tankMeasurementTankTypeId}/{tankMeasurementTypeId}")]
        public IEnumerable<TankMeasurementVM> Get(int tankMeasurementTankTypeId, int tankMeasurementTypeId)
        {
            return _tankMeasurementService.GetTankMeasurements().Where(t => 
            t.TankMeasurementTankTypeId == tankMeasurementTankTypeId &&
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
