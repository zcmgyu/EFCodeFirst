using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCodeFirstDemo
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EFDbContext : DbContext
    {

        public EFDbContext()
            : base("name=EFDbContext")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<EFDbContext>());
            Database.SetInitializer<EFDbContext>(new );
        }


        public DbSet<Standard> Standards { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentAddress> StudentAddresses { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public class EFCodeFirstInitializer: DropCreateDatabaseIfModelChanges<EFDbContext>
        {
            protected override void Seed(EFDbContext context)
            {
                IList<Standard> defaultStandards = new List<Standard>();
                defaultStandards.Add(new Standard() {StandardName = "Standard 1", Description = "First Standard"});
                defaultStandards.Add(new Standard() { StandardName = "Standard 2", Description = "Second Standard" });
                defaultStandards.Add(new Standard() { StandardName = "Standard 3", Description = "Third Standard" });
                foreach (var standard in defaultStandards)
                {
                    context.Standards.Add(standard);
                }
                base.Seed(context);
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //// Configure StudentId as PK for StudentAddress
            //modelBuilder.Entity<StudentAddress>().HasKey(e => e.StudentId);

            //// Configure StudentId as FK for StudentAddress
            //modelBuilder.Entity<Student>()
            //    .HasOptional(s => s.StudentAddress)
            //    .WithRequired(ad => ad.Student);
        }

        
    }

    public class Standard
    {
        public int StandardId { get; set; }
        public string StandardName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Student> Students { get; set; }

    }

    public class Student
    {

        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int? StandardId { get; set; }
        //public string Address { get; set; }
        //public virtual StudentAddress StudentAddress { get; set; }
        public virtual Standard Standard { get; set; }

        public virtual StudentAddress StudentAddress { get; set; }
    }

    public class StudentAddress
    {
        [Key, ForeignKey("Student")]
        public int StudentId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Required]
        public virtual Student Student { get; set; }
    }

    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public virtual Standard Standard { get; set; }
        public ICollection<Course> Coures { get; set; }
        public int TeacherType { get; set; }
    }

    public class Course
    {
        public int CourseId { get; set; }
        public string CourseNam { get; set; }
        public string Location { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<Course> Courses { get; set; }
    }

    
}
