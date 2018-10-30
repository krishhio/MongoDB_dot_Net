using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace M101DotNet
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
            Console.WriteLine();
            Console.WriteLine("Presiona Enter");
            Console.ReadLine();
        }

        static async Task MainAsync(string[] args)
        {
            //await Task.Delay(500);
            /* var connectionString = "mongodb://127.0.0.1:27017";
             var client = new MongoClient(connectionString);
             var db = client.GetDatabase("test");
             var col = db.GetCollection<BsonDocument>("people");
             Console.WriteLine("Conexion a Mongodb");*/
            BsonDocument doc = new BsonDocument
            {
                {"name","Cristian"}
            };

            doc.Add("Привет! Я ", 40);
            doc["profesion"] = "Solution Architect";
            Console.WriteLine(doc);

        }
    }
}
