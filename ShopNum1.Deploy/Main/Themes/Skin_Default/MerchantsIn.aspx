<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <ShopNum1:Meto ID="meto1" runat="server" Type="1" SkinFilename="Meto.ascx" />
    <link href="Themes/Skin_Default/Style/sjindex.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        window.onload = function () {
            var oPlay = document.getElementById('play');
            var oOl = oPlay.getElementsByTagName('ol')[0];
            var aLi1 = oOl.getElementsByTagName('li');
            var oUl = oPlay.getElementsByTagName('ul')[0];
            var aLi2 = oUl.getElementsByTagName('li');
            var i = iNum = direction = 0;
            var times = null;
            var play = null;

            for (i = 0; i < aLi1.length; i++) {
                aLi1[i].index = i;
                aLi1[i].onclick = function () {
                    iNum = this.index;
                    show();
                };
            }
            //按钮点击后调用的函数
            function show() {
                for (i = 0; i < aLi1.length; i++) {
                    aLi1[i].className = '';
                }
                aLi1[iNum].className = 'active';
                startMove(-(iNum * 171));
            }
            //自动播放转向
            function autoPlay() {
                if (iNum >= aLi1.length - 1) {
                    direction = 1;
                }
                else if (iNum <= 0) {
                    direction = 0;
                }

                if (direction == 0) {
                    iNum++;
                }
                else if (direction == 1) {
                    iNum--;
                }
                show();
            }
            //自动播放
            play = setInterval(autoPlay, 3000);

            //鼠标移入展示区停止自动播放
            oPlay.onmouseover = function () {
                clearInterval(play);
            };
            //鼠标移出展示区开启自动播放
            oPlay.onmouseout = function () {
                play = setInterval(autoPlay, 3000);
            };

            function startMove(iTarget) {
                clearInterval(times);
                times = setInterval(function () {
                    doMove(iTarget);
                }, 30);
            }
            function doMove(iTarget) {

                var iSpeed = (iTarget - oUl.offsetTop) / 10;
                iSpeed = iSpeed > 0 ? Math.ceil(iSpeed) : Math.floor(iSpeed);

                if (oUl.offsetTop == iTarget) {
                    clearInterval(times);
                }
                else {
                    oUl.style.top = oUl.offsetTop + iSpeed + 'px';
                }

            }
        };
    </script>
</head>
<body>
    <div class="module_head">
    </div>
    <div class="warp clearfix">
        <!--nav Start-->
        <div class="nav">
            <ul>
                <li><a href="javascript:void(0)" class="curr">首页</a></li>
                <li><a href="/MerchantsIn.html#know">了解我们</a></li>
                <li><a href="/MerchantsIn.html#need">招商标准</a></li>
                <li><a href="/MerchantsIn.html#enter">入驻流程</a></li>
                <li><a href="/MerchantsIn.html#scope">招商范围</a></li>
                <li><a href="/MerchantsIn.html#help">帮助中心</a></li>
                <li class="last"><a href="/MerchantsIn.html#contactus">联系我们</a></li>
            </ul>
        </div>
        <!--//nav End-->
        <!--main Start-->
        <div class="main clearfix">
            <div class="m_head">
                <!--信息公告-->
                <div class="mess_notice">
                    <h1>
                        信息公告</h1>
                    <div class="mess_con">
                        <ul>
                            <li><a href="#">·《ShopNum1招商标准》变更公示通知</a> </li>
                            <li><a href="#">·商家必读：ShopNum1入驻资质在线</a> </li>
                            <li><a href="#">·入驻ShopNum1所需资质办理指南</a> </li>
                            <li><a href="#">·ShopNum1家具火热招商</a> </li>
                            <li><a href="#">·ShopNum1汽车类目火热招商</a> </li>
                            <li><a href="#">·ShopNum1珠宝/饰品/手表/眼镜火热招商</a> </li>
                            <li><a href="#">·ShopNum1食品饮料火热招商</a> </li>
                        </ul>
                    </div>
                </div>
                <!--幻灯-->
                <div class="m_ad">
                    <div class="play" id="play">
                        <ol class="ol_class">
                            <li class="active" class="">1</li>
                            <li class="">2</li>
                            <li class="">3</li>
                            <li class="">4</li>
                        </ol>
                        <ul class="ul_class">
                            <ShopNum1:AdSimpleImage ID="AdSimpleImage1" runat="server" AdImgId="1" SkinFilename="AdSimpleImage.ascx" />
                            <ShopNum1:AdSimpleImage ID="AdSimpleImage2" runat="server" AdImgId="4" SkinFilename="AdSimpleImage.ascx" />
                            <ShopNum1:AdSimpleImage ID="AdSimpleImage3" runat="server" AdImgId="5" SkinFilename="AdSimpleImage.ascx" />
                            <ShopNum1:AdSimpleImage ID="AdSimpleImage4" runat="server" AdImgId="6" SkinFilename="AdSimpleImage.ascx" />
                        </ul>
                    </div>
                </div>
                <!--入住查询-->
                <div class="m_btn">
                    <div class="m_ruzhu">
                        <p class="s_rzhu">
                            <a href="#">
                                <img src="/main/Themes/Skin_Default/images/s_rzhu.12gif" /></a></p>
                        <div class="m_p">
                            <p>
                                入驻前咨询：400-691-8851</p>
                            <p>
                                (周一至周五 09：00-18：00)</p>
                        </div>
                        <div class="m_chax">
                            <a href="#" class="chxun">查询入驻进度</a></div>
                    </div>
                </div>
            </div>
            <a name="know"></a>
            <!--项目介绍-->
            <div class="box_xm">
                <div class="titi">
                    <span class="xm">项目介绍</span></div>
                <div class="jieshao">
                    <p>
                        ·商城，国内首个提供中高档品牌销售业务的网上购物平台，致力于为企业及商务白领提供综合性一站式的网购服务。安全可靠的交易平台，专业高效的服务 团队，以用户体验导向为核心价值观的商务服务理念，助力企业和商务白领，运用电子商务，压缩渠道成本、时间成本，拓展销售市场，强化企业品牌，实现
                        最大化企业的商业目标。
                    </p>
                    <p>
                        ·唐江国际有限公司是电子商务专业服务商，是一家拥有核心知识产权的纯互联网企业，运营多个领先的行业网站，拥有每日极大的访问量。公司先后通过通过多 年努力，迅速发展壮大，现已成功服务过一万多家企业，提供从电子商务网站建设、推广到在线零售的完整电子商务解决方案，不断为用户创造新的商业价值。
                    </p>
                </div>
            </div>
            <a name="need"></a>
            <!--招商要求-->
            <div class="box_xm">
                <div class="titi">
                    <span class="xm">招商要求</span></div>
                <div class="jieshao zhaos">
                    <div class="font_title">
                        每天极大的访问量，怎可能错失商机？</div>
                    <div class="box_mod">
                        <div class="mod1">
                            <p>
                                您属于</p>
                            <dl>
                                <dt>A、平台合作类</dt>
                                <dd>
                                    ·现有的网上S2C商城</dd>
                                <dt>B、独立招商类</dt>
                                <dd>
                                    ·生产型厂商，拥有自己注册商标；</dd>
                                <dd>
                                    ·授权代理商，获得国内或国际知名品牌厂商的授权；</dd>
                                <dd>
                                    ·经销商，专业品类专卖店；</dd>
                                <dd>
                                    ·具有民事行为能力的个人，获得授权代理书。</dd>
                            </dl>
                        </div>
                        <div class="mod1">
                            <p>
                                您只需</p>
                            <div class="mod_cont">
                                <ul>
                                    <li>1、定价公平合理。</li>
                                    <li>2、所有商品保障原厂正品。</li>
                                    <li>3、七天不影响二次销售换货。</li>
                                    <li>4、参加商城红包购物活动。</li>
                                    <li>5、保障商品质量，承诺售后服务。</li>
                                    <li>6、必要时提供购物发票。</li>
                                </ul>
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="box_mod">
                        <div class="mod1">
                            <p>
                                您拥有</p>
                            <div class="mod_cont">
                                <ul>
                                    <li>1、拥有企业营业执照，个人代理需提供个人身份证件。</li>
                                    <li>2、拥有注册商标或品牌，或者拥有正规的品牌授权书。</li>
                                    <li>3、署入驻商城服务合约。</li>
                                </ul>
                            </div>
                        </div>
                        <div class="mod1 modlast">
                            <p>
                                您要做</p>
                            <div class="mod_cont">
                                <ul>
                                    <li>1、提供商品，并上传商品图片与信息，在电脑系统后台中进行日常商品管理；</li>
                                    <li>2、自行存储商品，并根据订单发货给顾客，对有需要的顾客开具购物发票；</li>
                                    <li>3、优质的服务和可靠的配送服务体系，对售出商品的售后服务负责；</li>
                                </ul>
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                </div>
            </div>
            <a name="scope"></a>
            <!--招商范围-->
            <div class="box_xm">
                <div class="titi">
                    <span class="xm">招商范围</span></div>
                <div class="jieshao fwei">
                    <ul>
                        <li><a href="#">
                            <img src="Themes/Skin_Default/Images/s_sj.gif" width="143" height="45" /></a></li>
                        <li><a href="#">
                            <img src="Themes/Skin_Default/Images/s_sj1.gif" width="143" height="45" /></a></li>
                        <li><a href="#">
                            <img src="Themes/Skin_Default/Images/s_sj2.gif" width="143" height="45" /></a></li>
                        <li><a href="#">
                            <img src="Themes/Skin_Default/Images/s_sj3.gif" width="143" height="45" /></a></li>
                        <li><a href="#">
                            <img src="Themes/Skin_Default/Images/s_sj4.gif" width="143" height="45" /></a></li>
                        <li><a href="#">
                            <img src="Themes/Skin_Default/Images/s_sj5.gif" width="143" height="45" /></a></li>
                        <li><a href="#">
                            <img src="Themes/Skin_Default/Images/s_sj6.jpg" width="143" height="45" /></a></li>
                        <li><a href="#">
                            <img src="Themes/Skin_Default/Images/s_sj7.gif" width="143" height="45" /></a></li>
                        <li><a href="#">
                            <img src="Themes/Skin_Default/Images/s_sj8.gif" width="143" height="45" /></a></li>
                        <li><a href="#">
                            <img src="Themes/Skin_Default/Images/s_sj9.gif" width="143" height="45" /></a></li>
                        <li><a href="#">
                            <img src="Themes/Skin_Default/Images/s_sj10.gif" width="143" height="45" /></a></li>
                    </ul>
                    <div class="clear">
                    </div>
                </div>
            </div>
            <a name="enter"></a>
            <!--入住流程图-->
            <div class="step">
                <div class="ruzhu">
                    <span class="ruzt">入驻流程</span> <a href="#" class="rumore">查看动态演示 ></a>
                </div>
                <div class="step_cont">
                    <div class="step1">
                        <p class="title">
                            签署在线入驻协议</p>
                        <div class="step_red">
                            签署在线入驻协议</div>
                    </div>
                    <div class="step2">
                        <p class="sjmess">
                            商家信息提交</p>
                        <ul class="sjul">
                            <li>1)提交公司经营信息</li>
                            <li>2)提交入驻预经营信息</li>
                            <li>3)提交公司资质信息</li>
                            <li>4)提交公司财务税务信息</li>
                            <li>5)上传产品资质提交审核</li>
                        </ul>
                    </div>
                    <div class="step3">
                        <p class="sjmess">
                            合同签订</p>
                        <ul class="sjul sulcom">
                            <li>1)确认合同信息</li>
                            <li>2)合同/资质寄回</li>
                        </ul>
                    </div>
                    <div class="step4">
                        <p class="sjmess">
                            商家缴费</p>
                        <ul class="sjul sulcom">
                            <li>1)商家缴费</li>
                            <li>2)上传缴费回执单</li>
                        </ul>
                    </div>
                    <div class="step5">
                        <p class="sjmess">
                            店铺开通</p>
                        <ul class="sjul sulcom">
                            <li>1)确认缴费无误</li>
                            <li>2)店铺开通</li>
                        </ul>
                    </div>
                </div>
            </div>
            <a name="help"></a>
            <!--入住流程-->
            <div class="box_xm">
                <div class="titi">
                    <span class="xm">入驻流程</span></div>
                <div class="jieshao">
                    <div class="shenqin">
                        <div class="sq">
                            1、申请入驻</div>
                        <div class="sqcon">
                            <p>
                                核对资质信息：</p>
                            <p>
                                提交入驻申请：</p>
                            <p>
                                双方沟通：</p>
                            <p>
                                确认合作意向：</p>
                        </div>
                        <div class="spright">
                            <p>
                                商家首先关注ShopNew1商城入驻标准，确认符合要求</p>
                            <p>
                                商家务必按照邮件要求将信息发送到各类目负责人邮箱</p>
                            <p>
                                收到资料后，ShopNew1招商负责人会第一时间与您取得联系</p>
                            <p>
                                招商负责人会与您就合作条款、要求进行沟通，双方确认合作意向</p>
                        </div>
                    </div>
                    <div class="shenqin sqxia">
                        <div class="sq">
                            2、签订合同</div>
                        <div class="sqcon">
                            <p>
                                发送合同：</p>
                            <p>
                                提交合同资质：</p>
                            <p>
                                资质合同审核：</p>
                        </div>
                        <div class="spright">
                            <p>
                                招商负责人邮寄合同到商家处</p>
                            <p>
                                商家按照要求签订合同、提交资质文件到ShopNew1商城</p>
                            <p>
                                相关部门审核合同与资质</p>
                        </div>
                    </div>
                    <div class="shenqin sqxiac">
                        <div class="sq">
                            3、开店准备</div>
                        <div class="sqcon">
                            <p>
                                准备产品资料：</p>
                            <p>
                                交纳相关费用：</p>
                            <p>
                                开店销售：</p>
                        </div>
                        <div class="spright">
                            <p>
                                商家准备需要合作产品的相关图片及说明</p>
                            <p>
                                商家交纳保证金和平台使用费</p>
                            <p>
                                产品运营经理将与您取得联系安排开店事宜</p>
                        </div>
                    </div>
                </div>
            </div>
            <a name="contactus"></a>
            <!--联系我们-->
            <div class="contact">
                <div class="con_tit">
                    <span class="lxi">联系我们</span></div>
                <div class="cont_us">
                    <div class="cont_tab">
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <th width="25%">
                                    类目
                                </th>
                                <th>
                                    联系人
                                </th>
                                <th>
                                    E-mail地址
                                </th>
                                <th>
                                    MSN
                                </th>
                                <th>
                                    QQ
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    平台合作
                                </td>
                                <td>
                                    王先生
                                </td>
                                <td>
                                    sale001@shopnum1.com
                                </td>
                                <td>
                                    <span class="icon"></span>shopnum1_sale001@hotmail.com
                                </td>
                                <td>
                                    <span class="icon1"></span>2448429145
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    开店咨询
                                </td>
                                <td>
                                    谢先生
                                </td>
                                <td>
                                    sale001@shopnum1.com
                                </td>
                                <td>
                                    <span class="icon"></span>shopnum1_sale001@hotmail.com
                                </td>
                                <td>
                                    <span class="icon1"></span>2448429145
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    运动、休闲、鞋类、箱包、 珠宝配饰、化妆品、男装、女装
                                </td>
                                <td>
                                    刘先生
                                </td>
                                <td>
                                    sale001@shopnum1.com
                                </td>
                                <td>
                                    <span class="icon"></span>shopnum1_sale001@hotmail.com
                                </td>
                                <td>
                                    <span class="icon1"></span>2448429145
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    孕童、食品特产、家居家纺、 大小家电、手机、数码、电脑
                                </td>
                                <td>
                                    李先生
                                </td>
                                <td>
                                    sale001@shopnum1.com
                                </td>
                                <td>
                                    <span class="icon"></span>shopnum1_sale001@hotmail.com
                                </td>
                                <td>
                                    <span class="icon1"></span>2448429145
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <!--//main End-->
        <!--foot Start-->
        <div class="foot">
            <p>
                Copyright 2009-2012 唐江国际 All Rights Reserved ICP备11009662号</p>
            <p>
                客服工作时间：8:30-21:00 Email：t2009@hotmail.com</p>
            <p>
                程序开发商：唐江国际有限公司</p>
        </div>
        <!--//foot End-->
    </div>
</body>
</html>
