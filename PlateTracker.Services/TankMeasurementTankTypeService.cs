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
        TankTypeRepository _TankTypeRepository;
        IMapper _mapper;

        public TankTypeService(
            TankTypeRepository TankTypeRepository,
            IMapper mapper,
            ILogger<TankTypeService> logger)
        {
            _mapper = mapper;
            _logger = logger;
            _TankTypeRepository = TankTypeRepository;
        }

        public IEnumerable<TankTypeVM> GetTankTypesByLineId(int lineId)
        {
            List<TankTypeVM> returnValues = new List<TankTypeVM>();

            _TankTypeRepository.GetTankTypesByLineId(lineId).ToList().ForEach(l =>
            {
                var tankTypeAsVM = _mapper.Map<TankType, TankTypeVM>(l);
                returnValues.Add(tankTypeAsVM);
            });
            return returnValues;
        }
        public IEnumerable<TankTypeVM> GetTankTypes()
        {
            List<TankTypeVM> returnValues = new List<TankTypeVM>();

            var tankTypesAsDTO = _TankTypeRepository.GetTankTypes();
            tankTypesAsDTO.ToList().ForEach(n =>
            {
                var tankTypeAsVM = _mapper.Map<TankType, TankTypeVM>(n);
                returnValues.Add(tankTypeAsVM);
            });

            return returnValues;
        }
    }
}
