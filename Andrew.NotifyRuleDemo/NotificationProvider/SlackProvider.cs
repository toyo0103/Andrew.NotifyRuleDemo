using System;
using Andrew.NotifyRuleDemo.Contracts;

namespace Andrew.NotifyRuleDemo.NotificationProvider
{
    public class SlackProvider : INotificationService
    {
        public bool SendNotification(INotification notification)
        {
            var sn = (SlackNotification)notification;
            var slackNotification = (SlackNotification)notification;
            Console.WriteLine("SendSlack....");
            Console.WriteLine($"Channel : {sn.Channel}");
            Console.WriteLine($"Tag : {string.Join(",", sn.Receivers)}");
            Console.WriteLine($"content : {sn.Content}");

            return true;
        }
    }
}