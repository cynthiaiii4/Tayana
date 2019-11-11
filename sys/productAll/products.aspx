<%@ Page Title="" Language="C#" MasterPageFile="~/sys/master.Master" AutoEventWireup="true" CodeBehind="products.aspx.cs" Inherits="Tayan.sys.productAll.products" %>
<%@ Register TagPrefix="uc1" TagName="PageControl" Src="~/sys/PageControl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <link href="~/sys/PageControl.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
   
    <a href="../productAll/addproduct.aspx" class="btn btn-success bg-theme05 mt">新增產品</a>

    <div class="row mt" id="table" runat="server">
        <div class="col-md-12">
            <div class="content-panel">
                <h4><i class="fa fa-angle-right"></i>產品列表</h4>
                
                <label>請選擇系列</label>
                <asp:DropDownList ID="seriesList" runat="server" ></asp:DropDownList>
                <label>請選擇型號</label>
                <asp:DropDownList ID="numberList" runat="server" ></asp:DropDownList>
                
                <asp:Button ID="search" runat="server" Text="搜尋" OnClick="search_Click" />
                <asp:Button ID="clear" runat="server" Text="清除搜尋條件" OnClick="clear_Click" />
                <hr/>

                <asp:GridView ID="GridView1" CssClass="table table-striped table-advance table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" GridLines="None" >
                    <Columns >
                        <asp:BoundField DataField="RowNumber" HeaderText="項次" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                        <asp:BoundField DataField="series" HeaderText="series" SortExpression="series" />
                        <asp:BoundField DataField="number" HeaderText="number" SortExpression="number" />
                        <asp:TemplateField HeaderText="照片">
                            <ItemTemplate>
                                <asp:Image ImageUrl='<%# "/sys/uploadfile/images/"+Eval("img") %>' ID="Image1"  runat="server" style="width: 200px"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            
                            <ItemTemplate>
                                <asp:Button ID="Button1" CssClass="btn btn-success btn-xs" runat="server" CommandName="edit" Text="編輯產品資訊" />
                                <asp:HyperLink ID="HyperLink1" CssClass="btn btn-warning btn-xs" runat="server" NavigateUrl='<%# "editphoto.aspx?id=" + Eval("id") %>'>編輯照片及附件</asp:HyperLink>
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
