using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackProduct.Data
{
  public class Product
  {
    private static string _collection = "product";

    public static async Task Create(string companyId, ProductModel model)
    {
      if (string.IsNullOrEmpty(model.id))
        model.id = Mongo.RandomId();
      model.date = DateTime.Now.Ticks;

      var _db = Mongo.DbConnect("fastdo_" + companyId);

      var collection = _db.GetCollection<CheckListModel>(_collection);

      await collection.InsertOneAsync(model);

      return model;
    }


    public static async Task<CheckListModel> Update(string companyId, CheckListModel model)
    {
      var _db = Mongo.DbConnect("fastdo_" + companyId);

      var collection = _db.GetCollection<CheckListModel>(_collection);

      var option = new ReplaceOptions { IsUpsert = false };

      var result = await collection.ReplaceOneAsync(x => x.id.Equals(model.id), model, option);

      return model;
    }


    public static async Task<bool> Delete(string companyId, string id)
    {
      var _db = Mongo.DbConnect("fastdo_" + companyId);

      var collection = _db.GetCollection<CheckListModel>(_collection);

      var result = await collection.DeleteOneAsync(x => x.id == id);

      if (result.DeletedCount > 0)
        return true;
      else
        return false;
    }


    public static async Task<CheckListModel> Get(string companyId, string id)
    {
      var _db = Mongo.DbConnect("fastdo_" + companyId);

      var collection = _db.GetCollection<CheckListModel>(_collection);

      return await collection.Find(x => x.id == id).FirstOrDefaultAsync();
    }


    public static async Task<List<CheckListModel>> GetList(string companyId, string user)
    {
      var _db = Mongo.DbConnect("fastdo_" + companyId);

      var collection = _db.GetCollection<CheckListModel>(_collection);

      var builder = Builders<CheckListModel>.Filter;

      var filtered = builder.Eq("user", user);

      var result = await collection.Find(x => x.user == user).ToListAsync();

      return (from x in result orderby x.date descending select x).ToList();
    }

  }
}