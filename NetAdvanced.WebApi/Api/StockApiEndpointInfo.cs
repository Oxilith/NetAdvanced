using NetAdvanced.Core.Interfaces;
using NetAdvanced.WebApi.Helpers;

namespace NetAdvanced.WebApi.Api;

internal static class StockApiEndpointInfo
{
    internal static EndpointInfo GetEndpointInfo =>
        new("/get",
            "Get something",
            "Summary",
            "Description",
            "Stock");

    internal static EndpointInfo ActionEndpointInfo =>
        new("/void",
            "Run void action", 
            "Summary",
            "Description",
            "Stock");
}