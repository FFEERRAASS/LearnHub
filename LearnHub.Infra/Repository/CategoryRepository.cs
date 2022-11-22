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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbContext dbContext;
        public CategoryRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<Category> GetAllCategory()
        {
            IEnumerable<Category> result = dbContext.Connection.Query<Category>("Category_PACKAGE.GetAllCategory", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public Category GetCategoryById(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Category> result = dbContext.Connection.Query<Category>("Category_PACKAGE.GetCategoryById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
        public bool CreateCategory(Category cat)
        {
            var p = new DynamicParameters();
            p.Add("CategoryName",cat.Categoryname, dbType: DbType.String, direction: ParameterDirection.Input);
  
            var result = dbContext.Connection.Execute("Category_PACKAGE.CreateCategory", p, commandType: CommandType.StoredProcedure);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateCategory(Category cat)
        {
            var p = new DynamicParameters();
            p.Add("id", cat.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            p.Add("categoryname", cat.Categoryname, dbType: DbType.String, direction: ParameterDirection.Input);
          
            var result = dbContext.Connection.Execute("Category_PACKAGE.UpdateCategory", p, commandType: CommandType.StoredProcedure);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteCategory(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("Category_PACKAGE.DeleteCategory", p, commandType: CommandType.StoredProcedure);
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
