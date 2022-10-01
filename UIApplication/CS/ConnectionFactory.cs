using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace FBApiApplication.CS
{
    public  class ConnectionFactory
    {
        public  DbConnection Create(string connStr)
        {
            DbProviderFactory factory = DbProvider.Create();
            DbConnection conn = factory.CreateConnection();
            conn.ConnectionString = connStr;
            return conn;
        }
    }
}
