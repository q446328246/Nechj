using System.Collections;

namespace ShopNum1.DiscuzToolkit
{
    public class ErrorDetails : Hashtable
    {
        public ErrorDetails()
        {
            Add(1, "未知错误,请重新提交");
            Add(2, "服务目前不可使用");
            Add(3, "未知方法");
            Add(4, "整合程序已达到允许的最大同时请求数");
            Add(5, "请求来自一个未被当前整合程序允许的远程地址");
            Add(100, "指定的参数不存在或不是有效参数");
            Add(0x65, "所提交的api_key未关联到任何设定程序");
            Add(0x66, "session_key已过期或失效,请重定向让用户重新登录并获得新的session_key");
            Add(0x67, "当前会话所提交的call_id没有大于前一次的call_id");
            Add(0x68, "签名(sig)参数不正确");
        }
    }
}