namespace Library.API;
public class APIMovieResponseModel
{
    // public int Num { get; set; }
    // public string Img { get; set; }
    public string Name { get; set; }
    public string Language { get; set; }
    public string[] Genres { get; set; }
    public int AverageRuntime { get; set; }
    public string Status { get; set; }
    public string Premiered { get; set; }
}