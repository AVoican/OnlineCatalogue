using Microsoft.EntityFrameworkCore;
using OnlineCatalogue.Data.Entities;
using OnlineCatalogue.Service.DTOs;
using OnlineCatalogue.Service.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCatalogue.Service.Services
{
    public class StudentService : IStudentService
    {
        private OnlineCatalogueDbContext dbContext;

        public StudentService(OnlineCatalogueDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int CreateStudent(StudentCreateDto studentCreateDto)
        {
            var newStudent = studentCreateDto.Map();
            dbContext.Students.Add(newStudent);
            dbContext.SaveChanges();
            return newStudent.Id;
        }

        public int? DeleteStudent(int id)
        {
            var student = dbContext.Students.SingleOrDefault(s => s.Id == id);

            if (student == null)
            {
                return null;
            }

            dbContext.Students.Remove(student);
            dbContext.SaveChanges();
            return id;
        }

        public int? DeleteStudent(int id,bool deleteAddress)
        {
            var student = dbContext.Students.Include(s => s.Address).SingleOrDefault(s => s.Id == id);

            if (student == null)
            {
                return null;
            }

            if (deleteAddress)
            {
                if (student.Address != null) 
                {
                    dbContext.Addresses.Remove(student.Address);
                }
            }
            dbContext.Students.Remove(student);
            dbContext.SaveChanges();
            return id;
        }

        public StudentEditDto EditStudent(StudentEditDto studentDto)
        {
            var student = dbContext.Students.SingleOrDefault(s => s.Id == studentDto.Id);


            if (student == null)
            {
                return null;
            }

            student.FirstName = studentDto.FirstName;
            student.LastName = studentDto.LastName;
            student.Age = studentDto.Age;
            dbContext.SaveChanges();
            return studentDto;
        }

        public StudentAddressEditDto EditStudentAddress(StudentAddressEditDto studentAddressEditDto)
        {
            var student = dbContext.Students.Include(s=>s.Address).SingleOrDefault(s => s.Id == studentAddressEditDto.IdStudent);

            if (student == null)
            {
                return null;
            }

            if (student.Address == null)
            {
                student.Address = new Address { 
                    Number = studentAddressEditDto.Number,
                    City = studentAddressEditDto.City,
                    Street = studentAddressEditDto.Street
                };
            }
            else
            {
                student.Address.Number = studentAddressEditDto.Number;
                student.Address.City = studentAddressEditDto.City;
                student.Address.Street = studentAddressEditDto.Street;
            }

            dbContext.SaveChanges();
            return studentAddressEditDto;
        }

        public List<StudentDto> GetAllStudents()
        {
            return dbContext.Students.Select(x => x.Map()).ToList();
        }

        public StudentDto GetStudentById(int id)
        {
            return dbContext.Students.SingleOrDefault(s => s.Id == id)?.Map();
        }
    }
}
