using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MongoDB.Bson;
using MongoDB.Driver;


namespace MongoDBApp
{
    class Program
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;

        private static void PrintMenu()
        {
            Console.WriteLine("p \t список всех пользователей");
            Console.WriteLine("a \t добавить пользователя");
            Console.WriteLine("r \t удалить пользователя");
            Console.WriteLine("m \t отобразить меню");
            Console.WriteLine("e \t выход\n");
        }

       
        static void Main()
        {
            const string connect = "mongodb://localhost";
            _client = new MongoClient(connect);          
            _database = _client.GetDatabase("test");

            Info info = new Info();

            //info.Insert(_database);
            info.Select(_database);          
            
        }
    }
}
