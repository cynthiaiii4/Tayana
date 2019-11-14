<%@ Page Title="" Language="C#" MasterPageFile="~/Tayana.Master" AutoEventWireup="true" CodeBehind="YachtOverview.aspx.cs" Inherits="Tayan.Overview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <!--次選單-->
    <div class="menu_y">
        <ul>
            <li class="menu_y00">YACHTS</li>
            <asp:Literal ID="subMenu" runat="server"></asp:Literal>
        </ul>
    </div>
    <!--次選單結束-->
    <div class="box1">
    <asp:Literal ID="content" runat="server"></asp:Literal>
    </div>
    <p class="topbuttom">
        <img src="images/top.gif" alt="top" />
    </p>

    <!--下載開始-->
    <div class="downloads">
        <p>
            <img src="images/downloads.gif" alt="&quot;&quot;" /></p>
        <ul>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <li>
                        <asp:HyperLink ID="download" runat="server" NavigateUrl='<%#"/sys/uploadfile/files/"+Eval("filename")%>'>
                            <asp:Literal ID="downloadname" runat="server" Text='<%# Bind("showname") %>'></asp:Literal>
                        </asp:HyperLink>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
    <!--下載結束-->
</asp:Content>
