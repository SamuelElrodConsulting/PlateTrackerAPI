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
    public class LineService
    {
        LineRepository _lineRepository;
        private readonly IMapper _mapper;
        ILogger<LineService> _logger;
        public LineService(
            LineRepository lineRepository,
            IMapper mapper,
            ILogger<LineService> logger)
        {
            _mapper = mapper;
            _logger = logger;
            _lineRepository = lineRepository;
        }

        public IEnumerable<LineVM> GetLines()
        {
            List<LineVM> returnValues = new List<LineVM>();

            _lineRepository.GetLines().ToList().ForEach(t =>
            {
                var result = _mapper.Map<Line, LineVM>(t);
                result.LineTypeName = t.LineType.LineTypeName;
                returnValues.Add(result);
            });

            return returnValues;
        }

        public LineVM AddLine(LineVM lineToAdd)
        {
            var lineAsDTO = _mapper.Map<LineVM, Line>(lineToAdd);
            var LineInsertedAsDTO = _lineRepository.AddLine(lineAsDTO);
            var lineAsVM = _mapper.Map<Line, LineVM>(LineInsertedAsDTO);
            return lineAsVM;
        }

        public LineVM UpdateLine(LineVM lineToAdd)
        {
            var lineAsDTO = _mapper.Map<LineVM, Line>(lineToAdd);
            var LineInsertedAsDTO = _lineRepository.UpdateLine(lineAsDTO);
            var lineAsVM = _mapper.Map<Line, LineVM>(LineInsertedAsDTO);
            return lineAsVM;
        }

        public bool DeleteLine(int lineToDelete)
        {
            return _lineRepository.DeleteLine(lineToDelete);
        }
    }
}
