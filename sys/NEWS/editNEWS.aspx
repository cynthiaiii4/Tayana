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
                                    <asp:Image ID="Image1" runat="server" />
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
                           

                            <div class="form-group">
                                <div class="col-lg-offset-2 col-lg-10">
                                    <asp:CheckBox ID="topNews" runat="server" Text="本文置頂"/>
                                    <asp:Label ID="check" runat="server" ForeColor="Red"></asp:Label>
                                    <asp:Button CssClass="btn btn-theme" ID="save" runat="server" Text="儲存修改" OnClick="save_Click" />
                                    <asp:Button CssClass="btn btn-theme04" ID="cancel" runat="server" Text="取消" OnClick="cancel_Click" />
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
