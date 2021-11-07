using System.Net.Http;
using System.Net.Http.Headers;

namespace Library.API;
public static class APIHelper
{
    public static HttpClient ApiClient { get; set; }
    public static void InitializeClient()
    {
        ApiClient = new();
        ApiClient.BaseAddress = new Uri("http://api.tvmaze.com/search/");
        ApiClient.DefaultRequestHeaders.Accept.Clear();
        ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
}