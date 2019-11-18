<%@ Page Title="" Language="C#" MasterPageFile="~/sys/master.Master" AutoEventWireup="true" CodeBehind="editPhoto.aspx.cs" Inherits="Tayan.sys.productAll.editPhoto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
        <div class="row mt" id="table" runat="server">
            <div class="col-md-12">
                <div class="content-panel "style="padding-bottom: 50px" aria-atomic="False">
                    <h4><i class="fa fa-angle-right"></i>照片列表</h4>
                    <hr />
                    <div class="form-group ">
                        <label for="images" class="control-label col-lg-2">新增產品照片<br/>(總大小限制為4MB)</label>
                        <div class="col-lg-10" style="display: flex">
                            <asp:FileUpload AllowMultiple="True" ID="images" runat="server" class="form-control" style="margin: 0px 20px 0px 0px;" />
                            <asp:Button ID="uploadPhoto" runat="server" Text="新增圖片" OnClick="uploadPhoto_Click" CssClass="btn btn-danger btn-xs"/>
                        </div>
                    </div>
                    <asp:Label ID="check" runat="server" ForeColor="Red"></asp:Label>
                   
                    <asp:GridView ID="GridView1" CssClass="table table-striped table-advance table-hover"  runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowDeleting="GridView1_RowDeleting"  GridLines="None"  OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_OnRowDataBound">
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                            <asp:TemplateField HeaderText="照片">
                                <ItemTemplate>
                                    <asp:Image ImageUrl='<%# "/sys/uploadfile/images/"+Eval("img") %>' ID="Image1"  runat="server" style="width: 200px"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="indexPage" HeaderText="是否為首頁照片" SortExpression="indexPage" />
                            <asp:BoundField DataField="new" HeaderText="是否有New標籤" SortExpression="new" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="Button1" CssClass="btn btn-success btn-xs" runat="server" CommandName="changeIndex" Text="調整封面照片設定" /><br/><br>
                                    <asp:Button ID="Button3" runat="server" Text="調整NEW標籤設定" CommandName="changNew" CssClass="btn btn-warning btn-xs"/><br/><br>
                                    <asp:Button ID="Button2" CssClass="btn btn-primary btn-xs" runat="server" CommandName="delete" Text="刪除照片" OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) window.event.returnValue = false;" />
                                </ItemTemplate>

                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <br/>
                    <h4 style="padding-top: 30px;"><i class="fa fa-angle-right"></i>檔案列表</h4>
                    <hr />
                    <div class="form-group ">
                        <label for="files" class="control-label col-lg-2">附件檔案<br/>(總大小限制為4MB)</label>
                        <div class="col-lg-10" style="display: flex">
                            <asp:FileUpload AllowMultiple="True" ID="files" runat="server" class="form-control" style="margin: 0px 20px 0px 0px;" />
                            <asp:Button ID="uploadfile" runat="server" Text="新增檔案" OnClick="uploadfile_Click" CssClass="btn btn-danger btn-xs"/>
                        </div>
                    </div>
                    <asp:Label ID="check2" runat="server" ForeColor="Red"></asp:Label>
                    
                    <asp:GridView ID="GridView2" CssClass="table table-striped table-advance table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="id"  GridLines="None" OnRowDeleting="GridView2_RowDeleting" >
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                            <asp:TemplateField HeaderText="檔案">
                                <ItemTemplate>

                                    <asp:HyperLink ID="HyperLink2" Target="_blank" runat="server" NavigateUrl='<%# "/sys/uploadfile/files/"+Eval("filename") %>' Text='<%# Eval("showname") %>'></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="Button2" CssClass="btn btn-primary btn-xs" runat="server" CommandName="delete" Text="刪除檔案" OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) window.event.returnValue = false;"  />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                   
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </asp:Content>
