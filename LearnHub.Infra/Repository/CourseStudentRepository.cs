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
    public class CourseStudentRepository : ICourseStudentRepository
    {
        private readonly IDbContext dbContext;
        public CourseStudentRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<Studentcousre> GetAllCourseStudent()
        {
            IEnumerable<Studentcousre> result = dbContext.Connection.Query<Studentcousre>("CourseStudent_PACKAGE.GetAllCourseStudent", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public Studentcousre GetCourseStudentById(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Studentcousre> result = dbContext.Connection.Query<Studentcousre>("CourseStudent_PACKAGE.GetCourseStudentById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
        public bool CreateCourseStudent(Studentcousre stu)
        {
            var p = new DynamicParameters();
            p.Add("studentid", stu.Stdid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("courseid", stu.Courseid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("markofstd", stu.Markofstd, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("dateofregister", stu.Dateofregister, dbType: DbType.Date, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("CourseStudent_PACKAGE.CreateCourseStudent", p, commandType: CommandType.StoredProcedure);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateCourseStudent(Studentcousre stu)
        {
            var p = new DynamicParameters();
            p.Add("id", stu.Stdcid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            p.Add("studentid", stu.Stdid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("courseid", stu.Courseid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("markofstd", stu.Markofstd, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("dateofregister", stu.Dateofregister, dbType: DbType.Date, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("CourseStudent_PACKAGE.UpdateCourseStudent", p, commandType: CommandType.StoredProcedure);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteCourseStudent(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("CourseStudent_PACKAGE.DeleteCourseStudent", p, commandType: CommandType.StoredProcedure);
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
