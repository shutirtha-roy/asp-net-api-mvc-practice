using AutoMapper;
using FirstDemo.Infrastructure.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseEO = FirstDemo.Infrastructure.Entities.Course;
using StudentEO = FirstDemo.Infrastructure.Entities.Student;
using TopicEO = FirstDemo.Infrastructure.Entities.Topic;

namespace FirstDemo.Infrastructure.Profiles
{
    public class TrainingProfile : Profile
    {
		public TrainingProfile()
		{
			//From Title it will copy to Name and ReverMap means the opposite can happen for Course to CourseEO or CourseEO to Course
			CreateMap<CourseEO, Course>()
				.ForMember(dest => dest.Name, src => src.MapFrom(x => x.Title))
				.ReverseMap();

			CreateMap<StudentEO, Student>()
				.ReverseMap();

			CreateMap<TopicEO, Topic>()
				.ReverseMap();
		}
	}
}
