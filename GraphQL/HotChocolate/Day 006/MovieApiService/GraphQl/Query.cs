using HotChocolate.Types.Relay;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Entities;
using System.Data;
using System.Linq;

namespace MovieApiService.GraphQl;

public class Query
{
    public Query(
        IOptions<DatabaseSettings> bookStoreDatabaseSettings)
    {
        DB.InitAsync(bookStoreDatabaseSettings.Value.ConnectionString);
        DB.Database(bookStoreDatabaseSettings.Value.DatabaseName);
    }
    

    public async IAsyncEnumerable<Movie> GetMovies(string searchTerm)
    {
        var cursor = await DB.Find<Movie>().Match(x => x.Regex(c => c.Title, new BsonRegularExpression(searchTerm, "i")))
                                   .ExecuteCursorAsync();

        while (await cursor.MoveNextAsync())
        {
            foreach (var movie in cursor.Current)
            {
                yield return movie;
            }
        }
    }

    public async Task<List<Movie>> GetAllMovies()
    {
        return await DB.Find<Movie>().ExecuteAsync();
    }
}

[Collection(Movie.CollectionName)]
public class Movie : Entity
{
    internal const string CollectionName = "movies";

    [Field("title")]
    public string Title { get; set; } = null!;

    [Field("language")]
    public string? Language { get; set; }

    [Field("releaseDate")]
    public DateTime? ReleaseDate { get; set; }

    [Field("director")]
    public string? Director { get; set; }
}

