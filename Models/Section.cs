using System.ComponentModel.DataAnnotations;

namespace StudentWebsite.Models
{
    public class Section
    {
        public int ID { get; set; }
        [Display(Name = "Course ID")]
        public int CourseID { get; set; }
        [Display(Name = "Total Spots")]
        public int TotalSpots { get; set; }
        public string Professor { get; set; }

        public Course? Course { get; set; }
        public ICollection<Registration>? Registrations { get; set; }
    }
}
