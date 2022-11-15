using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using NReco.VideoConverter;
using System.Web.SessionState;
using System.Web.Caching;

namespace TVDisplay
{
    public class Handler : IHttpHandler, IRequiresSessionState
    {
        public static readonly List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG", ".JPEG" };
        private static string query;
        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.Files.Count > 0)
            {
                //Fetch the Uploaded File.
                HttpPostedFile postedFile = context.Request.Files[0];

                string fileName = Path.GetFileName(postedFile.FileName);
                string stats = "";

                if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                {
                    String path1 = context.Server.MapPath("~/PatientImages/");
                    if (!Directory.Exists(path1))
                    {
                        Directory.CreateDirectory(path1);
                    }

                    String path = context.Server.MapPath("~/PatientImages/" + context.Session["uhid"].ToString() + "/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    String path2 = context.Server.MapPath("~/PatientImages/" + "JunkVideos" + "/");
                    if (!Directory.Exists(path2))
                    {
                        Directory.CreateDirectory(path2);
                    }

                    string targetPath = path + context.Session["uhid"].ToString().Trim() + fileName;

                    Stream strm = postedFile.InputStream;
                    var targetFile = targetPath;


                    if (ImageExtensions.Contains(Path.GetExtension(targetFile).ToUpperInvariant()))
                    {
                        compressimagesize(0.8, strm, targetFile);
                    }
                    else if (targetFile.EndsWith(".pdf"))
                    {
                        postedFile.SaveAs(targetFile);
                    }
                    else
                    {
                        string junk_path = path2 + context.Session["uhid"].ToString().Trim() + fileName;
                        postedFile.SaveAs(junk_path);
                        var ffMpeg = new NReco.VideoConverter.FFMpegConverter();
                        ffMpeg.ConvertMedia(junk_path, targetFile, Format.mp4);
                    }
                    stats = "uploaded";
                }
                else
                {
                    //string dd = context.Session["uhid"].ToString() + fileName;
                    //context.Cache.Insert(dd, postedFile, null, DateTime.Now.AddSeconds(20), System.Web.Caching.Cache.NoSlidingExpiration);
                    //context.Cache.Insert("file","cached");

                    // stats = "cached";
                }


                String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                MySqlConnection sqlconn = new MySqlConnection(con);

                String pname2 = "sp_documents";
                MySqlCommand cmd2 = new MySqlCommand(pname2, sqlconn);

                sqlconn.Open();

                cmd2.Parameters.AddWithValue("Maction", "INSERT");

                cmd2.CommandType = CommandType.StoredProcedure;

                String str2 = "~/PatientImages/" + context.Session["uhid"].ToString() + "/" + context.Session["uhid"].ToString().Trim() + fileName;

                cmd2.Parameters.AddWithValue("Muhid", context.Session["uhid"].ToString());
                cmd2.Parameters.AddWithValue("Mdate", Convert.ToDateTime(context.Session["date"].ToString()));
                cmd2.Parameters.AddWithValue("Mtime", context.Session["time"].ToString());
                cmd2.Parameters.AddWithValue("Mtype", context.Session["file_type"]);
                cmd2.Parameters.AddWithValue("Mpath", str2);
                cmd2.Parameters.AddWithValue("Mstatus", stats);

                Int32 Affectedrows = cmd2.ExecuteNonQuery();
                if (Affectedrows != 0)
                {
                    // context.ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('File Uploaded Successfully');", true);
                    //  add_to_gallery();
                    //context.Response.Redirect("documents.aspx");
                }

                sqlconn.Close();

                string json = new JavaScriptSerializer().Serialize(
                new
                {
                    name = fileName
                });
                context.Response.StatusCode = (int)HttpStatusCode.OK;
                context.Response.ContentType = "text/json";
                context.Response.Write(json);
                context.Response.End();
            }
            //else
            //{
            //    context.Response.Write(@"<script> alert('Please choose a file'); </ script > ");
                 
            //}
        }
        private void compressimagesize(double scaleFactor, Stream sourcePath, string targetPath)
        {
            using (var image = System.Drawing.Image.FromStream(sourcePath))
            {
                var imgnewwidth = (int)(image.Width * scaleFactor);
                var imgnewheight = (int)(image.Height * scaleFactor);
                var imgthumnail = new Bitmap(imgnewwidth, imgnewheight);
                var imgthumbgraph = Graphics.FromImage(imgthumnail);
                imgthumbgraph.CompositingQuality = CompositingQuality.HighQuality;
                imgthumbgraph.SmoothingMode = SmoothingMode.HighQuality;
                imgthumbgraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                var imageRectangle = new Rectangle(0, 0, imgnewwidth, imgnewheight);
                imgthumbgraph.DrawImage(image, imageRectangle);
                imgthumnail.Save(targetPath, image.RawFormat);
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}