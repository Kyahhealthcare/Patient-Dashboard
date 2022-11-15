using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TVDisplay
{
    public partial class pdf_form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["pdf_file"] != null)
            {
                string path = Server.MapPath(Session["pdf_file"].ToString()).Replace("\\", "/").Trim();
                WebClient User = new WebClient();
                Byte[] FileBuffer = User.DownloadData(path);
                if (FileBuffer != null)
                {
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-length", FileBuffer.Length.ToString());
                    Response.BinaryWrite(FileBuffer);
                }
            }

        }
    }
}