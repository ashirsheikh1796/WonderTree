using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WonderTreeTest.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid StudentId { get; set; }
        [Required]
        [RegularExpression("^(?:[a-zA-Z]* ){0,2}[a-zA-Z]*$", ErrorMessage = "FullName should contains only alphabets and two spaces are allowed")]
        public string FullName { get; set; }
    }

    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CourseId { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Name should contains only alphabets and numbers")]
        public string Name { get; set; }
    }

    public class Student_Course_Result
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ResultId { get; set; }
        [Required]
        public Guid StudentId { get; set; }
        [Required]
        public Guid CourseId { get; set; }
        [Required]
        public DateTime Date_Time { get; set; }
        [Range(0, 100, ErrorMessage = "Score should be in the range of 0 to 100.")]
        public int Score { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }

    public class Log
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid LogId { get; set; }
        public string Message { get; set; }
    }
}