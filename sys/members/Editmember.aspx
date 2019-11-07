<%@ Page Title="" Language="C#" MasterPageFile="~/sys/master.Master" AutoEventWireup="true" CodeBehind="Editmember.aspx.cs" Inherits="Tayan.sys.members.Editmember" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
        <h3><i class="fa fa-angle-right"></i> 修改帳號</h3>
    <div class="cmxform form-horizontal style-form">
    <!-- /row -->
        <div class="row mt">
          <div class="col-lg-12">
              <div class="form-panel">
              <div class="form">
                <form class="cmxform form-horizontal style-form" id="signupForm" method="get" action="">
                  <div class="form-group ">
                    <label for="firstname" class="control-label col-lg-2">帳號</label>
                    <div class="col-lg-10">
                        <asp:Label ID="IDLabel" runat="server" ></asp:Label>
                      
                    </div>
                  </div>
                  <div class="form-group ">
                    <label for="lastname" class="control-label col-lg-2">密碼</label>
                    <div class="col-lg-10">
                      <input class=" form-control" id="PW" name="PW" type="password" runat="server"/>
                        <asp:HiddenField ID="hidden" runat="server" />
                    </div>
                  </div>
                  <div class="form-group ">
                    <label for="username" class="control-label col-lg-2">姓名</label>
                    <div class="col-lg-10">
                      <input class="form-control " id="Name" name="Name" type="text" runat="server"/>
                    </div>
                  </div>
                  <div class="form-group ">
                    <label for="password" class="control-label col-lg-2">照片</label>
                    <div class="col-lg-10">
                        <asp:Image ID="Image1" runat="server" Style="width: 150px"/>
                        <asp:FileUpload ID="profile" runat="server" class="form-control "/>
                        <asp:Label ID="Massage" runat="server" Text=""></asp:Label>
                        <asp:HiddenField ID="hiddenP" runat="server" />
                    </div>
                  </div>
                    <div class="form-group ">
                    <label for="email" class="control-label col-lg-2">Email</label>
                    <div class="col-lg-10">
                      <input class="form-control " id="email" name="email" type="email" runat="server"/>
                    </div>
                  </div>
                    <div class="form-group ">
                        <label for="confirm_password" class="control-label col-lg-2">部門</label>
                        <div class="col-lg-10">
                            <input class="form-control " id="dept" name="dept" type="text" runat="server"/>
                        </div>
                    </div>
                    <div class="form-group ">
                        <label for="confirm_password" class="control-label col-lg-2">電話</label>
                        <div class="col-lg-10">
                            <input class="form-control " id="tel" name="tel" type="text" runat="server"/>
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
                        
                        <asp:Button CssClass="btn btn-theme" ID="upload" runat="server" Text="更新" OnClick="upload_Click" />
                        <asp:Button CssClass="btn btn-theme04" ID="cancel" runat="server" Text="取消" OnClick="cancel_Click"/>
                  
                    </div>
                  </div>
                </form>
              </div>
            </div>
          </div>
        </div>
    </div>
</asp:Content>
