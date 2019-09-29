<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Page Language="C#" %>

<%@ Register TagPrefix="ShopNum1" Namespace="ActionlessForm" Assembly="ActionlessForm" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <link type="text/css" rel="Stylesheet" href='Themes/Skin_Default/Style/index-red.css' />
    <link href="/Main/Themes/Skin_Default/Style/indexshop1.css" rel="stylesheet" type="text/css" />
    <ShopNum1Shop:ShopMeto ID="ShopMeto" SkinFilename="SetMeta.ascx" runat="server" />
</head>
<body>
    <ShopNum1:Form ID="Form1" method="post" runat="server">
        <!--head start-->
        <!-- #include file="AgentHead.aspx" -->
        <div id="content">
            <!-- #include file="head.aspx" -->
            <div class="warp clearfix">
                <!--main start-->
                <!-------宝贝下架-------->
                <div class="ignore">
                    <dl>
                        <dt class="knight">
                            <img src="Themes/Skin_Default/Images/nofindks.jpg" /></dt>
                        <dd class="warrior">
                            <h4>
                                很抱歉，您查看的宝贝不存在，可能已下架或者被删除</h4>
                            您可以：
                            <p class="courtday">
                                1.该宝贝可能已经下架，您可以联系卖家找找宝贝<br />
                                2.在顶部搜索框重新输入关键词试试<br />
                                3.去<a href="/default.html">店铺首页</a>看看，去找你感兴趣的宝贝分类</p>
                            <p>
                            </p>
                        </dd>
                    </dl>
                </div>

            </div>
        </div>
        <!--foot start-->
        <!-- #include file="foot.aspx" -->
        <!--end-->
    </ShopNum1:Form>
    <!--js-->

    <script src="/js/jquery-1.6.2.min.js" type="text/javascript"></script>

    <script src="Themes/Skin_Default/js/default1.js" type="text/javascript"></script>

</body>
</html>
