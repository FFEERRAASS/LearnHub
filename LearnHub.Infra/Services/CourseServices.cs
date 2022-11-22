using LearnHub.Core.Data;
using LearnHub.Core.Repository;
using LearnHub.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Infra.Services
{
    public class CourseServices : ICourseServices
    {
        private readonly ICourseRepository courseRepository;
        public CourseServices(ICourseRepository _courseRepository)
        {
            courseRepository = _courseRepository;
        }
        public List<Course> GetAllCourses()
        {
            return courseRepository.GetAllCourses();
        }
        public List<StudentMarkDTO> SearchStudent(SREACH search)
        {
            return courseRepository.SearchStudent(search);
        }
        public async Task<List<Category>> GetAllCategoryCourse()
        {
            return await courseRepository.GetAllCategoryCourse();
        }

        public bool CreateCourse(Course course)
        {
            return courseRepository.CreateCourse(course);
        }
        public bool UpdateCourse(Course course)
        {
            return courseRepository.UpdateCourse(course);
        }
        public bool DeleteCourse(int id)
        {
            return courseRepository.DeleteCourse(id);
        }
        public Course GetCourseById(int id)
        {
            return courseRepository.GetCourseById(id);
        }
        public List<CountStudentCourse> CountStudentCourses()
        {
            return courseRepository.CountStudentCourses();
        }



    }
}
