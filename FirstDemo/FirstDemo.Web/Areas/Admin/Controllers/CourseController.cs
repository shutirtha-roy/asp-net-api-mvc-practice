using Autofac;
using FirstDemo.Web.Areas.Admin.Models;
using FirstDemo.Web.Codes;
using FirstDemo.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstDemo.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<CourseController> _logger;

        public CourseController(ILogger<CourseController> logger, ILifetimeScope scope)
        {
            _logger = logger;
            _scope = scope;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            CourseCreateModel model = _scope.Resolve<CourseCreateModel>();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseCreateModel model)
        {
            if(ModelState.IsValid)
            {
                model.ResolveDependency(_scope);
                await model.CreateCourse();
            }

            return View(model);
        }

        public IActionResult Edit(Guid id)
        {
            var model = _scope.Resolve<CourseEditModel>();
            model.LoadData(id);

            return View(model);
        }

        [ValidateAntiForgeryToken, HttpPost]
        public IActionResult Edit(CourseEditModel model)
        {
            if (ModelState.IsValid)
            {
                model.ResolveDependency(_scope);

                try
                {
                    model.EditCourse();

                    TempData["ResponseMessage"] = "Successfuly updated course.";
                    TempData["ResponseType"] = ResponseTypes.Success;

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                    TempData["ResponseMessage"] = "There was a problem in updating course.";
                    TempData["ResponseType"] = ResponseTypes.Danger;
                }
            }

            return View(model);
        }

        public IActionResult GetCourseData()
        {
            var dataTableModel = new DataTablesAjaxRequestModel(Request);
            var model = _scope.Resolve<CourseListModel>();
            return Json(model.GetPagedCourses(dataTableModel));
        }

        [ValidateAntiForgeryToken, HttpPost]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var model = _scope.Resolve<CourseListModel>();
                model.DeleteCourse(id);

                TempData["ResponseMessage"] = "Successfully delete course.";
                TempData["ResponseType"] = ResponseTypes.Success;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                TempData["ResponseMessage"] = "There was a problem in deleting course.";
                TempData["ResponseType"] = ResponseTypes.Danger;
            }

            return RedirectToAction("Index");
        }
    }
}
