using System.Collections.Generic;
using Andrew.NotifyRuleDemo.Contracts;

namespace Andrew.NotifyRuleDemo.NotificationProvider
{
    internal class EmailNotification : INotification
    {
        public NotificationType Type => NotificationType.Email;

        public string Template { get; set; }

        public string Subject { get; set; }

        public List<string> Receiver { get; set; }
    }
}