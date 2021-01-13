namespace Andrew.NotifyRuleDemo.Contracts
{
    public interface INotification
    {
        public NotificationType Type { get; }
        public string Template { get; }
    }
}