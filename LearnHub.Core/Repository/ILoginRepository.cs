using LearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Core.Repository
{
    public interface ILoginRepository
    {
        List<Login> GetAllLogin();
        bool CreateLogin(Login log);
        bool UpdateLogin(Login log);
        bool DeleteLogin(int id);
        Login GetLoginById(int id);
        Task<List<Role>> GetAllRoleLogin();

    }
}
