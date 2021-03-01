namespace Travely.SchedulerManager.Common
{
    public class NotifierOptions
    {
        public const string Section = nameof(NotifierOptions);
        public string RedisConnectionString { get; set; }
        public EmailOptions EmailOptions { get; set; }
    }
}
