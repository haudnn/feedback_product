using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeedbackProduct.Models;
using MongoDB.Driver;

namespace FeedbackProduct.Data
{
  public class Product
  {
    private static string _collection = "product";

    public static async Task Create(ProductModel model)
    {
      if (string.IsNullOrEmpty(model.id))
        model.id = Mongo.RandomId();
      model.created = DateTime.Now.Ticks;

      var _db = Mongo.DbConnect();

      var collection = _db.GetCollection<ProductModel>(_collection);

      await collection.InsertOneAsync(model);
    }


    public static async Task Update(ProductModel model)
    {
      var _db = Mongo.DbConnect();

      var collection = _db.GetCollection<ProductModel>(_collection);

      var option = new ReplaceOptions { IsUpsert = false };

      await collection.ReplaceOneAsync(x => x.id.Equals(model.id), model, option);
    }


    public static async Task Delete(string id)
    {
      var _db = Mongo.DbConnect();

      var collection = _db.GetCollection<CheckListModel>(_collection);

      var result = await collection.DeleteOneAsync(x => x.id == id);


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