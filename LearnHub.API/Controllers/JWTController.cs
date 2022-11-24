using LearnHub.Core.Data;
using LearnHub.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JWTController : ControllerBase
    {
        private readonly IJWTServices jWTServices;
        public JWTController(IJWTServices jWTServices)
        {
            this.jWTServices = jWTServices;
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Auth([FromBody]Login login)
        {
            var token = jWTServices.Auth(login);
            if(token == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(token);
            }

        }
    }
}
