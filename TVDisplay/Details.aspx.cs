using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TVDisplay
{
    public partial class Details : System.Web.UI.Page
    {
        public static string ward;
        public static string consultant;
        dataflow df = new dataflow();
        protected void Page_Init(object sender, EventArgs e)
        {
            ward_change();
            faculty();       
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ddl_ward.SelectedIndex != -1)
            {
                ward = ddl_ward.SelectedItem.Value;
            }
            if (ddl_faculty.SelectedIndex != -1)
            {
                consultant = ddl_faculty.SelectedItem.Value;
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
                    tb_uhid.Text = Session["uhid"].ToString();
                    get();
                }
                else
                {

                }
            }

        }
        protected void ward_change()
        {
            string constr = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT ward_name FROM ward_list"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    ddl_ward.DataSource = cmd.ExecuteReader();
                    ddl_ward.DataTextField = "ward_name";
                    ddl_ward.DataValueField = "ward_name";
                    ddl_ward.DataBind();
                    con.Close();
                }
            }
            ddl_ward.Items.Insert(0, new ListItem("--Select Ward--", "0"));

        }

        protected void faculty()
        {
            string constr = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT username FROM faculty"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    ddl_faculty.DataSource = cmd.ExecuteReader();
                    ddl_faculty.DataTextField = "username";
                    ddl_faculty.DataValueField = "username";
                    ddl_faculty.DataBind();
                    con.Close();
                }
            }
            ddl_faculty.Items.Insert(0, new ListItem("--Select Consultant--", ""));

        }

        protected override void InitializeCulture()
        {
            CultureInfo CI = new CultureInfo("pt-PT");
            CI.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";

            Thread.CurrentThread.CurrentCulture = CI;
            Thread.CurrentThread.CurrentUICulture = CI;
            base.InitializeCulture();
        }



        protected void right_click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("vitals.aspx");
        }
        protected void search_uhid(object sender, EventArgs e)
        {
            get();
        }
        void get()
        {
            //try
            //{
            if (tb_uhid.Text != "" || Session["uhid"] != null)
            {
                String con1 = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                // MySqlConnection sqlconn1 = new MySqlConnection("SERVER=sg2nlmysql23plsk.secureserver.net;PORT=3306;DATABASE=TVDisplay;UID=ph15073610681;PASSWORD=Aiims@123");

                MySqlConnection sqlconn1 = new MySqlConnection(con1);
                sqlconn1.Open();
                string query1 = "SELECT * FROM pt_details where uhid= '" + tb_uhid.Text + "'";
                MySqlCommand cmd21 = new MySqlCommand(query1, sqlconn1);
                DataTable dt21 = new DataTable();
                dt21.Load(cmd21.ExecuteReader());

                String con = ConfigurationManager.ConnectionStrings["neuro"].ConnectionString;
                SqlConnection sqlconn = new SqlConnection(con);
                sqlconn.Open();
                string query = "SELECT * FROM [NeuroTrauma].[dbo].[pt_details] where uhid= '" + tb_uhid.Text + "'";
                SqlCommand cmd2 = new SqlCommand(query, sqlconn);
                DataTable dt2 = new DataTable();
                dt2.Load(cmd2.ExecuteReader());


                DataTable pt_details1 = new DataTable();
                pt_details1 = df.get_pt_table("select * from patient_detail where reg_no='" + tb_uhid.Text + "'");
                //  pt_details = df.get_pt_table("select p_fname,p_lname,p_mname,p_sex,p_address,p_dob from patient_detail where reg_no='" + _uid + "'");


                if (dt21.Rows.Count != 0)
                {
                    Session["uhid"] = tb_uhid.Text;
                    fill_form1();

                    // uhid.Visible = true;
                    //l_uhid.Text = Session["uhid"].ToString();
                }
                else if (dt2.Rows.Count != 0)
                {
                    Session["uhid"] = tb_uhid.Text;
                    fill_form();

                    // uhid.Visible = true;
                    //l_uhid.Text = Session["uhid"].ToString();

                }
                else if (pt_details1.Rows.Count != 0)
                {
                    get_postgrate();
                }
                else
                {
                    string uh = tb_uhid.Text;
                    ClearControls(this);
                    tb_uhid.Text = uh;
                    //uhid.Visible = false;
                    //tb_uhid.Text = Session["uhid"].ToString();
                    Session["uhid"] = null;
                }
                sqlconn.Close();
                sqlconn1.Close();
            }
            else
            {
                Session["uhid"] = null;
                // refresh();
            }
            //}
            //catch (Exception m)
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('"+m.ToString()+"');", true);
            //}
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
        void fill_form1()
        {
            try
            {
                String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                MySqlConnection sqlconn = new MySqlConnection(con);
                sqlconn.Open();

                string query = "SELECT * FROM pt_details where uhid= '" + Session["uhid"].ToString() + "' ";
                MySqlCommand cmd = new MySqlCommand(query, sqlconn);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                if (dt.Rows.Count != 0)
                {
                    //tb_reg_time.Text = dt.Rows[0]["reg_time"].ToString();
                    // tb_uhid.Text = dt.Rows[0]["uhid"].ToString();
                    tb_fname.Text = dt.Rows[0]["fname"].ToString();
                    tb_lname.Text = dt.Rows[0]["lname"].ToString();
                    ddl_sex.SelectedValue = dt.Rows[0]["sex"].ToString();
                    //tb_dob.Text = Convert.ToDateTime(dt.Rows[0]["dob"]).ToString("dd-MM-yyyy");
                    if (dt.Rows[0]["date_admit"].ToString() != "")
                    {
                        tb_doa.Text = Convert.ToDateTime(dt.Rows[0]["date_admit"]).ToString("dd-MM-yyyy");
                    }
                    ddl_bld.SelectedValue = dt.Rows[0]["bld_grp"].ToString();
                    tb_bld_d.Text = dt.Rows[0]["bld_donated"].ToString();
                    tb_diag1.Text = dt.Rows[0]["diag1"].ToString();
                    tb_diag2.Text = dt.Rows[0]["diag2"].ToString();
                    tb_diag3.Text = dt.Rows[0]["diag3"].ToString();
                    ddl_faculty.SelectedValue= dt.Rows[0]["consultant"].ToString();
                    ddl_ward.SelectedValue = dt.Rows[0]["ward"].ToString();
                    //ddl_bed.SelectedValue = dt.Rows[0]["bed"].ToString();
                    tb_bed.Text = dt.Rows[0]["bed"].ToString();

                    int age;
                    DateTime _age = new DateTime();
                    _age = Convert.ToDateTime(dt.Rows[0]["dob"]);
                    age = DateTime.Now.Year - _age.Year;
                    if (DateTime.Now.DayOfYear < _age.DayOfYear)
                    {
                        age = age - 1;
                    }
                    tb_age.Text = age.ToString();
                }
                sqlconn.Close();
            }
            catch (Exception e)
            {

            }
        }
        void fill_form()
        {
            try
            {
                String con = ConfigurationManager.ConnectionStrings["neuro"].ConnectionString;
                SqlConnection sqlconn = new SqlConnection(con);
                sqlconn.Open();

                string query = "SELECT * FROM [NeuroTrauma].[dbo].[pt_details] where uhid= '" + Session["uhid"].ToString() + "' ";
                SqlCommand cmd = new SqlCommand(query, sqlconn);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                if (dt.Rows.Count != 0)
                {
                    //    tb_reg_time.Text = dt.Rows[0]["reg_time"].ToString();
                    tb_uhid.Text = dt.Rows[0]["uhid"].ToString();
                    tb_fname.Text = dt.Rows[0]["fname"].ToString();
                    tb_lname.Text = dt.Rows[0]["lname"].ToString();
                    ddl_sex.SelectedValue = dt.Rows[0]["gender"].ToString();
                    //tb_dob.Text = Convert.ToDateTime(dt.Rows[0]["dob"]).ToString("dd-MM-yyyy");

                    tb_doa.Text = Convert.ToDateTime(dt.Rows[0]["admit_date"]).ToString("dd-MM-yyyy");


                    int age;
                    DateTime _age = new DateTime();
                    _age = Convert.ToDateTime(dt.Rows[0]["dob"].ToString());
                    age = DateTime.Now.Year - _age.Year;
                    if (DateTime.Now.DayOfYear < _age.DayOfYear)
                    {
                        age = age - 1;
                    }
                    tb_age.Text = age.ToString();
                }
                sqlconn.Close();
            }
            catch (Exception e)
            {

            }

        }
        void get_postgrate()
        {
            try
            {
                DataTable pt_details1 = new DataTable();
                pt_details1 = df.get_pt_table("select * from patient_detail where reg_no='" + tb_uhid.Text + "'");
                //  pt_details = df.get_pt_table("select p_fname,p_lname,p_mname,p_sex,p_address,p_dob from patient_detail where reg_no='" + _uid + "'");
                if (pt_details1.Rows.Count != 0)
                {
                    // tb_uhid.Text = tb_search_uhid.Text;
                    tb_fname.Text = pt_details1.Rows[0]["p_fname"].ToString();
                    tb_lname.Text = pt_details1.Rows[0]["p_mname"].ToString() + ' ' + pt_details1.Rows[0]["p_lname"].ToString();
                    if (pt_details1.Rows[0]["p_sex"].ToString() == "1")
                    {
                        ddl_sex.SelectedValue = "M";
                    }
                    if (pt_details1.Rows[0]["p_sex"].ToString() == "2")
                    {
                        ddl_sex.SelectedValue = "F";
                    }
                    //  tb_mob.Text = pt_details1.Rows[0]["p_mobile_no"].ToString();
                    int age;
                    DateTime _age = new DateTime();
                    _age = Convert.ToDateTime(pt_details1.Rows[0]["p_dob"].ToString());
                    age = DateTime.Now.Year - _age.Year;
                    if (DateTime.Now.DayOfYear < _age.DayOfYear)
                    {
                        age = age - 1;
                    }
                    tb_age.Text = age.ToString();

                    if (pt_details1.Rows[0]["admission_date"].ToString() != "")
                    {
                        tb_doa.Text = Convert.ToDateTime(pt_details1.Rows[0]["admission_date"]).ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        tb_doa.Text = "";
                    }
                    string adr = pt_details1.Rows[0]["p_address"].ToString();

                    //tb_address.Text = adr.Trim().Replace('^', ' ');
                }

                else
                {
                    Label l = new Label();
                    l.Text = "<script>alert('no records were found!!')</script>";
                    Form.Controls.Add(l);
                    //refresh();
                    return;
                }
            }
            catch (Exception m)
            {
                Label l = new Label();
                l.Text = "<script>alert('" + m.Message + "')</script>";
                Form.Controls.Add(l);
            }
        }

        protected void save_form(object sender, EventArgs e)
        {
            //try
            //{
            if (tb_uhid.Text != "")
            {

                String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                MySqlConnection sqlconn = new MySqlConnection(con);

                sqlconn.Open();              


                string query2 = "SELECT * FROM pt_details where uhid= '" + tb_uhid.Text + "'";
                MySqlCommand cmd3 = new MySqlCommand(query2, sqlconn);
                DataTable dt2 = new DataTable();
                dt2.Load(cmd3.ExecuteReader());

                String pname = "sp_pt_details";
                MySqlCommand cmd = new MySqlCommand(pname, sqlconn);

               

                if (dt2.Rows.Count != 0)
                {
                    cmd.Parameters.AddWithValue("Maction", "UPDATE");
                    cmd.Parameters.AddWithValue("Mentered_date", Convert.ToDateTime(dt2.Rows[0]["entered_date"]));

                    //if (dtb.Rows.Count != 0)
                    //{
                    //    foreach (DataRow dtRow in dtb.Rows)
                    //    {
                    //        string test = dtRow["uhid"].ToString();
                    //        empty_bed(dtRow["uhid"].ToString());
                    //        add_discharge(dtRow["uhid"].ToString());

                    //    }
                    //}
                }
                else
                {     
                    cmd.Parameters.AddWithValue("Maction", "INSERT");
                    cmd.Parameters.AddWithValue("Mentered_date", DateTime.Now);
                }
                
                if(tb_bed.Text!="")
                {
                    string queryb = "SELECT * FROM pt_details where ward= '" + ddl_ward.SelectedValue + "' and bed='" + tb_bed.Text + "' and uhid!='" + tb_uhid.Text + "' ";
                    MySqlCommand cmdb = new MySqlCommand(queryb, sqlconn);
                    DataTable dtb = new DataTable();
                    dtb.Load(cmdb.ExecuteReader());
                    if (dtb.Rows.Count != 0)
                    {
                        foreach (DataRow dtRow in dtb.Rows)
                        {
                            string test = dtRow["uhid"].ToString();
                            empty_bed(dtRow["uhid"].ToString());
                            add_discharge(dtRow["uhid"].ToString());
                        }
                    }
                }
                

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Muhid", tb_uhid.Text);
                cmd.Parameters.AddWithValue("Mfname", tb_fname.Text);
                cmd.Parameters.AddWithValue("Mlname", tb_lname.Text);
                cmd.Parameters.AddWithValue("Msex", ddl_sex.SelectedValue);

                if (tb_age.Text != "")
                {
                    int year = Convert.ToInt32(DateTime.Now.Year) - Convert.ToInt32(tb_age.Text);
                    string dateb = "01-01-" + year;
                    DateTime dob = Convert.ToDateTime(dateb);
                    cmd.Parameters.AddWithValue("Mdob", dob);
                }


                cmd.Parameters.AddWithValue("Mbld_grp", ddl_bld.SelectedValue);
                cmd.Parameters.AddWithValue("Mbld_donated", tb_bld_d.Text);


                if (tb_doa.Text != "")
                {
                    cmd.Parameters.AddWithValue("Mdate_admit", Convert.ToDateTime(tb_doa.Text));
                }
                else
                {
                    cmd.Parameters.AddWithValue("Mdate_admit", null);
                }

                cmd.Parameters.AddWithValue("Mdiag1", tb_diag1.Text);
                cmd.Parameters.AddWithValue("Mdiag2", tb_diag2.Text);
                cmd.Parameters.AddWithValue("Mdiag3", tb_diag3.Text);

                cmd.Parameters.AddWithValue("Mconsultant", consultant);
                cmd.Parameters.AddWithValue("Mward", ward);
                cmd.Parameters.AddWithValue("Mbed", tb_bed.Text.Trim().TrimStart('0'));

                cmd.Parameters.AddWithValue("Mentered_by", Session["username"].ToString());

                Int32 Affectedrows = cmd.ExecuteNonQuery();
                if (Affectedrows != 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record inserted Successfully');", true);
                    Session["uhid"] = tb_uhid.Text;
                }
                sqlconn.Close();
            }
            else
            {
                Session["uhid"] = null;
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Enter uhid and date');", true);
            }
            //}
            //    catch (Exception m)
            //    {
            //        Label l = new Label();
            //        l.Text = "<script>alert('" + m.Message + "')</script>";
            //        Form.Controls.Add(l);
            //    }
        }


        void empty_bed(string p_uhid)
        {

            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();

            String pname = "sp_pt_details";
            MySqlCommand cmde = new MySqlCommand(pname, sqlconn);

            cmde.Parameters.AddWithValue("Maction", "empty_bed");
            cmde.CommandType = CommandType.StoredProcedure;

            cmde.Parameters.AddWithValue("Mentered_date", "");
            cmde.Parameters.AddWithValue("Mfname", "");
            cmde.Parameters.AddWithValue("Mlname", "");
            cmde.Parameters.AddWithValue("Msex", "");
            cmde.Parameters.AddWithValue("Mdob", "");
            cmde.Parameters.AddWithValue("Mbld_grp", "");
            cmde.Parameters.AddWithValue("Mbld_donated", "");
            cmde.Parameters.AddWithValue("Mdate_admit", "");
            cmde.Parameters.AddWithValue("Mdiag1", "");
            cmde.Parameters.AddWithValue("Mdiag2", "");
            cmde.Parameters.AddWithValue("Mdiag3", "");
            cmde.Parameters.AddWithValue("Mward", "");
            cmde.Parameters.AddWithValue("Mentered_by", "");
            cmde.Parameters.AddWithValue("Muhid", p_uhid);
            cmde.Parameters.AddWithValue("Mbed", "");
            cmde.Parameters.AddWithValue("Mconsultant", "");

            cmde.ExecuteNonQuery();

            sqlconn.Close();
        }

        void add_discharge(String p_uhid)
        {
            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();

            string query2 = "SELECT * FROM discharge_status where uhid= '" + p_uhid + "'";
            MySqlCommand cmd3 = new MySqlCommand(query2, sqlconn);
            DataTable dt2 = new DataTable();
            dt2.Load(cmd3.ExecuteReader());

            String pname = "sp_discharge_status";
            MySqlCommand cmdd = new MySqlCommand(pname, sqlconn);

            if (dt2.Rows.Count != 0)
            {
                cmdd.Parameters.AddWithValue("Maction", "UPDATE");
            }
            else
            {
                cmdd.Parameters.AddWithValue("Maction", "INSERT");
            }

            cmdd.CommandType = CommandType.StoredProcedure;

            cmdd.Parameters.AddWithValue("Muhid", p_uhid);
            cmdd.Parameters.AddWithValue("Mstatus", "Discharge");
            cmdd.Parameters.AddWithValue("Mdate", Convert.ToDateTime(tb_doa.Text));
            cmdd.Parameters.AddWithValue("Mtime", "");
            cmdd.ExecuteNonQuery();

            sqlconn.Close();
        }

    }
}