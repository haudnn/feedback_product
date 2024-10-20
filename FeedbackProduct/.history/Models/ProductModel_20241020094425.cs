using MongoDB.Bson.Serialization.Attributes;
namespace FeedbackProduct.Models
{
  public class ProductModel
  {
    [BsonId]
    public string id { get; set; }

    public string name { get; set; }

    public string image { get; set; }

    public long created { get; set; }
  }
}