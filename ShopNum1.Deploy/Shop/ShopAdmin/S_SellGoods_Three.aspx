<%@ Page Language="C#" %>

<%@ Import Namespace="ShopNum1.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>��ϲ������Ʒ�����ɹ���</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script type="text/javascript" language="javascript" src="js/jquery.pack.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="containe_bg">
        <!--ͷ��Top-->
        <ShopNum1ShopAdmin:S_Head ID="S_Head" runat="server" SkinFilename="Skin/S_Head.ascx" />
        <!--���ݲ���Content-->
        <div id="content_bg">
            <div class="con_order">
                <!--����-->
                <div class="buzho">
                    <ul>
                        <li>
                            <img src="images/buzho01.jpg" width="317" height="51" /></li>
                        <li>
                            <img src="images/buzho02.jpg" width="388" height="51" /></li>
                        <li>
                            <img src="images/buzho03_1.jpg" width="295" height="51" /></li>
                    </ul>
                </div>
                <div class="tiscg">
                    <h1>
                        ��ϲ������Ʒ<% if (ShopNum1.Common.Common.ReqStr("op") == "edit")
                                 { %>�༭<% }
                                 else
                                 { %>����<% } %>�ɹ�!</h1>
                    <h2>
                        <%
                            bool bflag = true;
                            if (ShopSettings.GetValue("AddProductIsAudit") != "0" && ShopNum1.Common.Common.ReqStr("pstate") == "0")
                            {
                                bflag = false; %>
                        <% }
                            else if (ShopSettings.GetValue("AddPanicBuyProductIsAudit") != "0" && ShopNum1.Common.Common.ReqStr("pstate") == "1")
                            {
                                bflag = false;
                            } %>
                        <% if (bflag)
                           { %>
                           <%
                               HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                               HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                               string MemberLoginID = cookie2.Values["MemLoginID"];

                               if (MemberLoginID== ShopNum1MultiEntity.TJShopInfo.shopId)
                               { %>
                                  <a href="<%= ShopUrlOperate.shopHref(ShopNum1.Common.Common.ReqStr("pid"), ShopNum1.Common.Common.ReqStr("shopid")) %>?category=1"
                            class="blue_xq">ȥ���̲鿴��Ʒ����</a> >>&nbsp;&nbsp;
                              <% }
                              else{ %>
                              <a href="<%= ShopUrlOperate.shopHref_two(ShopNum1.Common.Common.ReqStr("pid"), ShopNum1.Common.Common.ReqStr("shopid"),9) %>"
                            class="blue_xq">ȥ���̲鿴��Ʒ����</a> >>&nbsp;&nbsp;
                             <%} %> 
                              
                             
                               
                               
                        
                        <% }
                           else
                           { %>
                        <a href="S_Index.aspx?tosurl=S_UnAuditProduct.aspx" class="blue_xq">δ�����Ʒ�б�</a>
                        >>&nbsp;&nbsp;
                        <% } %>
                        <a href="<%= Request.Url.ToString().Replace("_Three", "_two") %>" class="blue_xq">�༭��Ʒ</a>
                        >>
                    </h2>
                </div>
                <div class="tiscg2">
                    <p>
                        ��������:</p>
                    <ul>
                        <li>1.���� " <a href="S_SellGoods_One.aspx?op=add&step=one" class="blue_xq">��������Ʒ</a>"</li>
                        <li>2.���� " <a href="S_Index.aspx" class="blue_xq">��������</a>" ���� "<a href="S_Index.aspx?tosurl=S_SellProduct.aspx"
                            class="blue_xq">��Ʒ�б�</a>"</li>
                        <li>3.���� " <a href="S_Index.aspx?tosurl=S_ZtcGoods_List.aspx" class="blue_xq">ֱͨ������</a>
                            " ѡ����Ʒ�������</li>
                        <li>4.ѡ����Ʒ�μ� " <a href="S_Index.aspx?tosurl=S_GroupProduct.aspx" class="blue_xq">�Ź��</a>
                            "</li>
                        <%-- <li>5.�����̳ǵ� " <a href="S_Index.aspx" class="blue_xq" >ר��</a> "</li>--%>
                    </ul>
                </div>
            </div>
            <!--ҳ��ײ�Bottom-->
            <div style="clear: both;">
            </div>
            <!--ҳ��ײ�Bottom-->
            <ShopNum1ShopAdmin:S_Bottom ID="S_Bottom" runat="server" SkinFilename="Skin/S_Bottom.ascx"
                class="foot_bg" />
        </div>
    </div>
    </form>
</body>
</html>
