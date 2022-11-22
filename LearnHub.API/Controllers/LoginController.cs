using LearnHub.Core.Data;
using LearnHub.Core.Services;
using LearnHub.Infra.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearnHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginServices loginServices;
        public LoginController(ILoginServices loginServices)
        {
            this.loginServices = loginServices;
        }
        [HttpGet("GetAllLoginRole")]
        public async Task<List<Role>> GetAllRoleLogin()
        {
            return await loginServices.GetAllRoleLogin();
        }
    }
}
