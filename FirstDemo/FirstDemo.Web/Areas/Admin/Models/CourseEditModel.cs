using Autofac;
using AutoMapper;
using FirstDemo.Infrastructure.BusinessObjects;
using FirstDemo.Infrastructure.Services;
using System.ComponentModel.DataAnnotations;

namespace FirstDemo.Web.Areas.Admin.Models
{
    public class CourseEditModel : BaseModel
    {
        private ICourseService _courseService;

        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        public double Fees { get; set; }
        public DateTime ClassStartDate { get; set; }
        private IMapper _mapper;

        public CourseEditModel() : base()
        {

        }

        public CourseEditModel(ICourseService coursService, IMapper mapper)
        {
            _courseService = coursService;
            _mapper = mapper;
        }

        internal void LoadData(Guid id)
        {
            var course = _courseService.GetCourses(id);

            if (course != null)
            {
                //Id = course.Id;
                //Title = course.Name;
                //Fees = course.Fees;
                //ClassStartDate = course.ClassStartDate;
                _mapper.Map(course, this);
            }
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            base.ResolveDependency(scope);
            _courseService = _scope.Resolve<ICourseService>();
            _mapper = _scope.Resolve<IMapper>();
        }

        internal void EditCourse()
        {
            Course course = _mapper.Map<Course>(this);
            //Course course = new Course();
            //course.Id = Id;
            //course.Name = Title;
            //course.Fees = Fees;
            //course.ClassStartDate = ClassStartDate;
            _courseService.EditCourse(course);
        }
    }
}
