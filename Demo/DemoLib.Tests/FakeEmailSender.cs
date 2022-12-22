using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLib.Tests
{
    public class FakeEmailSender : IEmailSender
    {
        public void Send(string email)
        {
        }
    }
}
