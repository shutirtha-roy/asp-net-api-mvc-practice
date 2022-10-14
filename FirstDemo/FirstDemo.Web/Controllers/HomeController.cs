using FirstDemo.Infrastructure.Services;
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
        private readonly IDataUtility _dataUtility;
        private readonly ITimeService _timeService;
        public HomeController(ILogger<HomeController> logger, ICourseModel courseModel, IDataUtility dataUtility, ITimeService timeService)
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

            _dataUtility = dataUtility;
            _timeService = timeService;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("I am in index page");

            //string sql = $"insert into Courses (Id, Title, Fees, ClassStartDate) values('{Guid.NewGuid()}', 'UX Design', 2000, '{_timeService.Now.AddDays(30).ToString("yyyy-MM-dd")}')";
            //string sql = "delete from courses where title = 'UX Design'";
            //string sql = $"insert into Courses (Id, Title, Fees, ClassStartDate) values(@xId, @xTitle, @xFees, @xClassStartDate)";
            //IDictionary<string, object> parameters = new Dictionary<string, object>();
            //parameters.Add("xId", Guid.NewGuid());
            //parameters.Add("xTitle", "UX Design");
            //parameters.Add("xFees", 2000);
            //parameters.Add("xClassStartDate", _timeService.Now.AddDays(30));
            string sql = "select * from courses";

            //await _dataUtility.ExecuteCommandAsync(sql);
            //await _dataUtility.ExecuteCommandAsync(sql, parameters);
            var data = _dataUtility.GetDataAsync(sql, null, System.Data.CommandType.Text);

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