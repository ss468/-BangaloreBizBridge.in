using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace InvestHub.Core.Interfaces.Repository
{
    public interface IDBConnectionFactory
    {
        IMongoDatabase GetDatabase(string connectionString, string databaseName);
        IMongoCollection<T> GetCollection<T>(string collectionName);
    }
}
