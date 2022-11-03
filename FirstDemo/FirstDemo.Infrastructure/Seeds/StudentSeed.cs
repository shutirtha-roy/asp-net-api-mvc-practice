using FirstDemo.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Infrastructure.Seeds
{
    internal class StudentSeed
    {
        internal Student[] Students
        {
            get
            {
                return new Student[]
                {
                    new Student{ Id = new Guid("13530E69-AEB3-4A44-B6A0-714546093FE7"), Name = "Samin", Address = "Dhaka", Cgpa = 3.0 },
                    new Student{ Id = new Guid("2FA3A5D2-C1F9-48A8-9CE4-CC05C3B739AE"), Name = "Apurba", Address = "Dhaka", Cgpa = 2.0 },
                    new Student{ Id = new Guid("9FC6ABEA-0D6D-4168-B147-549F2A64A174"), Name = "Asif", Address = "Dhaka", Cgpa = 4.0 }
                };
            }
        }
    }
}
