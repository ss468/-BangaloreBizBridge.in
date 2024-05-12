using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestHub.Core.Interfaces.Repository;
using MongoDB.Driver;
using MongoDB.Driver.Core.Connections;

namespace InvestHub.DAL.Repositories
{
    public class DBConnectionFactory : IDBConnectionFactory
    {
        private readonly IMongoDatabase _database;

        public DBConnectionFactory(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoDatabase GetDatabase(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            return client.GetDatabase(databaseName);
        }
        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}
