using OnlineCatalogue.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCatalogue.Service.DTOs
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public int Age { get; set; }
        public int? IdAddress { get; set; }
    }
}
