using System;
using System.Collections.Generic;
using System.Threading;
using Andrew.NotifyRuleDemo.Contracts;

namespace Andrew.NotifyRuleDemo
{
    public class NotifyEngine
    {
        private List<JobNotifyRuleBase> _rules;
        private readonly INotificationService _notificationService;

        public NotifyEngine(
            List<JobNotifyRuleBase> rules,
            INotificationService notificationService) 
        {
            this._rules = rules;
            this._notificationService = notificationService;
        } 

        public void Execute(CancellationToken token)
        {
            while(token.IsCancellationRequested == false)
            {
                Thread.Sleep(1000); // sleep 60 sec

                foreach(var r in this._rules)
                {
                    if (r is JobNotifyRuleBase)
                    {
                        var jRule = (JobNotifyRuleBase)r;
                        foreach (var x in jRule.MatchResult(DateTime.Now))
                        {
                            //通知只收名單跟內容
                            _notificationService.SendNotification(x);
                        }
                    }
                    //else if (r is GroupNotifyRuleBase)
                    //{
                    //    foreach (var x in r.MatchResult(DateTime.Now))
                    //    {
                    //        r.Notifications.ForEach(n => _notificationService.SendNotification(n, x.msginfo));
                    //    }
                    //}
                    else 
                    {
                        Console.WriteLine("RuleBase not implement");   
                    }
                }
            }
        }
    }
}
