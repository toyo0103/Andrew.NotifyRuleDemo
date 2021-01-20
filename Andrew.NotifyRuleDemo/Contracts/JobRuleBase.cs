using System;
using System.Collections.Generic;

namespace Andrew.NotifyRuleDemo.Contracts
{
    public abstract class JobNotifyRuleBase : NotifyRuleBase
    {
        public abstract IEnumerable<INotification> MatchResult(DateTime time_seed);
    }
}
