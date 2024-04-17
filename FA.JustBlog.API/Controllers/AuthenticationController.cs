using FA.JustBlog.Core.Models.ViewModels;
using FA.JustBlog.Core.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthenticationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("register-user")]
        public async Task<IActionResult> Register([FromBody] RegisterVM registerVM)
        {
            var result = await _unitOfWork.AuthenticationRepository.Register(registerVM);
            if (!result.Succeeded)
            {
                return BadRequest("Failed to register user");
            }

            return Created(nameof(Register), $"User {registerVM.Email} created!");
        }

        [HttpPost("login-user")]
        public async Task<IActionResult> Login([FromBody] LoginVM loginVM)
        {
            try
            {
                var tokenValue = await _unitOfWork.AuthenticationRepository.Login(loginVM);
                return Ok(tokenValue);
            }
            catch
            {
                return Unauthorized();
            }
        }
    }
}
