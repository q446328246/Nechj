
				$(document).ready(function() {
				    $("a.bigImg").mouseover(function() { //�������ͼƬ����Ʒ�ƶ���ʱ����ʾ��ͼ
				        $(this).css({ "position": "relative", "z-index": "100" });
				        var bigImg = "<div id='bigImg'><img src=" + this.childNodes[0].src + "></div>";
				        $(this).after().append(bigImg);
				        $("#bigImg").css({
				            "top": "80px",
				            "left": "90px",
				            "position": "absolute",
				            "z-index": "1000"
				        }).show("500");
				    }).mouseout(function() {

				        $("#bigImg").remove();
				        $(this).removeAttr("style");
				    });
				})