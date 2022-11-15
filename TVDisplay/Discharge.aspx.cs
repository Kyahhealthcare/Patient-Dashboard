using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TVDisplay
{
    public partial class Discharge : System.Web.UI.Page
    {
        string ret = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                InitializeCulture();
                if (Session["uhid"] != null)
                {
                    //uhid.Visible = true;
                   // l_uhid.Text = Session["uhid"].ToString();
                    fill_form();
                }
                else
                {
                   // uhid.Visible = false;
                }
            }
        }
        protected void btn_remove_Click(object sender, EventArgs e)
        {
            ClearControls(this);
            //uhid.Visible = false;
            Session["uhid"] = null;
        }
        public void ClearControls(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if ((c.GetType() == typeof(TextBox)))  //Clear TextBox
                {
                    ((TextBox)(c)).Text = "";
                }
                if ((c.GetType() == typeof(DropDownList)))  //Clear DropDownList
                {
                    ((DropDownList)(c)).ClearSelection();
                }
                if ((c.GetType() == typeof(CheckBox)))  //Clear CheckBox
                {
                    ((CheckBox)(c)).Checked = false;
                }
                if ((c.GetType() == typeof(CheckBoxList)))  //Clear CheckBoxList
                {
                    ((CheckBoxList)(c)).ClearSelection();
                }
                if ((c.GetType() == typeof(RadioButton)))  //Clear RadioButton
                {
                    ((RadioButton)(c)).Checked = false;
                }
                if ((c.GetType() == typeof(RadioButtonList)))  //Clear RadioButtonList
                {
                    ((RadioButtonList)(c)).ClearSelection();
                }

                if (c.HasControls())
                {
                    ClearControls(c);
                }
            }
        }
        protected override void InitializeCulture()
        {
            CultureInfo CI = new CultureInfo("pt-PT");
            CI.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";

            Thread.CurrentThread.CurrentCulture = CI;
            Thread.CurrentThread.CurrentUICulture = CI;
            base.InitializeCulture();
        }

        void fill_form()
        {
            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();
            

            string query2 = "SELECT * FROM discharge_status where uhid= '" + Session["uhid"].ToString() + "'  ";
            MySqlCommand cmd3 = new MySqlCommand(query2, sqlconn);
            DataTable dt = new DataTable();
            dt.Load(cmd3.ExecuteReader());
            if (dt.Rows.Count != 0)
            {
                ddl_status.SelectedValue = dt.Rows[0]["status"].ToString();
                tb_date.Text =Convert.ToDateTime(dt.Rows[0]["date"]).ToString("dd-MM-yyyy");
                tb_time.Text = dt.Rows[0]["time"].ToString();
            }
        }
        protected void save_status(object sender, EventArgs e)
        {
            try
            {
                if (Session["uhid"] != null)
                {
                    String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                    MySqlConnection sqlconn = new MySqlConnection(con);

                    sqlconn.Open();

                    string query2 = "SELECT * FROM discharge_status where uhid= '" + Session["uhid"].ToString() + "'";
                    MySqlCommand cmd3 = new MySqlCommand(query2, sqlconn);
                    DataTable dt2 = new DataTable();
                    dt2.Load(cmd3.ExecuteReader());

                    String pname = "sp_discharge_status";
                    MySqlCommand cmd = new MySqlCommand(pname, sqlconn);

                    if (dt2.Rows.Count != 0)
                    {
                        cmd.Parameters.AddWithValue("Maction", "UPDATE");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("Maction", "INSERT");
                    }

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("Muhid", Session["uhid"].ToString());
                    cmd.Parameters.AddWithValue("Mstatus",ddl_status.SelectedValue);
                    cmd.Parameters.AddWithValue("Mdate", Convert.ToDateTime(tb_date.Text));
                    cmd.Parameters.AddWithValue("Mtime", tb_time.Text);

                    empty_bed();

                    Int32 Affectedrows = cmd.ExecuteNonQuery();
                    if (Affectedrows != 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record inserted Successfully');", true);
                        //Session["uhid"] = l_uhid.Text;
                    }
                    sqlconn.Close();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Enter uhid');", true);
                }
            }
            catch (Exception m)
            {
                Label l = new Label();
                l.Text = "<script>alert('" + m.Message + "')</script>";
                Form.Controls.Add(l);
            }
        }


        void empty_bed()
        {
            if (Session["uhid"] != null)
            {
                String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                MySqlConnection sqlconn = new MySqlConnection(con);

                sqlconn.Open();

                string query2 = "SELECT * FROM pt_details where uhid= '" + Session["uhid"].ToString() + "'";
                MySqlCommand cmd3 = new MySqlCommand(query2, sqlconn);
                DataTable dt2 = new DataTable();
                dt2.Load(cmd3.ExecuteReader());

                String pname = "sp_pt_details";
                MySqlCommand cmd = new MySqlCommand(pname, sqlconn);

                if (dt2.Rows.Count != 0)
                {
                    cmd.Parameters.AddWithValue("Maction", "empty_bed");
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("Mentered_date", "");
                    cmd.Parameters.AddWithValue("Mfname", "");
                    cmd.Parameters.AddWithValue("Mlname", "");
                    cmd.Parameters.AddWithValue("Msex", "");
                    cmd.Parameters.AddWithValue("Mdob", "");
                    cmd.Parameters.AddWithValue("Mbld_grp", "");
                    cmd.Parameters.AddWithValue("Mbld_donated", "");
                    cmd.Parameters.AddWithValue("Mdate_admit", "");
                    cmd.Parameters.AddWithValue("Mdiag1", "");
                    cmd.Parameters.AddWithValue("Mdiag2", "");
                    cmd.Parameters.AddWithValue("Mdiag3", "");
                    cmd.Parameters.AddWithValue("Mward", "");
                    cmd.Parameters.AddWithValue("Mentered_by", "");
                    cmd.Parameters.AddWithValue("Mconsultant", "");

                    cmd.Parameters.AddWithValue("Muhid", Session["uhid"].ToString());
                    cmd.Parameters.AddWithValue("Mbed", "");

                }

                

                Int32 Affectedrows = cmd.ExecuteNonQuery();
                if (Affectedrows != 0)
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record inserted Successfully');", true);
                   
                }
                sqlconn.Close();
            }
        }
    }
    
}