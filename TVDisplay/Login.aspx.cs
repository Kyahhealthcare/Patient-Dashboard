using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TVDisplay
{
    public partial class Login : System.Web.UI.Page
    {
        public string UserAgent { get; }
        protected void Page_Load(object sender, EventArgs e)
        {
           
           
        }
        protected void submit_click(object sender, EventArgs e)
        {
            try
            {
                String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                MySqlConnection sqlconn = new MySqlConnection(con);
                sqlconn.Open();

                string query2 = "SELECT * FROM login_user where username= '" + tb_username.Text + "' ";
                MySqlCommand cmd3 = new MySqlCommand(query2, sqlconn);
                DataTable dts = new DataTable();
                dts.Load(cmd3.ExecuteReader());
                if (dts.Rows.Count != 0)
                {
                    if (tb_password.Text == dts.Rows[0]["password"].ToString())
                    {
                        Response.Cookies["userid"].Value = tb_username.Text;
                        Response.Cookies["userid"].Expires = DateTime.Now.AddDays(15);
                       
                        Response.Cookies["pwd"].Value = tb_password.Text;
                        Response.Cookies["pwd"].Expires = DateTime.Now.AddDays(15);

                        Response.Cookies["check_user"].Value = "valid";
                        Response.Cookies["check_user"].Expires = DateTime.Now.AddDays(15);

                        Response.Cookies["hid"].Value = dts.Rows[0]["hid"].ToString();
                        Response.Cookies["hid"].Expires = DateTime.Now.AddDays(15);

                        Session["username"] = tb_username.Text;
                        Session["hid"] = dts.Rows[0]["hid"].ToString();
                        Session["role"] = dts.Rows[0]["role"].ToString();
                        Response.Redirect("Home.aspx");
                    }
                    else
                    {
                        lblMsg.Visible = true;
                        return;
                    }
                }
                else
                {
                    lblMsg.Visible = true;
                    return;
                }
                sqlconn.Close();
            }
            catch (Exception m)
            { }

        }

        protected void goto_register(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}