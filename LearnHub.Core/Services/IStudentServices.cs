using LearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnHub.Core.Services
{
    public interface IStudentServices
    {
        List<Student> GetAllStudent();
        bool CreateStudent(Student stu);
        bool UpdateStudent(Student stu);
        bool DeleteStudent(int id);
        Student GetStudentById(int id);
        List<StudentMarkDTO> getstudentcoursemark();
    }
}
