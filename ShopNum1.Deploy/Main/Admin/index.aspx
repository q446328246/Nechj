<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="index.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>���ʵ����̳�-��̨����ƽ̨</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script src="js/jquery-1.9.1.js" type="text/javascript"> </script>
    <script src="js/menu.js" type="text/javascript"> </script>
    <script type='text/javascript' src='js/resolution-test.js'> </script>
    <script type="text/javascript" language="javascript">
        function reinitIframe() {
            var iframe = document.getElementById("mainFrame");
            try {
                var bHeight = iframe.contentWindow.document.body.scrollHeight;
                var dHeight = iframe.contentWindow.document.documentElement.scrollHeight;
                var height = Math.max(bHeight, dHeight);
                iframe.height = height;
            } catch (ex) {
            }
        }

        window.setInterval("reinitIframe()", 10);

        function test() {

            if (!$("#left").is(":hidden")) {
                $("#left").hide();
                $("#mright").addClass('mmhide');
                $("#mright").removeClass('mmshow');
                var _div = document.getElementById("test");
                _div.innerHTML = "��ʾ�˵�";

            } else {
                $("#left").show();
                $("#mright").addClass('mmshow');
                $("#mright").removeClass('mmhide');
                var _div = document.getElementById("test");
                _div.innerHTML = "���ز˵�";
            }
        }
    </script>
    <style type="text/css">
        .mmhide {
            margin-left: 0px;
        }

        .mmshow {
            margin-left: 200px;
        }

        .mright .san {
            background: url(images/xs_.jpg) no-repeat center bottom;
            height: 10px;
            left: 4px;
            position: absolute;
            text-indent: -999em;
            top: 4px;
            width: 8px;
        }

        .mmshow .san {
            background: url(images/xs_.jpg) no-repeat center bottom;
            height: 10px;
            left: 4px;
            position: absolute;
            text-indent: -999em;
            top: 4px;
            width: 8px;
        }

        .mmhide .san {
            background: url(images/yc.jpg) no-repeat center bottom;
            height: 10px;
            left: 2px;
            position: absolute;
            text-indent: -999em;
            top: 2px;
            width: 8px;
        }
    </style>
</head>
<body style="min-width: 1024px;">
    <div class="bodywarp" value="0">
        <div class="mainbody">
            <div class="toparea clearfix">
                <%--                <div class="logoImg">
                    <img src="images/top_logo.gif" width="443" height="64" />
                </div>--%>
                <div class="topnav">
                    <a onclick=" changeIfam('AdminWelcome_List.aspx', this) ">
                        <div class="hy">
                            ��ӭҳ
                        </div>
                    </a><a onclick=" ShowNav() ">
                        <div class="xiangdao">
                            ʹ����
                        </div>
                    </a>
                    <%--<a onclick=" changeIfam('Html/AboutShopNum1.htm', this) ">
                        <div class="gy">
                            ����
                        </div>
                    </a>--%><a href="/Default.aspx" target="_blank">
                        <div class="llan">
                            ����̳�
                        </div>
                    </a>
                    <%--                    <a href="http://yizhaoshang.shopnum1.com/auth">
                        <div class="yzs">
                            ������
                        </div>
                    </a>--%>
                    <a href="LoginExit.aspx" target="_blank">
                        <div class="exit">
                            �˳���̨
                        </div>
                    </a>
                </div>
            </div>
            <!--ͷ������-->
            <div id="nav">
                <div class="c">
                    <div class="l">
                        <div class="r">
                            <ul>
                                <!--KCE��Ŀ�޸�-->
                                <li><span class="v" style="overflow: hidden;"><a id="menuTop1" class="sele" onclick=" changeTab(1, 1, this); changeIfam('RexodMemberLogo.aspx');javascript:shopnum1.Tool.LoadMask.show(); ">NEC��Ŀ����</a></span>
                                    <div class="kind_menu">
                                        <div class="kc">
                                            <%--<a onclick=" changeIfam('AAA_KCE_addZaiBei.aspx');changeTabSub(1, 1, 1, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                                ����ծ��</a>--%> <%--<a onclick=" changeIfam('AAA_KCE_addKT.aspx');changeTabSub(1, 2, 1, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                                    ����NEC����</a> --%>
                                            <a onclick=" changeIfam('RexodMemberLogo.aspx');changeTabSub(1, 1, 1, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">�Ŷ����ü�¼</a>
                                            <a onclick=" changeIfam('TeamList.aspx');changeTabSub(1, 2, 1, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">�����Ŷ�</a>

                                            <a onclick=" changeIfam('AAA_KCE_QuerySuperior.aspx');changeTabSub(1, 3, 1, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">�����Ƽ��ϼ�����</a>
                                            <a onclick=" changeIfam('ReChat.aspx');changeTabSub(1, 4, 1, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ա�Ƽ�ͼ</a>
                                            <a onclick=" changeIfam('MemberShip_List_IsBusiness.aspx');changeTabSub(1, 5, 1, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">�̼�����</a>
                                            <a onclick=" changeIfam('Payment_List.aspx', this);  changeTabSub(1, 6, 1, 99, this);javascript:shopnum1.Tool.LoadMask.show(); ">֧����ʽ</a>
                                            <a onclick=" changeIfam('LogisticsCompany_List.aspx'); changeTabSub(1, 7, 1, 99, this);javascript:shopnum1.Tool.LoadMask.show(); ">������˾</a>
                                            <a onclick=" changeIfam('ShopNum1Region_list.aspx'); changeTabSub(1, 8, 1, 99, this);javascript:shopnum1.Tool.LoadMask.show(); ">�����б�</a>
                                            <a onclick=" changeIfam('ImageCategory_List.aspx'); changeTabSub(1, 9, 1, 99, this);javascript:shopnum1.Tool.LoadMask.show(); ">ͼƬ����</a>
                                            <a onclick=" changeIfam('Third_loginList.aspx'); changeTabSub(1, 10, 1, 99, this);javascript:shopnum1.Tool.LoadMask.show(); ">ϵͳ����</a>

                                        </div>
                                    </div>
                                </li>
                                <li><span class="v" style="overflow: hidden;"><a onclick=" changeTab(2, 2, this); changeIfam('Brand_List.aspx');javascript:shopnum1.Tool.LoadMask.show(); ">��Ʒ����</a></span>
                                    <div class="kind_menu">
                                        <div class="kc">
                                            <a onclick=" changeIfam('Brand_List.aspx'); changeTabSub(2, 1, 2, 8, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ʒ��������</a> <a onclick=" changeIfam('Prouduct_List.aspx'); changeTabSub(2, 2, 2, 9, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ʒ����</a>
                                            <%--  <a onclick="changeIfam('Group_ActivityList.aspx'); changeTabSub(2,2,2,10,this);javascript:shopnum1.Tool.LoadMask.show();">��������</a>--%>
                                            <a onclick=" changeIfam('ProuductChecked_List.aspx'); changeTabSub(2, 3, 2, 10, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ʒ��Ϣ���</a>
                                        </div>
                                    </div>
                                </li>
                                <li class="toptest" style="overflow: hidden;"><span class="v"><a onclick=" changeTab(3, 3, this); changeIfam('Order_List.aspx', this); javascript:shopnum1.Tool.LoadMask.show(); ">��������</a></span>
                                    <div class="kind_menu" style="width: 1000px;">
                                        <div class="kc">
                                            <a onclick=" changeIfam('Order_List.aspx');changeTabSub(3, 1, 3, 11, this);javascript:shopnum1.Tool.LoadMask.show(); ">��������</a>


                                            <a onclick=" changeIfam('#');changeTabSub(3, 2, 3, 12, this); " style="display: none;">�˻�(��)��</a> <a onclick=" changeIfam('ComplaintsManagement_List.aspx');changeTabSub(3, 3, 3, 13, this);javascript:shopnum1.Tool.LoadMask.show(); ">�ٱ�||Ͷ��</a>
                                        </div>
                                    </div>
                                </li>
                                <li class="toptest" style="overflow: hidden;"><span class="v"><a onclick=" changeTab(4, 4, this); changeIfam('Member_List.aspx');javascript:shopnum1.Tool.LoadMask.show(); ">��Ա����</a></span>
                                    <div class="kind_menu">
                                        <div class="kc">
                                            <a onclick=" changeIfam('Member_List.aspx'); changeTabSub(4, 1, 4, 14, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ա����</a> <a onclick=" changeIfam('ReceiveMessage_List.aspx'); changeTabSub(4, 2, 4, 15, this);javascript:shopnum1.Tool.LoadMask.show(); ">վ����Ϣ</a> <a onclick=" changeIfam('ShopNum1MessageBoard_List.aspx');changeTabSub(4, 3, 4, 16, this);javascript:shopnum1.Tool.LoadMask.show(); ">�������</a>
                                        </div>
                                    </div>
                                </li>
                                <li class="toptest" style="overflow: hidden;"><span class="v"><a onclick=" changeTab(5, 5, this); changeIfam('ShopType_List.aspx');javascript:shopnum1.Tool.LoadMask.show(); ">���̹���</a></span>
                                    <div class="kind_menu" style="width: 1000px;">
                                        <div class="kc">
                                            <a onclick=" changeIfam('ShopType_List.aspx'); changeTabSub(5, 1, 5, 18, this);javascript:shopnum1.Tool.LoadMask.show(); ">���̻�������</a> <a onclick=" changeIfam('ShopInfoList_Manage.aspx'); changeTabSub(5, 2, 5, 19, this);javascript:shopnum1.Tool.LoadMask.show(); ">���̹���</a> <a onclick=" changeIfam('ShopArticle_List.aspx'); changeTabSub(5, 3, 5, 52, this);javascript:shopnum1.Tool.LoadMask.show(); ">��������</a> <a onclick=" changeIfam('ShopVedio_List.aspx'); changeTabSub(5, 4, 5, 53, this);javascript:shopnum1.Tool.LoadMask.show(); ">������Ƶ</a> <a onclick=" changeIfam('ShopDoMainChecked_List.aspx'); changeTabSub(5, 5, 5, 20, this);javascript:shopnum1.Tool.LoadMask.show(); ">������Ϣ���</a>
                                        </div>
                                    </div>
                                </li>
                                <li class="toptest" style="display: none; overflow: hidden;"><span class="v"><a onclick=" changeTab(6, 6, this);  changeIfam('Dept_List.aspx');javascript:shopnum1.Tool.LoadMask.show(); ">ϵͳ����</a></span>
                                    <div class="kind_menu" style="width: 1000px;">
                                        <div class="kc">
                                            <a onclick=" changeIfam('User_List.aspx'); changeTabSub(6, 1, 6, 21, this);javascript:shopnum1.Tool.LoadMask.show(); ">Ȩ�޹���</a> <a onclick=" changeTabSub(6, 2, 6, 22, this); changeIfam('backupDB.aspx');javascript:shopnum1.Tool.LoadMask.show(); ">���ݹ���</a> <a onclick=" changeIfam('SensitiveWordsSeting.aspx');changeTabSub(6, 3, 6, 23, this);javascript:shopnum1.Tool.LoadMask.show(); ">����������</a> <a onclick=" changeIfam('Cache/Global_CacheManage.aspx');changeTabSub(6, 4, 6, 24, this);javascript:shopnum1.Tool.LoadMask.show(); ">��վ�Ż�</a>
                                        </div>
                                    </div>
                                </li>


                                <!--young-->
                                <li class="toptest" style="display: none; overflow: hidden;"><span class="v"><a onclick=" changeTab(14,14, this);  changeIfam('userOrderReport.aspx');javascript:shopnum1.Tool.LoadMask.show(); ">���ɱ���</a></span>
                                    <div class="kind_menu" style="width: 1000px;">
                                        <div class="kc">
                                            <a onclick=" changeIfam('userOrderReport.aspx'); changeTabSub(14, 1,14, 55, this);javascript:shopnum1.Tool.LoadMask.show(); ">�������</a>
                                        </div>
                                    </div>
                                </li>


                                <li class="toptest" style="overflow: hidden;"><span class="v"><a onclick=" changeTab(7, 7, this); changeIfam('Email_List.aspx'); javascript:shopnum1.Tool.LoadMask.show(); ">Ӫ���ƹ�</a></span>
                                    <div class="kind_menu">
                                        <div class="kc">
                                            <a onclick=" changeIfam('Email_List.aspx'); changeTabSub(7, 1, 7, 26, this);javascript:shopnum1.Tool.LoadMask.show(); ">�ʼ�ϵͳ</a> <a onclick=" changeIfam('MMS_List.aspx'); changeTabSub(7, 2, 7, 27, this);javascript:shopnum1.Tool.LoadMask.show(); ">����ϵͳ</a> <a onclick=" changeIfam('SiteMota_List.aspx');changeTabSub(7, 3, 7, 28, this);javascript:shopnum1.Tool.LoadMask.show(); ">���������Ż�</a> <a onclick=" changeIfam('SetMap.aspx'); changeTabSub(7, 4, 7, 29, this);javascript:shopnum1.Tool.LoadMask.show(); ">վ���ͼ</a> <a onclick=" changeIfam('SurveyTheme_Manage.aspx'); changeTabSub(7, 5, 7, 30, this);javascript:shopnum1.Tool.LoadMask.show(); ">�����б�</a> <a onclick=" changeIfam('ArticleCategory_List.aspx'); changeTabSub(7, 6, 7, 31, this);javascript:shopnum1.Tool.LoadMask.show(); ">���¹���</a> <a onclick=" changeIfam('VideoCategory_List.aspx'); changeTabSub(7, 7, 7, 32, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ƶ����</a>
                                            <%--<a style="display: none;" onclick="changeIfam('ShopVedioComment_List.aspx'); changeTabSub(7,7,9,32,this);javascript:shopnum1.Tool.LoadMask.show();">
                                                ��Ƶ����</a> --%><a onclick=" changeIfam('AttachMent_list.aspx'); changeTabSub(7, 8, 7, 33, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                                    ��������</a> <a onclick=" changeIfam('Link_Manage.aspx'); changeTabSub(7, 9, 7, 34, this);javascript:shopnum1.Tool.LoadMask.show(); ">��������</a> <a onclick=" changeIfam('SiteSpread.aspx'); changeTabSub(7, 10, 7, 35, this);javascript:shopnum1.Tool.LoadMask.show(); ">��վ�ƹ�</a> <a onclick=" changeIfam('ShopNum1_ScoreProductCategory_List.aspx'); changeTabSub(7, 11, 7, 36, this);javascript:shopnum1.Tool.LoadMask.show(); ">����̳�</a><a onclick=" changeIfam('Group_ActivityList.aspx'); changeTabSub(7, 12, 7, 37, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                                                    ��������</a>
                                        </div>
                                    </div>
                                </li>
                                <li class="toptest" style="overflow: hidden;"><span class="v"><a onclick=" changeTab(8, 8, this); changeIfam('AdvancePaymentMemApplyLog_List.aspx');javascript:shopnum1.Tool.LoadMask.show(); ">�������</a></span>
                                    <div class="kind_menu" style="width: 1000px;">
                                        <div class="kc">
                                            <a onclick=" changeIfam('AdvancePaymentMemApplyLog_List.aspx');changeTabSub(8, 1, 8, 366, this); javascript:shopnum1.Tool.LoadMask.show(); ">��Ա��ֵ</a> <a onclick=" changeIfam('AdvancePaymentApplyLog_List.aspx'); changeTabSub(8, 2, 8, 377, this);javascript:shopnum1.Tool.LoadMask.show(); ">���ֹ���</a> <a onclick=" changeIfam('AdvancePaymentPreTransfer_List.aspx'); changeTabSub(8, 3, 8, 38, this);javascript:shopnum1.Tool.LoadMask.show(); ">ת�˹���</a>
                                            <%--<a onclick="changeIfam('#');changeTabSub(8,4,8,39,this);javascript:shopnum1.Tool.LoadMask.show();"
                                                        style="display: none;">�ս����</a>--%>
                                            <a onclick=" changeIfam('AdvancePaymentStatistics_List.aspx');changeTabSub(8, 4, 8, 39, this);javascript:shopnum1.Tool.LoadMask.show(); ">��ң�BV������</a>
                                        </div>
                                    </div>
                                </li>
                                <li class="toptest" style="overflow: hidden;"><span class="v"><a onclick=" changeTab(9, 9, this); changeIfam('ShopNum1_SupplyDemand_List.aspx');javascript:shopnum1.Tool.LoadMask.show(); ">����ϵͳ</a></span>
                                    <div class="kind_menu" style="width: 1000px;">
                                        <div class="kc">
                                            <a onclick=" changeIfam('ShopNum1_SupplyDemand_List.aspx'); changeTabSub(9, 1, 9, 40, this);javascript:shopnum1.Tool.LoadMask.show(); ">�������</a> <a onclick=" changeIfam('ShopNum1_SupplyDemandCheck_List.aspx');changeTabSub(9, 2, 9, 54, this);javascript:shopnum1.Tool.LoadMask.show(); ">�������</a>
                                        </div>
                                    </div>
                                </li>
                                <li class="toptest" style="overflow: hidden;"><span class="v"><a onclick=" changeTab(10, 10, this); changeIfam('SkinBackup.aspx');javascript:shopnum1.Tool.LoadMask.show(); ">��վװ��</a></span>
                                    <div class="kind_menu" style="width: 1000px;">
                                        <div class="kc">
                                            <a onclick=" changeIfam('SkinBackup.aspx'); changeTabSub(10, 1, 10, 42, this);javascript:shopnum1.Tool.LoadMask.show(); ">ģ�����</a> <a onclick=" changeIfam('PageAdID_List.aspx'); changeTabSub(10, 2, 10, 43, this);javascript:shopnum1.Tool.LoadMask.show(); ">������</a> <a style="display: none" onclick=" changeIfam('InfoControl_List.aspx'); changeTabSub(10, 3, 10, 44, this);javascript:shopnum1.Tool.LoadMask.show(); ">ģ�����</a> <a onclick=" changeIfam('UserDefinedColumn_List.aspx'); changeTabSub(10, 4, 10, 45, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ŀ�б�</a> <a onclick=" changeIfam('Help_List.aspx');changeTabSub(10, 5, 10, 46, this);javascript:shopnum1.Tool.LoadMask.show(); ">��������</a> <a onclick=" changeIfam('Announcement_List.aspx');changeTabSub(10, 6, 10, 47, this);javascript:shopnum1.Tool.LoadMask.show(); ">�������</a><a onclick=" changeIfam('KeyWords_Manage.aspx');changeTabSub(10, 7, 10, 100, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                                                        �ؼ��ֹ���</a><a onclick=" changeIfam('MerchantsManage.aspx');changeTabSub(10, 8, 10, 101, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                                                            ���̹���</a>
                                        </div>
                                    </div>
                                </li>
                                <li class="toptest" style="overflow: hidden;"><span class="v"><a onclick=" changeTab(11, 11, this); changeIfam('SeeBuyRate.aspx'); javascript:shopnum1.Tool.LoadMask.show(); ">��Ӫͳ��</a></span>
                                    <div class="kind_menu" style="width: 1000px;">
                                        <div class="kc">
                                            <a onclick=" changeIfam('SellOrder.aspx'); changeTabSub(11, 1, 11, 49, this);javascript:shopnum1.Tool.LoadMask.show(); ">����ͳ��</a> <a onclick=" changeIfam('ShopClickReport.aspx');changeTabSub(11, 2, 11, 50, this);javascript:shopnum1.Tool.LoadMask.show(); ">����ͳ��</a> <a onclick=" changeIfam('MemberChartArea.aspx');changeTabSub(11, 3, 11, 51, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Աͳ��</a>
                                        </div>
                                    </div>
                                </li>
                                <li class="toptest" style="overflow: hidden;"><span class="v"><a onclick=" changeTab(12, 12, this); changeIfam('websites_list.aspx');javascript:shopnum1.Tool.LoadMask.show(); ">ϵͳ��Ⱥ</a></span>
                                    <div class="kind_menu" style="width: 1000px;">
                                        <div class="kc">
                                            <a onclick=" changeIfam('websites_list.aspx');changeTabSub(12, 1, 12, 51, this);javascript:shopnum1.Tool.LoadMask.show(); ">վȺ����</a>
                                        </div>
                                    </div>
                                </li>
                                <li class="toptest" style="overflow: hidden;"><span class="v"><a onclick=" changeTab(13, 13, this);  changeIfam('User_List.aspx');javascript:shopnum1.Tool.LoadMask.show(); ">ϵͳ����</a></span>
                                    <div class="kind_menu" style="width: 1000px;">
                                        <div class="kc">
                                            <a onclick=" changeIfam('User_List.aspx'); changeTabSub(13, 1, 13, 21, this);javascript:shopnum1.Tool.LoadMask.show(); ">Ȩ�޹���</a> <a onclick=" changeTabSub(13, 2, 13, 22, this); changeIfam('backupDB.aspx');javascript:shopnum1.Tool.LoadMask.show(); ">���ݹ���</a> <a onclick=" changeIfam('SensitiveWordsSeting.aspx');changeTabSub(13, 3, 13, 23, this);javascript:shopnum1.Tool.LoadMask.show(); ">����������</a> <a onclick=" changeIfam('Cache/Global_CacheManage.aspx');changeTabSub(13, 4, 13, 24, this);javascript:shopnum1.Tool.LoadMask.show(); ">��վ�Ż�</a>
                                        </div>
                                    </div>
                                </li>

                                <!--young-->
                                <li class="toptest" style="overflow: hidden;"><span class="v"><a onclick=" changeTab(15, 15, this);  changeIfam('userOrderReport.aspx');javascript:shopnum1.Tool.LoadMask.show(); ">���ɱ���</a></span>
                                    <div class="kind_menu" style="width: 1000px;">
                                        <div class="kc">
                                            <a onclick=" changeIfam('userOrderReport.aspx'); changeTabSub(15, 1, 15, 55, this);javascript:shopnum1.Tool.LoadMask.show(); ">�������</a>
                                        </div>
                                    </div>
                                </li>


                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <div class="km">
                <div class="kr">
                    <div class="kl">
                    </div>
                </div>
            </div>
            <div class="warp clearfix">
                <!--���-->
                <div id="left">
                    <%-- <!--��վ����->--%>
                    <div class="box_left" id="box_leftid1">
                        <div class="side-bx side-first side-bx-down" id="box_leftidSub1">
                            <div class="side-bx-title" id="sideleft1" onclick=" LeftExpansion(1, 1, this) ">
                                <h3>NEC���ӻ���</h3>
                            </div>
                            <div class="side-bx-bd">
                                <ul>
                                    <%-- <li><a class="current" onclick=" changeIfam('AAA_KCE_addZaiBei.aspx');LeftSubExpansion(1, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        ����ծ��</a></li>--%>
                                    <%--<li><a onclick=" changeIfam('AAA_KCE_addKT.aspx');LeftSubExpansion(1, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        ����NEC����</a></li>--%>
                                    <%-- <li><a onclick="changeIfam('KeyWords_Manage.aspx');LeftSubExpansion(1,3,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        ������������</a></li>--%>
                                    <%--<li><a onclick=" changeIfam('SetCategoryScale.aspx');LeftSubExpansion(1, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        �����������</a></li>--%>
                                    <li><a onclick="changeIfam('Team_LeaderShip.aspx');LeftSubExpansion(1,1,this);javascript:shopnum1.Tool.LoadMask.show();">CTC�Ŷ��쵼</a></li>
                                    <li><a onclick=" changeIfam('RexodMemberLogo.aspx');LeftSubExpansion(1, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">�Ŷ����ü�¼</a></li>
                                    <li><a onclick=" changeIfam('TeamList.aspx');LeftSubExpansion(1, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">�����Ŷ�</a></li>

                                    <li><a onclick="changeIfam('AAA_KCE_QuerySuperior.aspx');LeftSubExpansion(1,4,this);javascript:shopnum1.Tool.LoadMask.show();">�����Ƽ��ϼ�����</a></li>
                                    <li><a onclick=" changeIfam('ReChat.aspx', this);LeftSubExpansion(1,5,this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ա�Ƽ�ͼ</a></li>
                                    <li><a onclick=" changeIfam('MemberShip_List_IsBusiness.aspx', this);LeftSubExpansion(1,6,this);javascript:shopnum1.Tool.LoadMask.show(); ">�̼�����</a></li>
                                </ul>
                            </div>
                        </div>
                        <%--<div class="side-bx" id="box_leftidSub2">
                            <div class="side-bx-title" id="sideleft2" onclick=" LeftExpansion(1, 2, this) ">
                                <h3>
                                    �ͷ�����</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('ServiceOnLineService_ManageShow.aspx');LeftSubExpansion(2, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        �ͷ�����</a></li>
                                    <li><a onclick=" changeIfam('ServiceOnLineService_List.aspx');LeftSubExpansion(2, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        ���߿ͷ�</a></li>
                                </ul>
                            </div>
                        </div>--%>
                        <%--<div class="side-bx" id="box_leftidSub3">
                            <div class="side-bx-title" onclick=" LeftExpansion(1, 3, this) ">
                                <h3>
                                    ֧����ʽ</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('Payment_List.aspx');LeftSubExpansion(3, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        ƽ̨֧����ʽ</a></li>
                                    <li><a class="current" onclick=" changeIfam('MobilePayment_List.aspx');LeftSubExpansion(3, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        �ֻ�֧����ʽ</a></li>
                                    <li><a class="current" onclick=" changeIfam('PaymentType_List.aspx');LeftSubExpansion(3, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        ֧������</a></li>
                                </ul>
                            </div>
                        </div>--%>
                        <%-- <div class="side-bx" id="box_leftidSub4">
                            <div class="side-bx-title" onclick=" LeftExpansion(1, 4, this) ">
                                <h3>
                                    ������˾</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('LogisticsCompany_List.aspx');LeftSubExpansion(4, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        ������˾</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub5">
                            <div class="side-bx-title" onclick=" LeftExpansion(1, 5, this) ">
                                <h3>
                                    �����б�</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('ShopNum1Region_list.aspx');;LeftSubExpansion(5, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        �����б�</a></li>
                                </ul>
                            </div>
                        </div>--%>
                        <%-- <div class="side-bx" id="box_leftidSub6">
                            <div class="side-bx-title" onclick=" LeftExpansion(1, 6, this) ">
                                <h3>
                                    ͼƬ����</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('ImageCategory_List.aspx');LeftSubExpansion(6, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        ͼƬ���� </a></li>
                                    <li><a onclick=" changeIfam('Image_List.aspx');LeftSubExpansion(6, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        ͼƬ�б�</a></li>
                                    <li><a onclick=" changeIfam('ServiceSite_ImageSettings.aspx');LeftSubExpansion(6, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        ͼƬˮӡ</a></li>
                                    <li style="display: none;"><a onclick=" changeIfam('ImageSpec_List.aspx');LeftSubExpansion(6, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        ͼƬ���</a></li>
                                </ul>
                            </div>
                        </div>--%>
                        <%--<div class="side-bx" id="box_leftidSub7">
                            <div class="side-bx-title" onclick=" LeftExpansion(1, 7, this) ">
                                <h3 onclick=" ">
                                    ϵͳ����</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('Third_loginList.aspx');LeftSubExpansion(7, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        ��������¼����</a></li>
                                    <li><a onclick=" changeIfam('Discuz_Settings.aspx');LeftSubExpansion(7, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        ����Discuz!NT</a></li>
                                    <li><a onclick=" changeIfam('UCDiscuz_Settings.aspx');LeftSubExpansion(7, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        ����UCenter</a></li>
                                    <li><a onclick=" changeIfam('Tg_Settings.aspx');LeftSubExpansion(7, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        �����Ź�ϵͳ</a></li>
                                    <li><a onclick=" changeIfam('Union_Settings.aspx');LeftSubExpansion(7, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        ��������ϵͳ</a></li>
                                    <li><a onclick=" changeIfam('TbCategory_Settings.aspx');LeftSubExpansion(7, 6, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        �Ա����ർ�����</a></li>
                                </ul>
                            </div>
                        </div>--%>
                    </div>
                    <%-- <!--��Ʒ����->--%>
                    <div class="box_left" id="box_leftid2" style="display: none">
                        <div class="side-bx side-first" id="box_leftidSub8">
                            <div class="side-bx-title" onclick=" LeftExpansion(2, 1, this) ">
                                <h3>��Ʒ��������</h3>
                            </div>
                            <div class="side-bx-bd">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('Brand_List.aspx');LeftSubExpansion(8, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">��ƷƷ��</a></li>
                                    <li><a onclick=" changeIfam('Specification_List.aspx');LeftSubExpansion(8, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">������</a></li>
                                    <li><a onclick=" changeIfam('TbCIDSpecification.aspx');LeftSubExpansion(8, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">�Ա������</a></li>
                                    <li><a onclick=" changeIfam('ShopNum1_ShopProductProp_List.aspx');LeftSubExpansion(8, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">���Թ���</a></li>
                                    <li><a onclick=" changeIfam('ShopNum1_ProductCategory_List.aspx');LeftSubExpansion(8, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ʒ����</a></li>
                                    <li><a onclick=" changeIfam('CategoryType.aspx');LeftSubExpansion(8, 6, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ʒ����</a></li>
                                    <%--<li><a onclick="changeIfam('SetCategoryScale.aspx');LeftSubExpansion(8,6,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        �������</a></li>--%>
                                    <%--      <li><a onclick="changeIfam('ShopNum1_ScoreProductCategory_List.aspx');LeftSubExpansion(8,7,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        �����Ʒ����</a></li>--%>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub9">
                            <div class="side-bx-title" id="sideleft9" onclick=" LeftExpansion(2, 2, this) ">
                                <h3>��Ʒ����</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('Prouduct_List.aspx');LeftSubExpansion(9, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ʒ�б�</a></li>
                                    <li><a onclick=" changeIfam('ProuductPanicBuy_List.aspx');LeftSubExpansion(9, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">������Ʒ�б�</a></li>
                                    <%--     <li><a onclick="changeIfam('ProuductSpellBuy_List.aspx');LeftSubExpansion(9,3,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        �Ź���Ʒ�б�</a></li>
                                    --%>
                                    <li><a onclick=" changeIfam('ShopProductComment_List.aspx');LeftSubExpansion(9, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ʒ�����б�</a></li>
                                    <li><a onclick=" changeIfam('BTCRecommend.aspx');LeftSubExpansion(9, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">��ҳ�Ƽ�BTC��Ʒ</a></li>
                                    <%-- <li><a onclick="changeIfam('ProductIntegral_List.aspx');LeftSubExpansion(10,6,this);javascript:shopnum1.Tool.LoadMask.show();">�����Ʒ</a></li>--%>
                                </ul>
                            </div>
                        </div>
                        <%-- <div class="side-bx"  id="box_leftidSub10">
                            <div class="side-bx-title" id="sideleft10" onclick="LeftExpansion(2,3,this)">
                                <h3>��������</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick="changeIfam('Group_ActivityList.aspx');LeftSubExpansion(10,1,this);javascript:shopnum1.Tool.LoadMask.show();">�Ź��</a></li>
                                    <li><a class="current" onclick="changeIfam('Limit_ActivityList.aspx');LeftSubExpansion(10,2,this);javascript:shopnum1.Tool.LoadMask.show();">��ʱ�ۿ�</a></li>
                                </ul>
                            </div>
                        </div>--%>
                        <div class="side-bx" id="box_leftidSub10">
                            <div class="side-bx-title" id="sideleft10" onclick=" LeftExpansion(2, 3, this) ">
                                <h3>��Ʒ��Ϣ���</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('ProuductChecked_List.aspx');LeftSubExpansion(10, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ʒ��Ϣ���</a></li>
                                    <li><a class="current" onclick=" changeIfam('Prouduct_PanicChecked_List.aspx');LeftSubExpansion(10, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">������Ϣ���</a></li>
                                    <%-- <li><a class="current" onclick="changeIfam('Prouduct_SpellChecked_List.aspx');LeftSubExpansion(11,3,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        �Ź���Ϣ���</a></li>--%>
                                    <%--                                    <li><a class="current" onclick="changeIfam('ProductIntegralChecked_List.aspx');LeftSubExpansion(10,4,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        �����Ϣ���</a></li>--%>
                                    <li><a onclick=" changeIfam('ShopProductCommentAudit_List.aspx');LeftSubExpansion(10, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ʒ�������</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <%--          <!--��������->--%>
                    <div class="box_left" id="box_leftid3" style="display: none">
                        <div class="side-bx side-first" id="box_leftidSub11">
                            <div class="side-bx-title" onclick=" LeftExpansion(4, 1, this) ">
                                <h3>��������</h3>
                            </div>
                            <div class="side-bx-bd">
                                <ul>
                                    <li><a onclick=" changeIfam('Order_List.aspx', this); LeftSubExpansion(11, 7, this);javascript:shopnum1.Tool.LoadMask.show(); ">�����б�</a></li>

                                    <li><a onclick=" changeIfam('CTCOrder_List.aspx', this); LeftSubExpansion(11, 8, this);javascript:shopnum1.Tool.LoadMask.show(); ">CTC������ϸ</a></li>
                                    <li><a onclick=" changeIfam('LifeOrder_List.aspx', this); LeftSubExpansion(11, 9, this);javascript:shopnum1.Tool.LoadMask.show(); ">������񶩵��б�</a></li>
                                    <li><a onclick=" changeIfam('Order_Refuse.aspx', this); LeftSubExpansion(11, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">��A���ܾ��Ķ������</a></li>
                                    <li><a onclick=" changeIfam('Order_Refund_two.aspx', this); LeftSubExpansion(11, 6, this);javascript:shopnum1.Tool.LoadMask.show(); ">�����˿���б�</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub12" style="display: none;">
                            <div class="side-bx-title" onclick=" LeftExpansion(3, 2, this) ">
                                <h3>�˻�(��)��</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('#'); LeftSubExpansion(12, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">�˻�(��)��</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub13">
                            <div class="side-bx-title" onclick=" LeftExpansion(3, 3, this); ">
                                <h3>�ٱ�||Ͷ��</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('ComplaintsManagement_List.aspx', this); LeftSubExpansion(13, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">�ٱ�����</a></li>
                                    <li><a onclick=" changeIfam('OrdeComplaints_List.aspx', this); LeftSubExpansion(13, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">Ͷ�߹���</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <%--  <!--��Ա����->--%>
                    <div class="box_left" id="box_leftid4" style="display: none">
                        <div class="side-bx side-first" id="box_leftidSub14">
                            <div class="side-bx-title" onclick=" LeftExpansion(4, 1, this) ">
                                <h3>��Ա����</h3>

                            </div>
                            <div class="side-bx-bd">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('Member_List.aspx', this);LeftSubExpansion(14, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ա�б�</a></li>
                                    <li><a onclick=" changeIfam('MemberRank_List.aspx', this);LeftSubExpansion(14, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ա�ȼ�</a></li>
                                    <li><a onclick=" changeIfam('ShopUserRecommend.aspx', this);LeftSubExpansion(14, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ա����</a></li>
                                    <li><a class="current" onclick=" changeIfam('MemberShip_List.aspx', this); LeftSubExpansion(14, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">�����������б� </a></li>
                                    <li><a class="current" onclick=" changeIfam('ChangeScoreLog_List.aspx', this); LeftSubExpansion(14, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">���Ѻ��������־ </a></li>
                                    <li><a class="current" onclick=" changeIfam('ChangeRankScoreLog_List.aspx', this); LeftSubExpansion(14, 6, this);javascript:shopnum1.Tool.LoadMask.show(); ">�ȼ����������־ </a></li>
                                    <li><a class="current" onclick=" changeIfam('MemberRank_LinkCategory.aspx', this); LeftSubExpansion(14, 7, this);javascript:shopnum1.Tool.LoadMask.show(); ">ר����</a></li>
                                    <li><a class="current" onclick=" changeIfam('UpdateCommunity.aspx', this); LeftSubExpansion(14, 8, this);javascript:shopnum1.Tool.LoadMask.show(); ">��������������</a></li>
                                    <li><a class="current" onclick=" changeIfam('AddMemberLoginID.aspx', this); LeftSubExpansion(14, 9, this);javascript:shopnum1.Tool.LoadMask.show(); ">��ע��</a></li>
                                    <li><a class="current" onclick=" changeIfam('AZhuanB_Dv.aspx', this); LeftSubExpansion(14, 10, this);javascript:shopnum1.Tool.LoadMask.show(); ">A�ͻ�תB�ͻ���DV��</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub15">
                            <div class="side-bx-title" onclick=" LeftExpansion(4, 2, this) ">
                                <h3>վ����Ϣ</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <%--<li><a class="current" onclick="changeIfam('ReceiveMessage_List.aspx',this);LeftSubExpansion(15,1,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        ��Ϣ�ռ���</a></li>--%>
                                    <li><a onclick=" changeIfam('SendMessage_List.aspx', this);LeftSubExpansion(15, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ϣ������</a></li>
                                    <li><a onclick=" changeIfam('Message_Operate.aspx', this);LeftSubExpansion(15, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">������Ϣ</a></li>
                                </ul>
                            </div>
                        </div>
                        <%--   <div class="side-bx side-bx-down">--%>
                        <div class="side-bx" id="box_leftidSub16">
                            <div class="side-bx-title" onclick=" LeftExpansion(4, 3, this) ">
                                <h3>�������</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('ShopNum1MessageBoard_List.aspx'); LeftSubExpansion(16, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">�������</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <%--    <!--���̹���->--%>
                    <div class="box_left" id="box_leftid5" style="display: none">
                        <div class="side-bx side-first" id="box_leftidSub18">
                            <div class="side-bx-title" onclick=" LeftExpansion(5, 1, this); ">
                                <h3>���̻�������</h3>
                            </div>
                            <div class="side-bx-bd">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('ShopType_List.aspx');LeftSubExpansion(18, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">���̷���</a></li>
                                    <li><a onclick=" changeIfam('ShopRank_List.aspx'); LeftSubExpansion(18, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">���̵ȼ��б�</a></li>
                                    <li><a onclick=" changeIfam('ShopTemplate_List.aspx'); LeftSubExpansion(18, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">����ģ���б�</a></li>
                                    <!-- <li><a onclick=" changeIfam('CouponType_List.aspx');LeftSubExpansion(18, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">
                                        �Ż�ȯ����</a></li>-->
                                    <li><a onclick=" changeIfam('ShopReputation_List.aspx');LeftSubExpansion(18, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">���������б�</a></li>
                                    <li><a onclick=" changeIfam('ShopEnsure_List.aspx'); LeftSubExpansion(18, 6, this);javascript:shopnum1.Tool.LoadMask.show(); ">���̵����б�</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub19">
                            <div class="side-bx-title" onclick=" LeftExpansion(5, 2, this); ">
                                <h3>���̹���</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('ShopInfoList_Manage.aspx'); LeftSubExpansion(19, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">�����б�</a></li>
                                    <li><a onclick=" changeIfam('ShopEnsureVerify_List.aspx'); LeftSubExpansion(19, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">�����뵣���б�</a></li>
                                    <%--<li><a onclick="changeIfam('ShopTemplate_List.aspx',this); LeftSubExpansion(19,2,this);">
                                        ����ģ���б�</a></li>
                                    <li><a onclick="changeIfam('ShopEnsureVerify_List.aspx'); LeftSubExpansion(19,3,this);">
                                        ���̵����б�</a></li>--%>
                                    <li><a onclick=" changeIfam('ShopDoMain_List.aspx'); LeftSubExpansion(19, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">���������б�</a></li>
                                    <li><a onclick=" changeIfam('CouponList.aspx'); LeftSubExpansion(19, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">�����Ż�ȯ�б�</a></li>
                                    <li><a onclick=" changeIfam('Shop_ImgManage.aspx'); LeftSubExpansion(19, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">����ͼ���б�</a></li>
                                    <li style="display: none;"><a class="current" onclick=" changeIfam('DelayWxShop_V82.aspx'); LeftSubExpansion(19, 6, this);javascript:shopnum1.Tool.LoadMask.show(); ">����΢�ŵ���</a></li>
                                    <%-- <li><a onclick="changeIfam('ShopVedio_List.aspx',this); LeftSubExpansion(19,6,this);">
                                        ������Ƶ�б�</a></li>
                                    <li><a onclick="changeIfam('ShopArticle_List.aspx',this); LeftSubExpansion(19,7,this);">
                                        ���������б�</a></li>--%>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub52">
                            <div class="side-bx-title" onclick=" LeftExpansion(5, 3, this); ">
                                <h3>��������</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('ShopArticle_List.aspx'); LeftSubExpansion(52, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">���������б�</a></li>
                                    <li><a class="current" onclick=" changeIfam('ShopArticleComment_List.aspx'); LeftSubExpansion(52, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">�������������б�</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub53">
                            <div class="side-bx-title" onclick=" LeftExpansion(5, 4, this); ">
                                <h3>������Ƶ</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('ShopVedio_List.aspx'); LeftSubExpansion(53, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">������Ƶ�б�</a></li>
                                    <li><a onclick=" changeIfam('ShopVedioComment_List.aspx'); LeftSubExpansion(53, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">������Ƶ�����б�</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub20">
                            <div class="side-bx-title" onclick=" LeftExpansion(5, 5, this); ">
                                <h3>������Ϣ���</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <%--          <li style="display: none;"><a class="current" onclick="changeIfam('ShopInfoList_Audit.aspx',this);  LeftSubExpansion(20,1,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        ����ʵ������б�</a></li>--%>
                                    <li><a class="current" onclick=" changeIfam('ShopDoMainChecked_List.aspx', this);  LeftSubExpansion(20, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">������������б�</a></li>
                                    <li><a onclick=" changeIfam('ShopInfoList_Audit.aspx', this);  LeftSubExpansion(20, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">��������б�</a></li>
                                    <li><a onclick=" changeIfam('ShopInfoList_AuditNo.aspx', this);  LeftSubExpansion(20, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">�������δͨ���б�</a></li>
                                    <%--<li><a onclick="changeIfam('ShopApplyRankChecked_List.aspx',this);  LeftSubExpansion(20,4,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        ���̵ȼ�����б�</a></li>
                                    <li><a onclick="changeIfam('ShopEnsureVerifyChecked_List.aspx',this);  LeftSubExpansion(20,5,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        ���̵�������б�</a></li>--%>
                                    <li><a onclick=" changeIfam('ShopArticle_Check.aspx', this);  LeftSubExpansion(20, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">������������б�</a></li>
                                    <li><a onclick=" changeIfam('CouponList_Audit.aspx', this);  LeftSubExpansion(20, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">�����Ż�ȯ����б�</a></li>
                                    <%--  <li><a onclick="changeIfam('ShopCategoryAply_Audit.aspx',this);  LeftSubExpansion(20,8,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        ���������������б�</a></li>--%>
                                    <li><a onclick=" changeIfam('ShopArticleCommentAudit_List.aspx'); LeftSubExpansion(20, 6, this);javascript:shopnum1.Tool.LoadMask.show(); ">���������������</a></li>
                                    <li><a onclick=" changeIfam('ShopVedioChecked_List.aspx'); LeftSubExpansion(20, 7, this);javascript:shopnum1.Tool.LoadMask.show(); ">������Ƶ���</a></li>
                                    <li><a onclick=" changeIfam('ShopVedioCommentChecked_List.aspx'); LeftSubExpansion(20, 8, this);javascript:shopnum1.Tool.LoadMask.show(); ">������Ƶ�������</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <%-- --Ӫ���ƹ�---%>
                    <div class="box_left" id="box_leftid7" style="display: none">
                        <div class="side-bx side-first" id="box_leftidSub26">
                            <div class="side-bx-title" onclick=" LeftExpansion(7, 1, this); ">
                                <h3>�ʼ�ϵͳ</h3>
                            </div>
                            <div class="side-bx-bd">
                                <ul>
                                    <%--                                    <li style="display:none"><a onclick="changeIfam('EmailBookType_List.aspx'); LeftSubExpansion(26,1,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        �ʼ���������</a></li>
                                    <li style="display:none"><a onclick="changeIfam('EmailBook_List.aspx'); LeftSubExpansion(26,2,this);javascript:shopnum1.Tool.LoadMask.show();">�ʼ�����</a></li>
                                    <li style="display:none"><a onclick="changeIfam('EmailType_List.aspx'); LeftSubExpansion(26,3,this);javascript:shopnum1.Tool.LoadMask.show();">�ʼ�����</a></li>--%>
                                    <li><a class="current" onclick=" changeIfam('Email_List.aspx'); LeftSubExpansion(26, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">�ʼ�ģ��</a></li>
                                    <li><a onclick=" changeIfam('ServiceSite_EmailSetting.aspx'); LeftSubExpansion(26, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">�ʼ��ӿ�����</a></li>
                                    <li><a onclick=" changeIfam('EmailMemberGroup_List.aspx'); LeftSubExpansion(27, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ա�����</a></li>
                                    <li><a onclick=" changeIfam('EmailGropSend_Operate.aspx'); LeftSubExpansion(26, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">�ʼ�Ⱥ��</a></li>
                                    <li><a onclick=" changeIfam('EmailGroupSend_List.aspx'); LeftSubExpansion(26, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">�ʼ�������ʷ</a></li>
                                    <li><a onclick=" changeIfam('Service_EmailSendSetting.aspx'); LeftSubExpansion(26, 6, this);javascript:shopnum1.Tool.LoadMask.show(); ">�ʼ���������</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub27">
                            <div class="side-bx-title" onclick=" LeftExpansion(7, 2, this); ">
                                <h3>����ϵͳ</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <%--                                    <li style="display:none"><a  onclick="changeIfam('MMSType_List.aspx'); LeftSubExpansion(27,1,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        ���ŷ����б�</a></li>--%>
                                    <li><a class="current" onclick=" changeIfam('MMS_List.aspx'); LeftSubExpansion(27, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">����ģ��</a></li>
                                    <li><a onclick=" changeIfam('MMSMemberGroup_List.aspx'); LeftSubExpansion(27, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ա�����</a></li>
                                    <li><a onclick=" changeIfam('MMSGroupSend_Operate.aspx'); LeftSubExpansion(27, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">����Ⱥ��</a></li>
                                    <li><a onclick=" changeIfam('MMSGroupSend_List.aspx'); LeftSubExpansion(27, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">���ŷ�����ʷ</a></li>
                                    <li><a onclick=" changeIfam('MMSInterface_Operate.aspx'); LeftSubExpansion(27, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">���Žӿ�����</a></li>
                                    <li><a onclick=" changeIfam('Service_MMSSendSetting.aspx'); LeftSubExpansion(27, 6, this);javascript:shopnum1.Tool.LoadMask.show(); ">���ŷ�������</a></li>
                                </ul>
                            </div>
                        </div>
                        <%--   <div class="side-bx side-bx-down">--%>
                        <div class="side-bx" id="box_leftidSub28">
                            <div class="side-bx-title" onclick=" LeftExpansion(7, 3, this); ">
                                <h3>���������Ż�</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('SiteMota_List.aspx', this); LeftSubExpansion(28, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">SEO����</a></li>
                                </ul>
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('Robots_List.aspx', this); LeftSubExpansion(28, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">Robots����</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub29">
                            <div class="side-bx-title" onclick=" LeftExpansion(7, 4, this); ">
                                <h3>վ���ͼ</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('SetMap.aspx', this); LeftSubExpansion(29, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">վ���ͼ</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub30">
                            <div class="side-bx-title" onclick=" LeftExpansion(7, 5, this); ">
                                <h3>�����б�</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('SurveyTheme_Manage.aspx', this); LeftSubExpansion(30, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">�����б�</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub31">
                            <div class="side-bx-title" onclick=" LeftExpansion(7, 6, this); ">
                                <h3>���¹���</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('ArticleCategory_List.aspx', this); LeftSubExpansion(31, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">ƽ̨���·���</a></li>
                                    <li><a onclick=" changeIfam('Article_List.aspx', this); LeftSubExpansion(31, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">ƽ̨�����б�</a></li>
                                    <li><a onclick=" changeIfam('ArticleComment_List.aspx', this); LeftSubExpansion(33, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">ƽ̨���������б�</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub32">
                            <div class="side-bx-title" onclick=" LeftExpansion(7, 7, this); ">
                                <h3>��Ƶ����</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <%--<li><a class="current" onclick="changeIfam('ShopVedio_List.aspx',this); LeftSubExpansion(32,1,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        ǰ̨����</a></li>
                                    <li><a class="current" onclick="changeIfam('ShopVedio_List.aspx',this); LeftSubExpansion(32,1,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        ǰ̨��Ƶ�б�</a></li>
                                    <li><a onclick="changeIfam('ShopVedioComment_List.aspx',this); LeftSubExpansion(32,2,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        ǰ̨��Ƶ����</a></li>--%>
                                    <li><a class="current" onclick=" changeIfam('VideoCategory_List.aspx'); LeftSubExpansion(53, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ƶ����</a></li>
                                    <li><a class="current" onclick=" changeIfam('Video_List.aspx'); LeftSubExpansion(53, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ƶ�б�</a></li>
                                    <li><a onclick=" changeIfam('VideoComment_List.aspx'); LeftSubExpansion(53, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ƶ�����б�</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub33">
                            <div class="side-bx-title" onclick=" LeftExpansion(7, 8, this); ">
                                <h3>��������</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a onclick=" changeIfam('AttachMent_list.aspx'); LeftSubExpansion(33, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">�����б�</a></li>
                                    <li><a class="current" onclick=" changeIfam('AttachMentCateGory_List.aspx'); LeftSubExpansion(33, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">��������</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub34">
                            <div class="side-bx-title" onclick=" LeftExpansion(7, 9, this); ">
                                <h3>��������</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('Link_Manage.aspx', this); LeftSubExpansion(34, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">��������</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub35">
                            <div class="side-bx-title" onclick=" LeftExpansion(7, 10, this); ">
                                <h3>��վ�ƹ�</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('SiteSpread.aspx'); LeftSubExpansion(35, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">��վ�ƹ�</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub36">
                            <div class="side-bx-title" onclick=" LeftExpansion(7, 11, this); ">
                                <h3>����̳�</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('ShopNum1_ScoreProductCategory_List.aspx'); LeftSubExpansion(36, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">�����Ʒ����</a></li>
                                    <li><a class="current" onclick=" changeIfam('ProductIntegral_List.aspx'); LeftSubExpansion(36, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">�����Ʒ�б�</a></li>
                                    <li><a onclick=" changeIfam('OrderScore_List.aspx', this); LeftSubExpansion(36, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">��������б�</a></li>
                                    <li><a onclick=" changeIfam('ProductIntegralChecked_List.aspx');LeftSubExpansion(36, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">�����Ʒ���</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub37">
                            <div class="side-bx-title" onclick=" LeftExpansion(7, 12, this); ">
                                <h3>�����</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('Group_ActivityList.aspx');LeftSubExpansion(37, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">�Ź��</a></li>
                                    <li><a class="current" onclick=" changeIfam('Limit_ActivityList.aspx');LeftSubExpansion(37, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">������ʱ�ۿ�</a></li>
                                    <li><a onclick=" changeIfam('Theme_ActivityList.aspx');LeftSubExpansion(37, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">����</a></li>
                                    <li><a onclick=" changeIfam('ZtcGoods_List.aspx');LeftSubExpansion(37, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">ֱͨ����Ʒ�б�</a></li>
                                    <li><a onclick=" changeIfam('ShopZtcApplyAudit_List.aspx');LeftSubExpansion(37, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">ֱͨ�����</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <%----�������--%>
                    <div class="box_left" id="box_leftid8" style="display: none">
                        <div class="side-bx side-first" id="box_leftidSub366">
                            <div class="side-bx-title" onclick=" LeftExpansion(8, 1, this); ">
                                <h3>��Ա��ֵ</h3>
                            </div>
                            <div class="side-bx-bd">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('AdvancePaymentMemApplyLog_List.aspx'); LeftSubExpansion(366, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ա��ֵ</a></li>
                                    <li><a class="current" onclick=" changeIfam('AdvancePaymentApplyLog_ListETH_Cz.aspx'); LeftSubExpansion(367, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">��ԱETH��ֵ</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub377">
                            <div class="side-bx-title" onclick=" LeftExpansion(8, 2, this); ">
                                <h3>���ֹ���</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('AdvancePaymentApplyLog_List.aspx', this); LeftSubExpansion(377, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">����ETH�ҹ���</a></li>
                                    <li><a class="current" onclick=" changeIfam('AAA_KCE_addCaiWuTx.aspx', this); LeftSubExpansion(378, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">����ETH������</a></li>
                                    <li><a class="current" onclick=" changeIfam('AAA_KCE_AdvancePaymentApplyLog_ListNEC.aspx', this); LeftSubExpansion(379, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">����NEC�ҹ���</a></li>
                                    <li><a class="current" onclick=" changeIfam('AAA_KCE_addCaiWuTxNEC.aspx', this); LeftSubExpansion(380, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">����NEC������</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub38">
                            <div class="side-bx-title" onclick=" LeftExpansion(8, 3, this); ">
                                <h3>ת�˹���</h3>
                            </div>
                            <div class="side-bx-bd">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('AdvancePaymentPreTransfer_List.aspx', this); LeftSubExpansion(38, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Աת���б�</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub39">
                            <div class="side-bx-title" onclick=" LeftExpansion(8, 4, this) ">
                                <h3>�˻�����</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('AdvancePaymentStatistics_List.aspx', this); LeftSubExpansion(39, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">�һ��PV��ͳ���б� </a></li>
                                    <li><a class="current" onclick=" changeIfam('ChangeAdvancePaymentLog_List.aspx', this); LeftSubExpansion(39, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">��NEC���֣������־ </a></li>
                                    <li><a class="current" onclick=" changeIfam('FreezeAdvancePaymentLog_List.aspx', this); LeftSubExpansion(39, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">��NEC���֣���/����־</a></li>
                                    <li id="a_Select_Money_All" runat="server" style="display: none;"><a class="current" onclick=" changeIfam('Select_Money_All.aspx', this); LeftSubExpansion(39, 8, this);javascript:shopnum1.Tool.LoadMask.show(); ">adminÿ���ʽ�ͳ��</a></li>
                                    <li id="a_NewBlackList" runat="server" style="display: none;"><a class="current" onclick=" changeIfam('NewBlackList.aspx', this); LeftSubExpansion(39, 10, this);javascript:shopnum1.Tool.LoadMask.show();">����������</a></li>
                                    <li id="a_NewSelect_Money_All" runat="server"><a class="current" onclick=" changeIfam('NewSelect_Money_All.aspx', this);LeftSubExpansion(39, 11, this);javascript:shopnum1.Tool.LoadMask.show(); ">ÿ���ʽ�ͳ��</a></li>
                                </ul>
                            </div>
                        </div>

                        <div class="side-bx" id="Div1">
                            <div class="side-bx-title" onclick=" LeftExpansion(8, 5, this) ">
                                <h3>�������(DV)</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('AdvanceSettlementApplyLog.aspx', this); LeftSubExpansion(39, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">�������(DV) </a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <!--����ϵͳ-->
                    <div class="box_left" id="box_leftid9" style="display: none">
                        <div class="side-bx side-first" id="box_leftidSub40">
                            <div class="side-bx-title" onclick=" LeftExpansion(9, 1, this) ">
                                <h3>�������</h3>
                            </div>
                            <div class="side-bx-bd">
                                <ul>
                                    <li><a onclick=" changeIfam('ShopNum1_SupplyDemand_List.aspx'); LeftSubExpansion(40, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">������Ϣ</a></li>
                                    <li><a onclick=" changeIfam('ShopNum1_SupplyDemandCategory_List.aspx'); LeftSubExpansion(40, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">�������</a></li>
                                    <li><a onclick=" changeIfam('SupplyDemandComment_List.aspx'); LeftSubExpansion(40, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">���������б�</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx side-first" id="box_leftidSub54">
                            <div class="side-bx-title" onclick=" LeftExpansion(9, 2, this) ">
                                <h3>�������</h3>
                            </div>
                            <div class="side-bx-bd">
                                <ul>
                                    <li><a onclick=" changeIfam('ShopNum1_SupplyDemandCheck_List.aspx'); LeftSubExpansion(54, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">������Ϣ���</a></li>
                                    <li><a onclick=" changeIfam('SupplyDemandCommentAudit_List.aspx'); LeftSubExpansion(54, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">�����������</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <!--��վװ��-->
                    <div class="box_left" id="box_leftid10" style="display: none">
                        <div class="side-bx side-first" id="box_leftidSub42">
                            <div class="side-bx-title" onclick=" LeftExpansion(10, 1, this) ">
                                <h3>ģ�����</h3>
                            </div>
                            <div class="side-bx-bd">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('SkinBackup.aspx', this);  LeftSubExpansion(42, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">ģ�屸��</a></li>
                                    <li><a onclick=" changeIfam('SkinSelect.aspx', this);  LeftSubExpansion(42, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">ģ��ѡ��</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub43">
                            <div class="side-bx-title" onclick=" LeftExpansion(10, 2, this) ">
                                <h3>������</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <%--<li><a class="current" onclick="changeIfam('CategoryAdID_List.aspx',this);  LeftSubExpansion(43,1,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        ������λ�б�</a></li>--%>
                                    <%-- <li><a onclick="changeIfam('CategoryAdvertisement_List.aspx',this);  LeftSubExpansion(43,2,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        �������б�</a></li>
                                    <li><a onclick="changeIfam('CategoryAdBuy_List.aspx',this);  LeftSubExpansion(43,3,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        ��Ա�������б�</a></li>
                                    <li><a onclick="changeIfam('PageInfo_List.aspx',this);  LeftSubExpansion(43,4,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        �ֶ����ɹ��λ�б�</a></li>--%>
                                    <li><a onclick=" changeIfam('PageAdID_List.aspx', this);  LeftSubExpansion(43, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">���λ�б�</a></li>
                                    <li><a onclick=" changeIfam('Advertisement_List.aspx', this);  LeftSubExpansion(43, 7, this);javascript:shopnum1.Tool.LoadMask.show(); ">����б�</a></li>
                                    <li><a onclick=" changeIfam('AdvertisementImg_List.aspx', this);  LeftSubExpansion(43, 6, this);javascript:shopnum1.Tool.LoadMask.show(); ">ͼƬ����б�</a></li>
                                    <%--<li><a onclick="changeIfam('DefaultAd_List.aspx',this);  LeftSubExpansion(43,8,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        ��ҳ�õ�Ƭ</a></li>--%>
                                </ul>
                            </div>
                        </div>
                        <%--   <div class="side-bx side-bx-down">--%>
                        <div class="side-bx" id="box_leftidSub44" style="display: none;">
                            <div class="side-bx-title" onclick=" LeftExpansion(10, 3, this) ">
                                <h3>ģ�����</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('InfoControl_List.aspx', this);  LeftSubExpansion(44, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">ģ���б�</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub45">
                            <div class="side-bx-title" onclick=" LeftExpansion(10, 4, this) ">
                                <h3>��Ŀ�б�</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('UserDefinedColumn_List.aspx');  LeftSubExpansion(45, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ŀ�б�</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub46">
                            <div class="side-bx-title" onclick=" LeftExpansion(10, 5, this) ">
                                <h3>��������</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('Help_List.aspx', this);  LeftSubExpansion(46, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">�����б�</a></li>
                                    <li><a onclick=" changeIfam('HelpType_List.aspx', this);  LeftSubExpansion(46, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">��������</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub47">
                            <div class="side-bx-title" onclick=" LeftExpansion(10, 6, this) ">
                                <h3>�������</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('Announcement_List.aspx', this);  LeftSubExpansion(47, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">�����б�</a></li>
                                    <li><a onclick=" changeIfam('AnnouncementCategory_List.aspx', this);  LeftSubExpansion(47, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">�������</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub100">
                            <div class="side-bx-title" onclick=" LeftExpansion(10, 7, this) ">
                                <h3>�ؼ��ֹ���</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a onclick=" changeIfam('KeyWords_Manage.aspx');LeftSubExpansion(100, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">�ؼ����б�</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub101">
                            <div class="side-bx-title" onclick=" LeftExpansion(10, 8, this) ">
                                <h3>���̹���</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('MerchantsManage.aspx', this);  LeftSubExpansion(101, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">���̹���</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <%--  <!--��Ӫͳ��->--%>
                    <div class="box_left" id="box_leftid11" style="display: none">
                        <%-- <div class="side-bx side-first" id="box_leftidSub48" style="display: none">
                            <div class="side-bx-title" onclick="LeftExpansion(11,1,this)" style="display: none">
                                <h3>
                                    ����ͳ��</h3>
                            </div>
                            <div class="side-bx-bd">
                                <ul>
                                   ���̷���������
                                    <li><a class="current" onclick="changeIfam('ShopClickReport.aspx');  LeftSubExpansion(48,1,this);javascript:shopnum1.Tool.LoadMask.show();"
                                        style="display: none">����ͳ��</a></li>
                                </ul>
                            </div>
                        </div>--%>
                        <div class="side-bx" id="box_leftidSub49">
                            <div class="side-bx-title" onclick=" LeftExpansion(11, 1, this) ">
                                <h3>����ͳ��</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('SeeBuyRate.aspx', this);  LeftSubExpansion(49, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">���ʹ����ʱ���</a></li>
                                    <li><a onclick=" changeIfam('SellOrder.aspx', this);  LeftSubExpansion(49, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ʒ�������б���</a></li>
                                    <li><a onclick=" changeIfam('OrderProductReport.aspx', this);  LeftSubExpansion(49, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ʒ������ϸ����</a></li>
                                    <li><a onclick=" changeIfam('PaymentStatistics_List.aspx', this);  LeftSubExpansion(49, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">֧����ʽͳ�Ʊ���</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub50">
                            <div class="side-bx-title" onclick=" LeftExpansion(11, 2, this) ">
                                <h3>����ͳ��</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('ShopClickReport.aspx', this);  LeftSubExpansion(50, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">���̷������б���</a></li>
                                    <li><a onclick=" changeIfam('ShopChartArea.aspx', this);  LeftSubExpansion(50, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">��������ֲ�</a></li>
                                    <li><a onclick=" changeIfam('ShopSales.aspx', this);  LeftSubExpansion(50, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">�������۶�ͳ��</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub51">
                            <div class="side-bx-title" onclick=" LeftExpansion(11, 3, this) ">
                                <h3>��Աͳ��</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('MemberChartArea.aspx', this);  LeftSubExpansion(51, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ա����ֲ�ͼ</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <%--  ϵͳ����--%>
                    <div class="box_left" id="box_leftid13" style="display: none">
                        <div class="side-bx side-first" id="box_leftidSub21">
                            <div class="side-bx-title" onclick=" LeftExpansion(13, 1, this); ">
                                <h3>Ȩ�޹���</h3>
                            </div>
                            <div class="side-bx-bd">
                                <ul>
                                    <%--       <li style="display:none"><a class="current" onclick="changeIfam('Dept_List.aspx');  LeftSubExpansion(21,1,this);javascript:shopnum1.Tool.LoadMask.show();">
                                        �����б�</a></li>--%>
                                    <li><a class="current" onclick=" changeIfam('User_List.aspx', this);  LeftSubExpansion(21, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">�û�����</a></li>
                                    <li><a onclick=" changeIfam('Group_List.aspx', this);  LeftSubExpansion(21, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">��ɫ�����</a></li>
                                    <li><a onclick=" changeIfam('OperateLog_Manage.aspx', this);  LeftSubExpansion(21, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">ϵͳ������־</a></li>
                                    <li><a onclick=" changeIfam('UpdatePassword.aspx', this);  LeftSubExpansion(21, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">�޸�����</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub22">
                            <div class="side-bx-title" onclick=" LeftExpansion(13, 2, this); ">
                                <h3>���ݹ���</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('backupDB.aspx', this);  LeftSubExpansion(22, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">���ݱ���</a></li>
                                    <li><a onclick=" changeIfam('ClearData.aspx', this);  LeftSubExpansion(22, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">�����������</a></li>
                                </ul>
                            </div>
                        </div>
                        <%--   <div class="side-bx side-bx-down">--%>
                        <div class="side-bx" id="box_leftidSub23">
                            <div class="side-bx-title" onclick=" LeftExpansion(13, 3, this); ">
                                <h3>����������</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('SensitiveWordsSeting.aspx', this);  LeftSubExpansion(23, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">����������</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="side-bx" id="box_leftidSub24">
                            <div class="side-bx-title" onclick=" LeftExpansion(13, 4, this); ">
                                <h3>��վ�Ż�</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('Cache/Global_CacheManage.aspx', this);  LeftSubExpansion(24, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">���»���</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>


                    <!--young-->
                    <%--  ���ɱ���--%>
                    <div class="box_left" id="box_leftid15" style="display: none">
                        <div class="side-bx side-first" id="box_leftidSub55">
                            <div class="side-bx-title" onclick=" LeftExpansion(15, 1, this); ">
                                <h3>�������</h3>
                            </div>
                            <div class="side-bx-bd" style="display: none;">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('userOrderReport.aspx', this);  LeftSubExpansion(55, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">��������</a></li>
                                    <li><a class="current" onclick=" changeIfam('storeOrderReport.aspx', this);  LeftSubExpansion(55, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">��������</a></li>
                                    <li><a class="current" onclick=" changeIfam('Salesofinventory.aspx', this);  LeftSubExpansion(55, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">��������</a></li>
                                </ul>
                            </div>

                        </div>
                    </div>




                    <%--   <!--ϵͳ��Ⱥ->--%>
                    <div class="box_left" id="box_leftid12" style="display: none">
                        <div class="side-bx side-first" id="box_leftidSub51">
                            <div class="side-bx-title" onclick=" LeftExpansion(12, 1, this) ">
                                <h3>վȺ����</h3>
                            </div>
                            <div class="side-bx-bd">
                                <ul>
                                    <li><a class="current" onclick=" changeIfam('websites_list.aspx', this); LeftSubExpansion(51, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">վȺ�б�</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <!--�ұ�-->
                <div class="mright" id="mright" style="position: relative;">
                    <div id="test" onclick=" test() " style="color: #555555; cursor: pointer; font-weight: bold; text-align: left;"
                        class="san">
                        ���ز˵�
                    </div>
                    <iframe src="AdminWelcome_List.aspx" width="100%" frameborder="0" scrolling="auto"
                        id="mainFrame" name="win" onload=" this.height =100%" style="overflow-y: hidden;"></iframe>
                </div>
            </div>
            <div class=" warp clearfix" id="1">
            </div>
        </div>
        <div class="foot">
            <p class="copyright">
                Powered by <a href="http://www.T.com/" target="_blank"></a>Copyright (C) 2010-2014,
                All Rights Reserved
            </p>
        </div>
    </div>
    <!--ͷ������� ѡ�еĵڼ���-->
    <input id="HiddenFieldTop" type="hidden" value="1" name="HiddenFieldTop" />
    <!--ͷ��С���� ѡ�еĵڼ���-->
    <input id="HiddenTopSub" type="hidden" value="1" name="HiddenTopSub" />
    <!--��ߴ���� ѡ�еĵڼ���-->
    <input id="HiddenLeft" type="hidden" value="1" name="HiddenTopSub" />
    <!--���С���� ѡ�еĵڼ���-->
    <input id="HiddenLeftSub" type="hidden" value="1" name="HiddenTopSub" />
    <div class="SiteNav" style="display: none;">
        <div class="SiteNavCon">
            <div class="title clearfix">
                <span class="fl"></span><a href="javascript:;" class="fr"></a>
            </div>
            <div class="con">
                <dl class="item clearfix">
                    <dt><b>��վ����</b></dt>
                    <dd>
                        <a href="javascript:void(0);"><b>��������</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('ServiceSite_Settings.aspx');LeftSubExpansion(1, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">վ�����</a></li>
                            <li><a onclick=" changeIfam('ServiceSite_BasicSettings.aspx');LeftSubExpansion(1, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">��������</a></li>
                            <li><a onclick=" changeIfam('SetCategoryScale.aspx');LeftSubExpansion(1, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">�����������</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>�ͷ�����</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('ServiceOnLineService_ManageShow.aspx');LeftSubExpansion(2, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">�ͷ�����</a></li>
                            <li><a onclick=" changeIfam('ServiceOnLineService_List.aspx');LeftSubExpansion(2, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">���߿ͷ�</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>֧����ʽ</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('Payment_List.aspx');LeftSubExpansion(3, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">ƽ̨֧����ʽ</a></li>
                            <li><a class="current" onclick=" changeIfam('MobilePayment_List.aspx');LeftSubExpansion(3, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">�ֻ�֧����ʽ</a></li>
                            <li><a class="current" onclick=" changeIfam('PaymentType_List.aspx');LeftSubExpansion(3, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">֧������</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>������˾</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('LogisticsCompany_List.aspx');LeftSubExpansion(4, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">������˾</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>�����б�</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('ShopNum1Region_list.aspx');;LeftSubExpansion(5, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">�����б�</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>ͼƬ����</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('ImageCategory_List.aspx');LeftSubExpansion(6, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">ͼƬ���� </a></li>
                            <li><a onclick=" changeIfam('Image_List.aspx');LeftSubExpansion(6, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">ͼƬ�б�</a></li>
                            <li><a onclick=" changeIfam('ServiceSite_ImageSettings.aspx');LeftSubExpansion(6, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">ͼƬˮӡ</a></li>
                            <li><a onclick=" changeIfam('ImageSpec_List.aspx');LeftSubExpansion(6, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">ͼƬ���</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>ϵͳ����</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('Third_loginList.aspx');LeftSubExpansion(7, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">��������¼����</a></li>
                            <li><a onclick=" changeIfam('Discuz_Settings.aspx');LeftSubExpansion(7, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">����Discuz!NT</a></li>
                            <li><a onclick=" changeIfam('UCDiscuz_Settings.aspx');LeftSubExpansion(7, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">����UCenter</a></li>
                            <li><a onclick=" changeIfam('Tg_Settings.aspx');LeftSubExpansion(7, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">�����Ź�ϵͳ</a></li>
                            <li><a onclick=" changeIfam('Union_Settings.aspx');LeftSubExpansion(7, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">��������ϵͳ</a></li>
                        </ul>
                    </dd>
                </dl>
                <dl class="item clearfix">
                    <dt><b>��Ʒ����</b></dt>
                    <dd>
                        <a href="javascript:void(0);"><b>��Ʒ��������</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('Brand_List.aspx');LeftSubExpansion(8, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">��ƷƷ��</a></li>
                            <li><a onclick=" changeIfam('Specification_List.aspx');LeftSubExpansion(8, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">������</a></li>
                            <li><a onclick=" changeIfam('TbCIDSpecification.aspx');LeftSubExpansion(8, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">�Ա������</a></li>
                            <li><a onclick=" changeIfam('ShopNum1_ShopProductProp_List.aspx');LeftSubExpansion(8, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">���Թ���</a></li>
                            <li><a onclick=" changeIfam('ShopNum1_ProductCategory_List.aspx');LeftSubExpansion(8, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ʒ����</a></li>
                            <li><a onclick=" changeIfam('CategoryType.aspx');LeftSubExpansion(8, 6, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ʒ����</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>��Ʒ����</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('Prouduct_List.aspx');LeftSubExpansion(9, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ʒ�б�</a></li>
                            <li><a onclick=" changeIfam('ProuductPanicBuy_List.aspx');LeftSubExpansion(9, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">������Ʒ�б�</a></li>
                            <li><a onclick=" changeIfam('ShopProductComment_List.aspx');LeftSubExpansion(9, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ʒ�����б�</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>��Ʒ��Ϣ���</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('ProuductChecked_List.aspx');LeftSubExpansion(11, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ʒ��Ϣ���</a></li>
                            <li><a class="current" onclick=" changeIfam('Prouduct_PanicChecked_List.aspx');LeftSubExpansion(11, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">������Ϣ���</a></li>
                            <li><a onclick=" changeIfam('ShopProductCommentAudit_List.aspx');LeftSubExpansion(11, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ʒ�������</a></li>
                        </ul>
                    </dd>
                </dl>
                <dl class="item clearfix">
                    <dt><b>��������</b></dt>
                    <dd>
                        <a href="javascript:void(0);"><b>��������</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('Order_List.aspx', this); LeftSubExpansion(11, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">�Ź������б�</a></li>
                            <li><a onclick=" changeIfam('OrderPanic_List.aspx', this); LeftSubExpansion(11, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">���������б�</a></li>
                            <li><a onclick=" changeIfam('Order_List.aspx', this); LeftSubExpansion(11, 7, this);javascript:shopnum1.Tool.LoadMask.show(); ">�����б�</a></li>
                            <li><a onclick=" changeIfam('CTCOrder_List.aspx', this); LeftSubExpansion(11, 8, this);javascript:shopnum1.Tool.LoadMask.show(); ">CTC������ϸ</a></li>

                            <li><a onclick=" changeIfam('Order_Refuse.aspx', this); LeftSubExpansion(11, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">��A���ܾ��Ķ������</a></li>
                            <li><a onclick=" changeIfam('Order_Refund_two.aspx', this); LeftSubExpansion(11, 6, this);javascript:shopnum1.Tool.LoadMask.show(); ">�����˿���б�</a></li>
                        </ul>
                    </dd>
                    <dd class="subItem">
                        <a href="javascript:void(0);"><b>�ٱ�||Ͷ��</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('ComplaintsManagement_List.aspx', this); LeftSubExpansion(13, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">�ٱ�����</a></li>
                            <li><a onclick=" changeIfam('OrdeComplaints_List.aspx', this); LeftSubExpansion(13, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">Ͷ�߹���</a></li>
                        </ul>
                    </dd>
                </dl>
                <dl class="item clearfix">
                    <dt><b>��Ա����</b></dt>
                    <dd>
                        <a href="javascript:void(0);"><b>��Ա����</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('Member_List.aspx', this);LeftSubExpansion(14, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ա�б�</a></li>
                            <li><a onclick=" changeIfam('MemberRank_List.aspx', this);LeftSubExpansion(14, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ա�ȼ�</a></li>
                            <li><a class="current" onclick=" changeIfam('MemberShip_List.aspx', this); LeftSubExpansion(14, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ա�ȼ������б� </a></li>
                            <li><a class="current" onclick=" changeIfam('ChangeScoreLog_List.aspx', this); LeftSubExpansion(14, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">���Ѻ��������־ </a></li>
                            <li><a class="current" onclick=" changeIfam('ChangeRankScoreLog_List.aspx', this); LeftSubExpansion(14, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">�ȼ����������־ </a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>վ����Ϣ</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('SendMessage_List.aspx', this);LeftSubExpansion(15, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ϣ������</a></li>
                            <li><a onclick=" changeIfam('Message_Operate.aspx', this);LeftSubExpansion(15, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">������Ϣ</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>�������</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('ShopNum1MessageBoard_List.aspx'); LeftSubExpansion(16, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">�������</a></li>
                        </ul>
                    </dd>
                </dl>
                <dl class="item clearfix">
                    <dt><b>���̹���</b></dt>
                    <dd>
                        <a href="javascript:void(0);"><b>���̻�������</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('ShopType_List.aspx');LeftSubExpansion(18, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">���̷���</a></li>
                            <li><a onclick=" changeIfam('ShopRank_List.aspx'); LeftSubExpansion(18, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">���̵ȼ��б�</a></li>
                            <li><a onclick=" changeIfam('ShopTemplate_List.aspx'); LeftSubExpansion(18, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">����ģ���б�</a></li>
                            <li><a onclick=" changeIfam('CouponType_List.aspx');LeftSubExpansion(18, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">�Ż�ȯ����</a></li>
                            <li><a onclick=" changeIfam('ShopReputation_List.aspx');LeftSubExpansion(18, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">���������б�</a></li>
                            <li><a onclick=" changeIfam('ShopEnsure_List.aspx'); LeftSubExpansion(18, 6, this);javascript:shopnum1.Tool.LoadMask.show(); ">���̵����б�</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>���̹���</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('ShopInfoList_Manage.aspx'); LeftSubExpansion(19, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">�����б�</a></li>
                            <li><a onclick=" changeIfam('ShopEnsureVerify_List.aspx'); LeftSubExpansion(19, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">�����뵣���б�</a></li>
                            <li><a onclick=" changeIfam('ShopDoMain_List.aspx'); LeftSubExpansion(19, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">���������б�</a></li>
                            <li><a onclick=" changeIfam('CouponList.aspx'); LeftSubExpansion(19, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">�����Ż�ȯ�б�</a></li>
                            <li><a onclick=" changeIfam('Shop_ImgManage.aspx'); LeftSubExpansion(19, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">����ͼ���б�</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>��������</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('ShopArticle_List.aspx'); LeftSubExpansion(52, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">���������б�</a></li>
                            <li><a class="current" onclick=" changeIfam('ShopArticleComment_List.aspx'); LeftSubExpansion(52, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">�������������б�</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>������Ƶ</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('ShopVedio_List.aspx'); LeftSubExpansion(53, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">������Ƶ�б�</a></li>
                            <li><a onclick=" changeIfam('ShopVedioComment_List.aspx'); LeftSubExpansion(53, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">������Ƶ�����б�</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>������Ϣ���</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('ShopDoMainChecked_List.aspx', this);  LeftSubExpansion(20, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">������������б�</a></li>
                            <li><a onclick=" changeIfam('ShopInfoList_Audit.aspx', this);  LeftSubExpansion(20, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">��������б�</a></li>
                            <li><a onclick=" changeIfam('ShopInfoList_AuditNo.aspx', this);  LeftSubExpansion(20, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">�������δͨ���б�</a></li>
                            <li><a onclick=" changeIfam('ShopArticle_Check.aspx', this);  LeftSubExpansion(20, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">������������б�</a></li>
                            <li><a onclick=" changeIfam('CouponList_Audit.aspx', this);  LeftSubExpansion(20, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">�����Ż�ȯ����б�</a></li>
                            <li><a onclick=" changeIfam('ShopArticleCommentAudit_List.aspx'); LeftSubExpansion(20, 6, this);javascript:shopnum1.Tool.LoadMask.show(); ">���������������</a></li>
                            <li><a onclick=" changeIfam('ShopVedioChecked_List.aspx'); LeftSubExpansion(20, 7, this);javascript:shopnum1.Tool.LoadMask.show(); ">������Ƶ���</a></li>
                            <li><a onclick=" changeIfam('ShopVedioCommentChecked_List.aspx'); LeftSubExpansion(20, 8, this);javascript:shopnum1.Tool.LoadMask.show(); ">������Ƶ�������</a></li>
                        </ul>
                    </dd>
                </dl>
                <dl class="item clearfix">
                    <dt><b>Ӫ���ƹ�</b></dt>
                    <dd>
                        <a href="javascript:void(0);"><b>�ʼ�ϵͳ</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('Email_List.aspx'); LeftSubExpansion(26, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">�ʼ�ģ��</a></li>
                            <li><a onclick=" changeIfam('ServiceSite_EmailSetting.aspx'); LeftSubExpansion(26, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">�ʼ��ӿ�����</a></li>
                            <li><a onclick=" changeIfam('EmailMemberGroup_List.aspx'); LeftSubExpansion(27, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ա�����</a></li>
                            <li><a onclick=" changeIfam('EmailGropSend_Operate.aspx'); LeftSubExpansion(26, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">�ʼ�Ⱥ��</a></li>
                            <li><a onclick=" changeIfam('EmailGroupSend_List.aspx'); LeftSubExpansion(26, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">�ʼ�������ʷ</a></li>
                            <li><a onclick=" changeIfam('Service_EmailSendSetting.aspx'); LeftSubExpansion(26, 6, this);javascript:shopnum1.Tool.LoadMask.show(); ">�ʼ���������</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>����ϵͳ</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('MMS_List.aspx'); LeftSubExpansion(27, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">����ģ��</a></li>
                            <li><a onclick=" changeIfam('MMSMemberGroup_List.aspx'); LeftSubExpansion(27, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ա�����</a></li>
                            <li><a onclick=" changeIfam('MMSGroupSend_Operate.aspx'); LeftSubExpansion(27, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">����Ⱥ��</a></li>
                            <li><a onclick=" changeIfam('MMSGroupSend_List.aspx'); LeftSubExpansion(27, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">���ŷ�����ʷ</a></li>
                            <li><a onclick=" changeIfam('MMSInterface_Operate.aspx'); LeftSubExpansion(27, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">���Žӿ�����</a></li>
                            <li><a onclick=" changeIfam('Service_MMSSendSetting.aspx'); LeftSubExpansion(27, 6, this);javascript:shopnum1.Tool.LoadMask.show(); ">���ŷ�������</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>���������Ż�</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('SiteMota_List.aspx', this); LeftSubExpansion(28, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">SEO����</a></li>
                            <li><a class="current" onclick=" changeIfam('Robots_List.aspx', this); LeftSubExpansion(28, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">Robots����</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>վ���ͼ</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('SetMap.aspx', this); LeftSubExpansion(29, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">վ���ͼ</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>�����б�</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('SurveyTheme_Manage.aspx', this); LeftSubExpansion(30, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">�����б�</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>���¹���</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('ArticleCategory_List.aspx', this); LeftSubExpansion(31, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">ƽ̨���·���</a></li>
                            <li><a onclick=" changeIfam('Article_List.aspx', this); LeftSubExpansion(31, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">ƽ̨�����б�</a></li>
                            <li><a onclick=" changeIfam('ArticleComment_List.aspx', this); LeftSubExpansion(33, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">ƽ̨���������б�</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>��Ƶ����</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('VideoCategory_List.aspx'); LeftSubExpansion(53, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ƶ����</a></li>
                            <li><a class="current" onclick=" changeIfam('Video_List.aspx'); LeftSubExpansion(53, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ƶ�б�</a></li>
                            <li><a onclick=" changeIfam('VideoComment_List.aspx'); LeftSubExpansion(53, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ƶ�����б�</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>��������</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('AttachMent_list.aspx'); LeftSubExpansion(33, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">�����б�</a></li>
                            <li><a class="current" onclick=" changeIfam('AttachMentCateGory_List.aspx'); LeftSubExpansion(33, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">��������</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>��������</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('Link_Manage.aspx', this); LeftSubExpansion(34, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">��������</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>��վ�ƹ�</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('SiteSpread.aspx'); LeftSubExpansion(35, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">��վ�ƹ�</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>����̳�</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('ShopNum1_ScoreProductCategory_List.aspx'); LeftSubExpansion(36, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">�����Ʒ����</a></li>
                            <li><a class="current" onclick=" changeIfam('ProductIntegral_List.aspx'); LeftSubExpansion(36, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">�����Ʒ�б�</a></li>
                            <li><a onclick=" changeIfam('OrderScore_List.aspx', this); LeftSubExpansion(36, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">��������б�</a></li>
                            <li><a onclick=" changeIfam('ProductIntegralChecked_List.aspx');LeftSubExpansion(36, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">�����Ʒ���</a></li>
                        </ul>
                    </dd>
                    <dd class="last">
                        <a href="javascript:void(0);"><b>�����</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('Group_ActivityList.aspx');LeftSubExpansion(37, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">�Ź��</a></li>
                            <li><a onclick=" changeIfam('Limit_ActivityList.aspx');LeftSubExpansion(37, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">������ʱ�ۿ�</a></li>
                            <li><a onclick=" changeIfam('Theme_ActivityList.aspx');LeftSubExpansion(37, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">����</a></li>
                            <li><a onclick=" changeIfam('ZtcGoods_List.aspx');LeftSubExpansion(37, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">ֱͨ����Ʒ�б�</a></li>
                            <li><a onclick=" changeIfam('ShopZtcApplyAudit_List.aspx');LeftSubExpansion(37, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">ֱͨ�����</a></li>
                        </ul>
                    </dd>
                </dl>
                <dl class="item clearfix">
                    <dt><b>�������</b></dt>
                    <dd>
                        <a href="javascript:void(0);"><b>��Ա��ֵ</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('AdvancePaymentMemApplyLog_List.aspx'); LeftSubExpansion(36, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ա��ֵ</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>���ֹ���</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('AdvancePaymentApplyLog_List.aspx', this); LeftSubExpansion(37, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">���ֹ���</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>ת�˹���</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('AdvancePaymentPreTransfer_List.aspx', this); LeftSubExpansion(38, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Աת���б�</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>��ң�BV������</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('AdvancePaymentStatistics_List.aspx', this); LeftSubExpansion(39, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">�һ��PV��ͳ���б� </a></li>
                            <li><a class="current" onclick=" changeIfam('ChangeAdvancePaymentLog_List.aspx', this); LeftSubExpansion(39, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">��ң�BV�������־ </a></li>
                            <li><a class="current" onclick=" changeIfam('FreezeAdvancePaymentLog_List.aspx', this); LeftSubExpansion(39, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">��ң�BV����/����־</a></li>
                            <li><a class="current" onclick=" changeIfam('Select_Money_All.aspx', this); LeftSubExpansion(39, 7, this);javascript:shopnum1.Tool.LoadMask.show(); ">ÿ���ʽ�ͳ��</a></li>
                        </ul>
                    </dd>
                </dl>
                <dl class="item clearfix">
                    <dt><b>����ϵͳ</b></dt>
                    <dd>
                        <a href="javascript:void(0);"><b>�������</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('ShopNum1_SupplyDemand_List.aspx'); LeftSubExpansion(40, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">������Ϣ</a></li>
                            <li><a onclick=" changeIfam('ShopNum1_SupplyDemandCategory_List.aspx'); LeftSubExpansion(40, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">�������</a></li>
                            <li><a onclick=" changeIfam('SupplyDemandComment_List.aspx'); LeftSubExpansion(40, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">���������б�</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>�������</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('ShopNum1_SupplyDemandCheck_List.aspx'); LeftSubExpansion(54, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">������Ϣ���</a></li>
                            <li><a onclick=" changeIfam('SupplyDemandCommentAudit_List.aspx'); LeftSubExpansion(54, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">�����������</a></li>
                        </ul>
                    </dd>
                </dl>
                <dl class="item clearfix">
                    <dt><b>��վװ��</b></dt>
                    <dd>
                        <a href="javascript:void(0);"><b>ģ�����</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('SkinBackup.aspx', this);  LeftSubExpansion(42, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">ģ�屸��</a></li>
                            <li><a onclick=" changeIfam('SkinSelect.aspx', this);  LeftSubExpansion(42, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">ģ��ѡ��</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>������</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('PageAdID_List.aspx', this);  LeftSubExpansion(43, 5, this);javascript:shopnum1.Tool.LoadMask.show(); ">���λ�б�</a></li>
                            <li><a onclick=" changeIfam('Advertisement_List.aspx', this);  LeftSubExpansion(43, 7, this);javascript:shopnum1.Tool.LoadMask.show(); ">����б�</a></li>
                            <li><a onclick=" changeIfam('AdvertisementImg_List.aspx', this);  LeftSubExpansion(43, 6, this);javascript:shopnum1.Tool.LoadMask.show(); ">ͼƬ����б�</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>��Ŀ�б�</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('UserDefinedColumn_List.aspx');  LeftSubExpansion(45, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ŀ�б�</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>��������</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('Help_List.aspx', this);  LeftSubExpansion(46, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">�����б�</a></li>
                            <li><a onclick=" changeIfam('HelpType_List.aspx', this);  LeftSubExpansion(46, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">��������</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>�������</b></a>
                        <ul class="subItem">
                            <li><a class="current" onclick=" changeIfam('Announcement_List.aspx', this);  LeftSubExpansion(47, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">�����б�</a></li>
                            <li><a onclick=" changeIfam('AnnouncementCategory_List.aspx', this);  LeftSubExpansion(47, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">�������</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>�ؼ��ֹ���</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('KeyWords_Manage.aspx', this);LeftSubExpansion(487, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">�ؼ����б�</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>���̹���</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('MerchantsManage.aspx', this);  LeftSubExpansion(488, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">���̹���</a></li>
                        </ul>
                    </dd>
                </dl>
                <dl class="item clearfix">
                    <dt><b>��Ӫͳ��</b></dt>
                    <dd>
                        <a href="javascript:void(0);"><b>����ͳ��</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('SeeBuyRate.aspx', this);  LeftSubExpansion(49, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">���ʹ����ʱ���</a></li>
                            <li><a onclick=" changeIfam('SellOrder.aspx', this);  LeftSubExpansion(49, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ʒ�������б���</a></li>
                            <li><a onclick=" changeIfam('OrderProductReport.aspx', this);  LeftSubExpansion(49, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ʒ������ϸ����</a></li>
                            <li><a onclick=" changeIfam('PaymentStatistics_List.aspx', this);  LeftSubExpansion(49, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">֧����ʽͳ�Ʊ���</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>����ͳ��</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('ShopClickReport.aspx', this);  LeftSubExpansion(50, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">���̷������б���</a></li>
                            <li><a onclick=" changeIfam('ShopChartArea.aspx', this);  LeftSubExpansion(50, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">��������ֲ�</a></li>
                            <li><a onclick=" changeIfam('ShopSales.aspx', this);  LeftSubExpansion(50, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">�������۶�ͳ��</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>��Աͳ��</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('MemberChartArea.aspx', this);  LeftSubExpansion(51, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">��Ա����ֲ�ͼ</a></li>
                        </ul>
                    </dd>
                </dl>
                <dl class="item clearfix">
                    <dt><b>ϵͳ����</b></dt>
                    <dd>
                        <a href="javascript:void(0);"><b>վȺ����</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('websites_list.aspx', this); LeftSubExpansion(51, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">վȺ�б�</a></li>
                        </ul>
                    </dd>
                </dl>
                <dl class="item clearfix">
                    <dt><b>ϵͳ����</b></dt>
                    <dd>
                        <a href="javascript:void(0);"><b>Ȩ�޹���</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('User_List.aspx');  LeftSubExpansion(21, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">�û�����</a></li>
                            <li><a onclick=" changeIfam('Group_List.aspx');  LeftSubExpansion(21, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">��ɫ�����</a></li>
                            <li><a onclick=" changeIfam('OperateLog_Manage.aspx');  LeftSubExpansion(21, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">ϵͳ������־</a></li>
                            <li><a onclick=" changeIfam('UpdatePassword.aspx');  LeftSubExpansion(21, 4, this);javascript:shopnum1.Tool.LoadMask.show(); ">�޸�����</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>���ݹ���</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('backupDB.aspx', this);  LeftSubExpansion(22, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">���ݱ���</a></li>
                            <li><a onclick=" changeIfam('ClearData.aspx', this);  LeftSubExpansion(22, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">�����������</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>����������</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('SensitiveWordsSeting.aspx', this);  LeftSubExpansion(23, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">����������</a></li>
                        </ul>
                    </dd>
                    <dd>
                        <a href="javascript:void(0);"><b>��վ�Ż�</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('Cache/Global_CacheManage.aspx', this);  LeftSubExpansion(24, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">���»���</a></li>
                        </ul>
                    </dd>
                </dl>


                <!--young-->
                <dl class="item clearfix">
                    <dt><b>���ɱ���</b></dt>
                    <dd>
                        <a href="javascript:void(0);"><b>�������</b></a>
                        <ul class="subItem">
                            <li><a onclick=" changeIfam('userOrderReport.aspx', this);  LeftSubExpansion(55, 1, this);javascript:shopnum1.Tool.LoadMask.show(); ">��������</a></li>
                            <li><a onclick=" changeIfam('storeOrderReport.aspx', this);  LeftSubExpansion(55, 2, this);javascript:shopnum1.Tool.LoadMask.show(); ">����������</a></li>
                            <li><a class="current" onclick=" changeIfam('Salesofinventory.aspx', this);  LeftSubExpansion(55, 3, this);javascript:shopnum1.Tool.LoadMask.show(); ">��������</a></li>


                        </ul>

                    </dd>
                </dl>

            </div>
        </div>
    </div>
    <!--͸�����ֲ�-->
    <div class="mask">
    </div>
    <script type="text/javascript">
        var target = $('.item dd');
        target.hover(function () {
            $(this).children().eq(0).addClass('btn');
            $(this).children().eq(1).css('display', 'block');
        }, function () {
            $(this).children().eq(0).removeClass('btn');
            $(this).children().eq(1).css('display', 'none');
        });
        $('.item').hover(function () {
            $(this).children().eq(0).addClass('btn');
        }, function () {
            $(this).children().eq(0).removeClass('btn');
        });
    </script>
    <script type="text/javascript">
        var site_url = window.location.href.toLowerCase();
        switch (true) {
            default:
                $("#nav li").attr("class", "");
                $("#nav li").eq(0).attr("class", "nav_lishw");
                $(".nav_lishw .kind_menu").show();
        }
        $(".mask").hide();
        //��ʼ��
        $("#HiddenTopSub").val("1");
        $("#HiddenFieldTop").val("1");
        $("#HiddenLeftSub").val("1");
        $("#HiddenLeft").val("1");
        $(".SiteNavCon .fr").click(function () {
            $(".SiteNav").hide();
            $(".mask").hide();
        });
        //ͷ������� �����¼�
        $("#nav li").hover(
            function () {
                //		    $("#nav li").children(".kind_menu").hide();
                if (!$(this).find("span.v>a").hasClass("sele")) {
                    $(this).find("span.v>a").attr("class", "sele_hover"); //��ǰͷ������� ��ʽΪѡ��
                }

                //            $(this).children(".kind_menu").show();//��ǰͷ������� �����С���� ��ʾ
            },
            function () {
                if (!$(this).find("span.v>a").hasClass("sele")) {
                    $(this).find("span.v>a").attr("class", ""); //��ǰͷ������� ��ʽΪ��ѡ��
                }

                //            $("#nav li>div.kind_menu").hide();
                //��ԭԭ����ʽ
                //            var HiddenFieldTop=parseInt($("#HiddenFieldTop").val());
                //            $("#nav li:eq("+(HiddenFieldTop-1)+")>span>a").attr("class","sele");
                //            $("#nav li:eq("+(HiddenFieldTop-1)+")>div.kind_menu").show();
            }
        );

        //ͷ��С���� �����¼�
        $("div.kind_menu>div>a").hover(
            function () {
                $(this).attr("class", "ahover");

            },
            function () {
                $(this).removeClass("ahover");
                //��ԭԭ����ʽ
                var HiddenTopSub = parseInt($("#HiddenTopSub").val());
                var HiddenFieldTop = parseInt($("#HiddenFieldTop").val());
                $("#nav li:eq(" + (HiddenFieldTop - 1) + ")>div>div>a:eq(" + (HiddenTopSub - 1) + ")").attr("class", "ahover");
            }
        );
    </script>
    <script type="text/javascript" language="javascript">
        function changeIfam(obj) {
            $("#mainFrame").attr("src", obj);
            $(".SiteNav").hide();
            $(".mask").hide();
        }

        function ShowNav() {
            $(".SiteNav").show("slow");
            $(".mask").show("slow");
        }

        //ͷ������� ����¼� index:С���� id  indexsub:ҳ����ߵ���id 

        function changeTab(index, indexLeft, obj) {
            $("div.r>ul>li>span>a").attr("class", ""); //���д����δѡ��
            $(".kind_menu").hide(); //�����С��������
            $(obj).attr("class", "sele"); //��ǰ�����ѡ��
            $(obj).parent().next().show(); //��ǰ����� �����С������ʾ
            $(obj).parent().next().find("div.kc>a").attr("class", ""); //����ǰС����ȡ����ʽ
            $(obj).parent().next().find("div.kc>a:eq(0)").attr("class", "ahover"); //����ǰ��һ��С������ʽ
            $("#HiddenFieldTop").val(index); //�����������ǵڼ��� ���ڻ����¼�
            $("#HiddenTopSub").val("1"); //�����������ǵڼ��� ���ڻ����¼�

            $(".box_left").hide(); //��ߵ�������
            $("#box_leftid" + indexLeft).show(); //��ǰ��ߵ�����ʾ
            $("div.box_left>div>div.side-bx-bd").hide(); //��ǰ��ߵ��� ���йر�
            $("#box_leftid" + indexLeft + ">div:eq(0)>div.side-bx-bd").show(); //��ǰ��ߵ��� ��һ��չ��
            $(".side-bx-bd>ul>li>a").attr("class", ""); //��ǰ��ߵ��� С���ⶼ��ѡ��
            $("#box_leftid" + indexLeft + ">div:eq(0)>div.side-bx-bd>ul>li:eq(0)>a").attr("class", "current"); //��ǰ��ߵ��� ��һ��С����ѡ��
            $("#box_leftid" + indexLeft + ">div").removeClass("side-bx-down"); //��ͷ�䷽��
            $("#box_leftid" + indexLeft + ">div:eq(0)").addClass("side-bx-down"); //��ͷ�䷽��
            $("#HiddenLeftSub").val("1"); //�����������ǵڼ��� ���ڻ����¼�

            //������ Ҫ���� box_leftidSub8 ��������
            var indexLeftSub = $("#box_leftid" + indexLeft + ">div:eq(0)").attr("id");
            $("#HiddenLeft").val(indexLeftSub.substring(13)); //�����������ǵڼ��� ���ڻ����¼�

        }

        //ͷ��С���� ����¼� parent:����� id ,index :С�����������ǵڼ���  indexsub:С����id  indexLeft:ҳ����ߵ���id 

        function changeTabSub(parent, index, indexLeft, indexLeftSub, Aobj) {
            $("#HiddenFieldTop").val(parent); //���� ������������ǵڼ��� ���ڻ����¼�
            $("#HiddenTopSub").val(index); //���� С�����������ǵڼ��� ���ڻ����¼�
            $("div.kind_menu>div>a").attr("class", "");
            $(Aobj).attr("class", "ahover"); //����ǰaѡ����ʽ

            ////��ߵ���
            $(".box_left").hide(); //��ߵ�������
            $("#box_leftid" + indexLeft).show(); //��ǰ��ߵ�����ʾ
            $("div.side-bx>div.side-bx-bd").hide();
            $("#box_leftidSub" + indexLeftSub + ">div.side-bx-bd").show();


            $(".side-bx").removeClass("side-bx-down"); //��ͷ��ʼ��
            $("#box_leftidSub" + indexLeftSub).addClass("side-bx-down"); //��ͷ�䷽��

            $(".side-bx-bd>ul>li>a").attr("class", ""); //��ǰ��ߵ��� С���ⶼ��ѡ��
            $("#box_leftidSub" + indexLeftSub + ">div.side-bx-bd>ul>li:eq(0)>a").attr("class", "current"); //��ǰ��ߵ��� ��һ��С����ѡ��
            $("#HiddenLeftSub").val("1"); //�����������ǵڼ��� ���ڻ����¼�
            $("#HiddenLeft").val(indexLeftSub); //�����������ǵڼ��� ���ڻ����¼�
        }


        //��� �󵼺� չ������ parent��ͷ���󵼺� li��λ��,index��ͷ��С���� ��λ�� (����id)

        function LeftExpansion(parent, index, obj) {
            //var iurl=$(obj).next().find(".current").attr("onclick");
            $(obj).next().find(".current").removeClass("current");
            if ($(obj).parent().hasClass("side-bx-down")) {
                //��ߵ��� չ������
                $(obj).parent().removeClass("side-bx-down");
                $("div.side-bx>div.side-bx-bd").hide();
                $(obj).next("div.side-bx-bd").hide();
            } else {
                //��ߵ��� չ������
                $(".side-bx").removeClass("side-bx-down");
                $(obj).parent().addClass("side-bx-down");
                $("div.side-bx>div.side-bx-bd").hide();
                $(obj).next("div.side-bx-bd").show();
            }

            //ͷ�������仯
            $("#HiddenFieldTop").val(parent); //�����������ǵڼ��� ���ڻ����¼�
            $("#HiddenTopSub").val(index);
            $("div.kind_menu>div.kc>a").attr("class", "");
            $("#nav li:eq(" + (parseInt(parent) - 1) + ")>div>div>a:eq(" + (parseInt(index) - 1) + ")").attr("class", "ahover");
            //changeIfam(iurl.split("'")[1]);
        }

        //��� С���� ����¼� parent= box_leftidSub8;index:��ʾ��div.side-bx-bd�ĵڼ���a

        function LeftSubExpansion(parent, index, obj) {
            $("div.side-bx-bd>ul>li>a").attr("class", "");
            $(obj).attr("class", "current"); //ѡ����ʽ
            $("#HiddenLeftSub").val(index); //�����������ǵڼ��� ���ڻ����¼�
            $("#HiddenLeft").val(parent); //�����������ǵڼ��� ���ڻ����¼�
        }

        $(function () {
            // ��ߵ��� �����¼�
            $("div.side-bx-bd>ul>li>a").hover(
                function () {
                    if ($(this).hasClass("current")) {

                    } else {
                        $(this).attr("class", "test");
                    }
                },
                function () {
                    $(this).removeClass("test");
                    //��ԭԭ����ʽ
                    var HiddenLeftSub = parseInt($("#HiddenLeftSub").val());
                    var HiddenLeft = parseInt($("#HiddenLeft").val());
                    $("#box_leftidSub" + HiddenLeft + ">div.side-bx-bd>ul>li>a:eq(" + (HiddenLeftSub - 1) + ")").attr("class", "current");
                }
            );
        });

    </script>
    <style type="text/css">
        .loading {
            background: url("images/loading_bg.gif") no-repeat 0 0;
            color: Black;
            display: block;
            font-size: 12px;
            font-style: normal;
            font-weight: normal;
            height: 91px;
            left: 50%;
            line-height: 90px;
            margin: 0;
            opacity: 1;
            padding: 0;
            position: absolute;
            text-align: left;
            top: 50%;
            vertical-align: baseline;
            visibility: visible;
            width: 266px;
            z-index: 65535;
        }

        .loading_img {
            color: Black;
            display: block;
            float: left;
            font-family: 'Helvetica Neue', Helvetica, Arial, sans-serif;
            font-size: 12px;
            font-style: normal;
            font-weight: bold;
            height: auto;
            left: auto;
            line-height: 32px;
            margin: 0;
            opacity: 1;
            padding: 28px 10px 0 40px;
            position: static;
            text-align: left;
            top: auto;
            vertical-align: baseline;
            visibility: visible;
            width: 16px;
            z-index: auto;
        }

        .loading_message {
            color: Black;
            display: block;
            float: left;
            font-family: 'Helvetica Neue', Helvetica, Arial, sans-serif;
            font-size: 14px;
            height: auto;
            left: auto;
            line-height: 32px;
            margin: 0;
            opacity: 1;
            padding: 28px 0 0 20px;
            position: static;
            text-align: left;
            top: auto;
            vertical-align: baseline;
            visibility: visible;
            width: auto;
            z-index: auto;
        }
    </style>
</body>
</html>
