﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Infrastructure.BusinessObjects
{
	public class Student
	{
		public Guid Id { get; set; }
		public string? Name { get; set; }
		public double Cgpa { get; set; }
		public string? Address { get; set; }
	}
}
