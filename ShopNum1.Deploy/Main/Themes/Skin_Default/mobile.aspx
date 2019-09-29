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
    <script type="text/javascript">        window.scrollTo(0, 0);
        $(function () {
            var tasli = $(".categoryn ul").find(".iten:gt(5)");
            tasli.hide();
            $(".categoryn").hover(function () {
                $(this).find(".iten:lt(20)").show();
            }, function () {
                tasli.hide();
            });
        })
    
    </script>
    <script type="text/javascript">

        window.onerror = function () { return true; }
    </script>
    <script>
<!--
        function setTab(name, cursel, n) {
            for (i = 1; i <= n; i++) {
                var menu = document.getElementById(name + i); /* zzjs1 */
                var con = document.getElementById("con_" + name + "_" + i); /* con_zzjs_1 */
                menu.className = i == cursel ? "hover" : ""; /*��Ŀ���� �Ⱥ�����*/
                con.style.display = i == cursel ? "block" : "none";
            }
        }
//-->
    </script>
</head>
<body onload="init();">
    <form id="from1" runat="server">
    <div class="mobile_all_bg">
        <div class="mobile_top">
        </div>
        <div class="mobile_ban_bg">
            <div class="mobile_width">
                <div class="mobile_ban">
                    <div id="menubox">
                        <!--��ʽ1 ����ѡ�-->
                        <ul>
                            <li id="zzjs1" onmousemove="setTab('zzjs',1,6)" class="hover">
                                <img src="Themes/Skin_Default/Images/mobile/andior_btn.png" /></li>
                            <li id="zzjs2" onmousemove="setTab('zzjs',2,6)">
                                <img src="Themes/Skin_Default/Images/mobile/iphone_btn.png" /></li>
                        </ul>
                    </div>
                    <div id="conten">
                        <div class="www_zzjs_net_show" id="con_zzjs_1">
                            <div class="mob_banimg fl">
                                <div class="mob_ban1 fl">
                                    <img src="Themes/Skin_Default/Images/mobile/andior02.png" />
                                </div>
                                <div class="mob_ban2 fl">
                                    <img src="Themes/Skin_Default/Images/mobile/andior01.png" />
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="mob_bancon fr">
                                <div class="mob_ban3">
                                    <img src="Themes/Skin_Default/Images/mobile/andior_icon.png" />
                                </div>
                                <div class="mob_ew fl">
                                    <img src="Themes/Skin_Default/Images/mobile/erweima.jpg" />
                                </div>
                                <div class="mob_se fl">
                                    <div class="mob_searchs">
                                        <div class="mob_searchtext">
                                            ʹ���ֻ������ֱ�ӷ��ʣ�</div>
                                        <div class="mob_search">
                                            <a href="http://wap.t.com/android_app.apk">http://wap.t.com/android_app.apk</a>
                                        </div>
                                    </div>
                                    <div class="mob_sm">
                                        ɨ���ά�밲װ�����鿪��wifi�����أ�</div>
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="www_zzjs_net_show" id="con_zzjs_2">
                            <div class="mob_banimg fl">
                                <div class="mob_ban1 fl">
                                    <img src="Themes/Skin_Default/Images/mobile/andior02.png" />
                                </div>
                                <div class="mob_ban2 fl">
                                    <img src="Themes/Skin_Default/Images/mobile/andior01.png" />
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="mob_bancon fr">
                                <div class="mob_ban3">
                                    <img src="Themes/Skin_Default/Images/mobile/iphone_icon.png" />
                                </div>
                                <div class="mob_ew fl">
                                    <img src="Themes/Skin_Default/Images/mobile/erweima1.jpg" />
                                </div>
                                <div class="mob_se fl">
                                    <div class="mob_searchs">
                                        <div class="mob_searchtext">
                                            ʹ���ֻ������ֱ�ӷ��ʣ�</div>
                                        <div class="mob_search">
                                            <a href="#">δ���ţ�</a>
                                        </div>
                                    </div>
                                    <div class="mob_sm">
                                        ɨ���ά�밲װ�����鿪��wifi�����أ�</div>
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="mobile_main">
            <div class="mob_floor mob_floor1">
                <div class="mobile_width">
                    <div class="mobfloor_l mobfloor_l1 fl">
                        <h1>
                            ��Ʒ����</h1>
                        <div class="mobfloor_text">
                            ������Ʒ������������ָ�ɼ�</div>
                    </div>
                    <div class="mobfloor_r fr">
                        <img src="Themes/Skin_Default/Images/mobile/spfl.jpg" /></div>
                    <div class="clear">
                    </div>
                </div>
            </div>
            <div class="mob_floors mob_floor2">
                <div class="mobile_width">
                    <div class="mobfloors_l fl">
                        <img src="Themes/Skin_Default/Images/mobile/wdsc_icon.jpg" />
                    </div>
                    <div class="mobfloors_r mobfloors_r1 fr">
                        <h1>
                            �ҵ��̳�</h1>
                        <div class="mobfloor_text">
                            ��������Ϣ������ ��ʱ���һ������</div>
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </div>
            <div class="mob_floor mob_floor3">
                <div class="mobile_width">
                    <div class="mobfloor_l mobfloor_l2 fl">
                        <h1>
                            ���ﳵ</h1>
                        <div class="mobfloor_text">
                            �����򵥣��ֻ�֧�������� ����֧�����ƶ���ȫ֧�����ܣ��������֧��</div>
                    </div>
                    <div class="mobfloor_r fr">
                        <img src="Themes/Skin_Default/Images/mobile/gwc_icon.jpg" /></div>
                    <div class="clear">
                    </div>
                </div>
            </div>
            <div class="mob_floors mob_floor4">
                <div class="mobile_width">
                    <div class="mobfloors_l fl">
                        <img src="Themes/Skin_Default/Images/mobile/znxx_icon.jpg" />
                    </div>
                    <div class="mobfloors_r mobfloors_r2 fr">
                        <h1>
                            վ����Ϣ</h1>
                        <div class="mobfloor_text">
                            ��˽�ţ� ѡ�γ̣� ��ʱ��س��칵ͨ</div>
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </div>
            <div class="mob_floor mob_floor5">
                <div class="mobile_width">
                    <div class="mobfloor_l mobfloor_l3 fl">
                        <h1>
                            �ҵĶ���</h1>
                        <div class="mobfloor_text">
                            ֻ��Ĵָ������������Ʒ��������ǰ �µ������㡢�����</div>
                    </div>
                    <div class="mobfloor_r fr">
                        <img src="Themes/Skin_Default/Images/mobile/wddd_icon.jpg" /></div>
                    <div class="clear">
                    </div>
                </div>
            </div>
            <div class="mob_floors mob_floor6">
                <div class="mobile_width">
                    <div class="mobfloors_l fl">
                        <img src="Themes/Skin_Default/Images/mobile/wodsc.jpg" />
                    </div>
                    <div class="mobfloors_r mobfloors_r3 fr">
                        <h1>
                            �ҵ��ղ�</h1>
                        <div class="mobfloor_text">
                            ϲ������Ь��ϲ��T��������ϲ������Ʒ���Ž��ղؼа�</div>
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </div>
        </div>
        <div class="mobile_foot">
            <div class="mobile_width">
                <ShopNum1:FootControl ID="FootCacheControl1" runat="server" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
