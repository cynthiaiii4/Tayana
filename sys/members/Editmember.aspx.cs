using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayan.sys.members
{
    public partial class Editmember : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                //偷放個隱藏欄位並賦值
                HiddenField hiddenyo = (HiddenField)Master.FindControl("hiddenyo");
                hiddenyo.Value = "001";

                string EdiAcount = System.Web.Configuration.WebConfigurationManager
                    .ConnectionStrings["ConnectionString"].ToString();
                SqlConnection editConnection = new SqlConnection(EdiAcount);
                SqlCommand editCommand =
                    new SqlCommand($" Select * from account where id=@Eid",editConnection);
                editCommand.Parameters.Add("@Eid", SqlDbType.NVarChar);
                editCommand.Parameters["@Eid"].Value = Request.QueryString["id"];
                
                editConnection.Open();
                SqlDataReader ereader = editCommand.ExecuteReader();
                ereader.Read();
                IDLabel.Text = ereader["UID"].ToString();
                hidden.Value= ereader["PW"].ToString();
                Image1.ImageUrl = @"/sys/uploadfile/members/"+ereader["profile"].ToString();
                hiddenP.Value = ereader["profile"].ToString();
                PW.Value = ereader["profile"].ToString();
                email.Value= ereader["email"].ToString();
                dept.Value = ereader["dept"].ToString();
                tel.Value = ereader["tel"].ToString();
                Name.Value = ereader["Name"].ToString();
                string checkedBox = ereader["permission"].ToString();
                ereader.Close();

                //另解,效能較差
                //string[] checkedBox = ereader["permission"].ToString().Split(',');
                //ereader.Close();
                //foreach (var checkeditem in checkedBox)
                //{
                    //for (int i = 0; i < CheckBoxList.Items.Count; i++)
                    //{
                    //    if (ereader["permission"].ToString().IndexOf(CheckBoxList.Items[i].Value)>-1)
                    //    {
                    //        CheckBoxList.Items[i].Selected = true;
                    //        //break;
                    //    }
                    //}
                //}
                for (int i = 0; i < CheckBoxList.Items.Count; i++)
                {
                    if (checkedBox.IndexOf(","+CheckBoxList.Items[i].Value+",") > -1)//把CheckBoxList裡面的值跟字串比對，以","包住確保查的值正確
                    {
                        CheckBoxList.Items[i].Selected = true;//比對成功就打勾
                        //break;
                    }
                }


            }
        }

        protected void upload_Click(object sender, EventArgs e)
        {
            string fileName = "";
            if (profile.HasFile)
            {
                if (profile.PostedFile.ContentType.IndexOf("image") == -1)
                {
                    Massage.Text = "檔案型態錯誤!";
                    return;
                }
                //取得副檔名
                string Extension = profile.FileName.Split('.')[profile.FileName.Split('.').Length - 1];
                //新檔案名稱
                fileName = String.Format("{0}{1:yyyyMMddhhmmsss}.{2}", IDLabel.Text, DateTime.Now, Extension);
                //上傳目錄為/upload/Images/
                profile.SaveAs(Server.MapPath(String.Format("~/uploadfile/{0}", fileName)));

            }
            else
            {
                fileName = hiddenP.Value;
            }


            //取得勾選值
            //建立空字串儲存值
            string checkbox = ",";
            //將chkOutingType.Items裡所有的值傳到oItem儲存
            foreach (ListItem item in CheckBoxList.Items)
            {
                //判斷item是否有被選擇
                if (item.Selected == true)
                {
                    //判斷check是否已有值
                    //if (checkbox.Length > 0)
                    //{
                    //    //有就加,區分
                    //    checkbox += ",";
                    //}

                    checkbox += item.Value+",";
                }
            }



            string Eid = Request.QueryString["id"];
            string password = FormsAuthentication.HashPasswordForStoringInConfigFile(PW.Value, "MD5");
            string AddAcount = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["ConnectionString"].ToString();
            SqlConnection editConnection = new SqlConnection(AddAcount);
            SqlCommand editCommand =
                new SqlCommand(
                    $"UPDATE account SET PW=@PW,Name=@Name,profile=@profile,email=@email,dept=@dept,tel=@tel,permission=@permission where id=@Eid",
                    editConnection);
            editCommand.Parameters.Add("@Eid", SqlDbType.NVarChar);
            editCommand.Parameters["@Eid"].Value = Request.QueryString["id"];
            editCommand.Parameters.Add("@PW", SqlDbType.NVarChar);
            if (PW.Value != "")
            {
                editCommand.Parameters["@PW"].Value = password;
            }
            else
            {
                editCommand.Parameters["@PW"].Value = hidden.Value;
            }
            
            editCommand.Parameters.Add("@Name", SqlDbType.NVarChar);
            editCommand.Parameters["@Name"].Value = Name.Value;
            editCommand.Parameters.Add("@profile", SqlDbType.NVarChar);
            editCommand.Parameters["@profile"].Value = fileName;
            editCommand.Parameters.Add("@email", SqlDbType.NVarChar);
            editCommand.Parameters["@email"].Value = email.Value;
            editCommand.Parameters.Add("@dept", SqlDbType.NVarChar);
            editCommand.Parameters["@dept"].Value = dept.Value;
            editCommand.Parameters.Add("@tel", SqlDbType.NVarChar);
            editCommand.Parameters["@tel"].Value = tel.Value;
            editCommand.Parameters.Add("@permission", SqlDbType.NVarChar);
            editCommand.Parameters["@permission"].Value = checkbox;
            editConnection.Open();
            editCommand.ExecuteNonQuery();
            editConnection.Close();
            Response.Redirect("members.aspx");
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("members.aspx");
        }
    }
}