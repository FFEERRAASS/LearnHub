using LearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnHub.Core.Repository
{
    public interface ICourseStudentRepository
    {
        List<Studentcousre> GetAllCourseStudent();
        bool CreateCourseStudent(Studentcousre stu);
        bool UpdateCourseStudent(Studentcousre stu);
        bool DeleteCourseStudent(int id);
        Studentcousre GetCourseStudentById(int id);
    }
}
