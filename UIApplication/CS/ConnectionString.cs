using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using FloraBank.Core;
namespace FBApiApplication.CS
{
    public sealed class ConnectionString
    {


        private static DataTable GetData(string command,string Connection)
        {
            SysHelper DB = new SysHelper();
            DbCommand cmd = DB.ExecutePlanSQL(command, Connection);
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
                cmd.Dispose();
                DB.Dispose();
            }
        }

        


        public static string GetCBSConnectionString()
        {
            string con = "";
            string user_id = "";
            string pass = "";
            
            string CBS_server = System.Configuration.ConfigurationSettings.AppSettings["CBS_Server_name"];
            string CBS_DB = System.Configuration.ConfigurationSettings.AppSettings["DBConn"];//


            string SystemConn = "Server=" + CBS_server + ";database=" + CBS_DB + ";uid=system36;pwd=sys36";

            DataTable dt = GetData("select * from wv_net_system36 ", SystemConn);

            if(dt.Rows.Count > 0)
            {
                user_id = dt.Rows[0]["netappuser"].ToString();
                pass = dt.Rows[0]["netappass"].ToString();

                if (SystemSecurity.IsEncrypted(pass))
                    pass = SystemSecurity.Decrypt(pass).Substring(6);


                if (SystemSecurity.IsEncrypted(user_id))
                    user_id = SystemSecurity.Decrypt(user_id).Substring(6);

                con = "Server=" + CBS_server + ";database=" + CBS_DB + ";uid=" + user_id + ";pwd=" + pass;


            }

            return con;
        }

        public static string GetCBSLiveConnectionString()
        {
            string con = "";
            string user_id = "";
            string pass = "";

            string CBS_server = System.Configuration.ConfigurationSettings.AppSettings["CBS_Live_Server_name"];
            string CBS_DB = System.Configuration.ConfigurationSettings.AppSettings["DBConn"];//


            string SystemConn = "Server=" + CBS_server + ";database=" + CBS_DB + ";uid=system36;pwd=sys36";

            DataTable dt = GetData("select * from wv_net_system36 ", SystemConn);

            if (dt.Rows.Count > 0)
            {
                user_id = dt.Rows[0]["netappuser"].ToString();
                pass = dt.Rows[0]["netappass"].ToString();

                if (SystemSecurity.IsEncrypted(pass))
                    pass = SystemSecurity.Decrypt(pass).Substring(6);


                if (SystemSecurity.IsEncrypted(user_id))
                    user_id = SystemSecurity.Decrypt(user_id).Substring(6);

                con = "Server=" + CBS_server + ";database=" + CBS_DB + ";uid=" + user_id + ";pwd=" + pass;


            }

            return con;
        }



    }
}
