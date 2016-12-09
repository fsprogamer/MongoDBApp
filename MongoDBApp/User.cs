using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDBApp
{
    public class User
    {
        public ObjectId Id { get; set; }
        public String Name { get; set; }
        public int Age { get; set; }
    }

    public class Info
    {
        async public void Insert(IMongoDatabase _database)
        {
            var document = new BsonDocument
            {
                { "address" , new BsonDocument
                    {
                        { "street", "2 Avenue" },
                        { "zipcode", "10075" },
                        { "building", "1480" },
                        { "coord", new BsonArray { 73.9557413, 40.7720266 } }
                    }
                },
                { "borough", "Manhattan" },
                { "cuisine", "Italian" },
                { "grades", new BsonArray
                    {
                        new BsonDocument
                        {
                            { "date", new DateTime(2014, 10, 1, 0, 0, 0, DateTimeKind.Utc) },
                            { "grade", "A" },
                            { "score", 11 }
                        },
                        new BsonDocument
                        {
                            { "date", new DateTime(2014, 1, 6, 0, 0, 0, DateTimeKind.Utc) },
                            { "grade", "B" },
                            { "score", 17 }
                        }
                    }
                },
                { "name", "Vella" },
                { "restaurant_id", "41704620" }
            };

            var collection = _database.GetCollection<BsonDocument>("restaurants");
            await collection.InsertOneAsync(document);
        }

        async public void Select(IMongoDatabase _database)
        {
            var collection = _database.GetCollection<BsonDocument>("restaurants");
            var filter = new BsonDocument();
            var count = 0;
            //using (var cursor = collection.Find(filter))
            {
                //    while (await cursor.MoveNextAsync())
                //    {
                //        var batch = cursor.Current;
                //        foreach (var document in batch)
                //        {
                //            // process document
                //            count++;
                //        }
                //    }
                //}

                var restaurants = collection.FindSync(filter).ToList();
                foreach (var restaurant in restaurants)
                {
                    // Console.WriteLine("Имя: {0}, Возраст: {1}", restaurant, restaurant.Age);
                }
            }
        }
    }
}
