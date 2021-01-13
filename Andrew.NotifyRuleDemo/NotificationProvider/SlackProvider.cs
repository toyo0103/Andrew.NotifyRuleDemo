using System;
using System.Collections.Generic;
using System.Text;
using Andrew.NotifyRuleDemo.Contracts;

namespace Andrew.NotifyRuleDemo.NotificationProvider
{
    class SlackProvider : INotification
    {
        public NotificationType Type => NotificationType.Slack;

        public string Template { get; set; }
    }
}
