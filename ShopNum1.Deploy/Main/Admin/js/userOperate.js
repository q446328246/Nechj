
//正则检查   
var emailCheck = /^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/;
var pwdCheck = /^[\s\S]{4,30}$/;
var numCheck = /^[0-9]{1,}$/;
///find pwd 检查

function checkFindPwdSubmit() {
    var str = "";
    var emailCheck = /^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/;
    var pwdCheck = /^[\s\S]{4,30}$/;
    var email = document.getElementById("textEmail").value;
    var tempPwd = document.getElementById("textPwdTemp").value;
    if (email == "") {
        str = "メールアドレスを入力してください <br/>";
    }
    if (tempPwd == "") {
        str += "仮パスワードを入力してください <br/>";
    }
    if (str != "") {
        document.getElementById("errDiv").style.display = "block";
        document.getElementById("errDiv").innerHTML = str;
        return false;
    }
    /// 检查邮箱格式
    if (!emailCheck.exec(email)) {
        str += "メールアドレスを正しく入力してください <br/>";
    }
    //检查密码格式
    if (!pwdCheck.exec(tempPwd)) {
        str += "仮パスワードは4桁以上30桁以内で入力してください <br/>";
    }
    if (str != "") {
        document.getElementById("errDiv").style.display = "block";
        document.getElementById("errDiv").innerHTML = str;
        return false;
    }
    document.getElementById("errDiv").style.display = "none";
    //接收表单的URL地址
    var url = "/Api/userCheck.aspx"; //需要POST的值，把每个变量都通过&来联接
    var postStr = "otype=checkemail" + "&email=" + email;

    //实例化Ajax
    var ajax = null;
    try {
        ajax = new XMLHttpRequest();
    } catch (trymicrosoft) {
        try {
            ajax = new ActiveXObject("Msxml2.XMLHTTP");
        } catch (othermicrosoft) {
            try {
                ajax = new ActiveXObject("Microsoft.XMLHTTP");
            } catch (failed) {
                ajax = false;
            }
        }
    }
    if (!ajax)
        alert("Error initializing XMLHttpRequest!");

    //通过Get方式打开连接
    ajax.open("POST", url, true);
    //定义传输的文件HTTP头信息
    ajax.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    //发送POST数据
    ajax.send(postStr);

    //返回数据的处理函数
    ajax.onreadystatechange = function () {
        if (ajax.readyState == 4 && ajax.status == 200) {
            if (ajax.responseText != "success") {
                document.getElementById("errDiv").style.display = "block";
                if (ajax.responseText == "notfind") {
                    document.getElementById("errDiv").innerHTML = "メールアドレスが存在しません。";
                }
            } else {
                __doPostBack('ButtonFindPwdSubmit', '');
            }
        }
    };
}

//提交检查
function CheckSubmit() {
    var str = "";
    var memlogid = document.getElementById("textMemLoginID").value;
    var pwd = document.getElementById("textPwd").value;
    if (memlogid == "") {
        str += "Ｅメールアドレスを入力してください <br />";
    }
    if (pwd == "") {
        str += "パスワードを入力してください <br />";

    }
    if (str != "") {
        document.getElementById("errDiv").style.display = "block";
        document.getElementById("errDiv").innerHTML = str;
        return false;
    }
    /// 检查邮箱格式
    if (!emailCheck.exec(memlogid)) {
        str += "メールアドレスを正しく入力してください <br/>";
    }
    //检查密码格式
    if (!pwdCheck.exec(pwd)) {
        str += "仮パスワードは4桁以上30桁以内で入力してください <br/>";
    }
    if (str != "") {
        document.getElementById("errDiv").style.display = "block";
        document.getElementById("errDiv").innerHTML = str;
        return false;
    }
    document.getElementById("errDiv").style.display = "none";
    //接收表单的URL地址
    var url = "/Api/userCheck.aspx"; //需要POST的值，把每个变量都通过&来联接
    var postStr = "otype=checklogin" + "&memlogid=" + memlogid + "&pwd=" + pwd;

    //实例化Ajax
    var ajax = null;
    try {
        ajax = new XMLHttpRequest();
    } catch (trymicrosoft) {
        try {
            ajax = new ActiveXObject("Msxml2.XMLHTTP");
        } catch (othermicrosoft) {
            try {
                ajax = new ActiveXObject("Microsoft.XMLHTTP");
            } catch (failed) {
                ajax = false;
            }
        }
    }
    if (!ajax)
        alert("Error initializing XMLHttpRequest!");

    var aresult = false;
    //通过Get方式打开连接
    ajax.open("POST", url, true);
    //定义传输的文件HTTP头信息
    ajax.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    //返回数据的处理函数
    ajax.onreadystatechange = function () {
        if (ajax.readyState == 4) {
            if (ajax.status == 200) {
                if (ajax.responseText == "notfind") {
                    aresult = false;
                    document.getElementById("errDiv").style.display = "block";
                    document.getElementById("errDiv").innerHTML = "ログインできません。入力内容を確認してください。";
                } else if (ajax.responseText == "success") {
                    __doPostBack('btnConfirm', '');
                } else {
                    aresult = false;
                }

            }
        }
    };
    //发送POST数据
    ajax.send(postStr);

}