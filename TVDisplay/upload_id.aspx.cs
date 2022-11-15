using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Drawing;
using System.Web.UI;

namespace TVDisplay
{
    public partial class upload_id : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }
        protected void submit_click(object sender, EventArgs e)
        {
            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();

            string query = "SELECT * FROM doctor_list where mails= '" + tb_mail.Text + "' ";
            MySqlCommand cmd = new MySqlCommand(query, sqlconn);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());

            string queryr = "SELECT * FROM residents where mails= '" + tb_mail.Text + "' ";
            MySqlCommand cmdr = new MySqlCommand(queryr, sqlconn);
            DataTable dtr = new DataTable();
            dtr.Load(cmdr.ExecuteReader());


            string queryn = "SELECT * FROM nurse_list where mails= '" + tb_mail.Text + "' ";
            MySqlCommand cmdn = new MySqlCommand(queryn, sqlconn);
            DataTable dtn = new DataTable();
            dtn.Load(cmdn.ExecuteReader());
           

            if (ddl_designation.SelectedItem.Value == "faculty")
            {
                if (dt.Rows.Count == 0)
                {
                    add_doctor();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('This Email id already exists.');", true);
                }
            }
            else if (ddl_designation.SelectedItem.Value == "doc")
            {
                if (dt.Rows.Count == 0)
                {
                    add_doctor();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('This Email id already exists.');", true);
                }
            }
            else if (ddl_designation.SelectedItem.Value == "resident")
            {
                if (dt.Rows.Count == 0)
                {
                    add_resident();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('This Email id already exists.');", true);
                }
            }
            else if (ddl_designation.SelectedItem.Value == "nurse")
            {
                if (dtn.Rows.Count == 0)
                {
                    add_nurse();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('This Email id already exists.');", true);
                }
            }

               
        }

        void add_doctor()
        {
            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();

            String pname = "sp_login_user";
            MySqlCommand cmd = new MySqlCommand(pname, sqlconn);

            cmd.Parameters.AddWithValue("Maction", "add_doctor");
            cmd.Parameters.AddWithValue("Memail", tb_mail.Text);

            Random rand = new Random();
            int number = rand.Next(100000, 999999);

            cmd.Parameters.AddWithValue("Mpassword", number);

            cmd.Parameters.AddWithValue("Mhid", "");
            cmd.Parameters.AddWithValue("Mdesignation", "");
            cmd.Parameters.AddWithValue("Mrole", "user");
            cmd.Parameters.AddWithValue("Msalutation", "");
            cmd.Parameters.AddWithValue("Mfname", "");
            cmd.Parameters.AddWithValue("Mlname", "");
            cmd.Parameters.AddWithValue("Musername", "");
            cmd.Parameters.AddWithValue("Mmob", "");

            cmd.CommandType = CommandType.StoredProcedure;

            Int32 Affectedrows = cmd.ExecuteNonQuery();
            if (Affectedrows != 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Added Successfully');", true);
            }
            sqlconn.Close();
        }
        void add_resident()
        {
            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();

            String pname = "sp_login_user";
            MySqlCommand cmd = new MySqlCommand(pname, sqlconn);

            cmd.Parameters.AddWithValue("Maction", "add_resident");
            cmd.Parameters.AddWithValue("Memail", tb_mail.Text);

            Random rand = new Random();
            int number = rand.Next(100000, 999999);

            cmd.Parameters.AddWithValue("Mpassword", number);

            cmd.Parameters.AddWithValue("Mhid", "");
            cmd.Parameters.AddWithValue("Mdesignation", "");
            cmd.Parameters.AddWithValue("Mrole", "user");
            cmd.Parameters.AddWithValue("Msalutation", "");
            cmd.Parameters.AddWithValue("Mfname", "");
            cmd.Parameters.AddWithValue("Mlname", "");
            cmd.Parameters.AddWithValue("Musername", "");
            cmd.Parameters.AddWithValue("Mmob", "");

            cmd.CommandType = CommandType.StoredProcedure;

            Int32 Affectedrows = cmd.ExecuteNonQuery();
            if (Affectedrows != 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Added Successfully');", true);
            }
            sqlconn.Close();
        }

        void add_nurse()
        {
            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();

            String pname = "sp_login_user";
            MySqlCommand cmd = new MySqlCommand(pname, sqlconn);

            cmd.Parameters.AddWithValue("Maction", "add_nurse");
            cmd.Parameters.AddWithValue("Memail", tb_mail.Text);

            Random rand = new Random();
            int number = rand.Next(100000, 999999);

            cmd.Parameters.AddWithValue("Mpassword", number);

            cmd.Parameters.AddWithValue("Mhid", "");
            cmd.Parameters.AddWithValue("Mdesignation", "");
            cmd.Parameters.AddWithValue("Mrole", "user");
            cmd.Parameters.AddWithValue("Msalutation", "");
            cmd.Parameters.AddWithValue("Mfname", "");
            cmd.Parameters.AddWithValue("Mlname", "");
            cmd.Parameters.AddWithValue("Musername", "");
            cmd.Parameters.AddWithValue("Mmob", "");

            cmd.CommandType = CommandType.StoredProcedure;

            Int32 Affectedrows = cmd.ExecuteNonQuery();
            if (Affectedrows != 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Added Successfully');", true);
            }
            sqlconn.Close();
        }


        protected void goto_home(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}