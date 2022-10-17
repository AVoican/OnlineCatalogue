using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCatalogue.Service.DTOs
{
    public class StudentCreateDto
    {
        [Required]
        [StringLength(128)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(128)]
        public string LastName { get; set; }
        [Required]
        [Range(1,100,ErrorMessage = "Age must be between 1 and 100")]
        public int Age { get; set; }
    }
}
