

using System.Text.Json.Serialization;

namespace MovieBookingsApp
{
    public class Movie
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int LengthMin { get; set; }
        public string ImageURI { get; set; }
        public string WideImageURI { get; set; }
        public string Description { get; set; }
    }

    [JsonSerializable(typeof(List<Movie>))]
    internal sealed partial class MovieContext : JsonSerializerContext
    {

    }
}
