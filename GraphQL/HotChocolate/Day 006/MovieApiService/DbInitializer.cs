using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Entities;
using System.Text.Json;

namespace MovieApiService
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string MovieCollectionName { get; set; } = null!;
    }

    public class DatabaseInitializer
    {
        private readonly DatabaseSettings _databaseSettings;
        private readonly IMongoDatabase _database;
        public DatabaseInitializer(IOptions<DatabaseSettings> databaseSettings)
        {

            _databaseSettings = databaseSettings.Value;

            DB.InitAsync(_databaseSettings.DatabaseName, MongoClientSettings.FromConnectionString(_databaseSettings.ConnectionString));

            //var client = new MongoClient(_databaseSettings.ConnectionString);
            _database = DB.Database(_databaseSettings.DatabaseName);
        }

        public async Task Initialize()
        {
            if (!await CheckIfCollectionExists(_databaseSettings.MovieCollectionName))
            {
                var collection = _database.GetCollection<BsonDocument>(_databaseSettings.MovieCollectionName);

                var documents = new[]
                {
                new BsonDocument{
                    {"title","Yodha"},
                    {"language","Malayalam" },
                    {"releaseDate", new DateOnly(1992, 1, 2).ToDateTime(TimeOnly.MinValue) }
                }
            };

                await collection.InsertManyAsync(documents).ConfigureAwait(false);
            }
        }


        private async Task<bool> CheckIfCollectionExists(string collectionName)
        {
            var filter = new BsonDocument("name", collectionName);
            var collections = await _database.ListCollectionNamesAsync(new ListCollectionNamesOptions
            {
                Filter = filter
            });

            return await collections.AnyAsync();
        }
    }
}
