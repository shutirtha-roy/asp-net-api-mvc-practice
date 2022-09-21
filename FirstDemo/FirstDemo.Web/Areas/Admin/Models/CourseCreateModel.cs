using Autofac;
using FirstDemo.Infrastructure.BusinessObjects;
using FirstDemo.Infrastructure.Services;
using System.ComponentModel.DataAnnotations;

namespace FirstDemo.Web.Areas.Admin.Models
{
    public class CourseCreateModel : BaseModel
    {
        [Required]
        public string Title { get; set; }
        public double Fees { get; set; }
        public DateTime ClassStartDate { get; set; }
        private ICourseService _courseService;

        public CourseCreateModel()
        {

        }
        public CourseCreateModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        protected override void ResolveDependency(ILifetimeScope scope)
        {
            base.ResolveDependency(scope);
            _courseService = _scope.Resolve<ICourseService>();
        }

        internal async Task CreateCourse()
        {
            Course course = new Course();
            course.Name = Title;
            course.Fees = Fees;
            course.ClassStartDate = ClassStartDate;
            _courseService.CreateCourse(course);
        }
    }
}
