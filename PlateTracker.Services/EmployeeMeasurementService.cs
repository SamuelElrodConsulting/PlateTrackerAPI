using PlateTracker.data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Extensions.Logging;
using PlateTracker.data.Models;
using PlateTracker.ViewModels;
using AutoMapper;

namespace PlateTracker.Services
{
    public class EmployeeMeasurementService
    {
        EmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        ILogger<EmployeeMeasurementService> _logger;
        public EmployeeMeasurementService(
            EmployeeRepository employeeRepository,
            IMapper mapper,
            ILogger<EmployeeMeasurementService> logger)
        {
            _mapper = mapper;
            _logger = logger;
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<EmployeeVM> GetEmployees()
        {
            List<EmployeeVM> returnValues = new List<EmployeeVM>();

            _employeeRepository.GetEmployees().ToList().ForEach(t =>
            {
                var result = _mapper.Map<Employee, EmployeeVM>(t);
                returnValues.Add(result);
            });

            return returnValues;
        }
    }
}
