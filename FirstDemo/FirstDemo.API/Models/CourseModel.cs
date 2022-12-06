using Autofac;
using AutoMapper;
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


    }
}
