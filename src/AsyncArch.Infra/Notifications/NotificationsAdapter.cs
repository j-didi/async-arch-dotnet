using AsyncArch.Core.Ports;

namespace AsyncArch.Infra.Notifications;

public class NotificationsAdapter : INotificationsPort
{
    public Task Notify(string hash, string message)
    {
        Console.WriteLine($"Notifying app with hash {hash}...");
        Console.WriteLine(message);
        return Task.CompletedTask;
    }
}