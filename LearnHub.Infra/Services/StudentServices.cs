using LearnHub.Core.Data;
using LearnHub.Core.Repository;
using LearnHub.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnHub.Infra.Services
{
    public class StudentServices :IStudentServices
    {
        private readonly IStudentRepository studentRepository;
        public StudentServices(IStudentRepository _studentRepository)
        {
            studentRepository = _studentRepository;
        }
        public List<Student> GetAllStudent()
        {
            return studentRepository.GetAllStudent();
        }
        public List<StudentMarkDTO> getstudentcoursemark()
        {
            return studentRepository.getstudentcoursemark();
        }
        public bool CreateStudent(Student stu)
        {
            return studentRepository.Createstudent(stu);
        }
        public bool UpdateStudent(Student stu)
        {
            return studentRepository.UpdateStudent(stu);
        }
        public bool DeleteStudent(int id)
        {
            return studentRepository.DeleteStudent(id);
        }
        public Student GetStudentById(int id)
        {
            return studentRepository.GetStudentById(id);
        }
        
    }
}
