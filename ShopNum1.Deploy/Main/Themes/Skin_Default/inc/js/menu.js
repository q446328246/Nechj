/********************************************************************************
作者：zidou &&
日期：20090818
说明：
基于jquery1.3.2
使用方法：
文档加载完之后在js中实例化即可
new $menu('#menu > li',3.1,500);
new $menu('#bar > dl',1);
第一个参数为jquery选择器的使用方法，定位到一级列表，即实例中第一级li
第二个参数为模式
	模式0(默认模式):二级目录全部展开，单击一级目录关闭或展开，可以同时打开二级目录
	模式1：二级目录全部关闭，单击一级目录关闭或展开，可以同时打开二级目录
	模式2：二级目录全部关闭，单击一级目录关闭或展开，只可以展开一个二级目录
	模式3：二级目录至少展开一项，默认展开第一项，不可全部关闭，单击一级目录关闭或展开，只可以展开一个二级目录，如果想让第x个二级目录默认打开，则模式中输入3.x即可，如模式3.x实例中mode值为3.1
第三个参数为二级菜单展开速度，单位毫秒

HTML:
第一种
<ul id="menu">
	<li>
		<span>一级</span>
		<ul>
		<li>11111111</li>
		<li>2222222</li>
		<li>3333333</li>
		</ul>
	</li>
	<li>
		<span>一级</span>
		<ul>
		<li>7777777</li>
		<li>88888</li>
		</ul>
	</li>
</ul>
第二种
<div id="bar">
	<dl>
		<dt>一级</dt>
		<dd>1111111</dd>
		<dd>22222222</dd>
		<dd>33333333</dd>
	</dl>
	<dl>
		<dt>一级</dt>
		<dd>777777</dd>
		<dd>88888</dd>
	</dl>
</div>
**********************************************************************************/
var $menu=function(el,mode,speed){
	var my=this;
	my.e=el||'';
	my.m=mode||0;
	var arr=(my.m+'').split('.');
	my.s=speed||'fast';
	my.init=function(){// 初始化
		if(my.m>0) my.reg(0);
		if(my.m>2) my.go($(my.e).eq(arr[1]||0).children(':eq(0)'));
		$(my.e).each(function(){
			$(this).hover(function(){// 为一级菜单绑定事件
				if(my.m>1) my.reg();// 复位
				my.go(this);// 展开
				//return false;
			},
			function(){// 为一级菜单绑定事件
				//if(my.m>1) my.reg();// 复位
				$(this).children(":gt(0)").css('display','none');
				//return false;
			});
		});
	}
	my.reg=function(i){
		var oo=$(i)||{};
		$(my.e).not(oo).each(function(){
			$(this).children(":gt(0)").css('display','none');// 复位
		});
	}
	my.go=function(i){
		$(i).children(":gt(0)").slideDown(my.s, function(){my.reg(i);});
	}
	my.init();
}
new $menu('#menu > li',2);

//添加hover class
$(function(){
	$('#menu>li').hover(function(){
		$(this).addClass('hover');
	},function(){
		$(this).removeClass('hover');
	});
});
