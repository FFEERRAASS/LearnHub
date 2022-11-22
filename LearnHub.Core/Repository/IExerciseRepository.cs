using LearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnHub.Core.Repository
{
    public interface IExerciseRepository
    {
        List<Student> GetStudentByFirstName (string firstName);
        List<Student> GetStudentFnameAndLname();
        List<Student> GetStudentByBirthDay (DateTime birth);
        List<Student> GetStudentByBetweenDate(DateTime DateFrom , DateTime DateTo);
        List<Student> GetStudentByWithHighestMark (int numOfStudent);

    }
}
