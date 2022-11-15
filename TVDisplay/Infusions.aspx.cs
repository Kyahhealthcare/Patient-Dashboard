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
    public partial class Infusions : System.Web.UI.Page
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
                   // uhid.Visible = true;
                    //l_uhid.Text = Session["uhid"].ToString();
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

        void fill_form()
        {
            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();

            string query2 = "SELECT * FROM infusion_details where uhid= '" + Session["uhid"].ToString() + "'  ";
            MySqlCommand cmd3 = new MySqlCommand(query2, sqlconn);
            DataTable dt = new DataTable();
            dt.Load(cmd3.ExecuteReader());
            if (dt.Rows.Count != 0)
            {
               
                ddl_infusion1.SelectedValue = dt.Rows[0]["infusion1"].ToString();
                tb_quan1.Text = dt.Rows[0]["quan1"].ToString();
                if(dt.Rows[0]["date1"].ToString()!="")
                {
                    tb_date1.Text = Convert.ToDateTime(dt.Rows[0]["date1"]).ToString("dd-MM-yyyy");
                }
                if (dt.Rows[0]["date2"].ToString() != "")
                {
                    tb_date2.Text = Convert.ToDateTime(dt.Rows[0]["date2"]).ToString("dd-MM-yyyy");
                }
                if (dt.Rows[0]["date3"].ToString() != "")
                {
                    tb_date3.Text = Convert.ToDateTime(dt.Rows[0]["date3"]).ToString("dd-MM-yyyy");
                }
                tb_time1.Text = dt.Rows[0]["time1"].ToString();
                tb_time2.Text = dt.Rows[0]["time2"].ToString();
                tb_time3.Text = dt.Rows[0]["time3"].ToString();
                ddl_infusion2.SelectedValue = dt.Rows[0]["infusion2"].ToString();
                tb_quan2.Text = dt.Rows[0]["quan2"].ToString();
                ddl_infusion3.SelectedValue = dt.Rows[0]["infusion2"].ToString();
                tb_quan3.Text = dt.Rows[0]["quan3"].ToString();
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

        protected void save_infusion(object sender, EventArgs e)
        {
            //try
            //{
            if (Session["uhid"] != null)
            {
                String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                MySqlConnection sqlconn = new MySqlConnection(con);

                sqlconn.Open();

                string query2 = "SELECT * FROM infusion_details where uhid= '" + Session["uhid"].ToString() + "'";
                MySqlCommand cmd3 = new MySqlCommand(query2, sqlconn);
                DataTable dt2 = new DataTable();
                dt2.Load(cmd3.ExecuteReader());

                String pname = "sp_infusion_details";
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
                cmd.Parameters.AddWithValue("Minfusion1", ddl_infusion1.SelectedValue);
                cmd.Parameters.AddWithValue("Mquan1", tb_quan1.Text);
                    if (tb_date1.Text != "")
                    {
                        cmd.Parameters.AddWithValue("Mdate1", Convert.ToDateTime(tb_date1.Text));
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("Mdate1", null);
                    }
                    if (tb_date2.Text != "")
                    {
                        cmd.Parameters.AddWithValue("Mdate2", Convert.ToDateTime(tb_date2.Text));
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("Mdate2", null);
                    }
                    if (tb_date3.Text != "")
                    {
                        cmd.Parameters.AddWithValue("Mdate3", Convert.ToDateTime(tb_date3.Text));
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("Mdate3", null);
                    }
                    if (tb_time1.Text != "")
                    {
                        cmd.Parameters.AddWithValue("Mtime1", tb_time1.Text);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("Mtime1", null);
                    }
                    if (tb_time2.Text != "")
                    {
                        cmd.Parameters.AddWithValue("Mtime2", tb_time2.Text);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("Mtime2", null);
                    }
                    if (tb_time3.Text != "")
                    {
                        cmd.Parameters.AddWithValue("Mtime3", tb_time3.Text);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("Mtime3", null);
                    }
                    cmd.Parameters.AddWithValue("Minfusion2", ddl_infusion2.SelectedValue);
                    cmd.Parameters.AddWithValue("Mquan2", tb_quan2.Text);
                    cmd.Parameters.AddWithValue("Minfusion3", ddl_infusion3.SelectedValue);
                    cmd.Parameters.AddWithValue("Mquan3", tb_quan3.Text);

                    Int32 Affectedrows = cmd.ExecuteNonQuery();
                    if (Affectedrows != 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record inserted Successfully');", true);
                       // Session["uhid"] = l_uhid.Text;
                    }
                    sqlconn.Close();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Enter uhid');", true);
                }
            //}
            //catch (Exception m)
            //{
            //    Label l = new Label();
            //    l.Text = "<script>alert('" + m.Message + "')</script>";
            //    Form.Controls.Add(l);
            //}
        }
    }
}