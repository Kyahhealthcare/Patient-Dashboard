using IdentityModel.Client;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public partial class issues : System.Web.UI.Page
    {
        private static string s1;
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
                    fill_issues();
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

        protected void save_issue(object sender, EventArgs e)
        {
            try
            {
                if (Session["uhid"].ToString() != "")
                {
                    String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                    MySqlConnection sqlconn = new MySqlConnection(con);

                    sqlconn.Open();
                    String d = Convert.ToDateTime(tb_sd1.Text).ToString("yyyy-MM-dd");

                    string query2 = "SELECT * FROM issue_details where uhid= '" + Session["uhid"].ToString() + "' and since_date='" + d + "' and issue='"+icd10.Text+"'";
                    MySqlCommand cmd3 = new MySqlCommand(query2, sqlconn);
                    DataTable dt2 = new DataTable();
                    dt2.Load(cmd3.ExecuteReader());

                    String pname = "sp_issue_details";
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
                    cmd.Parameters.AddWithValue("Missue", icd10.Text);
                    cmd.Parameters.AddWithValue("Msince_date", Convert.ToDateTime(tb_sd1.Text));
                    if(tb_td1.Text!="")
                    {
                        cmd.Parameters.AddWithValue("Mtill_date", Convert.ToDateTime(tb_td1.Text));
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("Mtill_date", null);
                    }

                    Int32 Affectedrows = cmd.ExecuteNonQuery();
                    if (Affectedrows != 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record inserted Successfully');", true);
                        fill_issues();
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


        void fill_issues()
        {
            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();

            String pname = "sp_issue_details";
            MySqlCommand cmd = new MySqlCommand(pname, sqlconn);
            cmd.Parameters.AddWithValue("Maction", "SELECT");
            cmd.Parameters.AddWithValue("Missue", "");
            cmd.Parameters.AddWithValue("Msince_date", "");
            cmd.Parameters.AddWithValue("Mtill_date", "");
            cmd.Parameters.AddWithValue("Muhid", Session["uhid"].ToString());
            cmd.CommandType = CommandType.StoredProcedure;

            using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
            {
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);
                    dt.Columns.Add("status", typeof(String));
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["till_date"].ToString() == "")
                        {
                            row["status"] = "Active";
                        }
                        else 
                        {
                            row["status"] = "Inactive";
                        }
                    }

                    gv1.DataSource = dt;
                    gv1.DataBind();
                }
            }
            sqlconn.Close();

        }

        
        protected void gv_index_change(object sender, EventArgs e)
        {
            fill_issues();
            icd10.Text = gv1.SelectedRow.Cells[1].Text;
            tb_sd1.Text = gv1.SelectedRow.Cells[3].Text;
            tb_td1.Text = gv1.SelectedRow.Cells[4].Text;
            btn_save.Text = "Update";
        }
    }
}