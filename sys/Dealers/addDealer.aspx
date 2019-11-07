<%@ Page Title="" Language="C#" MasterPageFile="~/sys/master.Master" AutoEventWireup="true" CodeBehind="addDealer.aspx.cs" Inherits="Tayan.sys.Dealers.addDealer" ValidateRequest="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script src="https://cdn.ckeditor.com/4.13.0/standard/ckeditor.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h3><i class="fa fa-angle-right"></i>新增經銷商資訊</h3>
    <div class="cmxform form-horizontal style-form">
        <div class="row mt">
            <div class="col-lg-12">
                <div class="form-panel">
                    <div class="form">
                        <form class="cmxform form-horizontal style-form" id="signupForm" method="get" action="">
                            <div class="form-group ">
                                <label for="title" class="control-label col-lg-2">地區</label>
                                <div class="col-lg-10">
                                    <asp:DropDownList ID="areaList" runat="server" ClientIDMode="Static"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group ">
                                <label for="country" class="control-label col-lg-2">國家</label>
                                <div class="col-lg-10">
                                    <input class=" form-control" id="country" type="text" runat="server" required="" oninvalid="setCustomValidity('請填入國家')" oninput="setCustomValidity('')" clientidmode="Static" />
                                </div>
                            </div>
                            <div class="form-group ">
                                <label for="dealer" class="control-label col-lg-2">經銷商名稱</label>
                                <div class="col-lg-10">
                                    <input class=" form-control" id="dealer" type="text" runat="server" required="" oninvalid="setCustomValidity('請填入經銷商名稱')" oninput="setCustomValidity('')" clientidmode="Static" />
                                </div>
                            </div>
                            <div class="form-group ">
                                <label for="photo" class="control-label col-lg-2">經銷商圖片</label>
                                <div class="col-lg-10">
                                    <asp:FileUpload ID="photo" runat="server" class="form-control " required="" oninvalid="setCustomValidity('請上傳照片')" oninput="setCustomValidity('')" ClientIDMode="Static" />
                                </div>
                            </div>
                            <div class="form-group ">
                                <label for="dealerInfo" class="control-label col-lg-2">經銷商資訊<br>
                                    (可拖拉改變編輯框大小)</label>
                                <div class="col-lg-10">
                                    <textarea id="dealerInfo" clientidmode="Static" runat="server" required=""></textarea>
                                    <script>CKEDITOR.replace("dealerInfo");</script>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-offset-2 col-lg-10">
                                    <asp:Label ID="check" runat="server" ForeColor="Red"></asp:Label>
                                    <asp:Button CssClass="btn btn-theme" ID="save" runat="server" Text="新增" OnClick="save_Click" />
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
