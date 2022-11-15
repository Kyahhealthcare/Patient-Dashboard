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
    public partial class plan : System.Web.UI.Page
    {
        string ret = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneInfo);

            L_date.Text = DateTime.Now.ToString("dd-MM-yyyy");

            if (!IsPostBack)
            {
                if (Session["username"] == null)
                {
                    Response.Redirect("Login.aspx");
                }

                InitializeCulture();
                if (Session["uhid"] != null)
                {
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
           // uhid.Visible = false;
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
            String d = Convert.ToDateTime(L_date.Text).ToString("yyyy-MM-dd");

            string query2 = "SELECT * FROM plan_details where uhid= '" + Session["uhid"].ToString() + "' and date='" + d + "' ";
            MySqlCommand cmd3 = new MySqlCommand(query2, sqlconn);
            DataTable dt = new DataTable();
            dt.Load(cmd3.ExecuteReader());
            if (dt.Rows.Count != 0)
            {
                ddl_ct.SelectedValue = dt.Rows[0]["ct"].ToString();
                tb_ct_part.Text = dt.Rows[0]["ct_part"].ToString();
                tb_ct_finding.Text = dt.Rows[0]["ct_finding"].ToString();
                ddl_xray.SelectedValue = dt.Rows[0]["xray"].ToString();
                tb_xray_part.Text = dt.Rows[0]["xray_part"].ToString();
                ddl_mri.SelectedValue = dt.Rows[0]["mri"].ToString();
                tb_mri_part.Text = dt.Rows[0]["mri_part"].ToString();
                ddl_usd.SelectedValue = dt.Rows[0]["usd"].ToString();
                tb_usd_part.Text = dt.Rows[0]["usd_part"].ToString();
                tb_other.Text = dt.Rows[0]["other"].ToString();
            }
        }
        protected void save_plan(object sender, EventArgs e)
        {
            //try
            //{
                if (Session["uhid"].ToString() != "")
                {
                    String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                    MySqlConnection sqlconn = new MySqlConnection(con);

                    sqlconn.Open();
                    String d = Convert.ToDateTime(L_date.Text).ToString("yyyy-MM-dd");

                    string query2 = "SELECT * FROM plan_details where uhid= '" + Session["uhid"].ToString() + "' and date='" + d + "' ";
                    MySqlCommand cmd3 = new MySqlCommand(query2, sqlconn);
                    DataTable dt2 = new DataTable();
                    dt2.Load(cmd3.ExecuteReader());

                    String pname = "sp_plan_details";
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
                    cmd.Parameters.AddWithValue("Mdate",Convert.ToDateTime(L_date.Text));
                    cmd.Parameters.AddWithValue("Mct",ddl_ct.SelectedValue);
                    cmd.Parameters.AddWithValue("Mct_part",tb_ct_part.Text);
                    cmd.Parameters.AddWithValue("Mct_finding",tb_ct_finding.Text);
                    cmd.Parameters.AddWithValue("Mxray",ddl_xray.SelectedValue);
                    cmd.Parameters.AddWithValue("Mxray_part",tb_xray_part.Text);
                    cmd.Parameters.AddWithValue("Mmri",ddl_mri.SelectedValue);
                    cmd.Parameters.AddWithValue("Mmri_part", tb_mri_part.Text);
                    cmd.Parameters.AddWithValue("Musd",ddl_usd.SelectedValue);
                    cmd.Parameters.AddWithValue("Musd_part",tb_usd_part.Text);
                    cmd.Parameters.AddWithValue("Mother",tb_other.Text);
                   
                    Int32 Affectedrows = cmd.ExecuteNonQuery();
                    if (Affectedrows != 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record inserted Successfully');", true);
                    }
                    sqlconn.Close();
                }
                else
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Enter uhid');", true);
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