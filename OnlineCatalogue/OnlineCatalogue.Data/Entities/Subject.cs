using System;
using System.Collections.Generic;

namespace OnlineCatalogue.Data.Entities
{
    public partial class Subject
    {
        public Subject()
        {
            Marks = new HashSet<Mark>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? IdTeacher { get; set; }

        public virtual Teacher? Teacher { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
    }
}
