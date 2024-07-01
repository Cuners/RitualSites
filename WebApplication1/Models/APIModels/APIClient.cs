namespace WebApplication1.Models.APIModels
{
    public class ApiClient : IApiClient
    {
        public HttpClient Client { get; } = new HttpClient();
        public string BaseUrl { get; } = "https://localhost:7138";
    }
}
