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
    public class TankTypeFilterController : ControllerBase
    {
        private readonly ILogger<TankTypeFilterController> _logger;
        private TankTypeService _tankTypeService;

        public TankTypeFilterController(
            TankTypeService tankTypeService,
            ILogger<TankTypeFilterController> logger)
        {
            _logger = logger;
            _tankTypeService = tankTypeService;
        }

        [HttpGet]
        [Route("{lineTypeId}")]
        public IEnumerable<TankTypeVM> Get(int lineTypeId)
        {
            return _tankTypeService.GetTankTypesByLineTypeId(lineTypeId);
        }
    }
}
