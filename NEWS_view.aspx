<%@ Page Title="" Language="C#" MasterPageFile="~/Tayana.Master" AutoEventWireup="true" CodeBehind="NEWS_view.aspx.cs" Inherits="Tayan.NEWS_view" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            $('.topbuttom').click(function () {
                $('html, body').scrollTop(0);

            });

        });
    </script>
    <link rel="shortcut icon" href="favicon.ico" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="box3">
        <h4>
            <asp:Literal ID="title" runat="server"></asp:Literal></h4>
            <asp:Label ID="content" runat="server" Text="Label"></asp:Label>
    <!--下載開始-->
    <div class="downloads">
        <p><img src="images/downloads.gif" alt="&quot;&quot;" style="border:0px;"/></p>
        <ul>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <li>
                        <asp:HyperLink ID="download" runat="server" NavigateUrl='<%#"/sys/files/"+Eval("filename") %>' Target="_blank">
                            <asp:Literal ID="downloadName" runat="server" Text='<%#Eval("showname") %>'></asp:Literal></asp:HyperLink>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
            
            <%--<li><a href="#">Downloads 001</a></li>
            <li><a href="#">Downloads 001</a></li>
            <li><a href="#">Downloads 001</a></li>
            <li><a href="#">Downloads 001</a></li>--%>
        </ul> 
    </div>
    <!--下載結束-->

    <div class="buttom001"><a href="NEWS_list.aspx"><img src="images/back.gif" alt="&quot;&quot;" width="55" height="28" /></a></div>
</asp:Content>
