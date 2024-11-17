using NetAdvanced.Core.ApiServices;
using NetAdvanced.Core.Interfaces;

namespace NetAdvanced.Core.ApiClients;

public class StockApiClient : IStockApiClient
{
    public Task Void(string parameter)
    {
        throw new NotImplementedException();
    }

    public Task<TResult> Get<TResult>(string parameter)
    {
        throw new NotImplementedException();
    }
}