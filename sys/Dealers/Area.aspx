<%@ Page Title="" Language="C#" MasterPageFile="~/sys/master.Master" AutoEventWireup="true" CodeBehind="Area.aspx.cs" Inherits="Tayan.sys.Dealers.addArea" %>

<%@ Register Src="~/sys/PageControl.ascx" TagPrefix="uc1" TagName="PageControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <link href="../PageControl.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    
    <input type="area" placeholder="請輸入地區" id="area" runat="server"/>
    <asp:Button ID="add" runat="server" Text="新增地區" OnClick="add_Click" />
    <asp:Label ID="check" runat="server" style="color:red"></asp:Label>
    <a href="../Dealers/Dealers.aspx" class="btn btn-success bg-theme05 mt">返回經銷商管理頁</a>
    <div class="row mt" id="table" runat="server">
        <div class="col-md-12">
            <div class="content-panel">
                <h4><i class="fa fa-angle-right"></i>地區列表</h4>
                <hr/>

                <asp:GridView ID="GridView1" CssClass="table table-striped table-advance table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowDeleting="GridView1_RowDeleting" GridLines="None"  >
                    <Columns >
                        <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                        <asp:BoundField DataField="area" HeaderText="地區" SortExpression="area" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="Button2" CssClass="btn btn-primary btn-xs" runat="server" CommandName="delete" Text="Delete" OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) window.event.returnValue = false;"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <uc1:PageControl runat="server" ID="PageControl" />
               
            </div>

        </div>

    </div>
</asp:Content>
