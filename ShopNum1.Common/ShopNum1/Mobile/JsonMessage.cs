using System;
using System.Collections.Generic;
using System.Text;

namespace ShopNum1.Common.ShopNum1.Mobile
{
    [System.Serializable()]
    public class JsonMessage
    {
        private object data;
        public object Data
        {
            get { return data; }
            set { data = value; }
        }
        /// <summary>
        /// 0-操作失败，1-操作成功
        /// </summary>
        private int result = 1;

        public int Result
        {
            get { return result; }
            set { result = value; }
        }
        /// <summary>
        /// 0-无错误消息，1-用户已经被禁用,2-用户密码错误过次数多已经被禁用,3-密码或者账户可能有误,4-token里的值错误（有效时间已过期,需要重新登录！），5-token里的值错误（账户密码不匹配,需要重新登录！）,6-请求地址有误
        /// </summary>
        private int error_code;
        public int Error_code
        {
            get { return error_code; }
            set { error_code = value; }
        }
    }
}
