<%@ Page Title="" Language="C#" MasterPageFile="~/sys/master.Master" AutoEventWireup="true" CodeBehind="addmember.aspx.cs" Inherits="Tayan.sys.members.addmember" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h3><i class="fa fa-angle-right"></i>新增帳號</h3>
    <div class="cmxform form-horizontal style-form">
        <!-- /row -->
        <div class="row mt">
            <div class="col-lg-12">
                <div class="form-panel">
                    <div class="form">
                        <form class="cmxform form-horizontal style-form" id="signupForm" method="get" action="#">
                            <div class="form-group ">
                                <label for="firstname" class="control-label col-lg-2">帳號</label>
                                <div class="col-lg-10">
                                    <input class=" form-control" id="UID" name="UID" type="text" runat="server" required="" oninvalid="setCustomValidity('請填入帳號')" oninput="setCustomValidity('')" ClientIDMode="Static"/>
                                    <asp:Label ID="Label1" runat="server" ClientIDMode="Static" ForeColor="red"></asp:Label>
                                    <script>
                                        var UID = document.getElementById("UID");
                                        UID.addEventListener("blur", function (e)
                                        {
                                            var data = `UID=${UID.value}`
                                            var xhr = new XMLHttpRequest();
                                            //xhr.withCredentials = true;
                                            xhr.addEventListener("readystatechange", function () {
                                                if (this.readyState === 4) {
                                                    console.log(this.responseText);
                                                    if (this.responseText == "NO") {
                                                        document.getElementById("Label1").innerText = "此帳號已存在";
                                                    }
                                                }
                                            });
                                            xhr.open("POST", "checkID.ashx");
                                            xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
                                            xhr.send(data);

                                        })
                                    </script>
                                </div>
                            </div>
                            <div class="form-group ">
                                <label for="lastname" class="control-label col-lg-2">密碼</label>
                                <div class="col-lg-10">
                                    <input class=" form-control" id="PW" type="password" runat="server" required="" oninvalid="setCustomValidity('請填入密碼')" oninput="setCustomValidity('')" clientidmode="Static" />
                                </div>
                            </div>
                            <div class="form-group ">
                                <label for="lastname" class="control-label col-lg-2">請再次確認密碼</label>
                                <div class="col-lg-10">
                                    <input class=" form-control" id="PWCheck" name="PW" type="password" runat="server" required="" oninvalid="setCustomValidity('請再次確認密碼')" oninput="check(this)" />
                                </div>
                               
                                <script type='text/javascript'>
                                    function check(input) {
                                        console.log(document.getElementById('PW').value);
                                        if (input.value != document.getElementById('PW').value) {
                                            input.setCustomValidity('請重新確認密碼.');
                                        } else {
                                            // input is valid -- reset the error message
                                            input.setCustomValidity('');
                                        }
                                    }
                                </script>

                            </div>

                            <div class="form-group ">
                                <label for="username" class="control-label col-lg-2">姓名</label>
                                <div class="col-lg-10">
                                    <input class="form-control " id="Name" name="Name" type="text" runat="server" required="" oninvalid="setCustomValidity('請填入姓名')" oninput="setCustomValidity('')" />
                                </div>
                            </div>
                            <div class="form-group ">
                                <label for="password" class="control-label col-lg-2">照片</label>
                                <div class="col-lg-10">
                                    <asp:FileUpload ID="profile" runat="server" class="form-control " />
                                    <asp:Label ID="Message" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="form-group ">
                                <label for="email" class="control-label col-lg-2">Email</label>
                                <div class="col-lg-10">
                                    <input class="form-control" id="email" name="email" type="email" runat="server" required="" oninvalid="setCustomValidity('請填入e-mail')" oninput="setCustomValidity('')" />
                                </div>
                            </div>
                            <div class="form-group ">
                                <label for="confirm_password" class="control-label col-lg-2">部門</label>
                                <div class="col-lg-10">
                                    <input class="form-control " id="dept" name="dept" type="text" runat="server" />
                                </div>
                            </div>
                            <div class="form-group ">
                                <label for="confirm_password" class="control-label col-lg-2">電話</label>
                                <div class="col-lg-10">
                                    <input class="form-control " id="tel" name="tel" type="text" runat="server" />
                                </div>
                            </div>
                            <div class="form-group ">
                                <label for="confirm_password" class="control-label col-lg-2">權限</label>
                                <div class="col-lg-10">

                                    <asp:CheckBoxList ID="CheckBoxList" runat="server">
                                        <asp:ListItem Value="001">權限</asp:ListItem>
                                        <asp:ListItem Value="002">產品資訊</asp:ListItem>
                                        <asp:ListItem Value="003">NEWS</asp:ListItem>
                                        <asp:ListItem Value="004">Dealers</asp:ListItem>
                                       

                                    </asp:CheckBoxList>
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
