using System;
using System.Collections.Generic;
using System.Threading;
using Andrew.NotifyRuleDemo.Contracts;

namespace Andrew.NotifyRuleDemo
{
    public class NotifyEngine
    {
        private List<NotifyRuleBase> _rules;
        private readonly INotificationService _notificationService;

        public NotifyEngine(
            List<NotifyRuleBase> rules,
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
                    var x = r.IsMatch(DateTime.Now);
                    if (x.match == false) continue;

                    r.Notifications.ForEach(n => _notificationService.SendNotification(n, x.msginfo));
                }
            }
        }
    }
}
