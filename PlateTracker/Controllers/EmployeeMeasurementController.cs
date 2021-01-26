using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PlateTracker.Services;
using Microsoft.AspNetCore.Mvc;
using PlateTracker.ViewModels;

namespace PlateTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeMeasurementController: ControllerBase
    {
        private readonly ILogger<EmployeeMeasurementController> _logger;
        private EmployeeMeasurementService _employeeMeasurementService;

        public EmployeeMeasurementController(ILogger<EmployeeMeasurementController> logger)
        {
            _logger = logger;
            _employeeMeasurementService = new EmployeeMeasurementService(logger);
        }

        [HttpGet]
        public IEnumerable<EmployeeVM> Get()
        {
            return _employeeMeasurementService.GetEmployees();
        }
    }
}
