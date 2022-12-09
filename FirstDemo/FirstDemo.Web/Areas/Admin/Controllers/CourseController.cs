using Autofac;
using FirstDemo.Web.Areas.Admin.Models;
using FirstDemo.Web.Utilities;
using FirstDemo.Web.Models;
using Microsoft.AspNetCore.Mvc;
using FirstDemo.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Authorization;

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

        [Authorize(Policy = "CourseViewRequirementPolicy")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Policy = "CourseViewRequirementPolicy")]
        public IActionResult Create()
        {
            CourseCreateModel model = _scope.Resolve<CourseCreateModel>();
            return View(model);
        }

        [Authorize(Policy = "CourseCreatePolicy")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseCreateModel model)
        {
            if (ModelState.IsValid)
            {
                model.ResolveDependency(_scope);

                try
                {
                    await model.CreateCourse();
                    TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                    {
                        Message = "Successfully added a new course.",
                        Type = ResponseTypes.Success
                    });

                    return RedirectToAction("Index");
                }
                catch (DuplicateException ioe)
                {
                    _logger.LogError(ioe, ioe.Message);
                    ModelState.AddModelError("", ioe.Message);

                    TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                    {
                        Message = ioe.Message,
                        Type = ResponseTypes.Danger
                    });
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);

                    TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                    {
                        Message = "There was a problem in creating course.",
                        Type = ResponseTypes.Danger
                    });
                }
            }
            else
            {
                string messageText = string.Empty;
                foreach (var message in ModelState.Values)
                {
                    for (int i = 0; i < message.Errors.Count; i++)
                    {
                        messageText += message.Errors[i].ErrorMessage;
                    }
                }

                TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                {
                    Message = messageText,
                    Type = ResponseTypes.Danger
                });
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

                    TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                    {
                        Message = "Successfully edited the course.",
                        Type = ResponseTypes.Success
                    });

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);

                    TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                    {
                        Message = "There was a problem in editing course.",
                        Type = ResponseTypes.Danger
                    });
                }
            }

            return View(model);
        }

        //public IActionResult GetCourseData()
        //{
        //    var dataTableModel = new DataTablesAjaxRequestModel(Request);
        //    var model = _scope.Resolve<CourseListModel>();
        //    return Json(model.GetPagedCourses(dataTableModel));
        //}

        [ValidateAntiForgeryToken, HttpPost]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var model = _scope.Resolve<CourseListModel>();
                model.DeleteCourse(id);

                TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                {
                    Message = "Successfully deleted the course.",
                    Type = ResponseTypes.Success
                });
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                {
                    Message = "There was a problem in deleting course.",
                    Type = ResponseTypes.Danger
                });
            }

            return RedirectToAction("Index");
        }
    }
}
