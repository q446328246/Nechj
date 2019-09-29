using System;
using System.Collections.Generic;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Deploy.App_Code;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_ProductComment : BaseMemberControl
    {
        public static DataTable dt_order = null;


        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (hidPGuId.Value != "")
            {
                var listProductComment = new List<ShopNum1_Shop_ProductComment>();
                string str = ShopSettings.GetValue("ProductCommentISAudit");
                string[] strArray = (hidPGuId.Value + ",").Split(new[] {','});
                string[] strArray2 = (hidCtype.Value + ",").Split(new[] {','});
                string[] strArray3 = (hidCommentC.Value + ",").Split(new[] {','});
                string[] strArray4 = (hidProductName.Value + ",").Split(new[] {','});
                string[] strArray5 = (hidProductPrice.Value + ",").Split(new[] {','});
                string[] strArray6 = (hidSpecValue.Value + ",").Split(new[] {','});
                string[] strArray7 = (hidNick.Value + ",").Split(new[] {','});
                string[] strArray8 = (hidCategory.Value + ",").Split(new[] { ',' });
                string str2 = Common.Common.GetNameById("shopname", "shopnum1_shopinfo",
                    " and memloginid='" + hidShopId.Value + "'");
                string str3 = Common.Common.GetNameById("shopid", "shopnum1_shopinfo",
                    " and memloginid='" + hidShopId.Value + "'");
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (strArray[i] != "")
                    {
                        var item = new ShopNum1_Shop_ProductComment
                        {
                            Guid = Guid.NewGuid(),
                            CommentType = int.Parse(strArray2[i]),
                            Speed = int.Parse(hidListSpeed.Value),
                            Comment = strArray3[i],
                            ProductName = strArray4[i],
                            shop_category_id=Convert.ToInt32(strArray8[i])
                        };
                        if (item.Comment.Length > 500)
                        {
                            return;
                        }
                        
                        item.CommentTime = DateTime.Now;
                        item.IsDelete = 0;
                        item.ProductGuid = strArray[i];
                        item.ProductName = strArray4[i];
                        item.SpecValue = strArray6[i];
                        item.IsNick = Convert.ToInt32(strArray7[i]);
                        item.ShopID = str3;
                        item.ShopLoginId = hidShopId.Value;
                        item.ShopName = str2;
                        item.MemLoginID = base.MemLoginID;
                        item.OrderGuid = Common.Common.ReqStr("orid");
                        item.Attitude = int.Parse(hidListAttitude.Value);
                        item.Character = int.Parse(hidListCharacter.Value);
                        item.ProductPrice = decimal.Parse(strArray5[i]);
                        var action1 = (Shop_ProductComment_Action) LogicFactory.CreateShop_ProductComment_Action();
                        if (str == "0")
                        {
                            item.IsAudit = 1;
                            string s = (ShopSettings.GetValue("GoodAppraiseReputation") == string.Empty)
                                ? "0"
                                : ShopSettings.GetValue("GoodAppraiseReputation");
                            string str6 = (ShopSettings.GetValue("StandardAppraiseReputation") == string.Empty)
                                ? "0"
                                : ShopSettings.GetValue("StandardAppraiseReputation");
                            string str5 = (ShopSettings.GetValue("BadAppraiseReputation") == string.Empty)
                                ? "0"
                                : ShopSettings.GetValue("BadAppraiseReputation");
                            int score = 0;
                            var action2 =
                                (ShopNum1_ShopInfoList_Action) Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
                            var action3 = (ShopNum1_Member_Action) Factory.LogicFactory.CreateShopNum1_Member_Action();
                            int rankscore = (ShopSettings.GetValue("MyProductCommentRankSorce") == string.Empty)
                                ? 0
                                : int.Parse(ShopSettings.GetValue("MyProductCommentRankSorce"));
                            int num4 = (ShopSettings.GetValue("MyProductCommentSorce") == string.Empty)
                                ? 0
                                : int.Parse(ShopSettings.GetValue("MyProductCommentSorce"));
                            string str4 = strArray2[i];
                            if (str4 != null)
                            {
                                if (str4 != "5")
                                {
                                    if (!(str4 == "3"))
                                    {
                                        if (str4 == "1")
                                        {
                                            score = -int.Parse(str5);
                                        }
                                    }
                                    else
                                    {
                                        score = int.Parse(str6);
                                    }
                                }
                                else
                                {
                                    score = int.Parse(s);
                                }
                            }
                            action2.UpdateShopReputationByMemLoginID(hidShopId.Value, score);
                            action3.UpdateMemberScore(base.MemLoginID, rankscore, num4);
                            method_0(num4, rankscore);
                        }
                        else
                        {
                            item.IsAudit = 0;
                        }
                        listProductComment.Add(item);
                    }
                }
                Common.Common.UpdateInfo("IsBuyComment=1", "shopnum1_orderinfo",
                    " AND GUiD='" + Common.Common.ReqStr("orid") + "'");
                var action =
                    (ShopNum1_ProductComment_Action) Factory.LogicFactory.CreateShopNum1_ProductComment_Action();
                if (action.Add(listProductComment) > 0)
                {
                    OrderOperateLog("买家评价", "买家已经评价", "无");
                    MessageBox.Show("评论成功！");
                    Page.Response.Redirect("m_index.aspx?tomurl=M_FeedBack.aspx");
                }
                else
                {
                    MessageBox.Show("评论失败！");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                dt_order =
                    ((ShopNum1_OrderProduct_Action) Factory.LogicFactory.CreateShopNum1_OrderProduct_Action())
                        .SelectOrderProductByGuIdorAll(Common.Common.ReqStr("orid"), "");
                if (dt_order.Rows.Count == 0)
                {
                    dt_order = null;
                }
                string sasa = dt_order.Rows[0]["shop_category_id"].ToString();
                string sassa = dt_order.Rows[0]["shopid"].ToString();
            }
        }

        protected void method_0(int int_0, int int_1)
        {
            string str = Common.Common.GetNameById("cast(memberrank as varchar)+'-'+cast(score as varchar)",
                "shopnum1_member", " and memloginid='" + base.MemLoginID + "'");
            int num = 0;
            int num2 = 0;
            if ((str != "") && (str.IndexOf("-") != -1))
            {
                num = Convert.ToInt32(str.Split(new[] {'-'})[1]);
                num2 = Convert.ToInt32(str.Split(new[] {'-'})[0]);
            }
            if (int_0 > 0)
            {
                var scoreModeLog = new ShopNum1_ScoreModifyLog
                {
                    Guid = Guid.NewGuid(),
                    OperateType = 1,
                    CurrentScore = num,
                    OperateScore = int_0,
                    LastOperateScore = int_0 + num,
                    Date = DateTime.Now,
                    Memo = "买家评论送消费红包",
                    MemLoginID = base.MemLoginID,
                    CreateUser = base.MemLoginID,
                    CreateTime = DateTime.Now,
                    IsDeleted = 0
                };
                ((ShopNum1_ScoreModifyLog_Action) Factory.LogicFactory.CreateShopNum1_ScoreModifyLog_Action())
                    .OperateScore(
                        scoreModeLog);
            }
            if (int_1 > 0)
            {
                var rankScoreModifyLog = new ShopNum1_RankScoreModifyLog
                {
                    Guid = Guid.NewGuid(),
                    OperateType = 1,
                    CurrentScore = num2,
                    OperateScore = int_1,
                    LastOperateScore = int_1 + num2,
                    Date = DateTime.Now,
                    Memo = "买家评论送等级红包",
                    MemLoginID = base.MemLoginID,
                    CreateUser = base.MemLoginID,
                    CreateTime = DateTime.Now,
                    IsDeleted = 0
                };
                ((ShopNum1_RankScoreModifyLog_Action) Factory.LogicFactory.CreateShopNum1_RankScoreModifyLog_Action())
                    .OperateScore(rankScoreModifyLog);
            }
        }

        protected void OrderOperateLog(string memo, string CurrentStateMsg, string NextStateMsg)
        {
            if (!string.IsNullOrEmpty(Common.Common.ReqStr("orid")))
            {
                var orderOperateLog = new ShopNum1_OrderOperateLog
                {
                    Guid = Guid.NewGuid(),
                    OrderInfoGuid = new Guid(Common.Common.ReqStr("orid")),
                    OderStatus = 1,
                    ShipmentStatus = 0,
                    PaymentStatus = 0,
                    CurrentStateMsg = CurrentStateMsg,
                    NextStateMsg = NextStateMsg,
                    Memo = memo,
                    OperateDateTime = DateTime.Now,
                    IsDeleted = 0,
                    CreateUser = base.MemLoginID
                };
                ((ShopNum1_OrderOperateLog_Action) Factory.LogicFactory.CreateShopNum1_OrderOperateLog_Action()).Add(
                    orderOperateLog);
            }
        }
    }
}