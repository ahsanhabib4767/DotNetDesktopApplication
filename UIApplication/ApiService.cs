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

namespace FBApiApplication
{
    public partial class ApiService : Form
    {

        private Service cs;
        int duration;
        public ApiService()
        {
            cs = new Service();
            duration = cs.TimeParameter();
            InitializeComponent();
        }

        //Exit Button
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit?", "FloraBankApi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnParameter_Click(object sender, EventArgs e)
        {
            ParameterSetup sp = new ParameterSetup();
            sp.Show();
        }

        //Service start and post api data
        private void btnStart_Click(object sender, EventArgs e)
        {
            message_label.Text = "Service is Running!";
            message_label.ForeColor = Color.Green;
            btnParameter.Enabled = false;
            btnondemand.Enabled = false;
            btnStart.Enabled = false;
            timer1.Enabled = true;
            timer1.Start();
            ApiParameter objApiParameter = new ApiParameter();
            objApiParameter = cs.Get_Parameter_Data();
            if (objApiParameter != null && objApiParameter.SendAft.Length > 0)
            {
                txttimervalue.Text = objApiParameter.SendAft.ToString();
                duration = Int32.Parse(objApiParameter.SendAft.ToString());
            }
            else
            {
                timer1.Stop();
                message_label.Text = "Service is Stopped!";
                message_label.ForeColor = Color.Red;
                btnParameter.Enabled = true;
                btnondemand.Enabled = true;
                btnStart.Enabled = true;
            }
        }
        //service stop
        private void btnStop_Click(object sender, EventArgs e)
        {
            message_label.Text = "Service is Stopped!";
            message_label.ForeColor = Color.Red;
            btnParameter.Enabled = true;
            btnondemand.Enabled = true;
            btnStart.Enabled = true;
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            duration--;
            txttimervalue.Text = duration.ToString();
            Service cs = new Service();
           
            if (duration == 0)
            {

                //MessageBox.Show("time up");
                //message_label.Text = "Service is Stopped!";
                cs.SendDatatoApi();
                ApiParameter objApiParameter = new ApiParameter();
                objApiParameter=cs.Get_Parameter_Data();
                if (objApiParameter != null && objApiParameter.SendAft.Length > 0)
                {
                    txttimervalue.Text = objApiParameter.SendAft.ToString();
                    duration = Int32.Parse(objApiParameter.SendAft.ToString());
                }
                else
                {
                    timer1.Stop();
                    message_label.Text = "Service is Stopped!";
                    message_label.ForeColor = Color.Red;
                    btnParameter.Enabled = true;
                    btnondemand.Enabled = true;
                    btnStart.Enabled = true;
                }
               
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ApiService_Load(object sender, EventArgs e)
        {

        }

        private void btnondemand_Click(object sender, EventArgs e)
        {
            try
            {
                Service cs = new Service();
                cs.SendDatatoApi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        //Backup
       
        

        private void btnBkp_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == false)
            {
                cs.InsertBackupLogData();
                //message_label.Text = "Backup Taken Successfully!";
                MessageBox.Show("Backup Taken Successfully!");

            }
            else
            {
                //message_label.Text = "Stop Service";

                MessageBox.Show("Stop Service First!");

            }
        }
    }
}
