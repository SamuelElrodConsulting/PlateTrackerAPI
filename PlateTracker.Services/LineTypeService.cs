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
    public class LineTypeService
    {
        LineTypeRepository _lineTypeRepository;
        private readonly IMapper _mapper;
        ILogger<LineTypeService> _logger;
        public LineTypeService(
            LineTypeRepository lineTypeRepository,
            IMapper mapper,
            ILogger<LineTypeService> logger)
        {
            _mapper = mapper;
            _logger = logger;
            _lineTypeRepository = lineTypeRepository;
        }

        public IEnumerable<LineTypeVM> GetLineTypes()
        {
            List<LineTypeVM> returnValues = new List<LineTypeVM>();

            _lineTypeRepository.GetLineTypes().ToList().ForEach(t =>
            {
                var result = _mapper.Map<LineType, LineTypeVM>(t);
                returnValues.Add(result);
            });

            return returnValues;
        }

        public LineTypeVM AddLineType(LineTypeVM lineTypeToAdd)
        {
            var lineTypeAsDTO = _mapper.Map<LineTypeVM, LineType>(lineTypeToAdd);
            var lineTypeInsertedAsDTO = _lineTypeRepository.AddLineType(lineTypeAsDTO);
            var lineTypeAsVM = _mapper.Map<LineType, LineTypeVM>(lineTypeInsertedAsDTO);
            return lineTypeAsVM;
        }

        public LineTypeVM UpdateLineType(LineTypeVM lineTypeToAdd)
        {
            var lineTypeAsDTO = _mapper.Map<LineTypeVM, LineType>(lineTypeToAdd);
            var lineTypeUpdatedAsDTO = _lineTypeRepository.AddLineType(lineTypeAsDTO);
            var lineTypeAsVM = _mapper.Map<LineType, LineTypeVM>(lineTypeUpdatedAsDTO);
            return lineTypeAsVM;
        }
    }
}
