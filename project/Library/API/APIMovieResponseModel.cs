namespace Library.API;
/// <summary>
/// Custom ResponseModel with properties based on the response of the default api
/// </summary>
public class APIMovieResponseModel
{
    public string Name { get; set; }
    public string Language { get; set; }
    public int AverageRuntime { get; set; }
    public string Status { get; set; }
    public string Premiered { get; set; }

}