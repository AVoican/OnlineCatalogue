using System;
using System.Collections.Generic;

namespace OnlineCatalogue.Data.Entities
{
    public partial class Teacher
    {
        public Teacher()
        {
            Subjects = new HashSet<Subject>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? IdAddress { get; set; }
        public int Rank { get; set; }

        public virtual Address? Address { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
