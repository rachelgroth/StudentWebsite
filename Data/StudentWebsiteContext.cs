using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentWebsite.Models;

namespace StudentWebsite.Data
{
    public class StudentWebsiteContext : DbContext
    {
        public StudentWebsiteContext (DbContextOptions<StudentWebsiteContext> options)
            : base(options)
        {
        }

        public DbSet<StudentWebsite.Models.Student> Student { get; set; } = default!;

        public DbSet<StudentWebsite.Models.Course> Course { get; set; } = default!;

        public DbSet<StudentWebsite.Models.Section> Section { get; set; } = default!;

        public DbSet<StudentWebsite.Models.Registration> Registration { get; set; } = default!;

    }
}
