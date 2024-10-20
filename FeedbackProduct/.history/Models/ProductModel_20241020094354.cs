using MongoDB.Bson.Serialization.Attributes;
namespace FeedbackProduct.Models
{
  public class ProductModel
  {
    [BsonId]
    public string id { get; set; }

    using MongoDB.Bson.Serialization.Attributes;
  }
}