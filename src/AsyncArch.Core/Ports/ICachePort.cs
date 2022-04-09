namespace AsyncArch.Core.Ports;

public interface ICachePort
{
    Task<string> Read(Guid id);
    Task Write(Guid id, string json);
    Task Remove(Guid id);
}