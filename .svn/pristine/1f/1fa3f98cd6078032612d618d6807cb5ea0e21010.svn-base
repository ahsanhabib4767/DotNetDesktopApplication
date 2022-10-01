using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
namespace FBApiApplication.CS
{
    public class SysHelper:IDisposable
    {
        public SysHelper()
        {
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public DbCommand CreateCommand(string sqlQuery, CommandType commandType, string Connection)
        {
            ConnectionFactory conF = new ConnectionFactory();

            DbConnection conn = conF.Create(Connection);
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = sqlQuery;
            cmd.CommandType = commandType;
            return cmd;

        }
	
 	public  DbParameter CreateParameter(string name, object value)
        {
            DbParameter param = DbProvider.Create().CreateParameter();
            param.Value = value;
            param.ParameterName = name;

            return param;
        }
        public DbParameter CreateParameterOut(string name, object value)
        {
            DbParameter param = DbProvider.Create().CreateParameter();
            param.Value = value;
            param.ParameterName = name;
            param.Direction = ParameterDirection.Output;
            return param;
        }
        public DbParameter CreateParameterOut(string name, DbType dbtype, int size)
        {
            DbParameter param = DbProvider.Create().CreateParameter();
            param.Size = size;
            param.DbType = dbtype;
            param.ParameterName = name;
            param.Direction = ParameterDirection.Output;
            return param;
        }

        public DbCommand ExecutePlanSQL(string sqlQuery, string Connection)
        {
            return CreateCommand(sqlQuery, CommandType.Text, Connection);
        }

	    public DbCommand ExecuteStoredProcedure(string spname, string Connection)
        {
            return CreateCommand(spname, CommandType.StoredProcedure, Connection);
        }
    }
}
