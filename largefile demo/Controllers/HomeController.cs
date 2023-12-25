using largefile_demo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace largefile_demo.Controllers
{
    public class HomeController : Controller
    {
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        public IActionResult Index()
        {
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

        [HttpPost]
        public IActionResult formsubmit(IFormFile file12)
        {
            var path = Path.Combine("wwwroot", "Uploads");
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var datapath = Path.Combine(path, file12.FileName);
            using(var stream =new FileStream(datapath , FileMode.Create))
            {
                file12.CopyTo(stream);
            }


            return View("Index");  
        }
    }
}