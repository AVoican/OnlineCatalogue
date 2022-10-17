using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCatalogue.Service.DTOs
{
    public class StudentAddressEditDto
    {
        [Required]
        public int IdStudent { get; set; }
        [Required]
        [StringLength(128)]
        public string City { get; set; }
        [Required]
        [StringLength(128)]
        public string Street { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = $"Number must be greater than 0.")]
        public int Number { get; set; }
    }
}
