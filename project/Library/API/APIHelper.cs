using System.Net.Http;
using System.Net.Http.Headers;
namespace Library.API;
/// <summary>
/// Static HttpClient which can be initialized by using the "InitializeClient" method
/// The client has a default URL to the default Movie api endpoint 
/// The client is initialized to request json responses
/// </summary>
public static class APIHelper
{
    public static HttpClient ApiClient { get; set; }
    public static void InitializeClient()
    {
        ApiClient = new();
        ApiClient.BaseAddress = new Uri("http://api.tvmaze.com/singlesearch/");
        ApiClient.DefaultRequestHeaders.Accept.Clear();
        ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
}