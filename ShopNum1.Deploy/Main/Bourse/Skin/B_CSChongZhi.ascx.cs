using System;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System.Web;

namespace ShopNum1.Deploy.Main.Bourse.Skin
{
    public partial class B_CSChongZhi : BaseMemberControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                DataTable table = action.SelectMyDv(base.MemLoginID);
                if (table != null && table.Rows.Count > 0)
                {
                    bvMemLoginID.Text = table.Rows[0]["MemLoginID"].ToString();
                    Score_bv.Text = table.Rows[0]["AdvancePayment"].ToString();
                }
            }
        }

        protected void bv_btn_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            DataTable table = action.SelectMyDv(base.MemLoginID);
            string pppw = Common.Encryption.GetMd5SecondHash(bv_password.Value.Trim());
            if (table != null && table.Rows.Count > 0)
            {
                decimal dv = Convert.ToDecimal(table.Rows[0]["AdvancePayment"]);
                string MemLoginNO = table.Rows[0]["MemLoginNO"].ToString();
                string paypwd = table.Rows[0]["PayPwd"].ToString();
                string Name = table.Rows[0]["RealName"].ToString();
                string fuwuzhan = table.Rows[0]["IsFuwuzhan"].ToString();
                decimal TiDv = Convert.ToDecimal(bvScore_bv.Value.Trim());
                if (fuwuzhan == "1")
                {
                    if (TiDv > 0)
                    {
                        if (paypwd == pppw)
                        {
                            int dd = action.CXCSmember(base.MemLoginID);
                            if (dd != 0)
                            {
                                if (dv >= TiDv)
                                {
                                    string strRight = base.MemLoginID.Substring(base.MemLoginID.Length - 3, 3);
                                    string CS = "CS" + CreateOrderNumber() + strRight;
                                    int CsReturn = action.AddCsJiLu(Convert.ToString(dd), Name, (Convert.ToInt32(TiDv * 100)).ToString(), CS);

                                    if (CsReturn == 1)
                                    {
                                        int c = action.XiaoFeiCSBVTwo(MemLoginNO, TiDv, CS);
                                        if (c != 0)
                                        {
                                            int d = action.AddCSjifenTwo(Convert.ToString(dd), CS, GetIP());
                                            if (d == 0)
                                            {
                                                MessageBox.Show("充值成功！");
                                            }
                                            else
                                            {

                                                MessageBox.Show("充值错误，请尽快给客服人员电话联系！");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("未查到对应用户信息");
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("充值金额大于实际拥有金额，充值失败！");
                                }
                            }
                            else
                            {
                                MessageBox.Show("用户查询失败！");
                            }

                        }
                        else
                        {
                            MessageBox.Show("支付密码错误！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("充值金额错误！");
                    }
                }
                else 
                {
                    MessageBox.Show("只有服务站可以进行充值！");
                }
            }
            else
            {
                MessageBox.Show("用户信息错误！");
            }
        }

        /// <summary>  
        /// 获取客户端IP地址  
        /// </summary>  
        /// <returns></returns>  
        public static string GetIP()
        {
            string result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(result))
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            if (string.IsNullOrEmpty(result))
            {
                result = HttpContext.Current.Request.UserHostAddress;
            }
            if (string.IsNullOrEmpty(result))
            {
                return "0.0.0.0";
            }
            return result;
        }


        public string CreateOrderNumber()
        {
            string str = DateTime.Today.Year.ToString();
            string str2 = DateTime.Today.Month.ToString();
            if (str2.Length == 1)
            {
                str2 = "0" + str2;
            }
            string str3 = DateTime.Today.Day.ToString();
            if (str3.Length == 1)
            {
                str3 = "0" + str3;
            }
            string str4 = DateTime.Now.Minute.ToString();
            if (str4.Length == 1)
            {
                str4 = "0" + str4;
            }
            string str5 = DateTime.Now.Second.ToString();
            if (str5.Length == 1)
            {
                str5 = "0" + str5;
            }
            string str6 = DateTime.Now.Millisecond.ToString();
            if (str6.Length == 1)
            {
                str6 = "00" + str6;
            }
            else if (str6.Length == 2)
            {
                str6 = "0" + str6;
            }
            return (str + str2 + str3 + str4 + str5 + str6);
        }
    }
}