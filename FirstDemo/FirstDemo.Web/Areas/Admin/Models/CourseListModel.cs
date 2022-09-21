using Autofac;
using FirstDemo.Infrastructure.Services;

namespace FirstDemo.Web.Areas.Admin.Models
{
    public class CourseListModel : BaseModel
    {
        private ICourseService? _courseService;

        public CourseListModel() : base()
        {

        }

        public CourseListModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        protected override void ResolveDependency(ILifetimeScope scope)
        {
            base.ResolveDependency(scope);
            _courseService = _scope.Resolve<ICourseService>();
        }

        internal object? GetPagedCourses(object dataTableModel)
        {
            throw new NotImplementedException();
        }
    }
}
