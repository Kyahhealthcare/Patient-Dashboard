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
    public partial class MyPatients : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            labels();
        }

        void labels()
        {
            if (Session["hid"] != null)
            {
                // this.myddl = new DropDownList();
                String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                MySqlConnection sqlconn = new MySqlConnection(con);

                sqlconn.Open();

                string query2 = "SELECT l_name FROM label where created_by='DA'";
                MySqlCommand cmd3 = new MySqlCommand(query2, sqlconn);
                DataTable dt2 = new DataTable();
                dt2.Load(cmd3.ExecuteReader());

                foreach(DataRow dr in dt2.Rows)
                {
                    ddl_label.Items.Add(dr["l_name"].ToString());
                }

                other_label.DataSource = dt2;
                other_label.DataTextField = "l_name";
                other_label.DataValueField = "l_name";
                other_label.DataBind();
                other_label.Items.Insert(0, new ListItem("SELECT", " "));
                // ddl_f_surgeon1.Items.Insert(0, new ListItem("SELECT", " "));
                //ddl_f_surgeon2.Items.Insert(0, new ListItem("SELECT", " "));

                sqlconn.Close();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            InitializeCulture();
           
            if (!IsPostBack)
            {
                l_user.Text = Request.Cookies["userid"].Value.ToString();
                Session["username"] = Request.Cookies["userid"].Value.ToString();
                if (Session["username"] != null)
                {
                    fill_modal();
                    fill_form();
                }
                else
                {
                    //  uhid.Visible = false;
                }
            }
        }

        void fill_form()
        {
            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();

            String pname = "sp_my_patients";
            MySqlCommand cmd = new MySqlCommand(pname, sqlconn);
            cmd.Parameters.AddWithValue("Maction", "ALL");
            cmd.Parameters.AddWithValue("Mconsultant", "DA");
            cmd.Parameters.AddWithValue("Ml_name", "");

            cmd.CommandType = CommandType.StoredProcedure;

            using(MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
            {
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);
                    
                    ViewState["dt"] = dt;
                    gv2.DataSource = dt;
                    gv2.DataBind();
                }
            }

            sqlconn.Close();
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
           
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                CheckBox headerchk = (CheckBox)gv2.HeaderRow.FindControl("chkheader");
                CheckBox childchk = (CheckBox)e.Row.FindControl("chkchild");
                childchk.Attributes.Add("onclick", "javascript:Selectchildcheckboxes('" + headerchk.ClientID + "')");


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
            int index = Convert.ToInt32(e.RowIndex);

            DataTable dt = ViewState["dt"] as DataTable;

            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();
            string g = dt.Rows[index][1].ToString();

            string query = "update pt_details set consultant='' where uhid= '" + g + "'";
            MySqlCommand cmd = new MySqlCommand(query, sqlconn);
            
            cmd.ExecuteNonQuery();
          
            fill_form();
            sqlconn.Close();
        }

        protected void all_click(object sender, EventArgs e)
        {
            all.ForeColor = System.Drawing.ColorTranslator.FromHtml("#9EB23B");
            acad.ForeColor = System.Drawing.ColorTranslator.FromHtml("#166D89");
            op.ForeColor = System.Drawing.ColorTranslator.FromHtml("#166D89");
            Exam.ForeColor = System.Drawing.ColorTranslator.FromHtml("#166D89");
            conf.ForeColor = System.Drawing.ColorTranslator.FromHtml("#166D89");
            other_label.ForeColor = System.Drawing.ColorTranslator.FromHtml("#166D89");

            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();

            String pname = "sp_my_patients";
            MySqlCommand cmd = new MySqlCommand(pname, sqlconn);
            cmd.Parameters.AddWithValue("Maction", "ALL");
            cmd.Parameters.AddWithValue("Mconsultant", "DA");
            cmd.Parameters.AddWithValue("Ml_name", "");
            cmd.CommandType = CommandType.StoredProcedure;

            using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
            {
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);
                    ViewState["dt"] = dt;
                    gv2.DataSource = dt;
                    gv2.DataBind();
                }
            }
        }
        protected void label_selected(object sender, EventArgs e)
        {
            all.ForeColor = System.Drawing.ColorTranslator.FromHtml("#166D89");
            acad.ForeColor = System.Drawing.ColorTranslator.FromHtml("#166D89");
            op.ForeColor = System.Drawing.ColorTranslator.FromHtml("#166D89");
            Exam.ForeColor = System.Drawing.ColorTranslator.FromHtml("#166D89");
            conf.ForeColor = System.Drawing.ColorTranslator.FromHtml("#166D89");

            //if (other_label.SelectedItem.Value!="")
            //{
                other_label.ForeColor = System.Drawing.ColorTranslator.FromHtml("#9EB23B");
            //}            

            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();

            String pname = "sp_my_patients";
            MySqlCommand cmd = new MySqlCommand(pname, sqlconn);
            cmd.Parameters.AddWithValue("Maction", "label");
            cmd.Parameters.AddWithValue("Mconsultant", "DA");
            cmd.Parameters.AddWithValue("Ml_name", other_label.SelectedItem.Value);

            cmd.CommandType = CommandType.StoredProcedure;

            using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
            {
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);
                    ViewState["dt"] = dt;
                    gv2.DataSource = dt;
                    gv2.DataBind();
                }
            }
        }
        protected void acad_click(object sender, EventArgs e)
        {   //#9EB23B
            all.ForeColor = System.Drawing.ColorTranslator.FromHtml("#166D89");
            acad.ForeColor = System.Drawing.ColorTranslator.FromHtml("#9EB23B");
            op.ForeColor = System.Drawing.ColorTranslator.FromHtml("#166D89");
            Exam.ForeColor = System.Drawing.ColorTranslator.FromHtml("#166D89");
            conf.ForeColor = System.Drawing.ColorTranslator.FromHtml("#166D89");
            other_label.ForeColor = System.Drawing.ColorTranslator.FromHtml("#166D89");

            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();

            String pname = "sp_my_patients";
            MySqlCommand cmd = new MySqlCommand(pname, sqlconn);
            cmd.Parameters.AddWithValue("Maction", "label");
            cmd.Parameters.AddWithValue("Mconsultant", "DA");
            cmd.Parameters.AddWithValue("Ml_name", "Academic");

            cmd.CommandType = CommandType.StoredProcedure;

            using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
            {
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);
                    ViewState["dt"] = dt;
                    gv2.DataSource = dt;
                    gv2.DataBind();
                }
            }
        }

        protected void op_click(object sender, EventArgs e)
        {
            all.ForeColor = System.Drawing.ColorTranslator.FromHtml("#166D89");
            acad.ForeColor = System.Drawing.ColorTranslator.FromHtml("#166D89");
            op.ForeColor = System.Drawing.ColorTranslator.FromHtml("#9EB23B");
            Exam.ForeColor = System.Drawing.ColorTranslator.FromHtml("#166D89");
            conf.ForeColor = System.Drawing.ColorTranslator.FromHtml("#166D89");
            other_label.ForeColor = System.Drawing.ColorTranslator.FromHtml("#166D89");

            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();

            String pname = "sp_my_patients";
            MySqlCommand cmd = new MySqlCommand(pname, sqlconn);
            cmd.Parameters.AddWithValue("Maction", "label");
            cmd.Parameters.AddWithValue("Mconsultant", "DA");
            cmd.Parameters.AddWithValue("Ml_name", "Operative");

            cmd.CommandType = CommandType.StoredProcedure;

            using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
            {
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);
                    ViewState["dt"] = dt;
                    gv2.DataSource = dt;
                    gv2.DataBind();
                }
            }
        }

        protected void exam_click(object sender, EventArgs e)
        {
            all.ForeColor = System.Drawing.ColorTranslator.FromHtml("#166D89");
            acad.ForeColor = System.Drawing.ColorTranslator.FromHtml("#166D89");
            op.ForeColor = System.Drawing.ColorTranslator.FromHtml("#166D89");
            Exam.ForeColor = System.Drawing.ColorTranslator.FromHtml("#9EB23B");
            conf.ForeColor = System.Drawing.ColorTranslator.FromHtml("#166D89");
            other_label.ForeColor = System.Drawing.ColorTranslator.FromHtml("#166D89");

            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();

            String pname = "sp_my_patients";
            MySqlCommand cmd = new MySqlCommand(pname, sqlconn);
            cmd.Parameters.AddWithValue("Maction", "label");
            cmd.Parameters.AddWithValue("Mconsultant", "DA");
            cmd.Parameters.AddWithValue("Ml_name", "Exam Cases");

            cmd.CommandType = CommandType.StoredProcedure;

            using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
            {
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);
                    ViewState["dt"] = dt;
                    gv2.DataSource = dt;
                    gv2.DataBind();
                }
            }
        }

        protected void conf_click(object sender, EventArgs e)
        {
            all.ForeColor = System.Drawing.ColorTranslator.FromHtml("#166D89");
            acad.ForeColor = System.Drawing.ColorTranslator.FromHtml("#166D89");
            op.ForeColor = System.Drawing.ColorTranslator.FromHtml("#166D89");
            Exam.ForeColor = System.Drawing.ColorTranslator.FromHtml("#166D89");
            conf.ForeColor = System.Drawing.ColorTranslator.FromHtml("#9EB23B");
            other_label.ForeColor = System.Drawing.ColorTranslator.FromHtml("#166D89");

            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();

            String pname = "sp_my_patients";
            MySqlCommand cmd = new MySqlCommand(pname, sqlconn);
            cmd.Parameters.AddWithValue("Maction", "label");
            cmd.Parameters.AddWithValue("Mconsultant", "DA");
            cmd.Parameters.AddWithValue("Ml_name", "Conference Cases");

            cmd.CommandType = CommandType.StoredProcedure;

            using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
            {
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);
                    ViewState["dt"] = dt;
                    gv2.DataSource = dt;
                    gv2.DataBind();
                }
            }
        }

        protected void create_label(object sender, EventArgs e)
        {
            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();

            String pname = "sp_label";
            MySqlCommand cmd = new MySqlCommand(pname, sqlconn);
            cmd.Parameters.AddWithValue("Maction", "INSERT");

            cmd.Parameters.AddWithValue("Ml_name", tb_l_name.Text);
            cmd.Parameters.AddWithValue("Mcreated_by", "DA");

            cmd.Parameters.AddWithValue("Muhid", "");

            cmd.CommandType = CommandType.StoredProcedure;
            Int32 Affectedrows = cmd.ExecuteNonQuery();
            if (Affectedrows != 0)
            {
                labels();
                fill_modal();
                
                label_msg.Text = tb_l_name.Text +" is created";
                tb_l_name.Text = "";

            }
            sqlconn.Close();

        }

      

        void fill_modal()
        {
            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();
            String pname = "sp_label";
            MySqlCommand cmd = new MySqlCommand(pname, sqlconn);
            cmd.Parameters.AddWithValue("Maction", "SELECT_LABEL");
           
            cmd.Parameters.AddWithValue("Ml_name", "");
            cmd.Parameters.AddWithValue("Muhid", "");
            cmd.Parameters.AddWithValue("Mcreated_by", "DA");
            cmd.CommandType = CommandType.StoredProcedure;

            using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
            {
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);
                    modal_gv.DataSource = dt;
                    modal_gv.DataBind();
                    ViewState["labels"] = dt;
                }
            }

            sqlconn.Close();
        }

        protected void gv1_rowdatabound(object sender, GridViewRowEventArgs e)
        {
           if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var row = (DataRowView)e.Row.DataItem;
                var s = (string)row["l_name"];
                
                //string item = e.Row.Cells[0];
               // string s = ((Label)e.Row.Cells[0].Controls[0]).Text;
                //Label l = modal_gv.Rows[0].FindControl("l_name") as Label;
                //string s = l.Text;
                foreach (LinkButton button in e.Row.Cells[0].Controls.OfType<LinkButton>())
                {
                    if (button.CommandName == "delete")
                    {
                       // var l = "";
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + s + "?')){ return false; };";
                        //Session["s"] = l;
                    }
                    if (button.CommandName == "edit")
                    {
                        // var l = "";
                       
                        button.Attributes["onclick"] = "if(!confirm('Do you want to rename " + s + "?')){ return false; };";
                        //Session["s"] = l;
                        
                    }
                }
            }
        }
        protected void gv1_rowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "delete_label")
            { // also delete and update label_idd of pt_details
                GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int row_index = gvr.RowIndex;

                DataTable dt = new DataTable();
                dt = (DataTable)ViewState["labels"];
                var s = dt.Rows[row_index][0].ToString();

                String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                MySqlConnection sqlconn = new MySqlConnection(con);

                sqlconn.Open();
                String pname = "sp_label";
                MySqlCommand cmd = new MySqlCommand(pname, sqlconn);
                cmd.Parameters.AddWithValue("Maction", "DELETE");

                cmd.Parameters.AddWithValue("Ml_name", s);
                cmd.Parameters.AddWithValue("Mcreated_by", "DA");

                cmd.Parameters.AddWithValue("Muhid", "");

                cmd.CommandType = CommandType.StoredProcedure;
                Int32 Affectedrows = cmd.ExecuteNonQuery();
                if (Affectedrows != 0)
                {
                    fill_modal();
                    labels();
                }
                sqlconn.Close();
            }
            if (e.CommandName == "edit")
            {             

                GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int row_index = gvr.RowIndex;

                TextBox rn = (TextBox)modal_gv.Rows[row_index].FindControl("rename_box");
                rn.Visible = true;

                DataTable dt = new DataTable();
                dt = (DataTable)ViewState["labels"];
                var s = dt.Rows[row_index][0].ToString();

                String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                MySqlConnection sqlconn = new MySqlConnection(con);

                sqlconn.Open();
                String pname = "sp_label";
                MySqlCommand cmd = new MySqlCommand(pname, sqlconn);
                cmd.Parameters.AddWithValue("Maction", "UPDATE");

                cmd.Parameters.AddWithValue("Ml_name", rn.Text);
                cmd.Parameters.AddWithValue("Mcreated_by", "DA");

                cmd.Parameters.AddWithValue("Muhid", "");

                cmd.CommandType = CommandType.StoredProcedure;
                Int32 Affectedrows = cmd.ExecuteNonQuery();
                if (Affectedrows != 0)
                {
                    fill_modal();
                    labels();
                }
                sqlconn.Close();
            }
        }

        protected void tag_as(object sender, EventArgs e)
        {
            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();
            
            foreach (GridViewRow row in gv2.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
//                    CheckBox chkRow = (CheckBox)row.Cells[0].Controls[0];
                    bool isChecked = (row.Cells[0].FindControl("chkchild") as CheckBox).Checked;

                    if (isChecked)
                    {
                        //Take Row information from each column (Cell) and display it
                        string _uhid = row.Cells[2].Text;

                        String pname = "sp_label";
                        MySqlCommand cmd = new MySqlCommand(pname, sqlconn);
                        cmd.Parameters.AddWithValue("Maction", "UPDATE_PT");

                        cmd.Parameters.AddWithValue("Ml_name", ddl_label.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("Mcreated_by", "DA");

                        cmd.Parameters.AddWithValue("Muhid", _uhid);

                        cmd.CommandType = CommandType.StoredProcedure;
                        Int32 Affectedrows = cmd.ExecuteNonQuery();
                        if (Affectedrows != 0)
                        {
                            // label_msg.Text = tb_l_name.Text + " is created";
                            //tb_l_name.Text = "";
                        }
                    }
                }
               
            }
            
            sqlconn.Close();
        }

      
    }
}