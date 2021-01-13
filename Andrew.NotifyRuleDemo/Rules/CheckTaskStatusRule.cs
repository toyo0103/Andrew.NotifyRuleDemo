using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Andrew.NotifyRuleDemo.Contracts;
using Andrew.NotifyRuleDemo.Models;
using Andrew.NotifyRuleDemo.Rules.Settings;

namespace Andrew.NotifyRuleDemo.Rules
{
    public class CheckTaskStatusRule : INotifyRule
    {
        private readonly CheckTaskStatusRuleSetting _setting;

        private string _lastCheckHour = string.Empty;

        public List<INotification> Notifications { get; }

        public CheckTaskStatusRule(CheckTaskStatusRuleSetting setting) 
        {
            this._setting = setting;
            this.Notifications = setting.Notifications;
        }

        public (bool match, IDictionary<string, string> msginfo) IsMatch(DateTime time_seed)
        {
            Console.WriteLine($"check task status: {_setting.TargetStatue}");
            
            //if (_lastCheckHour == DateTime.UtcNow.ToString("HH")) return (false, null);

            //紀錄最後確認是的時間, 一小時只要確認一次
            _lastCheckHour = DateTime.UtcNow.ToString("HH");

            var tasks = this.CheckTaskStatue(_setting.TargetStatue);

            if (tasks.Count > 0)
            {
                IEnumerable<(string jobName, int count)> groupByJobName = tasks.GroupBy(x => x.JobName).Select(g => (g.Key, g.Count()));

                StringBuilder detail = new StringBuilder();

                foreach (var job in groupByJobName) detail.AppendLine($"{job.jobName}- {job.count} 筆");

                return (true, new Dictionary<string, string> 
                { 
                    { "Status", _setting .TargetStatue}, 
                    { "Detail", detail.ToString() } 
                });
            }

            return (false, null);
        }

        private List<TaskModel> CheckTaskStatue(string status) 
        {
            // 撈 DB 確認有沒有這個 Status 的 Task
            return new List<TaskModel> 
            { 
                new TaskModel { JobName = "SendTemplateMail" },
                new TaskModel { JobName = "SendTemplateMail" },
                new TaskModel { JobName = "TransOrderToERP" },
            };
        }
    }
}
