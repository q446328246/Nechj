<script src="Themes/Skin_Default/js/jquerycrums.js" type="text/javascript"></script>
<!--foot Start-->
<div style="z-index: 1">
    <!--底部帮助中心 Start-->
    <div class="lmf_all_foot" style="display: none;">
        <div class="lmf_all_foot_con">
            <ShopNum1:HelpListButtom ID="HelpListButtom2" ShowCount="6" runat="server" SkinFilename="HelpListButtom.ascx" />
            <div class="lmf_all_foot_adimg" style="display: none;">
                <img src="Themes/Skin_Default/Images/bottm_10.jpg" />
            </div>
        </div>
    </div>
    <!--//底部帮助中心 End-->
    <!--底部图片链接及版权信息 Start-->
    <div class="footer_info">
        <ShopNum1:FootControl ID="FootControl1" runat="server" />
    </div>
    <!--//底部图片链接及版权信息 End-->
    <!--底部在线客服 Start-->
    <%--    <ShopNum1:OnLineFootService ID="OnLineFootService" runat="server" SkinFilename="OnLineFootService.ascx"
        ShowCount="5" />--%>
    <!--//底部在线客服 End-->
</div>
<!--foot End-->
<!--返回顶部 Start-->
<div id="fixed-bottom" onclick="pageScroll()" style="display: none;" onmouseover="ChangeImageIn()"
    onmouseout="ChangeImageOut()">
    <img id="fixed-bottom_zhiding" class="back_top" src="Themes/Skin_Default/Images/myzhiding.png" />
</div>
<script type="text/javascript">
    function pageScroll() {
        window.scrollBy(0, -1000000);
    }
</script>
<script type="text/javascript">
    $(document).ready(function () {

        jQuery.fn.extend({

            //鼠标滑过二维码显示隐藏
            MouseShow: function (item1, item2) {
                if (this.length <= 0) {
                    return false;
                }
                var main = this;
                return main.bind({
                    mouseover: function (e) {
                        item1.show();
                        item2.show();
                    },
                    mouseout: function (e) {
                        item1.hide();
                        item2.hide();
                    }
                });

            },

            //鼠标滑过图片背景更换
            ChangeImg: function () {
                if (this.length <= 0) {
                    return false;
                }
                var main = this;
                return main.bind({
                    mouseover: function (e) {
                        var original = $(this).attr('src');
                        var nowSrc = original.substring(0, original.length - 4) + 1 + '.png';
                        $(this).attr('src', nowSrc);
                    },
                    mouseout: function (e) {
                        var original = $(this).attr('src');
                        var nowSrc = original.substring(0, original.length - 5) + '.png';
                        $(this).attr('src', nowSrc);
                    }
                });
            }
        });
        //页面加载时在底部显示
        //    var leftWid =($(document).width())/2+605;
        //   $('#fixed-weixin').css('left',leftWid);

        //弹框建议
        $('div.jianyi').bind({
            click: function () {
                $('.PopSuggest').show();
                $('.LayerMask').show();
            }
        });
        $('a.close ').bind({
            click: function () {
                $('.PopSuggest').hide();
                $('.LayerMask').hide();
            }
        });

        //过渡层
        $('.TransitionLayer1').bind({
            mouseover: function () {
                $('.ShouJi_erwei').show();
            }
        });
        //过渡层
        $('.TransitionLayer2').bind({
            mouseover: function () {
                $('.erwei').show();
            }
        });
        //鼠标滑过二维码显示隐藏
        $('div.ShouJi').MouseShow($('div.ShouJi_erwei'), $('div.TransitionLayer1'));
        $('div.MicroInfo').MouseShow($('div.erwei'), $('div.TransitionLayer2'));

        $('div.ShouJi_erwei').MouseShow($('div.ShouJi_erwei'), $('div.TransitionLayer1'));
        $('div.erwei').MouseShow($('div.erwei'), $('div.TransitionLayer2'));

        $('div.TransitionLayer1').MouseShow($('div.ShouJi_erwei'), $('div.TransitionLayer1'));
        $('div.TransitionLayer2').MouseShow($('div.erwei'), $('div.TransitionLayer2'));
        //鼠标滑过图片背景更换
        $('div.js-change-img img').ChangeImg();

    });
</script>
