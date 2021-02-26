using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HotelListing.IRepository;
using HotelListing.ViewModels.Return;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HotelListing.Controllers
{
    [ApiController]
    [Route("api/country")]
    public class CountryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CountryController> _logger;
        private readonly IMapper _mapper;

        public CountryController(IUnitOfWork unitOfWork, ILogger<CountryController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IReadOnlyList<CountryDto>>> GetCountries()
        {
            var countriesFromRepo = await _unitOfWork.Countries.GetAllAsync(null,null,new List<string>{"Hotels","Hostels"});
            var countriesToReturn = _mapper.Map<IReadOnlyList<CountryDto>>(countriesFromRepo);
            return Ok(countriesToReturn);
        }

        [HttpGet("{countryId:Guid}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IReadOnlyList<CountryDto>>> GetCountry(Guid countryId)
        {
            var countryFromRepo = await _unitOfWork.Countries.GetAsync(c => c.Id == countryId, new List<string>{"Hotels"});
            var countryToReturn = _mapper.Map<CountryDto>(countryFromRepo);
            return Ok(countryToReturn);
        }
    }
}
