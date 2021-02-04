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
                returnValues.Add(result);
            });

            return returnValues;
        }
    }
}
