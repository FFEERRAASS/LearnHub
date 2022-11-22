using LearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Core.Services
{
    public interface ILoginServices
    {
        List<Login> GetAllLogin();
        bool CreateLogin(Login log);
        public bool UpdateLogin(Login log);
        bool DeleteLogin(int id);
        Login GetLoginById(int id);
        Task<List<Role>> GetAllRoleLogin();

    }
}
