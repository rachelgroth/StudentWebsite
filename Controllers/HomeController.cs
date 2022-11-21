using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentWebsite.Data;
using StudentWebsite.Models;
using System.Diagnostics;

namespace StudentWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly StudentWebsiteContext _context;


        public HomeController(ILogger<HomeController> logger, StudentWebsiteContext context)
        {
            _logger = logger;
            _context = context;
        }

        //GET Students
        public async Task<IActionResult> Index()
        {
            var viewModel = new StudentViewModel
            {
                Students = _context.Student.Include(s => s.Registrations).ToList(),
                Courses = _context.Course.Include(c => c.Sections).ToList()
            };
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}