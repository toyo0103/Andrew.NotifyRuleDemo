using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Andrew.NotifyRuleDemo.Contracts;
using Andrew.NotifyRuleDemo.Models;
using Andrew.NotifyRuleDemo.NotificationProvider;
using Andrew.NotifyRuleDemo.Rules.Settings;

namespace Andrew.NotifyRuleDemo.Rules
{
    public class CheckTaskStatusRule : JobNotifyRuleBase
    {
        private readonly CheckTaskStatusRuleSetting _setting;

        private string _lastCheckHour = string.Empty;

        public CheckTaskStatusRule(CheckTaskStatusRuleSetting setting)
        {
            this._setting = setting;
        }

        public override IEnumerable<INotification> MatchResult(DateTime time_seed)
        {
            //if (_lastCheckHour == DateTime.UtcNow.ToString("HH")) return (false, null);

            //紀錄最後確認是的時間, 一小時只要確認一次
            _lastCheckHour = DateTime.UtcNow.ToString("HH");

            var tasks = this.CheckTaskStatue(_setting.TargetStatue);

            if (tasks.Count > 0)
            {
                IEnumerable<(string jobName, string owner, int count)> groupByJobNameOwner = tasks.GroupBy(x => new { x.JobName, x.Owner }).Select(g => (g.Key.JobName, g.Key.Owner ,g.Count()));

                //同部門的通知一次
                foreach (var owner in groupByJobNameOwner.Select(x => x.owner))
                {
                    StringBuilder detail = new StringBuilder();
                    foreach (var job in groupByJobNameOwner.Where(x => x.owner == owner))
                    {
                        detail.AppendLine($"{job.jobName}- {job.count} 筆");
                    }
                    yield return new SlackNotification { Receivers = new List<string> { owner }, Content = detail.ToString(), Channel = "rd-sg-maintain" };
                }
                yield break;
            }
        }

        private List<TaskModel> CheckTaskStatue(string status) 
        {
            // 撈 DB 確認有沒有這個 Status 的 Task
            return new List<TaskModel> 
            { 
                new TaskModel { JobName = "SendTemplateMail" , Owner = "UPD1"},
                new TaskModel { JobName = "SendTemplateMail" , Owner = "UPD1"},
                new TaskModel { JobName = "TransOrderToERP" , Owner = "UPD2"},
            };
        }
    }
}
