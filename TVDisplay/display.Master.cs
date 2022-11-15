using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TVDisplay
{
    public partial class display : System.Web.UI.MasterPage
    {
        public static string ret = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            blah();
            if (Session["uhid"] != null)
            {
                uhid.Visible = true;
                l_uhid.Text = Session["uhid"].ToString();
            }
            else
            {
                uhid.Visible = false;
            }

            String userAgent;
            userAgent = Request.UserAgent;

            GetDeviceType(userAgent);
            if (ret == "mobile")
            {
             //  panel_main.Attributes.Add("height", "80vh");
             //  panel_main.Attributes.Add("overflow-y", "auto");
            }
           
        }

        protected void tv_click(object sender, EventArgs e)
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
                Response.Redirect("dashboard.aspx");
            }
        }
        void blah() 
        {
            string Path = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            System.IO.FileInfo Info = new System.IO.FileInfo(Path);
            string pageName = Info.Name;

            if (pageName == "Details.aspx")
            {
                heading.InnerText = "Patient Details";
                heading2.InnerText = "Patient Details";
                side_img.ImageUrl = "Images/details.png";

              //  btn_left1.Visible = false;
               // btn_left.Visible = false;                
            }
            if (pageName == "gcs.aspx")
            {
                heading.InnerText = "GCS";
                heading2.InnerText = "GCS";
                side_img.ImageUrl = "Images/details.png";                
            }
            if (pageName == "vitals.aspx")
            {
                heading.InnerText = "Vitals";
                heading2.InnerText = "Vitals";
                side_img.ImageUrl = "Images/vital.png";
            }
            if (pageName == "fever.aspx")
            {
                heading.InnerText = "Fever Pack";
                heading2.InnerText = "Fever Pack";
                side_img.ImageUrl = "Images/details.png";
            }
            if (pageName == "lab.aspx")
            {
                heading.InnerText = "Lab Investigations";
                heading2.InnerText = "Lab Investigations";
                side_img.ImageUrl = "Images/lab.png";
            }
            if (pageName == "surgery.aspx")
            {
                heading.InnerText = "Surgery Details";
                heading2.InnerText = "Surgery Details";
                side_img.ImageUrl = "Images/surgery.jpg";
            }
            if (pageName == "BldTrans.aspx")
            {
                heading.InnerText = "Blood Transfusions";
                heading2.InnerText = "Blood Transfusions";
                side_img.ImageUrl = "Images/bld.jpg";
            }
            if (pageName == "Infusions.aspx")
            {
                heading.InnerText = "Infusions";
                heading2.InnerText = "Infusions";
                side_img.ImageUrl = "Images/bld1.jpg";
            }
            if (pageName == "IO.aspx")
            {
                heading.InnerText = "Last 24H I/O";
                heading2.InnerText = "Last 24H I/O";
                side_img.ImageUrl = "Images/details.png";
            }

            if (pageName == "documents.aspx")
            {
                heading.InnerText = "Upload Documents";
                heading2.InnerText = "Upload Documents";
                side_img.ImageUrl = "Images/doc.jpg";
            }
            if (pageName == "issues.aspx")
            {
                heading.InnerText = "Issues";
                heading2.InnerText = "Issues";
            }
            if (pageName == "Discharge.aspx")
            {
                heading.InnerText = "Discharge Status";
                heading2.InnerText = "Discharge Status";
            }
            if (pageName == "ventilation.aspx")
            {
                heading.InnerText = "Ventilation Modes";
                heading2.InnerText = "Ventilation Modes";
                side_img.ImageUrl = "Images/venti.jpg";
            }
            if (pageName == "plan.aspx")
            {
                heading.InnerText = "Today's Plan";
                heading2.InnerText = "Today's Plan";
                side_img.ImageUrl = "Images/plan.jpg";

                btn_right1.Visible = false;
                btn_right.Visible = false;
            }
        }
        void GetDeviceType(string ua)
        {
            
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

        protected void logout_click(object sender, EventArgs args)
        {
            Session["hid"] = null;
            Session["uhid"] = null;
            Session["username"] = null;
            Response.Redirect("Login.aspx");
        }
        protected void preview_dash(object sender, EventArgs args)
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
                Response.Redirect("dashboard.aspx");
            }
        }
        protected void move_left(object sender, ImageClickEventArgs e)
        {
            string Path = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            System.IO.FileInfo Info = new System.IO.FileInfo(Path);
            string pageName = Info.Name;
            
            if (pageName == "plan.aspx")
            {
                Response.Redirect("ventilation.aspx");
            }
            if (pageName == "ventilation.aspx")
            {
                Response.Redirect("Discharge.aspx");
            }
            if (pageName == "Discharge.aspx")
            {
                Response.Redirect("issues.aspx");
            }
            if (pageName == "issues.aspx")
            {
                Response.Redirect("documents.aspx");
            }
            if (pageName == "documents.aspx")
            {
                Response.Redirect("IO.aspx");
            }
            if (pageName == "IO.aspx")
            {
                Response.Redirect("Infusions.aspx");
            }
            if (pageName == "Infusions.aspx")
            {
                Response.Redirect("BldTrans.aspx");
            }
            if (pageName == "BldTrans.aspx")
            {
                Response.Redirect("surgery.aspx");
            }
            if (pageName == "surgery.aspx")
            {
                Response.Redirect("lab.aspx");
            }
            if (pageName == "lab.aspx")
            {
                Response.Redirect("fever.aspx");
            }
            if (pageName == "fever.aspx")
            {
                Response.Redirect("vitals.aspx");
            }
            if (pageName == "vitals.aspx")
            {
                Response.Redirect("gcs.aspx");
            }
            if (pageName == "gcs.aspx")
            {
                Response.Redirect("Details.aspx");
            }
            if (pageName == "Details.aspx")
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void move_right(object sender, ImageClickEventArgs e)
        {
            string Path = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            System.IO.FileInfo Info = new System.IO.FileInfo(Path);
            string pageName = Info.Name;
            if (pageName == "Details.aspx")
            {
                
                Response.Redirect("gcs.aspx");
               // panel_main.Attributes.Add("class", "w3-animate-left");
            }
            if (pageName == "gcs.aspx")
            {

                Response.Redirect("vitals.aspx");
                // panel_main.Attributes.Add("class", "w3-animate-left");
            }
            if (pageName == "vitals.aspx")
            {
               // panel_main.Attributes.Add("class", "w3-animate-left");
                Response.Redirect("fever.aspx");
            }
            if (pageName == "fever.aspx")
            {
              //  panel_main.Attributes.Add("class", "w3-animate-left");
                Response.Redirect("lab.aspx");
            }
            if (pageName == "lab.aspx")
            {
               // panel_main.Attributes.Add("class", "w3-animate-left");
                Response.Redirect("surgery.aspx");
            }
            if (pageName == "surgery.aspx")
            {
               // panel_main.Attributes.Add("class", "w3-animate-left");
                Response.Redirect("BldTrans.aspx");
            }
            if (pageName == "BldTrans.aspx")
            {
               // panel_main.Attributes.Add("class", "w3-animate-left");
                Response.Redirect("Infusions.aspx");
            }
            if (pageName == "Infusions.aspx")
            {
               // panel_main.Attributes.Add("class", "w3-animate-left");
                Response.Redirect("IO.aspx");
            }
            if (pageName == "IO.aspx")
            {
                //panel_main.Attributes.Add("class", "w3-animate-left");
                Response.Redirect("documents.aspx");
            }

            if (pageName == "documents.aspx")
            {
               // panel_main.Attributes.Add("class", "w3-animate-left");
                Response.Redirect("issues.aspx");
            }
            if (pageName == "issues.aspx")
            {
               // panel_main.Attributes.Add("class", "w3-animate-left");
                Response.Redirect("Discharge.aspx");
            }
            if (pageName == "Discharge.aspx")
            {
                //panel_main.Attributes.Add("class", "w3-animate-left");
                Response.Redirect("ventilation.aspx");
            }
            if (pageName == "ventilation.aspx")
            {
                //panel_main.Attributes.Add("class", "w3-animate-left");
                Response.Redirect("plan.aspx");
            }
            if (pageName == "plan.aspx")
            {
                //Response.Redirect("Discharge.aspx");
            }
        }

        protected void move_left1(object sender, EventArgs e)
        {
            string Path = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            System.IO.FileInfo Info = new System.IO.FileInfo(Path);
            string pageName = Info.Name;
            if (pageName == "plan.aspx")
            {
                Response.Redirect("ventilation.aspx");
            }
            if (pageName == "ventilation.aspx")
            {
                Response.Redirect("Discharge.aspx");
            }
            if (pageName == "Discharge.aspx")
            {
                Response.Redirect("issues.aspx");
            }
            if (pageName == "issues.aspx")
            {
                Response.Redirect("documents.aspx");
            }
            if (pageName == "documents.aspx")
            {
                Response.Redirect("IO.aspx");
            }
            if (pageName == "IO.aspx")
            {
                Response.Redirect("Infusions.aspx");
            }
            if (pageName == "Infusions.aspx")
            {
                Response.Redirect("BldTrans.aspx");
            }
            if (pageName == "BldTrans.aspx")
            {
                Response.Redirect("surgery.aspx");
            }
            if (pageName == "surgery.aspx")
            {
                Response.Redirect("lab.aspx");
            }
            if (pageName == "lab.aspx")
            {
                Response.Redirect("fever.aspx");
            }
            if (pageName == "fever.aspx")
            {
                Response.Redirect("vitals.aspx");
            }
            if (pageName == "vitals.aspx")
            {
                Response.Redirect("gcs.aspx");
            }
            if (pageName == "gcs.aspx")
            {
                Response.Redirect("Details.aspx");
            }
            if (pageName == "Details.aspx")
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void move_right2(object sender, EventArgs e)
        {
            string Path = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            System.IO.FileInfo Info = new System.IO.FileInfo(Path);
            string pageName = Info.Name;
            if (pageName == "Details.aspx")
            {
                Response.Redirect("gcs.aspx");
                // panel_main.Attributes.Add("class", "w3-animate-left");
            }
            if (pageName == "gcs.aspx")
            {
                Response.Redirect("vitals.aspx");
                // panel_main.Attributes.Add("class", "w3-animate-left");
            }
            if (pageName == "vitals.aspx")
            {
               // panel_main.Attributes.Add("class", "w3-animate-left");
                Response.Redirect("fever.aspx");
            }
            if (pageName == "fever.aspx")
            {
               // panel_main.Attributes.Add("class", "w3-animate-left");
                Response.Redirect("lab.aspx");
            }
            if (pageName == "lab.aspx")
            {
                //panel_main.Attributes.Add("class", "w3-animate-left");
                Response.Redirect("surgery.aspx");
            }
            if (pageName == "surgery.aspx")
            {
               // panel_main.Attributes.Add("class", "w3-animate-left");
                Response.Redirect("BldTrans.aspx");
            }
            if (pageName == "BldTrans.aspx")
            {
                //panel_main.Attributes.Add("class", "w3-animate-left");
                Response.Redirect("Infusions.aspx");
            }
            if (pageName == "Infusions.aspx")
            {
               // panel_main.Attributes.Add("class", "w3-animate-left");
                Response.Redirect("IO.aspx");
            }
            if (pageName == "IO.aspx")
            {
                //panel_main.Attributes.Add("class", "w3-animate-left");
                Response.Redirect("documents.aspx");
            }

            if (pageName == "documents.aspx")
            {
                //panel_main.Attributes.Add("class", "w3-animate-left");
                Response.Redirect("issues.aspx");
            }
            if (pageName == "issues.aspx")
            {
                //panel_main.Attributes.Add("class", "w3-animate-left");
                Response.Redirect("Discharge.aspx");
            }
            if (pageName == "Discharge.aspx")
            {
                //panel_main.Attributes.Add("class", "w3-animate-left");
                Response.Redirect("ventilation.aspx");
            }
            if (pageName == "ventilation.aspx")
            {
                //panel_main.Attributes.Add("class", "w3-animate-left");
                Response.Redirect("plan.aspx");
            }
            if (pageName == "plan.aspx")
            {
                //Response.Redirect("Discharge.aspx");
            }
        }

        protected void btn_remove_Click(object sender, EventArgs e)
        {
            Session["uhid"] = null;
            uhid.Visible = false;
            ClearControls(this);
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


    }
}