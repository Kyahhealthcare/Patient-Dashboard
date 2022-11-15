using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TVDisplay
{
    public partial class gcs : System.Web.UI.Page
    {
        string a = "0";
        string b = "0";
        string c = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] == null)
                {
                    Response.Redirect("Login.aspx");
                }

                // ward_change();
                InitializeCulture();
                if (Session["uhid"] != null)
                {
                    bind_grid();
                    //fill_gcs();
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
      
        protected void cal_gcs(object sender, EventArgs e)
        {
            if (rbl_e.SelectedIndex != -1)
            {
                a = rbl_e.SelectedValue.ToString();
            }
            if (rbl_v.SelectedIndex != -1)
            {
                b = rbl_v.SelectedValue.ToString();
            }
            if (rbl_m.SelectedIndex != -1)
            {
                c = rbl_m.SelectedValue.ToString();
            }
            int tot = Convert.ToInt32(a) + Convert.ToInt32(b) + Convert.ToInt32(c);
            lb_tot.Text = tot.ToString();


            if (cb_cry.Checked == true)
            {
                lb_tot.Text = "";
            }
            if (cb_spont.Checked == true)
            {
                lb_tot.Text = "";
            }
        }

        protected void t_checked(object sender, EventArgs e)
        {
            if (cb_t.Checked == true || cb_et.Checked == true)
            {
                rbl_v.SelectedValue = "1";
                rbl_v.Enabled = false;
                cal_gcs(sender, e);
            }
            else
            {
                rbl_v.Enabled = true;
            }
        }

        protected void save_gcs(object sender, EventArgs e)
        {
            try
            {
                if (Session["uhid"] != null)
                {
                    String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                    MySqlConnection sqlconn = new MySqlConnection(con);

                    sqlconn.Open();
                    String d = Convert.ToDateTime(tb_date.Text).ToString("yyyy-MM-dd");
                    String t = Convert.ToDateTime(tb_time.Text).ToString("hh:mm:ss");

                    string query2 = "SELECT * FROM gcs where uhid= '" + Session["uhid"].ToString() + "' and date='" + d + "' and time='" + t + "' ";
                    MySqlCommand cmd3 = new MySqlCommand(query2, sqlconn);
                    DataTable dt2 = new DataTable();
                    dt2.Load(cmd3.ExecuteReader());

                    String pname = "sp_gcs";
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
                    cmd.Parameters.AddWithValue("Me", rbl_e.SelectedValue);
                    cmd.Parameters.AddWithValue("Mv", rbl_v.SelectedValue);
                    cmd.Parameters.AddWithValue("Mm", rbl_m.SelectedValue);
                    if (cb_t.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("Mt", 1);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("Mt", 0);
                    }
                    if (cb_et.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("Met", 1);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("Met", 0);
                    }
                    if (cb_cry.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("Mcry", 1);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("Mcry", 0);
                    }
                    if (cb_spont.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("Mspont", 1);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("Mspont", 0);
                    }

                    cmd.Parameters.AddWithValue("Mtotal", lb_tot.Text);

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

            String pname = "sp_gcs";
            MySqlCommand cmd = new MySqlCommand(pname, sqlconn);
            cmd.Parameters.AddWithValue("Maction", "SELECT");
            cmd.Parameters.AddWithValue("Muhid", Session["uhid"].ToString());
            cmd.Parameters.AddWithValue("Mdate", "");
            cmd.Parameters.AddWithValue("Mtime", "");
            cmd.Parameters.AddWithValue("Me", "");
            cmd.Parameters.AddWithValue("Mv", "");
            cmd.Parameters.AddWithValue("Mm", "");
            cmd.Parameters.AddWithValue("Met", "");
            cmd.Parameters.AddWithValue("Mt", "");
            cmd.Parameters.AddWithValue("Mcry", "");
            cmd.Parameters.AddWithValue("Mspont", "");
            cmd.Parameters.AddWithValue("Mtotal", "");
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

        protected void cry_checked(object sender, EventArgs e)
        {
            if (cb_cry.Checked == true )
            {
                cb_t.Checked = false;
                cb_et.Checked = false;

                rbl_v.SelectedIndex = -1;
                rbl_v.Enabled = false;                
            }
            else
            {
                rbl_v.Enabled = true;
            }
        }

        protected void spont_checked(object sender, EventArgs e)
        {
            if (cb_spont.Checked == true)
            {
                rbl_m.SelectedIndex = -1;
                rbl_m.Enabled = false;
            }
            else
            {
                rbl_m.Enabled = true;
            }
        }
    }
}