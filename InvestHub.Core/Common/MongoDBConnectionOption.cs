using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestHub.Core.Common
{
    public class MongoDBConnectionOption
    {
        public string connectionString { get; set; }
        public string databaseName { get; set; }
    }
}
