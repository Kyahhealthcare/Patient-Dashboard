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
    public partial class surgery : System.Web.UI.Page
    {
        public static string fsurgeon1, fsurgeon2,sr1,sr2;
       
        protected void Page_Init(object sender, EventArgs e)
        {
            add_surgeon();
            add_sr();
           // fill_ot_d();

        }
        protected void Page_Load(object sender, EventArgs e)
        {          
            if (ddl_f_surgeon1.SelectedIndex != -1)
            {
                fsurgeon1 = ddl_f_surgeon1.SelectedItem.Value;
            }
            if (ddl_f_surgeon2.SelectedIndex != -1)
            {
                fsurgeon2 = ddl_f_surgeon2.SelectedItem.Value;
            }
            if (ddl_sr1.SelectedIndex != -1)
            {
                sr1 = ddl_sr1.SelectedItem.Value;
            }
            if (ddl_sr2.SelectedIndex != -1)
            {
                sr2 = ddl_sr2.SelectedItem.Value;
            }
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
                   fill_ot_d();
                }
                else
                {
                  //  uhid.Visible = false;
                }
            }
            else
            {
                add_surgeon();
            }
        }

        void fill_form()
        {
            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();

            String pname = "sp_surgery_details";
            MySqlCommand cmd = new MySqlCommand(pname, sqlconn);
            cmd.Parameters.AddWithValue("Maction", "SELECT");
            cmd.Parameters.AddWithValue("Muhid", Session["uhid"].ToString());
            cmd.Parameters.AddWithValue("Msurgeon1", "");
            cmd.Parameters.AddWithValue("Msurgeon2", "");
            cmd.Parameters.AddWithValue("Msr1", "");
            cmd.Parameters.AddWithValue("Msr2", "");
            cmd.Parameters.AddWithValue("Mdate", "");
            cmd.Parameters.AddWithValue("Msurgery_name", "");
            cmd.CommandType = CommandType.StoredProcedure;

            using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
            {
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);
                    dt.Columns.Add("pod", typeof(String));
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["date"].ToString() == "")
                        {
                            double days = (DateTime.Now - Convert.ToDateTime(row["date"])).TotalDays;
                            row["pod"] = Math.Ceiling(days) + " Days";
                        }
                        else
                        {
                            row["pod"] = "";
                        }
                    }
                    ViewState["dt"] = dt;
                    gv2.DataSource = dt;
                    gv2.DataBind();
                }
            }

            sqlconn.Close();
        }

        protected void gv_index_change(object sender, EventArgs e)
        {
            fill_ot_d();
            tb_dos.Text = ot_gv.SelectedRow.Cells[2].Text;
            ddl_f_surgeon1.SelectedValue = ot_gv.SelectedRow.Cells[3].Text;
            ddl_f_surgeon2.SelectedValue = ot_gv.SelectedRow.Cells[4].Text;
            tb_surgery_name.Text = ot_gv.SelectedRow.Cells[5].Text;
            //btn_save.Text = "Update";
        }
        void fill_ot_d()
        {
            String con = ConfigurationManager.ConnectionStrings["OT"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(con);
            String con1 = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn1 = new MySqlConnection(con1);

            sqlconn.Open();
            sqlconn1.Open();
            var select = "select  TCNO, SCDATE,SURGERY,surgeon1_id,surgeon2_id from ot_SURGERYINFO  where SPECIALITY='16' and TCNO='"+ Session["uhid"].ToString() + "'";
            // var select = "select * from ot_SURGERYINFO  where SPECIALITY='16' ";
            // var c = new SqlConnection(yourConnectionString); // Your Connection String here
            var select_faculty = "select username,id from faculty";

            var dataAdapter = new SqlDataAdapter(select, sqlconn);
            var commandBuilder = new SqlCommandBuilder(dataAdapter);

            var MydataAdapter = new MySqlDataAdapter(select_faculty, sqlconn1);
            var MycommandBuilder = new MySqlCommandBuilder(MydataAdapter);


            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            dt.Columns.Add("fac1", typeof(String));
            dt.Columns.Add("fac2", typeof(String));

            DataTable dt1 = new DataTable();
            MydataAdapter.Fill(dt1);


            foreach(DataRow dr in dt.Rows)
            {
                DataRow[] a = dt1.Select("id = '" + dr["surgeon1_id"] + "'");
                if (a.Length > 0)
                {
                    dr["fac1"] = a[0]["username"].ToString();
                }
                else
                {
                    dr["fac1"] = "";
                }
                
               
                DataRow[] b = dt1.Select("id = '" + dr["surgeon2_id"] + "'");

                if(b.Length > 0)
                {
                    dr["fac2"] = b[0]["username"].ToString();
                }
                else
                {
                    dr["fac2"] = "";
                }
                
            }

            ot_gv.DataSource = dt;
            ot_gv.DataBind();
            //  ot_gv.DataSource = ds.Tables[0];

            sqlconn1.Close();
            sqlconn.Close();
        }
        void add_surgeon()
        {
            if (Session["hid"] != null)
            {
               // this.myddl = new DropDownList();
                String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                MySqlConnection sqlconn = new MySqlConnection(con);

                sqlconn.Open();

                string query2 = "SELECT fname,lname,username FROM faculty where hid= '" + Session["hid"].ToString() + "' order by fname ";
                MySqlCommand cmd3 = new MySqlCommand(query2, sqlconn);
                DataTable dt2 = new DataTable();
                dt2.Load(cmd3.ExecuteReader());
                dt2.Columns.Add("doc", typeof(string), "'Dr.'+' '+fname+' '+lname+' '+username");

                ddl_f_surgeon1.DataSource = dt2;
                ddl_f_surgeon1.DataTextField = "doc";
                ddl_f_surgeon1.DataValueField = "username";
                ddl_f_surgeon1.DataBind();
                ddl_f_surgeon2.DataSource = dt2;
                ddl_f_surgeon2.DataTextField = "doc";
                ddl_f_surgeon2.DataValueField = "username";
                ddl_f_surgeon2.DataBind();

                ddl_f_surgeon1.Items.Insert(0, new ListItem("SELECT", " "));
                ddl_f_surgeon2.Items.Insert(0, new ListItem("SELECT", " "));

                sqlconn.Close();
            }
        }

        void add_sr()
        {
            if (Session["hid"] != null)
            {
                // this.myddl = new DropDownList();
                String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                MySqlConnection sqlconn = new MySqlConnection(con);

                sqlconn.Open();

                string query2 = "SELECT username FROM sr_list where hid= '" + Session["hid"].ToString() + "' order by username ";
                MySqlCommand cmd3 = new MySqlCommand(query2, sqlconn);
                DataTable dt2 = new DataTable();
                dt2.Load(cmd3.ExecuteReader());

                ddl_sr1.DataSource = dt2;
                ddl_sr1.DataTextField = "username";
                ddl_sr1.DataValueField = "username";
                ddl_sr1.DataBind();
                ddl_sr2.DataSource = dt2;
                ddl_sr2.DataTextField = "username";
                ddl_sr2.DataValueField = "username";
                ddl_sr2.DataBind();

                ddl_sr1.Items.Insert(0, new ListItem("SELECT", " "));
                ddl_sr2.Items.Insert(0, new ListItem("SELECT", " "));

                sqlconn.Close();
            }
        }
        void refresh()
        {
            tb_dos.Text = "";
            tb_surgery_name.Text = "";
            ddl_f_surgeon1.SelectedIndex = -1;
            ddl_f_surgeon2.SelectedIndex = -1;
            ddl_sr1.SelectedIndex = -1;
            ddl_sr2.SelectedIndex = -1;
        }
        protected override void InitializeCulture()
        {
            CultureInfo CI = new CultureInfo("pt-PT");
            CI.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";

            Thread.CurrentThread.CurrentCulture = CI;
            Thread.CurrentThread.CurrentUICulture = CI;
            base.InitializeCulture();
        }

        protected void save_surgery(object sender, EventArgs e)
        {
            try
            {
                if (Session["uhid"].ToString() != "")
                {
                    String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                    MySqlConnection sqlconn = new MySqlConnection(con);

                    sqlconn.Open();
                    String d = Convert.ToDateTime(tb_dos.Text).ToString("yyyy-MM-dd");

                    string query2 = "SELECT * FROM surgery_details where uhid= '" + Session["uhid"].ToString() + "' and date='" + d + "' ";
                    MySqlCommand cmd3 = new MySqlCommand(query2, sqlconn);
                    DataTable dt2 = new DataTable();
                    dt2.Load(cmd3.ExecuteReader());

                    String pname = "sp_surgery_details";
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
                    cmd.Parameters.AddWithValue("Msurgeon1", fsurgeon1);
                    cmd.Parameters.AddWithValue("Msurgeon2", fsurgeon2);
                    cmd.Parameters.AddWithValue("Msr1", sr1);
                    cmd.Parameters.AddWithValue("Msr2", sr2);
                    cmd.Parameters.AddWithValue("Mdate",Convert.ToDateTime(tb_dos.Text));
                    cmd.Parameters.AddWithValue("Msurgery_name",tb_surgery_name.Text);

                    Int32 Affectedrows = cmd.ExecuteNonQuery();
                    if (Affectedrows != 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record inserted Successfully');", true);
                        fill_form();
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

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string item = e.Row.Cells[3].Text;
                foreach (Button button in e.Row.Cells[4].Controls.OfType<Button>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
                    }
                }
            }
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           // fill_form();
            int index = Convert.ToInt32(e.RowIndex);

            DataTable dt = ViewState["dt"] as DataTable;

            //dt.Rows[index].Delete();

            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();
            string g= dt.Rows[index][1].ToString();
            //string g = gv2.Rows[index].Cells[0].ToString();

            String d = Convert.ToDateTime(g).ToString("yyyy-MM-dd");

            string query = "delete from surgery_details where uhid= '" + Session["uhid"].ToString() + "' and date='" + d + "'";
            MySqlCommand cmd = new MySqlCommand(query, sqlconn);
            //com = new SqlCommand(query, con);
            //com.Parameters.AddWithValue("@Id", SelectedId);
            cmd.ExecuteNonQuery();
            //dt.Rows[index].Delete();

            // ViewState["dt"] = dt;
            fill_form();
            sqlconn.Close();
        }


    }
}