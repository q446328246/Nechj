
<script src="Themes/Skin_Default/js/jquerycrums.js" type="text/javascript"></script>
<!--foot Start-->
<div>
    <!--底部帮助中心 Start-->
    <div class="lmf_all_foot">
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
    <ShopNum1:OnLineFootService ID="OnLineFootService" runat="server" SkinFilename="OnLineFootService.ascx"
        ShowCount="5" />
    <!--//底部在线客服 End-->
</div>
<!--foot End-->
<!--返回顶部 Start-->
<div id="fixed-bottom" onclick="pageScroll()" style="display: none;" onmouseover="ChangeImageIn()"
    onmouseout="ChangeImageOut()">
    <img id="fixed-bottom_zhiding" class="back_top" src="Themes/Skin_Default/Images/myzhiding.png" />
</div>
<!--//返回顶部 End-->
<!--微信、建议、返回顶部 start-->
<div id="fixed-weixin" class="weixin">
    <div class="ShouJi js-change-img">
        <img src="Themes/Skin_Default/Images/shouji.png" /></div>
    <div class="MicroInfo js-change-img">
        <img src="Themes/Skin_Default/Images/MicroInfo.png" /></div>
    <div class="jianyi js-change-img">
        <img src="Themes/Skin_Default/Images/jianyi.png" /></div>
    <div class="ReturnTop js-change-img" onclick="pageScroll()">
        <img src="Themes/Skin_Default/Images/ReturnTop.png" /></div>
    <div class="erwei">
        <p>
            <img src="Themes/Skin_Default/Images/er.jpg" /></p>
        <p>
            扫一扫，加我为微信好友吧!</p>
    </div>
    <div class="ShouJi_erwei">
        <p>
            <img src="Themes/Skin_Default/Images/shoujier.jpg" /></p>
        <p>
            扫一扫，快速进入商城!</p>
    </div>
</div>
<!--微信、建议、返回顶部 end-->
<!--弹框建议 start-->
<div class="PopSuggest">
    <%--     <a class="close">×</a>
   
    <p>写下您的意见反馈或金点子<span>(如果建议被采纳将有机会获得奖励哦！)</span></p>
    <textarea></textarea>
    <p>联系方式</p>
    <input type="text" value="手机、邮箱或QQ等" />
    <p>
        <a href="" class="submit-suggestion">提交</a>
    </p>--%>
    <%--<ShopNum1:MessageBoardList ID="MessageBoardList" runat="server" SkinFilename="MessageBoardList.ascx" />--%>
</div>
<!--弹框建议 end-->
<!--弹框透明遮罩层 start-->
<div class="LayerMask">
</div>
<!--弹框透明遮罩层 end-->
<!--[if lte IE 6]>
<style type="text/css">
    *html, *htmlbody
    {
        background-image: url(about:blank);
        background-attachment: fixed;
    }
    /*修正IE6振动bug*/#fixed-weixin /* IE6 底部固定*/
    {
        position: absolute;
        bottom: auto;
        top: expression(eval(document.documentElement.scrollTop+document.documentElement.clientHeight-this.offsetHeight-(parseInt(this.currentStyle.marginTop, 10)||0)-(parseInt(this.currentStyle.marginBottom, 10)||0)));
        right: auto;
        left: expression(eval(document.documentElement.scrollLeft+document.documentElement.clientWidth-this.offsetWidth)-(parseInt(this.currentStyle.marginLeft, 10)||0)-(parseInt(this.currentStyle.marginRight, 10)||0));
    }
</style>
<![endif]-->
<!--[if lte IE 6]>
<script src="Themes/Skin_Default/Js/DD_belatedPNG_0.0.8a.js" type="text/javascript"></script>
    <script type="text/javascript">
        DD_belatedPNG.fix('div, ul, img, li, input , a, *');
    </script>
<![endif]-->
<script type="text/javascript">
    window.onscroll = function () {
        var st = document.documentElement.scrollTop + document.body.scrollTop; //滚去的高度
        if (st > 460) {
            //var imgWeight=document.getElementById("fixed-bottom_zhiding").width;
            document.getElementById("fixed-weixin").style.display = "block";
            document.getElementById("fixed-weixin").style.left = (document.body.clientWidth / 2 + 605) + "px";
        }
        else {
            //document.getElementById("fixed-weixin").style.display = "none";
        }
    }

    function pageScroll() {
        window.scrollBy(0, -1000000);
    }

    function ChangeImageIn() {
        document.getElementById("fixed-bottom_zhiding").src = "Themes/Skin_Default/Images/myzhiding1.png";
    }
    function ChangeImageOut() {
        document.getElementById("fixed-bottom_zhiding").src = "Themes/Skin_Default/Images/myzhiding.png";
    }
</script>
<script type="text/javascript">
    $(document).ready(function () {
        //页面加载时在底部显示
        var leftWid = ($(document).width()) / 2 + 605;
        $('#fixed-weixin').css('left', leftWid);

        //鼠标滑过二维码显示隐藏
        $('div.ShouJi').MouseShow($('div.ShouJi_erwei'));
        $('div.MicroInfo').MouseShow($('div.erwei'));

        //鼠标滑过图片更换
        $('div.js-change-img img').ChangeImg();

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

    });
    jQuery.fn.extend({

        //鼠标滑过二维码显示隐藏
        MouseShow: function (item) {
            if (this.length <= 0) {
                return false;
            }
            var main = this;
            return main.bind({
                mouseover: function (e) {
                    item.show();
                },
                mouseout: function (e) {
                    item.hide();
                }
            });

        },

        //鼠标滑过图片更换
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
</script>
