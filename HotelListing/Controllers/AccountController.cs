using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using HotelListing.Models;
using HotelListing.Services;
using HotelListing.ViewModels.Create;
using HotelListing.ViewModels.Return;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace HotelListing.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly SignInManager<ApiUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;

        public AccountController(UserManager<ApiUser> userManager, 
            SignInManager<ApiUser> signInManager, 
            ILogger<AccountController> logger, 
            IMapper mapper, IAuthManager authManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _mapper = mapper;
            _authManager = authManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserDto user)
        {
            _logger.LogInformation($"Registration Attempt for {user.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userToRegister = _mapper.Map<ApiUser>(user);
            userToRegister.UserName = user.Email;
            var result = await _userManager.CreateAsync(userToRegister,user.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            await _userManager.AddToRolesAsync(userToRegister, user.Roles);
            return Accepted();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDto user)
        {
            _logger.LogInformation($"login Attempt for {user.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _authManager.ValidateUser(user))
            {
                return Unauthorized(user);
            }

            return Accepted(new {token = await _authManager.CreateToken(user)});
        }

    }
}
