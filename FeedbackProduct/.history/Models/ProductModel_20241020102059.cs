using MongoDB.Bson.Serialization.Attributes;
namespace FeedbackProduct.Models
{
  public class ProductModel
  {
    [BsonId]
    public string id { get; set; }

    public string name { get; set; } = string.Empty;

    public string image { get; set; } = string.Empty;

    public string image { get; set; } = string.Empty;


    public long created { get; set; }
  }
}