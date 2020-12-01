using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using BaseApp.Common;

namespace BaseApp.Service
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    public partial interface IAppService
    {
    }

    public partial class AppService
    {
        void SendEmail(string sendTo, string subject, string body, bool isBodyHtml = false)
        {
            log.LogInformation($"Send email to:{sendTo} subject:{subject}");

            var enabled = config.GetValue<bool>("Email:Enabled");
            if (!enabled)
                return;

            var mail = new MailMessage();
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = isBodyHtml;
            mail.From = new MailAddress(config.GetValue<string>("Email:Smtp:From"));

            string overrideAddress = config.GetValue<string>("Email:Override:To");
            var addresses = (string.IsNullOrEmpty(overrideAddress) ? sendTo : overrideAddress);

            var addressList = addresses.Split(',').ToList();
            foreach (var address in addressList)
            {
                mail.To.Add(address.Trim());
            }

            var smtpClient = new SmtpClient
            {
                Host = config.GetValue<string>("Email:Smtp:Host")
            };

            smtpClient.Send(mail);
        }

        void SendSilentEmail(string sendTo, string subject, string body, bool isBodyHtml = false)
        {
            try
            {
                SendEmail(sendTo, subject, body, isBodyHtml);
            }
            catch (Exception ex)
            {
                log.LogError("Failed sending email '{0}' {1} {2}", subject, body, ex);
            }
        }
    }
}