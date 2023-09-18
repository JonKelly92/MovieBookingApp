

using System.Text.Json.Serialization;

namespace MovieBookingsApp
{
    public class Movie
    {
        public string Name { get; set; }
        public int LengthMin { get; set; }
        public string ImageURI { get; set; }
    }

    [JsonSerializable(typeof(List<Movie>))]
    internal sealed partial class MovieContext : JsonSerializerContext
    {

    }
}
