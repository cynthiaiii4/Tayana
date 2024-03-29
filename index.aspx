﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Tayan.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>TtayanaWorld (DEMO)</title>
    <script type="text/javascript" src="Scripts/jquery.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery.cycle.all.2.74.js"></script>
    <!--[if lt IE 7]>
        <script type="text/javascript" src="javascript/iepngfix_tilebg.js"></script>
    <![endif]-->
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/reset.css" rel="stylesheet" type="text/css" />
   
</head>
<body>
    <form runat="server">
        <div class="contain">
            <div class="sub">
                <p><a href="index.aspx">Home</a></p>
            </div>

            <!--------------------------------選單開始---------------------------------------------------->
            <div class="menu">
                <ul>
                    <li class="menuli01"><a href="YachtOverview.aspx" runat="server" id="Overview">Yachts</a></li>
                    <li class="menuli02"><a href="NEWS_list.aspx">NEWS</a></li>
                    <li class="menuli03"><a href="Company.aspx">COMPANY</a></li>
                    <li class="menuli04"><a href="Dealers.aspx" runat="server" id="Dealers">DEALERS</a></li>
                    <li class="menuli05"><a href="Contact.aspx">CONTACT</a></li>
                </ul>
            </div>
            <!--------------------------------選單開始結束---------------------------------------------------->


            <!--遮罩-->
            <div class="bannermasks">
                <img src="images/banner00_masks.png" alt="&quot;&quot;" />
            </div>
            <!--遮罩結束-->








            <!--------------------------------換圖開始---------------------------------------------------->
            <div id="abgne-block-20110111">
                <div class="bd">
                    <div class="banner">
                        <%--最上方背景大圖--%>
                        <ul>
                            <%--<asp:Literal ID="bLi" runat="server"></asp:Literal>--%>
                            <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                                    <li class="info"><a href="#">
                                        <img src='<%# "/sys/uploadfile/images/"+ Eval("img") %>' runat="server" style="object-fit: cover;width: 100%;"/></a><!--文字開始--><div class="wordtitle">
                                            <asp:Literal ID="Literal1" runat="server" Text='<%# Bind("series") %>'></asp:Literal>
                                            <span><asp:Literal ID="Literal2" runat="server" Text='<%# Bind("number") %>'></asp:Literal></span><br />
                                            <p>SPECIFICATION SHEET</p>
                                        </div>
                                        <!--文字結束-->
                                        <!--新船型開始  54型才出現其於隱藏 -->
                                        <div class="new">
                                            <img src="images/new01.png" alt="new" runat="server" visible='<%# Eval("new").ToString()=="True"?true:false %>' />
                                            <!--新船型結束-->
                                        </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <%--<li class="info"><a href="#">
                            <img src="images/banner002b.jpg" /></a><!--文字開始--><div class="wordtitle">TAYANA <span>54</span><br />
                                <p>SPECIFICATION SHEET</p>
                            </div>
                            <!--文字結束-->
                            <!--新船型開始  54型才出現其於隱藏 -->
                            <div class="new">
                                <img src="images/new01.png" alt="new" /></div>
                            <!--新船型結束-->
                        </li>--%>
                        </ul>


                        <!--小圖開始-->
                        <div class="bannerimg title">
                            <ul>
                                <asp:Literal ID="sLi" runat="server"></asp:Literal>
                                <asp:Repeater ID="Repeater2" runat="server">
                                    <ItemTemplate>
                                        <li class="on">
                                            <div>
                                                <p class="bannerimg_p">
                                                    <img src='<%# "/sys/uploadfile/images/S"+ Eval("img") %>' runat="server" alt="&quot;&quot;" />
                                                </p>
                                            </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <%--  <li class="on">
                                <div>
                                    <p class="bannerimg_p">
                                        <img src="images/i001.jpg" alt="&quot;&quot;" /></p>
                                </div>
                            </li>--%>
                            </ul>
                        </div>
                        <!--小圖結束-->
                    </div>
                </div>
            </div>
            <!--------------------------------換圖結束---------------------------------------------------->


            <!--------------------------------最新消息---------------------------------------------------->
            <div class="news">
                <div class="newstitle">
                    <p class="newstitlep1">
                        <img src="images/news.gif" alt="news" />
                    </p>
                    <p class="newstitlep2"><a href="NEWS_list.aspx">More>></a></p>
                </div>

                <ul>
                    <asp:Repeater ID="Repeater3" runat="server">
                        <ItemTemplate>
                            <!--TOP第一則最新消息-->
                            <li style="position: relative">
                                <div class="news01">
                                    <!--TOP標籤-->
                                    <div class="newstop" style="top:0px">
                                        <img src="images/new_top01.png" alt="&quot;&quot;" runat="server" Visible='<%# Eval("topNews").ToString()=="True"?true:false %>'/>
                                    </div>
                                    <!--TOP標籤結束-->
                                    <div class="news02p1">
                                        <p class="news02p1img">
                                            <img src='<%# "/sys/uploadfile/images/I"+ Eval("img") %>' runat="server" alt="&quot;&quot;" />
                                        </p>
                                    </div>
                                    <p class="news02p2">
                                        <span style="color:#02a5b8"><asp:Literal ID="Literal2" runat="server" Text='<%# Eval("initDate","{0:d}")%>'></asp:Literal></span>
                                        <span>
                                        <a runat="server" ID="newslink" href='<%#"NEWS_view.aspx?id="+Eval("id")%>' ><asp:Label ID="Literal3" runat="server" Text='<%# Eval("title").ToString().Length>50?Eval("title").ToString().Substring(0,30)+"...":Eval("title") %>'></asp:Label></a>
                                        </span>
                                    </p>
                                </div>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                    <!--TOP第一則最新消息結束-->

                    <!--第二則-->
                   <%-- <li>

                        <div class="news01">
                            <!--TOP標籤-->
                            <div class="newstop">
                                <img src="images/new_top01.png" alt="&quot;&quot;" />
                            </div>
                            <!--TOP標籤結束-->
                            <div class="news02p1">
                                <p class="news02p1img">
                                    <img src="images/pit001.jpg" alt="&quot;&quot;" />
                                </p>
                            </div>
                            <p class="news02p2">
                                <span>Tayana 58 CE Certifica..</span>
                                <a href="#">For Tayana 58 entering the EU, CE Certificates are AVAILABLE to ensure conformity to all applicable European ...</a>
                            </p>
                        </div>
                    </li>--%>
                    <!--第二則結束-->
                </ul>
            </div>
            <!--------------------------------最新消息結束---------------------------------------------------->



            <!--------------------------------落款開始---------------------------------------------------->
            <div class="footer">
                <div class="footerp00">
                    <a href="http://www.tognews.com/">
                        <img src="images/tog.jpg" alt="&quot;&quot;" /></a>
                    <p class="footerp001">© 1973-2011 Tayana Yachts, Inc. All Rights Reserved</p>
                </div>
                <div class="footer01">
                    <span>No. 60, Hai Chien Road, Chung Men Li, Lin Yuan District, Kaohsiung City, Taiwan, R.O.C.</span><br />
                    <span>TEL：+886(7)641-2721</span> <span>FAX：+886(7)642-3193</span><span><a href="mailto:tayangco@ms15.hinet.net">E-mail：tayangco@ms15.hinet.net</a>.</span>
                </div>
            </div>
            <!--------------------------------落款結束---------------------------------------------------->

        </div>
    </form>
<script type="text/javascript">

    document.querySelectorAll('.banner ul li')[0].classList.add("on");
    $(function () {

        // 先取得 #abgne-block-20110111 , 必要參數及輪播間隔
        var $block = $('#abgne-block-20110111'),
            timrt, speed = 4000;


        // 幫 #abgne-block-20110111 .title ul li 加上 hover() 事件
        var $li = $('.title ul li', $block).hover(function () {
            // 當滑鼠移上時加上 .over 樣式
            $(this).addClass('over').siblings('.over').removeClass('over');
        }, function () {
            // 當滑鼠移出時移除 .over 樣式
            $(this).removeClass('over');
        }).click(function () {
            // 當滑鼠點擊時, 顯示相對應的 div.info
            // 並加上 .on 樣式

            $(this).addClass('on').siblings('.on').removeClass('on');
            $('#abgne-block-20110111 .bd .banner ul:eq(0)').children().hide().eq($(this).index()).fadeIn(1000);
        });

        // 幫 $block 加上 hover() 事件
        $block.hover(function () {
            // 當滑鼠移上時停止計時器
            clearTimeout(timer);
        }, function () {
            // 當滑鼠移出時啟動計時器
            timer = setTimeout(move, speed);
        });

        //// 控制輪播
        function move() {
            var _index = $('.title ul li.on', $block).index();
            _index = (_index + 1) % $li.length;
            $li.eq(_index).click();

            timer = setTimeout(move, speed);
        }

        // 啟動計時器
        timer = setTimeout(move, speed);

    });
</script>
<style>
    .on {
        width: 100%;
    }
     
</style>
</body>
</html>
