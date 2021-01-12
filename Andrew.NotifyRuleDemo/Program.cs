using System;
using System.Collections.Generic;
using System.Threading;

namespace Andrew.NotifyRuleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }



    public class NotifyEngine
    {
        private List<NotifyRuleBase> _rules;

        private void Execute(CancellationToken token)
        {
            while(true)
            {
                Thread.Sleep(1000); // sleep 60 sec

                foreach(var r in this._rules)
                {
                    var x = r.IsMatch(DateTime.Now);
                    if (x.match == false) continue;

                    string body = this.ApplyMessageTemplate(r.TemplateName, x.msginfo);
                    this.SendSlackNotification(r.SlackBotURL, body);
                }
            }
        }

        private string ApplyMessageTemplate(string templateName, IDictionary<string, string> templateParameters)
        {
            throw new NotImplementedException();
        }

        private string SendSlackNotification(string slackBotURL, string content)
        {
            throw new NotImplementedException();
        }
    }




    public abstract class NotifyRuleBase
    {
        public abstract (bool match, IDictionary<string, string> msginfo) IsMatch(DateTime time_seed);

        // get channel URL / BOT
        public string SlackBotURL;

        // get notify content
        public string TemplateName;

    }

}
