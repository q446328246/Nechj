<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <ShopNum1:Meto ID="meto1" runat="server" Type="1" SkinFilename="Meto.ascx" />
    <link href="Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />
    <script src="Themes/Skin_Default/js/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="Themes/Skin_Default/js/jquery1.42.min.js"></script>
    <script type="text/javascript" src="Themes/Skin_Default/js/jquery.SuperSlide.2.1.1.js"></script>
    <link href="Themes/Skin_Default/Style/datouwang.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
    <!--head start-->
    <!-- #include file="headbak.aspx" -->
    <!--//head end-->
    <!--main start-->
    <ShopNum1:Advertisement ID="dd" SkinFilename="Advertisement.ascx" runat="server" />
    <!-- ���� ��ʼ -->
    <div class="banner-box">
        <div class="tmall_box">
            <div class="menu">
                <ul>
                    <li><a href="http://www.datouwang.com/">Ʒ�ƽ�</a></li>
                    <li><a href="http://www.datouwang.com/">������</a></li>
                    <li><a href="http://www.datouwang.com/">������ֲ�</a></li>
                    <li><a href="http://www.datouwang.com/">������</a></li>
                    <li><a href="http://www.datouwang.com/">���׷�</a></li>
                    <li><a href="http://www.datouwang.com/">��è����</a></li>
                </ul>
            </div>
            <div id="tmall_nav">
                <!--�����Ŀ��ʼ-->
                <div class="tmall_cat_nav fl">
                    <div class="tmall_mod_title">
                        ��Ʒ�������</div>
                    <ul class="cate_nav">
                        <li>
                            <div class="cat_0_nav">
                                <s class="cat-nav-icon fp-iconfont">&#x3451;</s> ��ѡ�г�
                            </div>
                        </li>
                        <li>
                            <div class="cat_1_nav">
                                <s class="cat-nav-icon fp-iconfont">&#x3459;</s> <a href="http://www.datouwang.com/">
                                    Ůװ</a> / <a href="#">����</a>
                            </div>
                        </li>
                        <li>
                            <div class="cat_2_nav">
                                <s class="cat-nav-icon fp-iconfont">&#x346c;</s> <a href="http://www.datouwang.com/">
                                    ��װ</a> / <a href="http://www.datouwang.com/">�˶�</a> / <a href="http://www.datouwang.com/">
                                        ����</a>
                            </div>
                        </li>
                        <li>
                            <div class="cat_3_nav">
                                <s class="cat-nav-icon fp-iconfont">&#x346d;</s> <a href="http://www.datouwang.com/">
                                    ŮЬ</a> / <a href="http://www.datouwang.com/">��Ь</a> / <a href="http://www.datouwang.com/">
                                        ���</a>
                            </div>
                        </li>
                        <li>
                            <div class="cat_4_nav">
                                <s class="cat-nav-icon fp-iconfont">&#x345c;</s> <a href="http://www.datouwang.com/">
                                    ��ױƷ</a> / <a href="http://www.datouwang.com/">���˻���</a>
                            </div>
                        </li>
                        <li>
                            <div class="cat_5_nav">
                                <s class="cat-nav-icon fp-iconfont">&#x3457;</s> <a href="http://www.datouwang.com/">
                                    �ֻ�����</a> / <a href="http://www.datouwang.com/">���԰칫</a>
                            </div>
                        </li>
                        <li>
                            <div class="cat_6_nav">
                                <s class="cat-nav-icon fp-iconfont">&#x3456;</s> <a href="http://www.datouwang.com/">
                                    ĸӤ���</a>
                            </div>
                        </li>
                        <li>
                            <div class="cat_7_nav">
                                <s class="cat-nav-icon fp-iconfont">&#x3455;</s> <a href="http://www.datouwang.com/">
                                    ʳƷ</a>
                            </div>
                        </li>
                        <li>
                            <div class="cat_8_nav">
                                <s class="cat-nav-icon fp-iconfont">&#x3454;</s> <a href="http://www.datouwang.com/">
                                    ��ҵ�</a> / <a href="http://www.datouwang.com/">�������</a>
                            </div>
                        </li>
                        <li>
                            <div class="cat_9_nav">
                                <s class="cat-nav-icon fp-iconfont">&#x345e;</s> <a href="http://www.datouwang.com/">
                                    �Ҿ߽���</a>
                            </div>
                        </li>
                        <li>
                            <div class="cat_10_nav">
                                <s class="cat-nav-icon fp-iconfont">&#x3452;</s> <a href="http://www.datouwang.com/">
                                    �鱦��Ʒ</a> / <a href="http://www.datouwang.com/">�ֱ��۾�</a>
                            </div>
                        </li>
                        <li>
                            <div class="cat_11_nav">
                                <s class="cat-nav-icon fp-iconfont">&#x345d;</s> <a href="http://www.datouwang.com/">
                                    ȫ������</a> / <a href="http://www.datouwang.com/">�������</a>
                            </div>
                        </li>
                        <li>
                            <div class="cat_12_nav">
                                <s class="cat-nav-icon fp-iconfont">&#x346e;</s> <a href="http://www.datouwang.com/">
                                    �ҷ�</a> / <a href="http://www.datouwang.com/">����</a>
                            </div>
                        </li>
                        <li>
                            <div class="cat_13_nav">
                                <s class="cat-nav-icon fp-iconfont">&#x3460;</s> <a href="http://www.datouwang.com/">
                                    ҽҩ����</a>
                            </div>
                        </li>
                        <li>
                            <div class="cat_14_nav">
                                <s class="cat-nav-icon fp-iconfont">&#x345f;</s> <a href="http://www.datouwang.com/">
                                    �ӼҰٻ�</a>
                            </div>
                        </li>
                        <li>
                            <div class="cat_15_nav">
                                <s class="cat-nav-icon fp-iconfont">&#x3461;</s> <a href="http://www.datouwang.com/">
                                    ͼ������</a>
                            </div>
                        </li>
                    </ul>
                </div>
                <!--�����Ŀ����-->
                <!--�Ҳ����ݿ�ʼ-->
                <div class="tmall_cat_content fr">
                    <div class="cat_pannel clearfix">
                        <div class="fl cat_detail grid_col_0">
                            <ul class="cat_label_list market_list clearfix">
                                <li><a href="http://www.datouwang.com/">Ůװ</a></li>
                                <li><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">��װ</a></li>
                                <li><a href="http://www.datouwang.com/">��ױ</a></li>
                                <li><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">ĸӤ</a></li>
                                <li><a href="http://www.datouwang.com/">���</a></li>
                                <li><a href="http://www.datouwang.com/">��װ</a></li>
                                <li><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">ҽҩ</a></li>
                                <li><a href="http://www.datouwang.com/">ŮЬ</a></li>
                                <li><a href="http://www.datouwang.com/">���</a></li>
                                <li><a href="http://www.datouwang.com/">��Ь</a></li>
                                <li><a href="http://www.datouwang.com/">�ʻ�</a></li>
                            </ul>
                            <h3 class="cat_label_title">
                                ���⹺</h3>
                            <ul class="cat_label_list">
                                <li><a href="http://www.datouwang.com/">���¹���</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����˵��</a></li>
                                <li><a href="http://www.datouwang.com/">�Ƽ�����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">��������</a></li>
                                <li><a href="http://www.datouwang.com/">��ȫ�ػ�</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">���һ��</a></li>
                            </ul>
                            <a class="market_banner" href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/0.png" /></a>
                        </div>
                        <div class="fl cat_banner">
                            <ul class="cat_banner_pic">
                                <li><a href="http://www.datouwang.com/">
                                    <img src="Themes/Skin_Default/images/1S.jpg" width="459" height="482" /></a></li>
                                <li><a href="http://www.datouwang.com/">
                                    <img src="Themes/Skin_Default/images/2.jpg" width="459" height="482" /></a></li>
                                <li><a href="http://www.datouwang.com/">
                                    <img src="Themes/Skin_Default/images/3.jpg" width="459" height="482" /></a></li>
                            </ul>
                            <a class="prev_pic" href="javascript:void(0)"></a><a class="next_pic" href="javascript:void(0)">
                            </a>
                            <div class="num">
                                <ul>
                                </ul>
                            </div>
                        </div>
                        <ul class="fl cat_small_banner">
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/21jpg.jpg" width="190" height="160" /></a></li>
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/22.jpg" width="190" height="160" /></a></li>
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/23.jpg" width="190" height="160" /></a></li>
                        </ul>
                    </div>
                    <div class="cat_pannel clearfix">
                        <div class="fl cat_detail grid_col_1">
                            <h3 class="cat_title">
                                Ůװ/����</h3>
                            <ul class="cat_label_list clearfix">
                                <li><a href="http://www.datouwang.com/">��ƷƵ��</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">ŮװƵ��</a></li>
                                <li><a href="http://www.datouwang.com/">Ʒ������</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">T��</a></li>
                                <li><a href="http://www.datouwang.com/">����ȹ</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����ȹ</a></li>
                                <li><a href="http://www.datouwang.com/">����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">��֯��</a></li>
                                <li><a href="http://www.datouwang.com/">ë��</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">������</a></li>
                                <li><a href="http://www.datouwang.com/">ë������</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">���޴���</a></li>
                                <li><a href="http://www.datouwang.com/">С��װ</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">ţ�п�</a></li>
                                <li><a href="http://www.datouwang.com/">������</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">���޷�</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">��������</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">��ʿ����</a></li>
                                <li><a href="http://www.datouwang.com/">˯������</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����Ƶ��</a></li>
                            </ul>
                            <div class="cat_brand">
                                <ul class="cat_slide_brand">
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/10.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/11.jpg" width="90" height="40" /></a>
                                    </li>
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/12.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/13.jpg" width="90" height="40" /></a>
                                    </li>
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/14.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/15.jpg" width="90" height="40" /></a>
                                    </li>
                                </ul>
                                <ul class="cat_slide_nav">
                                    <li>?</li>
                                    <li>?</li>
                                    <li>?</li>
                                </ul>
                            </div>
                        </div>
                        <div class="fl cat_banner">
                            <a class="banner-grid-b1" href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/7.jpg" /></a> <a class="fl banner-grid-b2" href="http://www.datouwang.com/">
                                    <img src="Themes/Skin_Default/images/8.jpg" /></a> <a class="fl banner-grid-b3" href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/9.jpg" /></a>
                        </div>
                        <ul class="fl cat_small_banner">
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/4.jpg" width="190" height="160" /></a></li>
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/5.jpg" width="190" height="160" /></a></li>
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/6.jpg" width="190" height="160" /></a></li>
                        </ul>
                    </div>
                    <div class="cat_pannel clearfix">
                        <div class="fl cat_detail grid_col_2">
                            <h3 class="cat_title">
                                ��װ/�˶�/����</h3>
                            <ul class="cat_label_list clearfix">
                                <li><a href="http://www.datouwang.com/">����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">T��</a></li>
                                <li><a href="http://www.datouwang.com/">�п�</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">ţ�п�</a></li>
                                <li><a href="http://www.datouwang.com/">���п�</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">��֯��</a></li>
                                <li><a href="http://www.datouwang.com/">����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">Ƥ��</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">���޷�</a></li>
                                <li><a href="http://www.datouwang.com/">������װ</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">�˶�Ь</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">�˶���</a></li>
                                <li><a href="http://www.datouwang.com/">����Ь</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">�ܲ�Ь</a></li>
                                <li><a href="http://www.datouwang.com/">����¿�</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">��ɽЬ</a></li>
                                <li><a href="http://www.datouwang.com/">��ɽ��</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">���г�</a></li>
                                <li><a href="http://www.datouwang.com/">�ܲ���</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">������Ʒ</a></li>
                            </ul>
                            <div class="cat_brand">
                                <ul class="cat_slide_brand">
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/16.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/17.jpg" width="90" height="40" /></a>
                                    </li>
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/18.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/19.jpg" width="90" height="40" /></a>
                                    </li>
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/20.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/21.jpg" width="90" height="40" /></a>
                                    </li>
                                </ul>
                                <ul class="cat_slide_nav">
                                    <li>?</li>
                                    <li>?</li>
                                    <li>?</li>
                                </ul>
                            </div>
                        </div>
                        <div class="fl cat_banner">
                            <a class="banner-grid-b1" href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/24.jpg" /></a> <a class="fl banner-grid-b2"
                                    href="http://www.datouwang.com/">
                                    <img src="Themes/Skin_Default/images/25.jpg" /></a> <a class="fl banner-grid-b3"
                                        href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/26.jpg" /></a>
                        </div>
                        <ul class="fl cat_small_banner">
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/21jpg.jpg" width="190" height="160" /></a></li>
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/22.jpg" width="190" height="160" /></a></li>
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/23.jpg" width="190" height="160" /></a></li>
                        </ul>
                    </div>
                    <div class="cat_pannel clearfix">
                        <div class="fl cat_detail grid_col_3">
                            <h3 class="cat_title">
                                ŮЬ/��Ь/���</h3>
                            <ul class="cat_label_list clearfix">
                                <li><a href="http://www.datouwang.com/">ʱ��ŮЬ</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">������Ь</a></li>
                                <li><a href="http://www.datouwang.com/">������Ʒ</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">������Ь</a></li>
                                <li><a href="http://www.datouwang.com/">��ڵ�Ь</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">��װƤЬ</a></li>
                                <li><a href="http://www.datouwang.com/">ǳ�ڵ�Ь</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">��ʿ��Ь</a></li>
                                <li><a href="http://www.datouwang.com/">�и���Ь</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">�з���Ь</a></li>
                                <li><a href="http://www.datouwang.com/">���ʶ�ѥ</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">��ʿ��Ь</a></li>
                                <li><a href="http://www.datouwang.com/">��Ͳѥ</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">�߰�Ь</a></li>
                                <li><a href="http://www.datouwang.com/">����Ů��</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">˫���</a></li>
                                <li><a href="http://www.datouwang.com/">ŮʿǮ��</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">������</a></li>
                                <li><a href="http://www.datouwang.com/">��ƤŮ��</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">Ƥ��</a></li>
                                <li><a href="http://www.datouwang.com/">б��Ů��</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">Χ��</a></li>
                                <li><a href="http://www.datouwang.com/">б���а�</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">���Ƶ׼�</a></li>
                            </ul>
                            <div class="cat_brand">
                                <ul class="cat_slide_brand">
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/10.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/11.jpg" width="90" height="40" /></a>
                                    </li>
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/12.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/13.jpg" width="90" height="40" /></a>
                                    </li>
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/14.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/15.jpg" width="90" height="40" /></a>
                                    </li>
                                </ul>
                                <ul class="cat_slide_nav">
                                    <li>?</li>
                                    <li>?</li>
                                    <li>?</li>
                                </ul>
                            </div>
                        </div>
                        <div class="fl cat_banner">
                            <a class="fl banner-grid-b4" href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/27.jpg" /></a> <a class="fl banner-grid-b5"
                                    href="http://www.datouwang.com/">
                                    <img src="Themes/Skin_Default/images/29.jpg" /></a> <a class="fl banner-grid-b2"
                                        href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/25.jpg" /></a> <a class="fl banner-grid-b3"
                                            href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/26.jpg" /></a>
                        </div>
                        <ul class="fl cat_small_banner">
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/4.jpg" width="190" height="160" /></a></li>
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/5.jpg" width="190" height="160" /></a></li>
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/6.jpg" width="190" height="160" /></a></li>
                        </ul>
                    </div>
                    <div class="cat_pannel clearfix">
                        <div class="fl cat_detail grid_col_4">
                            <h3 class="cat_title">
                                ��è��ױ</h3>
                            <ul class="cat_label_list clearfix">
                                <li><a href="http://www.datouwang.com/">�沿����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">������װ</a></li>
                                <li><a href="http://www.datouwang.com/">��Ĥ</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">��Һ��˪</a></li>
                                <li><a href="http://www.datouwang.com/">���廤��</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">�۲�����</a></li>
                                <li><a href="http://www.datouwang.com/">��ױˮ</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">�沿����</a></li>
                                <li><a href="http://www.datouwang.com/">BB˪</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">��ʿ����</a></li>
                                <li><a href="http://www.datouwang.com/">���ͷ���</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">��ˮ</a></li>
                                <li><a href="http://www.datouwang.com/">����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">�ֲ�����</a></li>
                                <li><a href="http://www.datouwang.com/">���ݹ���</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">�ز�����</a></li>
                                <li><a href="http://www.datouwang.com/">����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">��ױ��װ</a></li>
                                <li><a href="http://www.datouwang.com/">жױ</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">ϴ����ԡ</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">������</a></li>
                                <li><a href="http://www.datouwang.com/">�ٷ�</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">Ⱦ���̷�</a></li>
                            </ul>
                            <div class="cat_brand">
                                <ul class="cat_slide_brand">
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/16.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/17.jpg" width="90" height="40" /></a>
                                    </li>
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/18.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/19.jpg" width="90" height="40" /></a>
                                    </li>
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/20.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/21.jpg" width="90" height="40" /></a>
                                    </li>
                                </ul>
                                <ul class="cat_slide_nav">
                                    <li>?</li>
                                    <li>?</li>
                                    <li>?</li>
                                </ul>
                            </div>
                        </div>
                        <div class="fl cat_banner">
                            <a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/30.jpg" /></a>
                        </div>
                        <ul class="fl cat_small_banner">
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/21jpg.jpg" width="190" height="160" /></a></li>
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/22.jpg" width="190" height="160" /></a></li>
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/23.jpg" width="190" height="160" /></a></li>
                        </ul>
                    </div>
                    <div class="cat_pannel clearfix">
                        <div class="fl cat_detail grid_col_5">
                            <h3 class="cat_title">
                                �ֻ�����</h3>
                            <ul class="cat_label_list clearfix">
                                <li><a href="http://www.datouwang.com/">�����ֻ�</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">�ʼǱ�</a></li>
                                <li><a href="http://www.datouwang.com/">˫��˫��</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">ƽ�����</a></li>
                                <li><a href="http://www.datouwang.com/">�����»�</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">̨ʽ��</a></li>
                                <li><a href="http://www.datouwang.com/">ǧԪ����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">DIY����</a></li>
                                <li><a href="http://www.datouwang.com/">��Լ����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">��ʾ��</a></li>
                                <li><a href="http://www.datouwang.com/">��os�ֻ�</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">��ӡ��</a></li>
                                <li><a href="http://www.datouwang.com/">�콢�ֻ�</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">·����</a></li>
                                <li><a href="http://www.datouwang.com/">�����ֻ�</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">���Ӵʵ�</a></li>
                                <li><a href="http://www.datouwang.com/">����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">������</a></li>
                                <li><a href="http://www.datouwang.com/">�ƶ���Դ</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">ƻ�����</a></li>
                                <li><a href="http://www.datouwang.com/">U��</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">�ƶ�Ӳ��</a></li>
                                <li><a href="http://www.datouwang.com/">��������</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">�������</a></li>
                            </ul>
                            <div class="cat_brand">
                                <ul class="cat_slide_brand">
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/10.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/11.jpg" width="90" height="40" /></a>
                                    </li>
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/12.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/13.jpg" width="90" height="40" /></a>
                                    </li>
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/14.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/15.jpg" width="90" height="40" /></a>
                                    </li>
                                </ul>
                                <ul class="cat_slide_nav">
                                    <li>?</li>
                                    <li>?</li>
                                    <li>?</li>
                                </ul>
                            </div>
                        </div>
                        <div class="fl cat_banner">
                            <a class="banner-grid-b1" href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/31.jpg" /></a> <a class="fl banner-grid-b2"
                                    href="http://www.datouwang.com/">
                                    <img src="Themes/Skin_Default/images/25.jpg" /></a> <a class="fl banner-grid-b3"
                                        href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/26.jpg" /></a>
                        </div>
                        <ul class="fl cat_small_banner">
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/4.jpg" width="190" height="160" /></a></li>
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/5.jpg" width="190" height="160" /></a></li>
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/6.jpg" width="190" height="160" /></a></li>
                        </ul>
                    </div>
                    <div class="cat_pannel clearfix">
                        <div class="fl cat_detail grid_col_6">
                            <h3 class="cat_title">
                                ��èĸӤ</h3>
                            <ul class="cat_label_list clearfix">
                                <li><a href="http://www.datouwang.com/">ţ�̷�</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">���̷�</a></li>
                                <li><a href="http://www.datouwang.com/">Ӥ����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">DHA</a></li>
                                <li><a href="http://www.datouwang.com/">ֽ���</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">��ƿ</a></li>
                                <li><a href="http://www.datouwang.com/">����ϴ��</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">�Ƴ�</a></li>
                                <li><a href="http://www.datouwang.com/">Ӥ����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">˯������</a></li>
                                <li><a href="http://www.datouwang.com/">����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">ȹ��</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">��ͯ����</a></li>
                                <li><a href="http://www.datouwang.com/">ͯװ</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">ͯЬ</a></li>
                                <li><a href="http://www.datouwang.com/">Ӥ�����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">���</a></li>
                                <li><a href="http://www.datouwang.com/">�綯ң��</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">ë�޲���</a></li>
                                <li><a href="http://www.datouwang.com/">�и�װ</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">�и���</a></li>
                                <li><a href="http://www.datouwang.com/">������</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">�����ڿ�</a></li>
                            </ul>
                            <div class="cat_brand">
                                <ul class="cat_slide_brand">
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/16.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/17.jpg" width="90" height="40" /></a>
                                    </li>
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/18.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/19.jpg" width="90" height="40" /></a>
                                    </li>
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/20.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/21.jpg" width="90" height="40" /></a>
                                    </li>
                                </ul>
                                <ul class="cat_slide_nav">
                                    <li>?</li>
                                    <li>?</li>
                                    <li>?</li>
                                </ul>
                            </div>
                        </div>
                        <div class="fl cat_banner">
                            <a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/32.jpg" /></a>
                        </div>
                        <ul class="fl cat_small_banner">
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/21jpg.jpg" width="190" height="160" /></a></li>
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/22.jpg" width="190" height="160" /></a></li>
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/23.jpg" width="190" height="160" /></a></li>
                        </ul>
                    </div>
                    <div class="cat_pannel clearfix">
                        <div class="fl cat_detail grid_col_7">
                            <h3 class="cat_title">
                                ʳƷ</h3>
                            <ul class="cat_label_list clearfix">
                                <li><a href="http://www.datouwang.com/">������</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">���޹�</a></li>
                                <li><a href="http://www.datouwang.com/">̨���</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">̩����</a></li>
                                <li><a href="http://www.datouwang.com/">������ʳ</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">���</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">ţ���</a></li>
                                <li><a href="http://www.datouwang.com/">�ǹ�</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">�ɿ���</a></li>
                                <li><a href="http://www.datouwang.com/">����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">���Ĺ�</a></li>
                                <li><a href="http://www.datouwang.com/">�̸���</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">�ɹ�</a></li>
                                <li><a href="http://www.datouwang.com/">�ն�</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">��ͷ</a></li>
                                <li><a href="http://www.datouwang.com/">��Ҷ</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">������</a></li>
                                <li><a href="http://www.datouwang.com/">ˮ��</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">�׾�</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">���Ѿ�</a></li>
                                <li><a href="http://www.datouwang.com/">�ƾ�</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">���</a></li>
                            </ul>
                            <div class="cat_brand">
                                <ul class="cat_slide_brand">
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/10.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/11.jpg" width="90" height="40" /></a>
                                    </li>
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/12.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/13.jpg" width="90" height="40" /></a>
                                    </li>
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/14.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/15.jpg" width="90" height="40" /></a>
                                    </li>
                                </ul>
                                <ul class="cat_slide_nav">
                                    <li>?</li>
                                    <li>?</li>
                                    <li>?</li>
                                </ul>
                            </div>
                        </div>
                        <div class="fl cat_banner">
                            <a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/33.jpg" /></a>
                        </div>
                        <ul class="fl cat_small_banner">
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/4.jpg" width="190" height="160" /></a></li>
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/5.jpg" width="190" height="160" /></a></li>
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/6.jpg" width="190" height="160" /></a></li>
                        </ul>
                    </div>
                    <div class="cat_pannel clearfix">
                        <div class="fl cat_detail grid_col_8">
                            <h3 class="cat_title">
                                ���õ���</h3>
                            <ul class="cat_label_list clearfix">
                                <li><a href="http://www.datouwang.com/">���ӻ�</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">�緹��</a></li>
                                <li><a href="http://www.datouwang.com/">��ˮ��</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����ˮ��</a></li>
                                <li><a href="http://www.datouwang.com/">ϴ�»�</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">��ˮ��</a></li>
                                <li><a href="http://www.datouwang.com/">����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">ե֭��</a></li>
                                <li><a href="http://www.datouwang.com/">������װ</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">������</a></li>
                                <li><a href="http://www.datouwang.com/">����ˮ��</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">ɨ�ػ�</a></li>
                                <li><a href="http://www.datouwang.com/">�յ�</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">�վ�����</a></li>
                                <li><a href="http://www.datouwang.com/">��ͥӰԺ</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">ů��ȡů</a></li>
                                <li><a href="http://www.datouwang.com/">��ͷ��</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">���뵶</a></li>
                                <li><a href="http://www.datouwang.com/">ȼ����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">�紵��</a></li>
                                <li><a href="http://www.datouwang.com/">������</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">��ԡ��</a></li>
                                <li><a href="http://www.datouwang.com/">4K����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">��ֱ����</a></li>
                            </ul>
                            <div class="cat_brand">
                                <ul class="cat_slide_brand">
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/16.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/17.jpg" width="90" height="40" /></a>
                                    </li>
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/18.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/19.jpg" width="90" height="40" /></a>
                                    </li>
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/20.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/21.jpg" width="90" height="40" /></a>
                                    </li>
                                </ul>
                                <ul class="cat_slide_nav">
                                    <li>?</li>
                                    <li>?</li>
                                    <li>?</li>
                                </ul>
                            </div>
                        </div>
                        <div class="fl cat_banner">
                            <a class="banner-grid-b1" href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/34.jpg" /></a> <a class="fl banner-grid-b2"
                                    href="http://www.datouwang.com/">
                                    <img src="Themes/Skin_Default/images/25.jpg" /></a> <a class="fl banner-grid-b3"
                                        href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/26.jpg" /></a>
                        </div>
                        <ul class="fl cat_small_banner">
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/21jpg.jpg" width="190" height="160" /></a></li>
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/22.jpg" width="190" height="160" /></a></li>
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/23.jpg" width="190" height="160" /></a></li>
                        </ul>
                    </div>
                    <div class="cat_pannel clearfix">
                        <div class="fl cat_detail grid_col_9">
                            <h3 class="cat_title">
                                ��è��װ</h3>
                            <ul class="cat_label_list clearfix">
                                <li><a href="http://www.datouwang.com/">�ƾ�</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">��ԡ</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">ɳ��</a></li>
                                <li><a href="http://www.datouwang.com/">���ز���</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">��ֽ</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">�ذ�</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">Ϳ��</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">�鷿</a></li>
                                <li><a href="http://www.datouwang.com/">ԡ��</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">�������</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">��̨</a></li>
                                <li><a href="http://www.datouwang.com/">��𹤾�</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">װ��</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">���</a></li>
                            </ul>
                            <div class="cat_brand">
                                <ul class="cat_slide_brand">
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/10.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/11.jpg" width="90" height="40" /></a>
                                    </li>
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/12.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/13.jpg" width="90" height="40" /></a>
                                    </li>
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/14.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/15.jpg" width="90" height="40" /></a>
                                    </li>
                                </ul>
                                <ul class="cat_slide_nav">
                                    <li>?</li>
                                    <li>?</li>
                                    <li>?</li>
                                </ul>
                            </div>
                        </div>
                        <div class="fl cat_banner">
                            <a class="banner-grid-b1" href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/35.jpg" /></a> <a class="fl banner-grid-b2"
                                    href="http://www.datouwang.com/">
                                    <img src="Themes/Skin_Default/images/25.jpg" /></a> <a class="fl banner-grid-b3"
                                        href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/26.jpg" /></a>
                        </div>
                        <ul class="fl cat_small_banner">
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/4.jpg" width="190" height="160" /></a></li>
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/5.jpg" width="190" height="160" /></a></li>
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/6.jpg" width="190" height="160" /></a></li>
                        </ul>
                    </div>
                    <div class="cat_pannel clearfix">
                        <div class="fl cat_detail grid_col_10">
                            <h3 class="cat_title">
                                �鱦����</h3>
                            <ul class="cat_label_list clearfix">
                                <li><a href="http://www.datouwang.com/">�鱦</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">�ƽ�</a></li>
                                <li><a href="http://www.datouwang.com/">��ʯ</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">���</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">�ʱ�</a></li>
                                <li><a href="http://www.datouwang.com/">��ʯ</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">��Ʒ</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">��׹</a></li>
                                <li><a href="http://www.datouwang.com/">��ָ</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">�б�</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">Ů��</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">��ʿ����</a></li>
                                <li><a href="http://www.datouwang.com/">̫����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">ZIPPO</a></li>
                                <li><a href="http://www.datouwang.com/">�۾�</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">��ʿ����</a></li>
                            </ul>
                            <div class="cat_brand">
                                <ul class="cat_slide_brand">
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/16.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/17.jpg" width="90" height="40" /></a>
                                    </li>
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/18.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/19.jpg" width="90" height="40" /></a>
                                    </li>
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/20.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/21.jpg" width="90" height="40" /></a>
                                    </li>
                                </ul>
                                <ul class="cat_slide_nav">
                                    <li>?</li>
                                    <li>?</li>
                                    <li>?</li>
                                </ul>
                            </div>
                        </div>
                        <div class="fl cat_banner">
                            <a class="banner-grid-b1" href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/36.jpg" /></a> <a class="fl banner-grid-b2"
                                    href="http://www.datouwang.com/">
                                    <img src="Themes/Skin_Default/images/25.jpg" /></a> <a class="fl banner-grid-b3"
                                        href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/26.jpg" /></a>
                        </div>
                        <ul class="fl cat_small_banner">
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/21jpg.jpg" width="190" height="160" /></a></li>
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/22.jpg" width="190" height="160" /></a></li>
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/23.jpg" width="190" height="160" /></a></li>
                        </ul>
                    </div>
                    <div class="cat_pannel clearfix">
                        <div class="fl cat_detail grid_col_11">
                            <h3 class="cat_title">
                                ����/��Ʒ</h3>
                            <ul class="cat_label_list clearfix">
                                <li><a href="http://www.datouwang.com/">����Ʒ��</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">��ϵƷ��</a></li>
                                <li><a href="http://www.datouwang.com/">ŷϵƷ��</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">��ϵƷ��</a></li>
                                <li><a href="http://www.datouwang.com/">����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">��������</a></li>
                                <li><a href="http://www.datouwang.com/">�ŵ�</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">װ����</a></li>
                                <li><a href="http://www.datouwang.com/">��ȫ����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">�����</a></li>
                                <li><a href="http://www.datouwang.com/">�����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">��̥</a></li>
                                <li><a href="http://www.datouwang.com/">��������</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">DVD����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">ϴ����</a></li>
                                <li><a href="http://www.datouwang.com/">GPS</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">��¼��</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">������</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">Ħ��װ��</a></li>
                            </ul>
                            <div class="cat_brand">
                                <ul class="cat_slide_brand">
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/10.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/11.jpg" width="90" height="40" /></a>
                                    </li>
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/12.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/13.jpg" width="90" height="40" /></a>
                                    </li>
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/14.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/15.jpg" width="90" height="40" /></a>
                                    </li>
                                </ul>
                                <ul class="cat_slide_nav">
                                    <li>?</li>
                                    <li>?</li>
                                    <li>?</li>
                                </ul>
                            </div>
                        </div>
                        <div class="fl cat_banner">
                            <a class="banner-grid-b1" href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/37.jpg" /></a> <a class="fl banner-grid-b2"
                                    href="http://www.datouwang.com/">
                                    <img src="Themes/Skin_Default/images/25.jpg" /></a> <a class="fl banner-grid-b3"
                                        href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/26.jpg" /></a>
                        </div>
                        <ul class="fl cat_small_banner">
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/4.jpg" width="190" height="160" /></a></li>
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/5.jpg" width="190" height="160" /></a></li>
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/6.jpg" width="190" height="160" /></a></li>
                        </ul>
                    </div>
                    <div class="cat_pannel clearfix">
                        <div class="fl cat_detail grid_col_12">
                            <h3 class="cat_title">
                                �ҷļ���</h3>
                            <ul class="cat_label_list clearfix">
                                <li><a href="http://www.datouwang.com/">������Ʒ</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">�ļ���</a></li>
                                <li><a href="http://www.datouwang.com/">�񶬱�</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">���ޱ�</a></li>
                                <li><a href="http://www.datouwang.com/">��˿��</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">��ͷ</a></li>
                                <li><a href="http://www.datouwang.com/">������</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">ë̺</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">��ͯ��Ʒ</a></li>
                                <li><a href="http://www.datouwang.com/">���촲Ʒ</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">������</a></li>
                                <li><a href="http://www.datouwang.com/">����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">ëԡ��</a></li>
                                <li><a href="http://www.datouwang.com/">����Ь</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">ɳ����</a></li>
                                <li><a href="http://www.datouwang.com/">ʮ����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">��̺</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">������</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">װ�λ�</a></li>
                                <li><a href="http://www.datouwang.com/">װ�ΰڼ�</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">������԰</a></li>
                            </ul>
                            <div class="cat_brand">
                                <ul class="cat_slide_brand">
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/16.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/17.jpg" width="90" height="40" /></a>
                                    </li>
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/18.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/19.jpg" width="90" height="40" /></a>
                                    </li>
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/20.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/21.jpg" width="90" height="40" /></a>
                                    </li>
                                </ul>
                                <ul class="cat_slide_nav">
                                    <li>?</li>
                                    <li>?</li>
                                    <li>?</li>
                                </ul>
                            </div>
                        </div>
                        <div class="fl cat_banner">
                            <a class="banner-grid-b1" href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/38.jpg" /></a> <a class="fl banner-grid-b2"
                                    href="http://www.datouwang.com/">
                                    <img src="Themes/Skin_Default/images/25.jpg" /></a> <a class="fl banner-grid-b3"
                                        href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/26.jpg" /></a>
                        </div>
                        <ul class="fl cat_small_banner">
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/21jpg.jpg" width="190" height="160" /></a></li>
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/22.jpg" width="190" height="160" /></a></li>
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/23.jpg" width="190" height="160" /></a></li>
                        </ul>
                    </div>
                    <div class="cat_pannel clearfix">
                        <div class="fl cat_detail grid_col_13">
                            <h3 class="cat_title">
                                ��èҽҩ</h3>
                            <ul class="cat_label_list clearfix">
                                <li><a href="http://www.datouwang.com/">�������</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">���</a></li>
                                <li><a href="http://www.datouwang.com/">ά����E</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">ά����C</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">������</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">�����Ĳ�</a></li>
                                <li><a href="http://www.datouwang.com/">�����ʷ�</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">�˲�</a></li>
                                <li><a href="http://www.datouwang.com/">��ԭ����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">ʯ���㶷</a></li>
                                <li><a href="http://www.datouwang.com/">����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">������</a></li>
                                <li><a href="http://www.datouwang.com/">������</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">���氲��</a></li>
                                <li><a href="http://www.datouwang.com/">��θ��ҩ</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">��éҩ��</a></li>
                                <li><a href="http://www.datouwang.com/">Ѫѹ��</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">�����۾�</a></li>
                                <li><a href="http://www.datouwang.com/">������</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">��Ȥ���</a></li>
                            </ul>
                            <div class="cat_brand">
                                <ul class="cat_slide_brand">
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/10.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/11.jpg" width="90" height="40" /></a>
                                    </li>
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/12.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/13.jpg" width="90" height="40" /></a>
                                    </li>
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/14.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/15.jpg" width="90" height="40" /></a>
                                    </li>
                                </ul>
                                <ul class="cat_slide_nav">
                                    <li>?</li>
                                    <li>?</li>
                                    <li>?</li>
                                </ul>
                            </div>
                        </div>
                        <div class="fl cat_banner">
                            <a class="banner-grid-b1" href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/39.jpg" /></a> <a class="fl banner-grid-b2"
                                    href="http://www.datouwang.com/">
                                    <img src="Themes/Skin_Default/images/25.jpg" /></a> <a class="fl banner-grid-b3"
                                        href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/26.jpg" /></a>
                        </div>
                        <ul class="fl cat_small_banner">
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/4.jpg" width="190" height="160" /></a></li>
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/5.jpg" width="190" height="160" /></a></li>
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/6.jpg" width="190" height="160" /></a></li>
                        </ul>
                    </div>
                    <div class="cat_pannel clearfix">
                        <div class="fl cat_detail grid_col_14">
                            <h3 class="cat_title">
                                �ӼҰٻ�</h3>
                            <ul class="cat_label_list clearfix">
                                <li><a href="http://www.datouwang.com/">���±�</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">�����;�</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">���</a></li>
                                <li><a href="http://www.datouwang.com/">������Ʒ</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">�ƾ�</a></li>
                                <li><a href="http://www.datouwang.com/">��������</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">��������</a></li>
                                <li><a href="http://www.datouwang.com/">�ϰ�</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">���¼�</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">��ԡͰ</a></li>
                                <li><a href="http://www.datouwang.com/">�����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����Ͱ</a></li>
                                <li><a href="http://www.datouwang.com/">������Ʒ</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">������Ʒ</a></li>
                                <li><a href="http://www.datouwang.com/">����ɡ</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">���һ�</a></li>
                                <li><a href="http://www.datouwang.com/">������Ʒ</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">ֽƷ</a></li>
                                <li><a href="http://www.datouwang.com/">����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">��޹����</a></li>
                                <li><a href="http://www.datouwang.com/">��������</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">������Ʒ</a></li>
                            </ul>
                            <div class="cat_brand">
                                <ul class="cat_slide_brand">
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/16.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/17.jpg" width="90" height="40" /></a>
                                    </li>
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/18.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/19.jpg" width="90" height="40" /></a>
                                    </li>
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/20.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/21.jpg" width="90" height="40" /></a>
                                    </li>
                                </ul>
                                <ul class="cat_slide_nav">
                                    <li>?</li>
                                    <li>?</li>
                                    <li>?</li>
                                </ul>
                            </div>
                        </div>
                        <div class="fl cat_banner">
                            <a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/40.jpg" /></a>
                        </div>
                        <ul class="fl cat_small_banner">
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/21jpg.jpg" width="190" height="160" /></a></li>
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/22.jpg" width="190" height="160" /></a></li>
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/23.jpg" width="190" height="160" /></a></li>
                        </ul>
                    </div>
                    <div class="cat_pannel clearfix">
                        <div class="fl cat_detail grid_col_15">
                            <h3 class="cat_title">
                                ��èͼ��</h3>
                            <ul class="cat_label_list clearfix">
                                <li><a href="http://www.datouwang.com/">С˵</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">��ʳ</a></li>
                                <li><a href="http://www.datouwang.com/">��ʷ</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">�������</a></li>
                                <li><a href="http://www.datouwang.com/">�ƻ�</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">��ѧ�ڽ�</a></li>
                                <li><a href="http://www.datouwang.com/">��ѧ</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">�ƾ���־</a></li>
                                <li><a href="http://www.datouwang.com/">����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">ͯ��</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">��־</a></li>
                                <li><a href="http://www.datouwang.com/">����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">�汾</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">����</a></li>
                                <li><a href="http://www.datouwang.com/">����</a></li>
                                <li class="second_label"><a href="http://www.datouwang.com/">��־</a></li>
                            </ul>
                            <div class="cat_brand">
                                <ul class="cat_slide_brand">
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/10.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/11.jpg" width="90" height="40" /></a>
                                    </li>
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/12.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/13.jpg" width="90" height="40" /></a>
                                    </li>
                                    <li><a href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/14.jpg" width="90" height="40" /></a> <a href="http://www.datouwang.com/">
                                            <img src="Themes/Skin_Default/images/15.jpg" width="90" height="40" /></a>
                                    </li>
                                </ul>
                                <ul class="cat_slide_nav">
                                    <li>?</li>
                                    <li>?</li>
                                    <li>?</li>
                                </ul>
                            </div>
                        </div>
                        <div class="fl cat_banner">
                            <a class="banner-grid-b1" href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/41.jpg" /></a> <a class="fl banner-grid-b2"
                                    href="http://www.datouwang.com/">
                                    <img src="Themes/Skin_Default/images/25.jpg" /></a> <a class="fl banner-grid-b3"
                                        href="http://www.datouwang.com/">
                                        <img src="Themes/Skin_Default/images/26.jpg" /></a>
                        </div>
                        <ul class="fl cat_small_banner">
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/4.jpg" width="190" height="160" /></a></li>
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/5.jpg" width="190" height="160" /></a></li>
                            <li><a href="http://www.datouwang.com/">
                                <img src="Themes/Skin_Default/images/6.jpg" width="190" height="160" /></a></li>
                        </ul>
                    </div>
                </div>
                <!--�Ҳ����ݽ���-->
            </div>
            
        </div>
        <script type="text/javascript">
            $(".cat_banner").hover(function () {
                $(this).find(".prev_pic,.next_pic").fadeTo("show", 0.2);
            }, function () {
                $(this).find(".prev_pic,.next_pic").hide();
            });
            $(".prev_pic,.next_pic").hover(function () {
                $(this).fadeTo("show", 0.5);
            }, function () {
                $(this).fadeTo("show", 0.2);
            });
            $(".cat_banner").slide({
                titCell: ".num ul",
                mainCell: ".cat_banner_pic",
                effect: "left",
                prevCell: ".prev_pic",
                nextCell: ".next_pic",
                autoPlay: true,
                interTime: 3000,
                delayTime: 500,
                autoPage: true
            });
            $(".cat_small_banner li").hover(function () {
                $(this).animate({ "left": -5 }, 200);
            }, function () {
                $(this).animate({ "left": 0 }, 200);
            });
            $(".cat_brand").slide({
                titCell: ".cat_slide_nav li",
                mainCell: ".cat_slide_brand",
                effect: "left",
                autoPlay: true,
                interTime: 3000,
                delayTime: 700
            });
            $("#tmall_nav").slide({
                titCell: ".cate_nav li",
                mainCell: ".tmall_cat_content",
                autoPlay: true,
                interTime: 7400,
                delayTime: 0
            });
        </script>
		<div class="tsBottom_right fr">
                <!-- �¾��� Start-->
                <div class="dropdown" id="dropdown">
                    <dl id="drop1" class="">
                        <dt><a href="javascript:void(0)" id="q0" class=""><b id="d0"></b><strong class="sh">
                            Ʒ�Ƶ���</strong></a></dt>
                        <dd id="w0" class="d0">
                            <strong>Ʒ�Ƶ���</strong>
                            <p>
                                �ڱ����û��̳�������Ʒ�����б���˾����ȫ�̼�ܣ�ͬʱ��֧���ķ�ʽҲ�ɲ���֧�����������ס�</p>
                            <div class="extra">
                            </div>
                        </dd>
                    </dl>
                    <dl id="drop2">
                        <dt><a href="javascript:void(0)" id="q1" class="dd"><b id="d1"></b><strong class="sh">
                            ���������</strong></a></dt>
                        <dd id="w1">
                            <strong>���������</strong>
                            <p>
                                ���Ǳ����û��̳ǻ�Ա�������ܣ������ֽ�ƫԶ�ĵ������⣬�����վ��ʾ����������߿ͷ���ѯ��</p>
                            <div class="extra">
                            </div>
                        </dd>
                    </dl>
                    <dl id="drop3">
                        <dt><a href="javascript:void(0)" id="q2" class="ee"><b id="d2"></b><strong class="sh">
                            200%����</strong> </a></dt>
                        <dd id="w2">
                            <strong>200%����</strong>
                            <p>
                                �ͻ���ʱ֧���ɹ�������û�����κδ������ǽ�100%ȫ���˿�˻����ͻ�ָ���ʻ��������ͻ���Ա���(����ʱ�����ֿ�)��ͬʱ���Ϳͻ���Э������ʱ�䣬���������������ԭ����������200%���⡣</p>
                            <div class="extra">
                            </div>
                        </dd>
                    </dl>
                    <div class="clear">
                    </div>
                </div>
                <!-- //�¾��� End-->
                <!-- ���¹��� Start-->
                <div class="newstw">
                    <ul class="newstw_top">
                        <li id="a0" class="aa" onmouseover="tab('a','b',0,2,'aa','bb')"><a>���¹���</a></li>
                        <li id="a1" class="bb" onmouseover="tab('a','b',1,2,'aa','bb')"><a>��������</a></li>
                    </ul>
                    <div class="newstw_con">
                        <div class="newcontain" id="b0" style="display: block;">
                            <ShopNum1:AnnouncementNewList ID="AnnouncementNewList" runat="server" SkinFilename="AnnouncementNewList.ascx" />
                        </div>
                        <div class="newcontain" id="b1" style="display: none;">
                            <ShopNum1:ArticleNewList ID="ArticleNewList" runat="server" SkinFilename="ArticleNewList.ascx" />
                        </div>
                    </div>
                </div>
                <!-- //���¹��� End-->
                <!-- �Ƽ�Ʒ�� Start-->
                <div class="menber">
                    <div class="menber_top">
                        <span class="huy">�Ƽ�Ʒ��</span> <a href="BrandDetail.aspx" class="more">����</a>
                    </div>
                    <div class="login1">
                        <ShopNum1:DeBrandList ID="DeBrandList1" runat="server" SkinFilename="DeBrandList1.ascx" />
                    </div>
                </div>
                <!--//�Ƽ�Ʒ�� End-->
            </div>
    </div>
    <!-- ���� ���� -->
    <ShopNum1:DefaultControl ID="DefaultControl" runat="server" />
    <!--//main end-->
    <!--foot start-->
    <!-- #include file="foot1.aspx" -->
    <!--foot end-->
    <!--js-->
    <script src="/js/load.js" type="text/javascript"></script>
    <script type="text/javascript" charset="utf-8">
        $(function () {
            $("#content img:not([class='imghdp'])").lazyload({ placeholder: "/ImgUpload/noImg.jpg" });
            $("img").each(function () { $(this).attr("src", $(this).attr("original")); });
        });
    </script>
    </form>
</body>
</html>
