using System;
using System.Collections.Generic;

#nullable disable

namespace LearnHub.Core.Data
{
    public partial class Student
    {
        public Student()
        {
            Logins = new HashSet<Login>();
            Studentcousres = new HashSet<Studentcousre>();
        }

        public decimal Studentid { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime? Birthdate { get; set; }

        public virtual ICollection<Login> Logins { get; set; }
        public virtual ICollection<Studentcousre> Studentcousres { get; set; }
    }
}
