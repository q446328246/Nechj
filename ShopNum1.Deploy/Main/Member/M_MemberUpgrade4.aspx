<html>
<head id="Head1" runat="server">
    <title>会员升级</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script src="js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="js/Common.js"></script>
    <script type="text/javascript" language="javascript" src="/js/artDialog/artDialog.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="M_Welcome.aspx">我是买家</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">会员升级</span></p>
        
        <%--        <ShopNum1:M_RecommendCommision ID="M_RecommendCommision" runat="server" SkinFilename="Skin/M_RecommendCommision.ascx"
            PageSize="10" />--%>
    </div>
    <script type="text/javascript" language="javascript">
        //跳转到制定的页码
        function ontoPage(txtId) {
            location.href = '?isread=<%= ShopNum1.Common.Common.ReqStr("isread") %>&pageid=' + $("#txtIndex").val();
        }

        


    </script>
                <p class="ptitle">
        提示：您的会员等级已到最高！</p>
    </form>

</body>
</html>