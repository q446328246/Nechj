<%@ Page Language="C#" EnableViewState="false" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <ShopNum1:Meto ID="meto1" runat="server" Type="1" SkinFilename="Meto.ascx" />
    <link href="Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />
    <script src="Themes/Skin_Default/Js/jquery.min.js" type="text/javascript"></script>
	<link href="Themes/Skin_Default/inc/Style/top.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        if (top.location != location) top.location.href = location.href;
        $(document).ready(function () {

            $("#FlowCate").mouseover(function () {
                $("#ThrCategory").show();
                $("#ThrCategory").focus();
            }).mouseout(function () {
                $("#ThrCategory").hide();
            });


            $("#ThrCategory").mouseover(function () {
                $("#ThrCategory").show();
            }).mouseout(function () {
                $("#ThrCategory").hide();
            });

        });
    </script>
    <!--[if lte IE 6]>
    <script src="Themes/Skin_Default/Js/DD_belatedPNG_0.0.8a.js" type="text/javascript"></script>
    <script type="text/javascript">
        DD_belatedPNG.fix('div, ul, img, li, input , a');
    </script>
    <![endif]-->
</head>
<body style="background: #f6f6f6;">
    <form id="from1" runat="server">
    <!--foot Start-->
    <div class="wrapBox FootMessage">
        <ShopNum1:Bottom ID="Bottom" runat="server" SkinFilename="Bottom.ascx" class="foot_bg" />
    </div>
    <!--//foot End-->
    </form>
</body>
</html>
