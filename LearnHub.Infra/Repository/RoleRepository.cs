using Dapper;
using LearnHub.Core.Common;
using LearnHub.Core.Data;
using LearnHub.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LearnHub.Infra.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IDbContext dbContext;
        public RoleRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<Role> GetAllRole()
        {
            IEnumerable<Role> result = dbContext.Connection.Query<Role>("Role_PACKAGE.GetAllRole", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public Role GetRoleById(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Role> result = dbContext.Connection.Query<Role>("Role_PACKAGE.GetRoleById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
        public bool CreateRole(Role role)
        {
            var p = new DynamicParameters();
            p.Add("RoleName", role.Rolename, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("Role_PACKAGE.CreateRole", p, commandType: CommandType.StoredProcedure);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateRole(Role role)
        {
            var p = new DynamicParameters();
            p.Add("id", role.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            p.Add("RoleName", role.Rolename, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("Role_PACKAGE.UpdateRole", p, commandType: CommandType.StoredProcedure);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteRole(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("Role_PACKAGE.DeleteRole", p, commandType: CommandType.StoredProcedure);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
