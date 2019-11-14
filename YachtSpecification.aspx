<%@ Page Title="" Language="C#" MasterPageFile="~/Tayana.Master" AutoEventWireup="true" CodeBehind="YachtSpecification.aspx.cs" Inherits="Tayan.Specification" %>
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

</asp:Content>
