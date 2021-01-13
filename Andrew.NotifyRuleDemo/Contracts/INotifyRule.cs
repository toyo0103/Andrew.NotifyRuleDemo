using System;
using System.Collections.Generic;

namespace Andrew.NotifyRuleDemo.Contracts
{
    public interface INotifyRule
    {
        (bool match, IDictionary<string, string> msginfo) IsMatch(DateTime time_seed);

        List<INotification> Notifications { get; }
    }
}
