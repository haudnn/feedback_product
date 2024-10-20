using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MongoDB.Bson.Serialization.Attributes;
namespace FeedbackProduct.Models
{
  public class FeedbackModel
  {
    [BsonId]
    public string id { get; set; }
  }
}