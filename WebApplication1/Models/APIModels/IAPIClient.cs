namespace WebApplication1.Models.APIModels
{
    public interface IApiClient
    {
        HttpClient Client { get; }
        string BaseUrl { get; }
    }
}
