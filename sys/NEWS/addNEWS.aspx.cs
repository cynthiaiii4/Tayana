using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayan.sys.NEWS
{
    public partial class addNEWS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HiddenField hiddenyo = (HiddenField)Master.FindControl("hiddenyo");
            hiddenyo.Value = "004";
        }
        protected void save_Click(object sender, EventArgs e)
        {
            #region 圖片判斷式
            string ifileName = "";
            if (img.HasFile)
            {
                if (img.PostedFile.ContentType.IndexOf("image") == -1)
                {
                    check.Text = "圖片格式錯誤!";
                    return;
                }
                //取得副檔名
                string Extension = Path.GetExtension(img.FileName);
                //新檔案名稱
                ifileName = String.Format("{0:yyyyMMddhhmmsss}{1}", DateTime.Now, Extension);
                //上傳目錄為/upload/Images/
                img.SaveAs(Server.MapPath(String.Format("~/sys/uploadfile/images/{0}", ifileName)));
                GenerateThumbnailImage(ifileName, Server.MapPath("~/sys/uploadfile/images/"), Server.MapPath("~/sys/uploadfile/images/"),"S",95,95);
                GenerateThumbnailImage(ifileName, Server.MapPath("~/sys/uploadfile/images/"), Server.MapPath("~/sys/uploadfile/images/"), "B", 187, 121);
            }
            else
            {
                check.Text = "請上傳圖片";
            }
            #endregion

            

            check.Text = "";
            if (string.IsNullOrEmpty(title.Value))
            {
                check.Text += "*標題不可以為空";
            }
            if (string.IsNullOrEmpty(summary.Value))
            {
                check.Text += "*摘要不可以為空";
            }
            if (string.IsNullOrEmpty(newsContent.Value))
            {
                check.Text += "*內容不可以為空";
            }

            if (string.IsNullOrEmpty(check.Text))
            {
                string ConnectionString = System.Web.Configuration.WebConfigurationManager
                    .ConnectionStrings["ConnectionString"].ToString();
                SqlConnection Connection = new SqlConnection(ConnectionString);

                #region 寫入主表
                SqlCommand Command =
                    new SqlCommand(
                        $"INSERT INTO news(title,summary,img,newsContent,topNews) VALUES(@title,@summary,@img,@newsContent,@topNews)",
                        Connection);
                Command.Parameters.Add("@title", SqlDbType.NVarChar);
                Command.Parameters["@title"].Value = title.Value;
                Command.Parameters.Add("@summary", SqlDbType.NVarChar);
                Command.Parameters["@summary"].Value = summary.Value;
                Command.Parameters.Add("@img", SqlDbType.NVarChar);
                Command.Parameters["@img"].Value = ifileName;
                Command.Parameters.Add("@newsContent", SqlDbType.NVarChar);
                Command.Parameters["@newsContent"].Value = newsContent.Value;
                Command.Parameters.Add("@topNews", SqlDbType.NVarChar);
                if (topNews.Checked)
                {
                    Command.Parameters["@topNews"].Value = true;
                }
                else
                {
                    Command.Parameters["@topNews"].Value = false;
                }
                

                Connection.Open();
                Command.ExecuteNonQuery();
                Connection.Close();

                #endregion

                Response.Redirect("~/sys/NEWS/NEWS.aspx");
            }

        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/sys/NEWS/NEWS.aspx");
        }

        static public void GenerateThumbnailImage(string name, string source, string target, string suffix, int MaxWidth, int MaxHight)
        {
            System.Drawing.Image baseImage = System.Drawing.Image.FromFile(source +"\\"+ name);
            Single ratio = 0.0F; //存放縮圖比例
            Single h = baseImage.Height;//圖像原尺寸高度
            Single w = baseImage.Width;//圖像原尺寸寬度
            int ht;//圖像縮圖後高度
            int wt; //圖像縮圖後寬度
            if (w > h)
            {//圖像比較寬
                ratio = MaxWidth / w;//計算寬度縮圖比例
                if (MaxWidth < w)
                {
                    ht = Convert.ToInt32(ratio * h);
                    wt = MaxWidth;
                }
                else
                {
                    ht = Convert.ToInt32(baseImage.Height);
                    wt = Convert.ToInt32(baseImage.Width);
                }
            }
            else
            {//比較高
                ratio = MaxHight / h;//計算寬度縮圖比例
                if (MaxHight < h)
                {
                    ht = MaxHight;
                    wt = Convert.ToInt32(ratio * w);
                }
                else
                {
                    ht = Convert.ToInt32(baseImage.Height);
                    wt = Convert.ToInt32(baseImage.Width);
                }
            }
            string Newname = target + "\\" + suffix + name;
            System.Drawing.Bitmap img = new System.Drawing.Bitmap(wt, ht);
            System.Drawing.Graphics graphic = Graphics.FromImage(img);
            graphic.CompositingQuality = CompositingQuality.HighQuality;
            graphic.SmoothingMode = SmoothingMode.HighQuality;
            graphic.InterpolationMode = InterpolationMode.NearestNeighbor;
            graphic.DrawImage(baseImage, 0, 0, wt, ht);
            img.Save(Newname);

            img.Dispose();
            graphic.Dispose();
            baseImage.Dispose();

        }
    }
}