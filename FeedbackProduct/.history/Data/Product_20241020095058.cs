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

      var collection = _db.GetCollection<ProductModel>(_collection);

      await collection.DeleteOneAsync(x => x.id == id);
    }


    public static async Task<ProductModel> Get(string id)
    {
      var _db = Mongo.DbConnect();

      var collection = _db.GetCollection<ProductModel>(_collection);

      return await collection.Find(x => x.id == id).FirstOrDefaultAsync();
    }


    public static async Task<List<ProductModel>> GetList()
    {
      var _db = Mongo.DbConnect();

      var collection = _db.GetCollection<ProductModel>(_collection);

      var builder = Builders<ProductModel>.Filter;

      var result = await collection.Find(x => true).SortByDescending(x=> x.created)ToListAsync();

      return result;
    }

  }
}