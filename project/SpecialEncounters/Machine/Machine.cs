using System.Net.Http;
using System.Threading.Tasks;
using Library.API;

namespace SpecialEncounters;

/// <summary>
/// Special encounter "Machine".
/// Features a working movie search engine connected to an API
/// </summary>
public class Machine
{
    /// <summary>
    /// Async method that prints information regarding the requested movie name/search term.
    /// </summary>
    public static async void MachineActivationWithoutPassword()
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

    /// <summary>
    /// Pass a string search term, returns a Task<APIMovieResponseModel> containing information about the movie
    /// </summary>
    /// <param name="searchTerm"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    private static async Task<APIMovieResponseModel> GETFromAPI(string searchTerm = "Rocky")
    {
        TextRender.Render("Fetching data...");
        TextRender.Render("");

        //Make a request to the API with the given search term, returns the response synchronously
        using (HttpResponseMessage responseMessage = APIHelper.ApiClient.GetAsync($"shows?q={searchTerm}").Result)
        {
            if (responseMessage.IsSuccessStatusCode)
            {
                //Parse the response message json directly to the <APIMovieResponseModel>, return a <APIMovieResponseModel> object with properties containing information about the movie
                APIMovieResponseModel movie = responseMessage.Content.ReadAsAsync<APIMovieResponseModel>().Result;
                return movie;
            }

            //If the request was unsuccessful throw an error with the reason
            else
            {
                throw new Exception(responseMessage.ReasonPhrase);
            }
        }
    }
}