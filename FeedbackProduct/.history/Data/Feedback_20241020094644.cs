using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeedbackProduct.Models;

namespace FeedbackProduct.Data
{
  public class Feedback
  {
    private static string _collection = "feedback";

    public static async Task Create(FeedbackModel model)
    {
      var _db = Mongo.DbConnect("feedback");

      if (string.IsNullOrEmpty(model.id))
        model.id = Mongo.RandomId();
      model.created = DateTime.Now.Ticks;

      var collection = _db.GetCollection<FeedbackModel>(_collection);

      await collection.InsertOneAsync(model);
    }

    public static async Task<List<FeedbackModel>> GetAll(FeedbackModel model)
    {
      var _db = Mongo.DbConnect("feedback");

      var collection = _db.GetCollection<FeedbackModel>(_collection);

      return await collection.Find(x => true).FirstOrDefaultAsync();
    }

  }
}