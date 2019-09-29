
//公共提示框
function msg_alert(message,url){
  
  if(url){
    layer.msg(message,{time:1000},function(){
          window.location.href=url;
        });
  }else{
    layer.msg(message,{time:1500});
  }
  
}

//商店信息修改
function change_shop(){
    //正在加载
    var index = layer.load(1, {
        shade: [0.1,'#fff']
    });
    var post_url = $("form[name='shopinfo']").attr('action');
    var post_data= $("form[name='shopinfo']").serialize();
    $.ajax({
        type: "POST",
        url: post_url,
        data:post_data,
        dataType: "json",
        success: function(data){
            layer.close(index);//关闭加载
            if(data.status==1){
                msg_alert(data.message,data.url);
            }else{
                msg_alert(data.message);
            }
        }
    });
}


//快捷登录
function quicklogin(){
    var thisform=document.forms['formlogin'];
    var account=thisform.account.value;
    var verify=thisform.code.value;
    if(account=='' || account==null){
        msg_alert('账号不能为空');
        return false;
    }

    if(verify=='' || verify==null){
      msg_alert('验证码不能为空');
      return false;
    }


    var post_url=$('.formlogin').attr('action');
    var post_data=$('.formlogin').serialize();
    //正在加载
    var index = layer.load(1, {
        shade: [0.1,'#fff']
    });
    $.ajax({
        type: "POST",
        url: post_url,
        data:post_data,
        dataType: "json",
        success: function(data){
            layer.close(index);//关闭加载
            if(data.status==1){
                window.location=data.url;
            }else{
                $('#code').trigger('click');
                msg_alert(data.message);
            }
        }
    });
}


//用户登录
function login(){
	  var thisform=document.forms['formlogin'];
	  var account=thisform.account.value;
	  var password=thisform.password.value;
	  // var verify=thisform.verify.value;

	  if(account=='' || account==null){
	  	msg_alert('账号不能为空');
      return false;
	  }
    if(password=='' || password==null){
      msg_alert('密码不能为空');
      return false;
    }
    // if(verify=='' || verify==null){
    //   msg_alert('验证码不能为空');
    //   return false;
    // }


    var post_url=$('.formlogin').attr('action');
    var post_data=$('.formlogin').serialize();
    //正在加载
    var index = layer.load(1, {
        shade: [0.1,'#fff']
    });
    $.ajax({
         type: "POST",
         url: post_url,
         data:post_data,
         dataType: "json",
         success: function(data){
            layer.close(index);//关闭加载
            if(data.status==1){
            window.location=data.url;
            }else{
                $('#code').trigger('click');
                msg_alert(data.message);
            }      
          }     
    });
}

//验证码
function change_code(){
  var verifyURL="/Login/verify";
  $("#code").attr("src",verifyURL+'?'+Math.random());
  return false;
}


//用户注册
function adduser(){
      //验证注册
      var thisform=document.forms['AddUser'];
      
      var   reg = /^[0-9a-zA-Z]{6,20}$/;
      var   mobile_rex=/^1[3456789]\d{9}$/;
      var   pid=thisform.pid.value;//推荐人
      var   code=thisform.code.value;//验证码
      var   username=thisform.username.value;//账号
      var   mobile=thisform.mobile.value;
      var   login_pwd=thisform.login_pwd.value;
      var   relogin_pwd=thisform.relogin_pwd.value;
      var   safe_pwd=thisform.safety_pwd.value;
      // var   repsafe_pwd=thisform.resafety_pwd.value;*/

    var reg = /^\d{6}\b/;
    if(!reg.test(safe_pwd)){
        msg_alert('交易密码只能为6位数');
        return false;
    }
    if(code=='' || code==null){
        msg_alert('验证码不能为空');
        return false;
    }

      if(username=='' || username==null){
        msg_alert('姓名不能为空');
        return false;
      }
     
      if(mobile=='' || mobile==null){
        msg_alert('手机号码不能为空');
        return false;
      }
      if(!mobile_rex.test(mobile)){
        msg_alert('手机号码错误');
        return false;
      }
      //
      // if(pid=='' || pid==null){
      //   msg_alert('推荐人不能为空');
      //   return false;
      // }
      // if(!mobile_rex.test(pid)){
      //   msg_alert('推荐人手机号码错误');
      //   return false;
      // }

      if(login_pwd=='' || login_pwd==null){
        msg_alert('登录密码不能为空');
        return false;
      }

      if(login_pwd!=relogin_pwd){
          msg_alert("两次输入登录密码不一致");
          return false;
      }

      // if(safe_pwd=='' || safe_pwd==null){
      //   msg_alert('登录密码不能为空');
      //   return false;
      // }
      // if(!reg.test(safe_pwd)){
      //     msg_alert("交易密码只能为6-20位数字或字母");
      //     return false;
      // }
      //
      // if(safe_pwd!=repsafe_pwd){
      //     msg_alert("两次输入交易密码不一致");
      //     return false;
      // }
      //正在加载
      var index = layer.load(1, {
          shade: [0.1,'#fff']
      });
      var post_url = $("form[name='AddUser']").attr('action');
      var post_data= $("form[name='AddUser']").serialize();
      $.ajax({
           type: "POST",
           url: post_url,
           data:post_data,
           dataType: "json",
           success: function(data){
              layer.close(index);//关闭加载
              if(data.status==1){
                msg_alert(data.message,data.url);
              }
              else{
                  msg_alert(data.message);
              }      
            }     
      });
}


//修改用户信息
function updateuser(){
      //正在加载
      var index = layer.load(1, {
          shade: [0.1,'#fff']
      });
      var post_url = $("form[name='updateinfo']").attr('action');
      var post_data= $("form[name='updateinfo']").serialize();
      $.ajax({
           type: "POST",
           url: post_url,
           data:post_data,
           dataType: "json",
           success: function(data){
              layer.close(index);//关闭加载
              if(data.status==1){
                layer.msg(data.message,{time:1000},function(){
                  location.reload();
                });
              }
              else{
                  msg_alert(data.message);
              }      
            }     
      });
}


//修改用户信息
function updatepassword(){
      //正在加载
      var index = layer.load(1, {
          shade: [0.1,'#fff']
      });
      var post_url = $("form[name='updatepwd']").attr('action');
      var post_data= $("form[name='updatepwd']").serialize();
      $.ajax({
           type: "POST",
           url: post_url,
           data:post_data,
           dataType: "json",
           success: function(data){
              layer.close(index);//关闭加载
              if(data.status==1){
                layer.msg(data.message,{time:1000},function(){
                  location.reload();
                });
              }
              else{
                  msg_alert(data.message);
              }      
            }     
      });
}



  //提示框
  function message(data){
    
        var str='';
        str+='<div id="lightr" class="white_content_tb2" style="display:block" >';
        str+='<div class="stealing">'; 
        str+='<p>'+data+'</p>';
        str+='</div>';
        str+='<div class="xftcan">';
        str+='<ul>';
        str+='<li id="queding"><a href="javascript:void(0)" onclick="removebox()">确定</a></li>';
        str+='</ul>';
        str+='</div>';
        str+='</div>';
        str+='<div id="fader" class="black_overlay_tb2" style="display:block" ></div>';
        $('body').children("div:first-child").before(str);
  }

//移除提示框
function removebox(){
  $('#lightr').remove();
  $('#fader').remove();
}


//增种弹框
  function bozhongguozi(obj){
        var id=$(obj).attr('data');
        var landtype=$(obj).attr('landtype');
        var status=$(obj).attr('status');
        //关闭当前窗口
        $('.beans').hide();
        var str='';
        if(status!=3){
            str+='<div id="light34" class="white_content34">';
            str+='<h3>确定要增种？</h3>增种：<input id="num" type="text" placeholder="增种数量">';
            str+='<p><button id="anniu2"> <a href = "javascript:void(0)" onclick = "removebozhongguozi()">取消</a></button>';
            str+='<button id="anniu2" data="'+id+'" landtype="'+landtype+'" onclick="bozhongjs(this)" >确定</button>';
            str+='</p>';
            str+='</div> ';
            str+='<div id="fade34" class="black_overlay34"></div>';
        }else{
          str+='<div id="light34" class="white_content34"><h3>确定要清除？</h3><p><button id="anniu2"> <a href="javascript:void(0)" onclick="removebozhongguozi()">取消</a></button><button id="anniu2" data="'+id+'" landtype="'+landtype+'" onclick="ClearTree(this)">确定</button></p></div>';
          str+='<div id="fade34" class="black_overlay34"></div>';
        }

        $('body').children("div:first-child").before(str);
  }

//移除增种弹框
function removebozhongguozi(){
  $('#light34').remove();
  $('#fade34').remove();
}

//删除树
function ClearTree(obj){
  
    var id=$(obj).attr('data');
    var index = layer.load(1, {
          shade: [0.1,'#fff'] //0.1透明度的白色背景
        });
         $.ajax({
         type: "POST",
         url: '/Ajaxdz/cleartree',
         data:{'id':id},
         dataType: "json",
         success: function(data){
             removebozhongguozi();
             layer.close(index);
             if(data.status==1){//收割失败
                 editdata();
                $(".tree"+id).prev('.beans').remove();
                $(".tree"+id).remove();
                layer.msg(data.message,{time:1000});  
              }else{
                layer.msg(data.message);
              }    
         }     
    });
}


//播种
  function bozhongjs(obj){
            var id=$(obj).attr('data');
            var landtype=$(obj).attr('landtype');
            var num=$('#num').val();
            if(id=='' || id==null){
              return false;
            }
            if(num=='' || num==null){
               layer.msg('请输入数量');
              return false;
            }
            var index = layer.load(1, {
              shade: [0.1,'#fff'] //0.1透明度的白色背景
            });
             $.ajax({
             type: "POST",
             url: '/Ajaxdz/bozhong',
             data:{'id':id,'farmid':landtype,'bz_num':num},
             dataType: "json",
             success: function(data){
                 removebozhongguozi();
                 layer.close(index);
                 if(data.status==1){//收割失败
                     editdata();
                    $(".tree"+id).prev('.beans').find('em').text(data.result);
                    $(".tree"+id).attr('lever','tree_lever_2'+data.url);
                    layer.msg(data.message,{time:1000});  
                  }else{
                    layer.msg(data.message);
                  }    
             }     
        });
      
   } 




 




//收割
function shougejs(obj){
        //关闭当前窗口
        $('.beans').hide();
        var id=$(obj).attr('data');
        var landtype=$(obj).attr('landtype');
        var status=$(obj).attr('status');
        if(id=='' || id==null){
          return false;
        }
        var index = layer.load(1, {
          shade: [0.1,'#fff'] //0.1透明度的白色背景
        }); 
         $.ajax({
             type: "POST",
             url: '/Ajaxdz/shouge',
             data:{'id':id,'farmid':landtype},
             dataType: "json",
             success: function(data){
                layer.close(index);
               if(data.status==1){//收割失败
                  editdata();
                  $(obj).parents('.land').find('.beans em').text(data.result);
                  if(status!=3){
                     $(obj).parents('.land').find('.tree').attr('lever','tree_lever_1');
                  }
                   layer.msg(data.message);
                }else{
                  layer.msg(data.message);
                }  
             }     
        });
   }


   //施肥
   function shifeijs(obj){
          var type=$(obj).attr('data');
          if(type=='0'){
            message('您今天已经施肥过了！明天再来~');
            return ;
          }
          var index = layer.load(1, {
            shade: [0.1,'#fff'] //0.1透明度的白色背景
          });

          $.ajax({
             type: "POST",
             url:'/Ajaxdz/shifei',
             data:{},
             dataType: "json",
             success: function(data){
                    layer.close(index);
                    if(data.status==1){
                       $(obj).attr('data','0');
                       message(data.message);
                       changetree();
                       editdata();
                    }else{
                      layer.msg(data.message);
                    }        
              }     
          });
  }


  //施肥成功修改树的状态
  function changetree(){
      var url="/Home/Index/landdata";
      $.post(url,{},function(data){
          if(data){
            $.each(data,function(k,v){
              if(v.status==3){
                $('.tree'+v.id).attr('lever','tree_lever_3'+v.type);
              }else{
                $('.tree'+v.id).attr('lever','tree_lever_2'+v.type);
              }
              $('.tree'+v.id).prev('.beans').find('em').text(v.num*1);
            })
          }
      });
  }


//==============游戏界面=================E==================

//修改显示数据
function editdata(){
    var url="/Home/Index/StoreData";
    $.post(url,{},function(msg){
        $('#cangku').text(msg.cangku);
        $('#plant').text(msg.plant);
        //
        $('#cangku', parent.document).text(msg.cangku);
    });
}


 function postznx(){

    //验证数据
    var thisform=document.forms['formznx'];
    var title=thisform.title.value;
    var content=thisform.content.value;
    if(title=='' || title==null){
      layer.msg('请输入标题');
      return false;
    }
    
    if(content=='' || content==null){
      layer.msg('请输入内容');
      return false;
    }

    //正在加载
    var index = layer.load(1, {
        shade: [0.1,'#fff']
    });

    var post_url = $("form[name='formznx']").attr('action');
    var post_data= $("form[name='formznx']").serialize();
    $.ajax({
         type: "POST",
         url: post_url,
         data:post_data,
         dataType: "json",
         success: function(data){
            layer.close(index);//关闭加载
            if(data.status==1){

              layer.msg(data.message,{time:1000},function(){
               $('.empty').val('');
                // location.reload();
              });
            }
            else{
                layer.msg(data.message);
            }      
          }     
    });
 }
 




$(function(){

  //商店完 
    $(".jannet").click(function() {
        $(this).hide();
        $(".navigation").stop().animate({"left": 0});
    });

    $('.jannet-close').click(function(){
        $('.jannet').show();
       $(".navigation").stop().animate({"left":'-45%'});
    });

    $('.close').click(function(){
        $(this).parent('.transaction').hide();
         $(this).parent('.transaction').next('div').hide();
    });
    function showbox(boxid){
        $(".transaction:not(#"+boxid+")").hide();
        $('#'+boxid).next('div').show();
        $('#'+boxid).toggle();
    }


    //菜单选择效果
    $('.navigation ul li').click(function(){
        $(this).addClass('click').siblings('li').removeClass('click');
    });

    //底部菜单选中
    $('.foor_nav ul li').click(function(){
        $(this).addClass('select').siblings('li').removeClass('select');
    })


    // 控制数量加减
    $(".jian").click(function(){
      
       var num=parseInt($(this).next('.num').val());
        num-=1;
        if(num<=1)
          num=1;
       $(this).next('.num').val(num);
    });

     $(".jia").click(function(){
      var num=parseInt($(this).prev('.num').val());
        num+=1;
       $(this).prev('.num').val(num);
    });


     //树提示框
     $('.tree').click(function(){
        $(this).prev('.beans').show().parent('.land').siblings('.land').find('.beans').hide();
     })

     $('.beans span').click(function(){
        $('.beans').hide();
     })
})

//选择道具
function SelectTool(obj){
  var val=$(obj).val();
  var num=100;
  if(val==2)
    num=30;

  $('#buy_num').val(num);
  $('#show_num').text(num);
  $('#num').text('1');

}


function ExcGameBi(obj){

  var fruit=$(obj).val();
  if(fruit){
    fruit=parseInt(fruit);
    fruit=fruit*10;
    $("#gamebi").val(fruit);
  }else{
    $("#gamebi").val('0');
  }

}


//找回密码
function SetPwd(){

    //验证数据
    var thisform=document.forms['getpwdfrom'];
    var mobile=thisform.mobile.value;
    var code=thisform.code.value;
    var passwordmin=thisform.passwordmin.value;
    var password=thisform.password.value;
    if(mobile=='' || mobile==null){
      layer.msg('请输入手机号码');
      return false;
    }
    
    if(code=='' || code==null){
      layer.msg('请输入验证码');
      return false;
    }

    if(password=='' || password==null){
      layer.msg('请输入新密码');
      return false;
    }
    if(passwordmin=='' || passwordmin==null){
      layer.msg('请输入确认密码');
      return false;
    }
    if(passwordmin!=password){
      layer.msg('两次输入密码不一致');
      return false;
    }

    //正在加载
    var index = layer.load(1, {
        shade: [0.1,'#fff']
    });

    var post_url = $("form[name='getpwdfrom']").attr('action');
    var post_data= $("form[name='getpwdfrom']").serialize();
    $.ajax({
         type: "POST",
         url: post_url,
         data:post_data,
         dataType: "json",
         success: function(data){
            layer.close(index);//关闭加载
            if(data.status==1){
              msg_alert(data.message,data.url);
            }
            else{
                layer.msg(data.message);
            }      
          }     
    });
 }



 //获取道具数据
 function getToolData(){
    
    var openshop = $('#openshop').val();//只加载一次数据
    if(openshop=='1')
    {
      document.getElementById('light6').style.display='block';
      document.getElementById('fade6').style.display='block';
      return ;
    }
    //正在加载
    // var index = layer.load(1, {
    //     shade: [0.1,'#fff']
    // });
    $.ajax({
         type: "POST",
         url: "/Index/tooldata",
         data:{},
         dataType: "json",
         success: function(data){
            // layer.close(index);//关闭加载
            if(data.status==1){
              // 树
              $('#huangdi').text(data.result[0]['price']);
              $('#huangdi').next('input').val(data.result[0]['id']);
              $('#hongdi').text(data.result[1]['price']);
              $('#hongdi').next('input').val(data.result[1]['id']);
              $('#heidi').text(data.result[2]['price']);
              $('#heidi').next('input').val(data.result[2]['id']);
              $('#tiyandi').text(data.result[3]['price']);
              $('#tiyandi').next('input').val(data.result[3]['id']);
              // 狗粮
              $('#dogfood').text(data.result[4]['price']);
              $('#dogfood').next('input').val(data.result[4]['id']);
              //一键采蜜
              $('#oneclick').text(data.result[5]['price']);
              $('#oneclick').next('input').val(data.result[5]['id']);
               //农夫
              $('#nongfu').text(data.result[6]['price']);
              $('#nongfu').next('input').val(data.result[6]['id']);
               //鸟
              $('#niao').text(data.result[7]['price']);
              $('#niao').next('input').val(data.result[7]['id']);
              //小鸡
              $('#xiaoji').text(data.result[8]['price']);
              $('#xiaoji').next('input').val(data.result[8]['id']);
              //猫
              $('#mao').text(data.result[9]['price']);
              $('#mao').next('input').val(data.result[9]['id']);
              //小狗
              $('#xiaogou').text(data.result[10]['price']);
              $('#xiaogou').next('input').val(data.result[10]['id']);
              //中狗
              $('#zhonggou').text(data.result[11]['price']);
              $('#zhonggou').next('input').val(data.result[11]['id']);
               //大狗
              $('#dagou').text(data.result[12]['price']);
              $('#dagou').next('input').val(data.result[12]['id']);


              //表示已经加载过数据
              $('#openshop').val('1')
              document.getElementById('light6').style.display='block';
              document.getElementById('fade6').style.display='block';
            }
            else{
                layer.msg(data.message);
            }      
          }     
    });


 }



 //提示框
  function messagesure(id){
    
        var str='';
        str+='<div id="lightr" class="white_content_tbdd" style="display:block" >';
         str+='<a href="javascript:void(0)" class="close" onclick="removebox()" id="guanbi"><img src="/Public/home/wap/images/gb.png"></a>';
        str+='<div class="stealing">'; 
        str+='<p class="btnwx" onclick="BuyTree('+id+')" >在线支付</p>';
        str+='<p class="btngz"  onclick="goland('+id+')" >果子支付</p>';
        str+='</div>';
        // str+='<div class="xftcan">';
        // str+='<ul>';
        // str+='<li class="btn-close" ><a href="javascript:void(0)" onclick="removebox()">关闭</a></li>';
        // str+='</ul>';
        // str+='</div>';
        str+='</div>';
        str+='<div id="fader" class="black_overlay_tb2" style="display:block" ></div>';
        $('body').children("div:first-child").before(str);
  }


  function BuyTree(id){
    var post_url='/Index/buytool';
    var post_data={id:id,type:'tree'};
    var index = layer.load(1, {
        shade: [0.1,'#fff'] //0.1透明度的白色背景
    });

     $.ajax({
           type: "POST",
           url: post_url,
           data:post_data,
           dataType: "json",
           success: function(data){
              layer.close(index);//关闭加载
              if(data.status==1){
                window.location.href=data.url;
                // layer.msg(data.message);
              }
              else{
                  layer.msg(data.message);
              }      
            }     
      });
}



 //购买道具
 function buytool(obj){
  var tool=$(obj).parent('p').parent('li').find("input[type='hidden']");
  var id=tool.val();
  var type=tool.attr('data');
  if(type=='land'){

    //选择果子购买或在线支付
    messagesure(id);
    
  }else{

    var num=$(obj).parent('p').parent('li').find(".num").val();
    if(num!=undefined){
      var data={'id':id,'num':num};
    }else{
      var data={'id':id}
    }
    gotool(data);
  }

 }

 function goland(id){
    removebox();
    var index = layer.load(1, {
        shade: [0.1,'#fff'] //0.1透明度的白色背景
      });
     $.ajax({
           type: "POST",
           url: '/Ajaxdz/kaiken',
           data:{'id':id},
           dataType: "json",
           success: function(data){
              layer.close(index);//关闭加载
              if(data.status==1){
                layer.msg(data.message,{time:1000},function(){
                  location.reload();
                });
              }
              else{
                  layer.msg(data.message);
              }      
            }     
      });
 }


 function gotool(post_data){
    var post_url='/Index/buytool';
    var index = layer.load(1, {
        shade: [0.1,'#fff'] //0.1透明度的白色背景
      });
     $.ajax({
           type: "POST",
           url: post_url,
           data:post_data,
           dataType: "json",
           success: function(data){
              layer.close(index);//关闭加载
              if(data.status==1){
                window.location.href=data.url;
                // layer.msg(data.message);
              }
              else{
                  layer.msg(data.message);
              }      
            }     
      });
}


//显示大转盘
function showzhuangpan(){
  var url='/Turntable/index.html';
  var src= $("#light30 iframe").attr('src');
  if(src=='' || src==null){
    $("#light30 iframe").attr('src',url);
  }
  document.getElementById('light30').style.display='block';
  document.getElementById('fade30').style.display='block';

}


//好友
function FriendData(){
    $('#contentc .page').val('1');
    document.getElementById('light9').style.display='block';
    document.getElementById('fade9').style.display='block';

    var post_url='/User/FriendsData';
    var index = layer.load(1, {
        shade: [0.1,'#fff'] //0.1透明度的白色背景
      });
     $.ajax({
           type: "POST",
           url: post_url,
           data:{},
           dataType: "json",
           success: function(data){
              layer.close(index);//关闭加载
              if(data)
              {
                insertDiv(data,''); 
              }
            }     
      });
}

 function insertDiv(data,type){  
     var uid=$('#uid').val(); 
     var datetime=$('#date').val(); 
     var list = $(".list");
     var str='';

      $.each(data, function(index, v){
         var caimi='不能采蜜';
          str+='<div class="honey">';
          str+='<table class="kkkkk" >';
          str+='<tr>';
          str+='<th>账号：</th>';
          str+='<td>'+v.u_zh.replace(/(\d{3})\d{6}(\d{2})/, '$1****$2')+'</td>';
          str+=' </tr>';
          str+='<tr>';
          str+=' <th>姓名：</th>';
          str+='<td>'+v.u_name+'</td>';
          str+='</tr>';
          str+='<tr>';
          str+=' <th>级别：</th>';
          if(uid==v.u_fuji){
            var level='一级';
            if(v.datestr==datetime && v.pid_caimi!=uid){
              caimi="可以采蜜";
            }
          }
          if(uid==v.u_yeji){
            var level='二级';
            if(v.datestr==datetime && v.gid_caimi!=uid){
              caimi="可以采蜜";
            }
          }
          if(uid==v.u_yyj){
            var level='三级';
            if(v.datestr==datetime && v.ggid_caimi!=uid){
              caimi="可以采蜜";
            }
          }
          str+='<td>'+level+'</td>';
          str+='</tr>';
          str+=' <tr>';
          str+='<th>能否采蜜：</th>';
          str+='<td class="caimistate" >'+caimi+'</td>';
          str+='</tr>';
          str+=' <tr>';
          str+='</table>';
          str+='<div id="anniu_bg" fid="'+v.uid+'" onclick="caimi(this)" ><a href="javascript:" >采蜜</a></div>';
          str+='</div>';
      })
      if(type=='more'){
          list.append(str);  
          $("#more").html("加载更多");  
      }else{
        list.html(str);
      }   
      
 } 

   function loadmore(obj) {  
         var page = $(obj).next('.page').val()
         page=parseInt(page);  
         var oldthis=$(obj);

         oldthis.html("加载中...");  
         $.ajax({  
             type: "get",  
             url: '/User/FriendsData',  
             data: "p=" + page,  
             dataType: "json",  
             success: function (data) {  
                
              /*判断有没有数据*/
              if (data){
                  $(obj).next('.page').val(page + 1);  
                  insertDiv(data,'more');  
               }else{  
                  oldthis.attr('onclick','');
                  oldthis.html("已经没有了");
               }  
             }  
         });  
    }  


  
//采蜜
function caimi(obj){

  var fid=$(obj).attr('fid');
  var index = layer.load(1, {
        shade: [0.1,'#fff'] //0.1透明度的白色背景
      });
     $.ajax({
           type: "POST",
           url: '/User/getfengmi',
           data:{'fid':fid},
           dataType: "json",
           success: function(data){
              layer.close(index);//关闭加载
              if(data.status==1){
                editdata();
                $(obj).prev('table').find('.caimistate').text('不能采蜜');
                layer.msg(data.message);
              }
              else{
                  layer.msg(data.message);
              }      
            }     
      });
}


//==============采蜜记录======S========
function caimidata(){

    $('#contentc .page').val('1');

    var post_url='/Growth/caimijilu';
    var index = layer.load(1, {
        shade: [0.1,'#fff'] //0.1透明度的白色背景
      });
     $.ajax({
           type: "POST",
           url: post_url,
           data:{},
           dataType: "json",
           success: function(data){
              layer.close(index);//关闭加载
              if(data)
              {
                insertCaimi(data,''); 
              }
            }     
      });
}

function insertCaimi(data,type){  
     var list = $(".list2");
     var str='';

      $.each(data, function(index, v){

           str+='<div class="honey">';
              str+='<table>';
                  str+='<tr>';
                      str+='<th>好友：</th>';
                      str+='<td>'+v.uname+'</td>';
                  str+='</tr>';
                  str+='<tr>';
                      str+='<th>采蜜数量：</th>';
                      str+='<td>'+v.caimi_num*1+'</td>';
                  str+='</tr>';
                  str+='<tr>';
                      str+='<th>时间：</th>';
                      str+='<td>'+v.tt+'</td>';
                  str+='</tr>';
              str+='</table>';
          str+='</div>';
      })
      if(type=='more'){
          list.append(str);  
          $("#more2").html("加载更多");  
      }else{
        list.html(str);
      }   
      
 } 

   function loadmorecaimi(obj) {  
         var page = $(obj).next('.page').val()
         page=parseInt(page);  
         var oldthis=$(obj);

         oldthis.html("加载中...");  
         $.ajax({  
             type: "get",  
             url: '/Growth/caimijilu',  
             data: "p=" + page,  
             dataType: "json",  
             success: function (data) {  
                
              /*判断有没有数据*/
              if (data){
                  $(obj).next('.page').val(page + 1);  
                  insertCaimi(data,'more');  
               }else{  
                  oldthis.attr('onclick','');
                  oldthis.html("已经没有了");
               }  
             }  
         });  
    }
//==============采蜜记录======E========


//一键采蜜
function onecaimi(){

    var post_url='/User/onecaimi';
    var index = layer.load(1, {
        shade: [0.1,'#fff'] //0.1透明度的白色背景
      });
     $.ajax({
           type: "POST",
           url: post_url,
           data:{},
           dataType: "json",
           success: function(data){
              layer.close(index);//关闭加载
              if(data.status==1){
                $('.caimistate').text('不能采蜜');
                layer.msg(data.message);
              }
              else{
                  layer.msg(data.message);
              }
            }     
      });
}


//++++自由交易+++++S+++
function trading(){
  $.ajax({
           type: "POST",
           url: '/Trading/freesell',
           data:{},
           dataType: "json",
           success: function(data){
              $('#tradingfee').attr('fee',data.fee1);
              $('#directfee').attr('fee',data.fee2);
            }     
      });
}

//计算手续费
function exenum(obj){
        var num_old=$(obj).val();
        if(num_old!='')
        var num=parseInt(num_old);
        var fee=Number($("#tradingfee").attr('fee'));
        var fee_num=num*fee;
        var total=num+fee_num;
        fee_num=Math.round(fee_num*100)/100;//保留两位小数
        if(num_old=='' || num_old==null){
          total='0';
          fee_num='0';
        }
            
        $('#tradingfee').val(fee_num);
        $('#selltotal').val(total);
    }

function ExeDirectNum(obj){

    var num_old=$(obj).val();
    if(num_old!='')
      var num=parseInt(num_old);

    var fee=Number($("#directfee").attr('fee'));
    var fee_num=num*fee;
    var total=num+fee_num;
    fee_num=Math.round(fee_num*100)/100;//保留两位小数
    if(num_old=='' || num_old==null){
      total='0';
      fee_num='0';
    }
        
    $('#directfee').val(fee_num);
    $('#directtotal').val(total);
}


function showimg(obj){
    $(obj).next('input').click();
}


//出售果子
function sellfruit(){

    //验证数据
    var thisform=document.forms['sellfruit_from'];
    var sell_num=thisform.sellnum.value;
    var upimg=thisform.getmonecode.value;
    var two_pw=thisform.two_pw.value;
    if(sell_num=='' || sell_num==null){
      layer.msg('请输入出售数量');
      return false;
    }
    if(!/^[1-9]\d*$/.test(sell_num)){
      layer.msg('出售请输入整数');
      return false;
    }
    if(sell_num<10){
      layer.msg("出售数量必须大于或等于10");
      return false;
    }

    if(upimg=='' || upimg==null){
      layer.msg('请上传收款二维码');
      return false;
    }
    if(two_pw=='' || two_pw==null){
      layer.msg('请输入交易密码');
      return false;
    }
   

    //正在加载
    var index = layer.load(1, {
        shade: [0.1,'#fff']
    });
    var post_url = $("form[name='sellfruit_from']").attr('action');
    var post_data= $("form[name='sellfruit_from']").serialize();
    $.ajax({
         type: "POST",
         url: post_url,
         data:post_data,
         dataType: "json",
         success: function(data){
            layer.close(index);//关闭加载
            if(data.status==1){
               editdata();
              layer.msg(data.message,{time:1500},function(){
                $('.empty').val('');
                $('#imghead').attr('src','/Public/home/wap/images/a1.png');
              });
            }
            else{
                layer.msg(data.message);
            }      
          }     
    });
}

//定向交易
function DirectSellFruit(){

    //验证数据
    var thisform=document.forms['directsellfruit_from'];
    var sell_num=thisform.sellnum.value;
    var account=thisform.account.value;
    var username=thisform.username.value;
    var two_pw=thisform.two_pw.value;
    var rwmcode=thisform.rwmcode.value;
    if(sell_num=='' || sell_num==null){
      layer.msg('请输入出售数量');
      return false;
    }
    if(!/^[1-9]\d*$/.test(sell_num)){
      layer.msg('出售请输入整数');
      return false;
    }
    if(account=='' || account==null){
      layer.msg('请输入买家账号');
      return false;
    }
    if(username=='' || username==null){
      layer.msg('请输入买家姓名');
      return false;
    }
    if(two_pw=='' || two_pw==null){
      layer.msg('请输入交易密码');
      return false;
    }
    if(rwmcode=='' || rwmcode==null){
      layer.msg('请上传收款二维码');
      return false;
    }
   

    //正在加载
    var index = layer.load(1, {
        shade: [0.1,'#fff']
    });
    var post_url = $("form[name='directsellfruit_from']").attr('action');
    var post_data= $("form[name='directsellfruit_from']").serialize();
    $.ajax({
         type: "POST",
         url: post_url,
         data:post_data,
         dataType: "json",
         success: function(data){
            layer.close(index);//关闭加载
            if(data.status==1){
               editdata();
              layer.msg(data.message,{time:1500},function(){
                $('.empty').val('');
                $('#imgheadtwo').attr('src','/Public/home/wap/images/a1.png');
              });
            }
            else{
                layer.msg(data.message);
            }      
          }     
    });
}




//确认购买
 function surebuy(obj,type){
    var id=$(obj).attr('data');
    //正在加载
    var index = layer.load(1, {
        shade: [0.1,'#fff']
    });

    var url='/Trading/surefreebuy';
    if(type==1){
      url='/Trading/surebuy';
    }

    $.ajax({
         type: "POST",
         url: url,
         data:{'id':id},
         dataType: "json",
         success: function(data){
            layer.close(index);//关闭加载
            if(data.status==1){
              layer.msg(data.message,{time:1500},function(){
                if(type==1){
                  $(obj).after('<span class="dengdai">等待卖家确认收款</span>');
                  $(obj).remove();
                }else{
                  $(obj).parents('.transaction').remove();
                }
              });
            }
            else{
                layer.msg(data.message);
            }      
          }     
    });
 }


 //确认收款
 function suresell(obj,type){
    var id=$(obj).attr('data');
    //正在加载
    var index = layer.load(1, {
        shade: [0.1,'#fff']
    });

    var url='/Trading/surefreesell';
    if(type==1){
      url='/Trading/suresell';
    }

    $.ajax({
         type: "POST",
         url: url,
         data:{'id':id},
         dataType: "json",
         success: function(data){
            layer.close(index);//关闭加载
            if(data.status==1){
              editdata();
              layer.msg(data.message,{time:1500},function(){
                $(obj).parents('.transaction').remove();
                $(obj).parents('.transaction').remove();
              });
            }
            else{
                layer.msg(data.message);
            }      
          }     
    });
 }

 //取消交易
 function quitsell(obj,type){

    if(!confirm('确实要取消吗?')){
      return false;
    }

    var id=$(obj).attr('data');
    //正在加载
    var index = layer.load(1, {
        shade: [0.1,'#fff']
    });
    
    var url='/Trading/quitfreesell';
    if(type==1){
      url='/Trading/quitsell';
    }

    $.ajax({
         type: "POST",
         url: url,
         data:{'id':id},
         dataType: "json",
         success: function(data){
            layer.close(index);//关闭加载
            if(data.status==1){
              layer.msg(data.message,{time:1500},function(){
                 $(obj).parents('.transaction').remove();
              });
            }
            else{
                layer.msg(data.message);
            }      
          }     
    });
 }


 //取消交易
 function quitTradeOrder(obj,type){

    if(!confirm('确实要取消吗?')){
      return false;
    }

    var id=$(obj).attr('data');
    //正在加载
    var index = layer.load(1, {
        shade: [0.1,'#fff']
    });
    
    var url='/Trading/cancelTradeOrder';
    if(type==1){
      url='/Trading/quitTradingOrder';
    }
    $.ajax({
         type: "POST",
         url: url,
         data:{'id':id},
         dataType: "json",
         success: function(data){
            layer.close(index);//关闭加载
            if(data.status==1){
              layer.msg(data.message,{time:1500},function(){
                 $(obj).parents('.transaction').remove();
              });
            }
            else{
                layer.msg(data.message);
            }      
          }     
    });
 }


function uploadFile() { 
  //正在加载
 
  $.ajaxFileUpload({
  
      url:'/Trading/uplodeimg',
      secureuri:false ,
      fileElementId:'upimg',
      dataType: 'text',
      success: function (data,status)  
      {
        
        var data = $.parseJSON(data);
         if(data.status==1){
           $('#imghead').attr('src',data.res);
           $("input[name='getmonecode']").val(data.res);
         }else{
           layer.msg('头像上传失败');
         }
        
      },
      error: function (data, status, e)
      {
        alert(e);
      }
    });
  return false;

} 

function uploadFileTwo() { 

  $.ajaxFileUpload({
  
      url:'/Trading/uplodeimg',
      secureuri:false ,
      fileElementId:'upimgtwo',
      dataType: 'text',
      success: function (data,status)  
      {
        
        var data = $.parseJSON(data);
         if(data.status==1){
           $('#imgheadtwo').attr('src',data.res);
           $("input[name='rwmcode']").val(data.res);
         }else{
           layer.msg('头像上传失败');
         }
        
      },
      error: function (data, status, e)
      {
        alert(e);
      }
    });
  return false;

} 


//抢购列表
function BuyList(){

    $('.pagebuy').val('1');

    var post_url='/Trading/freebuy';
    var index = layer.load(1, {
        shade: [0.1,'#fff'] //0.1透明度的白色背景
      });
     $.ajax({
           type: "POST",
           url: post_url,
           data:{},
           dataType: "json",
           success: function(data){
              layer.close(index);//关闭加载
              if(data)
              {
                insertBuy(data,''); 
              }
            }     
      });
}

function insertBuy(data,type){  
     var list = $(".listbuy");
     var str='';

      $.each(data, function(index, v){

            str+='<div class="honey transaction">';
               str+='<p>'+v.u_username+'</p>';
               str+='<p>'+v.u_account+'<span>果子：'+v.sellnum+'</span></p>';
               str+='<p>'+v.tt+'<span data="'+v.id+'" onclick ="surebuy(this)" class="purchase"><a href="javascript:void(0)" >确认抢购</a></span></p>';
            str+='</div>';
      })
      if(type=='more'){
          list.append(str);  
          $("#morebuy").html("加载更多");  
      }else{
        list.html(str);
      }   
      
 } 

   function LoadMoreBuy(obj) {  
         var page = $(obj).next('.pagebuy').val()
         page=parseInt(page);  
         var oldthis=$(obj);

         oldthis.html("加载中...");  
         $.ajax({  
             type: "get",  
             url: '/Trading/freebuy',  
             data: "p=" + page,  
             dataType: "json",  
             success: function (data) {  
                
              /*判断有没有数据*/
              if (data){
                  $(obj).next('.pagebuy').val(page + 1);  
                  insertBuy(data,'more');  
               }else{  
                  oldthis.attr('onclick','');
                  oldthis.html("已经没有了");
               }  
             }  
         });  
    }





  //代收款列表
function WaiBuyList(){

    $('.pagewaibuy').val('1');
    $("#morewaitbuy").html("加载更多");  
    var post_url='/Trading/freewait';
    var index = layer.load(1, {
        shade: [0.1,'#fff'] //0.1透明度的白色背景
      });
     $.ajax({
           type: "POST",
           url: post_url,
           data:{},
           dataType: "json",
           success: function(data){
              layer.close(index);//关闭加载
              if(data)
              {
                insertWaitBuy(data,''); 
              }
            }     
      });
}

function insertWaitBuy(data,type){ 
     var uid=$('#uid').val(); 
     var list = $(".listwaitbuy");
     var str='';

      $.each(data, function(index, v){

          var username='';
          var account='';
          var statusname='';
          var fun='';
          //自己出售
          if(uid==v.s_id){
           
            if(v.status==0){
               username='暂无人购买';
               account='';
              statusname="取消挂卖";
              fun='quitsell(this)';
            }
            if(v.status==1){
              username=v.b_username;
              account=v.b_account;
              statusname="确认收款";
              fun='suresell(this)';
              cancelname = "取消交易";
              cancelFun = 'quitTradeOrder(this)';
            }
          }
          //购买回来
          if(uid==v.b_id){
            username=v.s_username;
            account=v.s_account;
           
          }

          str+='<div class="honey transaction">';
             if(uid==v.s_id && v.status==1){
              str+='<p>'+username+'<span data="'+v.id+'" onclick ="'+cancelFun+'" style="color: red;font-size: 4vmin;">'+cancelname+'</span></p>';
             }else{
              str+='<p>'+username+'</p>';
             }
             str+='<p>'+account+'<span>果子：'+v.num+'</span></p>';
             str+='<p class="picture">'+v.tt;
                  str+='<i><a href="javascript:void(0)" data="'+v.img+'" onclick ="showbuyimg(this)">[查看图片]</a></i>';
                if(uid==v.s_id){
                  str+='<span class="purchase" data="'+v.id+'" onclick ="'+fun+'" ><a href="javascript:void(0)" >'+statusname+'</a>';
                  str+='</span>';
                }
              str+='</p>';
              if(uid==v.b_id && v.status==1){
                str+='<span class="dengdai">等待卖家确认收款</span>';
              }
          str+='</div>';
      })
      if(type=='more'){
          list.append(str);  
          $("#morewaitbuy").html("加载更多");  
      }else{
        list.html(str);
      }   
      
 } 

   function LoadMoreWaitBuy(obj) {  
         var page = $(obj).next('.pagewaitbuy').val()
         page=parseInt(page);  
         var oldthis=$(obj);

         oldthis.html("加载中...");  
         $.ajax({  
             type: "get",  
             url: '/Trading/freebuy',  
             data: "p=" + page,  
             dataType: "json",  
             success: function (data) {  
                
              /*判断有没有数据*/
              if (data){
                  $(obj).next('.pagewaitbuy').val(page + 1);  
                  insertWaitBuy(data,'more');  
               }else{  
                  // oldthis.attr('onclick','');
                  oldthis.html("已经没有了");
               }  
             }  
         });  
    }


  //定向交易代收款列表
function WaiDirectList(){

    $('.pagewaidirect').val('1');
    $("#morewaitdirect").html("加载更多");  
    var post_url='/Trading/directwait';
    var index = layer.load(1, {
        shade: [0.1,'#fff'] //0.1透明度的白色背景
      });
     $.ajax({
           type: "POST",
           url: post_url,
           data:{},
           dataType: "json",
           success: function(data){
              layer.close(index);//关闭加载
              if(data)
              {
                insertWaitDirect(data,''); 
              }
            }     
      });
}

function insertWaitDirect(data,type){ 
     var uid=$('#uid').val(); 
     var list = $(".listwaitdirect");
     var str='';

      $.each(data, function(index, v){

          var username='';
          var account='';
          var statusname='';
          var fun='';

          username=v.b_username;
          account=v.b_account;
          //自己出售
          if(uid==v.s_id){
           
            if(v.status==0){
              statusname="取消挂卖";
              fun='quitsell(this,1)';
            }
            if(v.status==1){
              statusname="确认收款";
              fun='suresell(this,1)';
              cancelname = "取消交易";
              cancelFun = 'quitTradeOrder(this,1)';
            }
          }
          //购买回来
          if(uid==v.b_id){
            username=v.s_username;
            account=v.s_account;

            if(v.status==0){
              statusname="确认购买";
              fun='surebuy(this,1)';
            }
          }

          str+='<div class="honey transaction">';
            if(uid==v.s_id&&v.status==1){
              str+='<p>'+username+'<span data="'+v.id+'" onclick ="'+cancelFun+'" style="color: red;font-size: 4vmin;">'+cancelname+'</span></p>';
             }else{
              str+='<p>'+username+'</p>';
             }
             str+='<p>'+account+'<span>果子：'+v.num+'</span></p>';
             str+='<p class="picture">'+v.tt;
                  str+='<i><a href="javascript:void(0)" data="'+v.img+'" onclick ="showbuyimg(this)">[查看图片]</a></i>';
              if(uid==v.b_id && v.status==1){
                str+='<span class="dengdai">等待卖家确认收款</span>';
              }else{
                str+='<span class="purchase" data="'+v.id+'" onclick ="'+fun+'" ><a href="javascript:void(0)" >'+statusname+'</a>';
                str+='</span>';
              }
              str+='</p>';
              
          str+='</div>';
      })
      if(type=='more'){
          list.append(str);  
          $("#morewaitdirect").html("加载更多");  
      }else{
        list.html(str);
      }   
      
 } 

   function LoadMoreWaitDirect(obj) {  
         var page = $(obj).next('.pagewaitdirect').val()
         page=parseInt(page);  
         var oldthis=$(obj);

         oldthis.html("加载中...");  
         $.ajax({  
             type: "get",  
             url: '/Trading/directwait',  
             data: "p=" + page,  
             dataType: "json",  
             success: function (data) {  
                
              /*判断有没有数据*/
              if (data){
                  $(obj).next('.pagewaitdirect').val(page + 1);  
                  insertWaitDirect(data,'more');  
               }else{  
                  // oldthis.attr('onclick','');
                  oldthis.html("已经没有了");
               }  
             }  
         });  
    }





//查看收款码
function showbuyimg(obj){
        var url=$(obj).attr('data');
        var str='';
        str+='<div id="light22" class="white_content_tb2" style="height: 86vmin;background-size: 100% 100%;top: 20%;display:block;z-index:1015">';
            str+='<div class="stealing tupian"> ';
                str+='<p><img src="'+url+'"></p>';
            str+='</div>';
            str+='<div class="xftcan">';
                str+='<ul>';
                    str+='<li id="queding"><a href="javascript:void(0)" onclick="removeshowbuyimg()">关闭</a></li>';
                str+='</ul>';
           str+=' </div>';
        str+='</div>';
        str+='<div id="fade22" style="display:block;z-index:1005" class="black_overlay_tb2"></div>';

        $('body').children("div:first-child").before(str);
  }

function removeshowbuyimg(){
  $('#light22').remove();
  $('#fade22').remove();
}



//++++自由交易+++++E+++


// ++++交易记录+++S++
function TradingDetail(gettype){
    if(gettype==0){
      $('#ulff>li').eq(0).addClass('currentf').siblings().removeClass('currentf');
      var post_url='/Trading/sellrecord';
      $('#moretradingdetail').attr('data',0);
    }
    else{
      $('#ulff>li').eq(1).addClass('currentf').siblings().removeClass('currentf');
       var post_url='/Trading/buyrecord';
       $('#moretradingdetail').attr('data',1);
    }

    $('.pagetradingdetail').val('1');
    $("#moretradingdetail").html("加载更多");  
    
    var index = layer.load(1, {
        shade: [0.1,'#fff'] //0.1透明度的白色背景
      });
     $.ajax({
           type: "POST",
           url: post_url,
           data:{},
           dataType: "json",
           success: function(data){
              layer.close(index);//关闭加载
              if(data)
              {
                insertTradingDetail(data,'',gettype); 
              }else{
                $(".listtradingdetail").html('');
              }
            }     
      });
}

function insertTradingDetail(data,type,gettype){ 
     var list = $(".listtradingdetail");
     var str='';

      $.each(data, function(index, v){
            if(v.status==3){
              var status_name="取消交易";
            }else{
              var status_name="交易成功";
            }
            var username='';
            var account='';
            if(gettype==0){
              if(v.b_username){
                username=v.b_username+'<span>手续费：'+v.fee_num+'</span>';
                account=v.b_account;
              }else{
                username='无人购买<span>手续费：'+v.fee_num+'</span>';
                account="　";
              }
              
            }else{
              username=v.s_username;
              account=v.s_account;
            }

            str+='<div class="honey transaction">';
               str+='<p>'+username+'</p>';
               str+='<p>'+account+'<span>果子：'+v.num+'</span></p>';
               str+='<p>'+v.tt+'<span><i>'+status_name+'</i></span></p>';
            str+='</div>';
      })
      if(type=='more'){
          list.append(str);  
          $("#moretradingdetail").html("加载更多");  
      }else{
        list.html(str);
      }   
      
 } 

   function LoadMoreTradingDetail(obj) {  
         var page = $(obj).next('.pagetradingdetail').val()
         page=parseInt(page);  
         var oldthis=$(obj);
         var type=$('#moretradingdetail').attr('data');
         if(type==0){
            var geturl='/Trading/sellrecord';
         }else{
          var geturl='/Trading/buyrecord';
         }

         oldthis.html("加载中...");  
         $.ajax({  
             type: "get",  
             url: geturl,  
             data: "p=" + page,  
             dataType: "json",  
             success: function (data) {  
                
              /*判断有没有数据*/
              if (data){
                  $(obj).next('.pagetradingdetail').val(page + 1);  
                  insertTradingDetail(data,'more');  
               }else{  
                  // oldthis.attr('onclick','');
                  oldthis.html("已经没有了");
               }  
             }  
         });  
    }

// ++++交易记录+++E++


//修改密码
function updatepwd(){
   var post_url = $('#updatepwd').attr('action');
   var post_data=$('#updatepwd').serialize();
   $.ajax({
       type: "POST",
       url: post_url,
       data:post_data,
       dataType: "json",
       success: function(data){
        if(data.status==1){
          layer.msg(data.message,{time:1500},function(){
            $('#updatepwd input').val('');
          });
        }else{
          layer.msg(data.message);
        }      
        }     
  });
}


// ++++收获、播种、施肥记录+++S++
function LandDetail(gettype){
    $('#ulf>li').eq(gettype).addClass('currentf').siblings().removeClass('currentf');
    $('#morelanddetail').attr('data',gettype);

    if(gettype==0){
      var post_url='/Growth/bozhongjilu';
    }
    if(gettype==1){
      var post_url='/Growth/shifeijilu';
    }
    if(gettype==2){
      var post_url='/Growth/shougejilu';
    }
    

    $('.pagelanddetail').val('1');
    $("#morelanddetail").html("加载更多");  
    
    var index = layer.load(1, {
        shade: [0.1,'#fff'] //0.1透明度的白色背景
      });
     $.ajax({
           type: "POST",
           url: post_url,
           data:{},
           dataType: "json",
           success: function(data){
              layer.close(index);//关闭加载
              if(data)
              {
                insertLandDetail(data,'',gettype); 
              }else{
                $(".listlanddetail").html('');
              }
            }     
      });
}

function insertLandDetail(data,type,gettype){ 
     var list = $(".listlanddetail");
     var str='';

      $.each(data, function(index, v){
           
            str+='<div class="honey">';
              str+='<table>';
                 str+=' <tbody>';
                  if(gettype!=1){
                      str+='<tr>';
                          str+='<th>土地编号：</th>';
                          str+='<td>'+v.farm_id+'</td>';
                      str+='</tr>';
                  }
                      str+='<tr>';
                          str+='<th>数量：</th>';
                          str+='<td>'+v.num+'</td>';
                      str+='</tr>';
                      str+='<tr>';
                          str+='<th>时间：</th>';
                          str+='<td>'+v.tt+'</td>';
                      str+='</tr>';
                  str+='</tbody>';
              str+='</table>';
          str+='</div>'; 
      })
      if(type=='more'){
          list.append(str);  
          $("#morelanddetail").html("加载更多");  
      }else{
        list.html(str);
      }   
      
 } 

   function LoadMoreLandDetail(obj) {  
         var page = $(obj).next('.pagelanddetail').val()
         page=parseInt(page);  
         var oldthis=$(obj);
         var type=$('#morelanddetail').attr('data');
         if(type==0){
            var geturl='/Growth/bozhongjilu';
          }
          if(type==1){
            var geturl='/Growth/shifeijilu';
          }
          if(type==2){
            var geturl='/Growth/shougejilu';
          }

         oldthis.html("加载中...");  
         $.ajax({  
             type: "get",  
             url: geturl,  
             data: "p=" + page,  
             dataType: "json",  
             success: function (data) {  
              /*判断有没有数据*/
              if (data){
                  $(obj).next('.pagelanddetail').val(page + 1);  
                  insertLandDetail(data,'more');  
               }else{  
                  // oldthis.attr('onclick','');
                  oldthis.html("已经没有了");
               }  
             }  
         });  
    }

// ++++收获、播种、施肥记录+++E+++



//系统公告
function getNewsData(){

  $.ajax({  
       type: "get",  
       url: '/News/index',  
       data: {},  
       dataType: "json",  
       success: function (data) {  
        if (data){
          var str='';
          $.each(data, function(index, v){
             str+='<div class="honey home">';
               str+='<table id="gonggao">';
                   str+='<tr>';
                       str+='<th>时间：</th>';
                       str+='<td>'+v.tt+'</td>';
                   str+='</tr>';
                    str+='<tr>';
                       str+='<th>标题：</th>';
                       str+='<td>'+v.title+'</td>';
                   str+='</tr>';
                    str+='<tr>';
                       str+='<th>内容：</th>';
                       str+='<td>'+v.content+'</td>';
                   str+='</tr>';
               str+='</table>';
            str+='</div>';
          });
          $('.newslist').html(str);
         }else{  
          
         }  
       }  
   }); 
}


//偷取系统会员数据
function StealData(){

    var post_url='/User/stealdata';
    var index = layer.load(1, {
        shade: [0.1,'#fff'] //0.1透明度的白色背景
      });
     $.ajax({
           type: "POST",
           url: post_url,
           data:{},
           dataType: "json",
           success: function(data){
              layer.close(index);//关闭加载
              if(data)
              {
                insertStealDiv(data,''); 
              }else{
                 $(".steallist").html('暂无数据');
              }
            }     
      });
}

 function insertStealDiv(data,type){  

     var list = $(".steallist");
     var str='';

      $.each(data, function(index, v){
         
            str+='<div class="honey">';
                str+='<table>';
                    str+='<tr>';
                        str+='<th>账号：</th>';
                        str+='<td>'+v.u_zh.replace(/(\d{3})\d{6}(\d{2})/, '$1****$2')+'</td>';
                    str+='</tr>';
                    str+='<tr>';
                        str+='<th>姓名：</th>';
                        str+='<td>'+v.u_name+'</td>';
                    str+='</tr>';
                str+='</table>';
                str+='<div id="anniu_bg" data="'+v.uid+'" onclick="StealFriend(this)" class="ann_r"><a href="#">偷取</a></div>';
            str+='</div>';
      })
      if(type=='more'){
          list.append(str);  
          $("#moresteal").html("加载更多");  
      }else{
        list.html(str);
      }   
      
 } 


 //获取道具数据
 function getOneFood(){

    $.ajax({
         type: "POST",
         url: "/Index/onefooddata",
         data:{},
         dataType: "json",
         success: function(data){
            if(data.status==1){

              if(data.result['one']>0){
                $('#buyoneclick').show();
                $('#buyoneclick .endtime').text(data.result['endo1']);
                $('#buyoneclick .xianshi').text(data.result['one_status']);
              }
              if(data.result['food']>0){
                $('#buydogfood').show();
                $('#buydogfood .endtime').text(data.result['endf1']);
                $('#buydogfood .xianshi').text(data.result['one_status']);
              }
            }
          }     
    });


 }



 function DogEatHide(obj){
    $(obj).parent('.beans').hide();
  }

function ShowTip(obj){
  $(obj).prev('.beans').show();
}

//喂狗
function DogEat(obj){
  $(obj).parent('.beans').hide();
  var data=$(obj).attr('data');
  var index = layer.load(1, {
        shade: [0.1,'#fff'] //0.1透明度的白色背景
      });
  $.ajax({
         type: "POST",
         url: "/Index/DogEat",
         data:{},
         dataType: "json",
         success: function(data){
             layer.close(index);//关闭加载
             if(data.status==1){
              layer.msg(data.message);
            }else{
              layer.msg(data.message);
            }
          }     
    });
}


//偷好友的
 function StealFriend(obj){
  var uid =$(obj).attr('data');
  if(uid){
      var index = layer.load(1, {
        shade: [0.1,'#fff'] //0.1透明度的白色背景
      });
      $.ajax({
             type: "POST",
             url: "/User/StealFriend",
             data:{'uid':uid},
             dataType: "json",
             success: function(data){
                 layer.close(index);//关闭加载
                 if(data.status==1){
                  editdata();
                  layer.msg(data.message,{time:1500},function(){
                    $(obj).parents('.honey').remove();
                  });
                }else{
                  layer.msg(data.message);
                }
              }     
        });
  }
}


//==============偷取记录======S========
function StealDeatail(){

    $('.pagesteal').val('1');

    var post_url='/Growth/StealDeatail';
    var index = layer.load(1, {
        shade: [0.1,'#fff'] //0.1透明度的白色背景
      });
     $.ajax({
           type: "POST",
           url: post_url,
           data:{},
           dataType: "json",
           success: function(data){
              layer.close(index);//关闭加载
              if(data)
              {
                insertSteal(data,''); 
              }
            }     
      });
}

function insertSteal(data,type){  
     var list = $(".liststeal");
     var str='';

      $.each(data, function(index, v){

           str+='<div class="honey">';
              str+='<table>';
                  str+='<tr>';
                      str+='<th>对方：</th>';
                      str+='<td>'+v.uname+'</td>';
                  str+='</tr>';
                  str+='<tr>';
                      str+='<th>数量：</th>';
                      str+='<td>'+v.s_num+'</td>';
                  str+='</tr>';
                   str+='<tr>';
                      str+='<th>状态：</th>';
                      str+='<td>'+v.type_name+'</td>';
                  str+='</tr>';
                  str+='<tr>';
                      str+='<th>时间：</th>';
                      str+='<td>'+v.tt+'</td>';
                  str+='</tr>';
              str+='</table>';
          str+='</div>';
      })
      if(type=='more'){
          list.append(str);  
          $("#moresteal").html("加载更多");  
      }else{
        list.html(str);
      }   
      
 } 

   function loadmoresteal(obj) {  
         var page = $(obj).next('.pagesteal').val()
         page=parseInt(page);  
         var oldthis=$(obj);

         oldthis.html("加载中...");  
         $.ajax({  
             type: "get",  
             url: '/Growth/StealDeatail',  
             data: "p=" + page,  
             dataType: "json",  
             success: function (data) {  
                
              /*判断有没有数据*/
              if (data){
                  $(obj).next('.pagesteal').val(page + 1);  
                  insertSteal(data,'more');  
               }else{  
                  oldthis.attr('onclick','');
                  oldthis.html("已经没有了");
               }  
             }  
         });  
    }
//==============偷取记录======E========

//根据手机号码或者id获取联系人
    function Checku(){
    var post_url='/Index/Turnout';
    var ooomj =$.trim($('#phone_uid').val()); //账号  //.trim() 去空格判断
    var exg = /^[1-9]\d*|0$/;
    if(!exg.test(ooomj)){
        layer.msg('对方账户不能为空');
        return;
    }
    $.ajax({
        type: "POST",
        url: post_url,
        data:{'uinfo':ooomj},
        dataType: "json",
        success: function(mes){
            if(mes.status == 1)
            {
                window.location.href=mes.message;
            }else{
                msg_alert(mes.message);
            }
        }
    });
}
