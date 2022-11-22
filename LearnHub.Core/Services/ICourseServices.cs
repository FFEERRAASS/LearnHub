using LearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Core.Services
{
    public interface ICourseServices
    {
        List<StudentMarkDTO> SearchStudent(SREACH search);

        List<Course> GetAllCourses();
        bool CreateCourse(Course course);
        bool UpdateCourse(Course course);
        bool DeleteCourse(int id);
        Course GetCourseById(int id);
        Task<List<Category>> GetAllCategoryCourse();
        List<CountStudentCourse> CountStudentCourses();


    }
}
