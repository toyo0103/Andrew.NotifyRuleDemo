using System.Collections.Generic;
using Andrew.NotifyRuleDemo.Contracts;

namespace Andrew.NotifyRuleDemo.Rules.Settings
{
    public class CheckTaskStatusRuleSetting
    {
        public string TargetStatue { get; set; }

        public List<INotification> Notifications { get; set; }
    }
}