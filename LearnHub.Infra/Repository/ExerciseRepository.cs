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
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly IDbContext dbContext;
        public ExerciseRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<Student> GetStudentByFirstName(string firstName)
        {
            var p = new DynamicParameters();
            p.Add("FirstName", firstName, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<Student> result = dbContext.Connection.Query<Student>("EXERCISE_PACKAGE.GetStudentByFirstName",p,commandType:CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<Student> GetStudentFnameAndLname()
        {
            var p = new DynamicParameters();
            IEnumerable<Student> result = dbContext.Connection.Query<Student>("EXERCISE_PACKAGE.GetStudentByFNameAndLName", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<Student> GetStudentByBirthDay(DateTime birth)
        {
            var p = new DynamicParameters();
            p.Add("birthdate", birth, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<Student> result = dbContext.Connection.Query<Student>("EXERCISE_PACKAGE.GetStudentByBirthdate", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<Student> GetStudentByBetweenDate(DateTime DateFrom, DateTime DateTo)
        {
            var p = new DynamicParameters();
            p.Add("DateF", DateFrom, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("DateE", DateTo, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<Student> result = dbContext.Connection.Query<Student>("EXERCISE_PACKAGE.GetStudentBetweenInterval", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<Student> GetStudentByWithHighestMark(int numOfStudent)
        {
            var p = new DynamicParameters();
            p.Add("numberOfStudent", numOfStudent, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Student> result = dbContext.Connection.Query<Student>("EXERCISE_PACKAGE.GetStudentWithHighestMarks", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

    }
}
