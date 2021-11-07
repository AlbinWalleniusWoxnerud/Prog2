using System.Net.Http;
using System.Threading.Tasks;
using Library.API;

namespace SpecialEncounters;

public class Machine
{
    public static async void MachineActivationWithoutPassword()
    {
        Library.API.APIHelper.InitializeClient();
        // TextRender.Render("");
        await GETFromAPI();
    }

    private static async Task<APIMovieResponseModel> GETFromAPI(string searchTerm = "Rocky")
    {
        string url = $"https://xkcd.com/info.0.json";
        using (HttpResponseMessage responseMessage = await APIHelper.ApiClient.GetAsync($"shows?q={searchTerm}"))
        {
            if (responseMessage.IsSuccessStatusCode)
            {
                APIMovieResponseModel movie = await responseMessage.Content.ReadAsAsync<APIMovieResponseModel>();
                return movie;
            }
            else
            {
                throw new Exception(responseMessage.ReasonPhrase);
            }
        }
    }
}