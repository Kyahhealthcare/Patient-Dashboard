using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TVDisplay
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create("http://www.stackoverflow.com");
            //httpReq.AllowAutoRedirect = false;

            //HttpWebResponse httpRes = (HttpWebResponse)httpReq.GetResponse();

            //if (httpRes.StatusCode != HttpStatusCode.NotFound)
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() == true)
            {
                //on internet
                online();
            }
            else
            {
                // offline
                offline();   
            }
            // Close the response.
          //  httpRes.Close();
        }

        void offline()
        {
            if (Request.Cookies["check_user"] != null)
            {
                if (Request.Cookies["userid"] != null && Request.Cookies["pwd"] != null)
                {
                    Session["username"] = Request.Cookies["userid"].Value.ToString();
                    Session["hid"] = Request.Cookies["hid"].Value.ToString();
                    Response.Redirect("Home.aspx");
                }
            }
            else
            {
                //String userAgent;
                //userAgent = Request.UserAgent;
                //GetDeviceType(userAgent);
                Response.Redirect("Login.aspx");
            }
        }

        void online()
        {
            if (Request.Cookies["userid"] != null && Request.Cookies["pwd"] != null)
            {
                String con = ConfigurationManager.ConnectionStrings["tvcon"].ConnectionString;
                MySqlConnection sqlconn = new MySqlConnection(con);
                sqlconn.Open();

                string query2 = "SELECT * FROM login_user where username= '" + Request.Cookies["userid"].Value.ToString() + "' ";
                MySqlCommand cmd3 = new MySqlCommand(query2, sqlconn);
                DataTable dts = new DataTable();
                dts.Load(cmd3.ExecuteReader());
                if (dts.Rows.Count != 0)
                {
                    if (Request.Cookies["pwd"].Value.ToString() == dts.Rows[0]["password"].ToString())
                    {
                        Session["username"] = Request.Cookies["userid"].Value.ToString();
                        Session["hid"] = dts.Rows[0]["hid"].ToString();
                        Response.Redirect("Home.aspx");
                    }
                    else
                    {
                        Response.Redirect("Login.aspx");
                    }
                }
            }
            else
            {
                String userAgent;
                userAgent = Request.UserAgent;
                GetDeviceType(userAgent);
            }
        }


        void GetDeviceType(string ua)
        {
            string ret = "";
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

            if(ret=="tv")
            {
                Response.Redirect("dashboard.aspx");
            }
            else if(ret == "mobile")
            {
                Response.Redirect("Login.aspx");
            }
            else if(ret == "desktop")
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}