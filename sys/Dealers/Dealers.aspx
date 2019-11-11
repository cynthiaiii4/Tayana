<%@ Page Title="" Language="C#" MasterPageFile="~/sys/master.Master" AutoEventWireup="true" CodeBehind="Dealers.aspx.cs" Inherits="Tayan.sys.Dealers.Dealers" %>

<%@ Register Src="~/sys/PageControl.ascx" TagPrefix="uc1" TagName="PageControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <link href="../PageControl.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
   
    <a href="../Dealers/addDealer.aspx" class="btn btn-success bg-theme05 mt">新增經銷商</a>
    <a href="../Dealers/Area.aspx" class="btn btn-success bg-theme05 mt">管理區域列表</a>
    <div class="row mt" id="table" runat="server">
        <div class="col-md-12">
            <div class="content-panel">
                <h4><i class="fa fa-angle-right"></i>經銷商列表</h4>
                <label>請選擇地區</label>
                <asp:DropDownList ID="areaList" runat="server" ></asp:DropDownList>
                <label>關鍵字搜尋</label>
                <input type="text" placeholder="請輸入搜尋關鍵字" id="keyword" runat="server"/>
                <asp:Button ID="search" runat="server" Text="搜尋" OnClick="search_Click" />
                <asp:Button ID="clear" runat="server" Text="清除搜尋條件" OnClick="clear_Click" />
                <hr/>

                <asp:GridView ID="GridView1" CssClass="table table-striped table-advance table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" GridLines="None" >
                    <Columns >
                        <asp:BoundField DataField="RowNumber" HeaderText="項次" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                        <asp:BoundField DataField="area" HeaderText="地區" SortExpression="area" />
                        <asp:BoundField DataField="country" HeaderText="國家" SortExpression="country" />
                        <asp:BoundField DataField="dealer" HeaderText="經銷商" SortExpression="dealer" />
                        <asp:TemplateField HeaderText="經銷商照片">
                            <ItemTemplate>
                                <asp:Image ImageUrl='<%# "/sys/uploadfile/dealers/"+Eval("photo") %>' ID="Image1"  runat="server" style="width: 150px"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="Button1" CssClass="btn btn-success btn-xs" runat="server" CommandName="edit" Text="編輯" />
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
