namespace NetAdvanced.Core.Interfaces;

public interface IApiClient
{
    public TimeSpan ApiCallTimeout => TimeSpan.FromSeconds(30);
    public TimeSpan LongRunningApiCallTimeout => TimeSpan.FromSeconds(90);
    public TimeSpan RetryDelay => TimeSpan.FromSeconds(5);
    public int RetryCount => 3;
    public int PageSize => 100 * 100;
}