using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MecBusca.Models
{
    public class DataAccess
    {
        MongoClient _client;
        IMongoDatabase _db;

        public DataAccess()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _db = _client.GetDatabase("aspcore-004-blt-mec-busca");
        }

        [Obsolete]
        public long CountClientes()
        {
            return _db.GetCollection<Cliente>(typeof(Cliente).Name).Count(new FilterDefinitionBuilder<Cliente>().Empty);
        }

        public IEnumerable<Cliente> GetClientes(string query)
        {
            var tags = query.ToUpper().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var filter = Builders<Cliente>.Filter.All(c => c.Tags, tags);
            return _db.GetCollection<Cliente>(typeof(Cliente).Name).Find(filter).ToList();
        }
    }
}
