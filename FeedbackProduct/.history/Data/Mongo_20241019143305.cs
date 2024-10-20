using MongoDB.Driver;
using System;
using System.Text;

namespace FeedbackProduct.Data
{
  public class Mongo
  {
    private static MongoCredential credential = MongoCredential.CreateCredential("admin", "fastdo", "#=62=V8l5%%jHN4");
    private static MongoClientSettings settings = MongoClientSettings.FromConnectionString("mongodb://192.168.1.3:27017/");

    private static MongoCredential credential2 = MongoCredential.CreateCredential("admin", "fastdo", "#=62=V8l5%%jHN4");
    private static MongoClientSettings settings2 = MongoClientSettings.FromConnectionString("mongodb://192.168.1.3:27018/");

    public static IMongoDatabase DbConnect(string name, int type = 1)
    {
      var environtment = SystemService.GetEnvironment();

      if (environtment == "development")
      {
        var mongoClient = new MongoClient();

        return mongoClient.GetDatabase(name);
      }
      else if (environtment == "production")
      {
        if (type == 1)
        {
          settings.Credential = credential;
          var mongoClient = new MongoClient(settings);
          return mongoClient.GetDatabase(name);
        }
        else if (type == 2)
        {
          settings2.Credential = credential2;
          var mongoClient = new MongoClient(settings2);
          return mongoClient.GetDatabase(name);
        }
      }
      else if (environtment == "beta")
      {
        var mongoClient = new MongoClient();

        return mongoClient.GetDatabase(name);
      }

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