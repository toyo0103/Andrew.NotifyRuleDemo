using System.Collections.Generic;
using Andrew.NotifyRuleDemo.Contracts;

namespace Andrew.NotifyRuleDemo.NotificationProvider
{
    internal class SlackNotification : INotification
    {
        public NotificationType Type => NotificationType.Slack;

        public string Channel { get; set; }

        public string Content { get; set; }

        public List<string> Receivers { get; set; }
    }
}