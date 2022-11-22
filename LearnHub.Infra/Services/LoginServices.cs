using LearnHub.Core.Data;
using LearnHub.Core.Repository;
using LearnHub.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LearnHub.Infra.Services
{
    public class LoginServices : ILoginServices
    {
        public readonly ILoginRepository loginRepository;
        public LoginServices(ILoginRepository _loginRepository)
        {
            loginRepository = _loginRepository;
        }
        public List<Login> GetAllLogin()
        {
            return loginRepository.GetAllLogin();
        }
        public bool CreateLogin(Login login)
        {
            return loginRepository.CreateLogin(login);
        }
        public bool UpdateLogin(Login log)
        {
            return loginRepository.UpdateLogin(log);
        }
        public bool DeleteLogin(int id)
        {
            return loginRepository.DeleteLogin(id);
        }
        public Login GetLoginById(int id)
        {
            return loginRepository.GetLoginById(id);
        }
        public async Task<List<Role>> GetAllRoleLogin()
        {
            return await loginRepository.GetAllRoleLogin();
        }




       
    }
}
