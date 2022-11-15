using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Drawing;

namespace TVDisplay
{
    public partial class ResetPass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] == null)
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
            string queryu = "SELECT * FROM login_user where username= '" + Session["username"].ToString() + "' ";
            MySqlCommand cmdu = new MySqlCommand(queryu, sqlconn);
            DataTable dtu = new DataTable();
            dtu.Load(cmdu.ExecuteReader());

            if(dtu.Rows[0]["password"].ToString()==tb_old_pass.Text)
            {
                change();
            }
            else
            {
                lblMsg.Text = "The old password you have entered is incorrect.";
                lblMsg.BackColor = Color.Red;
                lblMsg.ForeColor = Color.White;
                lblMsg.Visible = true;
            }
            sqlconn.Close();
        }

        void change()
        {
            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();

            String pname = "sp_login_user";
            MySqlCommand cmd = new MySqlCommand(pname, sqlconn);

            cmd.Parameters.AddWithValue("Maction", "CHANGE_PASS");
            cmd.Parameters.AddWithValue("Mpassword", tb_pass1.Text);
            cmd.Parameters.AddWithValue("Musername", Session["username"].ToString());
            cmd.Parameters.AddWithValue("Mhid", "");
            cmd.Parameters.AddWithValue("Mdesignation", "");
            cmd.Parameters.AddWithValue("Mrole", "");
            cmd.Parameters.AddWithValue("Msalutation", "");
            cmd.Parameters.AddWithValue("Mfname", "");
            cmd.Parameters.AddWithValue("Mlname", "");
            cmd.Parameters.AddWithValue("Memail", "");
            cmd.Parameters.AddWithValue("Mmob", "");
            cmd.CommandType = CommandType.StoredProcedure;

            Int32 Affectedrows = cmd.ExecuteNonQuery();
            if (Affectedrows != 0)
            {
                lblMsg.Text = "Your password has been successfully changed.";
                lblMsg.BackColor = Color.Green;
                lblMsg.ForeColor = Color.White;
                lblMsg.Visible = true;

            }
            sqlconn.Close();
        }
        protected void goto_login(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}