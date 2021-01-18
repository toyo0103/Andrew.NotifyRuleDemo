using System;
using System.Collections.Generic;
using Andrew.NotifyRuleDemo.Contracts;

namespace Andrew.NotifyRuleDemo.NotificationProvider
{
    public class EmailProvider : INotificationService
    {
        public bool SendNotification(INotification notification, IDictionary<string, string> msgInfo)
        {
            var emailNotification = (EmailNotification)notification;
            Console.WriteLine("send email....");
            Console.WriteLine($"subject : {emailNotification.Subject}");
            Console.WriteLine($"receiver : {string.Join(",", emailNotification.Receiver)}");
            Console.WriteLine($"content : {ApplyMessageTemplate(notification.Template, msgInfo)}");

            return true;
        }

        private string ApplyMessageTemplate(string template, IDictionary<string, string> templateParameters)
        {
            foreach (var item in templateParameters)
            {
                template = template.Replace($"{{{{{item.Key}}}}}", item.Value);
            }

            return template;
        }
    }
}