using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    public class TankMeasurementNominalController : ControllerBase
    {
        private readonly ILogger<TankMeasurementController> _logger;
        private TankMeasurementNominalService _tankMeasurementNominalService;

        public TankMeasurementNominalController(
            TankMeasurementNominalService tankMeasurementNominalService,
            ILogger<TankMeasurementController> logger)
        {
            _logger = logger;
            _tankMeasurementNominalService = tankMeasurementNominalService;
        }

        [HttpGet]
        public IEnumerable<TankMeasurementNominalVM> Get()
        {
            return _tankMeasurementNominalService.GetTankMeasurementNominals();
        }
        [HttpPost]
        public TankMeasurementNominalVM Post(TankMeasurementNominalVM newNominal)
        {
            var result = _tankMeasurementNominalService.AddTeankMeasurementNominal(newNominal);
            return result;
        }
        [HttpPut]
        public TankMeasurementNominalVM Put(TankMeasurementNominalVM updateNominal)
        {
            var result = _tankMeasurementNominalService.UpdateTankMeasurementNominal(updateNominal);
            return result;
        }
        [HttpDelete]
        [Route("{nominalId}")]
        public bool Delete(int nominalId)
        {
            var result = _tankMeasurementNominalService.DeleteTankMeasurementNominal(nominalId);
            return result;
        }
    }
}
