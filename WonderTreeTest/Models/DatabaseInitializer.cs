using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WonderTreeTest.Models
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<WonderTreeContext>
    {
        protected override void Seed(WonderTreeContext context)
        {
            base.Seed(context);

            var student1 = new Student() { FullName = "Muhammad Ashir Sheikh" };
            var student2 = new Student() { FullName = "Arsalan Ahmed" };
            var student3 = new Student() { FullName = "Hira Iqbal" };

            var course1 = new Course() { Name = "A101" };
            var course2 = new Course() { Name = "B202" };
            var course3 = new Course() { Name = "C303" };

            var result = new List<Student_Course_Result>() {
                new Student_Course_Result() { Course = course1, Date_Time = DateTime.Now, Student = student1, Score = 100 },
                new Student_Course_Result() { Course = course2, Date_Time = DateTime.Now, Student = student2, Score = 50 },
                new Student_Course_Result() { Course = course3, Date_Time = DateTime.Now, Student = student3, Score = 0 },
            };

            context.Student_Course_Results.AddRange(result);
            context.SaveChanges();
        }
    }
}