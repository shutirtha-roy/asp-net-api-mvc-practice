using FirstDemo.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Infrastructure.Repositories
{
    public class CourseRepository : Repository<Course, Guid>
    {
        public CourseRepository(DbContext context) : base(context)
        {
        }
    }
}
