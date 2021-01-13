using System;
using System.Collections.Generic;
using System.Threading;
using Andrew.NotifyRuleDemo.Contracts;

namespace Andrew.NotifyRuleDemo
{
    public class NotifyEngine
    {
        private List<INotifyRule> _rules;

        public NotifyEngine(List<INotifyRule> rules) => this._rules = rules;

        public void Execute(CancellationToken token)
        {
            while(token.IsCancellationRequested == false)
            {
                Thread.Sleep(1000); // sleep 60 sec

                foreach(var r in this._rules)
                {
                    var x = r.IsMatch(DateTime.Now);
                    if (x.match == false) continue;

                    foreach (var notification in r.Notifications)
                    {
                        string body = this.ApplyMessageTemplate(notification.Template, x.msginfo);
                        this.SenNotification(notification, body);
                    }
                }
            }
        }

        private string ApplyMessageTemplate(string template, IDictionary<string, string> templateParameters)
        {
            foreach (var item in templateParameters)
            {
                template = template.Replace($"{{{{{item.Key}}}}}", item.Value);
            }

            return template;
        }

        private void SenNotification(INotification notification, string content)
        {
            Console.WriteLine($"Send {notification.Type} -- {content}");
        }
    }

}
