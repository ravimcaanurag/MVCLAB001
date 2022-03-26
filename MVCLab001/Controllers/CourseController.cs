using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
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
            var credential = new DefaultAzureCredential();
            var client = new SecretClient(new Uri("https://labkv001.vault.azure.net/"), credential);
            var secret = client.GetSecret("sqlcnn");
            string actualSecret = secret.Value.Value;
            ViewBag.secret = actualSecret;

            return View(ser.getCourses());
        }
    }
}
