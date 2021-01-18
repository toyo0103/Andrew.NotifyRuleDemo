using Andrew.NotifyRuleDemo.Contracts;

namespace Andrew.NotifyRuleDemo.NotificationProvider
{
    internal class SlackNotification : INotification
    {
        public NotificationType Type => NotificationType.Slack;

        public string Template { get; set; }

        public string Channel { get; set; }
    }
}