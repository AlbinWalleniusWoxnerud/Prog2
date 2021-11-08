using System.Net.Http;
using System.Threading.Tasks;
using Library.API;

namespace SpecialEncounters;

public class Machine
{
    public static async Task MachineActivationWithoutPassword()
    {
        Library.API.APIHelper.InitializeClient();
        TextRender.Render("");
        TextRender.Render("TV Information.");
        TextRender.Render("");
        TextRender.Render("Enter a search term: ", sameLine: true, color: Color.White);
        string searchTerm = Console.ReadLine();
        TextRender.Render("");
        try
        {
            var movie = await GETFromAPI(searchTerm);
            TextRender.Render($"Name: {movie.Name}\nLanguage: {movie.Language}\nPremiered: {movie.Premiered}\nAverage Runtime: {movie.AverageRuntime} min\nStatus: {movie.Status}", color: Color.White);
        }
        catch (System.Exception)
        {
            TextRender.Render("An issue ocurred fetching your data!", color: Color.Red);
            TextRender.Render("");
        }
    }

    private static async Task<APIMovieResponseModel> GETFromAPI(string searchTerm = "Rocky")
    {
        TextRender.Render("Fetching data...");
        TextRender.Render("");
        using (HttpResponseMessage responseMessage = APIHelper.ApiClient.GetAsync($"shows?q={searchTerm}").Result)
        {
            if (responseMessage.IsSuccessStatusCode)
            {
                APIMovieResponseModel movie = responseMessage.Content.ReadAsAsync<APIMovieResponseModel>().Result;
                return movie;
            }
            else
            {
                throw new Exception(responseMessage.ReasonPhrase);
            }
        }
    }
}