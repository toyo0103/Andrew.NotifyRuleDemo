using System;
using System.Collections.Generic;
using System.Threading;
using Andrew.NotifyRuleDemo.Contracts;
using Andrew.NotifyRuleDemo.NotificationProvider;
using Andrew.NotifyRuleDemo.Rules;
using Andrew.NotifyRuleDemo.Rules.Settings;

namespace Andrew.NotifyRuleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<JobNotifyRuleBase> rules = new List<JobNotifyRuleBase>
            {
                new CheckTaskStatusRule(new CheckTaskStatusRuleSetting { TargetStatue = "Error" })
            };

            INotificationService ns = new NotificationServiceProxy();

            var notifyEngine = new NotifyEngine(rules, ns);

            notifyEngine.Execute(default(CancellationToken));
            
        }
    }
}
