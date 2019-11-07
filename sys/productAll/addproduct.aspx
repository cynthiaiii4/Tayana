<%@ Page Title="" Language="C#" MasterPageFile="~/sys/master.Master" AutoEventWireup="true" CodeBehind="addproduct.aspx.cs" Inherits="Tayan.sys.productAll.addproduct" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h3><i class="fa fa-angle-right"></i>編輯產品資訊</h3>
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
                                <label for="overview" class="control-label col-lg-2">Overview</label>
                                <div class="col-lg-10">
                                    <textarea id="overview" name="overview" clientidmode="Static" runat="server"></textarea>
                                    <script>CKEDITOR.replace("overview");</script>
                                </div>
                            </div>

                            <div class="form-group ">
                                <label for="layout" class="control-label col-lg-2">Layout & deck plan</label>
                                <div class="col-lg-10">
                                    <textarea id="layout" name="layout" clientidmode="Static" runat="server"></textarea>
                                    <script>CKEDITOR.replace("layout");</script>
                                </div>
                            </div>
                            <div class="form-group ">
                                <label for="specification" class="control-label col-lg-2">Specification</label>
                                <div class="col-lg-10">
                                    <textarea id="specification" name="specification" clientidmode="Static" runat="server"></textarea>
                                    <script>CKEDITOR.replace("specification");</script>
                                </div>
                            </div>
                            <div class="form-group ">
                                <label for="images" class="control-label col-lg-2">設定首頁照片(總大小限制為4MB)</label>
                                <div class="col-lg-10">
                                    <asp:FileUpload ID="indexImg" runat="server" class="form-control " />
                                    <asp:CheckBox ID="newProduct" runat="server" Text="加上New標籤" />
                                </div>
                            </div>
                            <div class="form-group ">
                                <label for="images" class="control-label col-lg-2">產品照片(總大小限制為4MB)</label>
                                <div class="col-lg-10">
                                    <asp:FileUpload AllowMultiple="True" ID="images" runat="server" class="form-control " />
                                </div>
                            </div>

                            <div class="form-group ">
                                <label for="files" class="control-label col-lg-2">附件檔案(總大小限制為4MB)</label>
                                <div class="col-lg-10">
                                    <asp:FileUpload AllowMultiple="True" ID="files" runat="server" class="form-control " />
                                </div>
                            </div>


                            <div class="form-group">
                                <div class="col-lg-offset-2 col-lg-10">
                                    <asp:Label ID="check" runat="server" ForeColor="Red"></asp:Label>
                                    <asp:Button CssClass="btn btn-theme" ID="save" runat="server" Text="儲存" OnClick="save_Click" />
                                    <asp:Button CssClass="btn btn-theme04" ID="cancel" runat="server" Text="取消" OnClick="cancel_Click" />

                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
   <%-- <script>
        $("#indexImg").change(function () {
            var indexImg = $("#indexImg")[0];
            if (indexImg.file[0].contentType.indexOf("image") == -1) {
                document.getElementById("check").innerText = "首頁圖片格式錯誤";
            }
        })
        $("#images").change(function () {
            var upploader_dom = $("#images");
            # 檔案格式是以副檔名來做判斷
            console.log(uploader_dom.file[0].type);
        })
    </script>--%>
</asp:Content>
