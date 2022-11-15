using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Runtime.Caching;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TVDisplay
{
    public partial class mob_dash : System.Web.UI.Page
    {
        public static string s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] == null)
                {
                    Response.Redirect("Login.aspx");
                }

                if (Session["uhid"] != null)
                {
                    if (Cache["'" + Session["username"].ToString() + "'ward"] != null && Cache["'" + Session["username"].ToString() + "'last_sync"] != null)
                    {
                        if (Request.Cookies.AllKeys.Contains("ward"))
                        {

                            if (Cache["'" + Session["username"].ToString() + "'ward"].ToString() == Request.Cookies["ward"].Value.ToString())
                            {
                                //HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create("http://www.stackoverflow.com");
                                //httpReq.AllowAutoRedirect = false;
                                //HttpWebResponse httpRes = (HttpWebResponse)httpReq.GetResponse();
                                //string ttt = Session["ward"].ToString();
                                //if (httpRes.StatusCode != HttpStatusCode.NotFound)
                                if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() == true)
                                {
                                    //online
                                    DateTime d = Convert.ToDateTime(Cache["'" + Session["username"].ToString() + "'last_sync"].ToString());
                                    TimeSpan tt = DateTime.Now - d;
                                    if (tt.Hours <= 24)
                                    {
                                        get_pt_details1();
                                        fill_issues1();
                                        add_to_gallery1();
                                    }
                                    else
                                    {
                                        get_pt_details();
                                        fill_issues();
                                        add_to_gallery();
                                    }

                                }
                                else
                                {
                                    //offline

                                    get_pt_details1();
                                    fill_issues1();
                                    add_to_gallery1();
                                }
                                // Close the response.
                                // httpRes.Close();
                            }
                            else
                            {
                                //different ward
                                get_pt_details();
                                fill_issues();
                                add_to_gallery();
                            }
                        }
                    }
                    else
                    {
                        //not synced
                        get_pt_details();
                        fill_issues();
                        add_to_gallery();
                    }
                }
               
            }
        }


        protected void goto_pt_details(object sender, EventArgs e)
        {
            Response.Redirect("Details.aspx");
        }
        protected void goto_gcs(object sender, EventArgs e)
        {
            Response.Redirect("gcs.aspx");
        }
        protected void goto_infusion(object sender, EventArgs e)
        {
            Response.Redirect("Infusions.aspx");
        }

        protected void goto_io(object sender, EventArgs e)
        {
            Response.Redirect("IO.aspx");
        }

        protected void goto_pt_details_diag(object sender, EventArgs e)
        {
            Response.Redirect("Details.aspx");
        }

        protected void goto_ventilation(object sender, EventArgs e)
        {
            Response.Redirect("ventilation.aspx");
        }

        protected void goto_vitals(object sender, EventArgs e)
        {
            Response.Redirect("vitals.aspx");
        }

        protected void goto_lab(object sender, EventArgs e)
        {
            Response.Redirect("lab.aspx");
        }

        
        protected void dis_img1_click(object sender, ImageClickEventArgs e)
        {
            add_to_gallery();
            if (dis_img1.ImageUrl == "Images/pdf.png")
            {
                Session["pdf_file"] = s1;
                string url = "pdf_form.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "", "window.open('" + url + "');", true);
                //image_Panel1.Visible = false;
            }
            else
            {
                //mpe1.Show();
                //image1.ImageUrl = dis_img1.ImageUrl;
                //image_Panel1.Visible = true;
            }
        }
       

        protected void goto_surgery(object sender, EventArgs e)
        {
            Response.Redirect("surgery.aspx");
        }

        protected void goto_feverpack(object sender, EventArgs e)
        {
            Response.Redirect("fever.aspx");
        }

        protected void goto_issues(object sender, EventArgs e)
        {
            Response.Redirect("issues.aspx");
        }

        protected void goto_docs(object sender, EventArgs e)
        {
            Response.Redirect("documents.aspx");
        }

        protected void home_dash(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void goto_todays(object sender, EventArgs e)
        {
            Response.Redirect("plan.aspx");
        }
              
        void get_pt_details()
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
                    uhid.Text = dt.Rows[0]["uhid"].ToString();
                    p_name.Text = dt.Rows[0]["fname"].ToString() + " " + dt.Rows[0]["lname"].ToString();

                    // tb_dob.Text = Convert.ToDateTime(dt.Rows[0]["dob"]).ToString("dd-MM-yyyy");
                    doa.Text = Convert.ToDateTime(dt.Rows[0]["date_admit"]).ToString("dd-MM-yyyy");
                    bld_grp.Text = dt.Rows[0]["bld_grp"].ToString();
                    bld_donated.Text = dt.Rows[0]["bld_donated"].ToString() + " Unit";
                    diag1.Text = dt.Rows[0]["diag1"].ToString();

                    if (dt.Rows[0]["diag2"].ToString() != "")
                    {
                        d2.Visible = true;
                        diag2.Text = dt.Rows[0]["diag2"].ToString();
                    }
                    else
                    {
                        d2.Visible = false;
                    }
                    if (dt.Rows[0]["diag3"].ToString() != "")
                    {
                        d3.Visible = true;
                        diag3.Text = dt.Rows[0]["diag3"].ToString();
                    }
                    else
                    {
                        d3.Visible = false;
                    }
                        
                    ward.Text = dt.Rows[0]["ward"].ToString();
                    bed.Text = dt.Rows[0]["bed"].ToString();

                    double days = (DateTime.Now - Convert.ToDateTime(dt.Rows[0]["date_admit"])).TotalDays;
                    los.Text = Math.Ceiling(days) + " Days";

                    int age;
                    DateTime _age = new DateTime();
                    _age = Convert.ToDateTime(dt.Rows[0]["dob"].ToString());
                    age = DateTime.Now.Year - _age.Year;
                    if (DateTime.Now.DayOfYear < _age.DayOfYear)
                    {
                        age = age - 1;
                    }
                    age_sex.Text = age.ToString() + "/" + dt.Rows[0]["sex"].ToString();
                }

                //gcs
                string queryg = "SELECT * FROM gcs where uhid= '" + Session["uhid"].ToString() + "' order by date desc ";
                MySqlCommand cmdg = new MySqlCommand(queryg, sqlconn);
                DataTable dtg = new DataTable();
                dtg.Load(cmdg.ExecuteReader());
                if (dtg.Rows.Count != 0)
                {
                    e.Text = dtg.Rows[0]["e"].ToString();
                    v.Text = dtg.Rows[0]["v"].ToString();
                    m.Text = dtg.Rows[0]["m"].ToString();
                    if (dtg.Rows[0]["t"].ToString() == "1")
                    {
                        v.Text = "T";
                    }
                    if (dtg.Rows[0]["et"].ToString() == "1")
                    {
                        v.Text = "ET";
                    }
                    gcs_tot.Text = dtg.Rows[0]["total"].ToString();

                    if (dtg.Rows[0]["cry"].ToString() == "1")
                    {
                        v.Text = "CRY";
                        gcs_tot.Text = "";
                    }
                    if (dtg.Rows[0]["spont"].ToString() == "1")
                    {
                        m.Text = "SPONT.";
                        gcs_tot.Text = "";
                    }
                }

                //infusion
                string query2 = "SELECT * FROM infusion_details where uhid= '" + Session["uhid"].ToString() + "' ";
                MySqlCommand cmd2 = new MySqlCommand(query2, sqlconn);
                DataTable dt2 = new DataTable();
                dt2.Load(cmd2.ExecuteReader());
                if (dt2.Rows.Count != 0)
                {
                    infusion1.Text = dt2.Rows[0]["infusion1"].ToString() + "@" + dt2.Rows[0]["quan1"].ToString() + " ml/hr";
                    infusion2.Text = dt2.Rows[0]["infusion2"].ToString() + "@" + dt2.Rows[0]["quan2"].ToString() + " ml/hr";
                    infusion3.Text = dt2.Rows[0]["infusion3"].ToString() + "@" + dt2.Rows[0]["quan3"].ToString() + " ml/hr";
                }

                //last 24I/O
                String d = DateTime.Now.ToString("yyyy-MM-dd");
                string last24 = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd");
                string query3 = "SELECT * FROM last_io where uhid= '" + Session["uhid"].ToString() + "' and (date='" + d + "' or date='" + last24 + "') order by date desc limit 1 ";
                MySqlCommand cmd3 = new MySqlCommand(query3, sqlconn);
                DataTable dt3 = new DataTable();
                dt3.Load(cmd3.ExecuteReader());
                if (dt3.Rows.Count != 0)
                {
                    i.Text = dt3.Rows[0]["i"].ToString();
                    o.Text = dt3.Rows[0]["o"].ToString();
                    drain.Text = dt3.Rows[0]["drain"].ToString() +" "+ dt3.Rows[0]["drain_comment"].ToString();
                }

                //ventilation
                string query4 = "SELECT * FROM ventilation_details where uhid= '" + Session["uhid"].ToString() + "' ";
                MySqlCommand cmd4 = new MySqlCommand(query4, sqlconn);
                DataTable dt4 = new DataTable();
                dt4.Load(cmd4.ExecuteReader());
                if (dt4.Rows.Count != 0)
                {
                    mode.Text = dt4.Rows[0]["mode"].ToString();
                    trach.Text = dt4.Rows[0]["trach"].ToString();
                    intubated.Text = dt4.Rows[0]["intubated"].ToString();
                    sedated.Text = dt4.Rows[0]["sedation"].ToString();
                    fio2.Text = dt4.Rows[0]["fio2"].ToString();
                    ps.Text =dt4.Rows[0]["Pressure"].ToString();
                }
                

                //surgery
                string query5 = "SELECT * FROM surgery_details where uhid= '" + Session["uhid"].ToString() + "' order by date desc";
                MySqlCommand cmd5 = new MySqlCommand(query5, sqlconn);
                DataTable dt5 = new DataTable();
                dt5.Load(cmd5.ExecuteReader());
                if (dt5.Rows.Count > 0)
                {
                    if( dt5.Rows[0]["surgeon1"].ToString() != "")
                    {
                        faculty.Text = dt5.Rows[0]["surgeon1"].ToString() + "/" + dt5.Rows[0]["surgeon2"].ToString();
                    }
                    else if(dt5.Rows[0]["surgeon2"].ToString() != "")
                    {
                        faculty.Text = dt5.Rows[0]["surgeon2"].ToString() + "/" + dt5.Rows[0]["surgeon1"].ToString();
                    }
                    else
                    {
                        faculty.Text = "__";
                    }

                    if (dt5.Rows[0]["sr1"].ToString() != "")
                    {
                        sr.Text = dt5.Rows[0]["sr1"].ToString() + "/" + dt5.Rows[0]["sr2"].ToString();
                    }
                    else if (dt5.Rows[0]["sr2"].ToString() != "")
                    {
                        sr.Text = dt5.Rows[0]["sr2"].ToString() + "/" + dt5.Rows[0]["sr1"].ToString();
                    }
                    else
                    {
                        sr.Text = "__";
                    }
                    //sr.Text = dt5.Rows[0]["sr1"].ToString() + "/" + dt5.Rows[0]["sr2"].ToString();

                    s_name1.Text = dt5.Rows[0]["surgery_name"].ToString();
                    dos1_date.Text = Convert.ToDateTime(dt5.Rows[0]["date"]).ToString("dd-MM-yyyy");
                    pod1_days.Text = Math.Ceiling((DateTime.Now - Convert.ToDateTime(dt5.Rows[0]["date"])).TotalDays) + " Days";
                }
                if (dt5.Rows.Count > 1)
                {
                    su2.Visible = true;
                    s_name2.Text = dt5.Rows[1]["surgery_name"].ToString();
                    dos2_date.Text = Convert.ToDateTime(dt5.Rows[1]["date"]).ToString("dd-MM-yyyy");
                    pod2_days.Text = Math.Ceiling((DateTime.Now - Convert.ToDateTime(dt5.Rows[1]["date"].ToString())).TotalDays) + " Days";
                }
                if (dt5.Rows.Count > 2)
                {
                    su3.Visible = true;
                    s_name3.Text = dt5.Rows[2]["surgery_name"].ToString();
                    dos3_date.Text = Convert.ToDateTime(dt5.Rows[2]["date"]).ToString("dd-MM-yyyy");
                    pod3_days.Text = Math.Ceiling((DateTime.Now - Convert.ToDateTime(dt5.Rows[2]["date"].ToString())).TotalDays) + " Days";
                }
                if (dt5.Rows.Count > 3)
                {
                    su4.Visible = true;
                    s_name4.Text = dt5.Rows[3]["surgery_name"].ToString();
                    dos4_date.Text = Convert.ToDateTime(dt5.Rows[3]["date"]).ToString("dd-MM-yyyy");
                    pod4_days.Text = Math.Ceiling((DateTime.Now - Convert.ToDateTime(dt5.Rows[3]["date"].ToString())).TotalDays) + " Days";
                }

                //fever pack
                string query6 = "SELECT * FROM fever_pack_details where uhid= '" + Session["uhid"].ToString() + "' order by date desc ";
                MySqlCommand cmd6 = new MySqlCommand(query6, sqlconn);
                DataTable dt6 = new DataTable();
                dt6.Load(cmd6.ExecuteReader());
                if (dt6.Rows.Count > 0)
                {
                    fp_date1.Text = Convert.ToDateTime(dt6.Rows[0]["date"]).ToString("dd-MM-yy");
                    fp_bld1.Text = dt6.Rows[0]["bld_cs"].ToString();
                    fp_trach1.Text = dt6.Rows[0]["trach_cs"].ToString();
                    fp_urine1.Text = dt6.Rows[0]["urine_cs"].ToString();
                    if (dt6.Rows[0]["urine_ph"].ToString() != "")
                    {
                        urine_ph1.Text = dt6.Rows[0]["urine_ph"].ToString();
                    }
                    else
                    {
                        urine_ph1.Text = "--";
                    }
                    urine_wbc1.Text = dt6.Rows[0]["urine_wbc"].ToString();
                }

                if (dt6.Rows.Count > 1)
                {
                    fp_date2.Text = Convert.ToDateTime(dt6.Rows[1]["date"]).ToString("dd-MM-yy");
                    fp_bld2.Text = dt6.Rows[1]["bld_cs"].ToString();
                    fp_trach2.Text = dt6.Rows[1]["trach_cs"].ToString();
                    fp_urine2.Text = dt6.Rows[1]["urine_cs"].ToString();
                    if (dt6.Rows[1]["urine_ph"].ToString() != "")
                    {
                        urine_ph2.Text = dt6.Rows[1]["urine_ph"].ToString();
                    }
                    else
                    {
                        urine_ph2.Text = "--";
                    }
                    urine_wbc2.Text = dt6.Rows[1]["urine_wbc"].ToString();
                }

                if (dt6.Rows.Count > 2)
                {
                    fp_date3.Text = Convert.ToDateTime(dt6.Rows[2]["date"]).ToString("dd-MM-yy");
                    fp_bld3.Text = dt6.Rows[2]["bld_cs"].ToString();
                    fp_trach3.Text = dt6.Rows[2]["trach_cs"].ToString();
                    fp_urine3.Text = dt6.Rows[2]["urine_cs"].ToString();
                    if (dt6.Rows[2]["urine_ph"].ToString() != "")
                    {
                        urine_ph3.Text = dt6.Rows[2]["urine_ph"].ToString();
                    }
                    else
                    {
                        urine_ph3.Text = "--";
                    }
                    urine_wbc3.Text = dt6.Rows[2]["urine_wbc"].ToString();
                }

                //lab_details
                string query71 = "SELECT * FROM lab_details where uhid= '" + Session["uhid"].ToString() + "' and test_name='HB' order by date desc";
                MySqlCommand cmd71 = new MySqlCommand(query71, sqlconn);
                DataTable dt71 = new DataTable();
                dt71.Load(cmd71.ExecuteReader());
                if (dt71.Rows.Count != 0)
                {
                    hb.Text = dt71.Rows[0]["result"].ToString();
                    hb_date.Text = Convert.ToDateTime(dt71.Rows[0]["date"].ToString()).ToString("dd-MM-yy");

                    DateTime hb_d = DateTime.ParseExact(dt71.Rows[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture);
                    hb_time.Text = hb_d.ToString("hh:mm tt");
                }
                else
                {
                    hb.Text = "--";
                }

                string query72 = "SELECT * FROM lab_details where uhid= '" + Session["uhid"].ToString() + "' and test_name='TLC' order by date desc";
                MySqlCommand cmd72 = new MySqlCommand(query72, sqlconn);
                DataTable dt72 = new DataTable();
                dt72.Load(cmd72.ExecuteReader());
                if (dt72.Rows.Count != 0)
                {
                    tlc.Text = dt72.Rows[0]["result"].ToString();
                    tlc_date.Text = Convert.ToDateTime(dt72.Rows[0]["date"].ToString()).ToString("dd-MM-yy");
                    //tlc_time.Text = dt72.Rows[0]["time"].ToString();

                    DateTime tlc_d = DateTime.ParseExact(dt72.Rows[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture);
                    tlc_time.Text = tlc_d.ToString("hh:mm tt");
                }
                else
                {
                    tlc.Text = "--";
                }

                string query73 = "SELECT * FROM lab_details where uhid= '" + Session["uhid"].ToString() + "' and test_name='G_Fasting' order by date desc";
                MySqlCommand cmd73 = new MySqlCommand(query73, sqlconn);
                DataTable dt73 = new DataTable();
                dt73.Load(cmd73.ExecuteReader());
                if (dt73.Rows.Count != 0)
                {
                    fasting.Text = dt73.Rows[0]["result"].ToString();
                    fasting_date.Text = Convert.ToDateTime(dt73.Rows[0]["date"].ToString()).ToString("dd-MM-yy");

                    DateTime f_d = DateTime.ParseExact(dt73.Rows[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture);
                    fasting_time.Text = f_d.ToString("hh:mm tt");
                }
                else
                {
                    fasting.Text = "--";
                }

                string query74 = "SELECT * FROM lab_details where uhid= '" + Session["uhid"].ToString() + "' and test_name='G_pp' order by date desc";
                MySqlCommand cmd74 = new MySqlCommand(query74, sqlconn);
                DataTable dt74 = new DataTable();
                dt74.Load(cmd74.ExecuteReader());
                if (dt74.Rows.Count != 0)
                {
                    pp.Text = dt74.Rows[0]["result"].ToString();
                    pp_date.Text = Convert.ToDateTime(dt74.Rows[0]["date"].ToString()).ToString("dd-MM-yy");
                    //pp_time.Text = dt74.Rows[0]["time"].ToString();
                    DateTime pp_d = DateTime.ParseExact(dt74.Rows[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture);
                    pp_time.Text = pp_d.ToString("hh:mm tt");
                }
                else
                {
                    pp.Text = "--";
                }

                string query75 = "SELECT * FROM lab_details where uhid= '" + Session["uhid"].ToString() + "' and test_name='Urea' order by date desc";
                MySqlCommand cmd75 = new MySqlCommand(query75, sqlconn);
                DataTable dt75 = new DataTable();
                dt75.Load(cmd75.ExecuteReader());
                if (dt75.Rows.Count != 0)
                {
                    urea.Text = dt75.Rows[0]["result"].ToString();
                    urea_date.Text = Convert.ToDateTime(dt75.Rows[0]["date"].ToString()).ToString("dd-MM-yy");
                    // urea_time.Text = dt75.Rows[0]["time"].ToString();
                    DateTime u_d = DateTime.ParseExact(dt75.Rows[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture);
                    urea_time.Text = u_d.ToString("hh:mm tt");
                }
                else
                {
                    urea.Text = "--";
                }

                string query76 = "SELECT * FROM lab_details where uhid= '" + Session["uhid"].ToString() + "' and test_name='Creatinine' order by date desc";
                MySqlCommand cmd76 = new MySqlCommand(query76, sqlconn);
                DataTable dt76 = new DataTable();
                dt76.Load(cmd76.ExecuteReader());
                if (dt76.Rows.Count != 0)
                {
                    creatnine.Text = dt76.Rows[0]["result"].ToString();
                    creat_date.Text = Convert.ToDateTime(dt76.Rows[0]["date"].ToString()).ToString("dd-MM-yy");
                    //creat_time.Text = dt76.Rows[0]["time"].ToString();
                    DateTime c_d = DateTime.ParseExact(dt76.Rows[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture);
                    creat_time.Text = c_d.ToString("hh:mm tt");
                }
                else
                {
                    creatnine.Text = "--";
                }

                string query77 = "SELECT * FROM lab_details where uhid= '" + Session["uhid"].ToString() + "' and test_name='NA' order by date desc";
                MySqlCommand cmd77 = new MySqlCommand(query77, sqlconn);
                DataTable dt77 = new DataTable();
                dt77.Load(cmd77.ExecuteReader());
                if (dt77.Rows.Count != 0)
                {
                    na.Text = dt77.Rows[0]["result"].ToString();
                    na_date.Text = Convert.ToDateTime(dt77.Rows[0]["date"].ToString()).ToString("dd-MM-yy");
                    //na_time.Text = dt77.Rows[0]["time"].ToString();
                    DateTime na_d = DateTime.ParseExact(dt77.Rows[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture);
                    na_time.Text = na_d.ToString("hh:mm tt");
                }
                else
                {
                    na.Text = "--";
                }

                string query78 = "SELECT * FROM lab_details where uhid= '" + Session["uhid"].ToString() + "' and test_name='K' order by date desc";
                MySqlCommand cmd78 = new MySqlCommand(query78, sqlconn);
                DataTable dt78 = new DataTable();
                dt78.Load(cmd78.ExecuteReader());
                if (dt78.Rows.Count != 0)
                {
                    k.Text = dt78.Rows[0]["result"].ToString();
                    k_date.Text = Convert.ToDateTime(dt78.Rows[0]["date"].ToString()).ToString("dd-MM-yy");
                    //k_time.Text = dt78.Rows[0]["time"].ToString();
                    DateTime k_d = DateTime.ParseExact(dt78.Rows[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture);
                    k_time.Text = k_d.ToString("hh:mm tt");
                }
                else
                {
                    k.Text = "--";
                }

                string query79 = "SELECT * FROM lab_details where uhid= '" + Session["uhid"].ToString() + "' and test_name='CSF_WBC' order by date desc";
                MySqlCommand cmd79 = new MySqlCommand(query79, sqlconn);
                DataTable dt79 = new DataTable();
                dt79.Load(cmd79.ExecuteReader());
                if (dt79.Rows.Count != 0)
                {
                    wbc.Text = dt79.Rows[0]["result"].ToString();
                    wbc_date.Text = Convert.ToDateTime(dt79.Rows[0]["date"].ToString()).ToString("dd-MM-yy");
                    //wbc_time.Text = dt79.Rows[0]["time"].ToString();
                    DateTime wbc_d = DateTime.ParseExact(dt79.Rows[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture);
                    wbc_time.Text = wbc_d.ToString("hh:mm tt");
                }
                else
                {
                    wbc.Text = "--";
                }

                string query710 = "SELECT * FROM lab_details where uhid= '" + Session["uhid"].ToString() + "' and test_name='CSF_RBC' order by date desc";
                MySqlCommand cmd710 = new MySqlCommand(query710, sqlconn);
                DataTable dt710 = new DataTable();
                dt710.Load(cmd710.ExecuteReader());
                if (dt710.Rows.Count != 0)
                {
                    rbc.Text = dt710.Rows[0]["result"].ToString();
                    rbc_date.Text = Convert.ToDateTime(dt710.Rows[0]["date"].ToString()).ToString("dd-MM-yy");
                    //rbc_time.Text = dt710.Rows[0]["time"].ToString();
                    DateTime rbc_d = DateTime.ParseExact(dt710.Rows[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture);
                    rbc_time.Text = rbc_d.ToString("hh:mm tt");
                }
                else
                {
                    rbc.Text = "--";
                }

                string query711 = "SELECT * FROM lab_details where uhid= '" + Session["uhid"].ToString() + "' and test_name='CSF_Sugar' order by date desc";
                MySqlCommand cmd711 = new MySqlCommand(query711, sqlconn);
                DataTable dt711 = new DataTable();
                dt711.Load(cmd711.ExecuteReader());
                if (dt711.Rows.Count != 0)
                {
                    csf_sugar.Text = dt711.Rows[0]["result"].ToString();
                    csf_sugar_date.Text = Convert.ToDateTime(dt711.Rows[0]["date"].ToString()).ToString("dd-MM-yy");
                    //csf_sugar_time.Text = dt711.Rows[0]["time"].ToString();
                    DateTime cs_d = DateTime.ParseExact(dt711.Rows[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture);
                    csf_sugar_time.Text = cs_d.ToString("hh:mm tt");
                }
                else
                {
                    csf_sugar.Text = "--";
                }

                //vital_details
                string query81 = "SELECT * FROM vital_details where uhid= '" + Session["uhid"].ToString() + "'  order by date desc";
                MySqlCommand cmd81 = new MySqlCommand(query81, sqlconn);
                DataTable dt81 = new DataTable();
                dt81.Load(cmd81.ExecuteReader());
                if (dt81.Rows.Count != 0)
                {
                    DateTime v_d = DateTime.ParseExact(dt81.Rows[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture);

                    v_date.Text= Convert.ToDateTime(dt81.Rows[0]["date"].ToString()).ToString("dd-MM-yy");
                    v_time.Text= v_d.ToString("hh:mm tt");

                    rr.Text = dt81.Rows[0]["rr"].ToString();
                    //rr_date.Text = Convert.ToDateTime(dt81.Rows[0]["date"].ToString()).ToString("dd-MM-yy");
                    //rr_time.Text = dt81.Rows[0]["time"].ToString();
                    //rr_time.Text = v_d.ToString("hh:mm tt");

                    spo2.Text = dt81.Rows[0]["spo2"].ToString();
                    //spo2_date.Text = Convert.ToDateTime(dt81.Rows[0]["date"].ToString()).ToString("dd-MM-yy");
                    //spo2_time.Text = dt81.Rows[0]["time"].ToString();
                    //DateTime spo2_d = DateTime.ParseExact(dt81.Rows[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture);
                    //spo2_time.Text = v_d.ToString("hh:mm tt");

                    pulse.Text = dt81.Rows[0]["pulse"].ToString();
                    //pulse_date.Text = Convert.ToDateTime(dt81.Rows[0]["date"].ToString()).ToString("dd-MM-yy");
                    //pulse_time.Text = v_d.ToString("hh:mm tt");

                    temp.Text = dt81.Rows[0]["temp"].ToString();
                    //temp_date.Text = Convert.ToDateTime(dt81.Rows[0]["date"].ToString()).ToString("dd-MM-yy");
                    //temp_time.Text = v_d.ToString("hh:mm tt");

                    bp.Text = dt81.Rows[0]["bp"].ToString();
                    //bp_date.Text = Convert.ToDateTime(dt81.Rows[0]["date"].ToString()).ToString("dd-MM-yy");
                    //bp_time.Text = v_d.ToString("hh:mm tt");

                    icp.Text = dt81.Rows[0]["icp"].ToString();
                    //icp_date.Text = Convert.ToDateTime(dt81.Rows[0]["date"].ToString()).ToString("dd-MM-yy");
                    //icp_time.Text = v_d.ToString("hh:mm tt");
                }

                //plan

                DateTime dateValue = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
                string now = dateValue.ToString("yyyy-MM-dd");

                string query9 = "SELECT * FROM plan_details where uhid= '" + Session["uhid"].ToString() + "' and date='" + now + "' ";
                MySqlCommand cmd9 = new MySqlCommand(query9, sqlconn);
                DataTable dt9 = new DataTable();
                dt9.Load(cmd9.ExecuteReader());
                if (dt9.Rows.Count != 0)
                {
                    ct_today.Text = dt9.Rows[0]["ct"].ToString() + "," + dt9.Rows[0]["ct_part"].ToString() + "," + dt9.Rows[0]["ct_finding"].ToString();
                    x_today.Text = dt9.Rows[0]["xray"].ToString() + "," + dt9.Rows[0]["xray_part"].ToString();
                    mri_today.Text = dt9.Rows[0]["mri"].ToString() + "," + dt9.Rows[0]["mri_part"].ToString();
                    usd_today.Text = dt9.Rows[0]["usd"].ToString() + "," + dt9.Rows[0]["usd_part"].ToString();
                    other_today.Text = dt9.Rows[0]["other"].ToString();
                }                
                sqlconn.Close();
            }
            catch (Exception e)
            {
                
            }
        }

        void get_pt_details1()
        {
            try
            {
                //String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                //MySqlConnection sqlconn = new MySqlConnection(con);
                //sqlconn.Open();

                DataTable dataTable = Cache["'"+ Session["username"].ToString()+"'last_pts"] as DataTable;
                DataRow[] dt = dataTable.Select("uhid = '" + Session["uhid"].ToString() + "'");

                if (dt.Length != 0)
                {
                    uhid.Text = dt[0]["uhid"].ToString();
                    p_name.Text = dt[0]["fname"].ToString() + " " + dt[0]["lname"].ToString();

                    // tb_dob.Text = Convert.ToDateTime(dt.Rows[0]["dob"]).ToString("dd-MM-yyyy");
                    doa.Text = Convert.ToDateTime(dt[0]["date_admit"]).ToString("dd-MM-yyyy");
                    bld_grp.Text = dt[0]["bld_grp"].ToString();
                    bld_donated.Text = dt[0]["bld_donated"].ToString() + " Unit";
                    diag1.Text = dt[0]["diag1"].ToString();
                    if (dt[0]["diag2"].ToString() != "")
                    {
                        d2.Visible = true;
                        diag2.Text = dt[0]["diag2"].ToString();
                    }
                    else
                    {
                        d2.Visible = false;
                    }
                    if (dt[0]["diag3"].ToString() != "")
                    {
                        d3.Visible = true;
                        diag3.Text = dt[0]["diag3"].ToString();
                    }
                    else
                    {
                        d3.Visible = false;
                    }
                    ward.Text = dt[0]["ward"].ToString();
                    bed.Text = dt[0]["bed"].ToString();

                    double days = (DateTime.Now - Convert.ToDateTime(dt[0]["date_admit"])).TotalDays;
                    los.Text = Math.Ceiling(days) + " Days";

                    int age;
                    DateTime _age = new DateTime();
                    _age = Convert.ToDateTime(dt[0]["dob"].ToString());
                    age = DateTime.Now.Year - _age.Year;
                    if (DateTime.Now.DayOfYear < _age.DayOfYear)
                    {
                        age = age - 1;
                    }
                    age_sex.Text = age.ToString() + "/" + dt[0]["sex"].ToString();
                }

                //gcs
                DataTable gcs_dt = Cache["'" + Session["username"].ToString() + "'gcs"] as DataTable;
                DataRow[] dtg = gcs_dt.Select("uhid = '" + Session["uhid"].ToString() + "' ");
                if (dtg.Length != 0)
                {
                    e.Text = dtg[0]["e"].ToString();
                    v.Text = dtg[0]["v"].ToString();
                    m.Text = dtg[0]["m"].ToString();
                    if (dtg[0]["t"].ToString() == "1")
                    {
                        v.Text = "T";
                    }
                    if (dtg[0]["et"].ToString() == "1")
                    {
                        v.Text = "ET";
                    }
                    gcs_tot.Text = dtg[0]["total"].ToString();

                    if (dtg[0]["cry"].ToString() == "1")
                    {
                        v.Text = "CRY";
                        gcs_tot.Text = "";
                    }
                    if (dtg[0]["spont"].ToString() == "1")
                    {
                        m.Text = "SPONT.";
                        gcs_tot.Text = "";
                    }
                }

                //infusion
                DataTable infusion_dt =Cache["'" + Session["username"].ToString() + "'infusion"] as DataTable;
                DataRow[] dt2 = infusion_dt.Select("uhid = '" + Session["uhid"].ToString() + "' ");
                if (dt2.Length != 0)
                {
                    infusion1.Text = dt2[0]["infusion1"].ToString() + "@" + dt2[0]["quan1"].ToString() + " ml/hr";
                    infusion2.Text = dt2[0]["infusion2"].ToString() + "@" + dt2[0]["quan2"].ToString() + " ml/hr";
                    infusion3.Text = dt2[0]["infusion3"].ToString() + "@" + dt2[0]["quan3"].ToString() + " ml/hr";
                }

                //last 24I/O
                DataTable io_dt = Cache["'" + Session["username"].ToString() + "'io"] as DataTable;
                DataRow[] dt3 = io_dt.Select("uhid = '" + Session["uhid"].ToString() + "' ");

                if (dt3.Length != 0)
                {
                    i.Text = dt3[0]["i"].ToString();
                    o.Text = dt3[0]["o"].ToString();
                    drain.Text = dt3[0]["drain"].ToString()+" " + dt3[0]["drain_comment"].ToString();
                }

                //ventilation
                DataTable ventilation_dt = Cache["'" + Session["username"].ToString() + "'ventilation"] as DataTable;
                DataRow[] dt4 = ventilation_dt.Select("uhid = '" + Session["uhid"].ToString() + "' ");
                if (dt4.Length != 0)
                {
                    mode.Text = dt4[0]["mode"].ToString();
                    trach.Text = dt4[0]["trach"].ToString();
                    intubated.Text = dt4[0]["intubated"].ToString();
                    sedated.Text = dt4[0]["sedation"].ToString();
                    fio2.Text = dt4[0]["fio2"].ToString();
                    ps.Text = dt4[0]["Pressure"].ToString();
                }

                //surgery
                DataTable surgery_dt =Cache["'" + Session["username"].ToString() + "'surgery"] as DataTable;
                DataRow[] dt5 = surgery_dt.Select("uhid = '" + Session["uhid"].ToString() + "' ");
                if (dt5.Length > 0)
                {
                    //faculty.Text = dt5[0]["surgeon1"].ToString() + "/" + dt5[0]["surgeon2"].ToString();
                    // sr.Text = dt5[0]["sr1"].ToString() + "/" + dt5[0]["sr2"].ToString();

                    if (dt5[0]["surgeon1"].ToString() != "")
                    {
                        faculty.Text = dt5[0]["surgeon1"].ToString() + "/" + dt5[0]["surgeon2"].ToString();
                    }
                    else if (dt5[0]["surgeon2"].ToString() != "")
                    {
                        faculty.Text = dt5[0]["surgeon2"].ToString() + "/" + dt5[0]["surgeon1"].ToString();
                    }
                    else
                    {
                        faculty.Text = "__";
                    }

                    if (dt5[0]["sr1"].ToString() != "")
                    {
                        sr.Text = dt5[0]["sr1"].ToString() + "/" + dt5[0]["sr2"].ToString();
                    }
                    else if (dt5[0]["sr2"].ToString() != "")
                    {
                        sr.Text = dt5[0]["sr2"].ToString() + "/" + dt5[0]["sr1"].ToString();
                    }
                    else
                    {
                        sr.Text = "__";
                    }


                    s_name1.Text = dt5[0]["surgery_name"].ToString();
                    dos1_date.Text = Convert.ToDateTime(dt5[0]["date"]).ToString("dd-MM-yyyy");
                    pod1_days.Text = Math.Ceiling((DateTime.Now - Convert.ToDateTime(dt5[0]["date"])).TotalDays) + " Days";
                }
                if (dt5.Length > 1)
                {
                    su2.Visible = true;
                    s_name2.Text = dt5[1]["surgery_name"].ToString();
                    dos2_date.Text = Convert.ToDateTime(dt5[1]["date"]).ToString("dd-MM-yyyy");
                    pod2_days.Text = Math.Ceiling((DateTime.Now - Convert.ToDateTime(dt5[1]["date"].ToString())).TotalDays) + " Days";
                }
                if (dt5.Length > 2)
                {
                    su3.Visible = true;
                    s_name3.Text = dt5[2]["surgery_name"].ToString();
                    dos3_date.Text = Convert.ToDateTime(dt5[2]["date"]).ToString("dd-MM-yyyy");
                    pod3_days.Text = Math.Ceiling((DateTime.Now - Convert.ToDateTime(dt5[2]["date"].ToString())).TotalDays) + " Days";
                }
                if (dt5.Length > 3)
                {
                    su4.Visible = true;
                    s_name4.Text = dt5[3]["surgery_name"].ToString();
                    dos4_date.Text = Convert.ToDateTime(dt5[3]["date"]).ToString("dd-MM-yyyy");
                    pod4_days.Text = Math.Ceiling((DateTime.Now - Convert.ToDateTime(dt5[3]["date"].ToString())).TotalDays) + " Days";
                }

                //fever pack
                DataTable fever_dt = Cache["'" + Session["username"].ToString() + "'fever"] as DataTable;
                DataRow[] dt6 = fever_dt.Select("uhid = '" + Session["uhid"].ToString() + "' ");
                if (dt6.Length > 0)
                {
                    fp_date1.Text = Convert.ToDateTime(dt6[0]["date"]).ToString("dd-MM-yy");
                    fp_bld1.Text = dt6[0]["bld_cs"].ToString();
                    fp_trach1.Text = dt6[0]["trach_cs"].ToString();
                    fp_urine1.Text = dt6[0]["urine_cs"].ToString();
                    if (dt6[0]["urine_ph"].ToString() != "")
                    {
                        urine_ph1.Text = dt6[0]["urine_ph"].ToString();
                    }
                    else
                    {
                        urine_ph1.Text = "--";
                    }
                    urine_wbc1.Text = dt6[0]["urine_wbc"].ToString();
                }

                if (dt6.Length > 1)
                {
                    fp_date2.Text = Convert.ToDateTime(dt6[1]["date"]).ToString("dd-MM-yy");
                    fp_bld2.Text = dt6[1]["bld_cs"].ToString();
                    fp_trach2.Text = dt6[1]["trach_cs"].ToString();
                    fp_urine2.Text = dt6[1]["urine_cs"].ToString();
                    if (dt6[1]["urine_ph"].ToString() != "")
                    {
                        urine_ph2.Text = dt6[1]["urine_ph"].ToString();
                    }
                    else
                    {
                        urine_ph2.Text = "--";
                    }
                    urine_wbc2.Text = dt6[1]["urine_wbc"].ToString();
                }

                if (dt6.Length > 2)
                {
                    fp_date3.Text = Convert.ToDateTime(dt6[2]["date"]).ToString("dd-MM-yy");
                    fp_bld3.Text = dt6[2]["bld_cs"].ToString();
                    fp_trach3.Text = dt6[2]["trach_cs"].ToString();
                    fp_urine3.Text = dt6[2]["urine_cs"].ToString();
                    if (dt6[2]["urine_ph"].ToString() != "")
                    {
                        urine_ph3.Text = dt6[2]["urine_ph"].ToString();
                    }
                    else
                    {
                        urine_ph3.Text = "--";
                    }
                    urine_wbc3.Text = dt6[2]["urine_wbc"].ToString();
                }

                //lab_details
                DataTable lab_dt = Cache["'" + Session["username"].ToString() + "'lab"] as DataTable;
                DataRow[] dt71 = lab_dt.Select("uhid = '" + Session["uhid"].ToString() + "' and test_name='HB' ");
                if (dt71.Length != 0)
                {
                    hb.Text = dt71[0]["result"].ToString();
                    hb_date.Text = Convert.ToDateTime(dt71[0]["date"].ToString()).ToString("dd-MM-yy");

                    DateTime hb_d = DateTime.ParseExact(dt71[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture);
                    hb_time.Text = hb_d.ToString("hh:mm tt");
                }
                else
                {
                    hb.Text = "--";
                }

                DataRow[] dt72 = lab_dt.Select("uhid = '" + Session["uhid"].ToString() + "' and test_name='TLC' ");
                if (dt72.Length != 0)
                {
                    tlc.Text = dt72[0]["result"].ToString();
                    tlc_date.Text = Convert.ToDateTime(dt72[0]["date"].ToString()).ToString("dd-MM-yy");
                    //tlc_time.Text = dt72[0]["time"].ToString();
                    DateTime tlc_d = DateTime.ParseExact(dt72[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture);
                    tlc_time.Text = tlc_d.ToString("hh:mm tt");
                }
                else
                {
                    tlc.Text = "--";
                }
                                
                DataRow[] dt73 = lab_dt.Select("uhid = '" + Session["uhid"].ToString() + "' and test_name='G_Fasting' ");
                if (dt73.Length != 0)
                {
                    fasting.Text = dt73[0]["result"].ToString();
                    fasting_date.Text = Convert.ToDateTime(dt73[0]["date"].ToString()).ToString("dd-MM-yy");
                    //fasting_time.Text = dt73[0]["time"].ToString();
                    DateTime f_d = DateTime.ParseExact(dt73[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture);
                    fasting_time.Text = f_d.ToString("hh:mm tt");
                }
                else
                {
                    fasting.Text = "--";
                }

                DataRow[] dt74 = lab_dt.Select("uhid = '" + Session["uhid"].ToString() + "' and test_name='G_pp' ");
                if (dt74.Length != 0)
                {
                    pp.Text = dt74[0]["result"].ToString();
                    pp_date.Text = Convert.ToDateTime(dt74[0]["date"].ToString()).ToString("dd-MM-yy");
                    //pp_time.Text = dt74[0]["time"].ToString();
                    DateTime p_d = DateTime.ParseExact(dt74[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture);
                    pp_time.Text = p_d.ToString("hh:mm tt");
                }
                else
                {
                    pp.Text = "--";
                }

                DataRow[] dt75 = lab_dt.Select("uhid = '" + Session["uhid"].ToString() + "' and test_name='Urea' ");
                if (dt75.Length != 0)
                {
                    urea.Text = dt75[0]["result"].ToString();
                    urea_date.Text = Convert.ToDateTime(dt75[0]["date"].ToString()).ToString("dd-MM-yy");
                    //urea_time.Text = dt75[0]["time"].ToString();
                    DateTime u_d = DateTime.ParseExact(dt75[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture);
                    urea_time.Text = u_d.ToString("hh:mm tt");
                }
                else
                {
                    urea.Text = "--";
                }

                DataRow[] dt76 = lab_dt.Select("uhid = '" + Session["uhid"].ToString() + "' and test_name='Creatinine' ");
                if (dt76.Length != 0)
                {
                    creatnine.Text = dt76[0]["result"].ToString();
                    creat_date.Text = Convert.ToDateTime(dt76[0]["date"].ToString()).ToString("dd-MM-yy");
                    //creat_time.Text = dt76[0]["time"].ToString();
                    DateTime c_d = DateTime.ParseExact(dt76[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture);
                    creat_time.Text = c_d.ToString("hh:mm tt");
                }
                else
                {
                    creatnine.Text = "--";
                }

                DataRow[] dt77 = lab_dt.Select("uhid = '" + Session["uhid"].ToString() + "' and test_name='NA' ");
                if (dt77.Length != 0)
                {
                    na.Text = dt77[0]["result"].ToString();
                    na_date.Text = Convert.ToDateTime(dt77[0]["date"].ToString()).ToString("dd-MM-yy");
                    //na_time.Text = dt77[0]["time"].ToString();
                    DateTime na_d = DateTime.ParseExact(dt77[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture);
                    na_time.Text = na_d.ToString("hh:mm tt");
                }
                else
                {
                    na.Text = "--";
                }

                DataRow[] dt78 = lab_dt.Select("uhid = '" + Session["uhid"].ToString() + "' and test_name='K' ");
                if (dt78.Length != 0)
                {
                    k.Text = dt78[0]["result"].ToString();
                    k_date.Text = Convert.ToDateTime(dt78[0]["date"].ToString()).ToString("dd-MM-yy");
                    //k_time.Text = dt78[0]["time"].ToString();
                    DateTime k_d = DateTime.ParseExact(dt78[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture);
                    k_time.Text = k_d.ToString("hh:mm tt");
                }
                else
                {
                    k.Text = "--";
                }

                DataRow[] dt79 = lab_dt.Select("uhid = '" + Session["uhid"].ToString() + "' and test_name='CSF_WBC' ");
                if (dt79.Length != 0)
                {
                    wbc.Text = dt79[0]["result"].ToString();
                    wbc_date.Text = Convert.ToDateTime(dt79[0]["date"].ToString()).ToString("dd-MM-yy");
                    //wbc_time.Text = dt79[0]["time"].ToString();
                    DateTime w_d = DateTime.ParseExact(dt79[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture);
                    wbc_time.Text = w_d.ToString("hh:mm tt");
                }
                else
                {
                    wbc.Text = "--";
                }

                DataRow[] dt710 = lab_dt.Select("uhid = '" + Session["uhid"].ToString() + "' and test_name='CSF_RBC' ");
                if (dt710.Length != 0)
                {
                    rbc.Text = dt710[0]["result"].ToString();
                    rbc_date.Text = Convert.ToDateTime(dt710[0]["date"].ToString()).ToString("dd-MM-yy");
                    //rbc_time.Text = dt710[0]["time"].ToString();
                    DateTime r_d = DateTime.ParseExact(dt710[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture);
                    rbc_time.Text = r_d.ToString("hh:mm tt");
                }
                else
                {
                    rbc.Text = "--";
                }

                DataRow[] dt711 = lab_dt.Select("uhid = '" + Session["uhid"].ToString() + "' and test_name='CSF_Sugar' ");
                if (dt711.Length != 0)
                {
                    csf_sugar.Text = dt711[0]["result"].ToString();
                    csf_sugar_date.Text = Convert.ToDateTime(dt711[0]["date"].ToString()).ToString("dd-MM-yy");
                    //csf_sugar_time.Text = dt711[0]["time"].ToString();
                    DateTime cs_d = DateTime.ParseExact(dt711[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture);
                    csf_sugar_time.Text = cs_d.ToString("hh:mm tt");
                }
                else
                {
                    csf_sugar.Text = "--";
                }

                DataTable vital_dt = Cache["'" + Session["username"].ToString() + "'vital"] as DataTable;
                DataRow[] dt81 = vital_dt.Select("uhid = '" + Session["uhid"].ToString() + "' ");

                if (dt81.Length != 0)
                {
                    DateTime v_d = DateTime.ParseExact(dt81[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture);

                    v_date.Text = Convert.ToDateTime(dt81[0]["date"].ToString()).ToString("dd-MM-yy");
                    v_time.Text = v_d.ToString("hh:mm tt");

                    rr.Text = dt81[0]["rr"].ToString();
                    //rr_date.Text = Convert.ToDateTime(dt81[0]["date"].ToString()).ToString("dd-MM-yy");
                   // rr_time.Text = dt81[0]["time"].ToString();

                    spo2.Text = dt81[0]["spo2"].ToString();
                    //spo2_date.Text = Convert.ToDateTime(dt81[0]["date"].ToString()).ToString("dd-MM-yy");
                   // spo2_time.Text = dt81[0]["time"].ToString();

                    pulse.Text = dt81[0]["pulse"].ToString();
                   // pulse_date.Text = Convert.ToDateTime(dt81[0]["date"].ToString()).ToString("dd-MM-yy");
                    //pulse_time.Text = dt81[0]["time"].ToString();

                    temp.Text = dt81[0]["temp"].ToString();
                    //temp_date.Text = Convert.ToDateTime(dt81[0]["date"].ToString()).ToString("dd-MM-yy");
                   // temp_time.Text = dt81[0]["time"].ToString();

                    bp.Text = dt81[0]["bp"].ToString();
                    //bp_date.Text = Convert.ToDateTime(dt81[0]["date"].ToString()).ToString("dd-MM-yy");
                    //bp_time.Text = dt81[0]["time"].ToString();

                    icp.Text = dt81[0]["icp"].ToString();
                    //icp_date.Text = Convert.ToDateTime(dt81[0]["date"].ToString()).ToString("dd-MM-yy");
                    //icp_time.Text = dt81[0]["time"].ToString();
                }

                //plan
                
                DateTime dateValue = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
                string now = dateValue.ToString("yyyy-MM-dd");

                DataTable plan_dt = Cache["'" + Session["username"].ToString() + "'plan"] as DataTable;
                DataRow[] dt9 = plan_dt.Select("uhid = '" + Session["uhid"].ToString() + "' and date='" + now + "' ");
                if (dt9.Length != 0)
                {
                    ct_today.Text = dt9[0]["ct"].ToString() + "," + dt9[0]["ct_part"].ToString() + "," + dt9[0]["ct_finding"].ToString();
                    x_today.Text = dt9[0]["xray"].ToString() + "," + dt9[0]["xray_part"].ToString();
                    mri_today.Text = dt9[0]["mri"].ToString() + "," + dt9[0]["mri_part"].ToString();
                    usd_today.Text = dt9[0]["usd"].ToString() + "," + dt9[0]["usd_part"].ToString();
                    other_today.Text = dt9[0]["other"].ToString();
                }
            //sqlconn.Close();
        }
            catch (Exception e)
            {

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

                    dt.Columns.Add("dot_color", typeof(String));
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["till_date"].ToString() == "")
                        {
                            row["dot_color"] = "Images/red_dot.png"; //active
                        }
                        else
                        {
                            row["dot_color"] = "Images/yellow_dot.png";
                        }
                    }
                    gv1.DataSource = dt;
                    gv1.DataBind();
                }
            }
            sqlconn.Close();
        }

        void fill_issues1()
        {
            DataTable issue_dt = Cache["'" + Session["username"].ToString() + "'issues"] as DataTable;
            if(issue_dt.Rows.Count>0)
            {
                DataRow[] dt1 = issue_dt.Select("uhid = '" + Session["uhid"].ToString() + "' ");
                if(dt1.Any())
                {
                    DataTable dt = dt1.CopyToDataTable();

                    dt.Columns.Add("dot_color", typeof(String));
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["till_date"].ToString() == "")
                        {
                            row["dot_color"] = "Images/red_dot.png"; //active
                        }
                        else
                        {
                            row["dot_color"] = "Images/yellow_dot.png";
                        }
                    }
                    gv1.DataSource = dt;
                    gv1.DataBind();
                }                
            }
        }
        void add_to_gallery()
        {
            if (Session["uhid"] != null)
            {
                try
                {
                    String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                    MySqlConnection sqlconn = new MySqlConnection(con);

                    sqlconn.Open();

                    string queryd = "SELECT * FROM documents where uhid= '" + Session["uhid"].ToString() + "' and type='Discharge Summary' order by date desc ";
                    MySqlCommand cmdd = new MySqlCommand(queryd, sqlconn);
                    DataTable dtd = new DataTable();
                    dtd.Load(cmdd.ExecuteReader());
                    if (dtd.Rows.Count > 0)
                    {
                        discharge.Visible = true;
                        dis_img1.Visible = true;
                       // dis_img1.ImageUrl = dtd.Rows[0]["path"].ToString();
                        dis_date.Text = Convert.ToDateTime(dtd.Rows[0]["date"]).ToString("dd-MM-yy");

                        DateTime dtd_d = DateTime.ParseExact(dtd.Rows[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture);
                        dis_time.Text = dtd_d.ToString("hh:mm tt");
                        //dis_time.Text = dtd.Rows[0]["time"].ToString();

                        if (dtd.Rows[0]["path"].ToString().EndsWith(".pdf"))
                        {
                            s1 = dtd.Rows[0]["path"].ToString();
                            dis_img1.ImageUrl = "Images/pdf.png";                            
                        }
                        else
                        {
                            dis_img1.ImageUrl = dtd.Rows[0]["path"].ToString();
                        }
                    }

                    string query = "SELECT * FROM documents where uhid= '" + Session["uhid"].ToString() + "' and type='xray' order by date desc ";
                    MySqlCommand cmd = new MySqlCommand(query, sqlconn);
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    if (dt.Rows.Count > 0)
                    {
                        xray.Visible = true;
                        x_img1.Visible = true;
                        x_img1.Src = dt.Rows[0]["path"].ToString();
                        x_date1.Text = Convert.ToDateTime(dt.Rows[0]["date"]).ToString("dd-MM-yy");
                        //x_time1.Text = dt.Rows[0]["time"].ToString();
                        DateTime x_d = DateTime.ParseExact(dt.Rows[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture);
                        x_time1.Text = x_d.ToString("hh:mm tt");
                    }
                    if (dt.Rows.Count > 1)
                    {
                        x_img2.Visible = true;
                        x_img2.Src = dt.Rows[1]["path"].ToString();
                        x_date2.Text = Convert.ToDateTime(dt.Rows[1]["date"]).ToString("dd-MM-yy");
                        //x_time2.Text = dt.Rows[1]["time"].ToString();
                        DateTime x_d2 = DateTime.ParseExact(dt.Rows[1]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture);
                        x_time2.Text = x_d2.ToString("hh:mm tt");
                    }
                    if (dt.Rows.Count > 2)
                    {
                        x_img3.Visible = true;
                        x_img3.Src = dt.Rows[2]["path"].ToString();
                        x_date3.Text = Convert.ToDateTime(dt.Rows[2]["date"]).ToString("dd-MM-yy");
                        //x_time3.Text = dt.Rows[2]["time"].ToString();
                        DateTime x_d3 = DateTime.ParseExact(dt.Rows[2]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture);
                        x_time3.Text = x_d3.ToString("hh:mm tt");
                    }

                    string query1 = "SELECT * FROM documents where uhid= '" + Session["uhid"].ToString() + "' and type='CT Head' order by date desc ";
                    MySqlCommand cmd1 = new MySqlCommand(query1, sqlconn);
                    DataTable dt1 = new DataTable();
                    dt1.Load(cmd1.ExecuteReader());
                    if (dt1.Rows.Count > 0)
                    {
                        ct_head.Visible = true;

                        if (dt1.Rows[0]["path"].ToString().EndsWith(".mp4"))
                        {
                            ct_h_vid1.Visible = true;
                            ct_h_vid1.Src = dt1.Rows[0]["path"].ToString();
                        }
                        else
                        {
                            ct_h_img1.Visible = true;
                            ct_h_img1.Src = dt1.Rows[0]["path"].ToString();
                        }
                        ct_h_date1.Text = Convert.ToDateTime(dt1.Rows[0]["date"]).ToString("dd-MM-yy");
                        // ct_h_time1.Text = dt1.Rows[0]["time"].ToString();
                        //DateTime ct_h_d3 = DateTime.ParseExact(dt1.Rows[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture);
                        ct_h_time1.Text = DateTime.ParseExact(dt1.Rows[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    if (dt1.Rows.Count > 1)
                    {
                        if (dt1.Rows[1]["path"].ToString().EndsWith(".mp4"))
                        {
                            ct_h_vid2.Visible = true;
                            ct_h_vid2.Src = dt1.Rows[1]["path"].ToString();
                        }
                        else
                        {
                            ct_h_img2.Visible = true;
                            ct_h_img2.Src = dt1.Rows[1]["path"].ToString();
                        }
                        ct_h_date2.Text = Convert.ToDateTime(dt1.Rows[1]["date"]).ToString("dd-MM-yy");
                        ct_h_time2.Text = DateTime.ParseExact(dt1.Rows[1]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    if (dt1.Rows.Count > 2)
                    {
                        if (dt1.Rows[2]["path"].ToString().EndsWith(".mp4"))
                        {
                            ct_h_vid3.Visible = true;
                            ct_h_vid3.Src = dt1.Rows[2]["path"].ToString();
                        }
                        else
                        {
                            ct_h_img3.Visible = true;
                            ct_h_img3.Src = dt1.Rows[2]["path"].ToString();
                        }
                        ct_h_date3.Text = Convert.ToDateTime(dt1.Rows[2]["date"]).ToString("dd-MM-yy");
                        ct_h_time3.Text = DateTime.ParseExact(dt1.Rows[2]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }

                    string query2 = "SELECT * FROM documents where uhid= '" + Session["uhid"].ToString() + "' and type='CT Spinal' order by date desc ";
                    MySqlCommand cmd2 = new MySqlCommand(query2, sqlconn);
                    DataTable dt2 = new DataTable();
                    dt2.Load(cmd2.ExecuteReader());
                    if (dt2.Rows.Count > 0)
                    {
                        ct_spinal.Visible = true;

                        if (dt2.Rows[0]["path"].ToString().EndsWith(".mp4"))
                        {
                            ct_s_vid1.Visible = true;
                            ct_s_vid1.Src = dt2.Rows[0]["path"].ToString();
                        }
                        else
                        {
                            ct_s_img1.Visible = true;
                            ct_s_img1.Src = dt2.Rows[0]["path"].ToString();
                        }
                        ct_s_date1.Text = Convert.ToDateTime(dt2.Rows[0]["date"]).ToString("dd-MM-yy");
                        ct_s_time1.Text = DateTime.ParseExact(dt2.Rows[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    if (dt2.Rows.Count > 1)
                    {
                        if (dt2.Rows[1]["path"].ToString().EndsWith(".mp4"))
                        {
                            ct_s_vid2.Visible = true;
                            ct_s_vid2.Src = dt2.Rows[1]["path"].ToString();
                        }
                        else
                        {
                            ct_s_img2.Visible = true;
                            ct_s_img2.Src = dt2.Rows[1]["path"].ToString();
                        }
                        ct_s_date2.Text = Convert.ToDateTime(dt2.Rows[1]["date"]).ToString("dd-MM-yy");
                        ct_s_time2.Text = DateTime.ParseExact(dt2.Rows[1]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    else
                    {
                        ct_s_img2.Src = "";
                    }
                    if (dt2.Rows.Count > 2)
                    {
                        if (dt2.Rows[2]["path"].ToString().EndsWith(".mp4"))
                        {
                            ct_s_vid3.Visible = true;
                            ct_s_vid3.Src = dt2.Rows[2]["path"].ToString();
                        }
                        else
                        {
                            ct_s_img3.Visible = true;
                            ct_s_img3.Src = dt2.Rows[2]["path"].ToString();
                        }
                        ct_s_date3.Text = Convert.ToDateTime(dt2.Rows[2]["date"]).ToString("dd-MM-yy");
                        ct_s_time3.Text = DateTime.ParseExact(dt2.Rows[2]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    else
                    {
                        ct_s_img3.Src = "";
                    }

                    string query3 = "SELECT * FROM documents where uhid= '" + Session["uhid"].ToString() + "' and type='Nursing Notes' order by date desc ";
                    MySqlCommand cmd3 = new MySqlCommand(query3, sqlconn);
                    DataTable dt3 = new DataTable();
                    dt3.Load(cmd3.ExecuteReader());
                    if (dt3.Rows.Count > 0)
                    {
                        nursing.Visible = true;
                        n_img1.Visible = true;
                        //s3 = dt.Rows[0]["path"].ToString();
                        n_img1.Src = dt3.Rows[0]["path"].ToString();
                        n_date1.Text = Convert.ToDateTime(dt3.Rows[0]["date"]).ToString("dd-MM-yy");
                        n_time1.Text = DateTime.ParseExact(dt3.Rows[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    else
                    {
                        n_img1.Src = "";
                        n_img2.Src = "";
                        n_img3.Src = "";
                    }
                    if (dt3.Rows.Count > 1)
                    {
                        n_img2.Visible = true;
                        //s3 = dt.Rows[0]["path"].ToString();
                        n_img2.Src = dt3.Rows[1]["path"].ToString();
                        n_date2.Text = Convert.ToDateTime(dt3.Rows[1]["date"]).ToString("dd-MM-yy");
                        n_time2.Text = DateTime.ParseExact(dt3.Rows[1]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    if (dt3.Rows.Count > 2)
                    {
                        n_img3.Visible = true;
                        n_img3.Src = dt3.Rows[2]["path"].ToString();
                        n_date3.Text = Convert.ToDateTime(dt3.Rows[2]["date"]).ToString("dd-MM-yy");
                        n_time3.Text = DateTime.ParseExact(dt3.Rows[2]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }

                    string query4 = "SELECT * FROM documents where uhid= '" + Session["uhid"].ToString() + "' and type='Treatment' order by date desc ";
                    MySqlCommand cmd4 = new MySqlCommand(query4, sqlconn);
                    DataTable dt4 = new DataTable();
                    dt4.Load(cmd4.ExecuteReader());
                    if (dt4.Rows.Count > 0)
                    {
                        treatment.Visible = true;
                        //s3 = dt.Rows[0]["path"].ToString();
                        t_img1.Visible = true;
                        t_img1.Src = dt4.Rows[0]["path"].ToString();
                        t_date1.Text = Convert.ToDateTime(dt4.Rows[0]["date"]).ToString("dd-MM-yy");
                        t_time1.Text = DateTime.ParseExact(dt4.Rows[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    if (dt4.Rows.Count > 1)
                    {
                        t_img2.Visible = true;
                        //s3 = dt.Rows[0]["path"].ToString();
                        t_img2.Src = dt4.Rows[1]["path"].ToString();
                        t_date2.Text = Convert.ToDateTime(dt4.Rows[1]["date"]).ToString("dd-MM-yy");
                        t_time2.Text = DateTime.ParseExact(dt4.Rows[1]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    if (dt4.Rows.Count > 2)
                    {
                        t_img3.Visible = true;
                        t_img3.Src = dt4.Rows[2]["path"].ToString();
                        t_date3.Text = Convert.ToDateTime(dt4.Rows[2]["date"]).ToString("dd-MM-yy");
                        t_time3.Text = DateTime.ParseExact(dt4.Rows[2]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }

                    string query5 = "SELECT * FROM documents where uhid= '" + Session["uhid"].ToString() + "' and type='Monitor Screen' order by date desc ";
                    MySqlCommand cmd5 = new MySqlCommand(query5, sqlconn);
                    DataTable dt5 = new DataTable();
                    dt5.Load(cmd5.ExecuteReader());
                    if (dt5.Rows.Count > 0)
                    {
                        m_img1.Visible = true;
                        monitor.Visible = true;
                        //s3 = dt.Rows[0]["path"].ToString();
                        m_img1.Src = dt5.Rows[0]["path"].ToString();
                        m_date1.Text = Convert.ToDateTime(dt5.Rows[0]["date"]).ToString("dd-MM-yy");
                        m_time1.Text = DateTime.ParseExact(dt5.Rows[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    if (dt5.Rows.Count > 1)
                    {
                        m_img2.Visible = true;
                        m_img2.Src = dt5.Rows[1]["path"].ToString();
                        m_date2.Text = Convert.ToDateTime(dt5.Rows[1]["date"]).ToString("dd-MM-yy");
                        m_time2.Text = DateTime.ParseExact(dt5.Rows[1]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    if (dt5.Rows.Count > 2)
                    {
                        m_img3.Visible = true;
                        m_img3.Src = dt5.Rows[2]["path"].ToString();
                        m_date3.Text = Convert.ToDateTime(dt5.Rows[2]["date"]).ToString("dd-MM-yy");
                        m_time3.Text = DateTime.ParseExact(dt5.Rows[2]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }

                    string query6 = "SELECT * FROM documents where uhid= '" + Session["uhid"].ToString() + "' and type='Ventilator Screen' order by date desc ";
                    MySqlCommand cmd6 = new MySqlCommand(query6, sqlconn);
                    DataTable dt6 = new DataTable();
                    dt6.Load(cmd6.ExecuteReader());
                    if (dt6.Rows.Count > 0)
                    {
                        v_img1.Visible = true;
                        ventilator.Visible = true;
                        v_img1.Src = dt6.Rows[0]["path"].ToString();
                        v_date1.Text = Convert.ToDateTime(dt6.Rows[0]["date"]).ToString("dd-MM-yy");
                        v_time1.Text = DateTime.ParseExact(dt6.Rows[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    if (dt6.Rows.Count > 1)
                    {
                        v_img2.Visible = true;
                        v_img2.Src = dt6.Rows[1]["path"].ToString();
                        v_date2.Text = Convert.ToDateTime(dt6.Rows[1]["date"]).ToString("dd-MM-yy");
                        v_time2.Text = DateTime.ParseExact(dt6.Rows[1]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    if (dt6.Rows.Count > 2)
                    {
                        v_img3.Visible = true;
                        v_img3.Src = dt6.Rows[2]["path"].ToString();
                        v_date3.Text = Convert.ToDateTime(dt6.Rows[2]["date"]).ToString("dd-MM-yy");
                        v_time3.Text = DateTime.ParseExact(dt6.Rows[2]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }

                    string query7 = "SELECT * FROM documents where uhid= '" + Session["uhid"].ToString() + "' and type='ABG' order by date desc";
                    MySqlCommand cmd7 = new MySqlCommand(query7, sqlconn);
                    DataTable dt7 = new DataTable();
                    dt7.Load(cmd7.ExecuteReader());
                    if (dt7.Rows.Count > 0)
                    {
                        abg_img1.Visible = true;
                        abg.Visible = true;
                        abg_img1.Src = dt7.Rows[0]["path"].ToString();
                        abg_date1.Text = Convert.ToDateTime(dt7.Rows[0]["date"]).ToString("dd-MM-yy");
                        abg_time1.Text = DateTime.ParseExact(dt7.Rows[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    if (dt7.Rows.Count > 1)
                    {
                        abg_img2.Visible = true;
                        abg_img2.Src = dt7.Rows[1]["path"].ToString();
                        abg_date2.Text = Convert.ToDateTime(dt7.Rows[1]["date"]).ToString("dd-MM-yy");
                        abg_time2.Text = DateTime.ParseExact(dt7.Rows[1]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    if (dt7.Rows.Count > 2)
                    {
                        abg_img3.Visible = true;
                        abg_img3.Src = dt7.Rows[2]["path"].ToString();
                        abg_date3.Text = Convert.ToDateTime(dt7.Rows[2]["date"]).ToString("dd-MM-yy");
                        abg_time3.Text = DateTime.ParseExact(dt7.Rows[2]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }


                    string query8 = "SELECT * FROM documents where uhid= '" + Session["uhid"].ToString() + "' and type='Lab Investigation Report' order by date desc ";
                    MySqlCommand cmd8 = new MySqlCommand(query8, sqlconn);
                    DataTable dt8 = new DataTable();
                    dt8.Load(cmd8.ExecuteReader());
                    if (dt8.Rows.Count > 0)
                    {
                        lab_img1.Visible = true;
                        lab.Visible = true;
                        lab_img1.Src = dt8.Rows[0]["path"].ToString();
                        lab_date1.Text = Convert.ToDateTime(dt8.Rows[0]["date"]).ToString("dd-MM-yy");
                        lab_time1.Text = DateTime.ParseExact(dt8.Rows[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    if (dt8.Rows.Count > 1)
                    {
                        lab_img2.Visible = true;
                        lab_img2.Src = dt8.Rows[1]["path"].ToString();
                        lab_date2.Text = Convert.ToDateTime(dt8.Rows[1]["date"]).ToString("dd-MM-yy");
                        lab_time2.Text = DateTime.ParseExact(dt8.Rows[1]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    if (dt8.Rows.Count > 2)
                    {
                        lab_img3.Visible = true;
                        lab_img3.Src = dt8.Rows[2]["path"].ToString();
                        lab_date3.Text = Convert.ToDateTime(dt8.Rows[2]["date"]).ToString("dd-MM-yy");
                        lab_time3.Text = DateTime.ParseExact(dt8.Rows[2]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }

                    string query9 = "SELECT * FROM documents where uhid= '" + Session["uhid"].ToString() + "' and type='Other Document' order by date desc ";
                    MySqlCommand cmd9 = new MySqlCommand(query9, sqlconn);
                    DataTable dt9 = new DataTable();
                    dt9.Load(cmd9.ExecuteReader());
                    if (dt9.Rows.Count > 0)
                    {
                        other.Visible = true;
                        o_img1.Visible = true;
                        o_img1.Src = dt9.Rows[0]["path"].ToString();
                        o_date1.Text = Convert.ToDateTime(dt9.Rows[0]["date"]).ToString("dd-MM-yy");
                        o_time1.Text = DateTime.ParseExact(dt9.Rows[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    if (dt9.Rows.Count > 1)
                    {
                        o_img2.Visible = true;
                        o_img2.Src = dt9.Rows[1]["path"].ToString();
                        o_date2.Text = Convert.ToDateTime(dt9.Rows[1]["date"]).ToString("dd-MM-yy");
                        o_time2.Text = DateTime.ParseExact(dt9.Rows[1]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    if (dt9.Rows.Count > 2)
                    {
                        o_img3.Visible = true;
                        o_img3.Src = dt9.Rows[2]["path"].ToString();
                        o_date3.Text = Convert.ToDateTime(dt9.Rows[2]["date"]).ToString("dd-MM-yy");
                        o_time3.Text = DateTime.ParseExact(dt9.Rows[2]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }

                    string query10 = "SELECT * FROM documents where uhid= '" + Session["uhid"].ToString() + "' and type='MRI' order by date desc ";
                    MySqlCommand cmd10 = new MySqlCommand(query10, sqlconn);
                    DataTable dt10 = new DataTable();
                    dt10.Load(cmd10.ExecuteReader());
                    if (dt10.Rows.Count > 0)
                    {
                        mri.Visible = true;
                        
                        if (dt10.Rows[0]["path"].ToString().EndsWith(".mp4"))
                        {
                            mri_vid1.Visible = true;
                            mri_vid1.Src = dt10.Rows[0]["path"].ToString();
                        }
                        else
                        {
                            mri_img1.Visible = true;
                            mri_img1.Src = dt10.Rows[0]["path"].ToString();
                        }

                        mri_date1.Text = Convert.ToDateTime(dt10.Rows[0]["date"]).ToString("dd-MM-yy");
                        mri_time1.Text = DateTime.ParseExact(dt10.Rows[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    if (dt10.Rows.Count > 1)
                    {
                        if (dt10.Rows[1]["path"].ToString().EndsWith(".mp4"))
                        {
                            mri_vid2.Visible = true;
                            mri_vid2.Src = dt10.Rows[1]["path"].ToString();
                        }
                        else
                        {
                            mri_img2.Visible = true;
                            mri_img2.Src = dt10.Rows[1]["path"].ToString();
                        }
                        mri_date2.Text = Convert.ToDateTime(dt10.Rows[1]["date"]).ToString("dd-MM-yy");
                        mri_time2.Text = DateTime.ParseExact(dt10.Rows[1]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    if (dt10.Rows.Count > 2)
                    {

                        if (dt10.Rows[2]["path"].ToString().EndsWith(".mp4"))
                        {
                            mri_vid3.Visible = true;
                            mri_vid3.Src = dt10.Rows[2]["path"].ToString();
                        }
                        else
                        {
                            mri_img3.Visible = true;
                            mri_img3.Src = dt10.Rows[2]["path"].ToString();
                        }
                        mri_date3.Text = Convert.ToDateTime(dt10.Rows[2]["date"]).ToString("dd-MM-yy");
                        mri_time3.Text = DateTime.ParseExact(dt10.Rows[2]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }

                    sqlconn.Close();
            }
                catch (Exception m)
            {
                Label l = new Label();
                l.Text = "<script>alert('" + m.Message + "')</script>";
                Form.Controls.Add(l);
            }
        }
        }
        void add_to_gallery1()
        {
            if (Session["uhid"] != null)
            {
                try
                {
                    DataTable doc_dt = Cache["'" + Session["username"].ToString() + "'documents"] as DataTable;
                    DataRow[] dtd = doc_dt.Select("uhid = '" + Session["uhid"].ToString() + "' and type='Discharge Summary' ");
                    if (dtd.Length > 0)
                    {
                        discharge.Visible = true;
                        dis_img1.Visible = true;
                        dis_date.Text = Convert.ToDateTime(dtd[0]["date"]).ToString("dd-MM-yy");
                        dis_time.Text = DateTime.ParseExact(dtd[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");

                        if (dtd[0]["path"].ToString().EndsWith(".pdf"))
                        {
                            s1 = dtd[0]["path"].ToString();
                            dis_img1.ImageUrl = "Images/pdf.png";
                        }
                        else
                        {
                            dis_img1.ImageUrl = dtd[0]["path"].ToString();
                        }
                    }

                    DataRow[] dt = doc_dt.Select("uhid = '" + Session["uhid"].ToString() + "' and type='xray' ");


                    if (dt.Length > 0)
                    {
                        xray.Visible = true;
                        x_img1.Visible = true;
                        x_img1.Src = dt[0]["path"].ToString();
                        x_date1.Text = Convert.ToDateTime(dt[0]["date"]).ToString("dd-MM-yy");
                        x_time1.Text = DateTime.ParseExact(dt[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    if (dt.Length > 1)
                    {
                        x_img2.Visible = true;
                        x_img2.Src = dt[1]["path"].ToString();
                        x_date2.Text = Convert.ToDateTime(dt[1]["date"]).ToString("dd-MM-yy");
                        x_time2.Text = DateTime.ParseExact(dt[1]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    if (dt.Length > 2)
                    {
                        x_img3.Visible = true;
                        x_img3.Src = dt[2]["path"].ToString();
                        x_date3.Text = Convert.ToDateTime(dt[2]["date"]).ToString("dd-MM-yy");
                        x_time3.Text = DateTime.ParseExact(dt[2]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }

                   
                    DataRow[] dt1 = doc_dt.Select("uhid = '" + Session["uhid"].ToString() + "' and type='CT Head' ");
                    if (dt1.Length > 0)
                    {
                        ct_head.Visible = true;

                        if (dt1[0]["path"].ToString().EndsWith(".mp4"))
                        {
                            ct_h_vid1.Visible = true;
                            ct_h_vid1.Src = dt1[0]["path"].ToString();
                        }
                        else
                        {
                            ct_h_img1.Visible = true;
                            ct_h_img1.Src = dt1[0]["path"].ToString();
                        }
                        ct_h_date1.Text = Convert.ToDateTime(dt1[0]["date"]).ToString("dd-MM-yy");
                        ct_h_time1.Text = DateTime.ParseExact(dt1[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    if (dt1.Length > 1)
                    {
                        if (dt1[1]["path"].ToString().EndsWith(".mp4"))
                        {
                            ct_h_vid2.Visible = true;
                            ct_h_vid2.Src = dt1[1]["path"].ToString();
                        }
                        else
                        {
                            ct_h_img2.Visible = true;
                            ct_h_img2.Src = dt1[1]["path"].ToString();
                        }
                        ct_h_date2.Text = Convert.ToDateTime(dt1[1]["date"]).ToString("dd-MM-yy");
                        ct_h_time2.Text = DateTime.ParseExact(dt1[1]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    if (dt1.Length > 2)
                    {
                        if (dt1[2]["path"].ToString().EndsWith(".mp4"))
                        {
                            ct_h_vid3.Visible = true;
                            ct_h_vid3.Src = dt1[2]["path"].ToString();
                        }
                        else
                        {
                            ct_h_img3.Visible = true;
                            ct_h_img3.Src = dt1[2]["path"].ToString();
                        }
                        ct_h_date3.Text = Convert.ToDateTime(dt1[2]["date"]).ToString("dd-MM-yy");
                        ct_h_time3.Text = DateTime.ParseExact(dt1[2]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }

                    
                    DataRow[] dt2 = doc_dt.Select("uhid = '" + Session["uhid"].ToString() + "' and type='CT Spinal' ");
                    if (dt2.Length > 0)
                    {
                        ct_spinal.Visible = true;

                        if (dt2[0]["path"].ToString().EndsWith(".mp4"))
                        {
                            ct_s_vid1.Visible = true;
                            ct_s_vid1.Src = dt2[0]["path"].ToString();
                        }
                        else
                        {
                            ct_s_img1.Visible = true;
                            ct_s_img1.Src = dt2[0]["path"].ToString();
                        }
                        ct_s_date1.Text = Convert.ToDateTime(dt2[0]["date"]).ToString("dd-MM-yy");
                        ct_s_time1.Text = DateTime.ParseExact(dt2[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    if (dt2.Length > 1)
                    {
                        if (dt2[1]["path"].ToString().EndsWith(".mp4"))
                        {
                            ct_s_vid2.Visible = true;
                            ct_s_vid2.Src = dt2[1]["path"].ToString();
                        }
                        else
                        {
                            ct_s_img2.Visible = true;
                            ct_s_img2.Src = dt2[1]["path"].ToString();
                        }

                        ct_s_date2.Text = Convert.ToDateTime(dt2[1]["date"]).ToString("dd-MM-yy");
                        ct_s_time2.Text = DateTime.ParseExact(dt2[1]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    else
                    {
                        ct_s_img2.Src = "";
                    }
                    if (dt2.Length > 2)
                    {
                        if (dt2[2]["path"].ToString().EndsWith(".mp4"))
                        {
                            ct_s_vid3.Visible = true;
                            ct_s_vid3.Src = dt2[2]["path"].ToString();
                        }
                        else
                        {
                            ct_s_img3.Visible = true;
                            ct_s_img3.Src = dt2[2]["path"].ToString();
                        }
                        ct_s_date3.Text = Convert.ToDateTime(dt2[2]["date"]).ToString("dd-MM-yy");
                        ct_s_time3.Text = DateTime.ParseExact(dt2[2]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    else
                    {
                        ct_s_img3.Src = "";
                    }

                    
                    DataRow[] dt3 = doc_dt.Select("uhid = '" + Session["uhid"].ToString() + "' and type='Nursing Notes' ");
                    if (dt3.Length > 0)
                    {
                        nursing.Visible = true;
                        n_img1.Visible = true;
                        //s3 = dt.Rows[0]["path"].ToString();
                        n_img1.Src = dt3[0]["path"].ToString();
                        n_date1.Text = Convert.ToDateTime(dt3[0]["date"]).ToString("dd-MM-yy");
                        n_time1.Text = DateTime.ParseExact(dt3[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    else
                    {
                        n_img1.Src = "";
                        n_img2.Src = "";
                        n_img3.Src = "";
                    }
                    if (dt3.Length > 1)
                    {
                        n_img2.Visible = true;
                        //s3 = dt.Rows[0]["path"].ToString();
                        n_img2.Src = dt3[1]["path"].ToString();
                        n_date2.Text = Convert.ToDateTime(dt3[1]["date"]).ToString("dd-MM-yy");
                        n_time2.Text = DateTime.ParseExact(dt3[1]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    if (dt3.Length > 2)
                    {
                        n_img3.Visible = true;
                        n_img3.Src = dt3[2]["path"].ToString();
                        n_date3.Text = Convert.ToDateTime(dt3[2]["date"]).ToString("dd-MM-yy");
                        n_time3.Text = DateTime.ParseExact(dt3[2]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }

                    
                    DataRow[] dt4 = doc_dt.Select("uhid = '" + Session["uhid"].ToString() + "' and type='Treatment' ");
                    if (dt4.Length > 0)
                    {
                        treatment.Visible = true;
                        //s3 = dt.Rows[0]["path"].ToString();
                        t_img1.Visible = true;
                        t_img1.Src = dt4[0]["path"].ToString();
                        t_date1.Text = Convert.ToDateTime(dt4[0]["date"]).ToString("dd-MM-yy");
                        t_time1.Text = DateTime.ParseExact(dt4[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    if (dt4.Length > 1)
                    {
                        t_img2.Visible = true;
                        //s3 = dt.Rows[0]["path"].ToString();
                        t_img2.Src = dt4[1]["path"].ToString();
                        t_date2.Text = Convert.ToDateTime(dt4[1]["date"]).ToString("dd-MM-yy");
                        t_time2.Text = DateTime.ParseExact(dt4[1]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    if (dt4.Length > 2)
                    {
                        t_img3.Visible = true;
                        t_img3.Src = dt4[2]["path"].ToString();
                        t_date3.Text = Convert.ToDateTime(dt4[2]["date"]).ToString("dd-MM-yy");
                        t_time3.Text = DateTime.ParseExact(dt4[2]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }

                    
                    DataRow[] dt5 = doc_dt.Select("uhid = '" + Session["uhid"].ToString() + "' and type='Monitor Screen' ");
                    if (dt5.Length > 0)
                    {
                        m_img1.Visible = true;
                        monitor.Visible = true;
                        //s3 = dt.Rows[0]["path"].ToString();
                        m_img1.Src = dt5[0]["path"].ToString();
                        m_date1.Text = Convert.ToDateTime(dt5[0]["date"]).ToString("dd-MM-yy");
                        m_time1.Text = DateTime.ParseExact(dt5[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    if (dt5.Length > 1)
                    {
                        m_img2.Visible = true;
                        //s3 = dt.Rows[0]["path"].ToString();
                        m_img2.Src = dt5[1]["path"].ToString();
                        m_date2.Text = Convert.ToDateTime(dt5[1]["date"]).ToString("dd-MM-yy");
                        m_time2.Text = DateTime.ParseExact(dt5[1]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    if (dt5.Length > 2)
                    {
                        m_img3.Visible = true;
                        m_img3.Src = dt5[2]["path"].ToString();
                        m_date3.Text = Convert.ToDateTime(dt5[2]["date"]).ToString("dd-MM-yy");
                        m_time3.Text = DateTime.ParseExact(dt5[2]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }

                    
                    DataRow[] dt6 = doc_dt.Select("uhid = '" + Session["uhid"].ToString() + "' and type='Treatment' ");
                    if (dt6.Length > 0)
                    {
                        v_img1.Visible = true;
                        ventilator.Visible = true;
                        //s3 = dt.Rows[0]["path"].ToString();
                        v_img1.Src = dt6[0]["path"].ToString();
                        v_date1.Text = Convert.ToDateTime(dt6[0]["date"]).ToString("dd-MM-yy");
                        v_time1.Text = DateTime.ParseExact(dt6[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    if (dt6.Length > 1)
                    {
                        v_img2.Visible = true;
                        //s3 = dt.Rows[0]["path"].ToString();
                        v_img2.Src = dt6[1]["path"].ToString();
                        v_date2.Text = Convert.ToDateTime(dt6[1]["date"]).ToString("dd-MM-yy");
                        v_time2.Text = DateTime.ParseExact(dt6[1]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    if (dt6.Length > 2)
                    {
                        v_img3.Visible = true;
                        v_img3.Src = dt6[2]["path"].ToString();
                        v_date3.Text = Convert.ToDateTime(dt6[2]["date"]).ToString("dd-MM-yy");
                        v_time3.Text = DateTime.ParseExact(dt6[2]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }

                    
                    DataRow[] dt7 = doc_dt.Select("uhid = '" + Session["uhid"].ToString() + "' and type='ABG' ");
                    if (dt7.Length > 0)
                    {
                        abg_img1.Visible = true;
                        abg.Visible = true;
                        //s3 = dt.Rows[0]["path"].ToString();
                        abg_img1.Src = dt7[0]["path"].ToString();
                        abg_date1.Text = Convert.ToDateTime(dt7[0]["date"]).ToString("dd-MM-yy");
                        abg_time1.Text = DateTime.ParseExact(dt7[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    if (dt7.Length > 1)
                    {
                        abg_img2.Visible = true;
                        //s3 = dt.Rows[0]["path"].ToString();
                        abg_img2.Src = dt7[1]["path"].ToString();
                        abg_date2.Text = Convert.ToDateTime(dt7[1]["date"]).ToString("dd-MM-yy");
                        abg_time2.Text = DateTime.ParseExact(dt7[1]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    if (dt7.Length > 2)
                    {
                        abg_img3.Visible = true;
                        abg_img3.Src = dt7[2]["path"].ToString();
                        abg_date3.Text = Convert.ToDateTime(dt7[2]["date"]).ToString("dd-MM-yy");
                        abg_time3.Text = DateTime.ParseExact(dt7[2]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                                        
                    DataRow[] dt8 = doc_dt.Select("uhid = '" + Session["uhid"].ToString() + "' and type='Lab Reports' ");
                    if (dt8.Length > 0)
                    {
                        lab_img1.Visible = true;
                        lab.Visible = true;
                        //s3 = dt.Rows[0]["path"].ToString();
                        lab_img1.Src = dt8[0]["path"].ToString();
                        lab_date1.Text = Convert.ToDateTime(dt8[0]["date"]).ToString("dd-MM-yy");
                        lab_time1.Text = DateTime.ParseExact(dt8[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    if (dt8.Length > 1)
                    {
                        lab_img2.Visible = true;
                        //s3 = dt.Rows[0]["path"].ToString();
                        lab_img2.Src = dt8[1]["path"].ToString();
                        lab_date2.Text = Convert.ToDateTime(dt8[1]["date"]).ToString("dd-MM-yy");
                        lab_time2.Text = DateTime.ParseExact(dt8[1]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    if (dt8.Length > 2)
                    {
                        lab_img3.Visible = true;
                        lab_img3.Src = dt8[2]["path"].ToString();
                        lab_date3.Text = Convert.ToDateTime(dt8[2]["date"]).ToString("dd-MM-yy");
                        lab_time3.Text = DateTime.ParseExact(dt8[2]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                                        
                    DataRow[] dt9 = doc_dt.Select("uhid = '" + Session["uhid"].ToString() + "' and type='Other Document' ");
                    if (dt9.Length > 0)
                    {
                        other.Visible = true;
                        o_img1.Visible = true;
                        o_img1.Src = dt9[0]["path"].ToString();
                        o_date1.Text = Convert.ToDateTime(dt9[0]["date"]).ToString("dd-MM-yy");
                        o_time1.Text = DateTime.ParseExact(dt9[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    if (dt9.Length > 1)
                    {
                        o_img2.Visible = true;
                        o_img2.Src = dt9[1]["path"].ToString();
                        o_date2.Text = Convert.ToDateTime(dt9[1]["date"]).ToString("dd-MM-yy");
                        o_time2.Text = DateTime.ParseExact(dt9[1]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    if (dt9.Length > 2)
                    {
                        o_img3.Visible = true;
                        o_img3.Src = dt9[2]["path"].ToString();
                        o_date3.Text = Convert.ToDateTime(dt9[2]["date"]).ToString("dd-MM-yy");
                        o_time3.Text = DateTime.ParseExact(dt9[2]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }

                    
                    DataRow[] dt10 = doc_dt.Select("uhid = '" + Session["uhid"].ToString() + "' and type='MRI' ");
                    if (dt10.Length > 0)
                    {
                        mri.Visible = true;

                        //s3 = dt.Rows[0]["path"].ToString();
                        if (dt10[0]["path"].ToString().EndsWith(".mp4"))
                        {
                            mri_vid1.Visible = true;
                            mri_vid1.Src = dt10[0]["path"].ToString();
                        }
                        else
                        {
                            mri_img1.Visible = true;
                            mri_img1.Src = dt10[0]["path"].ToString();
                        }

                        mri_date1.Text = Convert.ToDateTime(dt10[0]["date"]).ToString("dd-MM-yy");
                        mri_time1.Text = DateTime.ParseExact(dt10[0]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    if (dt10.Length > 1)
                    {
                        if (dt10[1]["path"].ToString().EndsWith(".mp4"))
                        {
                            mri_vid2.Visible = true;
                            mri_vid2.Src = dt10[1]["path"].ToString();
                        }
                        else
                        {
                            mri_img2.Visible = true;
                            mri_img2.Src = dt10[1]["path"].ToString();
                        }
                        mri_date2.Text = Convert.ToDateTime(dt10[1]["date"]).ToString("dd-MM-yy");
                        mri_time2.Text = DateTime.ParseExact(dt10[1]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }
                    if (dt10.Length > 2)
                    {

                        if (dt10[2]["path"].ToString().EndsWith(".mp4"))
                        {
                            mri_vid2.Visible = true;
                            mri_vid2.Src = dt10[2]["path"].ToString();
                        }
                        else
                        {
                            mri_img2.Visible = true;
                            mri_img2.Src = dt10[2]["path"].ToString();
                        }
                        mri_date3.Text = Convert.ToDateTime(dt10[2]["date"]).ToString("dd-MM-yy");
                        mri_time3.Text = DateTime.ParseExact(dt10[2]["time"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm tt");
                    }

                // sqlconn.Close();
            }
                catch (Exception m)
            {
                Label l = new Label();
                l.Text = "<script>alert('" + m.Message + "')</script>";
                Form.Controls.Add(l);
            }
        }
        }

        protected void image_close(object sender, EventArgs e)
        {
           // mpe1.Hide();
            add_to_gallery();
        }
        protected void home_click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
        protected void remove_dash(object sender, EventArgs e)
        {
            Session["uhid"] = null;
            Response.Redirect("Home.aspx");
        }

    }

}
