using Autofac;
using AutoMapper;
using FirstDemo.Infrastructure.BusinessObjects;
using FirstDemo.Infrastructure.Models;
using FirstDemo.Infrastructure.Services;

namespace FirstDemo.API.Models
{
    public class CourseModel
    {
        private ICourseService? _courseService;
        private IMapper _mapper;

        public Guid Id { get; set; }
        public string Title { get; set; }
        public double Fees { get; set; }
        public DateTime ClassStartDate { get; set; }

        public CourseModel()
        {

        }

        public CourseModel(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _courseService = scope.Resolve<ICourseService>();
            _mapper = scope.Resolve<IMapper>();
        }

        internal IList<Course> GetCourses()
        {
            return _courseService?.GetCourses();
        }

        internal void DeleteCourse(Guid id)
        {
            _courseService?.DeleteCourse(id);
        }

        internal void CreateCourse()
        {
            Course course = _mapper.Map<Course>(this);

            _courseService.CreateCourse(course);
        }

        internal void UpdateCourse()
        {
            Course course = _mapper.Map<Course>(this);

            _courseService.EditCourse(course);
        }

        internal Course GetCourse(string name)
        {
            return _courseService.GetCourse(name);
        }

        internal Course GetCourse(Guid id)
        {
            return _courseService.GetCourse(id);
        }

        internal object? GetPagedCourses(DataTablesAjaxRequestModel model)
        {

            var data = _courseService?.GetCourses(
                model.PageIndex,
                model.PageSize,
                model.SearchText,
                model.GetSortText(new string[] { "Title", "Fees", "ClassStartDate" }));

            return new
            {
                recordsTotal = data?.total,
                recordsFiltered = data?.totalDisplay,
                data = (from record in data?.records
                        select new string[]
                        {
                                record.Name,
                                record.Fees.ToString(),
                                record.ClassStartDate.ToString(),
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        }
    }
}
