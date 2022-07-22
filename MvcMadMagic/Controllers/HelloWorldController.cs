using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Encodings.Web;

namespace MvcMadMagic.Controllers
{
    public class HelloWorldController : Controller
    {
        private readonly ILogger<HelloWorldController> _logger;

        public HelloWorldController(ILogger<HelloWorldController> logger)
        {
            _logger = logger;
        }
        // 
        // GET: /HelloWorld/
        public IActionResult Index()
        {
            return  View();
        }

        // 
        // GET: /HelloWorld/Welcome/ 
        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"]  = numTimes;
            return View();
        }

        // GET: /HelloWorld/Check/ 
        public string Check(string name, int steps = 1)
        {
            string res = "";
            for (int i = 0; i < steps; i++)
            {
                res += $"{name} did new step\r\n";
            }
            return HtmlEncoder.Default.Encode(res);
        }

        public string Peck(string name, int ID = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
        }

    }
}