using System;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System.Collections.Generic;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopUserRecommend : PageBase, IRequiresSessionState
    {
        protected void BindGrid()
        {
            Num1GridviewShow.DataBind();
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {

            base.Response.Redirect("ShopUserRecommend_Operate.aspx");
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            string RecommendGuidAll = Mid.Value;
            String[] id = RecommendGuidAll.Split(new char[] { ',' });

            for (int i = 0; i < id.Length; i++)
            {
                var action = (ShopNum1_ShopUserRecommend_Action)LogicFactory.CreateShopNum1_ShopUserRecommend_Action();
                int num = action.Delete(id[i]);

                if (num == -1)
                {
                    MessageBox.Show("没有此条记录！");
                }
                else if (num > 0)
                {
                    var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员删除会员推荐商品列表",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopUserRecommend.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                    base.OperateLog(operateLog);

                    BindGrid();
                    MessageShow.ShowMessage("DelYes");
                    MessageShow.Visible = true;
                }
                else
                {
                    MessageShow.ShowMessage("DelNo");
                    MessageShow.Visible = true;
                }
            }


        }

        

        //protected void ButtonEdit_Click(object sender, EventArgs e)
        //{
        //    base.Response.Redirect("MemberRank_Operate.aspx?guid=" + CheckGuid.Value);
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                BindGrid();
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {

            var action = (ShopNum1_ShopUserRecommend_Action)LogicFactory.CreateShopNum1_ShopUserRecommend_Action();
            if (txtMemLoginID.Value == "")
            {
                Response.Write("<Script Language=JavaScript>alert('请输入会员ID！');</Script>");
            }
            else
            {
                DataTable SearchMember = action.Search(txtMemLoginID.Value);

                Num1GridviewShow.DataSourceID = null;
                Num1GridviewShow.DataSource = SearchMember;
                Num1GridviewShow.DataBind();
            }
        }

        protected void LinkAdd_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton LinkAdd = (LinkButton)sender;  //强转一下。
                string memberID = LinkAdd.CommandArgument.ToString();

                var action = (ShopNum1_ShopUserRecommend_Action)LogicFactory.CreateShopNum1_ShopUserRecommend_Action();
                DataTable table = action.SelectProdectIDBymenberId(memberID);
                Decimal TotalPrices = 0;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    int ProductID = Convert.ToInt32(table.Rows[i]["ProductID"]);
                    DataTable tablefree = action.SelectTimeByMenberId(memberID);
                    DateTime time = Convert.ToDateTime(tablefree.Rows[0]["LastSettlementDate"]);
                    DateTime newTime = Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"));
                    DataTable tabletwo = action.SelectMoneyByTime(ProductID, time, newTime);

                    for (int j = 0; j < tabletwo.Rows.Count; j++)
                    {
                        Decimal money = Convert.ToDecimal(tabletwo.Rows[j]["BuyNumber"]);
                        Int32 number = Convert.ToInt32(tabletwo.Rows[j]["BuyPrice"]);
                        TotalPrices += money * number;


                    }

                }
                if (TotalPrices == 0)
                {
                    Response.Write("<script>alert('此用户无可返现资金')</script>");
                }
                else
                {
                    Decimal FinalAmount = TotalPrices / 100 * 3;

                    Decimal MemberMoney = Convert.ToDecimal(action.SelectMoneyByMerberTable(memberID).Rows[0]["AdvancePayment"]);
                    Decimal MoneyTwo = FinalAmount + MemberMoney;
                    action.UpdateMoneyByMerberTable(memberID, MoneyTwo);
                    var shopNum1_AdvancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog();

                    //  tGuid\t, \tOperateType\t, \tCurrentAdvancePayment\t, \tOperateMoney\t, \tLastOperateMoney\t, \tDate\t, \tMemo\t, \tMemLoginID\t, \tCreateUser\t, \tCreateTime\t,    OrderNumber ,\tIsDeleted 

                    shopNum1_AdvancePaymentModifyLog.Guid = Guid.NewGuid();
                    shopNum1_AdvancePaymentModifyLog.OperateType = 1;
                    shopNum1_AdvancePaymentModifyLog.CurrentAdvancePayment = MemberMoney;
                    shopNum1_AdvancePaymentModifyLog.OperateMoney = FinalAmount;
                    shopNum1_AdvancePaymentModifyLog.LastOperateMoney = MoneyTwo;
                    shopNum1_AdvancePaymentModifyLog.Date = Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"));
                    shopNum1_AdvancePaymentModifyLog.Memo = "推荐商品返现";
                    shopNum1_AdvancePaymentModifyLog.MemLoginID = memberID;
                    shopNum1_AdvancePaymentModifyLog.CreateUser = memberID;
                    shopNum1_AdvancePaymentModifyLog.CreateTime = Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"));
                    shopNum1_AdvancePaymentModifyLog.IsDeleted = 0;

                    var shopNum1_AdvancePaymentModifyLog_Action =
                   (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
                    shopNum1_AdvancePaymentModifyLog_Action.OperateMoneytwo(shopNum1_AdvancePaymentModifyLog);
                    Response.Write("<script>alert('此用户返现资金已到帐')</script>");

                    string time = shopNum1_AdvancePaymentModifyLog.Date.ToString();
                    action.UpdateBindProductDate(memberID,time);

                }
            }
            catch (Exception )
            {
                
               
            }
            
           
            
        }

    }
}