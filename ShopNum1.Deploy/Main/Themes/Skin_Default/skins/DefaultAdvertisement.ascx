<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="System.Data" %>
<script type="text/javascript">
    var smallImgs = null;
    var smallImgCount = 0;
    var imgStart = 0;
    ///ie加载完成以后进行图片数量的判断
    document.onreadystatechange = function () {
        if (document.readyState == "complete") {
            if (document.getElementById("divSmallImg") != null) {
                smallImgs = document.getElementById("divSmallImg").getElementsByTagName("img");
                if (smallImgs == null)
                    return;
                smallImgCount = smallImgs.length;
                if (smallImgs[0] != null)
                    document.getElementById("AdBigImg").src = smallImgs[0].src;
            }
            //document.body.onload=bigImgOnload();

        }
    }
    //解决火狐元素加载的问题
    if (document.addEventListener) {
        document.addEventListener("DOMContentLoaded", function () {
            smallImgs = document.getElementById("divSmallImg").getElementsByTagName("img");
            smallImgCount = smallImgs.length;
            if (smallImgs[0] != null)
                document.getElementById("AdBigImg").src = smallImgs[0].src;

        }, null);
    }
    var vInterv = window.setInterval(AutoImgChange, 2000);



    ///图片定时事件
    function ImgInterv(iobj) {
        vInterv = window.setInterval(AutoImgChange, 2000);
        $(iobj).attr("style", " height:50px;border:3px solid #4e4e4e;margin-left:4px;filter: Alpha(Opacity=60);opacity:0.6;-moz-opacity:0.6;");
        // iobj.setAttribute("style"," height:50px;border:3px solid #4e4e4e;margin-left:4px;filter: Alpha(Opacity=60);opacity:0.6;-moz-opacity:0.6;");
    }


    ///小图点击效果
    function SmallMover(iobj) {

        window.clearInterval(vInterv);
        document.getElementById("AdBigImg").src = iobj.src;
        document.getElementById("smallImgName").innerHTML = iobj.title;
        //设置链接
        var imghref = $(iobj).parent().attr("href");
        document.getElementById("AdBigImg").parentNode.setAttribute("href", imghref);
        //初始化其它
        for (var i = 0; i < smallImgCount; i++) {
            if (smallImgs[i] != null)
                smallImgs[i].className = "smallImgOver";
            //smallImgs[i].setAttribute("style"," height:50px;border:3px solid #4e4e4e;margin-left:4px;filter: Alpha(Opacity=60);opacity:0.6;-moz-opacity:0.6;");
            $(smallImgs[i]).attr("style", " height:50px;border:3px solid #4e4e4e;margin-left:4px;filter: Alpha(Opacity=60);opacity:0.6;-moz-opacity:0.6;");

        }
        $(iobj).attr("style", "filter: Alpha(Opacity=100);opacity: 1;-moz-opacity: 1;border: 3px solid #f1f1f1;");
        // iobj.setAttribute("style","filter: Alpha(Opacity=100);opacity: 1;-moz-opacity: 1;border: 3px solid #f1f1f1;");
    }

    ///小图片自动切换
    function AutoImgChange() {
        ///还原样式
        for (var i = 0; i < smallImgCount; i++) {
            if (smallImgs[i] != null)
                smallImgs[i].className = "smallImgOver";
            //smallImgs[i].setAttribute("style"," height:50px;border:3px solid #4e4e4e;margin-left:4px;filter: Alpha(Opacity=60);opacity:0.6;-moz-opacity:0.6;");
            $(smallImgs[i]).attr("style", " height:50px;border:3px solid #4e4e4e;margin-left:4px;filter: Alpha(Opacity=60);opacity:0.6;-moz-opacity:0.6;");

        }

        if (imgStart == smallImgCount) {
            imgStart = 0;
            if (smallImgs != null) {
                document.getElementById("AdBigImg").src = smallImgs[imgStart].src;
                document.getElementById("smallImgName").innerHTML = smallImgs[imgStart].title;
                //smallImgs[imgStart].setAttribute("style","filter: Alpha(Opacity=100);opacity: 1;-moz-opacity: 1;border: 3px solid #f1f1f1;");
                $(smallImgs[imgStart]).attr("style", "filter: Alpha(Opacity=100);opacity: 1;-moz-opacity: 1;border: 3px solid #f1f1f1;");
                //设置链接
                var imghref = $(smallImgs[imgStart]).parent().attr("href");
                document.getElementById("AdBigImg").parentNode.setAttribute("href", imghref);
            }

        }
        else {
            if (smallImgs != null) {
                document.getElementById("AdBigImg").src = smallImgs[imgStart].src;
                document.getElementById("smallImgName").innerHTML = smallImgs[imgStart].title;
                //smallImgs[imgStart].setAttribute("style","filter: Alpha(Opacity=100);opacity: 1;-moz-opacity: 1;border: 3px solid #f1f1f1;");
                $(smallImgs[imgStart]).attr("style", "filter: Alpha(Opacity=100);opacity: 1;-moz-opacity: 1;border: 3px solid #f1f1f1;");
                //设置链接
                var imghref = $(smallImgs[imgStart]).parent().attr("href");
                document.getElementById("AdBigImg").parentNode.setAttribute("href", imghref);
            }

        }
        imgStart++;
    }


  
</script>
<div class="hd_adver fl">
    <div class="hd_adver_img">
        <a href="javascript:void(0)">
            <img id="AdBigImg" width="294" height="457" src="Themes/Skin_Default/Images/hd1.jpg"
                runat="server" />
        </a>
    </div>
    <div class="hd_bottom">
    </div>
    <div class="hd_bottom_font" id="smallImgName">
    </div>
    <div class="hd_bottom_img" id="divSmallImg">
        <asp:Repeater ID="RepeaterSmall" runat="server">
            <ItemTemplate>
                <a href='<%#((DataRowView)Container.DataItem).Row["href"]%>'>
                    <img onclick="SmallMover(this)" alt='<%#((DataRowView)Container.DataItem).Row["title"]%>'
                        width="36" height="50" runat="server" onmouseover="SmallMover(this)" onmouseout="ImgInterv(this)"
                        src='<%#((DataRowView)Container.DataItem).Row["imgsrc"] %>' title='<%#((DataRowView)Container.DataItem).Row["title"]%>' />
                </a>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
