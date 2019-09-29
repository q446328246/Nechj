
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WeiXinPay.aspx.cs" Inherits="ShopNum1.Deploy.Main.Account.WeiXinPay" %>

<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register Src="Skin/WeiXinPay.ascx" TagName="A_WeiXinPay" TagPrefix="uc1" %>
<%@ Register Src="Skin/A_Head.ascx" TagName="A_Head" TagPrefix="uc2" %>
<%@ Register Src="Skin/A_Left.ascx" TagName="A_Left" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>账户管理-扫码支付充值</title>
    <link href="style/style.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="/js/artDialog/artDialog.js"></script>
    <script src="js/jquery.pack.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
    

            var int=self.setInterval("orderStatus()",5000)
        function orderStatus()
        {
            $.post("<?= url::to(['/order/order/orderstatus'])?>",
                {
                    orderCode:"<?= $orderCode?>"
                },
                function(data,status){
                    if(data.state=='success'&&data.data=='paid'){
                        location.href = "<?= url::to(['/order/order/return','orderCode'=>$orderCode])?>";
                    }
                });
        }
</script>

</head>


<body>
    <form id="form1" runat="server">
         

        <div id="containe_bg">
            <!--头部Top-->
            <uc2:A_Head ID="A_Head1" runat="server" />
            <%--        <ShopNum1Account:A_Head ID="A_Head" runat="server" SkinFilename="Skin/A_Head.ascx" />--%>
            <!--内容部分Content-->
            <div id="content_bg">
                <div id="content1">
                    <div id="content2">
                        <uc3:A_Left ID="A_Left1" runat="server" />
                        <%--                    <ShopNum1Account:A_Left ID="A_Left" runat="server" SkinFilename="Skin/A_Left.ascx" />--%>
                        <!--右边框架-->
                        <div class="dpsc_mian">
                            <p class="ptitle">
                                <a href="A_Welcome.aspx">账户管理</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">扫码支付充值</span>
                                
                                    <%--        <ShopNum1Account:A_BindMobile ID="A_BindMobile" runat="server" SkinFilename="Skin/A_BindMobile.ascx" />--%>
                                <br />
                                    <uc1:A_WeiXinPay ID="A_WeiXinPay1" runat="server" PageSize="5" />
                                    <br />
                                   <asp:Image ID="Image1" runat="server" Style="width: 200px; height: 200px;margin-left: 300px;" />
                                
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            <div style="clear: both;">
            </div>
            <!--底部文件调用-->
            <!-- #include file="A_bottom.aspx" -->
            <!--底部文件调用-->
        </div>
    </form>
</body>
</html>
