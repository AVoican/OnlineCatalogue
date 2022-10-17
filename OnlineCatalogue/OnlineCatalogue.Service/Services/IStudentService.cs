using OnlineCatalogue.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCatalogue.Service.Services
{
    public interface IStudentService
    {
        List<StudentDto> GetAllStudents();
        StudentDto GetStudentById(int id);

        int CreateStudent(StudentCreateDto studentCreateDto);

        int? DeleteStudent(int id);

        StudentEditDto EditStudent(StudentEditDto studentDto);
        StudentAddressEditDto EditStudentAddress(StudentAddressEditDto studentAddressEditDto);
    }
}
