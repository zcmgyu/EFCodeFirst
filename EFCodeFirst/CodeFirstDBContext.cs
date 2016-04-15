using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst
{
    public class Standard
    {
        public int StandardId { get; set; }
        public string StandardName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Student> Students  { get; set; }

    }

    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int? StandardId { get; set; }
        public string Address { get; set; }
        public virtual Standard Standard{ get; set; }

    }

    class CodeFirstDbContext:DbContext
    {

        public CodeFirstDbContext() : base("name=MySchoolDb")
        {
            
        }
        public DbSet<Standard> Standards { get; set; }
        public DbSet<Student> Students { get; set; }

    }
}
