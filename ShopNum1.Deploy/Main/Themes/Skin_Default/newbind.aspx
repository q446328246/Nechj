<%@ Page Language="C#" AutoEventWireup="true" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <link href="Themes/Skin_Default/Style/index0.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery-1.6.2.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <!--head start-->
    <!-- #include file="headShop.aspx" -->
    <!--main start-->
    <!-- middle -->
    <div class="clearmiddle" style="padding: 10px; width: 960px;">
        <script type="text/javascript">
            $(document).ready(function () {
                $(".bind_re1").click(function () {
                    $(".bind_re1>input[type=radio]").attr("checked", "checked");
                    $(".regesiterd2").hide("slow");
                    $(".content1").css("background", "#fff9f3");
                    $(".content2").css("background", "#fff")
                    $(".regesiterd1").slideToggle("slow");
                });
                $(".bind_re2").click(function () {
                    $(".bind_re2>input[type=radio]").attr("checked", "checked");
                    $(".regesiterd1").hide("slow");
                    $(".content2").css("background", "#fff9f3");
                    $(".content1").css("background", "#fff")
                    $(".regesiterd2").slideToggle("slow");
                });
            });
        </script>
        <div class="newbind">
            <ShopNum1:SecondUserBind ID="SecondUserBind" runat="server" SkinFilename="SecondUserBind.ascx" />
        </div>
        <!-- 隔开 -->
        <div class="cle" style="width: 960px; margin: 0 auto; height: 8px; line-height: 8px;
            overflow: hidden; font-size: 8px;">
        </div>
    </div>
    <!--foot start-->
    <!-- #include file="foot1.aspx" -->
    <!--foot End-->
    </form>
</body>
</html>
