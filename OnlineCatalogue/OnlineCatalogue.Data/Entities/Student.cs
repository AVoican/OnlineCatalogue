using System;
using System.Collections.Generic;

namespace OnlineCatalogue.Data.Entities
{
    public partial class Student
    {
        public Student()
        {
            Marks = new HashSet<Mark>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int Age { get; set; }
        public int? IdAddress { get; set; }

        public virtual Address? Address { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
    }
}
