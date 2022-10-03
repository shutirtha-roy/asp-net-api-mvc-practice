using FirstDemo.Infrastructure.DbContexts;
using FirstDemo.Infrastructure.Repositories;
using FirstDemo.Infrastructure.UnitOfWorks;
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
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;

        public CourseService(IApplicationUnitOfWork applicationUnitOfWork)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
        }

        public void CreateCourse(CourseBO course)
        {
            course.SetProperClassStartDate();

            CourseEO courseEntity = new CourseEO();
            courseEntity.Title = course.Name;
            courseEntity.Fees = course.Fees;
            courseEntity.ClassStartDate = course.ClassStartDate;

            _applicationUnitOfWork.Courses.Add(courseEntity);
            _applicationUnitOfWork.Save();
        }

        public void DeleteCourse(Guid id)
        {
            _applicationUnitOfWork.Courses.Remove(id);
            _applicationUnitOfWork.Save();
        }

        public void EditCourse(CourseBO course)
        {
            var courseEO = _applicationUnitOfWork.Courses.GetById(course.Id);

            if(courseEO != null)
            {
                courseEO.Title = course.Name;
                courseEO.Fees = course.Fees;
                courseEO.ClassStartDate = course.ClassStartDate;

                _applicationUnitOfWork.Save();
            }
            else
            {
                throw new InvalidOperationException("Course was not found");
            }
        }

        public (int total, int totalDisplay, IList<CourseBO> records) GetCourses(int pageIndex, int pageSize, string searchText, string orderby)
        {
            (IList<CourseEO> data, int total, int totalDisplay) results = _applicationUnitOfWork
                .Courses.GetCourses(pageIndex, pageSize, searchText, orderby);
                    
            IList<CourseBO> courses = new List<CourseBO>();

            foreach (CourseEO courseEO in results.data)
            {
                courses.Add(new CourseBO
                {
                    Id = courseEO.Id,
                    Name = courseEO.Title,
                    Fees = courseEO.Fees,
                    ClassStartDate = courseEO.ClassStartDate
                });
            }

            return (results.total, results.totalDisplay, courses);
        }

        public CourseBO GetCourses(Guid id)
        {
            var courseEO = _applicationUnitOfWork.Courses.GetById(id);

            var courseBO = new CourseBO();
            courseBO.Name = courseEO.Title;
            courseBO.Fees = courseEO.Fees;
            courseBO.ClassStartDate = courseEO.ClassStartDate;

            return courseBO;
        }
    }
}
