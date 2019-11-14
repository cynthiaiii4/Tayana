<%@ Page Title="" Language="C#" MasterPageFile="~/Tayana.Master" AutoEventWireup="true" CodeBehind="NEWS_list.aspx.cs" Inherits="Tayan.NEWS_list" %>

<%@ Register Src="~/sys/PageControl.ascx" TagPrefix="uc1" TagName="PageControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="sys/PageControl.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="box2_list">
        <ul>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
            <li>
                <div class="list01">
                    <ul>
                        <li>
                            <div>
                                <p>
                                    <asp:Image ID="NEWSImg" runat="server" src='<%# "/sys/uploadfile/images/S"+Eval("img") %>'/>
                                </p>
                            </div>
                        </li>
                        <li><asp:Label ID="initDate" runat="server" Text='<%# Eval("initDate","{0:d}") %>'></asp:Label><br />
                            <asp:HyperLink ID="NewsLink" runat="server" NavigateUrl='<%#"NEWS_view.aspx?id="+ Eval("id") %>'>
                                <asp:Literal ID="title" runat="server" Text='<%# Bind("title") %>'></asp:Literal></asp:HyperLink>
                        <br />
                        <li><asp:Literal ID="summary" runat="server" Text='<%# Eval("summary").ToString().Length>50?Eval("summary").ToString().Substring(0,30)+"...":Eval("summary") %>'
                                         ></asp:Literal></li>
                    </ul>
                </div>
            </li>
                </ItemTemplate>
            </asp:Repeater>
        </ui>
    </div>
    
</asp:Content>
