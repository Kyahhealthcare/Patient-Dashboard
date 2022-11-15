using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Drawing;

namespace TVDisplay
{
    public partial class Register : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }
       
        protected void submit_click(object sender, EventArgs e)
        {
            if (tb_mail.Text != "")
            {
                String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                MySqlConnection sqlconn = new MySqlConnection(con);

                sqlconn.Open();
                // String d = Convert.ToDateTime(tb_dos.Text).ToString("yyyy-MM-dd");

                string query2 = "SELECT * FROM login_user where email= '" + tb_mail.Text + "' ";
                MySqlCommand cmd3 = new MySqlCommand(query2, sqlconn);
                DataTable dt2 = new DataTable();
                dt2.Load(cmd3.ExecuteReader());

                string queryu = "SELECT * FROM login_user where username= '" + tb_username.Text + "' ";
                MySqlCommand cmdu = new MySqlCommand(queryu, sqlconn);
                DataTable dtu = new DataTable();
                dtu.Load(cmdu.ExecuteReader());

                string queryd = "SELECT * FROM doctor_list where mails= '" + tb_mail.Text + "' ";
                MySqlCommand cmdd = new MySqlCommand(queryd, sqlconn);
                DataTable dtd = new DataTable();
                dtd.Load(cmdd.ExecuteReader());

                string queryn = "SELECT * FROM nurse_list where mails= '" + tb_mail.Text + "' ";
                MySqlCommand cmdn = new MySqlCommand(queryn, sqlconn);
                DataTable dtn = new DataTable();
                dtn.Load(cmdn.ExecuteReader());

                string queryr = "SELECT * FROM residents where mails= '" + tb_mail.Text + "' ";
                MySqlCommand cmdr = new MySqlCommand(queryr, sqlconn);
                DataTable dtr = new DataTable();
                dtr.Load(cmdr.ExecuteReader());

                String pname = "sp_login_user";
                MySqlCommand cmd = new MySqlCommand(pname, sqlconn);

                string otp = "";

                if (dt2.Rows.Count != 0)
                {
                    // already registered // go to login // or forgot password
                    lblMsg.Text = "This Email ID is already registered with us. Please login to continue";
                    lblMsg.Visible = true;
                    lblMsg.BackColor = Color.LightGray;
                    lblMsg.ForeColor = Color.DarkGray;
                }
                else if (dtu.Rows.Count != 0)
                {
                    // already registered // go to login // or forgot password
                    lblMsg.Text = "This username is already registered with us. Please try another";
                    lblMsg.Visible = true;
                    lblMsg.BackColor = Color.LightGray;
                    lblMsg.ForeColor = Color.DarkGray;
                }
                else if (dtd.Rows.Count != 0)// if doctor_list  have mail
                {
                    otp = dtd.Rows[0]["pass"].ToString();
                    reg(otp);
                }
                else if (dtr.Rows.Count != 0)// if doctor_list  have mail
                {
                    otp = dtr.Rows[0]["pass"].ToString();
                    reg(otp);
                }
                else if (dtn.Rows.Count != 0)// if nurse list have mail
                {
                    otp = dtn.Rows[0]["pass"].ToString();
                    reg(otp);
                }
                else
                {
                    lblMsg.Text = "This Email ID can not be registered.";
                    lblMsg.Visible = true;
                    lblMsg.BackColor = Color.Red;
                    lblMsg.ForeColor = Color.White;
                }
            }
        }

        void reg(string otp)
         {
            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();

            String pname = "sp_login_user";
            MySqlCommand cmd = new MySqlCommand(pname, sqlconn);

            cmd.Parameters.AddWithValue("Maction", "INSERT");
            cmd.Parameters.AddWithValue("Mpassword", otp);
           // otp = dtn.Rows[0]["pass"].ToString();
        

            cmd.Parameters.AddWithValue("Mhid", "h1");
            cmd.Parameters.AddWithValue("Mdesignation", ddl_designation.SelectedValue);
            cmd.Parameters.AddWithValue("Mrole", "user");
            cmd.Parameters.AddWithValue("Msalutation", ddl_sal.SelectedValue);
            cmd.Parameters.AddWithValue("Mfname", tb_fname.Text);
            cmd.Parameters.AddWithValue("Mlname", tb_lname.Text);
            cmd.Parameters.AddWithValue("Musername", tb_username.Text);
            cmd.Parameters.AddWithValue("Memail", tb_mail.Text);
            cmd.Parameters.AddWithValue("Mmob", tb_mob.Text);
            cmd.CommandType = CommandType.StoredProcedure;

            Int32 Affectedrows = cmd.ExecuteNonQuery();
            if (Affectedrows != 0)
            {
                string to = tb_mail.Text; //To address    
                string from = "patientdashbard@gmail.com"; //From address    
                MailMessage message = new MailMessage(from, to);

                //string mailbody = "In this article you will learn how to send a email using Asp.Net & C# " + otp.Trim();
                StreamReader reader = new StreamReader(Server.MapPath("~/pass_mail.html"));
                string readFile = reader.ReadToEnd();
                string myString = "";
                myString = readFile;
                myString = myString.Replace("$$User$$", tb_username.Text);
                myString = myString.Replace("$$Pass$$", otp);
                message.Subject = "Pateint Dashboard Registration";
               // Host = relay-hosting.secureserver.net
                //Port = 25

                message.Body = myString.ToString();
                message.BodyEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;
               // SmtpClient client = new SmtpClient("relay-hosting.secureserver.net", 25); //Gmail smtp on godaddy
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587); // on local
                System.Net.NetworkCredential basicCredential1 = new
                System.Net.NetworkCredential("patientdashbard@gmail.com", "fvewwqmnstjbbfpg");
                //client.EnableSsl = false; // on godaddy
                client.EnableSsl = true; // on local
                client.UseDefaultCredentials = false;
                client.Credentials = basicCredential1;
                try
                {
                    client.Send(message);
                    lblMsg.Text = "Registered Successfully. </br> We've sent your login credentials to the registered Email ID. Please Check";
                    lblMsg.BackColor = Color.Green;
                    lblMsg.ForeColor = Color.White;
                    lblMsg.Visible = true;
                }

                catch (Exception ex)
                {
                    throw ex;
                }

            }
            sqlconn.Close();
        }

        protected void goto_login(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}