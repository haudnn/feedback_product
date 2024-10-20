using FeedbackProduct.Models;
using MongoDB.Driver;

namespace FeedbackProduct.Data
{
  public class Feedback
  {
    private static string _collection = "feedback";

    public static async Task Create(FeedbackModel model)
    {
      var _db = Mongo.DbConnect();

      if (string.IsNullOrEmpty(model.id))
        model.id = Mongo.RandomId();
      model.created = DateTime.Now.Ticks;

      var collection = _db.GetCollection<FeedbackModel>(_collection);

      await collection.InsertOneAsync(model);
    }

    public static async Task<List<FeedbackModel>> GetAll()
    {
      var _db = Mongo.DbConnect("feedback");

      var collection = _db.GetCollection<FeedbackModel>(_collection);

      return await collection.Find(x => true).SortByDescending(x => x.created).ToListAsync();
    }

  }
}