using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TryEFWeb.Models;

namespace TryEFWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DataContext _context = null;

        public HomeController(ILogger<HomeController> logger, DataContext ctx)
        {
            this._logger = logger;
            this._context = ctx;
        }

        public async Task<IActionResult> Index()
        {
            Teacher teacher = await _context.Teachers.FindAsync(1);
            teacher.TeacherName = "Mr. Freeman";
            _context.Update(teacher);
            await _context.SaveChangesAsync();


            Student Tom = _context.Students.Where(s => s.StudentName == "Tom Cat").FirstOrDefault();
            if (Tom != null)
            {
                _context.Students.Remove(Tom);
                await _context.SaveChangesAsync();
            }


            /*Student newStudent = new Student();
            newStudent.Gender = 1;
            newStudent.StudentName = "Tom Cat";
            await _context.Students.AddAsync(newStudent);
            await _context.SaveChangesAsync();*/

            //Teacher teacher = _context.Teachers.Where(t => t.Id == 1).FirstOrDefault();
            //Student student = _context.Students.Where(s => s.Id == 1).FirstOrDefault();
            //Course course = _context.Courses.Where(c => c.Id == 1).FirstOrDefault();
            //StudentCourse sc = _context.StudentCourses.Where(sc => sc.Id == 1).FirstOrDefault();
            return View();
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
