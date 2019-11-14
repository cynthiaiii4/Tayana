<%@ Page Title="" Language="C#" MasterPageFile="~/Tayana.Master" AutoEventWireup="true" CodeBehind="YachtOverview.aspx.cs" Inherits="Tayan.Overview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" href="favicon.ico" />
   <%-- <link href="css/homestyle.css" rel="stylesheet" type="text/css" />
    <link href="css/reset.css" rel="stylesheet" type="text/css" />--%>
    <script type="text/javascript">
        $(function () {
            $('.topbuttom').click(function () {
                $('html, body').scrollTop(0);

            });

        });
    </script>
    
    <link rel="stylesheet" type="text/css" href="css/jquery.ad-gallery.css">
    <style type="text/css"> img, div, input { behavior: url(""); } </style>
    <script type="text/javascript" src="Scripts/jquery.ad-gallery.js"></script>
    <script type="text/javascript">
        $(function () {
            var galleries = $('.ad-gallery').adGallery();
            galleries[0].settings.effect = 'fade';
            if ($('.banner input[type=hidden]').val() == "0") {
                $(".bannermasks").hide();
                $(".banner").hide();
                $("#crumb").css("top","125px");
            }
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="Repeater2" runat="server">
        <ItemTemplate>
            <li><a href='<%#"/sys/uploadfile/images/S"+ Eval("img") %>' runat="server">
                <img src='<%#"/sys/uploadfile/images/S"+ Eval("img") %>' class="image0" />
            </a></li>
        </ItemTemplate>
    </asp:Repeater>
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
