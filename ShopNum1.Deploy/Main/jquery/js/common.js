//打开字滑入效果
window.onload = function(){
	$(".connect p").eq(0).animate({"left":"0%"}, 600);
	$(".connect p").eq(1).animate({"left":"0%"}, 400);
};
//jquery.validate表单验证
$(document).ready(function(){
	//登陆表单验证
	$("#loginForm").validate({
		rules:{
			username:{
				required:true,//必填
				minlength:6, //最少6个字符
				maxlength:32,//最多20个字符
			},
			password:{
				required:true,
				minlength:6, 
				maxlength:32,
			},
		},
		//错误信息提示
		messages:{
			username:{
				required:"必须填写用户名",
				minlength:"用户名至少为6个字符",
				maxlength:"用户名至多为32个字符",
				remote: "用户名已存在",
			},
			password:{
				required:"必须填写密码",
				minlength:"密码至少为6个字符",
				maxlength:"密码至多为32个字符",
			},
		},

	});
	//注册表单验证
	$("#registerForm").validate({
		rules:{
			username:{
				required:true,//必填
				minlength:1, //最少6个字符
				maxlength:8,//最多20个字符
				remote:{
					url:"http://kouss.com/demo/Sharelink/remote.json",//用户名重复检查，别跨域调用
					type:"post",
				},
			},
			password:{
				required:true,
				minlength:6, 
				maxlength:32,
			},
			email:{
				required:true,
				email:true,
			},
			confirm_password:{
				required:true,
				minlength:6,
				equalTo:'.password'
			},
			trading_password:{
				required:true,
				minlength:6, 
				maxlength:32,
			},
			code:{
				required:true,
				code:true,
			},
			apassword:{
				required:true,
				minlength:6, 
				maxlength:32,
			},
			phone_number:{
				required:true,
				phone_number:true,//自定义的规则
				digits:true,//整数
			remote:{
					url:"http://kouss.com/demo/Sharelink/remote.json",//用户名重复检查，别跨域调用
					type:"post",
				},
			}
		},
		//错误信息提示
		messages:{
			username:{
				required:"必须填写用户名",
				minlength:"用户名至少为1个字符",
				maxlength:"用户名至多为10个字符",
				remote: "用户名已存在",
			},
			trading_password:{
				required:"必须填写交易密码",
				minlength:"交易密码至少为6个字符",
				maxlength:"交易密码至多为32个字符",
			},
			
			code:{
				required:"请输入验证码",
				code: "请输入正确的验证码"
			},
			password:{
				required:"必须填写登录密码",
				minlength:"登录密码至少为6个字符",
				maxlength:"登录密码至多为32个字符",
			},
			email:{
				required:"请输入邮箱地址",
				email: "请输入正确的email地址"
			},
			confirm_password:{
				required: "请再次输入登录密码",
				minlength: "确认登录密码不能少于6个字符",
				equalTo: "两次输入登录密码不一致",//与另一个元素相同
			},
			phone_number:{
				required:"请输入手机号码",
				digits:"请输入正确的手机号码",
				remote: "手机号已存在",

			},
		
		},
	});

//登陆表单验证
	$("#forgetForm").validate({
		rules:{
			phone_number:{
				required:true,
				phone_number:true,//自定义的规则
				digits:true,//整数
			
			},
			code:{
				required:true,
				code:true,
			},
			password:{
				required:true,
				minlength:6, 
				maxlength:32,
			},
		},
		//错误信息提示
		messages:{
			phone_number:{
				required:"请输入手机号码",
				digits:"请输入正确的手机号码",
				
			},
			code:{
				required:"请输入验证码",
				code: "请输入正确的验证码"
			 },	
			password:{
				required:"请设置新登录密码",
				minlength:"密码至少为6个字符",
				maxlength:"密码至多为32个字符",
			},
		},

	});
	//添加自定义验证规则
	jQuery.validator.addMethod("phone_number", function(value, element) { 
		var length = value.length; 
		var phone_number = /^(11|12|13|14|15|16|17|18|19)\d{9}$/;
		return this.optional(element) || (length == 11 && phone_number.test(value)); 
	}, "手机号码格式错误"); 
});
