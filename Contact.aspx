<%@ Page Title="" Language="C#" MasterPageFile="~/Tayana.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Tayan.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('.slideshow').cycle({
                fx: 'fade' // choose your transition type, ex: fade, scrollUp, shuffle, etc...
            });
        });
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <!--表單-->
    <div class="from01">
        <p>
            Please Enter your contact information<span class="span01">*Required</span>
        </p>
        <br />
        <table>
            <tr>
                <td class="from01td01">Name :</td>
                <td><span>*</span><input type="text" name="Name" id="Name" required="" runat="server"/>
                </td>
            </tr>
            <tr>
                <td class="from01td01">Email :</td>
                <td><span>*</span><input type="email" name="Email" id="Email" required="" runat="server"/></td>
            </tr>
            <tr>
                <td class="from01td01">Phone :</td>
                <td><span>*</span><input type="tel" name="Phone" id="Phone" required="" runat="server"/></td>
            </tr>
            <tr>
                <td class="from01td01">Country :</td>
                <td><span>*</span>
                    <asp:DropDownList ID="areaList" runat="server"></asp:DropDownList>
                    
            </tr>
            <tr>
                <td colspan="2"><span>*</span>Brochure of interest  *Which Brochure would you like to view?</td>
            </tr>
            <tr>
                <td class="from01td01">&nbsp;</td>
                <td>
                    <asp:DropDownList ID="yachtList" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="from01td01">Comments:</td>
                <td>
                    <textarea name="Comments" id="Comments" cols="45" rows="5" runat="server"></textarea></td>
            </tr>
            <tr>
                <td class="from01td01"></td>
                <td>本網站採Google reCaptcha v3 驗證</td>
            </tr>
            <tr>
                <td class="from01td01">&nbsp;</td>
                <td class="f_right">
                    <asp:ImageButton ID="submitBTN" runat="server" OnClick="submitBTN_Click" ImageUrl="images/buttom03.gif"/>
                </td>
            </tr>
        </table>
    </div>
    <!--表單-->

    <div class="box1">
        <span class="span02">Contact with us</span><br />
        Thanks for your enjoying our web site as an introduction to the Tayana world and our range of yachts.
As all the designs in our range are semi-custom built, we are glad to offer a personal service to all our potential customers. 
If you have any questions about our yachts or would like to take your interest a stage further, please feel free to contact us.
    </div>

    <div class="list03">
        <p>
            <span>TAYANA HEAD OFFICE</span><br />
            NO.60 Haichien Rd. Chungmen Village Linyuan Kaohsiung Hsien 832 Taiwan R.O.C<br />
            tel. +886(7)641 2422<br />
            fax. +886(7)642 3193<br />
            info@tayanaworld.com<br />
        </p>
    </div>


    <div class="list03">
        <p>
            <span>SALES DEPT.</span><br />
            +886(7)641 2422  ATTEN. Mr.Basil Lin<br />
            <br />
        </p>
    </div>

    <div class="box4">
        <h4>Location</h4>
        <p>
            <iframe width="695" height="518" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="https://maps.google.com/maps?f=d&amp;source=s_d&amp;saddr=%E5%8F%B0%E7%81%A3%E9%AB%98%E9%9B%84%E5%B8%82%E5%B0%8F%E6%B8%AF%E5%8D%80%E4%B8%AD%E5%B1%B1%E5%9B%9B%E8%B7%AF%E9%AB%98%E9%9B%84%E5%B0%8F%E6%B8%AF%E6%A9%9F%E5%A0%B4&amp;daddr=%E5%8F%B0%E7%81%A3%E9%AB%98%E9%9B%84%E5%B8%82%E6%9E%97%E5%9C%92%E5%8D%80%E4%B8%AD%E9%96%80%E6%9D%91%E6%B5%B7%E5%A2%98%E8%B7%AF%EF%BC%96%EF%BC%90%E8%99%9F&amp;hl=zh-en&amp;geocode=FRthWAEdwlwsByGxkQ4S1t-ckinNS9aM0xxuNDELEXJZh6Soqg%3BFRRmVwEdMKssBym5azbzl-JxNDGd62mwtzGaDw&amp;aq=0&amp;oq=%E9%AB%98%E9%9B%84%E5%B0%8F%E6%B8%AF%E6%A9%9F&amp;sll=22.50498,120.36792&amp;sspn=0.008356,0.016512&amp;g=%E5%8F%B0%E7%81%A3%E9%AB%98%E9%9B%84%E5%B8%82%E6%9E%97%E5%9C%92%E5%8D%80%E4%B8%AD%E9%96%80%E6%9D%91%E6%B5%B7%E5%A2%98%E8%B7%AF%EF%BC%96%EF%BC%90%E8%99%9F&amp;mra=ls&amp;ie=UTF8&amp;t=m&amp;ll=22.537135,120.360718&amp;spn=0.08213,0.119133&amp;z=13&amp;output=embed"></iframe>
        </p>

    </div>




    <!--------------------------------內容結束------------------------------------------------------>
</asp:Content>
