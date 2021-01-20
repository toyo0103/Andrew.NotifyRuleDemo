using Andrew.NotifyRuleDemo.Contracts;

namespace Andrew.NotifyRuleDemo.NotificationProvider
{
    public class NotificationServiceProxy : INotificationService
    {
        public bool SendNotification(INotification notification)
        {
            if (notification.Type == NotificationType.Slack)
            {
                return new SlackProvider().SendNotification(notification);
            }

            return false;
        }
    }
}