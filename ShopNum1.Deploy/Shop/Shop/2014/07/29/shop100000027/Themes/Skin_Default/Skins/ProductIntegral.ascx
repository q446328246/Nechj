<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.ShopWebControl" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.Common" %>


<script type="text/javascript">
    function funIsMyself()
    {
        if($("#ProductIntegral_ctl00_HiddenFieldMemloginID").val()==$("#ProductIntegral_ctl00_RepeaterData_ctl00_HiddenFieldProductMemLoginID").val())
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    
    //获得及时库存
    function funGetRepertoryCount()
    {
//    return "ss";
        var count=0;
        var proguid=$("#ProductIntegral_ctl00_HiddenFieldGuid").val();
             $.ajax({
                 type: "get",
                 url: "/api/Address.ashx",
                 async: false,
                 data: "proguid="+proguid+"&type=kc",
                 dataType: "html",
                 success: function (ajaxData) {
                    if(ajaxData!="")
                    {
                    count=parseInt(ajaxData);
                    }
                    else
                    {
                        count= 0;
                        alert("商品不存在了");
                    }
                 }
             });
        return count;
        
    }
    
//    function funGetRepertoryCount()
//    {
//        
//    }


    function funcheck()
    {
        var Member=$("#ProductIntegral_ctl00_HiddenFieldMemloginID").val();
        var number=$("#ProductIntegral_ctl00_RepeaterData_ctl00_TextBoxNumber").val();
        var RepertoryCount=funGetRepertoryCount();
//        var RepertoryCount=funGetRepertoryCount();
        var MaxCount=parseInt( $("#ProductIntegral_ctl00_HiddenFieldMaxCount").val());
//funGetRepertoryCount();
//        alert();
        var IsMySelf=funIsMyself();
        if(Member!="0")
        {
            if(IsMySelf==true)
            {
            if(parseInt(RepertoryCount)>=1)
            {
                    if(number!="")
                    {
                        if(MaxCount<parseInt(RepertoryCount) && MaxCount!=0)
                        {
                            if(number>0 && number <= MaxCount)
                            {
                                if(funJisuan()==true)
                                {
                                    $("#sp_dialog_contDiv").css("display","block");
                                    $("#sp_dialog_outDiv").css("display","block");
                                    $("#sp_overlayDiv").css("display","block");
                                    $("#ScoreOrder_ctl00_TextBoxNumber").val(number)
                                }
                                else
                                {
                                    alert("积分不够！");
                                }
                            }
                            else
                            {
                                $("#ProductIntegral_ctl00_RepeaterData_ctl00_TextBoxNumber").val("1");
                                alert("兑换数量不得小于1,且不得大于系统规定的最大兑换数量"+MaxCount);
                            }
                        }
                        else
                        {
                            if(number>0 && number <= parseInt(RepertoryCount))
                            {
                                if(funJisuan()==true)
                                {
                                    $("#sp_dialog_contDiv").css("display","block");
                                    $("#sp_dialog_outDiv").css("display","block");
                                    $("#sp_overlayDiv").css("display","block");
                                    $("#ScoreOrder_ctl00_TextBoxNumber").val(number)
                                }
                                else
                                {
                                    alert("积分不够！");
                                }
                            }
                            else
                            {
                                $("#ProductIntegral_ctl00_RepeaterData_ctl00_TextBoxNumber").val("1");
                                alert("兑换数量不得小于1,且不得大于库存"+RepertoryCount);
                            }
                        }
                    }
                    else
                    {
                        alert("请填写兑换的数量！");
                    }
            }
            else
            {
                alert("库存不足！");
            }
            }
            else
            {
                alert("不能兑换自己的商品哦");
            }
            
        }
        else
        {
//            alert("登陆后才能兑换商品哦");
                funShowLogin();
//            window.location.href='<%=ShopSettings.siteDomain%>/login.aspx';
        }
        
    }
    
    function funClose()
    {
        $("#sp_dialog_contDiv").css("display","none");
        $("#sp_dialog_outDiv").css("display","none");
        $("#sp_overlayDiv").css("display","none");
    }
    
    function funCheckNum()
    {
        var RepertoryCount=funGetRepertoryCount();
        var Number=$("#ScoreOrder_ctl00_TextBoxNumber").val();
        
        var MaxCount=parseInt( $("#ProductIntegral_ctl00_HiddenFieldMaxCount").val());
        if(RepertoryCount>0)
        {
        
            if(MaxCount<RepertoryCount && MaxCount!=0)
            {
                if(Number>0 && Number<=MaxCount)
                {
                    if(funJisuan2()==false)
                    {
                        $("#ScoreOrder_ctl00_TextBoxNumber").val("1")
                        $("#SpanNumErr").html("积分不够！");
                        $("#SpanNumRight").css("display","none");
                        return false;
                    }
                    else
                    {
                        $("#SpanNumErr").html("");
                        $("#SpanNumRight").css("display","block");
                        return true;
                    }
                }
                else
                {
                    $("#ScoreOrder_ctl00_TextBoxNumber").val("1");
                    $("#SpanNumErr").html("必须为1到"+MaxCount+"之间的整数！");
                    $("#SpanNumRight").css("display","none");
                    return false;
                }
            }
            else
            {
                if(Number>0 && Number<RepertoryCount)
                {
                    if(funJisuan2()==false)
                    {
                        $("#ScoreOrder_ctl00_TextBoxNumber").val("1")
                        $("#SpanNumErr").html("积分不够！");
                        $("#SpanNumRight").css("display","none");
                        return false;
                    }
                    else
                    {
                        $("#SpanNumErr").html("");
                        $("#SpanNumRight").css("display","block");
                        return true;
                    }
                }
                else
                {
                    $("#ScoreOrder_ctl00_TextBoxNumber").val("1");
                    $("#SpanNumErr").html("必须为1到"+RepertoryCount+"之间的整数！");
                    $("#SpanNumRight").css("display","none");
                    return false;
                }
            }
            
        }
        else
        {
            $("#SpanNumErr").html("库存不足！");
            $("#SpanNumRight").css("display","none");
        }
        
        
    }
    
    //算账
    function funJisuan()
    {
         var number=$("#ProductIntegral_ctl00_RepeaterData_ctl00_TextBoxNumber").val();//数量
         var jifen=$("#ProductIntegral_ctl00_RepeaterData_ctl00_HiddenFieldScore").val();//单积分
         var myScroe=$("#ProductIntegral_ctl00_HiddenFieldMyScore").val();
        var needJF=parseInt(number)*parseInt(jifen);
        if(needJF>parseInt(myScroe))
        {
            return false
        }
        else
        {
            return true;
        }
        
    }
    
    //算账
    function funJisuan2()
    {
         var number=$("#ScoreOrder_ctl00_TextBoxNumber").val();//数量
         var jifen=$("#ProductIntegral_ctl00_RepeaterData_ctl00_HiddenFieldScore").val();//单积分
         var myScroe=$("#ProductIntegral_ctl00_HiddenFieldMyScore").val();
        var needJF=parseInt(number)*parseInt(jifen);
        if(needJF>parseInt(myScroe))
        {
            return false
        }
        else
        {
            return true;
        }
        
    }
    
    //验证码
    function reloadcode()
    {
        var verify=document.getElementById('safecode');
        verify.setAttribute('src','/imagecode.aspx?'+Math.random());
        $("#ScoreOrder_ctl00_TextBoxCode").val("");
    }
    $(function(){
        $("#ScoreOrder_ctl00_DropDownListAddress1").change(function(){
            var code=$("#ScoreOrder_ctl00_DropDownListAddress1").val();
            if(code!="000/3245" && code!="-1")
            {
                $.ajax
                ({
                url:"/api/Address.ashx",
                data:"AddressCode="+code+"&type=adress",
                success:function(data){
                    if(data!="")
                    {
                        $("#ScoreOrder_ctl00_DropDownListAddress2").html(data);
                        $("#ScoreOrder_ctl00_HiddenFieldCode").val(code);
                        $("#ScoreOrder_ctl00_DropDownListAddress3").html("<option value=\"-1\">-请选择-</option>");
                        $("#SpanAdressRight").css("display","block");
                        $("#SpanAdressErr").html("");
                    }
                }
                })
            }
            else
            {
                $("#ScoreOrder_ctl00_DropDownListAddress2").html("<option value=\"-1\">-请选择-</option>");
                $("#ScoreOrder_ctl00_DropDownListAddress3").html("<option value=\"-1\">-请选择-</option>");
                $("#ScoreOrder_ctl00_HiddenFieldCode").val("0");
                
                $("#SpanAdressRight").css("display","none");
                $("#SpanAdressErr").html("请选择地址！");
//                alert("");
            }
        })
        $("#ScoreOrder_ctl00_DropDownListAddress2").change(function(){
            var code=$("#ScoreOrder_ctl00_DropDownListAddress2").val();
//            alert(code);
            if(code!="-1")
            {
                $.ajax
                ({
                url:"/api/Address.ashx",
                data:"AddressCode="+code+"&type=adress",
                success:function(data){
                    if(data!="")
                    {
                        $("#ScoreOrder_ctl00_DropDownListAddress3").html(data);
                        $("#ScoreOrder_ctl00_HiddenFieldCode").val(code);
                    }
                }
                })
            }
            else
            {
                $("#ScoreOrder_ctl00_DropDownListAddress3").html("<option value=\"-1\">-请选择-</option>");
                $("#ScoreOrder_ctl00_HiddenFieldCode").val("0");
                alert("请选择地址！");
            }
        })
        $("#ScoreOrder_ctl00_DropDownListAddress3").change(function(){
            var code=$("#ScoreOrder_ctl00_DropDownListAddress3").val();
            $("#ScoreOrder_ctl00_HiddenFieldCode").val(code);
        })
        
    })
    
    
    //电话
    function checkSubmitMobil(){
       if($("#ScoreOrder_ctl00_TextBoxTel").val()=="")
        {
            $("#SpanPhoneErr").html("手机号码不能为空！");
            $("#ScoreOrder_ctl00_TextBoxTel").focus();
            return false;
        }

        if (!$("#ScoreOrder_ctl00_TextBoxTel").val().match(/^1[2|3|4|5|6|7|8|9][0-9]\d{4,8}$/)) {
        $("#SpanPhoneErr").html("<font color='red'>手机号码格式不正确!</font>");
        
        $("#ScoreOrder_ctl00_TextBoxTel").focus();
        return false;
        }
        $("#SpanPhoneRight").css("display","block");
        $("#SpanPhoneErr").html("");
        return true;
    } 
    
    function funCheckName()
    {
       var MemLoginID= $("#ScoreOrder_ctl00_TextBoxMemLoginID").val();
       if(MemLoginID=="")
       {
            $("#SpanMemLoginIDRight").css("display","none");
            $("#SpanMemLoginIDErr").html("收货人姓名不可为空！");
            return false;
       }
       else
       {
            $("#SpanMemLoginIDRight").css("display","block");
            $("#SpanMemLoginIDErr").html("");
            return true;
       }
    }
    
    //检查邮编
    function funCheckPostalcode()
    {
        var Postalcode= $("#ScoreOrder_ctl00_TextBoxPostalcode").val();
        if(Postalcode!="")
        {
            if(!$("#ScoreOrder_ctl00_TextBoxPostalcode").val().match(/^[0-9]{6}$/))
            {
                $("#SpanPostalcodeRight").css("display","none");
                $("#SpanPostalcodeErr").html("邮政编码格式有误！");
                return false;
            }
            else
            {
                $("#SpanPostalcodeRight").css("display","block");
                $("#SpanPostalcodeErr").html("");
                return true;
            }
        }
        else
        {
            $("#SpanPostalcodeRight").css("display","none");
            $("#SpanPostalcodeErr").html("邮政编码不可为空！");
            return false;
        }
    }
    
    //检查邮件
    function funCheckEmail()
    {
        var email= $("#ScoreOrder_ctl00_TextBoxEmail").val();
        if(email!="")
        {
            if(!$("#ScoreOrder_ctl00_TextBoxEmail").val().match(/^[\w-]+(\.[\w-]+)*@([\w-]+\.)+(com|cn)$/))
            {
                $("#SpanEmailRight").css("display","none");
                $("#SpanEmailErr").html("邮箱格式错误！");
                return false;
            }
            else
            {
                $("#SpanEmailRight").css("display","block");
                $("#SpanEmailErr").html("");
                return true;
            }
        }
//        else
//        {
//            $("#SpanEmailRight").css("display","none");
//            $("#SpanEmailErr").html("邮件不可为空！");
//            return false;
//        }
        return true;
        
    }
    
    
    function  funCheckYzm()
    {
        //验证码
        var yanzm= $("#ScoreOrder_ctl00_TextBoxCode").val();
        if(yanzm!="")
        {
            
            $.get("/api/CheckMemberLogin.ashx?type=getverifycode&code="+yanzm+"",null,function(data){
                   if(data=="true"){
                            $("#SpanCodeRight").css("display","block");
                           $("#SpanCodeErr").html("");
                   }
                   else{
                    $("#SpanCodeRight").css("display","none");
                    $("#SpanCodeErr").html("验证码错误！");
                   }
                   
            });
//            $.ajax
//                ({
//                url:"/api/CheckMemberLogin.ashx",
//                data:"type=getverifycode&code="+yanzm+"",
//                success:function(data){alert(data);
//                    if(data!="")
//                    {   
//                        sult=data;
//                        if(data)
//                        {
//                            $("#SpanCodeRight").css("display","block");
//                            $("#SpanCodeErr").html("");
//                        }
//                        else
//                        {
//                            $("#SpanCodeRight").css("display","none");
//                            $("#SpanCodeErr").html("验证码错误！");
//                        }
//                        return data;
//                    }
//                    else{return false;}
//                }
//                });
//                return false;
        }
        else
        {
            $("#SpanCodeRight").css("display","none");
            $("#SpanCodeErr").html("验证码不可为空！");
        }
    }
    
    function funCheckLogin()
    {
        funCheckNum();
        funCheckName();
        checkSubmitMobil();
        funCheckEmail();
        funCheckPostalcode()
        funCheckYzm();
        //检查登录
        if(funCheckNum()&& funCheckName()&& $("#ScoreOrder_ctl00_HiddenFieldCode").val()!="0" && checkSubmitMobil()&&funCheckEmail()&& funCheckPostalcode()&&$("#SpanCodeRight").is(":visible"))
        {
//            alert("test");
            $("#loginSpan").css("display","none");
            $("#dataJzz").css("display","block");
            //alert(funCheckYzm())
            //提交订单信息
            var num=$("#ScoreOrder_ctl00_TextBoxNumber").val();
            var name=encodeURI($("#ScoreOrder_ctl00_TextBoxMemLoginID").val());
            var code=$("#ScoreOrder_ctl00_HiddenFieldCode").val();
            var phone=$("#ScoreOrder_ctl00_TextBoxTel").val();
            var postCode=$("#ScoreOrder_ctl00_TextBoxPostalcode").val();
            var adress=encodeURI($("#ScoreOrder_ctl00_TextBoxAddress").val());
            var email=$("#ScoreOrder_ctl00_TextBoxEmail").val();
            var productGuid=$("#ProductIntegral_ctl00_HiddenFieldGuid").val();
            
             $.ajax
                ({
                url:"/api/Address.ashx",
                data:"type=order&num="+num+"&name="+name+"&code="+code+"&phone="+phone+"&postCode="+postCode+"&adress="+adress+"&email="+email+"&productGuid="+productGuid+"",
                success:function(data){
//                alert(data);
                    if(data!="")
                    {
                         if(data=="nologin")
                         {
                            alert("您没有登录");
                         }
                         else if(data=="noProduct")
                         {
                            alert("商品被删除或者下架了");
                         }
                         else if(data=="ok")
                         {
                                alert("订单生成成功，请进入会员中心查看");
                                $("#sp_dialog_contDiv").css("display","none");
                                $("#sp_dialog_outDiv").css("display","none");
                                $("#sp_overlayDiv").css("display","none");
                                $("#ScoreOrder_ctl00_TextBoxNumber").val("1");
                                $("#ScoreOrder_ctl00_TextBoxMemLoginID").val("");
                                $("#ScoreOrder_ctl00_HiddenFieldCode").val("");
                                $("#ScoreOrder_ctl00_TextBoxTel").val("");
                                $("#ScoreOrder_ctl00_TextBoxPostalcode").val("");
                                $("#ScoreOrder_ctl00_TextBoxAddress").val("");
                                $("#ScoreOrder_ctl00_TextBoxEmail").val("");
                                $("#loginSpan").css("display","block");
                                $("#dataJzz").css("display","none");
                                window.location=$("#ProductIntegral_ctl00_HiddenFieldUrl").val();
                         }
                         else if(data=="no")
                         {
                            alert("订单生成失败！");
                         }
                    }
                }
                });
        }
        
        
        
    }
    
    
    
</script>
<div class="detail">
    <asp:Repeater ID="RepeaterData" runat="server">
        <ItemTemplate>
            <div class="DetailImage">
                <table>
                    <tr>
                        <td colspan="2" style="height: 22px;">
                            <span style="color: #010101; font-size: 16px; padding-left: 8px; font-weight: bold;height: 28px; line-height: 28px;">
                                <asp:Label ID="LabelName" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["Name"]%>'></asp:Label>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td rowspan="10">
                                        <div id="preview" style="margin-bottom: 0px;">
                                            <div id="spec-n1" class="jqzoom">
                                                <img id="ProductImgurl" runat="server" src='<%# Page.ResolveUrl(((DataRowView)Container.DataItem).Row["OriginalImge"].ToString())%>'
                                                    width="310" height="310" onerror="javascript:this.src='Themes/Skin_Default/Images/noImage.gif'"
                                                    jqimg='<%# Page.ResolveUrl(((DataRowView)Container.DataItem).Row["OriginalImge"].ToString())%>' /></div>
                                            <div style="clear: both;">
                                            </div>
                                            <div id="spec-n5" class="tb_thumb" style="display:none;">
                                                <div class="control" id="spec-left">
                                                </div>
                                                <div class="control" id="spec-right">
                                                </div>
                                                <%--<div class="tb_gallery">
                                                    <ul>
                                                        <li class="tb_diply">
                                                            <div class="tb_pic tb_stn">
                                                                <a href="javascript://">
                                                                    <img src="Themes/Skin_Default/Images/potu2.jpg" /></a></div>
                                                        </li>
                                                        <li class="tb_diply">
                                                            <div class="tb_pic tb_stn">
                                                                <a href="javascript://">
                                                                    <img src="Themes/Skin_Default/Images/potu2.jpg" /></a></div>
                                                        </li>
                                                        <li class="tb_diply">
                                                            <div class="tb_pic tb_stn">
                                                                <a href="javascript://">
                                                                    <img src="Themes/Skin_Default/Images/potu2.jpg" /></a></div>
                                                        </li>
                                                        <li class="tb_diply tb_selected">
                                                            <div class="tb_pic tb_stn">
                                                                <a href="javascript://">
                                                                    <img src="Themes/Skin_Default/Images/potu2.jpg" /></a></div>
                                                        </li>
                                                    </ul>
                                                </div>--%>
                                            </div>
                                        </div>
                                        <asp:Literal ID="LiteralMemLoginID" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["MemLoginID"]%>'
                                            Visible="false"></asp:Literal>
                                        <asp:HiddenField ID="HiddenFieldProductMemLoginID" runat="server" Value='<%# ((DataRowView)Container.DataItem).Row["MemLoginID"]%>' />
                                         </td>
                                </tr>
                            </table>
                        </td>
                        <td class="rtrict_cont">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td style="width:80px;">
                                        <span style="color: #404040;">产品型号：</span>
                                    </td>
                                    <td><asp:Label ID="Label6" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["RepertoryNumber"]%>'></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>
                                        <span style="color: #404040;">市&nbsp;场&nbsp;价：</span>
                                        
                                    </td>
                                    <td>
                                        <span style="font-size: 14px;"><b class="jg_mark" style="color:#666666;">￥<asp:Label
                                            ID="LabelMarketPrice" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["MarketPrice"]%>'></asp:Label></b></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span style="color: #404040;">兑换积分：</span>
                                    </td>
                                    <td>
                                        <strong><b class="jg_store"><%# ((DataRowView)Container.DataItem).Row["Score"]%></b></strong>
                                        <asp:HiddenField ID="HiddenFieldScore" runat="server"  Value='<%# ((DataRowView)Container.DataItem).Row["Score"]%>'/>
                                    </td>
                                </tr>
                                <tr>
                                    <td><span class="rerve">库&nbsp;&nbsp;&nbsp;&nbsp;存：</span></td>
                                    <td class="stock">                                        
                                        <asp:Label ID="LabelRepertoryCount" CssClass="storage" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["RepertoryCount"]%>'></asp:Label><asp:Label ID="Label2" runat="server" Text='<%#  Eval("UnitName") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td><span class="rerve">浏览次数：</span></td>
                                    <td class="stock">
                                        <asp:Label ID="Label1" CssClass="storage" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["ClickCount"]%>' style="color:#009B00;"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td><span class="rerve">已兑换数：</span></td>
                                    <td class="stock">                                        
                                         <%#Eval("HaveSale").ToString() == "" ? "0" : Eval("HaveSale").ToString()%>
                                    </td>
                                </tr>
                                <tr>
                                    <td><span class="rerve">兑换数量：</span></td>
                                    <td class="stock">                                        
                                        <asp:TextBox ID="TextBoxNumber" runat="server" Width="30" Text="1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="padding-left: 102px;">
                                    <input type="button" id="Convert" name="Convert" class="cp_convert"  onclick="funcheck()"/>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <asp:Repeater ID="RepeaterDateImage" runat="server" Visible="false">
                        <ItemTemplate>
                            <img id="Img1" runat="server" src='<%# ((DataRowView)Container.DataItem).Row["imgurl"] %>'
                                width="100" height="100" />
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <div style="clear: both;">
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <asp:HiddenField ID="HiddenFieldGuid" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldMemloginID" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldMaxCount" runat="server" Value="1" />
    <asp:HiddenField ID="HiddenFieldIsMj" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldMyScore" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldIsMyself" runat="server" Value="false" />
    
    <asp:HiddenField ID="HiddenFieldUrl" runat="server" Value="javasctipt:void(0)" />
    <%if (Page.Request.Cookies["MemberLoginCookie"] == null){ %>
         <input type="hidden" id="hidlogin" value='0' />
    <%} %>
</div>
<script type="text/javascript" language="javascript">
    var shoppath='<%=ShopUrlOperate.GetShopPath() %>';//店铺路径
    var ycity='<%=ShopUrlOperate.GetUserCity() %>';
    var locurl='http://<%=ShopNum1.Common.ShopSettings.siteDomain %>/poplogin.aspx?vj=shopcar&backurl='+encodeURIComponent('http://<%=Request.Url.Host %>/ProductIntegral.aspx?guid=<%=Request.QueryString["guid"] %>');
</script>
<div id="loginbox" style="display:none;">
    <div class="box_mod">
    </div>
    <div class="box_area">
        <h3>
            <span class="b_dl">您尚未登录</span> <span class="b_colse">close</span>
        </h3>
        <iframe id="mylogingo" src="" width="100%" height="400" frameborder="0" scrolling="no"></iframe>
    </div>
</div>
<script>
    function funShowLogin()
    {
        $('#loginbox').show();
//        var strurl='<%=Page.Request.Url.ToString().Replace("%3a%2f%2f", "://").Replace("/", "%2f").Replace("&", "%26") %>'
//        $('#mylogingo').attr('src','http://" + ShopSettings.siteDomain + "/poplogin.aspx?vj=shopcar&backurl=" + strurl + "');
     }
</script>
