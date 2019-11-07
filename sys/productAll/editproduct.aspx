<%@ Page Title="" Language="C#" MasterPageFile="~/sys/master.Master" AutoEventWireup="true" CodeBehind="editproduct.aspx.cs" Inherits="Tayan.sys.productAll.editproduct"  ValidateRequest="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h3><i class="fa fa-angle-right"></i>修改產品資訊</h3>
    <div class="cmxform form-horizontal style-form">
        <!-- /row -->
        <div class="row mt">
            <div class="col-lg-12">
                <div class="form-panel">
                    <div class="form">
                        <form class="cmxform form-horizontal style-form" id="signupForm" method="get" action="#" enctype="multipart/form-data">
                            <div class="form-group ">
                                <label for="series" class="control-label col-lg-2">系列名稱</label>
                                <div class="col-lg-10">
                                    <input class=" form-control" id="series" name="series" type="text" runat="server" required="" oninvalid="setCustomValidity('請填入系列名稱')" oninput="setCustomValidity('')" />
                                </div>
                            </div>
                            <div class="form-group ">
                                <label for="number" class="control-label col-lg-2">型號</label>
                                <div class="col-lg-10">
                                    <input class=" form-control" id="number" name="number" type="text" runat="server" required="" oninvalid="setCustomValidity('請填入型號')" oninput="setCustomValidity('')" clientidmode="Static" />
                                </div>
                            </div>
                            <div class="form-group ">
                                <label for="overview" class="control-label col-lg-2">Overview<br/>(可以拖拉改變編輯框大小)</label>
                                <div class="col-lg-10">
                                    <textarea id="overview" name="overview" clientidmode="Static" runat="server"></textarea>
                                    <script>CKEDITOR.replace("overview");</script>
                                </div>
                            </div>

                            <div class="form-group ">
                                <label for="layout" class="control-label col-lg-2">Layout & deck plan<br/>(可以拖拉改變編輯框大小)</label>
                                <div class="col-lg-10">
                                    <textarea id="layout" name="layout" clientidmode="Static" runat="server"></textarea>
                                    <script>CKEDITOR.replace("layout");</script>
                                </div>
                            </div>
                            <div class="form-group ">
                                <label for="specification" class="control-label col-lg-2">Specification<br/>(可以拖拉改變編輯框大小)</label>
                                <div class="col-lg-10">
                                    <textarea id="specification" name="specification" clientidmode="Static" runat="server"></textarea>
                                    <script>CKEDITOR.replace("specification");</script>
                                </div>
                            </div>
                            


                            <div class="form-group">
                                <div class="col-lg-offset-2 col-lg-10">
                                    <asp:label id="check" runat="server" forecolor="Red"></asp:label>
                                    <asp:button cssclass="btn btn-theme" id="save" runat="server" text="儲存" onclick="upload_Click" />
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
