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
    public partial class fever : System.Web.UI.Page
    {
        private object tb_rr_date;

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
                    //l_uhid.Text = Session["uhid"].ToString();
                    fill_fever_grid();
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

        void fill_fever_grid()
        {
            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();

            String pname = "sp_fever_pack_details";
            MySqlCommand cmd = new MySqlCommand(pname, sqlconn);
            cmd.Parameters.AddWithValue("Maction", "SELECT");
            cmd.Parameters.AddWithValue("Muhid", Session["uhid"].ToString());
            cmd.Parameters.AddWithValue("Mdate", "");
            cmd.Parameters.AddWithValue("Mbld_cs", "");
            cmd.Parameters.AddWithValue("Mbld_cs_cmt", "");
            cmd.Parameters.AddWithValue("Mtrach_cs", "");
            cmd.Parameters.AddWithValue("Mtrach_cs_cmt", "");
            cmd.Parameters.AddWithValue("Murine_cs", "");
            cmd.Parameters.AddWithValue("Murine_cs_cmt", "");
            cmd.Parameters.AddWithValue("Murine_wbc", "");
            cmd.Parameters.AddWithValue("Murine_ph", "");
            cmd.Parameters.AddWithValue("Murine_rm_cmt", "");
            cmd.CommandType = CommandType.StoredProcedure;

            using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
            {
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);
                    gv2.DataSource = dt;
                    gv2.DataBind();
                }
            }
            sqlconn.Close();
        }
        protected void save_fever_pack(object sender, EventArgs e)
        {
            try
            {
                if (Session["uhid"].ToString() != "")
                {
                    String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                    MySqlConnection sqlconn = new MySqlConnection(con);

                    sqlconn.Open();
                    String d = Convert.ToDateTime(tb_date.Text).ToString("yyyy-MM-dd");

                    string query2 = "SELECT * FROM fever_pack_details where uhid= '" + Session["uhid"].ToString() + "' and date='" + d + "' ";
                    MySqlCommand cmd3 = new MySqlCommand(query2, sqlconn);
                    DataTable dt2 = new DataTable();
                    dt2.Load(cmd3.ExecuteReader());

                    String pname = "sp_fever_pack_details";
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
                    cmd.Parameters.AddWithValue("Mdate", Convert.ToDateTime(tb_date.Text));
                    cmd.Parameters.AddWithValue("Mbld_cs",ddl_bld.SelectedValue);
                    cmd.Parameters.AddWithValue("Mbld_cs_cmt",tb_bld.Text);
                    cmd.Parameters.AddWithValue("Mtrach_cs",ddl_trach.SelectedValue);
                    cmd.Parameters.AddWithValue("Mtrach_cs_cmt",tb_trach.Text);
                    cmd.Parameters.AddWithValue("Murine_cs",ddl_ur_cs.SelectedValue);
                    cmd.Parameters.AddWithValue("Murine_cs_cmt",tb_ur_cs.Text);
                    cmd.Parameters.AddWithValue("Murine_wbc",ddl_ur_wbc.SelectedValue);
                    cmd.Parameters.AddWithValue("Murine_ph", tb_ph.Text);
                    cmd.Parameters.AddWithValue("Murine_rm_cmt",tb_ur_rm.Text);

                    Int32 Affectedrows = cmd.ExecuteNonQuery();
                    if (Affectedrows != 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record inserted Successfully');", true);
                        fill_fever_grid();
                    }
                    sqlconn.Close();
                }
                else
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Enter uhid');", true);
                }
            }
            catch (Exception m)
            {
                Label l = new Label();
                l.Text = "<script>alert('" + m.Message + "')</script>";
                Form.Controls.Add(l);
            }
        }
    }
}