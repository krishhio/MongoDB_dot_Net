using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Runtime.CompilerServices;


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

            /*
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
            */

            /*
            var person = new Person
            {
                name = "Cristian",
                Age = 29,
                Colors = new List<string> { "red", "blue" },
                Pets = new List<Pet> { new Pet { Name = "Sophie", type = "Husky" } },
                ExtraElements = new BsonDocument("otroNombre","otroDato")
            };

            using (var writer = new JsonWriter(Console.Out))
            {
                BsonSerializer.Serialize(writer, person);
            }
            */
            /*

            var client = new MongoClient("mongodb://127.0.0.1:27017");
            var db = client.GetDatabase("test");

            var col = db.GetCollection<BsonDocument>("people");
           //var col = db.GetCollection<Person>("people");
            var doc = new BsonDocument
            {
                {"name","Cristian Gomez"},
                {"age", 30},
                {"Profession","Hacker"}
            };
            await col.InsertOneAsync(doc);

            var doc2 = new BsonDocument
            {
                {"algunDato",true},
                {"unLoQueSea","blablabla"}
            };

            var docClass = new Person
            {
                name = "Candy",
                Age = 30,
                Profession = "Diseñadora Grafica"

            };


            await col.InsertManyAsync(new[] { doc, doc2 });
           // await col.InsertOneAsync(docClass);

            */

            /*
            var connectionString = "mongodb://127.0.0.1:27017";
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase("test");
            var col = db.GetCollection<BsonDocument>("people");


            using (var cursor = await col.Find(new BsonDocument()).ToCursorAsync())
            {
                while(await cursor.MoveNextAsync())
                {
                    foreach(var doc in cursor.Current)
                    {
                        Console.WriteLine(doc);
                    }
                }
            }
            */
            /*
            var connectionString = "mongodb://127.0.0.1:27017";
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase("test");
            var col = db.GetCollection<BsonDocument>("people");


            await col.Find(new BsonDocument()).ForEachAsync(doc => Console.WriteLine(doc));

            */
            /*

            var client = new MongoClient();
            var db = client.GetDatabase("test");
            var col = db.GetCollection<Person>("people");

            //var filter = new BsonDocument("name", "Cristian Gomez");
            /*
            var filter = new BsonDocument("$and", new BsonArray
            {
                new BsonDocument("Age", new BsonDocument("$eq",30)),
                new BsonDocument("name","Cristian Gomez")
            });
            */
            /*
            var builder = Builders<Person>.Filter;
            //var filter = builder.And(builder.Gt("Age", 20), builder.Eq("name", "Candy"));
            var filter = builder.Gt("Age", 20) & builder.Eq("name", "Candy"); 
            //var list = await col.Find(filter).ToListAsync();
            //var list = await col.Find("{\"name\":'Cristian Gomez'}").ToListAsync();
            var list = await col.Find(filter).ToListAsync();

            foreach (var doc in list)
            {
                Console.WriteLine(doc);
            }
            */

            var client = new MongoClient();
            var db = client.GetDatabase("test");
            var col = db.GetCollection<BsonDocument>("people");

            /* var list = await col.Find(new BsonDocument())
                                 .Skip(1)
                                 .Limit(1)
                                 .ToListAsync();*/

            //var list = await col.Find(new BsonDocument())
            //.Sort("{Age:1}")
            //.ToListAsync();

            var list = await col.Find(new BsonDocument())
                                .Project("{name:1,_id:0}")
                                .ToListAsync();

            foreach (var doc in list)
            {
                Console.WriteLine(doc);
            }


        }
    }


    class Person
    {
        public ObjectId Id { get; set;}

        public string name { get; set; }

        public int Age { get; set; }

        public string Profession { get; set; }


    }

    class Pet
    {
        public string Name { get; set; }
        public string type { get; set; }
    }

}
