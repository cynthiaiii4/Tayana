<%@ Page Title="" Language="C#" MasterPageFile="~/sys/master.Master" AutoEventWireup="true" CodeBehind="indexImg.aspx.cs" Inherits="Tayan.sys.indexImg" %>
<%@ Register Src="~/sys/PageControl.ascx" TagPrefix="uc1" TagName="PageControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <link href="~/sys/PageControl.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="row mt" id="table" runat="server">
        <div class="col-md-12">
            <div class="content-panel">
                <h4><i class="fa fa-angle-right"></i>首頁輪播照片管理</h4>
                <p style="margin-left: 5px">最上方六筆為目前首頁照片</p>
                <hr/>

                <asp:GridView ID="GridView1" CssClass="table table-striped table-advance table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="id"  OnRowEditing="GridView1_RowEditing" GridLines="None" >
                    <Columns >
                        <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                        <asp:BoundField DataField="series" HeaderText="series" SortExpression="series" />
                        <asp:BoundField DataField="number" HeaderText="number" SortExpression="number" />
                        <asp:TemplateField HeaderText="照片">
                            <ItemTemplate>
                                <asp:Image ImageUrl='<%# "/sys/uploadfile/images/"+Eval("img") %>' ID="Image1"  runat="server" style="width: 100px"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="Button1" CssClass="btn btn-success btn-xs" runat="server" CommandName="edit" Text="移除首頁照片" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        
                    </Columns>
                </asp:GridView>
                <uc1:PageControl runat="server" ID="PageControl" />
               
            </div>

        </div>

    </div>
</asp:Content>
