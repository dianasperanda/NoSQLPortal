using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace noSQLportal.Models
{
    public class PortalContext
    {
        private readonly IMongoDatabase _database = null;

        public PortalContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase("nmbp");
        }

        public IMongoCollection<Article> Articles
        {
            get
            {
                return _database.GetCollection<Article>("article");
            }
        }
    }
}
