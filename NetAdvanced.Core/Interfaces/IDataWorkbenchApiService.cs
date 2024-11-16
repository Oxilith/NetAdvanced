namespace NetAdvanced.Core.Interfaces;

public interface IApiService
{
    public TimeSpan ApiCallTimeout => TimeSpan.FromSeconds(30);
    public TimeSpan LongRunningApiCallTimeout => TimeSpan.FromSeconds(90);
    public TimeSpan RetryDelay => TimeSpan.FromSeconds(5);
    Task<dynamic?> Get(string? arg3);
    Task<object> Void(string? arg3);
}