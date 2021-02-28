using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HotelListing.IRepository;
using HotelListing.Models;
using HotelListing.ViewModels.Create;
using HotelListing.ViewModels.Return;
using HotelListing.ViewModels.Update;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("{id:Guid}", Name = "getHotel")]
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

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateHotel(CreateHotelDto createHotel)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid post attempt in {nameof(createHotel)}");
                return BadRequest(ModelState);
            }

            var hotel = _mapper.Map<Hotel>(createHotel);
            await _unitOfWork.Hotels.InsertAsync(hotel);
            await _unitOfWork.SaveAsync();
            var hotelToReturn = _mapper.Map<HotelDto>(hotel);
            return CreatedAtRoute("getHotel", new {id = hotelToReturn.Id}, hotelToReturn);
        }

        [HttpPut("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateHotel(Guid id, UpdateHotelDto updateHotel)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid Update attempt in {nameof(UpdateHotel)}");
                return BadRequest(ModelState);
            }

            try
            {
                var hotel = await _unitOfWork.Hotels.GetAsync(q => q.Id == id);
                if (hotel == null)
                {
                    _logger.LogError($"Invalid Update attempt in {nameof(UpdateHotel)}");
                    return BadRequest("the hotel you tried to update not found");
                }

                _mapper.Map(updateHotel, hotel);
                _unitOfWork.Hotels.Update(hotel);
                await _unitOfWork.SaveAsync();
                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Some thing went wrong in the {nameof(UpdateHotel)}");
                return StatusCode(500, "Internal Server Error. Please Try Again later");
            }
        }
        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteHotel(Guid id)
        {
            
            try
            {
                var hotel = await _unitOfWork.Hotels.GetAsync(q => q.Id == id);
                if (hotel == null)
                {
                    _logger.LogError($"Invalid Delete attempt in {nameof(DeleteHotel)}");
                    return BadRequest("the hotel you tried to Delete not found");
                }

                await _unitOfWork.Hotels.DeleteAsync(id);
                await _unitOfWork.SaveAsync();
                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Some thing went wrong in the {nameof(DeleteHotel)}");
                return StatusCode(500, "Internal Server Error. Please Try Again later");
            }
        }
    }
}
