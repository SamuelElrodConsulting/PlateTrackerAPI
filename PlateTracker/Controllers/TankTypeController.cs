using Microsoft.AspNetCore.Http;
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
    public class TankTypeController : ControllerBase
    {
        private readonly ILogger<TankTypeController> _logger;
        private TankTypeService _tankTypeService;

        public TankTypeController(
            TankTypeService TankTypeService,
            ILogger<TankTypeController> logger)
        {
            _logger = logger;
            _tankTypeService = TankTypeService;
        }

        [HttpGet]
        public IEnumerable<TankTypeVM> Get()
        {
            return _tankTypeService.GetTankTypes();
        }

        [HttpGet]
        [Route("{lineId}")]
        public IEnumerable<TankTypeVM> Get(int lineID)
        {
            return _tankTypeService.GetTankTypesByLineId(lineID);
        }
        [HttpPost]
        public TankTypeVM Post(TankTypeVM tankType)
        {
            return _tankTypeService.AddTankType(tankType);
        }
        [HttpPut]
        public TankTypeVM Put(TankTypeVM tankType)
        {
            return _tankTypeService.UpdateTankType(tankType);
        }
        [HttpDelete]
        [Route("{tankTypeId}")]
        public bool Delete(int tankTypeId)
        {
            return _tankTypeService.DeleteTankType(tankTypeId);
        }
    }
}
