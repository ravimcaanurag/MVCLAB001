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
            SecretClientOptions options = new SecretClientOptions()
            {
                Retry =
        {
            Delay= TimeSpan.FromSeconds(2),
            MaxDelay = TimeSpan.FromSeconds(16),
            MaxRetries = 5,
            Mode = RetryMode.Exponential
         }
            };
            var client = new SecretClient(new Uri("https://labkv001.vault.azure.net/"), new DefaultAzureCredential(), options);

            KeyVaultSecret secret = client.GetSecret("sqlcnn");

            string secretValue = secret.Value;
            ViewBag.secret = secretValue;

            return View(ser.getCourses());
        }
    }
}
