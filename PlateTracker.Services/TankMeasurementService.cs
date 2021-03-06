﻿using Microsoft.Extensions.Logging;
using PlateTracker.data.Models;
using PlateTracker.data.Repositories;
using PlateTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper;

namespace PlateTracker.Services
{
    public class TankMeasurementService
    {
        private TankMeasurementRepository _tankMeasurementRepository;
        private LineTankTypeRepository _lineTankTypeRepository;
        private TankMeasurementNominalRepository _tankMeasurementNominalRepository;
        private IMapper _mapper;
        private ILogger<TankMeasurementService> _logger;
        public TankMeasurementService(
            TankMeasurementRepository tankMeasurementRepository,
            TankMeasurementNominalRepository tankMeasurementNominalRepository,
            LineTankTypeRepository lineTankTypeRepository,
            IMapper mapper,
            ILogger<TankMeasurementService> logger)
        {
            _tankMeasurementRepository = tankMeasurementRepository;
            _tankMeasurementNominalRepository = tankMeasurementNominalRepository;
            _lineTankTypeRepository = lineTankTypeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<TankMeasurementVM> GetTankMeasurements()
        {
            List<TankMeasurementVM> returnValues = new List<TankMeasurementVM>();

            var measurementAsDTO = _tankMeasurementRepository.GetTankMeasurements();
            measurementAsDTO.ToList().ForEach(n =>
            {
                var measurementAsVM = _mapper.Map<TankMeasurement, TankMeasurementVM>(n);
                measurementAsVM.TankTypeName = n.LineTankType.TankType.TankTypeName;
                measurementAsVM.TankeMeasurementTypeName = n.TankMeasurementType.TankMeasurementTypeName;
                measurementAsVM.TankMeasurementDescription = n.TankMeasurementType.TankMeasurementTypeDescription;
                measurementAsVM.UOM = n.TankMeasurementType.Uom;
                measurementAsVM.EmployeeName = n.TankMeasurementEmployee.EmployeeFirstName + " " + n.TankMeasurementEmployee.EmployeeLastName;
                measurementAsVM.LineName = n.LineTankType.Line.LineName;
                measurementAsVM.LineID = n.LineTankType.LineId;
                measurementAsVM.TankTypeId = n.LineTankType.TankTypeId;
                var nominal = _tankMeasurementNominalRepository.GetTankMeasurementNominal(n.LineTankType.TankTypeId, n.TankMeasurementTypeId);
                if (nominal != null)
                {
                    measurementAsVM.LowNominalValue = nominal.LowNominalValue;
                    measurementAsVM.IdealNominalValue = nominal.IdealNominalValue;
                    measurementAsVM.HighNominalValue = nominal.HighNominalValue;
                    measurementAsVM.MinimumTestingFrequencyDays = nominal.MinimumTestingFrequencyDays;
                    measurementAsVM.IdealTestingFrequencyDays = nominal.IdealTestingFrequencyDays;
                    measurementAsVM.NominalExists = true;
                }
                else
                {
                    measurementAsVM.NominalExists = false;
                }

                if (measurementAsVM.Value > measurementAsVM.HighNominalValue || measurementAsVM.Value < measurementAsVM.LowNominalValue)
                {
                    measurementAsVM.OutsideNominal = true;
                }
                returnValues.Add(measurementAsVM);
            });

            return returnValues;
        }

        public TankMeasurementVM AddTankMeasurement(TankMeasurementVM tmToAdd)
        {
            //get lineTankTypeId from LineId and TankTypeId
            tmToAdd.LineTankTypeId = _lineTankTypeRepository.GetLineTankType(tmToAdd.LineID, tmToAdd.TankTypeId).LineTankTypeId;
            //---------------------------------------------
            var tmAsDTO = _mapper.Map<TankMeasurementVM, TankMeasurement>(tmToAdd);
            var tmInsertedAsDTO = _tankMeasurementRepository.AddTankMeasurement(tmAsDTO);
            var tmAsVM = _mapper.Map<TankMeasurement, TankMeasurementVM>(tmInsertedAsDTO);
            return tmAsVM;
        }

        public TankMeasurementVM UpdateTankMeasurement(TankMeasurementVM tmToUpdate)
        {
            var tmAsDTO = _mapper.Map<TankMeasurementVM, TankMeasurement>(tmToUpdate);
            var tmUpdatedAsDTO = _tankMeasurementRepository.UpdateTankMeasurement(tmAsDTO);
            var tmAsVM = _mapper.Map<TankMeasurement, TankMeasurementVM>(tmUpdatedAsDTO);
            return tmAsVM;
        }
        public bool DeleteTankMeasurement(int deleteID)
        {
            try
            {
                _tankMeasurementRepository.DeleteTankMeasurement(deleteID);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return false;
            }
        }
    }
}
