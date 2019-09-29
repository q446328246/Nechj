<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.ShopNewWebControl" %>
<%@ Import Namespace="System.Data " %>
<%@ Import Namespace="ShopNum1.Common" %>
<script language="javascript" type="text/javascript">
  $(function(){
             getCommentList("all");
            $("input[name='radio_py']").click(function(){
            getCommentList($(this).val());
      });
  });
   
    function Sethtml(n)
{
    var xhtml=new Array();
    xhtml.push(' <div class="CommentListBox clearfix">');
    xhtml.push('                <div class="MemberPhoto fl">');
    xhtml.push('                    <p><img src="'+n.pic+'" /></p>');
    xhtml.push('                    <p>'+n.memloginid+'</p>');
    xhtml.push('                    <p>'+opPY(n.commenttype)+'</p>');
    xhtml.push('                </div>');
    xhtml.push('                <div class="MemberDis fl">');
    xhtml.push('                   <p>'+n.comment+'</p>');
    xhtml.push('                    <p class="grey">'+n.commenttime+' '+n.specvalue+'</p>');
    if(n.reply!=""){
            xhtml.push('                    <div class="ReplyBg">');
            xhtml.push('                        <i></i>');
            xhtml.push('                         <div class="ShoperRe">');
            xhtml.push('                            <div class="fl">');
            xhtml.push('                                <p><b>【掌柜解释】</b></p>');
            xhtml.push('                                <p class="time">'+n.replytime+'</p>');
            xhtml.push('                            </div>');
            xhtml.push('                            <div class="fl">'+n.reply+'</div>');
            xhtml.push('                            <div class="clear"></div>');
            xhtml.push('                        </div>');
    }
    if(n.continuecomment!=""){
                    xhtml.push('                       <div class="AddComment">');
                    xhtml.push('                            <div class="fl">');
                    xhtml.push('                                <p><b>【追加评论】</b></p>');
                    xhtml.push('                                <p class="time">'+n.continuetime+'</p>');
                    xhtml.push('                            </div>');
                    xhtml.push('                            <div class="fl">'+n.continuecomment+'</div>');
                    xhtml.push('                            <div class="clear"></div>');
                    xhtml.push('                        </div>');
                    xhtml.push('                    </div>');
            }
    xhtml.push('                </div>');
    xhtml.push('                <div class="clear"></div>');
    xhtml.push('            </div>');
    xhtml.push('            </div>');
    return xhtml.join("");
}
function getCommentList(ctype)
{
      var shopid='<%=Common.ReqStr("shopid") %>';
      var proid='<%=Common.ReqStr("guid") %>';
      $.getJSON("/Api/Shop/pcoment.ashx?shopid="+shopid+"&guid="+proid+"&ctype="+ctype+"&showtype=1&sign=vj",null,function(data){
           if(data!="")
           {
            var xshopComment=new Array();
            $.each(data,function(m,n){
                  xshopComment.push(Sethtml(n));
            });
            $("#divComment").html(xshopComment.join(""));
            }else{ $("#divComment").html("");}
      });
}
function opPY(type)
{
    switch(type)
    {
       case "1":return "<img src='Themes/Skin_Default/Images/gds_dp2.png'/>"; break;
       case "3":return "<img src='Themes/Skin_Default/Images/gds_dp1.png'/>";break;
       case "5":return "<img src='Themes/Skin_Default/Images/gds_dp.png'/>";break;
    }
}
$(function(){
	//countDown("2013/9/17 9:32:17","#demo01 .day","#demo01 .hour","#demo01 .minute","#demo01 .second");
});
function countDown(time,day_elem,hour_elem,minute_elem,second_elem){
	//if(typeof end_time == "string")
	var end_time = new Date(time).getTime(),//月份是实际月份-1
	//current_time = new Date().getTime(),
	sys_second = (end_time-new Date().getTime())/1000;
	var timer = setInterval(function(){
		if (sys_second > 0) {
			sys_second -= 1;
			var day = Math.floor((sys_second / 3600) / 24);
			var hour = Math.floor((sys_second / 3600) % 24);
			var minute = Math.floor((sys_second / 60) % 60);
			var second = Math.floor(sys_second % 60);
			day_elem && $(day_elem).text(day);//计算天
			$(hour_elem).text(hour<10?"0"+hour:hour);//计算小时
			$(minute_elem).text(minute<10?"0"+minute:minute);//计算分
			$(second_elem).text(second<10?"0"+second:second);// 计算秒  
		} else { 
			clearInterval(timer);
		}
	}, 1000);
}

</script>
<style type="text/css">
*{margin:0;padding:0;list-style-type:none;}
a,img{border:0;}
body{font:12px/180% Arial, Helvetica, sans-serif,"宋体";}
/* colockbox */
.colockbox{width:283px;height:76px;margin:20px auto;background:url(images/colockbg.png) no-repeat;}
.colockbox span{float:left;display:block;width:58px;height:48px;line-height:48px;font-size:26px;text-align:center;color:#000000;margin:0 17px 0 0;}
.colockbox span.second{margin:0;}
#demo02{width:208px;background-position:-75px 0;}
</style>
     
                    
<div class="detail">
    <asp:Repeater ID="RepeaterData" runat="server">
        <ItemTemplate>
            <div class="DetailImage snap">
                <div class="content">
                    <div class="ProductImg fl">
                        <div id="preview">
                            <div id="spec-n1" class="jqzoom">
                                <img id="ProductImgurl" runat="server" src='<%# Page.ResolveUrl(((DataRowView)Container.DataItem).Row["OriginalImage"].ToString())%>'
                                    width="310" height="310" onerror="javascript:this.src='Themes/Skin_Default/Images/noImage.gif'"
                                    jqimg='<%# Page.ResolveUrl(((DataRowView)Container.DataItem).Row["OriginalImage"].ToString())%>' />
                            </div>
                            <div class="clear"></div>
                            <div id="spec-n5" class="tb_thumb">
                               <%-- <div class="control" id="spec-left">
                                </div>
                                <div class="control" id="spec-right">
                                </div>--%>
                                <div class="tb_gallery" id="tb_gallery">
                                  <ShopNum1Shop:ProductMultiImage ID="ProductMultiImage" runat="server" SkinFilename="ProductMultiImage.ascx" />
                                </div>
                                <div id="spec-list" style="display: none;">
                                    <asp:Repeater ID="RepeaterDateImage" runat="server">
                                        <ItemTemplate>
                                            <img id="Img1" runat="server" onclick="selectimg(this)" src='<%# Eval("imgurl") %>'
                                                width="100" height="100" />
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>
                        <div style="position: absolute; z-index: 109; top: 15px; left: 0px; display:none;">
                            <asp:Image ID="Image2" runat="server" src="Themes/Skin_Default/Images/qianggou.gif"
                                Width="55" Height="53" />
                        </div>
                    </div>
                    <div class="BuyInfo BuyInfo1 fl">
                        <div class="qiang-title">
                            <h1><asp:Label ID="Label1" runat="server" Text='<%# Eval("Name")%>'></asp:Label></h1>
                        </div>
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td class="tassle">
                                    <span class="flohost">市场价： </span><span class="clenew">￥<asp:Label ID="Label2" runat="server"
                                        Text='<%# Eval("marketPrice")%>'></asp:Label></span>
                                </td>
                            </tr>
                            <tr>
                                <td class="tassle">
                                    <span class="flohost">抢购价：</span><span class="ntsig"> ￥<%# Eval("ShopPrice")%>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td class="tassle">
                                    <span class="flohost">抢购数：</span><span style="font-weight: bold;">
                                        <%#Eval("repertorycount")%>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td class="tassle" style="padding:0;">
                                    <div class="time-box">
                                        <div>
                                            <span class="flohost"><asp:Label ID="LabelTime" runat="server" Text=""></asp:Label></span>
                                            <%--  <div class="colockbox" id="demo01" style="display:block;">
	<span class="day">-</span>
	<span class="hour">-</span>
	<span class="minute">-</span>
	<span class="second">-</span>
</div>                 --%>
                                             
                                            <span class="cotunse" id='<%# "Panicspan" + (ProductIsPanicDetail.i).ToString() %>'>
                                           <%--<script>countDown('<%#  ProductIsPanicDetail.IsBegin(Eval("StartTime"),Eval("EndTime")).Replace("-","/") %>',"#demo01 .day","#demo01 .hour","#demo01 .minute","#demo01 .second")</script>--%>
                                                   <script>show_date_time('<%#  ProductIsPanicDetail.IsBegin(Eval("StartTime"),Eval("EndTime")).Replace("-","/") %>','<%# "Panicspan" + (ProductIsPanicDetail.i++).ToString() %>')</script>
                                            </span>
                                        </div>
                                        <div class="yqiang">
                                            已被抢走<span><%# Eval("buycount").ToString() == "" ? "0" : Eval("buycount")%></span>件
                                        </div>
                                        <div class="Iwant">
                                            <p><asp:Button ID="ButtonShopCar" runat="server" Text="" CssClass="plunde" /></p>
                                            <p style="display:none;">(抢购前请先<a href="#">登录</a>)</p>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <%--<div class=".fenxiang-qiang">
                            <p id="ckepop"> 
                                <span class="jiathis_txt">分享到：</span> <a class="jiathis_button_qzone"></a> 
                                <a class="jiathis_button_tsina"></a> <a class="jiathis_button_tqq"></a> 
                                <a class="jiathis_button_renren"></a> <a class="jiathis_button_kaixin001"></a> 
                                <a class="jiathis_button_tsohu"></a> <a class="jiathis_button_fav"></a> 
                                <a class="jiathis_button_douban"></a> 
                                <a href="http://www.jiathis.com/share" class="jiathis jiathis_txt jtico jtico_jiathis" target="_blank"></a>
                                <script type="text/javascript" src="http://v2.jiathis.com/code/jia.js" charset="utf-8"></script>
                            </p>
                        </div>--%>
                    </div>
                    <div class="clear"></div>
                </div>
            </div>
            <div> 
                <div class="whoBuy">
                    <ShopNum1Shop:ProductIsPanicBuyList ID="ProductIsPanicBuyList1" runat="server" ShowCount="10"
                        SkinFilename="ProductIsPanicBuyList1.ascx" />
                </div>
                <div class="hd_de diagram">
                    <div class="hd_de_top">
                        <h2 class="hd_de_topli">
                            商品详细</h2>
                    </div>
                    <div class="hd_de_lr" style="line-height: 22px;">
                        <%#  Server.HtmlDecode(Eval("Detail").ToString())%>
                    </div>
                </div>
                <div class="hd_de diagram">
                    <div class="hd_de_top">
                        <h2 class="hd_de_topli">
                            抢购须知</h2>
                    </div>
                    <div class="hd_de_lr" style="line-height: 22px;">
                        <%# Server.HtmlDecode(Eval("Instruction").ToString())%>
                    </div>
                </div>
                <div class="hd_de diagram">
                    <div class="hd_de_top">
                        <h2 class="hd_de_topli">
                            商品评价</h2>
                    </div>
                    <div class="MemberDiscuss clearfix">
                        <div class="ComScore">
                            <table width="100%">
                                <tr>
                                    <td class="title" width="100">宝贝与描述相符</td>
                                    <td class="count">
                                        <img id="c1" src="Themes/Skin_Default/Images/icon_star_2.gif" />
                                        <img id="c2" src="Themes/Skin_Default/Images/icon_star_2.gif" />
                                        <img id="c3" src="Themes/Skin_Default/Images/icon_star_2.gif" />
                                        <img id="c4" src="Themes/Skin_Default/Images/icon_star_2.gif" />
                                        <img id="c5" src="Themes/Skin_Default/Images/icon_star_2.gif" />
                                        <span><asp:Label ID="lblCharactervg" runat="server"></asp:Label></span>分
                                    </td>
                                    <td width="100">共有<b><asp:Label ID="lblAllnum" runat="server"></asp:Label></b>条评论</td>
                                </tr>
                            </table>
                        </div>
                        <div class="flower">
                            <table width="100%">
                                <tr>
                                     <td><input type="radio" name="radio_py" value="all" checked="checked" />全部(<asp:Label ID="lblTotal" runat="server"></asp:Label>)</td>
                                    <td><input type="radio" name="radio_py" value="good" /><img src="Themes/Skin_Default/Images/gds_dp.png" />好评(<asp:Label ID="lblGoodCount" runat="server"></asp:Label>)</td>
                                    <td><input type="radio" name="radio_py" value="normal" /><img src="Themes/Skin_Default/Images/gds_dp1.png" />中评(<asp:Label ID="lblMiddelCount" runat="server"></asp:Label>)</td>
                                    <td><input type="radio" name="radio_py" value="bad" /><img src="Themes/Skin_Default/Images/gds_dp2.png" />差评(<asp:Label ID="lblBadCount" runat="server"></asp:Label>)</td>
                                    <td><input type="radio" name="radio_py" value="addcomment" />追加评论(<asp:Label ID="lblContinue" runat="server"></asp:Label>)</td>
                                </tr>
                            </table>
                        </div>
                         <div id="divComment">
                                <center><img src="Themes/Skin_Default/Images/loading.gif" /></center>
                        </div>
                </div>
            </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <!-- 分页部分-->
<div class="pager">
    <asp:Label ID="LabelPageMessage" runat="server"></asp:Label>
    &nbsp;<asp:HyperLink ID="lnkFirst" runat="server"><span class="fpager">[ 首页</span></asp:HyperLink>
    <asp:HyperLink ID="lnkPrev" runat="server"><span class="fpager">| 上一页</span></asp:HyperLink>
    <asp:HyperLink ID="lnkNext" runat="server"><span class="fpager">| 下一页</span></asp:HyperLink>
    <asp:HyperLink ID="lnkLast" runat="server"><span class="fpager">| 末页 ]</span></asp:HyperLink>
    &nbsp;<span class="fpager">转到
        <asp:Literal ID="lnkTo" runat="server" />
        页</span>
</div>
</div>
