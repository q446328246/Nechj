<%@ Page Language="C#" EnableViewState="false" %>

<%@ Register Src="Skin/M_Head.ascx" TagName="M_Head" TagPrefix="uc2" %>
<%@ Register Src="Skin/M_Left.ascx" TagName="M_Left" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我是买家</title>
    <link rel='stylesheet' type='text/css' href='style/m.css' />
    <script type="text/javascript" language="javascript" src="js/jquery.pack.js"></script>
    <script type="text/javascript" language="javascript" src="js/M_Index.js"></script>
    <script type="text/javascript" language="javascript">
        //跳转到制定的页码
        var para = (document.location.search.match(new RegExp("(?:^\\?|&)" + "action" + "=(.*?)(?=&|$)")) || ['', null])[1];
        if (para != null) {
            if (para == "2") {
                alert("恭喜您成功提交申请，请等待管理员审批！");
            }
            else if (para == "1") {
                alert("恭喜您升级成功！");
            }
            else if (para == "3") {
                alert("线下支付申请提交成功！请及时汇款！");
            }
            else if (para == "4") {
                alert("恭喜您成功升级为临时区代理！");
            }
            else if (para == "5") {
                alert("您的会员等级不能使用线下充值！");
            }

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="containe_bg">
        <%--        <ShopNum1:M_Head ID="M_Head" runat="server" SkinFilename="Skin/M_Head.ascx" />--%>
        <uc2:M_Head ID="M_Head1" runat="server" />
        <!--内容部分Content-->
        <div id="content_bg">
            <div id="content1">
                <div id="content2">
                    <!--左边导航nav-->
                    <%--                    <ShopNum1:M_Left ID="M_Left" runat="server" SkinFilename="Skin/M_Left.ascx" />--%>
                    <uc3:M_Left ID="M_Left1" runat="server" />
                    <!--右边框架-->
                    <div class="ifr_right">
                        <%string strURL = string.Empty;


                          if (Page.Request.QueryString["tomurl"] != null)
                          {
                              strURL = Server.UrlDecode(Page.Request.QueryString["tomurl"].ToString());
                          }

                          else
                          {
                              strURL = "M_Welcome.aspx";
                          }
                        %>
                        <iframe width="100%" frameborder="0" height="100%" allowtransparency="true" id="mainFrame"
                            name="win" src='<%=strURL %>' scrolling="no"></iframe>
                    </div>
                </div>
            </div>
        </div>
        <!--底部文件调用-->
        <!-- #include file="m_bottom.aspx" -->
        <!--底部文件调用-->
    </div>
    </form>
</body>
</html>
