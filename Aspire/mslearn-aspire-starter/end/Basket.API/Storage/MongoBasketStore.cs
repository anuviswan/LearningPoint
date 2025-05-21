using eShop.Basket.API.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace eShop.Basket.API.Storage;

public class MongoBasketStore
{
  private IMongoCollection<CustomerBasket> _basketCollection;

  /// <summary>
  /// When the MongoBasketStore is created, it will be passed an IMongoClient instance. 
  /// This is then used to create a MongoDB collection for the CustomerBasket model.
  /// The collection handles the CRUD operations for the basket items.
  /// </summary>
  /// <param name="mongoClient">Passed through Dependancy Injection</param>
  public MongoBasketStore(IMongoClient mongoClient)
  {
    // The database name needs to match the created database in the AppHost
    _basketCollection = mongoClient.GetDatabase("BasketDB").GetCollection<CustomerBasket>("basketitems");
  }

  public async Task<CustomerBasket?> GetBasketAsync(string customerId)
  {
    var filter = Builders<CustomerBasket>.Filter.Eq(r => r.BuyerId, customerId);

    return await _basketCollection.Find(filter).FirstOrDefaultAsync();
  }

  public async Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket basket)
  {
    var filter = Builders<CustomerBasket>.Filter.Eq(r => r.BuyerId, basket.BuyerId);

    var result = await _basketCollection.ReplaceOneAsync(filter, basket, new ReplaceOptions { IsUpsert = true });

    return result.IsModifiedCountAvailable == true ? basket : null;
  }
}