﻿
using System;
using System.Collections.Generic;
using Andrew.NotifyRuleDemo.Contracts;

namespace Andrew.NotifyRuleDemo.NotificationProvider
{
    public class SlackProvider : INotificationService
    {
        public bool SendNotification(INotification notification, IDictionary<string, string> msgInfo)
        {
            var slackNotification = (SlackNotification)notification;
            Console.WriteLine("SendSlack....");
            Console.WriteLine($"Channel : {slackNotification.Channel}");
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