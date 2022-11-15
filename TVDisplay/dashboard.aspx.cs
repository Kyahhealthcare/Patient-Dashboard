using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls; 

namespace TVDisplay
{
    public partial class dashboard : System.Web.UI.Page
    {
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
                    get_pt_details();
                    fill_issues();
                }
            }
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
                    diag2.Text = dt.Rows[0]["diag2"].ToString();
                    diag3.Text = dt.Rows[0]["diag3"].ToString();
                    ward.Text = dt.Rows[0]["ward"].ToString();
                    bed.Text = dt.Rows[0]["bed"].ToString();


                    string querydis = "SELECT * FROM discharge_status where uhid= '" + Session["uhid"].ToString() + "' ";
                    MySqlCommand cmddis = new MySqlCommand(querydis, sqlconn);
                    DataTable dtdis = new DataTable();
                    dtdis.Load(cmddis.ExecuteReader());
                    if (dtdis.Rows.Count != 0)
                    {
                        double days = (Convert.ToDateTime(dtdis.Rows[0]["date"]) - Convert.ToDateTime(dt.Rows[0]["date_admit"])).TotalDays;
                        los.Text = Math.Ceiling(days) + " Days";
                    }
                    else
                    {
                        double days = (DateTime.Now - Convert.ToDateTime(dt.Rows[0]["date_admit"])).TotalDays;
                        los.Text = Math.Ceiling(days) + " Days";
                    }


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


                //infusion
                string query2 = "SELECT * FROM infusion_details where uhid= '" + Session["uhid"].ToString() + "' ";
                MySqlCommand cmd2 = new MySqlCommand(query2, sqlconn);
                DataTable dt2 = new DataTable();
                dt2.Load(cmd2.ExecuteReader());
                if (dt2.Rows.Count != 0)
                {
                    infusion1.Text = dt2.Rows[0]["infusion1"].ToString() + "@" + dt2.Rows[0]["quan1"].ToString() + " ml/min";
                    //infusion2.Text = dt2.Rows[0]["infusion2"].ToString() + "@" + dt2.Rows[0]["quan2"].ToString() + " ml/min";
                    //infusion2.Text = dt2.Rows[0]["infusion3"].ToString() + "@" + dt2.Rows[0]["quan3"].ToString() + " ml/min";
                }

                //discharge
                string queryd = "SELECT * FROM discharge_status where uhid= '" + Session["uhid"].ToString() + "' ";
                MySqlCommand cmdd = new MySqlCommand(queryd, sqlconn);
                DataTable dtd = new DataTable();
                dtd.Load(cmdd.ExecuteReader());
                if (dtd.Rows.Count != 0)
                {
                    infusion1.Text = dt2.Rows[0]["infusion1"].ToString() + "@" + dt2.Rows[0]["quan1"].ToString() + " ml/min";
                    //infusion2.Text = dt2.Rows[0]["infusion2"].ToString() + "@" + dt2.Rows[0]["quan2"].ToString() + " ml/min";
                    //infusion2.Text = dt2.Rows[0]["infusion3"].ToString() + "@" + dt2.Rows[0]["quan3"].ToString() + " ml/min";
                }


                //last 24I/O
                string query3 = "SELECT * FROM last_io where uhid= '" + Session["uhid"].ToString() + "' ";
                MySqlCommand cmd3 = new MySqlCommand(query3, sqlconn);
                DataTable dt3 = new DataTable();
                dt3.Load(cmd3.ExecuteReader());
                if (dt3.Rows.Count != 0)
                {
                    i.Text = dt3.Rows[0]["i"].ToString();
                    o.Text = dt3.Rows[0]["o"].ToString();
                    drain.Text = dt3.Rows[0]["drain"].ToString();
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
                    fio2.Text = "FIO2: " + dt4.Rows[0]["fio2"].ToString();
                    ps.Text = "Pressure Support: " + dt4.Rows[0]["Pressure"].ToString();
                }

                //surgery
                string query5 = "SELECT * FROM surgery_details where uhid= '" + Session["uhid"].ToString() + "' order by date desc";
                MySqlCommand cmd5 = new MySqlCommand(query5, sqlconn);
                DataTable dt5 = new DataTable();
                dt5.Load(cmd5.ExecuteReader());
                if (dt5.Rows.Count > 0)
                {
                    surg.Text = dt5.Rows[0]["surgeon1"].ToString() + "/" + dt5.Rows[0]["surgeon2"].ToString();

                    s_name1.Text = dt5.Rows[0]["surgery_name"].ToString();
                    dos1_date.Text = Convert.ToDateTime(dt5.Rows[0]["date"]).ToString("dd-MM-yyyy");
                    pod1_days.Text = Math.Ceiling((DateTime.Now - Convert.ToDateTime(dt5.Rows[0]["date"])).TotalDays) + " Days";
                }
                if (dt5.Rows.Count > 1)
                {
                    s_name2.Text = dt5.Rows[1]["surgery_name"].ToString();
                    dos2_date.Text = Convert.ToDateTime(dt5.Rows[1]["date"]).ToString("dd-MM-yyyy");
                    pod2_days.Text = Math.Ceiling((DateTime.Now - Convert.ToDateTime(dt5.Rows[1]["date"].ToString())).TotalDays) + " Days";
                }
                if (dt5.Rows.Count > 2)
                {
                    s_name3.Text = dt5.Rows[2]["surgery_name"].ToString();
                    dos3_date.Text = Convert.ToDateTime(dt5.Rows[2]["date"]).ToString("dd-MM-yyyy");
                    pod3_days.Text = Math.Ceiling((DateTime.Now - Convert.ToDateTime(dt5.Rows[2]["date"].ToString())).TotalDays) + " Days";
                }
                if (dt5.Rows.Count > 3)
                {
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
                    hb_time.Text = dt71.Rows[0]["time"].ToString();
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
                    tlc_time.Text = dt72.Rows[0]["time"].ToString();
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
                    fasting_time.Text = dt73.Rows[0]["time"].ToString();
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
                    pp_time.Text = dt74.Rows[0]["time"].ToString();
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
                    urea_time.Text = dt75.Rows[0]["time"].ToString();
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
                    creat_time.Text = dt76.Rows[0]["time"].ToString();
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
                    na_time.Text = dt77.Rows[0]["time"].ToString();
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
                    k_time.Text = dt78.Rows[0]["time"].ToString();
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
                    wbc_time.Text = dt79.Rows[0]["time"].ToString();
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
                    rbc_time.Text = dt710.Rows[0]["time"].ToString();
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
                    csf_sugar_time.Text = dt711.Rows[0]["time"].ToString();
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
                    rr.Text = dt81.Rows[0]["rr"].ToString();
                    rr_date.Text = Convert.ToDateTime(dt81.Rows[0]["date"].ToString()).ToString("dd-MM-yy");
                    rr_time.Text = dt81.Rows[0]["time"].ToString();

                    spo2.Text = dt81.Rows[0]["spo2"].ToString();
                    spo2_date.Text = Convert.ToDateTime(dt81.Rows[0]["date"].ToString()).ToString("dd-MM-yy");
                    spo2_time.Text = dt81.Rows[0]["time"].ToString();

                    pulse.Text = dt81.Rows[0]["pulse"].ToString();
                    pulse_date.Text = Convert.ToDateTime(dt81.Rows[0]["date"].ToString()).ToString("dd-MM-yy");
                    pulse_time.Text = dt81.Rows[0]["time"].ToString();

                    temp.Text = dt81.Rows[0]["temp"].ToString();
                    temp_date.Text = Convert.ToDateTime(dt81.Rows[0]["date"].ToString()).ToString("dd-MM-yy");
                    temp_time.Text = dt81.Rows[0]["time"].ToString();

                    bp.Text = dt81.Rows[0]["bp"].ToString();
                    bp_date.Text = Convert.ToDateTime(dt81.Rows[0]["date"].ToString()).ToString("dd-MM-yy");
                    bp_time.Text = dt81.Rows[0]["time"].ToString();

                    icp.Text = dt81.Rows[0]["icp"].ToString();
                    icp_date.Text = Convert.ToDateTime(dt81.Rows[0]["date"].ToString()).ToString("dd-MM-yy");
                    icp_time.Text = dt81.Rows[0]["time"].ToString();
                }
                              
                //plan
                string query9 = "SELECT * FROM plan_details where uhid= '" + Session["uhid"].ToString() + "' and date='" + DateTime.Now + "' ";
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
                
                //issues


                sqlconn.Close();
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
    }
}