using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayan
{
    public partial class Tayana : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder list = new StringBuilder();
            string progressS = "";
            string commandString = "";
            string sql = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"]
                .ToString();
            SqlConnection connection=new SqlConnection(sql);
            switch (hiddenyo.Value)
            {
                case "001":
                    topImg.Src = "/images/banner01_masks.png";
                    MenuTitle.Text = "YACHTS";
                    commandString = "SELECT id,series,number from products ORDER BY id desc";
                    SqlCommand Command = new SqlCommand(commandString, connection);
                    SqlDataAdapter DataAdapter = new SqlDataAdapter(Command);
                    DataTable dataTable1 = new DataTable();
                    DataAdapter.Fill(dataTable1);
                    progressS += @">> <a href=""YachtOverview.aspx"">Yachts</a>";
                    foreach (DataRow row in dataTable1.Rows)
                    {
                        list.Append(@"<li><a href=""YachtOverview.aspx?id=" + row[0]+ @""">" + row[1]+" "+row[2]+ "</a></li>");
                        if (row[0].ToString() == Request.QueryString["id"])
                        {
                            rightTitle.Text = row[1].ToString();
                            progressS += @">> <span class=""on1""><a href=""YachtOverview.aspx?id=" + Request.QueryString["id"] + @""">" + row[1] + "</span></a>";
                        }
                    }
                    MenuList.Text = list.ToString();
                    progress.Text = progressS;
                    return;
                case "002":
                    topImg.Src = "/images/newsbanner.jpg";
                    MenuTitle.Text = "NEWS";
                    list.Append(@"<li><a href=""NEWS_list.aspx"">News & Events</a></li>");
                    MenuList.Text = list.ToString();
                    progressS += @">> <span class=""on1""><a href=""NEWS_list.aspx"">News & Events</span></a>";
                    progress.Text = progressS;
                    rightTitle.Text = "News & Events";
                    return;
                
                case "003":
                    topImg.Src = "/images/company.jpg";
                    MenuTitle.Text = "COMPANY";
                    list.Append(@"<li><a href=""Company.aspx"">About Us</a></li>");
                    list.Append(@"<li><a href=""Company1.aspx"">Certificat</a></li>");
                    MenuList.Text = list.ToString();
                    progressS += @">> <a href=""Company.aspx"">Company</a>";
                    switch (Request.Path)
                    {
                        case "/Company.aspx":
                            progressS += @">> <span class=""on1""><a href=""Company.aspx"">About Us</span></a>";
                            rightTitle.Text = "About Us";
                            progress.Text = progressS;
                            return;
                        case "/Company1.aspx":
                            progressS += @">> <span class=""on1""><a href=""Company1.aspx"">Certificat</span></a>";
                            rightTitle.Text = "Certificat";
                            progress.Text = progressS;
                            return;
                    }

                    return;
                
                case "004":
                    topImg.Src = "/images/DEALERS.jpg";
                    MenuTitle.Text = "DEALERS";
                    commandString = "SELECT * from area";
                    SqlCommand sqlCommand=new SqlCommand(commandString, connection);
                    SqlDataAdapter sqlDataAdapter=new SqlDataAdapter(sqlCommand);
                    DataTable dataTable=new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    progressS += @">> <a href=""Dealers.aspx"">Dealers</a>";
                    foreach (DataRow row in dataTable.Rows)
                    {
                        list.Append(@"<li><a href=""Dealers.aspx?id=" + row[0]+@""">"+row[1]+"</a></li>");
                        if (row[0].ToString() == Request.QueryString["id"])
                        {
                            rightTitle.Text = row[1].ToString();
                            progressS += @">> <span class=""on1""><a href=""Dealers.aspx?id=" + Request.QueryString["id"] + @""">" + row[1] + "</span></a>";
                        }
                    }
                    MenuList.Text = list.ToString();
                    progress.Text = progressS;
                    return;
                case "005":
                    topImg.Src = "/images/contact.jpg";
                    MenuTitle.Text = "CONTACT";
                    list.Append(@"<li><a href=""Contact.aspx"">contacts</a></li>");
                    MenuList.Text = list.ToString();
                    progressS+=@">> <span class=""on1""><a href=""Contact.aspx"">contacts</span></a>";
                    progress.Text = progressS;
                    rightTitle.Text = "Contact";
                    return;
            }

        }
    }
}