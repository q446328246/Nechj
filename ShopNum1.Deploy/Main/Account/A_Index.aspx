<%@ Page Language="C#" EnableViewState="false" %>

<%@ Register Src="Skin/A_Head.ascx" TagName="A_Head" TagPrefix="uc1" %>
<%@ Register Src="Skin/A_Left.ascx" TagName="A_Left" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>账户管理</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script language="javascript" type="text/javascript" src="js/jquery.pack.js"></script>
    <script language="javascript" type="text/javascript" src="js/A_Index.js"></script>
    <script type="text/javascript" language="javascript">
        window.onerror = function () { return true; };
    </script>
    <script src="/js/jquery-1.6.2.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="containe_bg">
        <!--头部Top-->
        <uc1:A_Head ID="A_Head1" runat="server" />
        <%--        <ShopNum1Account:A_Head ID="A_Head" runat="server" SkinFilename="Skin/A_Head.ascx" />--%>
        <!--内容部分Content-->
        <div id="content_bg">
            <div id="content1">
                <div id="content2">
                    <uc2:A_Left ID="A_Left1" runat="server" />
                    <%--                    <ShopNum1Account:A_Left ID="A_Left" runat="server" SkinFilename="Skin/A_Left.ascx" />--%>
                    <!--右边框架-->
                    <div class="ifr_right" style="width: 794px;">
                        <%string strURL = string.Empty;
                          if (Page.Request.QueryString["toaurl"] != null)
                          {
                              strURL = Server.UrlDecode(Page.Request.QueryString["toaurl"].ToString());
                          }
                          else
                          {
                              strURL = "A_PwdSer.aspx";
                          }
                        %>
                        <iframe src='<%=strURL %>' width="100%" frameborder="0" scrolling="auto" id="mainFrame"
                            name="win" onload="this.height=100%"></iframe>
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
