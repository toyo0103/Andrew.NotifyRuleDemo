using System;
using System.Collections.Generic;

namespace Andrew.NotifyRuleDemo.Contracts
{
    public abstract class NotifyRuleBase
    {
        public abstract (bool match, IDictionary<string, string> msginfo) IsMatch(DateTime time_seed);

        public List<INotification> Notifications { get; private set; }

        public NotifyRuleBase(List<INotification> notifications) 
        {
            this.Notifications = notifications;
        }
    }
}
