using FirstDemo.Infrastructure.BusinessObjects;
using FirstDemo.Infrastructure.Services;
using System.ComponentModel.DataAnnotations;

namespace FirstDemo.Web.Areas.Admin.Models
{
    public class CourseCreateModel
    {
        [Required]
        public string Title { get; set; }
        public double Fees { get; set; }
        public DateTime ClassStartDate { get; set; }
        private readonly ICourseService _courseService;

        public CourseCreateModel(ICourseService courseService)
        {
            _courseService = courseService;
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
