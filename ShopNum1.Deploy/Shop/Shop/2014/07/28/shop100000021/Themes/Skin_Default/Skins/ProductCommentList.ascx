<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.ShopWebControl" %>
<input type="hidden" id="hidType" runat="server"/>
<script type="text/javascript">
$(document).ready(function(){
        $("#divComment .childComment").children(":first").find("span").each(function(i){
             var  spanv= $.trim($(this).html());
             if(i==0)
             {
                  if(spanv=="")
                  {
                        $(this).parent().hide();
                  }
            }
            else
            {
                  if(spanv=="")
                  {
                      $(this).parent().parent().hide();
                  }
            }
      });
      $("input[name='radio_py']").click(function(){
            getCommentList($(this).val());
      });
});
getCommentList("all");
function getCommentList(ctype)
{
      var shopid='<%=Common.ReqStr("shopid") %>';
      var proid='<%=Common.ReqStr("guid") %>';
     $.getJSON("/Api/Shop/pcoment.ashx?shopid="+shopid+"&guid="+proid+"&ctype="+ctype+"&showtype="+$("#ProductCommentList_ctl00_hidType").val()+"&sign=vj",null,function(data){
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
function Sethtml(n)
{
   var xhtml=new Array();
    xhtml.push(' <div class="CommentListBox clearfix">');
    xhtml.push('                <div class="MemberPhoto fl">');
    xhtml.push('                    <p><img class="photo" src="'+n.pic+'" onerror="javascript:this.src=/ImgUpload/noImage.jpg" /></p>');
    xhtml.push('                    <p style="padding-top:5px;"><span>'+opPY(n.commenttype)+'</span><span>'+n.memloginid+'</span></p>');
    xhtml.push('                </div>');
    xhtml.push('                <div class="MemberDis fl">');
    xhtml.push('                    <p>'+n.comment+'</p>');
    xhtml.push('                    <p class="grey">'+n.commenttime+' '+n.specvalue+'</p>');
    xhtml.push('                    <div class="ReplyBg">');
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
    if(n.reply!=""){
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
    xhtml.push('                </div>');
    xhtml.push('                <div class="clear"></div>');
    xhtml.push('            </div>');
    xhtml.push('            </div>');
    return xhtml.join("");
}
</script>
<div class="MemberDiscuss clearfix">
    <asp:Repeater ID="RepeaterStat" runat="server">
        <ItemTemplate>
            <div class="ComScore">
                <table width="100%">
                    <tr>
                        <td class="title" width="100">宝贝与描述相符</td>
                        <td class="count">
                            <img id="c1" src="Themes/Skin_Default/Images/icon_star_1.gif" />
                            <img id="c2" src="Themes/Skin_Default/Images/icon_star_1.gif" />
                            <img id="c3" src="Themes/Skin_Default/Images/icon_star_1.gif" />
                            <img id="c4" src="Themes/Skin_Default/Images/icon_star_1.gif" />
                            <img id="c5" src="Themes/Skin_Default/Images/icon_star_1.gif" />
                            <asp:HiddenField ID="hc" runat="server" Value='<%# ProductCommentList.SetNoNull(Eval("Characteravg"))%>' />
                            <span><%# ProductCommentList.SetNoNull(Eval("Characteravg"))%></span>分
                        </td>
                        <td width="100">共有<b><%# Eval("Allnum")%></b>条评论</td>
                    </tr>
                </table>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <div class="flower">
        <table width="100%">
            <tr>
                <td><input type="radio" name="radio_py" value="all" checked="checked" />全部(<asp:Label ID="lblTotal" runat="server" Text="0"></asp:Label>)</td>
                <td><input type="radio" name="radio_py" value="good" /><img src="Themes/Skin_Default/Images/gds_dp.png" />好评(<asp:Label ID="lblGoodCount" runat="server" Text="0"></asp:Label>)</td>
                <td><input type="radio" name="radio_py" value="normal" /><img src="Themes/Skin_Default/Images/gds_dp1.png" />中评(<asp:Label ID="lblMiddelCount" runat="server" Text="0"></asp:Label>)</td>
                <td><input type="radio" name="radio_py" value="bad" /><img src="Themes/Skin_Default/Images/gds_dp2.png" />差评(<asp:Label ID="lblBadCount" runat="server" Text="0"></asp:Label>)</td>
                <td><input type="radio" name="radio_py" value="addcomment" />追加评论(<asp:Label ID="lblContinue" runat="server" Text="0"></asp:Label>)</td>
            </tr>
        </table>
    </div>
    <div id="divComment">
        <center><img src="Themes/Skin_Default/Images/loading.gif" /></center>
    </div>
</div>

<script language="javascript" type="text/javascript">
    for(var i=1;i<6;i++) {
        var img = document.getElementById("c"+i);
        if(i<=document.getElementById("ProductCommentList_ctl00_RepeaterStat_ctl00_hc").value) {
            img.src="Themes/Skin_Default/Images/icon_star_2.gif";
        }
        else {
            img.src="Themes/Skin_Default/Images/icon_star_1.gif";
        }
    }
</script>

