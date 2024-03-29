﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLib
{
    public class AccountService
    {
        private readonly IEmailSender _emailSender;

        public AccountService(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public void CreateAccount(string username, string password, string email)
        {
            //EmailSender emailSender = new EmailSender();
            _emailSender.Send(email);
        }

        public void GetCampaignReport(string campaignName)
        {
            if (!string.IsNullOrWhiteSpace(campaignName))
            {
                int count = _emailSender.GetEmailSeen(campaignName);

                if (count > 0)
                    _emailSender.Send("roy@gmail.com");
            }
        }
    }
}
