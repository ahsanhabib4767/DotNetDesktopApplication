using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBApiApplication.CS
{
   public class FBSession
    {

       public static string GetHeadOfficeYN()
       {
           string HOYN = "";
           DataTable dt = null;
           DBHelper DB = new DBHelper();
           try
           {

               dt = DB.GenerateDataTable(@"select Pub_bank_id,hobr from parameter_online where hobr='H'");
               if (dt.Rows.Count > 0)
               {
                   HOYN = dt.Rows[0]["hobr"].ToString();
               }
           }
           catch (Exception ex)
           {
               throw (ex);
           }
           finally
           {
               DB.Dispose();
           }

           return HOYN;
       }
       public static string GetHeadOfficebranchCode()
       {
           string branchCode = "";
           DataTable dt = null;
           DBHelper DB = new DBHelper();
           try
           {

               dt = DB.GenerateDataTable(@"select Pub_bank_id,hobr from parameter_online where hobr='H'");
               if (dt.Rows.Count > 0)
               {
                   branchCode = dt.Rows[0]["Pub_bank_id"].ToString();
               }
           }
           catch (Exception ex)
           {
               throw (ex);
           }
           finally
           {
               DB.Dispose();
           }

           return branchCode;
       }
       public static DataTable GetDataFromCBS(string command)
       {
           SysHelper DB = new SysHelper();
           DbCommand cmd = DB.ExecutePlanSQL(command, ConnectionString.GetCBSConnectionString());
           cmd.Connection.Open();
           try
           {
               DataTable dt = new DataTable();
               dt.Load(cmd.ExecuteReader());
               return dt;
           }
           catch (Exception ex)
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

       public static string GetServerDate()
       {
           DBHelper _DB = new DBHelper();
           string date = "";
           try
           {
               DataTable dt = _DB.GenerateDataTable("select min(dayend_dt) as _date from DAYEND_DATE where branch_code='" + Settings.FloraBranchCode + "' and holyday_yn='NO' and dayend_yn='NO'");
               if (dt.Rows.Count > 0)
               {
                   date = Convert.ToDateTime(dt.Rows[0][0]).ToShortDateString();
               }
           }
           catch
           {
           }
           finally
           {
               _DB.Dispose();
           }
           return date;
       }
    }
}
