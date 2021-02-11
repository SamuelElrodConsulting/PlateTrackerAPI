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
    public class TankTypeService
    {
        ILogger<TankTypeService> _logger;
        TankTypeRepository _tankTypeRepository;
        IMapper _mapper;

        public TankTypeService(
            TankTypeRepository tankTypeRepository,
            IMapper mapper,
            ILogger<TankTypeService> logger)
        {
            _mapper = mapper;
            _logger = logger;
            _tankTypeRepository = tankTypeRepository;
        }

        public IEnumerable<TankTypeVM> GetTankTypesByLineId(int lineId)
        {
            List<TankTypeVM> returnValues = new List<TankTypeVM>();

            _tankTypeRepository.GetTankTypesByLineId(lineId).ToList().ForEach(l =>
            {
                var tankTypeAsVM = _mapper.Map<TankType, TankTypeVM>(l);
                tankTypeAsVM.LineTypeName = l.LineType.LineTypeName;
                returnValues.Add(tankTypeAsVM);
            });
            return returnValues;
        }
        public IEnumerable<TankTypeVM> GetTankTypesByLineTypeId(int lineTypeId)
        {
            List<TankTypeVM> returnValues = new List<TankTypeVM>();

            _tankTypeRepository.GetTankTypesByLineTypeId(lineTypeId).ToList().ForEach(l =>
            {
                var tankTypeAsVM = _mapper.Map<TankType, TankTypeVM>(l);
                tankTypeAsVM.LineTypeName = l.LineType.LineTypeName;
                returnValues.Add(tankTypeAsVM);
            });
            return returnValues;
        }
        public IEnumerable<TankTypeVM> GetTankTypes()
        {
            List<TankTypeVM> returnValues = new List<TankTypeVM>();

            var tankTypesAsDTO = _tankTypeRepository.GetTankTypes();
            tankTypesAsDTO.ToList().ForEach(n =>
            {
                var tankTypeAsVM = _mapper.Map<TankType, TankTypeVM>(n);
                tankTypeAsVM.LineTypeName = n.LineType.LineTypeName;
                returnValues.Add(tankTypeAsVM);
            });

            return returnValues;
        }

        public TankTypeVM AddTankType(TankTypeVM tankTypeToAdd)
        {
            var tankTypeAsDTO = _mapper.Map<TankTypeVM, TankType>(tankTypeToAdd);
            var tankTypeInsertedAsDTO = _tankTypeRepository.AddTankType(tankTypeAsDTO);
            var tankTypeAsVM = _mapper.Map<TankType, TankTypeVM>(tankTypeInsertedAsDTO);
            return tankTypeAsVM;
        }

        public TankTypeVM UpdateTankType(TankTypeVM tankTypeToAdd)
        {
            var tankTypeAsDTO = _mapper.Map<TankTypeVM, TankType>(tankTypeToAdd);
            var tankTypeUpdatedAsDTO = _tankTypeRepository.UpdateTankType(tankTypeAsDTO);
            var tankTypeAsVM = _mapper.Map<TankType, TankTypeVM>(tankTypeUpdatedAsDTO);
            return tankTypeAsVM;
        }

        public bool DeleteTankType(int tankTypeId)
        {
            return _tankTypeRepository.DeleteTankType(tankTypeId);
        }
    }
}
