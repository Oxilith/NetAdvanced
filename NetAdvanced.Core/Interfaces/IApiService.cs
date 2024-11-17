namespace NetAdvanced.Core.Interfaces;

public interface IApiService<T> where T : IApiClient, new()
{
    public IApiClientConfiguration<T> Configuration { get; }
    T CreateClient(IApiClientConfiguration<T> apiConfiguration);
}