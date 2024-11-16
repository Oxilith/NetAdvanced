using Microsoft.Extensions.Logging;
using NetAdvanced.Core.Interfaces;

namespace NetAdvanced.Core.ApiServices;

public abstract class ApiService<T>(IApiClientConfiguration configuration, ILogger<IApiService> logger): IApiService where T : new()

{
    protected IApiClientConfiguration Configuration { get; } = configuration;
    protected ILogger<IApiService> Logger { get; } = logger;

    public T CreateClient(IApiClientConfiguration apiConfiguration)
    {
        return apiConfiguration.CreateClient<T>();
    }

    protected delegate TSection QueryDelegate<out TSection>(IApiClientConfiguration apiClientConfiguration);

    public Task<dynamic?> Get(string? arg3)
    {
        throw new NotImplementedException();
    }

    public Task<object> Void(string? arg3)
    {
        throw new NotImplementedException();
    }
}

public interface IApiClientConfiguration
{
    T CreateClient<T>() where T : new();
    public Task<object> Void(string? arg3);
    public Task<dynamic?> Get(string? arg3);
}