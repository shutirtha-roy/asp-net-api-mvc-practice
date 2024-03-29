﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Infrastructure.Entities
{
    public class Student : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Cgpa { get; set; }
        public List<CourseRegistration> StudentCourses { get; set; }
    }
}
