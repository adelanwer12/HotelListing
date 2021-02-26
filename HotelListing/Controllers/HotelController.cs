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
    [Route("api/hotel")]
    public class HotelController: ControllerBase
    {
        private readonly ILogger<HotelController> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public HotelController(ILogger<HotelController> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IReadOnlyList<HotelDto>>> GetHotels()
        {
            var hotelsFromRepo = await _unitOfWork.Hotels.GetAllAsync();
            var hotels = _mapper.Map<IReadOnlyList<HotelDto>>(hotelsFromRepo);
            return Ok(hotels);
        }

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<HotelDto>> GetHotel(Guid id)
        {
            var hotelFromRepo = await _unitOfWork.Hotels.GetAsync(h=>h.Id == id);
            var hotel = _mapper.Map<HotelDto>(hotelFromRepo);
            if (hotel == null)
            {
                return NotFound();
            }
            return Ok(hotel);
        }
    }
}
