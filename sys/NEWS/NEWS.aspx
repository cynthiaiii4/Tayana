<%@ Page Title="" Language="C#" MasterPageFile="~/sys/master.Master" AutoEventWireup="true" CodeBehind="NEWS.aspx.cs" Inherits="Tayan.sys.NEWS.NEWS" %>

<%@ Register Src="~/sys/PageControl.ascx" TagPrefix="uc1" TagName="PageControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <link href="../PageControl.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
   
    <a href="../NEWS/addNEWS.aspx" class="btn btn-success bg-theme05 mt">新增最新消息</a>

    <div class="row mt" id="table" runat="server">
        <div class="col-md-12">
            <div class="content-panel">
                <h4><i class="fa fa-angle-right"></i>最新消息列表</h4>
                
                <label>起始時間</label>
                <input id="timeStart" class="input-medium default-date-picker" size="16" type="text" value="" placeholder="請輸入開始時間" runat="server" ClientIDMode="Static"/>
                <script >document.querySelector("#timeStart").setAttribute("type", "date")</script>
                <label>結束時間</label>
                <input id="timeEnd" class="input-medium default-date-picker" size="16" type="text" value="" placeholder="請輸入結束時間" runat="server" ClientIDMode="Static"/>
                <script >document.querySelector("#timeEnd").setAttribute("type", "date")</script>
                <label>關鍵字搜尋</label>
                <input type="text" placeholder="請輸入搜尋關鍵字" id="keyword" runat="server"/>
                
                <asp:Button ID="search" runat="server" Text="搜尋" OnClick="search_Click" />
                <asp:Button ID="clear" runat="server" Text="清除搜尋條件" OnClick="clear_Click" />
                <hr/>

                <asp:GridView ID="GridView1" CssClass="table table-striped table-advance table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" GridLines="None" >
                    <Columns >
                        <asp:BoundField DataField="RowNumber" HeaderText="項次" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                        <asp:BoundField DataField="title" HeaderText="標題" SortExpression="newsTitle" />
                        <asp:BoundField DataField="summary" HeaderText="摘要" SortExpression="newsSummary" />
                        <asp:TemplateField HeaderText="最新消息照片">
                            <ItemTemplate>
                                <asp:Image ImageUrl='<%# "/sys/uploadfile/images/"+Eval("img") %>' ID="Image1"  runat="server" style="width: 150px"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="topNews" HeaderText="置頂" SortExpression="topNews" />
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
