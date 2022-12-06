using AutoMapper;
using FirstDemo.Infrastructure.DbContexts;
using FirstDemo.Infrastructure.Exceptions;
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
        private readonly IMapper _mapper;

        public CourseService(IMapper mapper, IApplicationUnitOfWork applicationUnitOfWork)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
            _mapper = mapper;
        }

        public void CreateCourse(CourseBO course)
        {
            var count = _applicationUnitOfWork.Courses.GetCount(x => x.Title == course.Name);

            if (count > 0)
                throw new DuplicateException("Course title already exists");

            course.SetProperClassStartDate();

            CourseEO courseEntity = _mapper.Map<CourseEO>(course);
            //CourseEO courseEntity = new CourseEO();
            //courseEntity.Title = course.Name;
            //courseEntity.Fees = course.Fees;
            //courseEntity.ClassStartDate = course.ClassStartDate;

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
                courseEO = _mapper.Map(course, courseEO);
                //courseEO.Title = course.Name;
                //courseEO.Fees = course.Fees;
                //courseEO.ClassStartDate = course.ClassStartDate;

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
                //courses.Add(new CourseBO
                //{
                //    Id = courseEO.Id,
                //    Name = courseEO.Title,
                //    Fees = courseEO.Fees,
                //    ClassStartDate = courseEO.ClassStartDate
                //});

                courses.Add(_mapper.Map<CourseBO>(courseEO));
            }

            return (results.total, results.totalDisplay, courses);
        }

        public CourseBO GetCourses(Guid id)
        {
            var courseEO = _applicationUnitOfWork.Courses.GetById(id);

            CourseBO courseBO = _mapper.Map<CourseBO>(courseEO);

            //var courseBO = new CourseBO();
            //courseBO.Name = courseEO.Title;
            //courseBO.Fees = courseEO.Fees;
            //courseBO.ClassStartDate = courseEO.ClassStartDate;

            return courseBO;
        }

        public CourseBO GetCourse(string name)
        {
            var courseEO = _applicationUnitOfWork.Courses.Get(x => x.Title.Equals(name), "")
                .FirstOrDefault();

            CourseBO courseBO = _mapper.Map<CourseBO>(courseEO);

            return courseBO;
        }

        public CourseBO GetCourse(Guid id)
        {
            var courseEO = _applicationUnitOfWork.Courses.GetById(id);

            CourseBO courseBO = _mapper.Map<CourseBO>(courseEO);

            return courseBO;
        }

        public IList<CourseBO> GetCourses()
        {
            var coursesEO = _applicationUnitOfWork.Courses.GetAll();

            IList<CourseBO> courses = new List<CourseBO>();

            foreach (CourseEO courseEO in coursesEO)
            {
                courses.Add(_mapper.Map<CourseBO>(courseEO));
            }

            return courses;
        }
    }
}
