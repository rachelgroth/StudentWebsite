using System.ComponentModel.DataAnnotations;

namespace StudentWebsite.Models
{
    public class Course
    {
        public int ID { get; set; }
        [Display(Name="Course Code")]
        public string CourseCode { get; set; }
        [Display(Name="Course Name")]
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Section>? Sections { get; set; }
    }
}
