namespace TourManager.Clients.Abstraction.Settings
{
    public interface IServiceSettingsProvider
    {
        string ComposeActivityServiceUrl();

        string ComposePropertyServiceUrl();
    }
}
