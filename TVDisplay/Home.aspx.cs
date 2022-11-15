using EO.Base.UI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Windows.Threading;

namespace TVDisplay
{
    public partial class Home : System.Web.UI.Page
    {
        private static string ret;
        private static string aaa;
        protected void Page_Init(object sender, EventArgs e)
        {
            
        }
        protected async void sync_to_cache(object sender, EventArgs e)
        {
            string ttt = Session["ward"].ToString();
            try
            {
                await save_cache(ttt);
            }
            finally
            {
                syncing.Style["display"] = "none";
                sync_now.Visible = true;

                if (Cache["'" + Session["username"].ToString() + "'ward"].ToString() != null && Cache["'" + Session["username"].ToString() + "'last_sync"] != null)
                {
                    if (Cache["'" + Session["username"].ToString() + "'ward"].ToString() == ttt)
                    {
                        show_tick();
                        last_sync.Visible = true;
                        DateTime d = Convert.ToDateTime(Cache["'" + Session["username"].ToString() + "'last_sync"].ToString());
                        sync_date.Text = d.ToString("dd MMM yyyy") + "," + d.ToString("HH:mm tt");
                    }
                }
            }
        }
        

        void show_tick()
        {
            tick1.Visible = true;
            tick2.Visible = true;
            tick3.Visible = true;
            tick4.Visible = true;
            tick5.Visible = true;
            tick6.Visible = true;
            tick7.Visible = true;
            tick8.Visible = true;
            tick9.Visible = true;
            tick10.Visible = true;
            tick11.Visible = true;
            tick12.Visible = true;
            tick13.Visible = true;
            tick14.Visible = true;
            tick15.Visible = true;
            tick16.Visible = true;
            tick17.Visible = true;
            tick18.Visible = true;
            tick19.Visible = true;
            tick20.Visible = true;
            tick21.Visible = true;
            tick22.Visible = true;
            tick23.Visible = true;
            tick24.Visible = true;
            tick25.Visible = true;
            tick26.Visible = true;
            tick27.Visible = true;
            tick28.Visible = true;
            tick29.Visible = true;
            tick30.Visible = true;
            tick31.Visible = true;
            sync1.Visible = false;
            sync2.Visible = false;
            sync3.Visible = false;
            sync4.Visible = false;
            sync5.Visible = false;
            sync6.Visible = false;
            sync7.Visible = false;
            sync8.Visible = false;
            sync9.Visible = false;
            sync10.Visible = false;
            sync11.Visible = false;
            sync12.Visible = false;
            sync13.Visible = false;
            sync14.Visible = false;
            sync15.Visible = false;
            sync16.Visible = false;
            sync17.Visible = false;
            sync18.Visible = false;
            sync18.Visible = false;
            sync19.Visible = false;
            sync20.Visible = false;
            sync21.Visible = false;
            sync22.Visible = false;
            sync23.Visible = false;
            sync24.Visible = false;
            sync25.Visible = false;
            sync26.Visible = false;
            sync27.Visible = false;
            sync28.Visible = false;
            sync29.Visible = false;
            sync30.Visible = false;
            sync31.Visible = false;
        }


        void hide_tick()
        {
            tick1.Visible = false;
            tick2.Visible = false;
            tick3.Visible = false;
            tick4.Visible = false;
            tick5.Visible = false;
            tick6.Visible = false;
            tick7.Visible = false;
            tick8.Visible = false;
            tick9.Visible = false;
            tick10.Visible = false;
            tick11.Visible = false;
            tick12.Visible = false;
            tick13.Visible = false;
            tick14.Visible = false;
            tick15.Visible = false;
            tick16.Visible = false;
            tick17.Visible = false;
            tick18.Visible = false;
            tick19.Visible = false;
            tick20.Visible = false;
            tick21.Visible = false;
            tick22.Visible = false;
            tick23.Visible = false;
            tick24.Visible = false;
            tick25.Visible = false;
            tick26.Visible = false;
            tick27.Visible = false;
            tick28.Visible = false;
            tick29.Visible = false;
            tick30.Visible = false;
            sync1.Visible = true;
            sync2.Visible = true;
            sync3.Visible = true;
            sync4.Visible = true;
            sync5.Visible = true;
            sync6.Visible = true;
            sync7.Visible = true;
            sync8.Visible = true;
            sync9.Visible = true;
            sync10.Visible = true;
            sync11.Visible = true;
            sync12.Visible = true;
            sync13.Visible = true;
            sync14.Visible = true;
            sync15.Visible = true;
            sync16.Visible = true;
            sync17.Visible = true;
            sync18.Visible = true;
            sync18.Visible = true;
            sync19.Visible = true;
            sync20.Visible = true;
            sync21.Visible = true;
            sync22.Visible = true;
            sync23.Visible = true;
            sync24.Visible = true;
            sync25.Visible = true;
            sync26.Visible = true;
            sync27.Visible = true;
            sync28.Visible = true;
            sync29.Visible = true;
            sync30.Visible = true;
            sync31.Visible = true;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            String userAgent;
            userAgent = Request.UserAgent;
            GetDeviceType(userAgent);
            if(!IsPostBack)
            {
                if(Request.Cookies["userid"].Value.ToString()==null && Session["username"]==null)
                {
                    Response.Redirect("Login.aspx");
                }

                l_user.Text = Request.Cookies["userid"].Value.ToString();
                Session["username"] = Request.Cookies["userid"].Value.ToString();

                ward_change(sender, e);
                if (Cache["'" + Session["username"].ToString() + "'ward"] != null && Cache["'" + Session["username"].ToString() + "'last_sync"] != null)
                {
                    if (Cache["'" + Session["username"].ToString() + "'ward"].ToString() == Request.Cookies["ward"].Value.ToString())
                    {
                        show_tick();
                        last_sync.Visible = true;
                        DateTime d = Convert.ToDateTime(Cache["'" + Session["username"].ToString() + "'last_sync"].ToString());
                        sync_date.Text = d.ToString("dd MMM yyyy") + "," + d.ToString("HH:mm tt");
                    }
                    else
                    {
                        last_sync.Visible = false;
                        hide_tick();
                    }
                }
                else
                {
                    hide_tick();
                }

                check_role();

                if (Request.Cookies.AllKeys.Contains("place"))
                {
                    if(Request.Cookies["place"].Value.ToString()=="aiims")
                    {
                        one.Checked = true;
                        ward_change(sender, e);
                        select_ward(sender, e);
                    }
                    else
                    {
                        three.Checked = true;
                        ward_change(sender, e);
                        select_ward(sender, e);
                    }
                    if (Request.Cookies.AllKeys.Contains("ward"))
                    {
                        ddl_ward.SelectedValue = Request.Cookies["ward"].Value.ToString();
                        //Session["ward"]= Request.Cookies["ward"].Value.ToString();
                        ward_selection(sender, e);
                        if (Request.Cookies.AllKeys.Contains("unit"))
                        {
                            rbl_pt.SelectedValue = Request.Cookies["unit"].Value.ToString();
                            unit_select(sender, e);
                        }

                        if (Cache["'" + Session["username"].ToString() + "'ward"] != null && Cache["'" + Session["username"].ToString() + "'last_sync"] != null)
                        {
                            if (Cache["'" + Session["username"].ToString() + "'ward"].ToString() == Request.Cookies["ward"].Value.ToString())
                            {
                                show_tick();
                                last_sync.Visible = true;
                                DateTime d = Convert.ToDateTime(Cache["'" + Session["username"].ToString() + "'last_sync"].ToString());
                                sync_date.Text = d.ToString("dd MMM yyyy") + "," + d.ToString("HH:mm tt");
                                
                            }
                            else
                            {
                                last_sync.Visible = false;
                                hide_tick();
                            }
                        }
                        else
                        {
                            hide_tick();
                        }
                    }

                }
                else
                {
                    three.Checked = true;
                    ddl_ward.SelectedValue = "TC3";
                    ward_selection(sender, e);
                }                
            }

           
        }


        void check_role()
        {
            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);
            sqlconn.Open();

            string query2 = "SELECT * FROM login_user where username= '" + Session["username"].ToString() + "' ";
            MySqlCommand cmd3 = new MySqlCommand(query2, sqlconn);
            DataTable dts = new DataTable();
            dts.Load(cmd3.ExecuteReader());
            if (dts.Rows.Count != 0)
            {
                if (dts.Rows[0]["role"].ToString() == "admin")
                {
                    upload_mail.Visible = true;
                }
                else
                {
                    upload_mail.Visible = false;
                }
                Session["hid"] = dts.Rows[0]["hid"].ToString();
            }
        }
        protected void ww_click(object sender, EventArgs e)
        {
            ward_change(sender, e);
            select_ward(sender, e);
        }

        protected async Task save_cache(string ward)
        {           if(Cache["'" + Session["username"].ToString() + "'ward"] !=null)
                    {
                        Cache.Remove("'" + Session["username"].ToString() + "'ward");
                    }

                    Cache.Insert("'" + Session["username"].ToString() + "'ward", ward);

                    int i = 0;
                    String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                    MySqlConnection sqlconn = new MySqlConnection(con);
                    sqlconn.Open();

                    string query = "SELECT * FROM pt_details where ward= '" + ward + "' and bed != '' ";
                    MySqlCommand cmd = new MySqlCommand(query, sqlconn);
                    DataTable dts = new DataTable();
                    dts.Load(cmd.ExecuteReader());
                    if (dts.Rows.Count != 0)
                    {
                       // Cache["last_pts"] = dts;
                        Cache.Insert("'" + Session["username"].ToString() + "'last_pts", dts);
                    }

                    DataTable gcs = new DataTable();
                    DataTable infusion = new DataTable();
                    DataTable io = new DataTable();
                    DataTable ventilation = new DataTable();
                    DataTable surgery = new DataTable();
                    DataTable fever = new DataTable();
                    DataTable lab = new DataTable();
                    DataTable vital = new DataTable();
                    DataTable plan = new DataTable();
                    DataTable issues = new DataTable();
                    DataTable documents = new DataTable();

                    foreach (DataRow dr in dts.Rows)
                    {
                       string aa=  dr["uhid"].ToString();

                        string query1 = "SELECT * FROM gcs where uhid= '" + aa + "' order by date desc limit 3 ";
                        MySqlCommand cmd1 = new MySqlCommand(query1, sqlconn);
                        DataTable dts1 = new DataTable();
                        dts1.Load(cmd1.ExecuteReader());
                        if (dts1.Rows.Count != 0)
                        {
                           gcs.Merge(dts1);
                        }
                        dts1.Clear();
                        i = 5;
                        //if (progress != null)
                        //{
                        //    progress.Report(i);
                        //}

                        string query2 = "SELECT * FROM infusion_details where uhid= '" + aa + "' ";
                        MySqlCommand cmd2 = new MySqlCommand(query2, sqlconn);
                        DataTable dts2 = new DataTable();
                        dts2.Load(cmd2.ExecuteReader());
                        if (dts2.Rows.Count != 0)
                        {
                            infusion.Merge(dts2);
                        }
                        dts2.Clear();
                        i = 10;
                        //if (progress != null)
                        //{
                        //    progress.Report(i);
                        //}

                        string query3 = "SELECT * FROM last_io where uhid= '" + aa + "' order by date desc limit 1 ";
                        MySqlCommand cmd3 = new MySqlCommand(query3, sqlconn);
                        DataTable dts3 = new DataTable();
                        dts3.Load(cmd3.ExecuteReader());
                        if (dts3.Rows.Count != 0)
                        {
                            io.Merge(dts3);
                        }
                        dts3.Clear();
                        i = 20;
                        

                        string query4 = "SELECT * FROM ventilation_details where uhid= '" + aa + "'";
                        MySqlCommand cmd4 = new MySqlCommand(query4, sqlconn);
                        DataTable dts4 = new DataTable();
                        dts4.Load(cmd4.ExecuteReader());
                        if (dts4.Rows.Count != 0)
                        {
                            ventilation.Merge(dts4);
                        }
                        dts4.Clear();

                        string query5 = "SELECT * FROM surgery_details where uhid= '" + aa + "' order by date desc limit 4 ";
                        MySqlCommand cmd5 = new MySqlCommand(query5, sqlconn);
                        DataTable dts5 = new DataTable();
                        dts5.Load(cmd5.ExecuteReader());
                        if (dts5.Rows.Count != 0)
                        {
                            surgery.Merge(dts5);
                        }
                        dts5.Clear();

                        string query6 = "SELECT * FROM fever_pack_details where uhid= '" + aa + "' order by date desc limit 3 ";
                        MySqlCommand cmd6 = new MySqlCommand(query6, sqlconn);
                        DataTable dts6 = new DataTable();
                        dts6.Load(cmd6.ExecuteReader());
                        if (dts6.Rows.Count != 0)
                        {
                            fever.Merge(dts6);
                        }
                        dts6.Clear();

                        string query7 = "SELECT distinct test_name, uhid, result, date, time FROM lab_details where uhid= '" + aa + "' order by date desc  ";
                        MySqlCommand cmd7 = new MySqlCommand(query7, sqlconn);
                        DataTable dts7 = new DataTable();
                        dts7.Load(cmd7.ExecuteReader());
                        if (dts7.Rows.Count != 0)
                        {
                            lab.Merge(dts7);
                        }
                        dts7.Clear();

                        string query8 = "SELECT * FROM vital_details where uhid= '" + aa + "' order by date desc limit 1";
                        MySqlCommand cmd8 = new MySqlCommand(query8, sqlconn);
                        DataTable dts8 = new DataTable();
                        dts8.Load(cmd8.ExecuteReader());
                        if (dts8.Rows.Count != 0)
                        {
                            vital.Merge(dts8);
                        }
                        dts8.Clear();

                        string query9 = "SELECT * FROM plan_details where uhid= '" + aa + "' order by date desc  limit 1";
                        MySqlCommand cmd9 = new MySqlCommand(query9, sqlconn);
                        DataTable dts9 = new DataTable();
                        dts9.Load(cmd9.ExecuteReader());
                        if (dts9.Rows.Count != 0)
                        {
                            plan.Merge(dts9);
                        }
                        dts9.Clear();

                        string query10 = "SELECT * FROM issue_details where uhid= '" + aa + "' order by since_date desc  ";
                        MySqlCommand cmd10 = new MySqlCommand(query10, sqlconn);
                        DataTable dts10 = new DataTable();
                        dts10.Load(cmd10.ExecuteReader());
                        if (dts10.Rows.Count != 0)
                        {
                            issues.Merge(dts10);
                        }
                        dts10.Clear();

                        //string script = string.Format("localStorage.userId= '{0}';", "12345");
                        //ClientScript.RegisterClientScriptBlock(this.GetType(), "key", script, true);

                        string query11 = "select * from documents where uhid= '" + aa + "' and type='xray' order by date desc limit 3";
                        MySqlCommand cmd11 = new MySqlCommand(query11, sqlconn);
                        DataTable dts11 = new DataTable();
                        dts11.Load(cmd11.ExecuteReader());
                        if (dts11.Rows.Count != 0)
                        {
                            documents.Merge(dts11);                            
                        }

                        string query12 = "select * from documents where uhid= '" + aa + "' and type='CT Head' order by date desc limit 3";
                        MySqlCommand cmd12 = new MySqlCommand(query12, sqlconn);
                        DataTable dts12 = new DataTable();
                        dts12.Load(cmd12.ExecuteReader());
                        if (dts12.Rows.Count != 0)
                        {
                            documents.Merge(dts12);
                        }

                        string query13 = "select * from documents where uhid= '" + aa + "' and type='CT Spinal' order by date desc limit 3";
                        MySqlCommand cmd13 = new MySqlCommand(query13, sqlconn);
                        DataTable dts13 = new DataTable();
                        dts13.Load(cmd13.ExecuteReader());
                        if (dts13.Rows.Count != 0)
                        {
                            documents.Merge(dts13);
                        }

                        string query14 = "select * from documents where uhid= '" + aa + "' and type='Nursing Notes' order by date desc limit 3";
                        MySqlCommand cmd14 = new MySqlCommand(query14, sqlconn);
                        DataTable dts14 = new DataTable();
                        dts14.Load(cmd14.ExecuteReader());
                        if (dts14.Rows.Count != 0)
                        {
                            documents.Merge(dts14);
                        }

                        string query15 = "select * from documents where uhid= '" + aa + "' and type='Treatment' order by date desc limit 3";
                        MySqlCommand cmd15 = new MySqlCommand(query15, sqlconn);
                        DataTable dts15 = new DataTable();
                        dts15.Load(cmd15.ExecuteReader());
                        if (dts15.Rows.Count != 0)
                        {
                            documents.Merge(dts15);
                        }

                        string query16 = "select * from documents where uhid= '" + aa + "' and type='Monitor Screen' order by date desc limit 3";
                        MySqlCommand cmd16 = new MySqlCommand(query16, sqlconn);
                        DataTable dts16 = new DataTable();
                        dts16.Load(cmd16.ExecuteReader());
                        if (dts16.Rows.Count != 0)
                        {
                            documents.Merge(dts16);
                        }

                        string query17 = "select * from documents where uhid= '" + aa + "' and type='Ventilator Screen' order by date desc limit 3";
                        MySqlCommand cmd17 = new MySqlCommand(query17, sqlconn);
                        DataTable dts17 = new DataTable();
                        dts17.Load(cmd17.ExecuteReader());
                        if (dts17.Rows.Count != 0)
                        {
                            documents.Merge(dts17);
                        }

                        string query18 = "select * from documents where uhid= '" + aa + "' and type='ABG' order by date desc limit 3";
                        MySqlCommand cmd18 = new MySqlCommand(query18, sqlconn);
                        DataTable dts18 = new DataTable();
                        dts18.Load(cmd18.ExecuteReader());
                        if (dts18.Rows.Count != 0)
                        {
                            documents.Merge(dts18);
                        }

                        string query19 = "select * from documents where uhid= '" + aa + "' and type='Lab Reports' order by date desc limit 3";
                        MySqlCommand cmd19 = new MySqlCommand(query19, sqlconn);
                        DataTable dts19 = new DataTable();
                        dts19.Load(cmd19.ExecuteReader());
                        if (dts19.Rows.Count != 0)
                        {
                            documents.Merge(dts19);
                        }

                        string query20 = "select * from documents where uhid= '" + aa + "' and type='Other Documents' order by date desc limit 3";
                        MySqlCommand cmd20 = new MySqlCommand(query20, sqlconn);
                        DataTable dts20 = new DataTable();
                        dts20.Load(cmd20.ExecuteReader());
                        if (dts20.Rows.Count != 0)
                        {
                            documents.Merge(dts20);
                        }

                        string query21 = "select * from documents where uhid= '" + aa + "' and type='MRI' order by date desc limit 3";
                        MySqlCommand cmd21 = new MySqlCommand(query21, sqlconn);
                        DataTable dts21 = new DataTable();
                        dts21.Load(cmd21.ExecuteReader());
                        if (dts21.Rows.Count != 0)
                        {
                            documents.Merge(dts21);
                        }

                        string query22 = "select * from documents where uhid= '" + aa + "' and type='Discharge Summary' order by date desc limit 3";
                        MySqlCommand cmd22 = new MySqlCommand(query22, sqlconn);
                        DataTable dts22 = new DataTable();
                        dts22.Load(cmd22.ExecuteReader());
                        if (dts22.Rows.Count != 0)
                        {
                            documents.Merge(dts22);
                        }

                        dts11.Clear();
                        dts12.Clear();
                        dts13.Clear();                            
                        dts14.Clear();
                        dts15.Clear();
                        dts16.Clear();
                        dts17.Clear();
                        dts18.Clear();
                        dts19.Clear();
                        dts20.Clear();
                        dts21.Clear();
                        dts22.Clear();
                    }            

            //Cache["gcs"] = gcs;
            if (Cache["'" + Session["username"].ToString() + "'gcs"] != null)
            {
                Cache.Remove("'" + Session["username"].ToString() + "'gcs");
            }
            Cache.Insert("'" + Session["username"].ToString() + "'gcs", gcs);

            //Cache["infusion"] = infusion;
            if (Cache["'" + Session["username"].ToString() + "'infusion"] != null)
            {
                Cache.Remove("'" + Session["username"].ToString() + "'infusion");
            }
            Cache.Insert("'" + Session["username"].ToString() + "'infusion", infusion);

            //Cache["io"] = io;
            if (Cache["'" + Session["username"].ToString() + "'io"] != null)
            {
                Cache.Remove("'" + Session["username"].ToString() + "'io");
            }
            Cache.Insert("'" + Session["username"].ToString() + "'io", io);

            //Cache["ventilation"] = ventilation;
            if (Cache["'" + Session["username"].ToString() + "'ventilation"] != null)
            {
                Cache.Remove("'" + Session["username"].ToString() + "'ventilation");
            }
            Cache.Insert("'" + Session["username"].ToString() + "'ventilation", ventilation);

            //Cache["surgery"] = surgery;
            if (Cache["'" + Session["username"].ToString() + "'surgery"] != null)
            {
                Cache.Remove("'" + Session["username"].ToString() + "'surgery");
            }
            Cache.Insert("'" + Session["username"].ToString() + "'surgery", surgery);

            // Cache["fever"] = fever;
            if (Cache["'" + Session["username"].ToString() + "'fever"] != null)
            {
                Cache.Remove("'" + Session["username"].ToString() + "'fever");
            }
            Cache.Insert("'" + Session["username"].ToString() + "'fever", fever);

            //Cache["lab"] = lab;
            if (Cache["'" + Session["username"].ToString() + "'lab"] != null)
            {
                Cache.Remove("'" + Session["username"].ToString() + "'lab");
            }
            Cache.Insert("'" + Session["username"].ToString() + "'lab", lab);

            //Cache["vital"] = vital;
            if (Cache["'" + Session["username"].ToString() + "'vital"] != null)
            {
                Cache.Remove("'" + Session["username"].ToString() + "'vital");
            }
            Cache.Insert("'" + Session["username"].ToString() + "'vital", vital);

            //Cache["plan"] = plan;
            if (Cache["'" + Session["username"].ToString() + "'plan"] != null)
            {
                Cache.Remove("'" + Session["username"].ToString() + "'plan");
            }
            Cache.Insert("'" + Session["username"].ToString() + "'plan", plan);

            //Cache["issues"] = issues;
            if (Cache["'" + Session["username"].ToString() + "'issues"] != null)
            {
                Cache.Remove("'" + Session["username"].ToString() + "'issues");
            }
            Cache.Insert("'" + Session["username"].ToString() + "'issues", issues);

            if (Cache["'" + Session["username"].ToString() + "'documents"] != null)
            {
                Cache.Remove("'" + Session["username"].ToString() + "'documents");
            }
            Cache.Insert("'" + Session["username"].ToString() + "'documents", documents);
            
            //foreach(DataRow dr in documents.Rows)
            //{
            //    byte[] imageArray = System.IO.File.ReadAllBytes("C:/Users/Dr. Deepak Agarwal/Desktop/13-07-2022/TVDisplay/Images/hosp.jpg");
            //    string base64ImageRepresentation = Convert.ToBase64String(imageArray);
            //    Cache.Insert("'" + Session["username"].ToString() + "''"+ dr["path"].ToString() + "'", base64ImageRepresentation);
            //}

            if (Cache["'" + Session["username"].ToString() + "'last_sync"] != null)
            {
                Cache.Remove("'" + Session["username"].ToString() + "'last_sync");
            }
            Cache.Insert("'" + Session["username"].ToString() + "'last_sync", DateTime.Now.ToString() );

            aaa = "1";            

            sqlconn.Close();
        }
        protected void ward_change(object sender, EventArgs e)
        {
            ddl_ward.ClearSelection();
            string constr = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            if (one.Checked == true)
            {
                Response.Cookies["place"].Value = "aiims";
                Response.Cookies["place"].Expires = DateTime.Now.AddDays(15);

                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT ward_name FROM ward_list where h_name='main'"))
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
                ward_selection(sender, e);              
            }
            else
            {
                Response.Cookies["place"].Value = "trauma";
                Response.Cookies["place"].Expires = DateTime.Now.AddDays(15);

                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT ward_name FROM ward_list where h_name='trauma'"))
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
                ward_selection(sender, e);                
            }

            if (Cache["'" + Session["username"].ToString() + "'ward"] != null && Cache["'" + Session["username"].ToString() + "'last_sync"] != null)
            {
                if (Cache["'" + Session["username"].ToString() + "'ward"].ToString() == Request.Cookies["ward"].Value.ToString())
                {
                    show_tick();
                    last_sync.Visible = true;
                    DateTime d = Convert.ToDateTime(Cache["'" + Session["username"].ToString() + "'last_sync"].ToString());
                    sync_date.Text = d.ToString("dd MMM yyyy") + "," + d.ToString("HH:mm tt");
                }
                else
                {
                    hide_tick();
                    last_sync.Visible = false;
                }
            }
            else
            {
                hide_tick();
            }

        }
        void GetDeviceType(string ua)
        {
            //string ret = "";
            // Check if user agent is a smart TV - http://goo.gl/FocDk
            if (Regex.IsMatch(ua, @"GoogleTV|SmartTV|Internet.TV|NetCast|NETTV|AppleTV|boxee|Kylo|Roku|DLNADOC|CE\-HTML", RegexOptions.IgnoreCase))
            {
                ret = "tv";
            }
            // Check if user agent is a TV Based Gaming Console
            else if (Regex.IsMatch(ua, "Xbox|PLAYSTATION.3|Wii", RegexOptions.IgnoreCase))
            {
                ret = "tv";
            }
            // Check if user agent is a Tablet
            else if ((Regex.IsMatch(ua, "iP(a|ro)d", RegexOptions.IgnoreCase) || (Regex.IsMatch(ua, "tablet", RegexOptions.IgnoreCase)) && (!Regex.IsMatch(ua, "RX-34", RegexOptions.IgnoreCase)) || (Regex.IsMatch(ua, "FOLIO", RegexOptions.IgnoreCase))))
            {
                ret = "tablet";
            }
            // Check if user agent is an Android Tablet
            else if ((Regex.IsMatch(ua, "Linux", RegexOptions.IgnoreCase)) && (Regex.IsMatch(ua, "Android", RegexOptions.IgnoreCase)) && (!Regex.IsMatch(ua, "Fennec|mobi|HTC.Magic|HTCX06HT|Nexus.One|SC-02B|fone.945", RegexOptions.IgnoreCase)))
            {
                ret = "tablet";
            }
            // Check if user agent is a Kindle or Kindle Fire
            else if ((Regex.IsMatch(ua, "Kindle", RegexOptions.IgnoreCase)) || (Regex.IsMatch(ua, "Mac.OS", RegexOptions.IgnoreCase)) && (Regex.IsMatch(ua, "Silk", RegexOptions.IgnoreCase)))
            {
                ret = "tablet";
            }
            // Check if user agent is a pre Android 3.0 Tablet
            else if ((Regex.IsMatch(ua, @"GT-P10|SC-01C|SHW-M180S|SGH-T849|SCH-I800|SHW-M180L|SPH-P100|SGH-I987|zt180|HTC(.Flyer|\\_Flyer)|Sprint.ATP51|ViewPad7|pandigital(sprnova|nova)|Ideos.S7|Dell.Streak.7|Advent.Vega|A101IT|A70BHT|MID7015|Next2|nook", RegexOptions.IgnoreCase)) || (Regex.IsMatch(ua, "MB511", RegexOptions.IgnoreCase)) && (Regex.IsMatch(ua, "RUTEM", RegexOptions.IgnoreCase)))
            {
                ret = "tablet";
            }
            // Check if user agent is unique Mobile User Agent
            else if ((Regex.IsMatch(ua, "BOLT|Fennec|Iris|Maemo|Minimo|Mobi|mowser|NetFront|Novarra|Prism|RX-34|Skyfire|Tear|XV6875|XV6975|Google.Wireless.Transcoder", RegexOptions.IgnoreCase)))
            {
                ret = "mobile";
            }
            // Check if user agent is an odd Opera User Agent - http://goo.gl/nK90K
            else if ((Regex.IsMatch(ua, "Opera", RegexOptions.IgnoreCase)) && (Regex.IsMatch(ua, "Windows.NT.5", RegexOptions.IgnoreCase)) && (Regex.IsMatch(ua, @"HTC|Xda|Mini|Vario|SAMSUNG\-GT\-i8000|SAMSUNG\-SGH\-i9", RegexOptions.IgnoreCase)))
            {
                ret = "mobile";
            }
            // Check if user agent is Windows Desktop
            else if ((Regex.IsMatch(ua, "Windows.(NT|XP|ME|9)")) && (!Regex.IsMatch(ua, "Phone", RegexOptions.IgnoreCase)) || (Regex.IsMatch(ua, "Win(9|.9|NT)", RegexOptions.IgnoreCase)))
            {
                ret = "desktop";
            }
            // Check if agent is Mac Desktop
            else if ((Regex.IsMatch(ua, "Macintosh|PowerPC", RegexOptions.IgnoreCase)) && (!Regex.IsMatch(ua, "Silk", RegexOptions.IgnoreCase)))
            {
                ret = "desktop";
            }
            // Check if user agent is a Linux Desktop
            else if ((Regex.IsMatch(ua, "Linux", RegexOptions.IgnoreCase)) && (Regex.IsMatch(ua, "X11", RegexOptions.IgnoreCase)))
            {
                ret = "desktop";
            }
            // Check if user agent is a Solaris, SunOS, BSD Desktop
            else if ((Regex.IsMatch(ua, "Solaris|SunOS|BSD", RegexOptions.IgnoreCase)))
            {
                ret = "desktop";
            }
            // Check if user agent is a Desktop BOT/Crawler/Spider
            else if ((Regex.IsMatch(ua, "Bot|Crawler|Spider|Yahoo|ia_archiver|Covario-IDS|findlinks|DataparkSearch|larbin|Mediapartners-Google|NG-Search|Snappy|Teoma|Jeeves|TinEye", RegexOptions.IgnoreCase)) && (!Regex.IsMatch(ua, "Mobile", RegexOptions.IgnoreCase)))
            {
                ret = "desktop";
            }
            // Otherwise assume it is a Mobile Device
            else
            {
                ret = "mobile";
            }
            // return ret;
            //tb_username.Text = ret;

            
        }

        protected void dash_click(object sender, EventArgs e)
        {
            if (ret == "tv")
            {
                Response.Redirect("dashboard.aspx");
            }
            else if (ret == "mobile")
            {
                Response.Redirect("mob_dash.aspx");
            }
            else if (ret == "desktop")
            {
                Response.Redirect("mob_dash.aspx");
                //Response.Redirect("mob_dash.aspx");
            }
            else if (ret == "tablet")
            {
                Response.Redirect("mob_dash.aspx");
            }
        }


        protected void register(object sender, EventArgs e)
        {
            Session["uhid"] = null;
            Response.Redirect("Details.aspx");
        }

        protected void search_uhid(object sender, EventArgs e)
        {
            try
            {
                if (tb_uhid.Text != "")
                {
                    String con1 = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                    MySqlConnection mysqlconn1 = new MySqlConnection(con1);
                    mysqlconn1.Open();
                    string query1 = "SELECT * FROM pt_details where uhid= '" + tb_uhid.Text + "'";
                    MySqlCommand cmd21 = new MySqlCommand(query1, mysqlconn1);
                    DataTable dt21 = new DataTable();
                    dt21.Load(cmd21.ExecuteReader());

                    String con = ConfigurationManager.ConnectionStrings["neuro"].ConnectionString;
                    SqlConnection sqlconn = new SqlConnection(con);
                    sqlconn.Open();
                    string query = "SELECT * FROM [NeuroTrauma].[dbo].[pt_details] where uhid= '" + tb_uhid.Text + "'";
                    SqlCommand cmd2 = new SqlCommand(query, sqlconn);
                    DataTable dt2 = new DataTable();
                    dt2.Load(cmd2.ExecuteReader());

                    if (dt21.Rows.Count != 0)
                    {
                        Session["uhid"] = tb_uhid.Text;
                        alert_label.Visible = false;
                        //btn_details.Text = "Edit Details";
                        p_row.Visible = true;
                        p_name.Text = dt21.Rows[0]["fname"].ToString() + " " + dt21.Rows[0]["lname"].ToString();
                        p_uhid.Text = dt21.Rows[0]["uhid"].ToString();
                    }
                    else if (dt2.Rows.Count != 0)
                    {
                        Session["uhid"] = tb_uhid.Text;
                        alert_label.Visible = true;
                       // btn_details.Text = "Register Patient";
                        p_row.Visible = false;
                    }
                    else
                    {
                        Session["uhid"] = tb_uhid.Text;
                        alert_label.Visible = true;
                        //btn_details.Text = "Register Patient";
                        p_row.Visible = false;
                    }
                    sqlconn.Close();
                    mysqlconn1.Close();
                }
                else
                {
                    Session["uhid"] = null;
                    p_row.Visible = false;
                    alert_label.Visible = false;
                    //btn_details.Text = "Register New Patient";
                }
            }
            catch (Exception m)
            {

            }
        }
        
        protected void select_ward(object sender, EventArgs e)
        {
            rbl_pt.ClearSelection();

            u1b1.Visible = false;
            u1b2.Visible = false;
            u1b3.Visible = false;
            u1b4.Visible = false;
            u1b5.Visible = false;
            u1b6.Visible = false;
            u1b7.Visible = false;
            u1b8.Visible = false;
            u1b9.Visible = false;
            u1b10.Visible = false;
            u1b11.Visible = false;
            u1b12.Visible = false;
            u1b13.Visible = false;
            u1b14.Visible = false;
            u1b15.Visible = false;
            u1b16.Visible = false;
            u1b17.Visible = false;
            u1b18.Visible = false;
            u1b19.Visible = false;
            u1b20.Visible = false;
            u1b21.Visible = false;
            u1b22.Visible = false;
            u1b23.Visible = false;
            u1b24.Visible = false;
            u1b25.Visible = false;
            u1b26.Visible = false;
            u1b27.Visible = false;
            u1b28.Visible = false;
            u1b29.Visible = false;
            u1b30.Visible = false;
            u1b31.Visible = false;
            for (int i=1; i<=30; i++)
            {
                System.Web.UI.WebControls.LinkButton bb = FindControl("b"+i) as System.Web.UI.WebControls.LinkButton;
                bb.BackColor= System.Drawing.ColorTranslator.FromHtml("#A9A9A9");
                bb.ForeColor = System.Drawing.Color.White;
            }
            ward_selection(sender, e);            
        }

        void ward_selection(object sender, EventArgs e)
        {
            if (ddl_ward.SelectedIndex != -1)
            {
                Response.Cookies["ward"].Value = ddl_ward.SelectedValue;

                Response.Cookies["ward"].Expires = DateTime.Now.AddDays(15);

                Session["ward"] = ddl_ward.SelectedValue;

                if (Cache["'" + Session["username"].ToString() + "'ward"] != null && Cache["'" + Session["username"].ToString() + "'last_sync"] != null)
                {
                    string ccc = Cache["'" + Session["username"].ToString() + "'ward"].ToString();
                    if (ccc == ddl_ward.SelectedValue)
                    {
                        show_tick();
                        last_sync.Visible = true;
                        DateTime d = Convert.ToDateTime(Cache["'" + Session["username"].ToString() + "'last_sync"].ToString());
                        sync_date.Text = d.ToString("dd MMM yyyy") + "," + d.ToString("HH:mm tt");
                    }
                    else
                    {
                        last_sync.Visible = false;
                        hide_tick();
                    }
                }
                else
                {
                    hide_tick();
                }
            }
            if (rbl_pt.SelectedIndex == -1)
            {
                if (ddl_ward.SelectedValue == "ICUB")
                {
                    bed_color("ICUB");
                    u1b1.Visible = true;
                    u1b2.Visible = true;
                    u1b3.Visible = true;
                    u1b4.Visible = true;
                    u1b5.Visible = true;
                    u1b6.Visible = true;

                    u1b7.Visible = true;
                    u1b8.Visible = true;
                    u1b9.Visible = true;
                    u1b10.Visible = true;
                    u1b11.Visible = true;
                    u1b12.Visible = true;

                }
                if (ddl_ward.SelectedValue == "ICUC")
                {
                    bed_color("ICUC");
                    u1b11.Visible = true;
                    u1b12.Visible = true;
                    u1b13.Visible = true;
                    u1b14.Visible = true;
                    u1b15.Visible = true;
                    u1b16.Visible = true;
                    u1b17.Visible = true;

                    //u1b1.Visible = true;
                    //u1b2.Visible = true;
                    //u1b3.Visible = true;
                    //u1b4.Visible = true;
                    //u1b5.Visible = true;
                    //u1b6.Visible = true;
                    u1b7.Visible = true;
                    u1b8.Visible = true;
                    u1b9.Visible = true;
                    u1b10.Visible = true;
                    u1b18.Visible = true;
                    u1b19.Visible = true;
                }
                if (ddl_ward.SelectedValue == "NS3 HDU")
                {
                    bed_color("NS3 HDU");
                    u1b25.Visible = true;
                    u1b26.Visible = true;
                    u1b27.Visible = true;
                    u1b28.Visible = true;
                    u1b29.Visible = true;
                    u1b30.Visible = true;
                    u1b31.Visible = true;
                }
                if (ddl_ward.SelectedValue == "TC3")
                {
                    bed_color("TC3");
                    u1b1.Visible = true;
                    u1b2.Visible = true;
                    u1b3.Visible = true;
                    u1b4.Visible = true;
                    u1b5.Visible = true;
                    u1b6.Visible = true;

                    u1b13.Visible = true;
                    u1b14.Visible = true;
                    u1b15.Visible = true;
                    u1b16.Visible = true;

                    u1b7.Visible = true;
                    u1b8.Visible = true;
                    u1b9.Visible = true;
                    u1b10.Visible = true;
                    u1b11.Visible = true;
                    u1b12.Visible = true;

                    u1b17.Visible = true;
                    u1b18.Visible = true;
                    u1b19.Visible = true;
                    u1b20.Visible = true;
                }
                if (ddl_ward.SelectedValue == "TC5")
                {
                    bed_color("TC5");
                    u1b1.Visible = true;
                    u1b2.Visible = true;
                    u1b3.Visible = true;
                    u1b4.Visible = true;
                    u1b5.Visible = true;
                    u1b6.Visible = true;
                    u1b7.Visible = true;
                    u1b8.Visible = true;
                    u1b9.Visible = true;

                    u1b19.Visible = true;
                    u1b20.Visible = true;
                    u1b21.Visible = true;

                    u1b25.Visible = true;
                    u1b26.Visible = true;

                    u1b10.Visible = true;
                    u1b11.Visible = true;
                    u1b12.Visible = true;
                    u1b13.Visible = true;
                    u1b14.Visible = true;
                    u1b15.Visible = true;
                    u1b16.Visible = true;
                    u1b17.Visible = true;
                    u1b18.Visible = true;

                    u1b22.Visible = true;
                    u1b23.Visible = true;
                    u1b24.Visible = true;

                    u1b27.Visible = true;
                    u1b28.Visible = true;
                }
                if (ddl_ward.SelectedValue == "TC4")
                {
                    bed_color("TC4");
                    u1b21.Visible = true;
                    u1b22.Visible = true;
                    u1b23.Visible = true;
                    u1b24.Visible = true;
                    u1b25.Visible = true;

                    u1b26.Visible = true;
                    u1b27.Visible = true;
                    u1b28.Visible = true;
                    u1b29.Visible = true;
                    u1b30.Visible = true;
                }
                if (ddl_ward.SelectedValue == "TC4A")
                {
                    bed_color("TC4A");
                    //u1b9.Visible = true;
                    //u1b10.Visible = true;
                    //u1b11.Visible = true;
                    //u1b12.Visible = true;

                    u1b13.Visible = true;
                    u1b14.Visible = true;
                    u1b15.Visible = true;
                    u1b16.Visible = true;
                    u1b17.Visible = true;
                    u1b18.Visible = true;
                    u1b19.Visible = true;
                    u1b20.Visible = true;

                    u1b21.Visible = true;
                    u1b22.Visible = true;
                    u1b23.Visible = true;
                    u1b24.Visible = true;
                    u1b25.Visible = true;
                    u1b26.Visible = true;
                    u1b27.Visible = true;
                    u1b28.Visible = true;
                }
            }
            else
            {
                unit_select(sender, e);
            }
        }

        void bed_color(string ward_name)
        {
            
            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);
            sqlconn.Open();

            string query = "SELECT bed FROM pt_details where ward='" + ward_name + "' and bed!='' ";

            MySqlCommand cmd = new MySqlCommand(query, sqlconn);

            DataTable dts = new DataTable();
            dts.Load(cmd.ExecuteReader());
            if (dts.Rows.Count != 0)
            {
                foreach (DataRow dtRow in dts.Rows)
                { 
                    if(dtRow["bed"].ToString().Trim().TrimStart('0')!="")
                    {
                        string name = "b" + dtRow["bed"].ToString().Trim().TrimStart('0');
                        System.Web.UI.WebControls.LinkButton btn1 = FindControl(name.Trim()) as System.Web.UI.WebControls.LinkButton;
                        btn1.BackColor = System.Drawing.Color.Green;
                        btn1.ForeColor = System.Drawing.Color.White;
                    }
                }
            }
            sqlconn.Close();
        }
        private bool mouseUp = false;
        
        private const int holdButtonDuration = 2000; //milliseconds
        #region unit1_beds
        protected void unit1_bed1(object sender, EventArgs e)
        {
            check_bed("1", ddl_ward.SelectedValue);
        }
        protected void unit1_bed2(object sender, EventArgs e)
        {
            check_bed("2", ddl_ward.SelectedValue);
        }
        protected void unit1_bed3(object sender, EventArgs e)
        {
            check_bed("3", ddl_ward.SelectedValue);
        }
        protected void unit1_bed4(object sender, EventArgs e)
        {
            check_bed("4", ddl_ward.SelectedValue);
        }
        protected void unit1_bed5(object sender, EventArgs e)
        {
            check_bed("5", ddl_ward.SelectedValue);
        }
        protected void unit1_bed6(object sender, EventArgs e)
        {
            check_bed("6", ddl_ward.SelectedValue);
        }
        protected void unit1_bed7(object sender, EventArgs e)
        {
            check_bed("7", ddl_ward.SelectedValue);
        }
        protected void unit1_bed8(object sender, EventArgs e)
        {
            check_bed("8", ddl_ward.SelectedValue);
        }
        protected void unit1_bed9(object sender, EventArgs e)
        {
            check_bed("9", ddl_ward.SelectedValue);
        }
        protected void unit1_bed10(object sender, EventArgs e)
        {
            check_bed("10", ddl_ward.SelectedValue);
        }
        protected void unit1_bed11(object sender, EventArgs e)
        {
            check_bed("11", ddl_ward.SelectedValue);
        }
        protected void unit1_bed12(object sender, EventArgs e)
        {
            check_bed("12", ddl_ward.SelectedValue);
        }
        protected void unit1_bed13(object sender, EventArgs e)
        {
            check_bed("13", ddl_ward.SelectedValue);
        }
        protected void unit1_bed14(object sender, EventArgs e)
        {
            check_bed("14", ddl_ward.SelectedValue);
        }
        protected void unit1_bed15(object sender, EventArgs e)
        {
            check_bed("15", ddl_ward.SelectedValue);
        }
        protected void unit1_bed16(object sender, EventArgs e)
        {
            check_bed("16", ddl_ward.SelectedValue);
        }
        protected void unit1_bed17(object sender, EventArgs e)
        {
            check_bed("17", ddl_ward.SelectedValue);
        }
        protected void unit1_bed18(object sender, EventArgs e)
        {
            check_bed("18", ddl_ward.SelectedValue);
        }
        protected void unit1_bed19(object sender, EventArgs e)
        {
            check_bed("19", ddl_ward.SelectedValue);
        }
        protected void unit1_bed20(object sender, EventArgs e)
        {
            check_bed("20", ddl_ward.SelectedValue);
        }
        protected void unit1_bed21(object sender, EventArgs e)
        {
            check_bed("21", ddl_ward.SelectedValue);
        }
        protected void unit1_bed22(object sender, EventArgs e)
        {
            check_bed("22", ddl_ward.SelectedValue);
        }
        protected void unit1_bed23(object sender, EventArgs e)
        {
            check_bed("23", ddl_ward.SelectedValue);
        }
        protected void unit1_bed24(object sender, EventArgs e)
        {
            check_bed("24", ddl_ward.SelectedValue);
        }
        protected void unit1_bed25(object sender, EventArgs e)
        {
            check_bed("25", ddl_ward.SelectedValue);
        }
        protected void unit1_bed26(object sender, EventArgs e)
        {
            check_bed("26", ddl_ward.SelectedValue);
        }
        protected void unit1_bed27(object sender, EventArgs e)
        {
            check_bed("27", ddl_ward.SelectedValue);
        }
        protected void unit1_bed28(object sender, EventArgs e)
        {
            check_bed("28", ddl_ward.SelectedValue);
        }
        protected void unit1_bed29(object sender, EventArgs e)
        {
            check_bed("29", ddl_ward.SelectedValue);
        }
        protected void unit1_bed30(object sender, EventArgs e)
        {
            check_bed("30", ddl_ward.SelectedValue);
        }
        protected void unit1_bed31(object sender, EventArgs e)
        {
            check_bed("31", ddl_ward.SelectedValue);
        }
        #endregion

        private void btnTest_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            mouseUp = false;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 1 && (mouseUp == false && sw.ElapsedMilliseconds < holdButtonDuration))
                System.Windows.Forms.Application.DoEvents();
            if (sw.ElapsedMilliseconds >= holdButtonDuration)
            {  //btnTest_ShortClick(sender, e);
                unit1_bed1(sender, e);
            }
            else
            {   //btnTest_LongClick(sender, e);
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Enter uhid and date');", true);
            }
        }
        private void btnTest_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            mouseUp = true;
        }

        void check_bed(string bed_no, string ward_name )
        {
            if (bed_no != "")
            {
                String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                MySqlConnection sqlconn = new MySqlConnection(con);
                sqlconn.Open();

                string query = "SELECT * FROM pt_details where ward='" + ward_name + "' and bed='" + bed_no + "' order by date_admit desc ";

                MySqlCommand cmd = new MySqlCommand(query, sqlconn);

                DataTable dts = new DataTable();
                dts.Load(cmd.ExecuteReader());
                if (dts.Rows.Count != 0)
                {
                    Session["uhid"] = dts.Rows[0]["uhid"].ToString();
                    if (ret == "mobile")
                    {
                        Response.Redirect("mob_dash.aspx");
                    }
                    else if (ret == "desktop")
                    {
                        Response.Redirect("mob_dash.aspx");
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('No patient is registered on this bed');", true);
                }
                sqlconn.Close();
            }
        }
        protected void edit_click(object sender, EventArgs e)
        {
            Session["uhid"] = tb_uhid.Text;
            Response.Redirect("Details.aspx");
        }

        protected void cancel_click(object sender, EventArgs e)
        {
            p_row.Visible = false;
            tb_uhid.Text = "";
            Session["uhid"] = null;
        }

        protected void view_click(object sender, EventArgs e)
        {
            Session["uhid"] = tb_uhid.Text;
            if (ret == "tv")
            {
                Response.Redirect("dashboard.aspx");
            }
            else if (ret == "mobile")
            {
                Response.Redirect("mob_dash.aspx");
            }
            else if (ret == "desktop")
            {
                Response.Redirect("mob_dash.aspx");
                // Response.Redirect("mob_dash.aspx");
            }
            else if (ret == "tablet")
            {
                Response.Redirect("mob_dash.aspx");
            }
        }

        protected void search_button(object sender, ImageClickEventArgs e)
        {
            search_uhid(sender, e);
        }

        protected void aiims_checked(object sender, EventArgs e)
        {
            ward_change(sender, e);
        }
        protected void trauma_checked(object sender, EventArgs e)
        {
            ward_change(sender, e);
        }

        protected void unit_select(object sender, EventArgs e)
        {
            //if(rbl_pt.SelectedIndex != -1)
            //{
                Response.Cookies["unit"].Value = rbl_pt.SelectedValue;
                Response.Cookies["unit"].Expires = DateTime.Now.AddDays(15);
           // }
            u1b1.Visible = false;
            u1b2.Visible = false;
            u1b3.Visible = false;
            u1b4.Visible = false;
            u1b5.Visible = false;
            u1b6.Visible = false;
            u1b7.Visible = false;
            u1b8.Visible = false;
            u1b9.Visible = false;
            u1b10.Visible = false;
            u1b11.Visible = false;
            u1b12.Visible = false;
            u1b13.Visible = false;
            u1b14.Visible = false;
            u1b15.Visible = false;
            u1b16.Visible = false;
            u1b17.Visible = false;
            u1b18.Visible = false;
            u1b19.Visible = false;
            u1b20.Visible = false;
            u1b21.Visible = false;
            u1b22.Visible = false;
            u1b23.Visible = false;
            u1b24.Visible = false;
            u1b25.Visible = false;
            u1b26.Visible = false;
            u1b27.Visible = false;
            u1b28.Visible = false;
            u1b29.Visible = false;
            u1b30.Visible = false;
            u1b31.Visible = false;

            if (rbl_pt.SelectedValue=="unit1")
            {
                if (ddl_ward.SelectedValue == "ICUB")
                {
                    u1b1.Visible = true;
                    u1b2.Visible = true;
                    u1b3.Visible = true;
                    u1b4.Visible = true;
                    u1b5.Visible = true;
                    u1b6.Visible = true;

                    u1b7.Visible = false;
                    u1b8.Visible = false;
                    u1b9.Visible = false;
                    u1b10.Visible = false;
                    u1b11.Visible = false;
                    u1b12.Visible = false;

                }
                if (ddl_ward.SelectedValue == "NS3 HDU")
                {                    
                    u1b25.Visible = true;
                    u1b26.Visible = true;
                    u1b27.Visible = true;
                    u1b28.Visible = true;
                    u1b29.Visible = true;
                    u1b30.Visible = true;
                    u1b31.Visible = true;
                }
                if (ddl_ward.SelectedValue == "ICUC")
                {
                    u1b11.Visible = true;
                    u1b12.Visible = true;
                    u1b13.Visible = true;
                    u1b14.Visible = true;
                    u1b15.Visible = true;
                    u1b16.Visible = true;
                    u1b17.Visible = true;

                    u1b7.Visible = false;
                    u1b8.Visible = false;
                    u1b9.Visible = false;
                    u1b10.Visible = false;

                    u1b18.Visible = false;
                    u1b19.Visible = false;
                }
                if (ddl_ward.SelectedValue == "TC3")
                {
                    u1b1.Visible = true;
                    u1b2.Visible = true;
                    u1b3.Visible = true;
                    u1b4.Visible = true;
                    u1b5.Visible = true;
                    u1b6.Visible = true;

                    u1b13.Visible = true;
                    u1b14.Visible = true;
                    u1b15.Visible = true;
                    u1b16.Visible = true;

                    u1b7.Visible = false;
                    u1b8.Visible = false;
                    u1b9.Visible = false;
                    u1b10.Visible = false;
                    u1b11.Visible = false;
                    u1b12.Visible = false;

                    u1b17.Visible = false;
                    u1b18.Visible = false;
                    u1b19.Visible = false;
                    u1b20.Visible = false;
                }
                if (ddl_ward.SelectedValue == "TC5")
                {
                    u1b1.Visible = true;
                    u1b2.Visible = true;
                    u1b3.Visible = true;
                    u1b4.Visible = true;
                    u1b5.Visible = true;
                    u1b6.Visible = true;
                    u1b7.Visible = true;
                    u1b8.Visible = true;
                    u1b9.Visible = true;

                    u1b19.Visible = true;
                    u1b20.Visible = true;
                    u1b21.Visible = true;

                    u1b25.Visible = true;
                    u1b26.Visible = true;

                    u1b10.Visible = false;
                    u1b11.Visible = false;
                    u1b12.Visible = false;
                    u1b13.Visible = false;
                    u1b14.Visible = false;
                    u1b15.Visible = false;
                    u1b16.Visible = false;
                    u1b17.Visible = false;
                    u1b18.Visible = false;

                    u1b22.Visible = false;
                    u1b23.Visible = false;
                    u1b24.Visible = false;

                    u1b27.Visible = false;
                    u1b28.Visible = false;
                }
                if (ddl_ward.SelectedValue == "TC4")
                {
                    u1b21.Visible = true;
                    u1b22.Visible = true;
                    u1b23.Visible = true;
                    u1b24.Visible = true;
                    u1b25.Visible = true;

                    u1b26.Visible = false;
                    u1b27.Visible = false;
                    u1b28.Visible = false;
                    u1b29.Visible = false;
                    u1b30.Visible = false;
                }
                if (ddl_ward.SelectedValue == "TC4A")
                {
                    //u1b9.Visible = true;
                    //u1b10.Visible = true;
                    //u1b11.Visible = true;
                    //u1b12.Visible = true;

                    u1b13.Visible = true;
                    u1b14.Visible = true;
                    u1b15.Visible = true;
                    u1b16.Visible = true;
                    u1b17.Visible = true;
                    u1b18.Visible = true;
                    u1b19.Visible = true;
                    u1b20.Visible = true;

                    u1b21.Visible = false;
                    u1b22.Visible = false;
                    u1b23.Visible = false;
                    u1b24.Visible = false;
                    u1b25.Visible = false;
                    u1b26.Visible = false;
                    u1b27.Visible = false;
                    u1b28.Visible = false;
                }
            }
            else if(rbl_pt.SelectedValue=="unit2")
            {
                if (ddl_ward.SelectedValue == "ICUB")
                {
                    u1b1.Visible = false;
                    u1b2.Visible = false;
                    u1b3.Visible = false;
                    u1b4.Visible = false;
                    u1b5.Visible = false;
                    u1b6.Visible = false;

                    u1b7.Visible = true;
                    u1b8.Visible = true;
                    u1b9.Visible = true;
                    u1b10.Visible = true;
                    u1b11.Visible = true;
                    u1b12.Visible = true;
                }
                if (ddl_ward.SelectedValue == "NS3 HDU")
                {
                    u1b25.Visible = false;
                    u1b26.Visible = false;
                    u1b27.Visible = false;
                    u1b28.Visible = false;
                    u1b29.Visible = false;
                    u1b30.Visible = false;
                    u1b31.Visible = false;
                }
                if (ddl_ward.SelectedValue == "ICUC")
                {
                    u1b11.Visible = false;
                    u1b12.Visible = false;
                    u1b13.Visible = false;
                    u1b14.Visible = false;
                    u1b15.Visible = false;
                    u1b16.Visible = false;
                    u1b17.Visible = false;

                    u1b7.Visible = true;
                    u1b8.Visible = true;
                    u1b9.Visible = true;
                    u1b10.Visible = true;
                    u1b18.Visible = true;
                    u1b19.Visible = true;
                }
                if (ddl_ward.SelectedValue == "TC3")
                {
                    u1b1.Visible = false;
                    u1b2.Visible = false;
                    u1b3.Visible = false;
                    u1b4.Visible = false;
                    u1b5.Visible = false;
                    u1b6.Visible = false;

                    u1b13.Visible = false;
                    u1b14.Visible = false;
                    u1b15.Visible = false;
                    u1b16.Visible = false;

                    u1b7.Visible = true;
                    u1b8.Visible = true;
                    u1b9.Visible = true;
                    u1b10.Visible = true;
                    u1b11.Visible = true;
                    u1b12.Visible = true;

                    u1b17.Visible = true;
                    u1b18.Visible = true;
                    u1b19.Visible = true;
                    u1b20.Visible = true;
                }
                if (ddl_ward.SelectedValue == "TC5")
                {
                    u1b1.Visible = false;
                    u1b2.Visible = false;
                    u1b3.Visible = false;
                    u1b4.Visible = false;
                    u1b5.Visible = false;
                    u1b6.Visible = false;
                    u1b7.Visible = false;
                    u1b8.Visible = false;
                    u1b9.Visible = false;

                    u1b19.Visible = false;
                    u1b20.Visible = false;
                    u1b21.Visible = false;

                    u1b25.Visible = false;
                    u1b26.Visible = false;

                    u1b10.Visible = true;
                    u1b11.Visible = true;
                    u1b12.Visible = true;
                    u1b13.Visible = true;
                    u1b14.Visible = true;
                    u1b15.Visible = true;
                    u1b16.Visible = true;
                    u1b17.Visible = true;
                    u1b18.Visible = true;

                    u1b22.Visible = true;
                    u1b23.Visible = true;
                    u1b24.Visible = true;

                    u1b27.Visible = true;
                    u1b28.Visible = true;
                }
                if (ddl_ward.SelectedValue == "TC4")
                {
                    u1b21.Visible = false;
                    u1b22.Visible = false;
                    u1b23.Visible = false;
                    u1b24.Visible = false;
                    u1b25.Visible = false;

                    u1b26.Visible = true;
                    u1b27.Visible = true;
                    u1b28.Visible = true;
                    u1b29.Visible = true;
                    u1b30.Visible = true;
                }
                if (ddl_ward.SelectedValue == "TC4A")
                {
                    u1b13.Visible = false;
                    u1b14.Visible = false;
                    u1b15.Visible = false;
                    u1b16.Visible = false;
                    u1b17.Visible = false;
                    u1b18.Visible = false;
                    u1b19.Visible = false;
                    u1b20.Visible = false;

                    u1b21.Visible = true;
                    u1b22.Visible = true;
                    u1b23.Visible = true;
                    u1b24.Visible = true;
                    u1b25.Visible = true;
                    u1b26.Visible = true;
                    u1b27.Visible = true;
                    u1b28.Visible = true;
                }
            }
        }

        
    }
}