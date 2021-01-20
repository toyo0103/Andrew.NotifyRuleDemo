using System.Collections.Generic;

namespace Andrew.NotifyRuleDemo.Contracts
{
    public interface INotificationService
    {
        bool SendNotification(INotification notification);
    }
}
