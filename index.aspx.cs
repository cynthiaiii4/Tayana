using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayan
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string login = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection Connection = new SqlConnection(login);
            SqlCommand Command = new SqlCommand($"SELECT * FROM image WHERE indexPage='True'", Connection);
            
            SqlDataAdapter Adapter = new SqlDataAdapter(Command);
            DataTable dataTable = new DataTable();
            Adapter.Fill(dataTable);

            //最上方背景大圖
            StringBuilder bigLi = new StringBuilder();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                bigLi.Append(@"<li class=""info on""><a href=""#"">< img src = ""images/" + dataTable.Rows[i][4] +
                             @"""/></a>< div class=""wordtitle"">" + dataTable.Rows[i][2] + "<span>" +
                             dataTable.Rows[i][3] + @"</span><br/><p>SPECIFICATION SHEET</p></ div >");
                    
                if (!string.IsNullOrEmpty(dataTable.Rows[i][6].ToString()))
                {
                    bigLi.Append(@"<div class=""new""><img src = ""images/new01.png"" alt=""new"" /></div>");
                }

                bigLi.Append("</li>");
            }
            bLi.Text= bigLi.ToString();

            //最上方輪播小圖
            StringBuilder smallLi = new StringBuilder();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                smallLi.Append(@"<li class=""on""><div><p class=""bannerimg_p""><img src = ""images/"+ dataTable.Rows[i][4] +@"""alt=""&quot;&quot;"" /></p></div></li>");

            }
            sLi.Text = smallLi.ToString();
        }
        
    }
}