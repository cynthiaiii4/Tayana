using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayan.sys.productAll
{
    public partial class addproduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HiddenField hiddenyo = (HiddenField)Master.FindControl("hiddenyo");
            hiddenyo.Value = "002";
        }

        protected void save_Click(object sender, EventArgs e)
        {
            #region 首頁照片判斷式
            string ifileName = "";
            if (indexImg.HasFile)
            {
                if (indexImg.PostedFile.ContentType.IndexOf("image") == -1)
                {
                    check.Text = "首頁照片格式錯誤!";
                    return;
                }
                
                //取得副檔名
                string Extension = indexImg.FileName.Split('.')[indexImg.FileName.Split('.').Length - 1];
                //新檔案名稱
                ifileName = String.Format("{0:yyyyMMddhhmmsss}.{1}", DateTime.Now, Extension);
                //上傳目錄為/upload/Images/
                indexImg.SaveAs(Server.MapPath(String.Format("~/sys/uploadfile/images/{0}", ifileName)));

            }
            #endregion

            #region 其他照片判斷式
            List<string> fileName = new List<string>();
            
            if (images.HasFile)
            {
                int i = 1;
                foreach (var item in images.PostedFiles)
                {
                    if (item.ContentType.IndexOf("image") == -1)
                    {
                        check.Text = "首頁照片格式錯誤!";
                        return;
                    }

                    //取得副檔名
                    string Extension = item.FileName.Split('.')[item.FileName.Split('.').Length - 1];
                    //新檔案名稱
                    string singlefile = String.Format("{0:yyyyMMddhhmmsss}-{1}.{2}", DateTime.Now,i, Extension);
                    //存進陣列
                    fileName.Add(singlefile);
                    //上傳目錄為/Images/
                    images.SaveAs(Server.MapPath(String.Format("~/sys/uploadfile/images/{0}", singlefile)));
                    i++;
                }

            }
            #endregion

            check.Text = "";
            if (string.IsNullOrEmpty(series.Value))
            {
                check.Text += "*系列不可以為空";
            }
            if (string.IsNullOrEmpty(number.Value))
            {
                check.Text += "*型號不可以為空";
            }

            if (string.IsNullOrEmpty(check.Text))
            {
                string ConnectionString = System.Web.Configuration.WebConfigurationManager
                    .ConnectionStrings["ConnectionString"].ToString();
                SqlConnection Connection = new SqlConnection(ConnectionString);

                #region 寫入主表
                SqlCommand Command =
                    new SqlCommand(
                        $"INSERT INTO products(series,number,overview,layout,specification) VALUES(@series,@number,@overview,@layout,@specification) SELECT SCOPE_IDENTITY()",
                        Connection);
                Command.Parameters.Add("@series", SqlDbType.NVarChar);
                Command.Parameters["@series"].Value = series.Value;
                Command.Parameters.Add("@number", SqlDbType.NVarChar);
                Command.Parameters["@number"].Value = number.Value;
                Command.Parameters.Add("@overview", SqlDbType.NVarChar);
                Command.Parameters["@overview"].Value = overview.Value;
                Command.Parameters.Add("@layout", SqlDbType.NVarChar);
                Command.Parameters["@layout"].Value = layout.Value;
                Command.Parameters.Add("@specification", SqlDbType.NVarChar);
                Command.Parameters["@specification"].Value = specification.Value;

                Connection.Open();
                int nid = Convert.ToInt32(Command.ExecuteScalar());
                Connection.Close();

                #endregion

                #region 寫入首頁照片

                if (indexImg.HasFile)
                {
                    SqlCommand pCommand =
                        new SqlCommand(
                            $"INSERT INTO images(productID,img,indexPage,new) VALUES(@productID,@img,@indexPage,@new)",
                            Connection);
                    pCommand.Parameters.Add("@productID", SqlDbType.NVarChar);
                    pCommand.Parameters["@productID"].Value = nid;
                    pCommand.Parameters.Add("@img", SqlDbType.NVarChar);
                    pCommand.Parameters["@img"].Value = ifileName;
                    pCommand.Parameters.Add("@indexPage", SqlDbType.NVarChar);
                    pCommand.Parameters["@indexPage"].Value = true;
                    pCommand.Parameters.Add("@new", SqlDbType.NVarChar);
                    if (newProduct.Checked)
                    {
                        pCommand.Parameters["@new"].Value = true;
                    }
                    else
                    {
                        pCommand.Parameters["@new"].Value = "";
                    }
                    Connection.Open();
                    pCommand.ExecuteNonQuery();
                    Connection.Close();
                }
                
                #endregion

                #region 寫入其他照片
                foreach (var item in fileName)
                {
                    SqlCommand oCommand =
                        new SqlCommand(
                            $"INSERT INTO images(productID,img) VALUES(@productID,@img)",
                            Connection);
                    oCommand.Parameters.Add("@productID", SqlDbType.NVarChar);
                    oCommand.Parameters["@productID"].Value = nid;
                    oCommand.Parameters.Add("@img", SqlDbType.NVarChar);
                    oCommand.Parameters["@img"].Value = item;
                    Connection.Open();
                    oCommand.ExecuteNonQuery();
                    Connection.Close();
                }
                #endregion


                //寫入其他檔案
                if (files.HasFile)
                {
                    int i = 1;
                    foreach (var item in files.PostedFiles)
                    {
                        //取得副檔名
                        string Extension = Path.GetExtension(item.FileName);
                        //取得原檔名
                        string itemname = Path.GetFileName(item.FileName);
                        //新檔案名稱
                        string ofileName = String.Format("{0:yyyyMMddhhmmsss}-{1}.{2}", DateTime.Now,i, Extension);
                        //上傳目錄為/upload/Images/
                        files.SaveAs(Server.MapPath(String.Format("~/sys/uploadfile/files/{0}", ofileName)));
                        i++;
                        SqlCommand oCommand =
                            new SqlCommand(
                                $"INSERT INTO downloads(productID,filename,showname) VALUES(@productID,@filename,@showname)",
                                Connection);
                        oCommand.Parameters.Add("@productID", SqlDbType.NVarChar);
                        oCommand.Parameters["@productID"].Value = nid;
                        oCommand.Parameters.Add("@filename", SqlDbType.NVarChar);
                        oCommand.Parameters["@filename"].Value = ofileName;
                        oCommand.Parameters.Add("@showname", SqlDbType.NVarChar);
                        oCommand.Parameters["@showname"].Value = itemname;
                        Connection.Open();
                        oCommand.ExecuteNonQuery();
                        Connection.Close();
                    }
                }

                Response.Redirect("~/sys/productAll/products.aspx");
            }

        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/sys/productAll/products.aspx");
        }
    }
}