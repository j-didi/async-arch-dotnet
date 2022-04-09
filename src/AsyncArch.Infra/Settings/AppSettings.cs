namespace AsyncArch.Infra.Settings;

public class AppSettings
{
    public string ConnectionString { get; set; }
    public CacheSettings CacheSettings { get; set; }
    public BrokerSettings BrokerSettings { get; set; }
}