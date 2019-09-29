<%@ Page Language="C#" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <ShopNum1:Meto ID="meto1" runat="server" Type="1" SkinFilename="Meto.ascx" />
    <link href="Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />
    <script src="Js/jquery-1.6.2.min.js" type="text/javascript"></script>
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
</head>
<body>
    <form id="form1" runat="server">
    <!--head Start-->
    <!-- #include file="headShop.aspx" -->
    <!--//head End-->
    <!--main Start-->
    <div class="FlowCat_cont clearfix">
        <div class="warp_site">
            <a href="Default.aspx">首页</a> 》<a href="#">分类页面</a>
        </div>
        <div class="supply_page">
            <%--信息分类列表--%>
            <div class="supply_cates">
                <div class="sup_title">
                    <span class="fl">信息分类列表</span> <a href="#" class="sup_more">更多>></a>
                </div>
                <div class="sup_lists">
                    <ul>
                        <li><b>商务服务</b><a href="#">对讲机</a>|<a href="#">通信配件</a>|<a href="#">电话机</a>|<a href="#">寻呼机</a>|<a
                            href="#">通信电缆</a>|<a href="#">移动电话</a>|<a href="#">电话磁卡</a>|<a href="#">集团电话</a>|<a
                                href="#">网络通信产品</a>|<a href="#">相关产品</a>|<a href="#">无线通信</a> </li>
                        <li><b>常用信息</b><a href="#">砖瓦</a>|<a href="#">特种建材</a>|<a href="#">厨房设备</a>|<a href="#">墙体材料</a>|<a
                            href="#">建材及相关设备</a>|<a href="#">门窗</a>|<a href="#">施工材料</a>|<a href="#">壁纸</a>|<a
                                href="#">建筑玻璃</a>|<a href="#">建筑陶瓷</a> </li>
                        <li><b>求职简历</b><a href="#">石油及制品</a>|<a href="#">天然气、煤气</a>|<a href="#">能源产品代理</a>|<a
                            href="#">寻呼机</a>|<a href="#">通信电缆</a>|<a href="#">移动电话</a>|<a href="#">发电机</a>|<a
                                href="#">能源项目合作 </a>|<a href="#">太阳能 </a></li>
                        <li><b>同城活动</b><a href="#">对讲机</a>|<a href="#">通信配件</a>|<a href="#">电话机</a>|<a href="#">寻呼机</a>|<a
                            href="#">通信电缆</a>|<a href="#">移动电话</a>|<a href="#">电话磁卡</a>|<a href="#">集团电话</a>|<a
                                href="#">网络通信产品</a>|<a href="#">相关产品</a>|<a href="#">无线通信</a>|<a href="#">施工材料</a>|<a
                                    href="#">壁纸</a>|<a href="#">建筑玻璃</a>|<a href="#">建筑陶瓷</a> </li>
                    </ul>
                </div>
            </div>
            <%--广告--%>
            <div class="supply_img">
                <a href="#">
                    <img src="Themes/Skin_Default/Images/lmf_ad01.jpg" width="1190" height="90" /></a>
            </div>
            <%--信息列表--%>
            <div class="message_lists clearfix">
                <div class="mess_box clearfix">
                    <div class="th5">
                        <span class="redpic"></span><span class="fl">房屋信息</span><a href="#" class="more_red">我要发布>></a></div>
                    <div class="mess_list">
                        <div class="mess_conts">
                            <a href="#" class="messpic">
                                <img src="Themes/Skin_Default/Images/supply_pic.jpg" width="95" height="75" /></a>
                            <div class="messname">
                                <p>
                                    <a href="#">酷睿i7笔记本优惠转让</a></p>
                                <div class="suname">
                                    <a href="#">联想Y470N-IFI 酷睿i5 2410M 2.3GHz双核心/四线程 可睿频加速至2.9GHz 内存 4GB 硬…</a></div>
                            </div>
                        </div>
                        <div class="mess_li">
                            <ul>
                                <li><span class="spantit">【求购】</span><a href="#">集装箱，集装箱活动房，特种集装</a><span class="spantime">[12-22]</span></li>
                                <li><span class="spantit">【求购】</span><a href="#">集装箱，集装箱活动房，特种集装</a><span class="spantime">[12-22]</span></li>
                                <li><span class="spantit">【求购】</span><a href="#">集装箱，集装箱活动房，特种集装</a><span class="spantime">[12-22]</span></li>
                                <li><span class="spantit">【求购】</span><a href="#">集装箱，集装箱活动房，特种集装</a><span class="spantime">[12-22]</span></li>
                            </ul>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                </div>
                <div class="mess_box clearfix">
                    <div class="th5">
                        <span class="redpic"></span><span class="fl">交友信息</span><a href="#" class="more_red">我要发布>></a></div>
                    <div class="mess_list">
                        <div class="mess_conts">
                            <a href="#" class="messpic">
                                <img src="Themes/Skin_Default/Images/supply_pic.jpg" width="95" height="75" /></a>
                            <div class="messname">
                                <p>
                                    <a href="#">酷睿i7笔记本优惠转让</a></p>
                                <div class="suname">
                                    <a href="#">联想Y470N-IFI 酷睿i5 2410M 2.3GHz双核心/四线程 可睿频加速至2.9GHz 内存 4GB 硬…</a></div>
                            </div>
                        </div>
                        <div class="mess_li">
                            <ul>
                                <li><span class="spantit">【求购】</span><a href="#">集装箱，集装箱活动房，特种集装</a><span class="spantime">[12-22]</span></li>
                                <li><span class="spantit">【求购】</span><a href="#">集装箱，集装箱活动房，特种集装</a><span class="spantime">[12-22]</span></li>
                                <li><span class="spantit">【求购】</span><a href="#">集装箱，集装箱活动房，特种集装</a><span class="spantime">[12-22]</span></li>
                                <li><span class="spantit">【求购】</span><a href="#">集装箱，集装箱活动房，特种集装</a><span class="spantime">[12-22]</span></li>
                            </ul>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                </div>
                <div class="mess_box last_box clearfix">
                    <div class="th5">
                        <span class="redpic"></span><span class="fl">宠物信息</span><a href="#" class="more_red">我要发布>></a></div>
                    <div class="mess_list">
                        <div class="mess_conts">
                            <a href="#" class="messpic">
                                <img src="Themes/Skin_Default/Images/supply_pic.jpg" width="95" height="75" /></a>
                            <div class="messname">
                                <p>
                                    <a href="#">酷睿i7笔记本优惠转让</a></p>
                                <div class="suname">
                                    <a href="#">联想Y470N-IFI 酷睿i5 2410M 2.3GHz双核心/四线程 可睿频加速至2.9GHz 内存 4GB 硬…</a></div>
                            </div>
                        </div>
                        <div class="mess_li">
                            <ul>
                                <li><span class="spantit">【求购】</span><a href="#">集装箱，集装箱活动房，特种集装</a><span class="spantime">[12-22]</span></li>
                                <li><span class="spantit">【求购】</span><a href="#">集装箱，集装箱活动房，特种集装</a><span class="spantime">[12-22]</span></li>
                                <li><span class="spantit">【求购】</span><a href="#">集装箱，集装箱活动房，特种集装</a><span class="spantime">[12-22]</span></li>
                                <li><span class="spantit">【求购】</span><a href="#">集装箱，集装箱活动房，特种集装</a><span class="spantime">[12-22]</span></li>
                            </ul>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                </div>
            </div>
            <div class="supply_img">
                <a href="#">
                    <img src="Themes/Skin_Default/Images/supply03.jpg" width="1190" height="90" /></a>
            </div>
            <div class="message_lists clearfix">
                <div class="mess_box clearfix">
                    <div class="th5">
                        <span class="redpic"></span><span class="fl">票务信息</span><a href="#" class="more_red">我要发布>></a></div>
                    <div class="mess_list">
                        <div class="mess_conts">
                            <a href="#" class="messpic">
                                <img src="Themes/Skin_Default/Images/supply_pic.jpg" width="95" height="75" /></a>
                            <div class="messname">
                                <p>
                                    <a href="#">酷睿i7笔记本优惠转让</a></p>
                                <div class="suname">
                                    <a href="#">联想Y470N-IFI 酷睿i5 2410M 2.3GHz双核心/四线程 可睿频加速至2.9GHz 内存 4GB 硬…</a></div>
                            </div>
                        </div>
                        <div class="mess_li">
                            <ul>
                                <li><span class="spantit">【求购】</span><a href="#">集装箱，集装箱活动房，特种集装</a><span class="spantime">[12-22]</span></li>
                                <li><span class="spantit">【求购】</span><a href="#">集装箱，集装箱活动房，特种集装</a><span class="spantime">[12-22]</span></li>
                                <li><span class="spantit">【求购】</span><a href="#">集装箱，集装箱活动房，特种集装</a><span class="spantime">[12-22]</span></li>
                                <li><span class="spantit">【求购】</span><a href="#">集装箱，集装箱活动房，特种集装</a><span class="spantime">[12-22]</span></li>
                            </ul>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                </div>
                <div class="mess_box clearfix">
                    <div class="th5">
                        <span class="redpic"></span><span class="fl">活动信息</span><a href="#" class="more_red">我要发布>></a></div>
                    <div class="mess_list">
                        <div class="mess_conts">
                            <a href="#" class="messpic">
                                <img src="Themes/Skin_Default/Images/supply_pic.jpg" width="95" height="75" /></a>
                            <div class="messname">
                                <p>
                                    <a href="#">酷睿i7笔记本优惠转让</a></p>
                                <div class="suname">
                                    <a href="#">联想Y470N-IFI 酷睿i5 2410M 2.3GHz双核心/四线程 可睿频加速至2.9GHz 内存 4GB 硬…</a></div>
                            </div>
                        </div>
                        <div class="mess_li">
                            <ul>
                                <li><span class="spantit">【求购】</span><a href="#">集装箱，集装箱活动房，特种集装</a><span class="spantime">[12-22]</span></li>
                                <li><span class="spantit">【求购】</span><a href="#">集装箱，集装箱活动房，特种集装</a><span class="spantime">[12-22]</span></li>
                                <li><span class="spantit">【求购】</span><a href="#">集装箱，集装箱活动房，特种集装</a><span class="spantime">[12-22]</span></li>
                                <li><span class="spantit">【求购】</span><a href="#">集装箱，集装箱活动房，特种集装</a><span class="spantime">[12-22]</span></li>
                            </ul>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                </div>
                <div class="mess_box last_box clearfix">
                    <div class="th5">
                        <span class="redpic"></span><span class="fl">美食信息</span><a href="#" class="more_red">我要发布>></a></div>
                    <div class="mess_list">
                        <div class="mess_conts">
                            <a href="#" class="messpic">
                                <img src="Themes/Skin_Default/Images/supply_pic.jpg" width="95" height="75" /></a>
                            <div class="messname">
                                <p>
                                    <a href="#">酷睿i7笔记本优惠转让</a></p>
                                <div class="suname">
                                    <a href="#">联想Y470N-IFI 酷睿i5 2410M 2.3GHz双核心/四线程 可睿频加速至2.9GHz 内存 4GB 硬…</a></div>
                            </div>
                        </div>
                        <div class="mess_li">
                            <ul>
                                <li><span class="spantit">【求购】</span><a href="#">集装箱，集装箱活动房，特种集装</a><span class="spantime">[12-22]</span></li>
                                <li><span class="spantit">【求购】</span><a href="#">集装箱，集装箱活动房，特种集装</a><span class="spantime">[12-22]</span></li>
                                <li><span class="spantit">【求购】</span><a href="#">集装箱，集装箱活动房，特种集装</a><span class="spantime">[12-22]</span></li>
                                <li><span class="spantit">【求购】</span><a href="#">集装箱，集装箱活动房，特种集装</a><span class="spantime">[12-22]</span></li>
                            </ul>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                </div>
            </div>
            <div class="supply_img">
                <a href="#">
                    <img src="Themes/Skin_Default/Images/supply02.jpg" width="1190" height="90" /></a>
            </div>
            <div class="message_lists clearfix">
                <div class="mess_box clearfix">
                    <div class="th5">
                        <span class="redpic"></span><span class="fl">购物信息</span><a href="#" class="more_red">我要发布>></a></div>
                    <div class="mess_list">
                        <div class="mess_conts">
                            <a href="#" class="messpic">
                                <img src="Themes/Skin_Default/Images/supply_pic.jpg" width="95" height="75" /></a>
                            <div class="messname">
                                <p>
                                    <a href="#">酷睿i7笔记本优惠转让</a></p>
                                <div class="suname">
                                    <a href="#">联想Y470N-IFI 酷睿i5 2410M 2.3GHz双核心/四线程 可睿频加速至2.9GHz 内存 4GB 硬…</a></div>
                            </div>
                        </div>
                        <div class="mess_li">
                            <ul>
                                <li><span class="spantit">【求购】</span><a href="#">集装箱，集装箱活动房，特种集装</a><span class="spantime">[12-22]</span></li>
                                <li><span class="spantit">【求购】</span><a href="#">集装箱，集装箱活动房，特种集装</a><span class="spantime">[12-22]</span></li>
                                <li><span class="spantit">【求购】</span><a href="#">集装箱，集装箱活动房，特种集装</a><span class="spantime">[12-22]</span></li>
                                <li><span class="spantit">【求购】</span><a href="#">集装箱，集装箱活动房，特种集装</a><span class="spantime">[12-22]</span></li>
                            </ul>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                </div>
                <div class="mess_box clearfix">
                    <div class="th5">
                        <span class="redpic"></span><span class="fl">二手市场信息</span><a href="#" class="more_red">我要发布>></a></div>
                    <div class="mess_list">
                        <div class="mess_conts">
                            <a href="#" class="messpic">
                                <img src="Themes/Skin_Default/Images/supply_pic.jpg" width="95" height="75" /></a>
                            <div class="messname">
                                <p>
                                    <a href="#">酷睿i7笔记本优惠转让</a></p>
                                <div class="suname">
                                    <a href="#">联想Y470N-IFI 酷睿i5 2410M 2.3GHz双核心/四线程 可睿频加速至2.9GHz 内存 4GB 硬…</a></div>
                            </div>
                        </div>
                        <div class="mess_li">
                            <ul>
                                <li><span class="spantit">【求购】</span><a href="#">集装箱，集装箱活动房，特种集装</a><span class="spantime">[12-22]</span></li>
                                <li><span class="spantit">【求购】</span><a href="#">集装箱，集装箱活动房，特种集装</a><span class="spantime">[12-22]</span></li>
                                <li><span class="spantit">【求购】</span><a href="#">集装箱，集装箱活动房，特种集装</a><span class="spantime">[12-22]</span></li>
                                <li><span class="spantit">【求购】</span><a href="#">集装箱，集装箱活动房，特种集装</a><span class="spantime">[12-22]</span></li>
                            </ul>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                </div>
                <div class="mess_box last_box clearfix">
                    <div class="th5">
                        <span class="redpic"></span><span class="fl">时尚信息</span><a href="#" class="more_red">我要发布>></a></div>
                    <div class="mess_list">
                        <div class="mess_conts">
                            <a href="#" class="messpic">
                                <img src="Themes/Skin_Default/Images/supply_pic.jpg" width="95" height="75" /></a>
                            <div class="messname">
                                <p>
                                    <a href="#">酷睿i7笔记本优惠转让</a></p>
                                <div class="suname">
                                    <a href="#">联想Y470N-IFI 酷睿i5 2410M 2.3GHz双核心/四线程 可睿频加速至2.9GHz 内存 4GB 硬…</a></div>
                            </div>
                        </div>
                        <div class="mess_li">
                            <ul>
                                <li><span class="spantit">【求购】</span><a href="#">集装箱，集装箱活动房，特种集装</a><span class="spantime">[12-22]</span></li>
                                <li><span class="spantit">【求购】</span><a href="#">集装箱，集装箱活动房，特种集装</a><span class="spantime">[12-22]</span></li>
                                <li><span class="spantit">【求购】</span><a href="#">集装箱，集装箱活动房，特种集装</a><span class="spantime">[12-22]</span></li>
                                <li><span class="spantit">【求购】</span><a href="#">集装箱，集装箱活动房，特种集装</a><span class="spantime">[12-22]</span></li>
                            </ul>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--//main End-->
    <!--foot Start-->
    <!-- #include file="foot1.aspx" -->
    <!--//foot End-->
    </form>
</body>
</html>
