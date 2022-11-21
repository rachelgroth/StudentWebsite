using System.ComponentModel.DataAnnotations;

namespace StudentWebsite.Models
{
    public class Registration
    {
        public int RegistrationID { get; set; }
        public int? SectionID { get; set; }
        public int? StudentID { get; set; }

        public Section? Section { get; set; }
        public Student? Student { get; set; }
    }
}
