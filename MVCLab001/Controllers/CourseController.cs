using Microsoft.AspNetCore.Mvc;
using MVCLab001.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCLab001.Controllers
{
    public class CourseController : Controller
    {
        public readonly courseService ser;
        public CourseController(courseService _ser)
        {
            ser = _ser;
        }

        [Route("Course/Display")]
        public IActionResult Index()
        {

            return View(ser.getCourses());
        }
    }
}
