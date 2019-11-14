<%@ Page Title="" Language="C#" MasterPageFile="~/Tayana.Master" AutoEventWireup="true" CodeBehind="Dealers.aspx.cs" Inherits="Tayan.Dealers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="javascript/iepngfix_tilebg.js"></script>
    <link rel="shortcut icon" href="favicon.ico" /><link href="css/homestyle.css" rel="stylesheet" type="text/css" /><link href="css/reset.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $('.topbuttom').click(function () {
                $('html, body').scrollTop(0);

            });

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="box2_list">
        <ul>
            <asp:Repeater ID="Repeater1" runat="server" >
                <ItemTemplate>
                    <li>
                        <div class="list02">
                            <ul>
                                <li class="list02li"><div><p><img src='<%# "/sys/uploadfile/dealers/S"+Eval("photo") %>' runat="server" /></p></div></li>
                                <li>  <asp:Label ID="country" runat="server" Text='<%# Bind("country") %>'></asp:Label><br />
                                    <asp:Literal ID="dealername" runat="server" Text='<%# Bind("dealer") %>'></asp:Literal><br />
                                    <asp:Literal ID="dealerInfo" runat="server" Text='<%# Bind("dealerInfo") %>'></asp:Literal>
                                </li>  
                            </ul></div>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</asp:Content>
