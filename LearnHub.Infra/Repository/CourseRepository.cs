using Dapper;
using LearnHub.Core.Common;
using LearnHub.Core.Data;
using LearnHub.Core.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Infra.Repository
{
    public class CourseRepository:ICourseRepository
    {
        private readonly IDbContext dbContext;
        public CourseRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Course> GetAllCourses()
        {
            IEnumerable<Course> result = dbContext.Connection.Query<Course>("COURSE_PACKAGE.GetAllCourses", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<CountStudentCourse> CountStudentCourses()
        {
           
            IEnumerable<CountStudentCourse> result = dbContext.Connection.Query<CountStudentCourse>("COURSE_PACKAGE.totalStudent", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<StudentMarkDTO> SearchStudent(SREACH search)
        {
            var p = new DynamicParameters();
            p.Add("stdName", search.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("cName", search.Coursename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Datefrom", search.DateFrom, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("dateto", search.DateTo, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<StudentMarkDTO>("COURSESTUDENT_PACKAGE.SearchCourseStudent", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public Course GetCourseById(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Course> result = dbContext.Connection.Query<Course>("COURSE_PACKAGE.GetCourseById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
        public bool CreateCourse(Course course)
        {
            var p = new DynamicParameters();
            p.Add("coursename", course.Coursename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Imagename", course.Imagename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Categoryid", course.Categoryid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("COURSE_PACKAGE.CREATECOURSE", p, commandType: CommandType.StoredProcedure);
            if(result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateCourse(Course course)
        {
            var p = new DynamicParameters();
            p.Add("id", course.Courseid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("cname", course.Coursename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("imgn", course.Imagename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("catid", course.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("COURSE_PACKAGE.UPDATECOURSE", p, commandType: CommandType.StoredProcedure);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteCourse(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("COURSE_PACKAGE.DELETECOURSE", p, commandType: CommandType.StoredProcedure);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<List<Category>> GetAllCategoryCourse()
        {
            var p = new DynamicParameters();
            var result = await dbContext.Connection.QueryAsync<Category, Course,Category>("Course_Package.getallcategotycourse",
            (Category, course) =>
            {
            Category.Courses.Add(course);
                return Category;

            },
            splitOn: "Courseid",
            param:null,
            commandType: CommandType.StoredProcedure
            );
            var results = result.GroupBy(p => p.Categoryid).Select(g=>
            {
                var groupedPost = g.First();
                groupedPost.Courses = g.Select(p =>
                p.Courses.Single()).ToList();
                return groupedPost;
});
            return results.ToList();
}
    }
}
