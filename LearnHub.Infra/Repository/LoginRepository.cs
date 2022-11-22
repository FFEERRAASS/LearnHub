using Dapper;
using LearnHub.Core.Common;
using LearnHub.Core.Data;
using LearnHub.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Infra.Repository
{
    public class LoginRepository :ILoginRepository 
    {
        private readonly IDbContext dbContext;
        public LoginRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<Login> GetAllLogin()
        {
            IEnumerable<Login> result = dbContext.Connection.Query<Login>("Login_PACKAGE.GetAllLogin", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public Login GetLoginById(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Login> result = dbContext.Connection.Query<Login>("Login_PACKAGE.GetLoginById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
        public bool CreateLogin(Login log)
        {
            var p = new DynamicParameters();
            p.Add("USERNAME", log.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Password", log.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Studentid", log.Studentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Roleid", log.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("Login_PACKAGE.CreateLogin", p, commandType: CommandType.StoredProcedure);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateLogin(Login log)
        {
            var p = new DynamicParameters();
            p.Add("id", log.Loginid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            p.Add("USERNAME", log.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Password", log.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Studentid", log.Studentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Roleid", log.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("Login_PACKAGE.UpdateLogin", p, commandType: CommandType.StoredProcedure);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteLogin(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("Login_PACKAGE.DeleteLogin", p, commandType: CommandType.StoredProcedure);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<List<Role>>GetAllRoleLogin()
        {
            var p = new DynamicParameters();
            var result = await dbContext.Connection.QueryAsync<Role, Login, Role>("LOGIN_PACKAGE.GetAllRoleLogin",
            (Role, Login) =>
            {
                Role.Logins.Add(Login);
                return Role;

            },
            param: null,
            splitOn: "Loginid",
            
            commandType: CommandType.StoredProcedure
            );
            var results = result.GroupBy(p => p.Roleid).Select(g =>
            {
                var groupedPost = g.First();
                groupedPost.Logins = g.Select(p =>
                p.Logins.Single()).ToList();
                return groupedPost;
            });
            return results.ToList();
        }
    
    }
}
