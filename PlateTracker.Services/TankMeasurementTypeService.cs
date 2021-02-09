using Microsoft.Extensions.Logging;
using PlateTracker.data.Repositories;
using PlateTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PlateTracker.data.Models;
using AutoMapper;

namespace PlateTracker.Services
{
    public class TankMeasurementTypeService
    {
        ILogger<TankMeasurementTypeService> _logger;
        IMapper _mapper;
        TankMeasurementTypesRepository _tankMeasurementTypesRepository;
        public TankMeasurementTypeService(
            TankMeasurementTypesRepository tankMeasurementTypesRepository,
            IMapper mapper,
            ILogger<TankMeasurementTypeService> logger)
        {
            _mapper = mapper;
            _logger = logger;
            _tankMeasurementTypesRepository = tankMeasurementTypesRepository;
        }

        public IEnumerable<TankMeasurementTypeVM> GetTankMeasurementTypes()
        {
            List<TankMeasurementTypeVM> returnValues = new List<TankMeasurementTypeVM>();

            _tankMeasurementTypesRepository.GetTankMeasurementTypes().ToList().ForEach(t =>
            {
                var result = _mapper.Map<TankMeasurementType, TankMeasurementTypeVM>(t);
                returnValues.Add(result);
            });

            return returnValues;
        }

        public TankMeasurementTypeVM AddTankMeasurementType(TankMeasurementTypeVM measurementTypeToAdd)
        {
            var measurementTypeToAddDTO = _mapper.Map<TankMeasurementTypeVM, TankMeasurementType>(measurementTypeToAdd);
            var dtoResult = _tankMeasurementTypesRepository.AddTankMeasurementType(measurementTypeToAddDTO);
            var vmResult = _mapper.Map<TankMeasurementType, TankMeasurementTypeVM>(dtoResult);
            return vmResult;
        }

        public TankMeasurementTypeVM UpdateTankMeasurementType(TankMeasurementTypeVM measurementTypeToUpdate)
        {
           var measurementTypeToUpdateDTO = _mapper.Map<TankMeasurementTypeVM, TankMeasurementType>(measurementTypeToUpdate);
            var dtoResult = _tankMeasurementTypesRepository.UpdateTankMeasurementType(measurementTypeToUpdateDTO);
            var vmResult = _mapper.Map<TankMeasurementType, TankMeasurementTypeVM>(dtoResult);
            return vmResult;
        }

        public Boolean DeleteTankMeasurementType(int tankMeasurementTypeID)
        {
            return _tankMeasurementTypesRepository.DeleteTankMeasurementType(tankMeasurementTypeID);
        }
    }
}
