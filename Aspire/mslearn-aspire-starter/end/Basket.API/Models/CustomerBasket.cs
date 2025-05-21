using MongoDB.Bson;

namespace eShop.Basket.API.Models;

public class CustomerBasket
{
  /// <summary>
  /// MongoDB document identifier
  /// </summary>
  public string _id { get; set; } = "";

  public required string BuyerId { get; set; }

  public List<BasketItem> Items { get; set; } = [];
}
