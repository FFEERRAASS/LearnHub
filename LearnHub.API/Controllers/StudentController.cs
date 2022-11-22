using LearnHub.Core.Data;
using LearnHub.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LearnHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices studentServices;
        public StudentController(IStudentServices studentServices)
        {
            this.studentServices = studentServices;
        }
        [HttpGet]
        [Route("GetAllStudent")]
        public List<Student> GetAllStudent()
        {
            return studentServices.GetAllStudent();
        }
        [HttpGet]
        [Route("getstudentcoursemark")]
        
        public List<StudentMarkDTO> getstudentcoursemark()
        {
            return studentServices.getstudentcoursemark();
        }
    }
}
