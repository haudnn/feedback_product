using MongoDB.Bson.Serialization.Attributes;

namespace FeedbackProduct.Models
{
  public class FeedbackModel
  {
    [BsonId]
    public string id { get; set; }

    public string email { get; set; } = string.Empty;

    public string name { get; set; } = string.Empty;

    public string productId { get; set; } = string.Empty;

    public string content { get; set; } = string.Empty;

    public long created { get; set; }
  }
}