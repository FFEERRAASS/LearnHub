using LearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnHub.Core.Repository
{
    public interface IRoleRepository
    {
        List<Role> GetAllRole();
        bool CreateRole(Role log);
        bool UpdateRole(Role log);
        bool DeleteRole(int id);
        Role GetRoleById(int id);
    }
}
