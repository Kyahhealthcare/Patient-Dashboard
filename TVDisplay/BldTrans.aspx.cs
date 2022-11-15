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
    public partial class BldTrans : System.Web.UI.Page
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
                   // l_uhid.Text = Session["uhid"].ToString();
                   fill_grid();
                }
                else
                {
                   // uhid.Visible = false;
                }
            }
        }

        void fill_grid()
        {
            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();
           
            String pname = "sp_bld_transfusion_details";
            MySqlCommand cmd = new MySqlCommand(pname, sqlconn);
            cmd.Parameters.AddWithValue("Maction", "SELECT");
            cmd.Parameters.AddWithValue("Muhid", Session["uhid"].ToString());
            cmd.Parameters.AddWithValue("Mtype", "");
            cmd.Parameters.AddWithValue("Mquantity", "");
            cmd.Parameters.AddWithValue("Mblood_bag_no", "");
            cmd.Parameters.AddWithValue("Mdate_of_start", "");
            cmd.Parameters.AddWithValue("Mreaction", ""); 
            cmd.Parameters.AddWithValue("Mcompleted", "");
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
        protected void save_bld_trans(object sender, EventArgs e)
        {
            //try
            //{
                if (Session["uhid"]!=null)
                {
                    String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                    MySqlConnection sqlconn = new MySqlConnection(con);

                    sqlconn.Open();
                    String d = Convert.ToDateTime(tb_dos.Text).ToString("yyyy-MM-dd");

                    string query2 = "SELECT * FROM bld_transfusion_details where uhid= '" + Session["uhid"].ToString() + "' and date_of_start='" + d + "' and type='"+ddl_bld_trans.SelectedValue+"' ";
                    MySqlCommand cmd3 = new MySqlCommand(query2, sqlconn);
                    DataTable dt2 = new DataTable();
                    dt2.Load(cmd3.ExecuteReader());

                    String pname = "sp_bld_transfusion_details";
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
                    cmd.Parameters.AddWithValue("Mtype",ddl_bld_trans.SelectedValue);
                    cmd.Parameters.AddWithValue("Mquantity",tb_quan.Text);
                    cmd.Parameters.AddWithValue("Mblood_bag_no",tb_bld_bag.Text);
                    cmd.Parameters.AddWithValue("Mdate_of_start", Convert.ToDateTime(tb_dos.Text));
                    cmd.Parameters.AddWithValue("Mreaction",ddl_react.SelectedValue);
                    cmd.Parameters.AddWithValue("Mcompleted",ddl_comp.SelectedValue);

                    Int32 Affectedrows = cmd.ExecuteNonQuery();
                    if (Affectedrows != 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record inserted Successfully');", true);
                        fill_grid();
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