using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Runtime.Remoting.Messaging;

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

            doc.Add("Empresa", "ISS");
            doc.Add("Edad ", 40);
            doc["profesion"] = "Solution Architect";
            doc["Origen"] = "Chiapas";

            var nestedArray = new BsonArray();
            nestedArray.Add(new BsonDocument("color", "red"));
            nestedArray.Add(new BsonDocument("color", "green"));
            nestedArray.Add(new BsonDocument("color", "black"));
            doc.Add("array", nestedArray);
            Console.WriteLine(doc["array"][0]["color"]);
            Console.WriteLine(doc);

        }
    }
}
