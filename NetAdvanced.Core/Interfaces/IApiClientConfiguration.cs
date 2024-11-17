namespace NetAdvanced.Core.Interfaces;

public interface IApiClientConfiguration<out T> where T : IApiClient, new()
{
    T CreateClient();
}