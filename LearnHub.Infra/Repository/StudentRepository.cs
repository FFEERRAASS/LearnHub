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
    public class StudentRepository:IStudentRepository
    {
        private readonly IDbContext dbContext;
        public StudentRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<Student> GetAllStudent()
        {
            IEnumerable<Student> result = dbContext.Connection.Query<Student>("STUDENT_PACKAGE.GetAllStudent", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public Student GetStudentById(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Student> result = dbContext.Connection.Query<Student>("STUDENT_PACKAGE.GetStudentById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
        public bool Createstudent(Student stu)
        {
            var p = new DynamicParameters();
            p.Add("Firstname", stu.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Birthdate", stu.Birthdate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("Lastname", stu.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("STUDENT_PACKAGE.CreateStudent", p, commandType: CommandType.StoredProcedure);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateStudent(Student stu)
        {
            var p = new DynamicParameters();
            p.Add("id", stu.Studentid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            p.Add("Firstname", stu.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Birthdate", stu.Birthdate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("Lastname", stu.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("STUDENT_PACKAGE.UpdateStudent", p, commandType: CommandType.StoredProcedure);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteStudent(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("STUDENT_PACKAGE.DeleteStudent", p, commandType: CommandType.StoredProcedure);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public List<StudentMarkDTO> getstudentcoursemark()
        {
            IEnumerable<StudentMarkDTO> result = dbContext.Connection.Query<StudentMarkDTO>("Student_PACKAGE.getstudentcoursemark", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
