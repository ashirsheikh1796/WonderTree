using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Xml;

namespace WonderTreeTest.Models
{
    public class WonderTreeContext : DbContext
    {
        public WonderTreeContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new DatabaseInitializer());
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student_Course_Result> Student_Course_Results { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}