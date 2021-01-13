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
            List<INotifyRule> rules = new List<INotifyRule>
            {
                new CheckTaskStatusRule(new CheckTaskStatusRuleSetting { TargetStatue = "Error", Notifications = new List<INotification>
                {
                    new SlackProvider{ Template = "有 {{Status}} Task 尚未處理，請協助確認 <br> {{Detail}}"}
                }})
            };

            var notifyEngine = new NotifyEngine(rules);

            notifyEngine.Execute(default(CancellationToken));
            
        }
    }
}
