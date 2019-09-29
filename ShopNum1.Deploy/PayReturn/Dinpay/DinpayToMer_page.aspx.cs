using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace ShopNum1.Deploy.PayReturn.Dinpay
{
    public partial class DinpayToMer_page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //StreamWriter stream = new StreamWriter(@"d:\1.txt", true);
            try
            {
                //获取智付反馈信息
                //商户号
                string merchant_code = Request.Form["merchant_code"].ToString().Trim();
               
                //通知类型
                string notify_type = Request.Form["notify_type"].ToString().Trim();
                
                //通知校验ID
                string notify_id = Request.Form["notify_id"].ToString().Trim();
               
                string interface_version = Request.Form["interface_version"].ToString().Trim();
               
                //签名方式
                string sign_type = Request.Form["sign_type"].ToString().Trim();
                
                //签名
                string dinpaySign = Request.Form["sign"].ToString().Trim();
                
                //商家订单号
                string order_no = Request.Form["order_no"].ToString().Trim();
                
                //商家订单时间
                string order_time = Request.Form["order_time"].ToString().Trim();
                
                //商家订单金额
                string order_amount = Request.Form["order_amount"].ToString().Trim();
                
                //回传参数
                string extra_return_param = Request.Form["extra_return_param"];
                
                
                //智付交易定单号
                string trade_no = Request.Form["trade_no"].ToString().Trim();
                
                //智付交易时间
                string trade_time = Request.Form["trade_time"].ToString().Trim();
               
                //交易状态 SUCCESS 成功  FAILED 失败
                string trade_status = Request.Form["trade_status"].ToString().Trim();
                
                string bank_seq_no = Request.Form["bank_seq_no"];
                
                /**
                 *签名顺序按照参数名a到z的顺序排序，若遇到相同首字母，则看第二个字母，以此类推，
                *同时将商家支付密钥key放在最后参与签名，组成规则如下：
                *参数名1=参数值1&参数名2=参数值2&……&参数名n=参数值n&key=key值
                **/


                //组织订单信息
                string signStr = "";

                if (null != bank_seq_no && bank_seq_no != "")
                {
                    signStr = signStr + "bank_seq_no=" + bank_seq_no.ToString().Trim() + "&";
                }

                if (null != extra_return_param && extra_return_param != "")
                {
                    signStr = signStr + "extra_return_param=" + extra_return_param + "&";
                }
                signStr = signStr + "interface_version=V3.0" + "&";
                signStr = signStr + "merchant_code=" + merchant_code + "&";


                if (null != notify_id && notify_id != "")
                {
                    signStr = signStr + "notify_id=" + notify_id + "&notify_type=" + notify_type + "&";
                }

                signStr = signStr + "order_amount=" + order_amount + "&";
                signStr = signStr + "order_no=" + order_no + "&";
                signStr = signStr + "order_time=" + order_time + "&";
                signStr = signStr + "trade_no=" + trade_no + "&";
                signStr = signStr + "trade_status=" + trade_status + "&";

                if (null != trade_time && trade_time != "")
                {
                    signStr = signStr + "trade_time=" + trade_time + "&";
                }

                string key = "Q1anha1tangj1ang_Terr0qq";

                signStr = signStr + "key=" + key;
                string signInfo = signStr;

                //将组装好的信息MD5签名
                string sign = FormsAuthentication.HashPasswordForStoringInConfigFile(signInfo, "md5").ToLower(); //注意与支付签名不同  此处对String进行加密
                
                //比较智付返回的签名串与商家这边组装的签名串是否一致
                if (dinpaySign == sign)
                {
                    //验签成功，数据没有被篡改过
                    /*
                    此处提示消费者此订单支付成功
                    业务结束	注：建议页面同步通知一般只做订单支付成功提示，而不做订单支付状态更新，更新订单支付状态在notify_url指定的地址处理，请做好订单是否重复修改状态的判断，以免虚拟充值重复到账！！
                    */
                    if (trade_status == "SUCCESS")
                    {

                        this.lbtrade_no.Text = trade_no;

                        this.lborder_no.Text = order_no;

                        this.lborder_amount.Text = order_amount;

                        this.lbtrade_status.Text = "交易成功";

                        this.lbbank_seq_no.Text = bank_seq_no;
                    }
                    else 
                    {
                        this.lbtrade_no.Text = trade_no;

                        this.lborder_no.Text = order_no;

                        this.lborder_amount.Text = order_amount;

                        this.lbtrade_status.Text = "交易失败";

                        this.lbbank_seq_no.Text = bank_seq_no;
                    }
                    this.lbVerify.Text = "验证成功";
                    
                }
                else
                { 
                    //验签失败 业务结束
                    this.lbVerify.Text = "验证失败";
                }

            }
            finally
            {

                
            }
        }
       
    }
}