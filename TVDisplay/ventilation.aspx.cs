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
    public partial class ventilation : System.Web.UI.Page
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

        void fill_form()
        {
            try
            {
                String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                MySqlConnection sqlconn = new MySqlConnection(con);
                sqlconn.Open();

                string query = "SELECT * FROM ventilation_details where uhid= '" + Session["uhid"].ToString() + "' ";
                MySqlCommand cmd = new MySqlCommand(query, sqlconn);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                if (dt.Rows.Count != 0)
                {
                    ddl_vent_mode.SelectedValue = dt.Rows[0]["mode"].ToString();
                    ddl_trach.SelectedValue = dt.Rows[0]["trach"].ToString();
                    ddl_intubated.SelectedValue = dt.Rows[0]["intubated"].ToString();
                    ddl_sedation.SelectedValue = dt.Rows[0]["sedation"].ToString();
                    tb_fio.Text = dt.Rows[0]["fio2"].ToString();
                    tb_pres.Text = dt.Rows[0]["pressure"].ToString();
                }
            }
            catch(Exception m)
            { }
        }
        protected void Save_venti(object sender, EventArgs e)
        {
            try
            {
                if (Session["uhid"].ToString() != "")
                {
                    String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                    MySqlConnection sqlconn = new MySqlConnection(con);

                    sqlconn.Open();
                    

                    string query2 = "SELECT * FROM ventilation_details where uhid= '" + Session["uhid"].ToString() + "' ";
                    MySqlCommand cmd3 = new MySqlCommand(query2, sqlconn);
                    DataTable dt2 = new DataTable();
                    dt2.Load(cmd3.ExecuteReader());

                    String pname = "sp_ventilation_details";
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
                    cmd.Parameters.AddWithValue("Mmode",ddl_vent_mode.SelectedValue);
                    cmd.Parameters.AddWithValue("Mtrach",ddl_trach.SelectedValue);
                    cmd.Parameters.AddWithValue("Mintubated",ddl_intubated.SelectedValue);
                    cmd.Parameters.AddWithValue("Msedation",ddl_sedation.SelectedValue);
                    cmd.Parameters.AddWithValue("Mfio2",tb_fio.Text);
                    cmd.Parameters.AddWithValue("Mpressure",tb_pres.Text);


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

        protected void venti_intu(object sender, EventArgs e)
        {
            if (ddl_intubated.SelectedValue=="Yes")
            {
                ddl_trach.SelectedValue = "No";
            }
        }

        protected void venti_trach(object sender, EventArgs e)
        {
            if (ddl_trach.SelectedValue == "Yes")
            {
                ddl_intubated.SelectedValue = "No";
            }
        }
    }
}