using NetAdvanced.Core.Interfaces;

namespace NetAdvanced.Core.ApiClients;

public class StockApiClientConfiguration : IApiClientConfiguration<StockApiClient>
{
    public StockApiClient CreateClient()
    {
        return new StockApiClient();
    }
}