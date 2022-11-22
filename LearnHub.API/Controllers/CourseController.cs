using LearnHub.Core.Data;
using LearnHub.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;

namespace LearnHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseServices courseServices;
        public CourseController(ICourseServices courseServices)
        {
            this.courseServices = courseServices;
        }
        [HttpGet]
        [Route("GetAllCourse")]
        public List<Course> GetAllCourses()
        {
            return courseServices.GetAllCourses();
        }
        [HttpGet]
        [Route("GetCourseById/{id}")]
        public Course GetCourseById(int id)
        {
            return courseServices.GetCourseById(id);
        }
        [HttpPost]
        [Route("createcourse")]
        public bool CreateCourse([FromForm] Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }
            else
            {
                var image = UploadImage();
                course.Imagename = image;
                return courseServices.CreateCourse(course);
            }
        }
        [HttpPut]
        [Route("updatecourse")]
        public bool UpdateCourse(Course course)
        {
            return courseServices.UpdateCourse(course);
        }
        [HttpDelete]
        [Route("deletecourse/{id}")]
        public bool DeleteCourse(int id)
        {
            return courseServices.DeleteCourse(id);
        }
        [HttpPost]
        [Route("UploadImage")]
        public string UploadImage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullpath = Path.Combine("Image/", fileName);
            using (var stream = new FileStream(fullpath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Course course = new Course();
            course.Imagename = fileName;
            return course.Imagename;

        }
        [HttpPost]
        [Route("SearchHH")]
        
        public List<StudentMarkDTO> SearchStudent(SREACH search)
        {
            return courseServices.SearchStudent(search);
        }
        [HttpGet("GetAllCS")]
        public async Task<List<Category>> GetAllCategoryCourse()
        {
            return await courseServices.GetAllCategoryCourse();
        }

    }
}
