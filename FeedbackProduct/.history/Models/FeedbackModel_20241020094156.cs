
using MongoDB.Bson.Serialization.Attributes;
namespace FeedbackProduct.Models
{
  public class FeedbackModel
  {
    [BsonId]
    public string id { get; set; }
  }
}