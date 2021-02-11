using Microsoft.Extensions.Logging;
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
    public class TankMeasurementNominalService
    {
        private TankMeasurementNominalRepository _tankMeasuremenNominalRepository;
        private IMapper _mapper;
        public TankMeasurementNominalService(
            TankMeasurementNominalRepository tankMeasurementNominalRepository,
            IMapper mapper,
            ILogger<TankMeasurementNominalService> logger)
        {
            _tankMeasuremenNominalRepository = tankMeasurementNominalRepository;
            _mapper = mapper;
        }

        public IEnumerable<TankMeasurementNominalVM> GetTankMeasurementNominals()
        {
            List<TankMeasurementNominalVM> returnValues = new List<TankMeasurementNominalVM>();

            var nominalsAsDTO = _tankMeasuremenNominalRepository.GetTankMeasurementNominals();
            nominalsAsDTO.ToList().ForEach(n =>
            {
                var nominalAsVM = _mapper.Map<TankMeasurementNominal, TankMeasurementNominalVM>(n);
                nominalAsVM.TankTypeName = n.TankType.TankTypeName;
                nominalAsVM.TankMeasurementTypeName = n.TankMeasurementType.TankMeasurementTypeName;
                nominalAsVM.UOM = n.TankMeasurementType.Uom;
                returnValues.Add(nominalAsVM);
            });

            return returnValues;
        }

        public TankMeasurementNominalVM AddTeankMeasurementNominal(TankMeasurementNominalVM nominalToAdd)
        {
            var nominalAsDTO = _mapper.Map<TankMeasurementNominalVM, TankMeasurementNominal>(nominalToAdd);
            var nominalInsertedAsDTO = _tankMeasuremenNominalRepository.AddTankMeasurementNominal(nominalAsDTO);
            var nominalAsVM = _mapper.Map<TankMeasurementNominal, TankMeasurementNominalVM>(nominalInsertedAsDTO);
            return nominalAsVM;
        }

        public TankMeasurementNominalVM UpdateTankMeasurementNominal(TankMeasurementNominalVM nominalToUpdate)
        {
            var noimnalAsDTO = _mapper.Map<TankMeasurementNominalVM, TankMeasurementNominal>(nominalToUpdate);
            var nominalUpdatedAsDTO = _tankMeasuremenNominalRepository.UpdateTankMeasurementNominal(noimnalAsDTO);
            var nominalAsVM = _mapper.Map<TankMeasurementNominal, TankMeasurementNominalVM>(nominalUpdatedAsDTO);
            return nominalAsVM;
        }

        public bool DeleteTankMeasurementNominal(int nominalId)
        {
            try
            {
                _tankMeasuremenNominalRepository.DeleteNominal(nominalId);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
