using Microsoft.AspNetCore.Mvc;
using HotelListing.IRepository;
using Microsoft.AspNetCore.Authorization;

namespace HotelListing.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestAuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TestAuthController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Test()
        {
            return Ok("Secret Message");
        }
    }
}
