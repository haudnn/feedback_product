using MongoDB.Bson.Serialization.Attributes;

namespace FeedbackProduct.Models
{
  public class FeedbackModel
  {
    [BsonId]
    public string id { get; set; }

    public string email { get; set; }

    public string name { get; set; }

    public string productId { get; set; }

    public string content { get; set; }

    public string created { get; set; }
  }
}