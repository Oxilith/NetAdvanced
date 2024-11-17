namespace NetAdvanced.Core.Interfaces;

public interface IStockApiClient : IApiClient
{
    public Task Void(string parameter);
    public Task<TResult> Get<TResult>(string parameter);
}