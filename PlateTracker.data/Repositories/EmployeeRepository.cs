using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PlateTracker.data.Models;
using Microsoft.Extensions.Logging;

namespace PlateTracker.data.Repositories
{
    public class EmployeeRepository
    {
        TechnicalPlatingContext _context;
        ILogger _logger;
        public EmployeeRepository(TechnicalPlatingContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }
        public IEnumerable<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }

        public Employee GetTankMeasurementNominal(int employeeId)
        {
            return _context.Employees.First(n => n.EmployeeId == employeeId);
        }
        public Employee AddTankMeasurementNominal(Employee employeeToAdd)
        {
            var addResult = _context.Employees.Add(employeeToAdd);
            _context.SaveChanges();
            return addResult.Entity;
        }
        public Employee UpdateEmployee(Employee employeeToUpdate)
        {
            var currentValue = _context.Employees.First(n => n.EmployeeId == employeeToUpdate.EmployeeId);
            employeeToUpdate.CreatedBy = currentValue.CreatedBy;
            employeeToUpdate.CreatedDatetime = currentValue.CreatedDatetime;
            _context.Entry(currentValue).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            _context.Entry(employeeToUpdate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var updateResult = _context.Employees.Update(employeeToUpdate);
            _context.SaveChanges();
            return updateResult.Entity;
        }
    }
}
