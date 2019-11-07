<%@ Page Title="" Language="C#" MasterPageFile="~/sys/master.Master" AutoEventWireup="true" CodeBehind="members.aspx.cs" Inherits="Tayan.sys.members.members" %>

<%@ Register Src="~/sys/PageControl.ascx" TagPrefix="uc1" TagName="PageControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <link href="/sys/PageControl.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
   
    <a href="addmember.aspx" class="btn btn-success bg-theme05 mt">新增帳號</a>

    <div class="row mt" id="table" runat="server">
        <div class="col-md-12">
            <div class="content-panel">
                <h4><i class="fa fa-angle-right"></i>User 列表</h4>
                <hr>
                <asp:GridView ID="GridView1" CssClass="table table-striped table-advance table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" GridLines="None" >
                    <Columns >
                        <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                        <asp:BoundField DataField="UID" HeaderText="UID" SortExpression="UID" />
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                        <asp:BoundField DataField="dept" HeaderText="dept" SortExpression="dept" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="Button1" CssClass="btn btn-success btn-xs" runat="server" CommandName="edit" Text="Edit" />
                                <asp:Button ID="Button2" CssClass="btn btn-primary btn-xs" runat="server" CommandName="delete" Text="Delete" OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) window.event.returnValue = false;"/>
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <uc1:PageControl runat="server" ID="PageControl" />
               
            </div>
            <!-- /content-panel -->
        </div>
        <!-- /col-md-12 -->
    </div>
</asp:Content>



