using MongoDB.Driver;
using System;
using System.Text;

namespace FeedbackProduct.Data
{
  public class Mongo
  {
    public static IMongoDatabase DbConnect(string name, int type = 1)
    {
      var environtment = SystemService.GetEnvironment();

      var mongoClient = new MongoClient();

      return mongoClient.GetDatabase(name);
      return null;
    }

    private static readonly string Characters = "0123456789abcdefghijklmnopqrstuvwxyz";
    public static string RandomId()
    {
      DateTime date = DateTime.Now;

      var result = new StringBuilder();
      result.Append(DateTime.Now.ToString("yy"));
      result.Append(Characters[date.Month]);
      result.Append(Characters[date.Day]);
      result.Append(Guid.NewGuid().ToString().Replace("-", "").Substring(0, 6));

      return result.ToString().ToUpper();
    }
  }
}