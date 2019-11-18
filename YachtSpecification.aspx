<%@ Page Title="" Language="C#" MasterPageFile="~/Tayana.Master" AutoEventWireup="true" CodeBehind="YachtSpecification.aspx.cs" Inherits="Tayan.Specification" ValidateRequest="false" %>
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
            <li><a href='<%#"/sys/uploadfile/images/"+ Eval("img") %>' runat="server">
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
    <style>
        .ad-controls {
            display: none;
        }
        .ad-gallery .ad-image-wrapper {
            height:355px;
        }
        .ad-gallery .ad-nav {
            top: 482px;
        }
    </style>
</asp:Content>
