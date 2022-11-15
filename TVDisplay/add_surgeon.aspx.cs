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
    public partial class add_surgeon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Session["username"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void submit_click(object sender, EventArgs e)
        {
            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();

            string query = "SELECT * FROM surgeon where username= '" + tb_acronym.Text + "' ";
            MySqlCommand cmd = new MySqlCommand(query, sqlconn);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count == 0)
            {
                add_surgeons();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('This acronym is already exists.');", true);
            }       

        }

        void add_surgeons()
        {
            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();

            String pname = "sp_login_user";
            MySqlCommand cmd = new MySqlCommand(pname, sqlconn);

            cmd.Parameters.AddWithValue("Maction", "add_surgeon");
           
            // otp = dtn.Rows[0]["pass"].ToString();


            cmd.Parameters.AddWithValue("Mhid", Session["hid"].ToString());
            cmd.Parameters.AddWithValue("Mfname", tb_fname.Text);
            cmd.Parameters.AddWithValue("Mlname", tb_lname.Text);
            cmd.Parameters.AddWithValue("Musername", tb_acronym.Text);

            cmd.Parameters.AddWithValue("Mdesignation", "");
            cmd.Parameters.AddWithValue("Mrole", "");
            cmd.Parameters.AddWithValue("Msalutation", "");            
            cmd.Parameters.AddWithValue("Memail", "");
            cmd.Parameters.AddWithValue("Mmob", "");
            cmd.Parameters.AddWithValue("Mpassword", "");
            cmd.CommandType = CommandType.StoredProcedure;

            Int32 Affectedrows = cmd.ExecuteNonQuery();
            if (Affectedrows != 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Surgeon added successfully.');", true);
            }
            sqlconn.Close();
        }
        protected void goto_home(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}