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
        private TankTypeService _TankTypeService;

        public TankTypeController(
            TankTypeService TankTypeService,
            ILogger<TankTypeController> logger)
        {
            _logger = logger;
            _TankTypeService = TankTypeService;
        }

        [HttpGet]
        public IEnumerable<TankTypeVM> Get()
        {
            return _TankTypeService.GetTankTypes();
        }

        [HttpGet]
        [Route("{lineId}")]
        public IEnumerable<TankTypeVM> Get(int lineID)
        {
            return _TankTypeService.GetTankTypesByLineId(lineID);
        }
    }
}
