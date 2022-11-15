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
    public partial class lab : System.Web.UI.Page
    {
        public static string ret = "";
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

        protected void Add_hb(object sender, EventArgs e)
        {
            try
            {
                if (Session["uhid"].ToString() != "")
                {
                    String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                    MySqlConnection sqlconn = new MySqlConnection(con);

                    sqlconn.Open();
                    String d = Convert.ToDateTime(tb_hb_date.Text).ToString("yyyy-MM-dd");

                    string query2 = "SELECT * FROM lab_details where uhid= '" + Session["uhid"].ToString() + "' and date='" + d + "' and test_name='HB' ";
                    MySqlCommand cmd3 = new MySqlCommand(query2, sqlconn);
                    DataTable dt2 = new DataTable();
                    dt2.Load(cmd3.ExecuteReader());

                    String pname = "sp_lab_details";
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
                    cmd.Parameters.AddWithValue("Mtest_name", "HB");
                    cmd.Parameters.AddWithValue("Mresult", tb_hb.Text);
                    cmd.Parameters.AddWithValue("Mdate", Convert.ToDateTime(tb_hb_date.Text));
                    cmd.Parameters.AddWithValue("Mtime", tb_hb_time.Text);

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
            }
            catch (Exception m)
            {
                Label l = new Label();
                l.Text = "<script>alert('" + m.Message + "')</script>";
                Form.Controls.Add(l);
            }
        }
        protected void Add_tlc(object sender, EventArgs e)
        {
            try
            {
                if (Session["uhid"].ToString() != "")
                {
                    String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                    MySqlConnection sqlconn = new MySqlConnection(con);

                    sqlconn.Open();
                    String d = Convert.ToDateTime(tb_tlc_date.Text).ToString("yyyy-MM-dd");

                    string query2 = "SELECT * FROM lab_details where uhid= '" + Session["uhid"].ToString() + "' and date='" + d + "' and test_name='TLC' ";
                    MySqlCommand cmd3 = new MySqlCommand(query2, sqlconn);
                    DataTable dt2 = new DataTable();
                    dt2.Load(cmd3.ExecuteReader());

                    String pname = "sp_lab_details";
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
                    cmd.Parameters.AddWithValue("Mtest_name", "TLC");
                    cmd.Parameters.AddWithValue("Mresult", tb_tlc.Text);
                    cmd.Parameters.AddWithValue("Mdate", Convert.ToDateTime(tb_tlc_date.Text));
                    cmd.Parameters.AddWithValue("Mtime", tb_tlc_time.Text);

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
            }
            catch (Exception m)
            {
                Label l = new Label();
                l.Text = "<script>alert('" + m.Message + "')</script>";
                Form.Controls.Add(l);
            }
        }
        protected void Add_fasting(object sender, EventArgs e)
        {
            try
            {
                if (Session["uhid"].ToString() != "")
                {
                    String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                    MySqlConnection sqlconn = new MySqlConnection(con);

                    sqlconn.Open();
                    String d = Convert.ToDateTime(tb_fasting_date.Text).ToString("yyyy-MM-dd");

                    string query2 = "SELECT * FROM lab_details where uhid= '" + Session["uhid"].ToString() + "' and date='" + d + "' and test_name='G_Fasting' ";
                    MySqlCommand cmd3 = new MySqlCommand(query2, sqlconn);
                    DataTable dt2 = new DataTable();
                    dt2.Load(cmd3.ExecuteReader());

                    String pname = "sp_lab_details";
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
                    cmd.Parameters.AddWithValue("Mtest_name", "G_Fasting");
                    cmd.Parameters.AddWithValue("Mresult", tb_fasting.Text );
                    cmd.Parameters.AddWithValue("Mdate", Convert.ToDateTime(tb_fasting_date.Text));
                    cmd.Parameters.AddWithValue("Mtime", tb_fasting_time.Text);

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
            }
            catch (Exception m)
            {
                Label l = new Label();
                l.Text = "<script>alert('" + m.Message + "')</script>";
                Form.Controls.Add(l);
            }
        }
        protected void Add_pp(object sender, EventArgs e)
        {
            try
            {
                if (Session["uhid"].ToString() != "")
                {
                    String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                    MySqlConnection sqlconn = new MySqlConnection(con);

                    sqlconn.Open();
                    String d = Convert.ToDateTime(tb_pp_date.Text).ToString("yyyy-MM-dd");

                    string query2 = "SELECT * FROM lab_details where uhid= '" + Session["uhid"].ToString() + "' and date='" + d + "' and test_name='G_pp' ";
                    MySqlCommand cmd3 = new MySqlCommand(query2, sqlconn);
                    DataTable dt2 = new DataTable();
                    dt2.Load(cmd3.ExecuteReader());

                    String pname = "sp_lab_details";
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
                    cmd.Parameters.AddWithValue("Mtest_name", "G_pp");
                    cmd.Parameters.AddWithValue("Mresult", tb_pp.Text);
                    cmd.Parameters.AddWithValue("Mdate", Convert.ToDateTime(tb_pp_date.Text));
                    cmd.Parameters.AddWithValue("Mtime", tb_pp_time.Text);

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
            }
            catch (Exception m)
            {
                Label l = new Label();
                l.Text = "<script>alert('" + m.Message + "')</script>";
                Form.Controls.Add(l);
            }
        }
        protected void Add_urea(object sender, EventArgs e)
        {
            try
            {
                if (Session["uhid"].ToString() != "")
                {
                    String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                    MySqlConnection sqlconn = new MySqlConnection(con);

                    sqlconn.Open();
                    String d = Convert.ToDateTime(tb_urea_date.Text).ToString("yyyy-MM-dd");

                    string query2 = "SELECT * FROM lab_details where uhid= '" + Session["uhid"].ToString() + "' and date='" + d + "' and test_name='Urea' ";
                    MySqlCommand cmd3 = new MySqlCommand(query2, sqlconn);
                    DataTable dt2 = new DataTable();
                    dt2.Load(cmd3.ExecuteReader());

                    String pname = "sp_lab_details";
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
                    cmd.Parameters.AddWithValue("Mtest_name", "Urea");
                    cmd.Parameters.AddWithValue("Mresult", tb_urea.Text);
                    cmd.Parameters.AddWithValue("Mdate", Convert.ToDateTime(tb_urea_date.Text));
                    cmd.Parameters.AddWithValue("Mtime", tb_urea_time.Text);

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
            }
            catch (Exception m)
            {
                Label l = new Label();
                l.Text = "<script>alert('" + m.Message + "')</script>";
                Form.Controls.Add(l);
            }
        }
        protected void Add_creat(object sender, EventArgs e)
        {
            try
            {
                if (Session["uhid"].ToString() != "")
                {
                    String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                    MySqlConnection sqlconn = new MySqlConnection(con);

                    sqlconn.Open();
                    String d = Convert.ToDateTime(tb_creat_date.Text).ToString("yyyy-MM-dd");

                    string query2 = "SELECT * FROM lab_details where uhid= '" + Session["uhid"].ToString() + "' and date='" + d + "' and test_name='Creatinine' ";
                    MySqlCommand cmd3 = new MySqlCommand(query2, sqlconn);
                    DataTable dt2 = new DataTable();
                    dt2.Load(cmd3.ExecuteReader());

                    String pname = "sp_lab_details";
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
                    cmd.Parameters.AddWithValue("Mtest_name", "Creatinine");
                    cmd.Parameters.AddWithValue("Mresult", tb_creat.Text);
                    cmd.Parameters.AddWithValue("Mdate", Convert.ToDateTime(tb_creat_date.Text));
                    cmd.Parameters.AddWithValue("Mtime", tb_creat_time.Text);

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
            }
            catch (Exception m)
            {
                Label l = new Label();
                l.Text = "<script>alert('" + m.Message + "')</script>";
                Form.Controls.Add(l);
            }
        }
        protected void Add_na(object sender, EventArgs e)
        {
            try
            {
                if (Session["uhid"].ToString() != "")
                {
                    String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                    MySqlConnection sqlconn = new MySqlConnection(con);

                    sqlconn.Open();
                    String d = Convert.ToDateTime(tb_na_date.Text).ToString("yyyy-MM-dd");

                    string query2 = "SELECT * FROM lab_details where uhid= '" + Session["uhid"].ToString() + "' and date='" + d + "' and test_name='NA' ";
                    MySqlCommand cmd3 = new MySqlCommand(query2, sqlconn);
                    DataTable dt2 = new DataTable();
                    dt2.Load(cmd3.ExecuteReader());

                    String pname = "sp_lab_details";
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
                    cmd.Parameters.AddWithValue("Mtest_name", "NA");
                    cmd.Parameters.AddWithValue("Mresult", tb_na.Text);
                    cmd.Parameters.AddWithValue("Mdate", Convert.ToDateTime(tb_na_date.Text));
                    cmd.Parameters.AddWithValue("Mtime", tb_na_time.Text);

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
            }
            catch (Exception m)
            {
                Label l = new Label();
                l.Text = "<script>alert('" + m.Message + "')</script>";
                Form.Controls.Add(l);
            }
        }
        protected void Add_k(object sender, EventArgs e)
        {
            try
            {
                if (Session["uhid"].ToString() != "")
                {
                    String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                    MySqlConnection sqlconn = new MySqlConnection(con);

                    sqlconn.Open();
                    String d = Convert.ToDateTime(tb_k_date.Text).ToString("yyyy-MM-dd");

                    string query2 = "SELECT * FROM lab_details where uhid= '" + Session["uhid"].ToString() + "' and date='" + d + "' and test_name='K' ";
                    MySqlCommand cmd3 = new MySqlCommand(query2, sqlconn);
                    DataTable dt2 = new DataTable();
                    dt2.Load(cmd3.ExecuteReader());

                    String pname = "sp_lab_details";
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
                    cmd.Parameters.AddWithValue("Mtest_name", "K");
                    cmd.Parameters.AddWithValue("Mresult", tb_k.Text);
                    cmd.Parameters.AddWithValue("Mdate", Convert.ToDateTime(tb_k_date.Text));
                    cmd.Parameters.AddWithValue("Mtime", tb_k_time.Text);

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
            }
            catch (Exception m)
            {
                Label l = new Label();
                l.Text = "<script>alert('" + m.Message + "')</script>";
                Form.Controls.Add(l);
            }
        }
        protected void Add_wbc(object sender, EventArgs e)
        {
            try
            {
                if (Session["uhid"].ToString() != "")
                {
                    String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                    MySqlConnection sqlconn = new MySqlConnection(con);

                    sqlconn.Open();
                    String d = Convert.ToDateTime(tb_wbc_date.Text).ToString("yyyy-MM-dd");

                    string query2 = "SELECT * FROM lab_details where uhid= '" + Session["uhid"].ToString() + "' and date='" + d + "' and test_name='CSF_WBC' ";
                    MySqlCommand cmd3 = new MySqlCommand(query2, sqlconn);
                    DataTable dt2 = new DataTable();
                    dt2.Load(cmd3.ExecuteReader());

                    String pname = "sp_lab_details";
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
                    cmd.Parameters.AddWithValue("Mtest_name", "CSF_WBC");
                    cmd.Parameters.AddWithValue("Mresult", tb_wbc.Text);
                    cmd.Parameters.AddWithValue("Mdate", Convert.ToDateTime(tb_wbc_date.Text));
                    cmd.Parameters.AddWithValue("Mtime", tb_wbc_time.Text);

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
            }
            catch (Exception m)
            {
                Label l = new Label();
                l.Text = "<script>alert('" + m.Message + "')</script>";
                Form.Controls.Add(l);
            }
        }
        protected void Add_rbc(object sender, EventArgs e)
        {
            try
            {
                if (Session["uhid"].ToString() != "")
                {
                    String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                    MySqlConnection sqlconn = new MySqlConnection(con);

                    sqlconn.Open();
                    String d = Convert.ToDateTime(tb_rbc_date.Text).ToString("yyyy-MM-dd");

                    string query2 = "SELECT * FROM lab_details where uhid= '" + Session["uhid"].ToString() + "' and date='" + d + "' and test_name='CSF_RBC' ";
                    MySqlCommand cmd3 = new MySqlCommand(query2, sqlconn);
                    DataTable dt2 = new DataTable();
                    dt2.Load(cmd3.ExecuteReader());

                    String pname = "sp_lab_details";
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
                    cmd.Parameters.AddWithValue("Mtest_name", "CSF_RBC");
                    cmd.Parameters.AddWithValue("Mresult", tb_rbc.Text);
                    cmd.Parameters.AddWithValue("Mdate", Convert.ToDateTime(tb_rbc_date.Text));
                    cmd.Parameters.AddWithValue("Mtime", tb_rbc_time.Text);

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
            }
            catch (Exception m)
            {
                Label l = new Label();
                l.Text = "<script>alert('" + m.Message + "')</script>";
                Form.Controls.Add(l);
            }
        }
        protected void Add_csf_sugar(object sender, EventArgs e)
        {
            try
            {
                if (Session["uhid"].ToString() != "")
                {
                    String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                    MySqlConnection sqlconn = new MySqlConnection(con);

                    sqlconn.Open();
                    String d = Convert.ToDateTime(tb_csf_sugar_date.Text).ToString("yyyy-MM-dd");

                    string query2 = "SELECT * FROM lab_details where uhid= '" + Session["uhid"].ToString() + "' and date='" + d + "' and test_name='CSF_Sugar' ";
                    MySqlCommand cmd3 = new MySqlCommand(query2, sqlconn);
                    DataTable dt2 = new DataTable();
                    dt2.Load(cmd3.ExecuteReader());

                    String pname = "sp_lab_details";
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
                    cmd.Parameters.AddWithValue("Mtest_name", "CSF_SUGAR");
                    cmd.Parameters.AddWithValue("Mresult", tb_csf_sugar.Text);
                    cmd.Parameters.AddWithValue("Mdate", Convert.ToDateTime(tb_csf_sugar_date.Text));
                    cmd.Parameters.AddWithValue("Mtime", tb_csf_sugar_time.Text);

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
            }
            catch (Exception m)
            {
                Label l = new Label();
                l.Text = "<script>alert('" + m.Message + "')</script>";
                Form.Controls.Add(l);
            }
        }
        protected void Add_platelets(object sender, EventArgs e)
        {
            try
            {
                if (Session["uhid"].ToString() != "")
                {
                    String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                    MySqlConnection sqlconn = new MySqlConnection(con);

                    sqlconn.Open();
                    String d = Convert.ToDateTime(tb_platelets_date.Text).ToString("yyyy-MM-dd");

                    string query2 = "SELECT * FROM lab_details where uhid= '" + Session["uhid"].ToString() + "' and date='" + d + "' and test_name='PLATELETS' ";
                    MySqlCommand cmd3 = new MySqlCommand(query2, sqlconn);
                    DataTable dt2 = new DataTable();
                    dt2.Load(cmd3.ExecuteReader());

                    String pname = "sp_lab_details";
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
                    cmd.Parameters.AddWithValue("Mtest_name", "PLATELETS");
                    cmd.Parameters.AddWithValue("Mresult", tb_platelets.Text);
                    cmd.Parameters.AddWithValue("Mdate", Convert.ToDateTime(tb_platelets_date.Text));
                    cmd.Parameters.AddWithValue("Mtime", tb_platelets_time.Text);

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
            }
            catch (Exception m)
            {
                Label l = new Label();
                l.Text = "<script>alert('" + m.Message + "')</script>";
                Form.Controls.Add(l);
            }
        }
        protected void Add_ptinr(object sender, EventArgs e)
        {
            try
            {
                if (Session["uhid"].ToString() != "")
                {
                    String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                    MySqlConnection sqlconn = new MySqlConnection(con);

                    sqlconn.Open();
                    String d = Convert.ToDateTime(tb_ptinr_date.Text).ToString("yyyy-MM-dd");

                    string query2 = "SELECT * FROM lab_details where uhid= '" + Session["uhid"].ToString() + "' and date='" + d + "' and test_name='PT_INR' ";
                    MySqlCommand cmd3 = new MySqlCommand(query2, sqlconn);
                    DataTable dt2 = new DataTable();
                    dt2.Load(cmd3.ExecuteReader());

                    String pname = "sp_lab_details";
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
                    cmd.Parameters.AddWithValue("Mtest_name", "PT_INR");
                    cmd.Parameters.AddWithValue("Mresult", tb_ptinr.Text);
                    cmd.Parameters.AddWithValue("Mdate", Convert.ToDateTime(tb_ptinr_date.Text));
                    cmd.Parameters.AddWithValue("Mtime", tb_ptinr_time.Text);

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
            }
            catch (Exception m)
            {
                Label l = new Label();
                l.Text = "<script>alert('" + m.Message + "')</script>";
                Form.Controls.Add(l);
            }
        }
        protected void image_close(object sender, EventArgs e)
        {
            mpe1.Hide();
        }

        protected void mpe_HB(object sender, EventArgs e)
        {
            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();

            String pname = "sp_lab_details";
            MySqlCommand cmd = new MySqlCommand(pname, sqlconn);
            cmd.Parameters.AddWithValue("Maction", "SELECT_HB");
            cmd.Parameters.AddWithValue("Muhid", Session["uhid"].ToString());
            cmd.Parameters.AddWithValue("Mtest_name", "");
            cmd.Parameters.AddWithValue("Mresult", "");
            cmd.Parameters.AddWithValue("Mdate", "");
            cmd.Parameters.AddWithValue("Mtime", "");
            cmd.CommandType = CommandType.StoredProcedure;

            using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
            {
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);

                    BoundField HB = new BoundField();
                    HB.DataField = "HB";
                    HB.HeaderText = "HB";
                    gv1.Columns.Insert(0, HB);

                    gv1.DataSource = dt;
                    gv1.DataBind();
                    image_Panel1.Visible = true;
                    mpe1.Show();
                }
            }
            sqlconn.Close();
        }
        protected void mpe_tlc(object sender, EventArgs e)
        {
            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();

            String pname = "sp_lab_details";
            MySqlCommand cmd = new MySqlCommand(pname, sqlconn);
            cmd.Parameters.AddWithValue("Maction", "SELECT_TLC");
            cmd.Parameters.AddWithValue("Muhid", Session["uhid"].ToString());
            cmd.Parameters.AddWithValue("Mtest_name", "");
            cmd.Parameters.AddWithValue("Mresult", "");
            cmd.Parameters.AddWithValue("Mdate", "");
            cmd.Parameters.AddWithValue("Mtime", "");
            cmd.CommandType = CommandType.StoredProcedure;

            using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
            {
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);

                    BoundField TLC = new BoundField();
                    TLC.DataField = "TLC";
                    TLC.HeaderText = "TLC";
                    gv1.Columns.Insert(0, TLC);

                    gv1.DataSource = dt;
                    gv1.DataBind();
                    image_Panel1.Visible = true;
                    mpe1.Show();
                }
            }
            sqlconn.Close();
        }
        protected void mpe_fasting(object sender, EventArgs e)
        {
            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();

            String pname = "sp_lab_details";
            MySqlCommand cmd = new MySqlCommand(pname, sqlconn);
            cmd.Parameters.AddWithValue("Maction", "SELECT_FAST");
            cmd.Parameters.AddWithValue("Muhid", Session["uhid"].ToString());
            cmd.Parameters.AddWithValue("Mtest_name", "");
            cmd.Parameters.AddWithValue("Mresult", "");
            cmd.Parameters.AddWithValue("Mdate", "");
            cmd.Parameters.AddWithValue("Mtime", "");
            cmd.CommandType = CommandType.StoredProcedure;

            using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
            {
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);

                    BoundField FAST = new BoundField();
                    FAST.DataField = "G_Fasting";
                    FAST.HeaderText = "G_Fasting";
                    gv1.Columns.Insert(0, FAST);

                    gv1.DataSource = dt;
                    gv1.DataBind();
                    image_Panel1.Visible = true;
                    mpe1.Show();
                }
            }
            sqlconn.Close();
        }
        protected void mpe_pp(object sender, EventArgs e)
        {
            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();

            String pname = "sp_lab_details";
            MySqlCommand cmd = new MySqlCommand(pname, sqlconn);
            cmd.Parameters.AddWithValue("Maction", "SELECT_PP");
            cmd.Parameters.AddWithValue("Muhid", Session["uhid"].ToString());
            cmd.Parameters.AddWithValue("Mtest_name", "");
            cmd.Parameters.AddWithValue("Mresult", "");
            cmd.Parameters.AddWithValue("Mdate", "");
            cmd.Parameters.AddWithValue("Mtime", "");
            cmd.CommandType = CommandType.StoredProcedure;

            using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
            {
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);

                    BoundField PP = new BoundField();
                    PP.DataField = "G_PP";
                    PP.HeaderText = "G_PP";
                    gv1.Columns.Insert(0, PP);

                    gv1.DataSource = dt;
                    gv1.DataBind();
                    image_Panel1.Visible = true;
                    mpe1.Show();
                }
            }
            sqlconn.Close();
        }
        protected void mpe_urea(object sender, EventArgs e)
        {
            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();

            String pname = "sp_lab_details";
            MySqlCommand cmd = new MySqlCommand(pname, sqlconn);
            cmd.Parameters.AddWithValue("Maction", "SELECT_Urea");
            cmd.Parameters.AddWithValue("Muhid", Session["uhid"].ToString());
            cmd.Parameters.AddWithValue("Mtest_name", "");
            cmd.Parameters.AddWithValue("Mresult", "");
            cmd.Parameters.AddWithValue("Mdate", "");
            cmd.Parameters.AddWithValue("Mtime", "");
            cmd.CommandType = CommandType.StoredProcedure;

            using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
            {
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);

                    BoundField Urea = new BoundField();
                    Urea.DataField = "Urea";
                    Urea.HeaderText = "Urea";
                    gv1.Columns.Insert(0, Urea);

                    gv1.DataSource = dt;
                    gv1.DataBind();
                    image_Panel1.Visible = true;
                    mpe1.Show();
                }
            }
            sqlconn.Close();
        }
        protected void mpe_creat(object sender, EventArgs e)
        {
            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();

            String pname = "sp_lab_details";
            MySqlCommand cmd = new MySqlCommand(pname, sqlconn);
            cmd.Parameters.AddWithValue("Maction", "SELECT_Create");
            cmd.Parameters.AddWithValue("Muhid", Session["uhid"].ToString());
            cmd.Parameters.AddWithValue("Mtest_name", "");
            cmd.Parameters.AddWithValue("Mresult", "");
            cmd.Parameters.AddWithValue("Mdate", "");
            cmd.Parameters.AddWithValue("Mtime", "");
            cmd.CommandType = CommandType.StoredProcedure;

            using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
            {
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);

                    BoundField Creatinine = new BoundField();
                    Creatinine.DataField = "Creatinine";
                    Creatinine.HeaderText = "Creatinine";
                    gv1.Columns.Insert(0, Creatinine);

                    gv1.DataSource = dt;
                    gv1.DataBind();
                    image_Panel1.Visible = true;
                    mpe1.Show();
                }
            }
            sqlconn.Close();
        }
        protected void mpe_na(object sender, EventArgs e)
        {
            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();

            String pname = "sp_lab_details";
            MySqlCommand cmd = new MySqlCommand(pname, sqlconn);
            cmd.Parameters.AddWithValue("Maction", "SELECT_NA");
            cmd.Parameters.AddWithValue("Muhid", Session["uhid"].ToString());
            cmd.Parameters.AddWithValue("Mtest_name", "");
            cmd.Parameters.AddWithValue("Mresult", "");
            cmd.Parameters.AddWithValue("Mdate", "");
            cmd.Parameters.AddWithValue("Mtime", "");
            cmd.CommandType = CommandType.StoredProcedure;

            using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
            {
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);

                    BoundField NA = new BoundField();
                    NA.DataField = "NA";
                    NA.HeaderText = "NA";
                    gv1.Columns.Insert(0, NA);

                    gv1.DataSource = dt;
                    gv1.DataBind();
                    image_Panel1.Visible = true;
                    mpe1.Show();
                }
            }
            sqlconn.Close();
        }
        protected void mpe_k(object sender, EventArgs e)
        {
            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();

            String pname = "sp_lab_details";
            MySqlCommand cmd = new MySqlCommand(pname, sqlconn);
            cmd.Parameters.AddWithValue("Maction", "SELECT_K");
            cmd.Parameters.AddWithValue("Muhid", Session["uhid"].ToString());
            cmd.Parameters.AddWithValue("Mtest_name", "");
            cmd.Parameters.AddWithValue("Mresult", "");
            cmd.Parameters.AddWithValue("Mdate", "");
            cmd.Parameters.AddWithValue("Mtime", "");
            cmd.CommandType = CommandType.StoredProcedure;

            using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
            {
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);

                    BoundField K = new BoundField();
                    K.DataField = "K";
                    K.HeaderText = "K";
                    gv1.Columns.Insert(0, K);

                    gv1.DataSource = dt;
                    gv1.DataBind();
                    image_Panel1.Visible = true;
                    mpe1.Show();
                }
            }
            sqlconn.Close();
        }
        protected void mpe_wbc(object sender, EventArgs e)
        {
            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();

            String pname = "sp_lab_details";
            MySqlCommand cmd = new MySqlCommand(pname, sqlconn);
            cmd.Parameters.AddWithValue("Maction", "SELECT_WBC");
            cmd.Parameters.AddWithValue("Muhid", Session["uhid"].ToString());
            cmd.Parameters.AddWithValue("Mtest_name", "");
            cmd.Parameters.AddWithValue("Mresult", "");
            cmd.Parameters.AddWithValue("Mdate", "");
            cmd.Parameters.AddWithValue("Mtime", "");
            cmd.CommandType = CommandType.StoredProcedure;

            using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
            {
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);

                    BoundField WBC = new BoundField();
                    WBC.DataField = "CSF_WBC";
                    WBC.HeaderText = "CSF_WBC";
                    gv1.Columns.Insert(0, WBC);

                    gv1.DataSource = dt;
                    gv1.DataBind();
                    image_Panel1.Visible = true;
                    mpe1.Show();
                }
            }
            sqlconn.Close();
        }
        protected void mpe_rbc(object sender, EventArgs e)
        {
            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();

            String pname = "sp_lab_details";
            MySqlCommand cmd = new MySqlCommand(pname, sqlconn);
            cmd.Parameters.AddWithValue("Maction", "SELECT_RBC");
            cmd.Parameters.AddWithValue("Muhid", Session["uhid"].ToString());
            cmd.Parameters.AddWithValue("Mtest_name", "");
            cmd.Parameters.AddWithValue("Mresult", "");
            cmd.Parameters.AddWithValue("Mdate", "");
            cmd.Parameters.AddWithValue("Mtime", "");
            cmd.CommandType = CommandType.StoredProcedure;

            using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
            {
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);

                    BoundField RBC = new BoundField();
                    RBC.DataField = "CSF_RBC";
                    RBC.HeaderText = "CSF_RBC";
                    gv1.Columns.Insert(0, RBC);

                    gv1.DataSource = dt;
                    gv1.DataBind();
                    image_Panel1.Visible = true;
                    mpe1.Show();
                }
            }
            sqlconn.Close();
        }
        protected void mpe_csf_sugar(object sender, EventArgs e)
        {
            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();

            String pname = "sp_lab_details";
            MySqlCommand cmd = new MySqlCommand(pname, sqlconn);
            cmd.Parameters.AddWithValue("Maction", "SELECT_CSF_SUGAR");
            cmd.Parameters.AddWithValue("Muhid", Session["uhid"].ToString());
            cmd.Parameters.AddWithValue("Mtest_name", "");
            cmd.Parameters.AddWithValue("Mresult", "");
            cmd.Parameters.AddWithValue("Mdate", "");
            cmd.Parameters.AddWithValue("Mtime", "");
            cmd.CommandType = CommandType.StoredProcedure;

            using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
            {
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);

                    BoundField CSF_SUGAR = new BoundField();
                    CSF_SUGAR.DataField = "CSF_SUGAR";
                    CSF_SUGAR.HeaderText = "CSF_SUGAR";
                    gv1.Columns.Insert(0, CSF_SUGAR);

                    gv1.DataSource = dt;
                    gv1.DataBind();
                    image_Panel1.Visible = true;
                    mpe1.Show();
                }
            }
            sqlconn.Close();
        }

        protected void mpe_platelets(object sender, EventArgs e)
        {
            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();

            String pname = "sp_lab_details";
            MySqlCommand cmd = new MySqlCommand(pname, sqlconn);
            cmd.Parameters.AddWithValue("Maction", "SELECT_PLATELETS");
            cmd.Parameters.AddWithValue("Muhid", Session["uhid"].ToString());
            cmd.Parameters.AddWithValue("Mtest_name", "");
            cmd.Parameters.AddWithValue("Mresult", "");
            cmd.Parameters.AddWithValue("Mdate", "");
            cmd.Parameters.AddWithValue("Mtime", "");
            cmd.CommandType = CommandType.StoredProcedure;

            using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
            {
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);

                    BoundField RBC = new BoundField();
                    RBC.DataField = "PLATELETS";
                    RBC.HeaderText = "PLATELETS";
                    gv1.Columns.Insert(0, RBC);

                    gv1.DataSource = dt;
                    gv1.DataBind();
                    image_Panel1.Visible = true;
                    mpe1.Show();
                }
            }
            sqlconn.Close();
        }
        protected void mpe_ptinr(object sender, EventArgs e)
        {
            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();

            String pname = "sp_lab_details";
            MySqlCommand cmd = new MySqlCommand(pname, sqlconn);
            cmd.Parameters.AddWithValue("Maction", "SELECT_PT_INR");
            cmd.Parameters.AddWithValue("Muhid", Session["uhid"].ToString());
            cmd.Parameters.AddWithValue("Mtest_name", "");
            cmd.Parameters.AddWithValue("Mresult", "");
            cmd.Parameters.AddWithValue("Mdate", "");
            cmd.Parameters.AddWithValue("Mtime", "");
            cmd.CommandType = CommandType.StoredProcedure;

            using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
            {
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);

                    BoundField RBC = new BoundField();
                    RBC.DataField = "PT_INR";
                    RBC.HeaderText = "PT_INR";
                    gv1.Columns.Insert(0, RBC);

                    gv1.DataSource = dt;
                    gv1.DataBind();
                    image_Panel1.Visible = true;
                    mpe1.Show();
                }
            }
            sqlconn.Close();
        }
    }
}