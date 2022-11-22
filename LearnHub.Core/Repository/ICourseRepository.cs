using LearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Core.Repository
{
    public interface ICourseRepository
    {
        List<Course> GetAllCourses();
        bool CreateCourse(Course course);
        bool UpdateCourse(Course course);
        bool DeleteCourse(int id);
        Course GetCourseById(int id);
        List<StudentMarkDTO> SearchStudent(SREACH search);
        Task<List<Category>> GetAllCategoryCourse();


    }
}
