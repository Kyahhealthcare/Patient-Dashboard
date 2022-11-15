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
    public partial class IO : System.Web.UI.Page
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
                    //l_uhid.Text = Session["uhid"].ToString();
                    fill_io();
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

        void fill_io()
        {
            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();

            String pname = "sp_last_io";
            MySqlCommand cmd = new MySqlCommand(pname, sqlconn);
            cmd.Parameters.AddWithValue("Maction", "SELECT");
            cmd.Parameters.AddWithValue("Mdate", "");
            cmd.Parameters.AddWithValue("Mi", "");
            cmd.Parameters.AddWithValue("Mo", "");
            cmd.Parameters.AddWithValue("Mdrain", "");
            cmd.Parameters.AddWithValue("Mdrain_comment", "");
            cmd.Parameters.AddWithValue("Muhid", Session["uhid"].ToString());
            cmd.CommandType = CommandType.StoredProcedure;

            using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
            {
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);
                    gv1.DataSource = dt;
                    gv1.DataBind();
                }
            }
            sqlconn.Close();

        }
        protected void gv_index_change(object sender, EventArgs e)
        {
            fill_io();
            tb_date.Text = gv1.SelectedRow.Cells[1].Text;
            if(gv1.SelectedRow.Cells[2].Text != "&nbsp;")
            {
                tb_i.Text = gv1.SelectedRow.Cells[2].Text;
            }
            if (gv1.SelectedRow.Cells[3].Text != "&nbsp;")
            {
                tb_o.Text = gv1.SelectedRow.Cells[3].Text;
            }
            if (gv1.SelectedRow.Cells[4].Text != "&nbsp;")
            {
                tb_drain.Text = gv1.SelectedRow.Cells[4].Text;
            }
            
            btn_save.Text = "Update";
        }
        protected void save_io(object sender, EventArgs e)
        {
            try
            {
                if (Session["uhid"] != null)
                {
                    String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                    MySqlConnection sqlconn = new MySqlConnection(con);

                    sqlconn.Open();
                    String d = Convert.ToDateTime(tb_date.Text).ToString("yyyy-MM-dd");
                    string query2 = "SELECT * FROM last_io where uhid= '" + Session["uhid"].ToString() + "' and date ='"+d+"'";
                    MySqlCommand cmd3 = new MySqlCommand(query2, sqlconn);
                    DataTable dt2 = new DataTable();
                    dt2.Load(cmd3.ExecuteReader());

                    String pname = "sp_last_io";
                    MySqlCommand cmd = new MySqlCommand(pname, sqlconn);

                    if (dt2.Rows.Count != 0)
                    {
                        cmd.Parameters.AddWithValue("Maction", "UPDATE");
                        cmd.Parameters.AddWithValue("Mdate", Convert.ToDateTime(tb_date.Text));
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("Maction", "INSERT");
                        cmd.Parameters.AddWithValue("Mdate", DateTime.Now);
                    }

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("Muhid", Session["uhid"].ToString());
                    cmd.Parameters.AddWithValue("Mi", tb_i.Text);
                    cmd.Parameters.AddWithValue("Mo", tb_o.Text);
                    cmd.Parameters.AddWithValue("Mdrain", tb_drain.Text);
                    cmd.Parameters.AddWithValue("Mdrain_comment", tb_drain_comment.Text);

                    Int32 Affectedrows = cmd.ExecuteNonQuery();
                    if (Affectedrows != 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record inserted Successfully');", true);
                        fill_io();
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

        
    }
}