using System;
using System.Collections.Generic;
using Andrew.NotifyRuleDemo.Contracts;

namespace Andrew.NotifyRuleDemo.NotificationProvider
{
    public class NotificationServiceProxy : INotificationService
    {
        public bool SendNotification(INotification notification, IDictionary<string, string> msgInfo)
        {
            if (notification.Type == NotificationType.Slack) 
            {
                return new SlackProvider().SendNotification(notification, msgInfo);
            }

            if (notification.Type == NotificationType.Email)
            {
                return new EmailProvider().SendNotification(notification, msgInfo);
            }

            return false;
        }
    }
}