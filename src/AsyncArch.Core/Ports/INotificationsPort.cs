namespace AsyncArch.Core.Ports;

public interface INotificationsPort
{
    Task Notify(string hash, string message);
}