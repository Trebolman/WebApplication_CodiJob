using Application.DTOs;
using Infraestructure.Transversal.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace CodiJobServices2.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class AuthenticationController : Controller
    {
        IUserService UserService;
        public AuthenticationController(IUserService userService)
        {
            this.UserService = userService;
        }

        [HttpPost("LogIn")]
        [AllowAnonymous]
        public async Task<IActionResult> LogIn([FromBody]LoginDTO login)
        {
            if (ModelState.IsValid)
            {
                var user = await UserService.AuthenticateAsync(login.UserName, login.Password);
                if (user == null)
                    return BadRequest(new { message = "Username or password is incorrect" });
                return Ok(user);
            }
            else
            {
                return BadRequest(new { message = "Model(LoginDTO) is not Valid" });
            }
        }
    }
}