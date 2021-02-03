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
        private TankTypeService _TankType;

        public TankTypeController(
            TankTypeService TankTypeService,
            ILogger<TankTypeController> logger)
        {
            _logger = logger;
            _TankType = TankTypeService;
        }

        [HttpGet]
        public IEnumerable<TankTypeVM> Get()
        {
            return _TankType.GetTankTypes();
        }
    }
}
