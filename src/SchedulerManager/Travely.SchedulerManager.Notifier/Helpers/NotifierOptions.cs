namespace Travely.SchedulerManager
{
    public class NotifierOptions
    {
        public const string Section = nameof(NotifierOptions);
        public string RedisConnectionString { get; set; }
        public EmailOptions EmailOptions { get; set; }
    }

    public class EmailOptions
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string Sender { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
