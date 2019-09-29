<%@ Page Language="C#" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <link href="Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />
</head>
<body style="background: none;">
    <form id="from1" runat="server">
    <div class="postage">
        <div class="post_logo">
            <a href="Default.aspx">
                <img src="Themes/Skin_Default/Images/newLogo.png" /></a>
        </div>
        <div class="post_con">
            <h1>
                尊敬的<span>李美方</span>您好：</h1>
            <p>
                感谢您在本商城( mall.t.com )购物!</p>
            <p>
                您的订单<b>420329444</b>还未付款，请尽快付款，您可进入“<a href="">订单详情</a>”页面随时关注订单状态，并对订单进行修改等操作。
            </p>
            <p>
                感谢您对我们的支持，祝您购物愉快!</p>
        </div>
        <div class="post_tips">
            <p>
                如果您想随时随地购物，查阅订单状态等，下载<a href="">手机移动客户端</a>更方便、更快捷；</p>
        </div>
    </div>
    </form>
</html>
