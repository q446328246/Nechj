using System;
using System.Data;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopZtcApplyAudit_List : PageBase, IRequiresSessionState
    {
        protected void BindGrid()
        {
            Num1GridViewShow.DataBind();
        }

        protected void ButtonAudit_Click(object sender, EventArgs e)
        {
            try
            {
                string[] strArray = CheckGuid.Value.Split(new[] {','});
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (IsCheck(strArray[i]))
                    {
                        CreateZtcGoods(strArray[i]);
                        BindGrid();
                    }
                }
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "审核通过",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopZtcApplyAudit_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                MessageBox.Show("数据审核成功！");
                BindGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("数据审核失败！");
            }
        }

        protected void ButtonCancelAudit_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_ZtcApply_Action) LogicFactory.CreateShopNum1_ZtcApply_Action();
            try
            {
                string[] strArray = CheckGuid.Value.Split(new[] {','});
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (IsCheck(strArray[i]))
                    {
                        action.ChangeAuditState(strArray[i], 2);
                        DataTable infoByGuid = action.GetInfoByGuid(strArray[i].Replace("'", ""));
                        decimal num3 = Convert.ToDecimal(infoByGuid.Rows[0]["Ztc_Money"].ToString());
                        string str2 = infoByGuid.Rows[0]["MemberID"].ToString();
                        decimal num2 = 0M;
                        string str = Common.Common.GetNameById("AdvancePayment", "ShopNum1_Member",
                                                               "  AND  MemLoginID='" + str2 + "'");
                        if (!string.IsNullOrEmpty(str))
                        {
                            num2 = Convert.ToDecimal(str);
                        }
                        var advancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog
                            {
                                Guid = Guid.NewGuid(),
                                OperateType = 5,
                                CurrentAdvancePayment = num2,
                                OperateMoney = num3,
                                LastOperateMoney = Convert.ToDecimal(num2) + num3,
                                Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                Memo = "直通车审核未通过,退款￥" + num3 + "！",
                                MemLoginID = str2,
                                CreateUser = base.ShopNum1LoginID,
                                CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                IsDeleted = 0
                            };
                        ((ShopNum1_AdvancePaymentModifyLog_Action)
                         LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action()).OperateMoney(
                             advancePaymentModifyLog);
                    }
                }
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "审核未通过",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopZtcApplyAudit_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                MessageBox.Show("操作成功！");
                BindGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("数据审核失败！");
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_ZtcApply_Action) LogicFactory.CreateShopNum1_ZtcApply_Action();
            try
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "删除直通车信息",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopZtcApplyAudit_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                action.Delete(CheckGuid.Value);
                BindGrid();
            }
            catch (Exception)
            {
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void ButtonSearchDetail_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ShopProductComment_Detail.aspx?Guid=" + CheckGuid.Value + "&Type=Audit");
        }

        public void CreateZtcGoods(string guid)
        {
            var action = (ShopNum1_ZtcGoods_Action) LogicFactory.CreateShopNum1_ZtcGoods_Action();
            var ztcGoods = new ShopNum1_ZtcGoods();
            var action2 = (ShopNum1_ZtcApply_Action) LogicFactory.CreateShopNum1_ZtcApply_Action();
            DataTable infoByGuid = action2.GetInfoByGuid(guid);
            string g = string.Empty;
            decimal num = 0M;
            string str2 = "";
            string str3 = "";
            decimal num2 = 0M;
            string str4 = "";
            DateTime time2 = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            decimal num3 = 0M;
            string str5 = string.Empty;
            if ((infoByGuid != null) && (infoByGuid.Rows.Count > 0))
            {
                g = infoByGuid.Rows[0]["ProductGuid"].ToString();
                DataTable table2 =
                    ((Shop_Product_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Product_Action()).SearchProductShopByGuid("'" +
                                                                                                             infoByGuid
                                                                                                                 .Rows[0
                                                                                                                 ][
                                                                                                                     "ProductGuid"
                                                                                                                 ] + "'");
                if ((table2 != null) && (table2.Rows.Count > 0))
                {
                    num = Convert.ToDecimal(table2.Rows[0]["ShopPrice"].ToString());
                    str2 = table2.Rows[0]["OriginalImage"].ToString();
                    str3 = table2.Rows[0]["Name"].ToString();
                }
                num2 = num;
                str4 = infoByGuid.Rows[0]["ShopName"].ToString();
                time2 = Convert.ToDateTime(infoByGuid.Rows[0]["StartTime"].ToString());
                num3 = Convert.ToDecimal(infoByGuid.Rows[0]["Ztc_Money"].ToString());
                str5 = infoByGuid.Rows[0]["MemberID"].ToString();
            }
            int num4 = 0;
            try
            {
                num4 = action2.ChangeAuditState(guid, 1);
            }
            catch (Exception)
            {
            }
            ztcGoods.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            ztcGoods.CreateUser = base.ShopNum1LoginID;
            ztcGoods.IsDeleted = 0;
            ztcGoods.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            ztcGoods.ModifyUser = base.ShopNum1LoginID;
            ztcGoods.ProductGuid = new Guid(g);
            ztcGoods.ProductPrice = num;
            ztcGoods.SellCount = 0;
            ztcGoods.SellPrice = num2;
            ztcGoods.ShopName = str4;
            if (DateTime.Compare(DateTime.Now, time2) == -1)
            {
                ztcGoods.StartTime = time2;
            }
            else
            {
                ztcGoods.StartTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            ztcGoods.State = 1;
            ztcGoods.Ztc_Money = num3;
            ztcGoods.ZtcImg = str2;
            ztcGoods.ZtcName = str3;
            ztcGoods.MemberID = str5;
            if (num4 > 0)
            {
                action.Add(ztcGoods);
            }
        }

        public string Is(object object_0)
        {
            if (object_0.ToString() == "1")
            {
                return "审核通过";
            }
            if (object_0.ToString() == "0")
            {
                return "未审核";
            }
            if (object_0.ToString() == "2")
            {
                return "审核未通过";
            }
            return "";
        }

        public bool IsCheck(string guid)
        {
            DataTable infoByGuid =
                ((ShopNum1_ZtcApply_Action) LogicFactory.CreateShopNum1_ZtcApply_Action()).GetInfoByGuid(guid);
            if ((infoByGuid != null) && (infoByGuid.Rows.Count > 0))
            {
                if ((infoByGuid.Rows[0]["AuditState"].ToString() == "1") ||
                    (infoByGuid.Rows[0]["AuditState"].ToString() == "2"))
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        private void BindData()
        {
            var item = new ListItem
                {
                    Text = "-全部-",
                    Value = "-1"
                };
            DropDownListIsAudit.Items.Add(item);
            var item2 = new ListItem
                {
                    Text = "未审核",
                    Value = "0"
                };
            DropDownListIsAudit.Items.Add(item2);
            var item3 = new ListItem
                {
                    Text = "审核通过",
                    Value = "1"
                };
            DropDownListIsAudit.Items.Add(item3);
            var item4 = new ListItem
                {
                    Text = "审核未通过",
                    Value = "2"
                };
            DropDownListIsAudit.Items.Add(item4);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                BindData();
                BindGrid();
            }
        }

        public string Time(string time)
        {
            if (Convert.ToDateTime(time) == Convert.ToDateTime("1900-1-1"))
            {
                return "未审核";
            }
            return time;
        }
    }
}