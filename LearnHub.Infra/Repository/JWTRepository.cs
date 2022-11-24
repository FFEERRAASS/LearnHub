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
    public class JWTRepository :IJWTRepository
    {
        private readonly IDbContext dbContext;
        public JWTRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Login Auth(Login login)
        {
            var p = new DynamicParameters();
            p.Add("User_NAME", login.Username,dbType:DbType.String,direction:ParameterDirection.Input);
            p.Add("PASS", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<Login> result = dbContext.Connection.Query<Login>("Login_Package.User_Login", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

    }
}
