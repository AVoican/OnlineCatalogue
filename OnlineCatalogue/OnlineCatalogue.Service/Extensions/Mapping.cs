using OnlineCatalogue.Data.Entities;
using OnlineCatalogue.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCatalogue.Service.Extensions
{
    public static class Mapping
    {
        public static StudentDto Map(this Student student)
        {
            return new StudentDto
            {
                Age = student.Age,
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                IdAddress = student.IdAddress
            };
        }

        public static Student Map(this StudentCreateDto studentToCreate)
        {
            return new Student
            {
                Age = studentToCreate.Age,
                FirstName = studentToCreate.FirstName,
                LastName = studentToCreate.LastName
            };
        }
    }
}
