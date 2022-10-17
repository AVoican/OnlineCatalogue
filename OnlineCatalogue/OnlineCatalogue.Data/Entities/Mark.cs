using System;
using System.Collections.Generic;

namespace OnlineCatalogue.Data.Entities
{
    public partial class Mark
    {
        public int IdStudent { get; set; }
        public int IdSubject { get; set; }
        public int Value { get; set; }
        public DateTime Moment { get; set; }

        public virtual Student Student { get; set; } = null!;
        public virtual Subject Subject { get; set; } = null!;
    }
}
