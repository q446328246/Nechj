<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="B_MemberRegProtocol.aspx.cs" Inherits="ShopNum1.Deploy.Main.Bourse.B_MemberRegProtocol" %>
<%@ Register Src="Skin/B_Bottom.ascx" TagName="B_Bottom" TagPrefix="uc2" %>
<%@ Register Src="Skin/B_MemberRegProtocol.ascx" TagName="B_MemberRegProtocol" TagPrefix="uc1" %>
<%@ Import Namespace="ShopNum1.Common" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    
    <link href="Style/index.css" rel="stylesheet" type="text/css" />
    <script src="../Themes/Skin_Default/Js/jquery.min.js" type="text/javascript"></script>
    <link href="../Themes/Skin_Default/inc/Style/top.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
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
    <style type="text/css">
    
    .baocbtn{ text-align:center; background:url(images/baocbtn.jpg)  no-repeat; color:#fff; font-weight:bold; font-size:14px; width:72px; height:30px; line-height:30px; border:none;  cursor:pointer;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <!--head Start-->
   
    <div class="FlowCat_cont clearfix">
        
        <div>
          <uc1:B_MemberRegProtocol ID="B_MemberRegProtocol1" runat="server" />
        </div>
    </div>
    
    </form>
   
</body>
</html>