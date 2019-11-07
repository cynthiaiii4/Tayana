using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayan.sys.members
{
    public partial class addmember : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HiddenField hiddenyo = (HiddenField)Master.FindControl("hiddenyo");
            hiddenyo.Value = "001";
        }

        protected void save_Click(object sender, EventArgs e)
        {
            string fileName="";
            if (profile.HasFile)
            {
                if (profile.PostedFile.ContentType.IndexOf("image") == -1)
                {
                    Message.Text = "檔案型態錯誤!";
                    return;
                }
                //取得副檔名
                string Extension = profile.FileName.Split('.')[profile.FileName.Split('.').Length - 1];
                //新檔案名稱
                fileName = String.Format("{0}{1:yyyyMMddhhmmsss}.{2}",UID.Value,DateTime.Now,Extension);
                //上傳目錄為/upload/Images/
                profile.SaveAs(Server.MapPath(String.Format("~/uploadfile/members/{0}", fileName)));

            }
            //取得勾選值
            //建立空字串儲存值
            string checkbox=",";
            //將chkOutingType.Items裡所有的值傳到oItem儲存
            foreach (ListItem item in CheckBoxList.Items)
            {
                //判斷item是否有被選擇
                if (item.Selected == true)
                {
                   

                    checkbox += item.Value+",";
                }
            }

            check.Text = "";
            if (string.IsNullOrEmpty(UID.Value))
            {
                check.Text += "*帳號不可以為空";
            }
            if (string.IsNullOrEmpty(PW.Value))
            {
                check.Text += "*密碼不可以為空";
            }
            if (string.IsNullOrEmpty(Name.Value))
            {
                check.Text += "*姓名不可以為空";
            }
            

            if (string.IsNullOrEmpty(check.Text))
            {
                string password =FormsAuthentication.HashPasswordForStoringInConfigFile(PW.Value, "MD5");

                string AddAcount = System.Web.Configuration.WebConfigurationManager
                    .ConnectionStrings["ConnectionString"].ToString();
                SqlConnection addConnection = new SqlConnection(AddAcount);
                SqlCommand addCommand =
                    new SqlCommand(
                        $"INSERT INTO account(UID,PW,Name,profile,email,dept,tel,permission) VALUES(@UID,@PW,@Name,@profile,@email,@dept,@tel,@permission)",
                        addConnection);
                addCommand.Parameters.Add("@UID", SqlDbType.NVarChar);
                addCommand.Parameters["@UID"].Value = UID.Value;
                addCommand.Parameters.Add("@PW", SqlDbType.NVarChar);
                addCommand.Parameters["@PW"].Value = password;
                addCommand.Parameters.Add("@Name", SqlDbType.NVarChar);
                addCommand.Parameters["@Name"].Value = Name.Value;
                addCommand.Parameters.Add("@profile", SqlDbType.NVarChar);
                addCommand.Parameters["@profile"].Value = string.IsNullOrEmpty(fileName)?"defult.png": fileName;
                addCommand.Parameters.Add("@email", SqlDbType.NVarChar);
                addCommand.Parameters["@email"].Value = email.Value;
                addCommand.Parameters.Add("@dept", SqlDbType.NVarChar);
                addCommand.Parameters["@dept"].Value = dept.Value;
                addCommand.Parameters.Add("@tel", SqlDbType.NVarChar);
                addCommand.Parameters["@tel"].Value = tel.Value;
                addCommand.Parameters.Add("@permission", SqlDbType.NVarChar);
                addCommand.Parameters["@permission"].Value = checkbox;
                addConnection.Open();
                addCommand.ExecuteNonQuery();
                addConnection.Close();
                Response.Redirect("members.aspx");
            }

        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("members.aspx");
        }
    }
}