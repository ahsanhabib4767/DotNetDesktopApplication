using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
namespace FBApiApplication.CS
{
    public  class DBHelper:IDisposable
    {

        
       
        private static string connStr;//= System.Configuration.ConfigurationSettings.AppSettings["DBConn"];

        public DBHelper()
        {
            connStr = ConnectionString.GetCBSConnectionString();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #region "DB Command Creatation"
        public  DbCommand CreateCommand(string sqlQuery, CommandType commandType)
        {
            ConnectionFactory conF = new ConnectionFactory();
 
                DbConnection conn = conF.Create(connStr);
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = sqlQuery;
                cmd.CommandType = commandType;
                return cmd;
           
        }
        public DbCommand LiveCreateCommand(string sqlQuery, CommandType commandType)
        {
            connStr = ConnectionString.GetCBSLiveConnectionString();
            ConnectionFactory conF = new ConnectionFactory();

            DbConnection conn = conF.Create(connStr);
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
        #endregion

        public DbCommand ExecuteStoredProcesure(string sqlQuery)
        {
            return CreateCommand(sqlQuery, CommandType.StoredProcedure);
        }
        public DbCommand LiveExecuteStoredProcesure(string sqlQuery)
        {
            return LiveCreateCommand(sqlQuery, CommandType.StoredProcedure);
        }
        public  DbCommand ExecutePlanSQL(string sqlQuery)
        {
            return CreateCommand(sqlQuery, CommandType.Text);
        }
        

        public  int ExecuteCommand(string command)
        {
            DbCommand cmd = ExecutePlanSQL(command);
            cmd.Connection.Open();
            int result = 0;
            try
            {
               
                result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
        }
        public  DataTable  GenerateDataTable(string command)
        {
            DbCommand cmd = ExecutePlanSQL(command);
            cmd.Connection.Open();
            try
            {
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch(Exception ex)
            {
                throw (ex);
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
            
        }

        public int CBSExecuteCommand(string command)
        {
            SysHelper CBSDB = new SysHelper();
            DbCommand cmd = CBSDB.ExecutePlanSQL(command, ConnectionString.GetCBSConnectionString());           
            cmd.Connection.Open();
            int result = 0;
            try
            {

                result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
        }

        public int LiveCBSExecuteCommand(string command)
        {
            SysHelper CBSDB = new SysHelper();
            DbCommand cmd = CBSDB.ExecutePlanSQL(command, ConnectionString.GetCBSLiveConnectionString());
            cmd.Connection.Open();
            int result = 0;
            try
            {

                result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
        }

    }
}
