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
            List<NotifyRuleBase> rules = new List<NotifyRuleBase>
            {
                new CheckTaskStatusRule(new CheckTaskStatusRuleSetting { TargetStatue = "Error", Notifications = new List<INotification>
                {
                    new SlackNotification
                    { 
                        Template = "有 {{Status}} Task 尚未處理，請協助確認 <br> {{Detail}}", 
                        Channel = "arch-team-devops"
                    },
                    new EmailNotification
                    { 
                        Subject = "未處理 Error Task", 
                        Template = "有 {{Status}} Task 尚未處理，請協助確認 <br> {{Detail}}", 
                        Receiver = new List<string>{ "steventasi@91app.com", "borischin@91app.com" } //只能指定明確的收件人 
                    }
                }})
            };

            INotificationService ns = new NotificationServiceProxy();

            var notifyEngine = new NotifyEngine(rules, ns);

            notifyEngine.Execute(default(CancellationToken));
            
        }
    }
}
