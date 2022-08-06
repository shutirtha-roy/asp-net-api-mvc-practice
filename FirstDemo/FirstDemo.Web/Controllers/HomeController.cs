using FirstDemo.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FirstDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly ICourseModel _courseModel;
        private static ICourseModel _courseModel;
        public HomeController(ILogger<HomeController> logger, ICourseModel courseModel)
        {
            _logger = logger;

            if(_courseModel != null)
            {
                if(courseModel == _courseModel)
                {
                    int x = 5;
                }
            }
            else
                _courseModel = courseModel;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("I am in index page");
            return View();
        }

        public IActionResult Privacy()
        {
            //Guid id = new Guid("734D4A8F - 0FBE - 4FAB - 8DB2 - 066EDEE3D1FD");
            //Guid id = new Guid();
            _logger.LogInformation("I am in privacy page");
            return View();
        }

        public IActionResult Test()
        {
            var model = new TestModel();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}