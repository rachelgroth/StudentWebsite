using StudentWebsite.Models;

namespace StudentWebsite.Data
{
    public class DBInitializer
    {
        public static void Initialize(StudentWebsiteContext context)
        {
            context.Database.EnsureCreated();

            if (context.Registration.Any())
            {
                return;
            }

            var students = new Student[]
            {
                new Student{ FirstName = "Bob", LastName = "Smith", Email = "bobsmith@gmail.com", Major = "English", Phone = "605-123-4567" },
                new Student{ FirstName = "Becky", LastName = "Smith", Email = "beckysmith@gmail.com", Major = "Computer Science", Phone = "605-765-4321" },
                new Student{ FirstName = "Jessica", LastName = "Nelson", Email = "jnels@hotmail.com", Major = "English", Phone = "605-123-1234" },
                new Student{ FirstName = "Payden", LastName = "Woo", Email = "woop@gmail.com", Major = "Math", Phone = "605-111-2222" },
                new Student{ FirstName = "Tim", LastName = "Jones", Email = "tjones@gmail.com", Major = "Physical Science", Phone = "605-555-5555" },
                new Student{ FirstName = "Jeff", LastName = "Bones", Email = "jeffbones@gmail.com", Major = "Cyber Security", Phone = "605-111-1111" },
                new Student{ FirstName = "Kelsey", LastName = "Olson", Email = "kolson@gmail.com", Major = "Computer Science", Phone = "605-222-1111" }
            };
            foreach (Student s in students)
            {
                context.Student.Add(s);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course{
                    CourseCode = "ENGL101",
                    Name = "Composition I",
                    Description = "Practice in the skills, research, and documentation needed for the effective academic writing. Analysis of a variety of academic and non-academic texts, rhetorical structures, critical thinking, and audience will be included."
                },
                new Course{
                    CourseCode = "ENGL201",
                    Name = "Composition II",
                    Description = "Study of and practice in writing persuasive prose, with the aim to improve writing skills in all disciplines."
                },
                new Course{
                    CourseCode = "ART111",
                    Name = "Drawing I",
                    Description = "Introduces various drawing concepts, media, and processes developing perceptual and technical skills related to accurate observing and drawing."
                },
                new Course{
                    CourseCode = "PSYC101",
                    Name = "General Psychology",
                    Description = "This course is an introduction survey of the field of psychology with consideration of the biological bases of behavior, sensory and perceptual processes, learning and memory, human growth and development, social behavior and normal and abnormal behavior."
                },
                new Course{
                    CourseCode = "MATH123",
                    Name = "Calculus I",
                    Description = "The study of limits, continuity, derivatives, applications of the derivative, antiderivatives, the definite and indefinite integral, and the fundamental theorem of calculus."
                },
                new Course{
                    CourseCode = "CSC105",
                    Name = "Introduction to Computers",
                    Description = "Overview of computer applications with emphasis on word processing, spreadsheets, database, presentation tools and internet-based applications."
                },
                new Course{
                    CourseCode = "CSC150",
                    Name = "Computer Science I",
                    Description = "An introduction to computer programming. Focus on problem solving, algorithm development, design, and programming concepts. Topics include sequence, selection, repetition, functions, and arrays."
                }
            };
            foreach (Course c in courses)
            {
                context.Course.Add(c);
            }
            context.SaveChanges();

            var sections = new Section[]
            {
                new Section{ CourseID = 1, TotalSpots = 5, Professor = "Dr. Ross"},
                new Section{ CourseID = 1, TotalSpots = 7, Professor = "Dr. English"},
                new Section{ CourseID = 2, TotalSpots = 5, Professor = "Dr. Ross"},
                new Section{ CourseID = 3, TotalSpots = 10, Professor = "Mr. Rogers"},
                new Section{ CourseID = 3, TotalSpots = 10, Professor = "Ms. White"},
                new Section{ CourseID = 4, TotalSpots = 5, Professor = "Dr. Hope"},
                new Section{ CourseID = 5, TotalSpots = 5, Professor = "Dr. Nye"},
                new Section{ CourseID = 6, TotalSpots = 7, Professor = "Dr. Tim"},
                new Section{ CourseID = 7, TotalSpots = 10, Professor = "Dr. Tim"},
            };
            foreach (Section s in sections)
            {
                context.Section.Add(s);
            }
            context.SaveChanges();

            var registrations = new Registration[]
            {
                new Registration{ SectionID = 1, StudentID = 1},
                new Registration{ SectionID = 2, StudentID = 2},
                new Registration{ SectionID = 3, StudentID = 3},
                new Registration{ SectionID = 4, StudentID = 4},
                new Registration{ SectionID = 5, StudentID = 5},
                new Registration{ SectionID = 6, StudentID = 6},
                new Registration{ SectionID = 7, StudentID = 7},
                new Registration{ SectionID = 8, StudentID = 1},
                new Registration{ SectionID = 9, StudentID = 2},
                new Registration{ SectionID = 1, StudentID = 3},
                new Registration{ SectionID = 2, StudentID = 4},
                new Registration{ SectionID = 3, StudentID = 5},
                new Registration{ SectionID = 4, StudentID = 6},
                new Registration{ SectionID = 5, StudentID = 7}
            };
            foreach(Registration r in registrations)
            {
                context.Registration.Add(r);
            }
            context.SaveChanges();
        }
    }
}
