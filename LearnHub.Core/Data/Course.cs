using System;
using System.Collections.Generic;

#nullable disable

namespace LearnHub.Core.Data
{
    public partial class Course
    {
        public Course()
        {
            Studentcousres = new HashSet<Studentcousre>();
        }

        public decimal Courseid { get; set; }
        public string Coursename { get; set; }
        public string Imagename { get; set; }
        public decimal? Categoryid { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Studentcousre> Studentcousres { get; set; }
    }
}
