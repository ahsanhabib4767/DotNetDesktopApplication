using FBApiApplication;
using FBApiApplication.CS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class login : Form
    {
        DBHelper DB;
        Service objSendData;
        public login()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string CBSYN = System.Configuration.ConfigurationSettings.AppSettings["OwnCBS"];
            if (CBSYN == "Y")
            {
                Login_CBS();
            }
            else
            {
               // Login();
            }
            //Login();
        }

        void Login_CBS()
        {
            try
            {
                if (txtuserID.Text == "" || txtuserID.Text == null)
                {
                    MessageBox.Show("Please Enter User ID");
                    txtuserID.Focus();
                }
                else if (txtPassword.Text == "" || txtPassword.Text == null)
                {
                    MessageBox.Show("Please Enter Password");
                    txtPassword.Focus();
                }
                else
                {
                    DataTable dt = null;
                    DB = new DBHelper();
                    objSendData = new Service();
                    var rtgsObj = new ApiService();
                    string HOYN = FBSession.GetHeadOfficeYN();
                    string HObranchCode = FBSession.GetHeadOfficebranchCode();
                    try
                    {


                        if (HOYN == "Y")
                        {
                            dt = FBSession.GetDataFromCBS("select user_code,userpass_net,username,user_level,branch_code from user_login where user_code=" + txtuserID.Text + " and enabledYN='Y' and branch_code='" + HObranchCode + "'");
                        }
                        else
                        {
                            dt = FBSession.GetDataFromCBS("select user_code,userpass_net,username,user_level,branch_code from user_login where user_code=" + txtuserID.Text + " and enabledYN='Y'");
                        }
                        if (dt.Rows.Count > 0)
                        {

                            Settings.UserID = Convert.ToInt32(dt.Rows[0]["user_code"]);
                            string branch_code = dt.Rows[0]["branch_code"].ToString();
                            Settings.FloraBranchCode = branch_code;
                            Settings.ServerDate = FBSession.GetServerDate();

                            DataTable dtfloraBankId = new DataTable();
                            dtfloraBankId = FBSession.GetDataFromCBS("select florabank_ID from dbo.parameter_mstr");
                            if (dtfloraBankId.Rows.Count > 0)
                            {
                                Settings.florabank_ID = dtfloraBankId.Rows[0]["florabank_ID"].ToString();
                            }
                            string db_pass = dt.Rows[0]["userpass_net"].ToString();
                            string encripted_pass = FloraBank.Core.SystemSecurity.Encrypt(txtuserID.Text + txtPassword.Text.Trim() + branch_code);
                            
                        if (db_pass == encripted_pass)
                        {  
                            var obj = new ApiService();
                            obj.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid User ID or Password");
                        }
                        }
                        else
                        {
                            MessageBox.Show("Invalid User ID or Password");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Invalid User ID or Password");
                    }
                    finally
                    {
                        DB.Dispose();
                        objSendData.Dispose();
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
