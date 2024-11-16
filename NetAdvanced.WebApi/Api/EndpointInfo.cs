namespace NetAdvanced.WebApi.Api;

public class EndpointInfo(string path, string operationName, string summary, string description, string tagName)
{
    public string Path { get; } = path;
    public string OperationName { get; } = operationName;
    public string Summary { get; } = summary;
    public string Description { get; } = description;
    public string TagName { get; } = tagName;
}