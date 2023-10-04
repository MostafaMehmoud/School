using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }
        [MinLength(5)]
        [MaxLength(15)]
        public string CourseName { get; set; }
        public int TeacherId {  get; set; }
        public Teacher Teacher { get; set;}
        [Range(0, 25)]
        public int CourseCapicity { get; set; }


    }
}
