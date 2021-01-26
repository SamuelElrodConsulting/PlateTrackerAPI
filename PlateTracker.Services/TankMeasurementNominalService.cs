using Microsoft.Extensions.Logging;
using PlateTracker.data.Models;
using PlateTracker.data.Repositories;
using PlateTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PlateTracker.Services
{
    public class TankMeasurementNominalService
    {
        private TankMeasurementNominalRepository _tankMeasuremenNominalRepository;
        private AutoMapperService _mapper;
        public TankMeasurementNominalService(ILogger logger)
        {
            var context = new TechnicalPlatingContext();
            _tankMeasuremenNominalRepository = new TankMeasurementNominalRepository(context, logger);
            _mapper = new AutoMapperService();
        }

        public IEnumerable<TankMeasurementNominalVM> GetTankMeasurementNominals()
        {
            List<TankMeasurementNominalVM> returnValues = new List<TankMeasurementNominalVM>();

            var nominalsAsDTO = _tankMeasuremenNominalRepository.GetTankMeasurementNominals();
            nominalsAsDTO.ToList().ForEach(n =>
            {
                var nominalAsVM = _mapper.IMapper.Map<TankMeasurementNominal, TankMeasurementNominalVM>(n);
                nominalAsVM.TankMeasurementTankTypeName = n.TankMeasurementTankType.TankMeasurementTankTypeName;
                nominalAsVM.TankMeasurementTypeName = n.TankMeasurementType.TankMeasurementTypeName;
                nominalAsVM.UOM = n.TankMeasurementType.Uom;
                returnValues.Add(nominalAsVM);
            });

            return returnValues;
        }

        public TankMeasurementNominalVM AddTeankMeasurementNominal(TankMeasurementNominalVM nominalToAdd)
        {
            var nominalAsDTO = _mapper.IMapper.Map<TankMeasurementNominalVM, TankMeasurementNominal>(nominalToAdd);
            var nominalInsertedAsDTO = _tankMeasuremenNominalRepository.AddTankMeasurementNominal(nominalAsDTO);
            var nominalAsVM = _mapper.IMapper.Map<TankMeasurementNominal, TankMeasurementNominalVM>(nominalInsertedAsDTO);
            return nominalAsVM;
        }

        public TankMeasurementNominalVM UpdateTankMeasurementNominal(TankMeasurementNominalVM nominalToUpdate)
        {
            var noimnalAsDTO = _mapper.IMapper.Map<TankMeasurementNominalVM, TankMeasurementNominal>(nominalToUpdate);
            var nominalUpdatedAsDTO = _tankMeasuremenNominalRepository.UpdateTankMeasurementNominal(noimnalAsDTO);
            var nominalAsVM = _mapper.IMapper.Map<TankMeasurementNominal, TankMeasurementNominalVM>(nominalUpdatedAsDTO);
            return nominalAsVM;
        }
    }
}
