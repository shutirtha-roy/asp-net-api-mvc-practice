﻿using Autofac;
using FirstDemo.Web.Areas.Admin.Models;
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

        public IActionResult GetCourseData()
        {
            var dataTableModel = new DataTablesAjaxRequestModel(Request);
            var model = _scope.Resolve<CourseListModel>();
            return Json(model.GetPagedCourses(dataTableModel));
        }
    }
}
