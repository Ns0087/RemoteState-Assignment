using AssignmentJWT.Models;
using AssignmentJWT.Models.RequestViewModels;
using AssignmentJWT.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AssignmentJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyProtectedController : ControllerBase
    {
        private readonly IJwtService _jwtService;

        public MyProtectedController(IServiceProvider serviceProvider) 
        {
            _jwtService = serviceProvider.GetRequiredService<IJwtService>();
        }
        [HttpGet]
        [Authorize]
        [Route("get")]
        public IActionResult Get()
        {
            // This code will only be executed if the user is authenticated
            // You can access the user's claims using User.Identity
            return Ok(new { message = "Hello, authenticated user!" });
        }

        [HttpPost]
        public async Task<string> Login(User user)
        {
            var token = await _jwtService.GenerateToken(user);
            

            return token;
        }

    }
}
