using AutoMapper;
using Microsoft.Extensions.Logging;
using PlateTracker.data.Repositories;
using PlateTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PlateTracker.data.Models;

namespace PlateTracker.Services
{
    public class LineTankTypeService
    {
        LineTankTypeRepository _lineTankTypeRepository;
        private readonly IMapper _mapper;
        ILogger<LineTankTypeService> _logger;
        public LineTankTypeService(
            LineTankTypeRepository lineTankTypeRepository,
            IMapper mapper,
            ILogger<LineTankTypeService> logger)
        {
            _mapper = mapper;
            _logger = logger;
            _lineTankTypeRepository = lineTankTypeRepository;
        }

        public IEnumerable<LineTankTypeVM> GetLineTankTypes()
        {
            List<LineTankTypeVM> returnValues = new List<LineTankTypeVM>();

            _lineTankTypeRepository.GetLineTankTypes().ToList().ForEach(t =>
            {
                var result = _mapper.Map<LineTankType, LineTankTypeVM>(t);
                result.LineName = t.Line.LineName;
                result.TankTypeName = t.TankType.TankTypeName;
                returnValues.Add(result);
            });

            return returnValues;
        }

        public LineTankTypeVM AddLineTankType(LineTankTypeVM lineTankTypeToAdd)
        {
            var lineTankTypeAsDTO = _mapper.Map<LineTankTypeVM, LineTankType>(lineTankTypeToAdd);
            var lineTankTypeInsertedAsDTO = _lineTankTypeRepository.AddLineTankType(lineTankTypeAsDTO);
            var lineTankTypeAsVM = _mapper.Map<LineTankType, LineTankTypeVM>(lineTankTypeInsertedAsDTO);
            return lineTankTypeAsVM;
        }

        public LineTankTypeVM UpdateLineTankType(LineTankTypeVM lineTankTypeToAdd)
        {
            var lineTankTypeAsDTO = _mapper.Map<LineTankTypeVM, LineTankType>(lineTankTypeToAdd);
            var lineTankTypeUpdatedAsDTO = _lineTankTypeRepository.UpdateLineTankType(lineTankTypeAsDTO);
            var lineTankTypeAsVM = _mapper.Map<LineTankType, LineTankTypeVM>(lineTankTypeUpdatedAsDTO);
            return lineTankTypeAsVM;
        }
    }
}
