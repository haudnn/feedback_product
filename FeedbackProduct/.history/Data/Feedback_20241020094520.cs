using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackProduct.Data
{
  public class Feedback
  {
    private static string _collection = "feedback";

    public static async Task Create(string companyId, DayOffModel model)
    {
      var _db = Mongo.DbConnect("fastdo_" + companyId);

      if (string.IsNullOrEmpty(model.id))
        model.id = Mongo.RandomId();
      model.create = DateTime.Now.Ticks;

      var collection = _db.GetCollection<DayOffModel>(_collection);

      await collection.InsertOneAsync(model);

      return model;
    }

  }
}