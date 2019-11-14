<%@ Page Title="" Language="C#" MasterPageFile="~/sys/master.Master" AutoEventWireup="true" CodeBehind="editNEWS.aspx.cs" Inherits="Tayan.sys.NEWS.editNEWS" ValidateRequest="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script src="https://cdn.ckeditor.com/4.13.0/standard/ckeditor.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h3><i class="fa fa-angle-right"></i>修改最新消息</h3>
    <div class="cmxform form-horizontal style-form">
        <div class="row mt">
            <div class="col-lg-12">
                <div class="form-panel">
                    <div class="form">
                        <form class="cmxform form-horizontal style-form" id="signupForm" method="get" action="">
                            <div class="form-group ">
                                <label for="title" class="control-label col-lg-2">標題</label>
                                <div class="col-lg-10">
                                    <input class=" form-control" id="title" type="text" runat="server" required="" oninvalid="setCustomValidity('請填入標題')" oninput="setCustomValidity('')" clientidmode="Static" />
                                </div>
                            </div>
                            <div class="form-group ">
                                <label for="img" class="control-label col-lg-2">圖片
                                </label>
                                <div class="col-lg-10">
                                    <asp:Image ID="Image1" runat="server" style="width: 200px"/>
                                    <asp:FileUpload ID="img" runat="server" class="form-control " />
                                    <asp:HiddenField ID="hiddenP" runat="server" />
                                </div>
                            </div>
                            <div class="form-group ">
                                <label for="summary" class="control-label col-lg-2">摘要<br>(可拖拉改變編輯框大小)</label>
                                <div class="col-lg-10">
                                    <textarea id="summary" clientidmode="Static" runat="server" required=""></textarea>
                                    <script>CKEDITOR.replace("summary");</script>
                                </div>
                            </div>

                            <div class="form-group ">
                                <label for="newsContent" class="control-label col-lg-2">內容<br>(可拖拉改變編輯框大小)</label>
                                <div class="col-lg-10">
                                    <textarea id="newsContent" name="newsContent" clientidmode="Static" runat="server" required=""></textarea>
                                    <script>CKEDITOR.replace("newsContent");</script>
                                </div>
                            </div>
                            <div class="form-group ">
                                <label for="newsContent" class="control-label col-lg-2">是否置頂</label>
                                <div class="col-lg-10">
                                    <asp:CheckBox ID="topNews" runat="server" Text="本文置頂"/>
                                </div>
                            </div>
                            

                            <div class="form-group">
                                <div class="col-lg-offset-2 col-lg-10">
                                    <asp:Label ID="check" runat="server" ForeColor="Red"></asp:Label>
                                    <asp:Button CssClass="btn btn-theme" ID="save" runat="server" Text="儲存修改" OnClick="save_Click" />
                                    <asp:Button CssClass="btn btn-theme04" ID="cancel" runat="server" Text="取消" OnClick="cancel_Click" />
                                </div>
                            </div>
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
                                </Columns>
                            </asp:GridView>
                            <div class="form-group ">
                                <label for="files" class="control-label col-lg-2">附件檔案<br/>(總大小限制為4MB)</label>
                                <div class="col-lg-10" style="display: flex">
                                    <asp:FileUpload AllowMultiple="True" ID="FileUpload1" runat="server" class="form-control" style="margin: 0px 20px 0px 0px;" />
                                    <asp:Button ID="uploadfile" runat="server" Text="新增檔案" OnClick="uploadfile_Click" CssClass="btn btn-danger btn-xs"/>
                                </div>
                            </div>
                            <asp:Label ID="check2" runat="server" ForeColor="Red"></asp:Label>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
