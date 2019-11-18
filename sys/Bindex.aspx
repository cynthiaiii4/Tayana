<%@ Page Title="" Language="C#" MasterPageFile="~/sys/master.Master" AutoEventWireup="true" CodeBehind="Bindex.aspx.cs" Inherits="Tayan.sys.index1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <style>
        .title {
            font-size: 60px;
            text-align: center;
            color: #013A6F;
            margin-top: 60px;
            font-family: 'Ruda', sans-serif;
        }
        img {
            margin: 0px auto;
        }
         
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h1 class="title">歡迎使用 Tayana 後台管理系統</h1>
    <div style="display: flex">
    <img src="/images/boatImg-removebg-preview.png">
    </div>
</asp:Content>
