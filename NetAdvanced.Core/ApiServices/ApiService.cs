using Microsoft.Extensions.Logging;
using NetAdvanced.Core.Interfaces;

namespace NetAdvanced.Core.ApiServices;

public class ApiService<T>(IApiClientConfiguration<T> configuration, ILogger<IApiService<T>> logger)
    : IApiService<T> where T : IApiClient, new()

{
    public IApiClientConfiguration<T> Configuration { get; } = configuration;
    protected ILogger<IApiService<T>> Logger { get; } = logger;

    public T CreateClient(IApiClientConfiguration<T> apiConfiguration)
    {
        return apiConfiguration.CreateClient();
    }

    protected delegate TSection QueryDelegate<out TSection>(IApiClientConfiguration<T> apiClientConfiguration);
}