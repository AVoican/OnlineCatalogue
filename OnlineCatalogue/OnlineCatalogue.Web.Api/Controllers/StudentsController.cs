using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OnlineCatalogue.Data.Entities;
using OnlineCatalogue.Service.DTOs;
using OnlineCatalogue.Service.Services;

namespace OnlineCatalogue.Web.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private IStudentService studentService { get; set; }

        public StudentsController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        /// <summary>
        /// Retrieves all students 
        /// </summary>
        /// <returns>Students list</returns>
        [HttpGet("GetAllStudents")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<StudentDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
        public IActionResult GetAllStudents()
        {
            try
            {
                var students = studentService.GetAllStudents();
                return Ok(students);
            }
            catch (Exception ex)    
            {
                return StatusCode(500, ex);
            }
        }

        /// <summary>
        /// Gets a student based on its id
        /// </summary>
        /// <param name="id">student id to get</param>
        /// <returns>student information</returns>
        [HttpGet("GetStudentById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
        public IActionResult GetStudentById(int id)
        {
            try
            {
                var student = studentService.GetStudentById(id);

                if(student == null)
                {
                    return NotFound($"No student with ID: {id} was found.");
                }

                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        
        /// <summary>
        /// Creates a new student
        /// </summary>
        /// <param name="studentToCreate"></param>
        /// <returns>Created student</returns>
        [HttpPost("CreateStudent")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult CreateStudent(StudentCreateDto studentToCreate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var studentId = studentService.CreateStudent(studentToCreate);
                    return Ok(studentId);
                }

                var message = string.Join(" | ", ModelState.Values
                                .SelectMany(v => v.Errors)
                                .Select(e => e.ErrorMessage));

                return BadRequest(message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        /// <summary>
        /// Deletes a student
        /// </summary>
        /// <param name="idStudent"></param>
        /// <returns>The ID of the deleted student</returns>
        [HttpDelete("DeleteStudent{idStudent}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IActionResult DeleteStudent(int idStudent)
        {
            try
            {      
                var deletedStudentId = studentService.DeleteStudent(idStudent);

                if(deletedStudentId == null)
                {
                    return NotFound($"No student with ID: {idStudent} was found.");
                }

                return Ok(deletedStudentId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        /// <summary>
        /// Updates a student's information
        /// </summary>
        /// <param name="newStudentData"></param>
        /// <returns>Updated student</returns>
        [HttpPut("EditStudent")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentEditDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IActionResult EditStudent(StudentEditDto studentToEdit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var updatedStudent = studentService.EditStudent(studentToEdit);
                    if (updatedStudent == null)
                    {
                        return NotFound($"No student with ID: {studentToEdit.Id} was found.");
                    }

                    return Ok(updatedStudent);
                }

                var message = string.Join(" | ", ModelState.Values
                                .SelectMany(v => v.Errors)
                                .Select(e => e.ErrorMessage));

                return BadRequest(message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        /// <summary>
        /// Updates a student's address
        /// </summary>
        /// <param name="studentAddress"></param>
        /// <returns>Updated student address</returns>
        [HttpPut("EditStudentAddress")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentAddressEditDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IActionResult EditStudentAddress(StudentAddressEditDto studentAddressToEdit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var updatedStudentAddress = studentService.EditStudentAddress(studentAddressToEdit);
                    if (updatedStudentAddress == null)
                    {
                        return NotFound($"No student with ID: {studentAddressToEdit.IdStudent} was found.");
                    }

                    return Ok(updatedStudentAddress);
                }

                var message = string.Join(" | ", ModelState.Values
                                .SelectMany(v => v.Errors)
                                .Select(e => e.ErrorMessage));

                return BadRequest(message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}