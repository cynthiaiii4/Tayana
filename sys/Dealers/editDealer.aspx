﻿<%@ Page Title="" Language="C#" MasterPageFile="~/sys/master.Master" AutoEventWireup="true" CodeBehind="editDealer.aspx.cs" Inherits="Tayan.sys.Dealers.editDealer" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script src="https://cdn.ckeditor.com/4.13.0/standard/ckeditor.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h3><i class="fa fa-angle-right"></i>修改經銷商資訊</h3>
    <div class="cmxform form-horizontal style-form">
        <div class="row mt">
            <div class="col-lg-12">
                <div class="form-panel">
                    <div class="form">
                        <form class="cmxform form-horizontal style-form" id="signupForm" method="get" >
                            <div class="form-group ">
                                <label for="title" class="control-label col-lg-2">地區</label>
                                <div class="col-lg-10">
                                    <asp:dropdownlist id="areaList" runat="server" clientidmode="Static"></asp:dropdownlist>
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
                                    <asp:image id="Image1" runat="server" style="width: 200px"/>
                                    <asp:fileupload id="photo" runat="server" class="form-control "  clientidmode="Static" />
                                    <asp:hiddenfield id="hiddenP" runat="server" />
                                </div>
                            </div>
                            <div class="form-group ">
                                <label for="dealerInfo" class="control-label col-lg-2">
                                    經銷商資訊<br/>
                                    (可拖拉改變編輯框大小)</label>
                                <div class="col-lg-10">
                                    <textarea id="dealerInfo" clientidmode="Static" runat="server" required=""></textarea>
                                    <script>CKEDITOR.replace("dealerInfo",
    {
        filebrowserBrowseUrl: '/sys/ckeditor/ckfinder/ckfinder.html',
        filebrowserImageBrowseUrl: '/sys/ckeditor/ckfinder/ckfinder.html?type=Images',
        filebrowserFlashBrowseUrl: '/sys/ckeditor/ckfinder/ckfinder.html?type=Flash',
        filebrowserUploadUrl: '/sys/ckeditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files',
        filebrowserImageUploadUrl: '/sys/ckeditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images',
        filebrowserFlashUploadUrl: '/sys/ckeditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash'
    });</script>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-offset-2 col-lg-10">
                                    <asp:label id="check" runat="server" forecolor="Red"></asp:label>
                                    <asp:button cssclass="btn btn-theme" id="save" runat="server" text="儲存" onclick="save_Click" />
                                    <asp:button cssclass="btn btn-theme04" id="cancel" runat="server" text="取消" onclick="cancel_Click" />
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
