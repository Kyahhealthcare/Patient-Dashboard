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
    public partial class vitals : System.Web.UI.Page
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
                    //fill_form();
                    bind_grid();
                }
                else
                {
                    //uhid.Visible = false;
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

        protected void save_vitals(object sender, EventArgs e)
        {
            try
            {
                if (Session["uhid"]!=null)
                {
                    String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                    MySqlConnection sqlconn = new MySqlConnection(con);

                    sqlconn.Open();
                    String d = Convert.ToDateTime(tb_date.Text).ToString("yyyy-MM-dd");
                    String t = Convert.ToDateTime(tb_time.Text).ToString("hh:mm:ss");

                    string query2 = "SELECT * FROM vital_details where uhid= '" + Session["uhid"].ToString() + "' and date='" + d + "' and time='"+t+"' ";
                    MySqlCommand cmd3 = new MySqlCommand(query2, sqlconn);
                    DataTable dt2 = new DataTable();
                    dt2.Load(cmd3.ExecuteReader());

                    String pname = "sp_vital_details";
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
                    cmd.Parameters.AddWithValue("Mtime", tb_time.Text);
                    cmd.Parameters.AddWithValue("Mrr", tb_rr.Text);
                    cmd.Parameters.AddWithValue("Mspo2", tb_spo2.Text);
                    cmd.Parameters.AddWithValue("Mpulse", tb_pulse.Text);
                    cmd.Parameters.AddWithValue("Mtemp", tb_temp.Text);
                    cmd.Parameters.AddWithValue("Mbp", tb_bp.Text);
                    cmd.Parameters.AddWithValue("Micp", tb_icp.Text);
                    cmd.Parameters.AddWithValue("Mrpupil", rbl_p_right.SelectedValue);
                    cmd.Parameters.AddWithValue("Mlpupil", rbl_p_left.SelectedValue);

                    Int32 Affectedrows = cmd.ExecuteNonQuery();
                    if (Affectedrows != 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record inserted Successfully');", true);
                        bind_grid();
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

        void bind_grid()
        {
            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();

            String pname = "sp_vital_details";
            MySqlCommand cmd = new MySqlCommand(pname, sqlconn);
            cmd.Parameters.AddWithValue("Maction", "SELECT");
            cmd.Parameters.AddWithValue("Muhid", Session["uhid"].ToString());
            cmd.Parameters.AddWithValue("Mdate", "");
            cmd.Parameters.AddWithValue("Mtime", "");
            cmd.Parameters.AddWithValue("Mrr", "");
            cmd.Parameters.AddWithValue("Mspo2", "");
            cmd.Parameters.AddWithValue("Mpulse", "");
            cmd.Parameters.AddWithValue("Mtemp", "");
            cmd.Parameters.AddWithValue("Mbp", "");
            cmd.Parameters.AddWithValue("Micp", "");
            cmd.Parameters.AddWithValue("Mrpupil", "");
            cmd.Parameters.AddWithValue("Mlpupil", "");

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

       
    }
}