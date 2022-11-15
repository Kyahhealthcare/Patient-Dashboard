using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Cryptography;
using NReco.VideoConverter;
using System.Web;

namespace TVDisplay
{
    public partial class documents : System.Web.UI.Page
    {
        public static string s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12;
       
        public static readonly List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG" };
        private static string query;
        private MemoryStream cachedStream;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] == null)
                {
                    Response.Redirect("Login.aspx");
                }

                InitializeCulture();
                if (Session["uhid"] != null)
                {
                    add_to_gallery();

                    if(Cache["file"] != null)
                    {
                        //check_files();
                    }
                }
                else
                {
                    Session["pdf_file"] = null;
                }
            }
            add_to_gallery();
            
        }

        void check_files()
        {
            String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(con);

            sqlconn.Open();

            string query = "SELECT * FROM documents where uhid= '" + Session["uhid"].ToString() + "' order by date desc ";
            MySqlCommand cmd = new MySqlCommand(query, sqlconn);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    if(dr["status"].ToString()== "cached")
                    {
                        String path1 = Server.MapPath("~/PatientImages/");
                        if (!Directory.Exists(path1))
                        {
                            Directory.CreateDirectory(path1);
                        }

                        String path = Server.MapPath("~/PatientImages/" + Session["uhid"].ToString() + "/");
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }

                        String path2 = Server.MapPath("~/PatientImages/" + "JunkVideos" + "/");
                        if (!Directory.Exists(path2))
                        {
                            Directory.CreateDirectory(path2);
                        }

                        string s = dr["path"].ToString() ;

                        string[] subs = s.Split('/');


                        string targetPath = path + Session["uhid"].ToString().Trim() + subs[3];

                        string ss = subs[3].ToString();


                        // FileUpload fileone = new FileUpload();
                        // MyFile = path;
                        // HttpPostedFileBase
                        // fileone.PostedFile.FileName = Cache[ss].ToString();

                      

                        HttpPostedFile fileone= Cache[ss] as HttpPostedFile;
                       // hh = Cache[ss];

                      //   var fileone = Cache[ss] as HttpPostedFile;


                        Stream strm = fileone.InputStream;
                        var targetFile = targetPath;


                        if (ImageExtensions.Contains(Path.GetExtension(targetFile).ToUpperInvariant()))
                        {
                            compressimagesize(0.8, strm, targetFile);
                        }
                        else if (targetFile.EndsWith(".pdf"))
                        {
                            fileone.SaveAs(targetFile);
                        }
                        else
                        {
                            string junk_path = path2 + Session["uhid"].ToString().Trim() + fileone;
                            fileone.SaveAs(junk_path);
                            var ffMpeg = new NReco.VideoConverter.FFMpegConverter();
                            ffMpeg.ConvertMedia(junk_path, targetFile, Format.mp4);
                        }
                    }
                }                 
            }
            sqlconn.Close();
        }


        protected void btn_remove_Click(object sender, EventArgs e)
        {
            ClearControls(this);
            Session["uhid"] = null;
            Response.Redirect("documents.aspx");
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
        protected override void InitializeCulture()
        {
            CultureInfo CI = new CultureInfo("pt-PT");
            CI.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";

            Thread.CurrentThread.CurrentCulture = CI;
            Thread.CurrentThread.CurrentUICulture = CI;
            base.InitializeCulture();
        }
        
        protected void upload(object sender, EventArgs e)
        {
            if (Session["uhid"] != null)
            {
                try
                {
                    //if (FileUpload1.HasFile)
                    //{

                        image1.ImageUrl = "";
                        image_Panel1.Visible = false;
                        mpe1.Hide();

                      //  string fileName1 = Path.GetFileName(FileUpload1.PostedFile.FileName);
                   // byte[] byteArray = File.ReadAllBytes(fileName1);
                    //Cache.Insert("'" + Session["username"] + "'", fileContent, new System.Web.Caching.CacheDependency(Server.MapPath("'" + fileName1 + "'")));

                    //string fileContent;// = Cache["SampleFile"] as string;
                    //if (string.IsNullOrEmpty(fileContent))
                    //{
                    //    using (StreamReader sr = File.OpenText(Server.MapPath(fileName1)))
                    //    {
                    //        fileContent = sr.ReadToEnd();
                    //        Cache.Insert("SampleFile", fileContent, new System.Web.Caching.CacheDependency(Server.MapPath(fileName1)));
                    //    }
                    //}
                    //TextBox1.Text = fileContent;

                   // upload_ss();
                   // }
                }
                catch (Exception m)
                {
                    Label l = new Label();
                    l.Text = "<script>alert('" + m.Message + "')</script>";
                    Form.Controls.Add(l);
                }
            }
        }



        //public void CacheFile(string fileName)
        //{
        //    cachedStream = new MemoryStream(File.ReadAllBytes(fileName));
        //    var d = "fgfgfgf";
        //    var f = "fgfgffg";
        //}

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

        void upload_ss()
        {
            //HttpPostedFile file = myFile.PostedFile.FileName;
            String fileName = myFile.PostedFile.FileName;
            // string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);

            //String path1 = Server.MapPath("~/PatientImages/");
            //if (!Directory.Exists(path1))
            //{
            //    Directory.CreateDirectory(path1);
            //}

            //String path = Server.MapPath("~/PatientImages/" + Session["uhid"].ToString() + "/");
            //if (!Directory.Exists(path))
            //{
            //    Directory.CreateDirectory(path);
            //}

            //String path2 = Server.MapPath("~/PatientImages/" + "JunkVideos" + "/");
            //if (!Directory.Exists(path2))
            //{
            //    Directory.CreateDirectory(path2);
            //}

            //  string targetPath = path + Session["uhid"].ToString().Trim() + fileName;

            // Stream strm = FileUpload1.PostedFile.InputStream;
            // var targetFile = targetPath;
            //if (ImageExtensions.Contains(Path.GetExtension(targetFile).ToUpperInvariant()))
            //{
            //    compressimagesize(0.8, strm, targetFile);
            //}
            //else if (targetFile.EndsWith(".pdf"))
            //{
            //    FileUpload1.PostedFile.SaveAs(targetFile);
            //}
            //else
            //{
            //    string junk_path = path2 + Session["uhid"].ToString().Trim() + fileName;
            //    FileUpload1.PostedFile.SaveAs(junk_path);
            //    var ffMpeg = new NReco.VideoConverter.FFMpegConverter();
            //    ffMpeg.ConvertMedia(junk_path, targetFile, Format.mp4);
            //}

            //String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            //MySqlConnection sqlconn = new MySqlConnection(con);

            //String pname2 = "sp_documents";
            //MySqlCommand cmd2 = new MySqlCommand(pname2, sqlconn);

            //sqlconn.Open();

            //cmd2.Parameters.AddWithValue("Maction", "INSERT");

            //cmd2.CommandType = CommandType.StoredProcedure;

            //String str2 = "~/PatientImages/" + Session["uhid"].ToString() + "/" + Session["uhid"].ToString().Trim() + fileName;

            //cmd2.Parameters.AddWithValue("Muhid", Session["uhid"].ToString());
            //cmd2.Parameters.AddWithValue("Mdate", Convert.ToDateTime(tb_date.Text));
            //cmd2.Parameters.AddWithValue("Mtime", tb_time.Text);
            //cmd2.Parameters.AddWithValue("Mtype", ddl_type.SelectedValue);
            //cmd2.Parameters.AddWithValue("Mpath", str2);

            //Int32 Affectedrows = cmd2.ExecuteNonQuery();
            //if (Affectedrows != 0)
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('File Uploaded Successfully');", true);
            //    add_to_gallery();
            //}

            //sqlconn.Close();
        }
        protected void img1_clicked(object sender, ImageClickEventArgs e)
        {
            add_to_gallery();
            if (img1.ImageUrl == "Images/pdf.png")
            {
                Session["pdf_file"] = s1;
                string url = "pdf_form.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "", "window.open('" + url + "');", true);
                image_Panel1.Visible = false;
            }
            else
            {
                mpe1.Show();
                image1.ImageUrl = img1.ImageUrl;
                image_Panel1.Visible = true;
            }
        }
        protected void img2_clicked(object sender, ImageClickEventArgs e)
        {
            add_to_gallery();
            if (img2.ImageUrl == "Images/pdf.png")
            {
                Session["pdf_file"] = s2;
                string url = "pdf_form.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "", "window.open('" + url + "');", true);
                image_Panel1.Visible = false;
            }
            else
            {
                mpe1.Show();
                image1.ImageUrl = img2.ImageUrl;
                image_Panel1.Visible = true;
            }
        }

        protected void img3_clicked(object sender, ImageClickEventArgs e)
        {
            add_to_gallery();
            if (img3.ImageUrl == "Images/pdf.png")
            {
                Session["pdf_file"] = s3;
                string url = "pdf_form.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "", "window.open('" + url + "');", true);
                image_Panel1.Visible = false;
            }
            else
            {
                mpe1.Show();
                image1.ImageUrl = img3.ImageUrl;
                image_Panel1.Visible = true;
            }
        }

        protected void upload_date(object sender, EventArgs e)
        {
            Session["date"] = tb_date.Text;
        }

        protected void upload_time(object sender, EventArgs e)
        {
            Session["time"] = tb_time.Text;
        }

        protected void refresh_images(object sender, EventArgs e)
        {
            Response.Redirect("documents.aspx");
        }

        protected void img4_clicked(object sender, ImageClickEventArgs e)
        {
            add_to_gallery();
            if (img4.ImageUrl == "Images/pdf.png")
            {
                Session["pdf_file"] = s4;
                string url = "pdf_form.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "", "window.open('" + url + "');", true);
                image_Panel1.Visible = false;
            }
            else
            {
                mpe1.Show();
                image1.ImageUrl = img4.ImageUrl;
                image_Panel1.Visible = true;
            }
        }

        protected void img5_clicked(object sender, ImageClickEventArgs e)
        {
            add_to_gallery();
            if (img5.ImageUrl == "Images/pdf.png")
            {
                Session["pdf_file"] = s5;
                string url = "pdf_form.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "", "window.open('" + url + "');", true);
                image_Panel1.Visible = false;
            }
            else
            {
                mpe1.Show();
                image1.ImageUrl = img5.ImageUrl;
                image_Panel1.Visible = true;
            }
        }

        protected void img6_clicked(object sender, ImageClickEventArgs e)
        {
            add_to_gallery();
            if (img6.ImageUrl == "Images/pdf.png")
            {
                Session["pdf_file"] = s6;
                string url = "pdf_form.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "", "window.open('" + url + "');", true);
                image_Panel1.Visible = false;
            }
            else
            {
                mpe1.Show();
                image1.ImageUrl = img6.ImageUrl;
                image_Panel1.Visible = true;
            }
        }

        protected void img7_clicked(object sender, ImageClickEventArgs e)
        {
            add_to_gallery();
            if (img7.ImageUrl == "Images/pdf.png")
            {
                Session["pdf_file"] = s7;
                string url = "pdf_form.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "", "window.open('" + url + "');", true);
                image_Panel1.Visible = false;
            }
            else
            {
                mpe1.Show();
                image1.ImageUrl = img7.ImageUrl;
                image_Panel1.Visible = true;
            }
        }

        protected void img8_clicked(object sender, ImageClickEventArgs e)
        {
            add_to_gallery();
            if (img8.ImageUrl == "Images/pdf.png")
            {
                Session["pdf_file"] = s8;
                string url = "pdf_form.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "", "window.open('" + url + "');", true);
                image_Panel1.Visible = false;
            }
            else
            {
                mpe1.Show();
                image1.ImageUrl = img8.ImageUrl;
                image_Panel1.Visible = true;
            }
        }

        protected void img9_clicked(object sender, ImageClickEventArgs e)
        {
            add_to_gallery();
            if (img9.ImageUrl == "Images/pdf.png")
            {
                Session["pdf_file"] = s9;
                string url = "pdf_form.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "", "window.open('" + url + "');", true);
                image_Panel1.Visible = false;
            }
            else
            {
                mpe1.Show();
                image1.ImageUrl = img9.ImageUrl;
                image_Panel1.Visible = true;
            }
        }

        protected void img10_clicked(object sender, ImageClickEventArgs e)
        {
            add_to_gallery();
            if (img10.ImageUrl == "Images/pdf.png")
            {
                Session["pdf_file"] = s10;
                string url = "pdf_form.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "", "window.open('" + url + "');", true);
                image_Panel1.Visible = false;
            }
            else
            {
                mpe1.Show();
                image1.ImageUrl = img10.ImageUrl;
                image_Panel1.Visible = true;
            }
        }

        protected void img11_clicked(object sender, ImageClickEventArgs e)
        {
            add_to_gallery();
            if (img11.ImageUrl == "Images/pdf.png")
            {
                Session["pdf_file"] = s11;
                string url = "pdf_form.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "", "window.open('" + url + "');", true);
                image_Panel1.Visible = false;
            }
            else
            {
                mpe1.Show();
                image1.ImageUrl = img11.ImageUrl;
                image_Panel1.Visible = true;
            }
        }

        protected void img12_clicked(object sender, ImageClickEventArgs e)
        {
            add_to_gallery();
            if (img12.ImageUrl == "Images/pdf.png")
            {
                Session["pdf_file"] = s12;
                string url = "pdf_form.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "", "window.open('" + url + "');", true);
                image_Panel1.Visible = false;
            }
            else
            {
                mpe1.Show();
                image1.ImageUrl = img12.ImageUrl;
                image_Panel1.Visible = true;
            }
        }

        protected void image_close(object sender, EventArgs e)
        {
            mpe1.Hide();
            add_to_gallery();
        }


        void add_to_gallery()
        {
            if (Session["uhid"] != null)
            {
                String con = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                MySqlConnection sqlconn = new MySqlConnection(con);

                sqlconn.Open();

                Session["file_type"] = ddl_type.SelectedValue;

                if (ddl_type.SelectedItem.Value == "xray")
                {
                    query = "SELECT * FROM documents where uhid= '" + Session["uhid"].ToString() + "' and type='xray' order by date desc ";

                }

                if (ddl_type.SelectedItem.Value == "CT Head")
                {
                    query = "SELECT * FROM documents where uhid= '" + Session["uhid"].ToString() + "' and type='CT Head' order by date desc ";

                }

                if (ddl_type.SelectedItem.Value == "CT Spinal")
                {
                    query = "SELECT * FROM documents where uhid= '" + Session["uhid"].ToString() + "' and type='CT Spinal' order by date desc ";

                }

                if (ddl_type.SelectedItem.Value == "Nursing Notes")
                {
                    query = "SELECT * FROM documents where uhid= '" + Session["uhid"].ToString() + "' and type='Nursing Notes' order by date desc ";

                }

                if (ddl_type.SelectedItem.Value == "Treatment")
                {
                    query = "SELECT * FROM documents where uhid= '" + Session["uhid"].ToString() + "' and type='Treatment' order by date desc ";

                }

                if (ddl_type.SelectedItem.Value == "Monitor Screen")
                {
                    query = "SELECT * FROM documents where uhid= '" + Session["uhid"].ToString() + "' and type='Monitor Screen' order by date desc ";

                }

                if (ddl_type.SelectedItem.Value == "Ventilator Screen")
                {
                    query = "SELECT * FROM documents where uhid= '" + Session["uhid"].ToString() + "' and type='Ventilator Screen' order by date desc ";

                }

                if (ddl_type.SelectedItem.Value == "ABG")
                {
                    query = "SELECT * FROM documents where uhid= '" + Session["uhid"].ToString() + "' and type='ABG' order by date desc";

                }

                if (ddl_type.SelectedItem.Value == "Lab Reports")
                {
                    query = "SELECT * FROM documents where uhid= '" + Session["uhid"].ToString() + "' and type='Lab Reports' order by date desc ";

                }

                if (ddl_type.SelectedItem.Value == "Other Documents")
                {
                    query = "SELECT * FROM documents where uhid= '" + Session["uhid"].ToString() + "' and type='Other Documents' order by date desc ";

                }
                if (ddl_type.SelectedItem.Value == "MRI")
                {
                    query = "SELECT * FROM documents where uhid= '" + Session["uhid"].ToString() + "' and type='MRI' order by date desc ";

                }
                if (ddl_type.SelectedItem.Value == "Discharge Summary")
                {
                    query = "SELECT * FROM documents where uhid= '" + Session["uhid"].ToString() + "' and type='Discharge Summary' order by date desc ";

                }
                if (ddl_type.SelectedItem.Value == "")
                {
                    img1.ImageUrl = "";
                    img2.ImageUrl = "";
                    img3.ImageUrl = "";
                    img4.ImageUrl = "";
                    img5.ImageUrl = "";
                    img6.ImageUrl = "";
                    img7.ImageUrl = "";
                    img8.ImageUrl = "";
                    img9.ImageUrl = "";
                    img10.ImageUrl = "";
                    img11.ImageUrl = "";
                    img12.ImageUrl = "";
                    vid1.Src = "";
                    vid2.Src = "";
                    vid3.Src = "";
                    vid4.Src = "";
                    vid5.Src = "";
                    vid6.Src = "";
                    vid7.Src = "";
                    vid8.Src = "";
                    vid9.Src = "";
                    vid10.Src = "";
                    vid11.Src = "";
                    vid12.Src = "";
                }

                if (query != null)
                {
                    MySqlCommand cmd = new MySqlCommand(query, sqlconn);

                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        using (DataTable dts = new DataTable())
                        {
                            sda.Fill(dts);
                            if (dts.Rows.Count != 0)
                            {
                                img1.ImageUrl = "";
                                img2.ImageUrl = "";
                                img3.ImageUrl = "";
                                img4.ImageUrl = "";
                                img5.ImageUrl = "";
                                img6.ImageUrl = "";
                                img7.ImageUrl = "";
                                img8.ImageUrl = "";
                                img9.ImageUrl = "";
                                img10.ImageUrl = "";
                                img11.ImageUrl = "";
                                img12.ImageUrl = "";
                                vid1.Src = "";
                                vid2.Src = "";
                                vid3.Src = "";
                                vid4.Src = "";
                                vid5.Src = "";
                                vid6.Src = "";
                                vid7.Src = "";
                                vid8.Src = "";
                                vid9.Src = "";
                                vid10.Src = "";
                                vid11.Src = "";
                                vid12.Src = "";

                                String path1 = Server.MapPath("~/PatientImages/");
                                if (!Directory.Exists(path1))
                                {
                                    Directory.CreateDirectory(path1);
                                }

                                String path = Server.MapPath("~/PatientImages/" + Session["uhid"].ToString() + "/");
                                if (!Directory.Exists(path))
                                {
                                    Directory.CreateDirectory(path);
                                }

                                for (int i = 0; i < dts.Rows.Count; i++)
                                {
                                    if (img1.ImageUrl == "" && vid1.Src=="")
                                    {
                                        i1.Visible = true;
                                        if (dts.Rows[i]["path"].ToString().EndsWith(".pdf"))
                                        {
                                            img1.Visible = true;
                                            vid1.Visible = false;
                                            s1 = dts.Rows[i]["path"].ToString();
                                            img1.ImageUrl = "Images/pdf.png";
                                        }
                                        else if (dts.Rows[i]["path"].ToString().EndsWith(".mp4"))
                                        {
                                            img1.Visible = false;
                                            vid1.Visible = true;
                                            vid1.Src = dts.Rows[i]["path"].ToString();
                                        }
                                        else
                                        {
                                            img1.Visible = true;
                                            vid1.Visible = false;
                                            img1.ImageUrl = dts.Rows[i]["path"].ToString();
                                        }
                                        img_date1.Text = Convert.ToDateTime(dts.Rows[i]["date"]).ToString("dd-MM-yyyy");
                                        img_time1.Text = dts.Rows[i]["time"].ToString();
                                    }
                                    else if (img2.ImageUrl == "" && vid2.Src == "")
                                    {
                                        i2.Visible = true;
                                        if (dts.Rows[i]["path"].ToString().EndsWith(".pdf"))
                                        {
                                            img2.Visible = true;
                                            vid2.Visible = false;
                                            s2 = dts.Rows[i]["path"].ToString();
                                            img2.ImageUrl = "Images/pdf.png";
                                        }
                                        else if (dts.Rows[i]["path"].ToString().EndsWith(".mp4"))
                                        {
                                            img2.Visible = false;
                                            vid2.Visible = true;
                                            vid2.Src = dts.Rows[i]["path"].ToString();
                                        }
                                        else
                                        {
                                            img2.Visible = true;
                                            vid2.Visible = false;
                                            img2.ImageUrl = dts.Rows[i]["path"].ToString();
                                        }
                                        img_date2.Text = Convert.ToDateTime(dts.Rows[i]["date"]).ToString("dd-MM-yyyy");
                                        img_time2.Text = dts.Rows[i]["time"].ToString();
                                    }
                                    else if (img3.ImageUrl == "" && vid3.Src == "")
                                    {
                                        i3.Visible = true;
                                        if (dts.Rows[i]["path"].ToString().EndsWith(".pdf"))
                                        {
                                            img3.Visible = true;
                                            vid3.Visible = false;
                                            s3 = dts.Rows[i]["path"].ToString();
                                            img3.ImageUrl = "Images/pdf.png";
                                        }
                                        else if (dts.Rows[i]["path"].ToString().EndsWith(".mp4"))
                                        {
                                            img3.Visible = false;
                                            vid3.Visible = true;
                                            vid3.Src = dts.Rows[i]["path"].ToString();
                                        }
                                        else
                                        {
                                            img3.Visible = true;
                                            vid3.Visible = false;
                                            img3.ImageUrl = dts.Rows[i]["path"].ToString();
                                        }
                                        img_date3.Text = Convert.ToDateTime(dts.Rows[i]["date"]).ToString("dd-MM-yyyy");
                                        img_time3.Text = dts.Rows[i]["time"].ToString();
                                    }
                                    else if (img4.ImageUrl == "" && vid4.Src == "")
                                    {
                                        i4.Visible = true;
                                        if (dts.Rows[i]["path"].ToString().EndsWith(".pdf"))
                                        {
                                            img4.Visible = true;
                                            vid4.Visible = false;
                                            s4 = dts.Rows[i]["path"].ToString();
                                            img4.ImageUrl = "Images/pdf.png";
                                        }
                                        else if (dts.Rows[i]["path"].ToString().EndsWith(".mp4"))
                                        {
                                            img4.Visible = false;
                                            vid4.Visible = true;
                                            vid4.Src = dts.Rows[i]["path"].ToString();
                                        }
                                        else
                                        {
                                            img4.Visible = true;
                                            vid4.Visible = false;
                                            img4.ImageUrl = dts.Rows[i]["path"].ToString();
                                        }
                                        img_date4.Text = Convert.ToDateTime(dts.Rows[i]["date"]).ToString("dd-MM-yyyy");
                                        img_time4.Text = dts.Rows[i]["time"].ToString();
                                    }
                                    else if (img5.ImageUrl == "" && vid5.Src == "")
                                    {
                                        i5.Visible = true;
                                        if (dts.Rows[i]["path"].ToString().EndsWith(".pdf"))
                                        {
                                            img5.Visible = true;
                                            vid5.Visible = false;
                                            s5 = dts.Rows[i]["path"].ToString();
                                            img5.ImageUrl = "Images/pdf.png";
                                        }
                                        else if (dts.Rows[i]["path"].ToString().EndsWith(".mp4"))
                                        {
                                            img5.Visible = false;
                                            vid5.Visible = true;
                                            vid5.Src = dts.Rows[i]["path"].ToString();
                                        }
                                        else
                                        {
                                            img5.Visible = true;
                                            vid5.Visible = false;
                                            img5.ImageUrl = dts.Rows[i]["path"].ToString();
                                        }
                                        img_date5.Text = Convert.ToDateTime(dts.Rows[i]["date"]).ToString("dd-MM-yyyy");
                                        img_time5.Text = dts.Rows[i]["time"].ToString();
                                    }
                                    else if (img6.ImageUrl == "" && vid6.Src == "")
                                    {
                                        i6.Visible = true;
                                        if (dts.Rows[i]["path"].ToString().EndsWith(".pdf"))
                                        {
                                            img6.Visible = true;
                                            vid6.Visible = false;
                                            s6 = dts.Rows[i]["path"].ToString();
                                            img6.ImageUrl = "Images/pdf.png";
                                        }
                                        else if (dts.Rows[i]["path"].ToString().EndsWith(".mp4"))
                                        {
                                            img6.Visible = false;
                                            vid6.Visible = true;
                                            vid6.Src = dts.Rows[i]["path"].ToString();
                                        }
                                        else
                                        {
                                            img6.Visible = true;
                                            vid6.Visible = false;
                                            img6.ImageUrl = dts.Rows[i]["path"].ToString();
                                        }
                                        img_date6.Text = Convert.ToDateTime(dts.Rows[i]["date"]).ToString("dd-MM-yyyy");
                                        img_time6.Text = dts.Rows[i]["time"].ToString();
                                    }
                                    else if (img7.ImageUrl == "" && vid7.Src == "")
                                    {
                                        i7.Visible = true;
                                        if (dts.Rows[i]["path"].ToString().EndsWith(".pdf"))
                                        {
                                            img7.Visible = true;
                                            vid7.Visible = false;
                                            s7 = dts.Rows[i]["path"].ToString();
                                            img7.ImageUrl = "Images/pdf.png";
                                        }
                                        else if (dts.Rows[i]["path"].ToString().EndsWith(".mp4"))
                                        {
                                            img7.Visible = false;
                                            vid7.Visible = true;
                                            vid7.Src = dts.Rows[i]["path"].ToString();
                                        }
                                        else
                                        {
                                            img7.Visible = true;
                                            vid7.Visible = false;
                                            img7.ImageUrl = dts.Rows[i]["path"].ToString();
                                        }
                                        img_date7.Text = Convert.ToDateTime(dts.Rows[i]["date"]).ToString("dd-MM-yyyy");
                                        img_time7.Text = dts.Rows[i]["time"].ToString();
                                    }
                                    else if (img8.ImageUrl == "" && vid8.Src == "")
                                    {
                                        i8.Visible = true;
                                        if (dts.Rows[i]["path"].ToString().EndsWith(".pdf"))
                                        {
                                            img8.Visible = true;
                                            vid8.Visible = false;
                                            s8 = dts.Rows[i]["path"].ToString();
                                            img8.ImageUrl = "Images/pdf.png";
                                        }
                                        else if (dts.Rows[i]["path"].ToString().EndsWith(".mp4"))
                                        {
                                            img8.Visible = false;
                                            vid8.Visible = true;
                                            vid8.Src = dts.Rows[i]["path"].ToString();
                                        }
                                        else
                                        {
                                            img8.Visible = true;
                                            vid8.Visible = false;
                                            img8.ImageUrl = dts.Rows[i]["path"].ToString();
                                        }
                                        img_date8.Text = Convert.ToDateTime(dts.Rows[i]["date"]).ToString("dd-MM-yyyy");
                                        img_time8.Text = dts.Rows[i]["time"].ToString();
                                    }
                                    else if (img9.ImageUrl == "" && vid9.Src == "")
                                    {
                                        i9.Visible = true;
                                        if (dts.Rows[i]["path"].ToString().EndsWith(".pdf"))
                                        {
                                            img9.Visible = true;
                                            vid9.Visible = false;
                                            s9 = dts.Rows[i]["path"].ToString();
                                            img9.ImageUrl = "Images/pdf.png";
                                        }
                                        else if (dts.Rows[i]["path"].ToString().EndsWith(".mp4"))
                                        {
                                            img9.Visible = false;
                                            vid9.Visible = true;
                                            vid9.Src = dts.Rows[i]["path"].ToString();
                                        }
                                        else
                                        {
                                            img9.Visible = true;
                                            vid9.Visible = false;
                                            img9.ImageUrl = dts.Rows[i]["path"].ToString();
                                        }
                                        img_date9.Text = Convert.ToDateTime(dts.Rows[i]["date"]).ToString("dd-MM-yyyy");
                                        img_time9.Text = dts.Rows[i]["time"].ToString();
                                    }
                                    else if (img10.ImageUrl == "" && vid10.Src == "")
                                    {
                                        i10.Visible = true;
                                        if (dts.Rows[i]["path"].ToString().EndsWith(".pdf"))
                                        {
                                            img10.Visible = true;
                                            vid10.Visible = false;
                                            s10 = dts.Rows[i]["path"].ToString();
                                            img10.ImageUrl = "Images/pdf.png";
                                        }
                                        else if (dts.Rows[i]["path"].ToString().EndsWith(".mp4"))
                                        {
                                            img10.Visible = false;
                                            vid10.Visible = true;
                                            vid10.Src = dts.Rows[i]["path"].ToString();
                                        }
                                        else
                                        {
                                            img10.Visible = true;
                                            vid10.Visible = false;
                                            img10.ImageUrl = dts.Rows[i]["path"].ToString();
                                        }
                                        img_date10.Text = Convert.ToDateTime(dts.Rows[i]["date"]).ToString("dd-MM-yyyy");
                                        img_time10.Text = dts.Rows[i]["time"].ToString();
                                    }
                                    else if (img11.ImageUrl == "" && vid11.Src == "")
                                    {
                                        i11.Visible = true;
                                        if (dts.Rows[i]["path"].ToString().EndsWith(".pdf"))
                                        {
                                            img11.Visible = true;
                                            vid11.Visible = false;
                                            s11 = dts.Rows[i]["path"].ToString();
                                            img11.ImageUrl = "Images/pdf.png";
                                        }
                                        else if (dts.Rows[i]["path"].ToString().EndsWith(".mp4"))
                                        {
                                            img11.Visible = false;
                                            vid11.Visible = true;
                                            vid11.Src = dts.Rows[i]["path"].ToString();
                                        }
                                        else
                                        {
                                            img11.Visible = true;
                                            vid11.Visible = false;
                                            img11.ImageUrl = dts.Rows[i]["path"].ToString();
                                        }
                                        img_date11.Text = Convert.ToDateTime(dts.Rows[i]["date"]).ToString("dd-MM-yyyy");
                                        img_time11.Text = dts.Rows[i]["time"].ToString();
                                    }
                                    else if (img12.ImageUrl == "" && vid12.Src == "")
                                    {
                                        i12.Visible = true;
                                        if (dts.Rows[i]["path"].ToString().EndsWith(".pdf"))
                                        {
                                            img12.Visible = true;
                                            vid12.Visible = false;
                                            s12 = dts.Rows[i]["path"].ToString();
                                            img12.ImageUrl = "Images/pdf.png";
                                        }
                                        else if (dts.Rows[i]["path"].ToString().EndsWith(".mp4"))
                                        {
                                            img12.Visible = false;
                                            vid12.Visible = true;
                                            vid12.Src = dts.Rows[i]["path"].ToString();
                                        }
                                        else
                                        {
                                            img12.Visible = true;
                                            vid12.Visible = false;
                                            img12.ImageUrl = dts.Rows[i]["path"].ToString();
                                        }
                                        img_date12.Text = Convert.ToDateTime(dts.Rows[i]["date"]).ToString("dd-MM-yyyy");
                                        img_time12.Text = dts.Rows[i]["time"].ToString();
                                    }

                                }

                            }

                        }
                    }
                }

                sqlconn.Close();
            }

        }
       
    }
}