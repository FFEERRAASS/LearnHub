using LearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnHub.Core.Repository
{
    public interface IStudentRepository
    {
        List<Student> GetAllStudent();
        bool Createstudent(Student stu);
        bool UpdateStudent(Student stu);
        bool DeleteStudent(int id);
        Student GetStudentById(int id);
        List<StudentMarkDTO> getstudentcoursemark();
    }
}
