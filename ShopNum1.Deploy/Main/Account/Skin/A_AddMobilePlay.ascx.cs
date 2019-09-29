using System;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System.Web;


namespace ShopNum1.Deploy.Main.Account.Skin
{
    public partial class A_AddMobilePlay : BaseMemberControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
              DataTable table = action.SelectMyDv(base.MemLoginID);
              if (table!=null && table.Rows.Count>0)
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
          string pppw=  Common.Encryption.GetMd5SecondHash(bv_password.Value.Trim());
             if (table!=null && table.Rows.Count>0)
              {
           decimal dv = Convert.ToDecimal(table.Rows[0]["AdvancePayment"]);
          string MemLoginNO = table.Rows[0]["MemLoginNO"].ToString();
          string paypwd = table.Rows[0]["PayPwd"].ToString();
          decimal TiDv = Convert.ToDecimal(bvScore_bv.Value.Trim());
          if (paypwd == pppw)
          {
              int dd = action.NET_PM_SelectPersonCount(base.MemLoginID);
              if (dd==1)
              {
                  if (dv >= TiDv)
                  {
                      int c = action.XiaoFeiDV(MemLoginNO, TiDv);
                      if (c != 0)
                      {
                          int d = action.AddDVGetXianShiYou("tj88", GetIP(), base.MemLoginID, (TiDv*100).ToString(), "自主提现积分");
                          if (d == 0)
                          {
                              MessageBox.Show("提现成功！");
                          }
                          else
                          {

                              MessageBox.Show("提现错误，请尽快给客服人员电话联系！");
                          }
                      }
                  }
                  else
                  {
                      MessageBox.Show("提现金额大于实际拥有金额，提现失败！");
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

        

    }
}