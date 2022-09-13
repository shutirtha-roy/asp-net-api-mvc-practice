using FirstDemo.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseBO = FirstDemo.Infrastructure.BusinessObjects.Course;
using CourseEO = FirstDemo.Infrastructure.Entities.Course;

namespace FirstDemo.Infrastructure.Services
{
    public class CourseService : ICourseService
    {
        CourseRepository<CourseEO> courseRepository;
        public void CreateCourse(CourseBO course)
        {
            course.SetProperClassStartDate();

            CourseEO courseEntity = new CourseEO();
            courseEntity.Title = course.Name;
            courseEntity.Fees = course.Fees;
            courseEntity.ClassStartDate = course.ClassStartDate;

            courseRepository.Add(courseEntity);
        }
    }
}
