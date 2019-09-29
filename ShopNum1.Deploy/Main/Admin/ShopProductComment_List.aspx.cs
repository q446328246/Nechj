using System;
using System.Data;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System.Web;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopProductComment_List : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                BindData();
                BindGrid();
            }
        }

        protected void BindGrid()
        {
            Num1GridViewShow.DataBind();
        }

        protected void ButtonAudit_Click(object sender, EventArgs e)
        {
            try
            {
                var action = (ShopNum1_ProductComment_Action)LogicFactory.CreateShopNum1_ProductComment_Action();
                var action2 = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
                DataTable commentTypeByGuid = action.GetCommentTypeByGuid(CheckGuid.Value);
                string s = (ShopSettings.GetValue("GoodAppraiseReputation") == string.Empty)
                               ? "0"
                               : ShopSettings.GetValue("GoodAppraiseReputation");
                string str = (ShopSettings.GetValue("StandardAppraiseReputation") == string.Empty)
                                 ? "0"
                                 : ShopSettings.GetValue("StandardAppraiseReputation");
                string str2 = (ShopSettings.GetValue("BadAppraiseReputation") == string.Empty)
                                  ? "0"
                                  : ShopSettings.GetValue("BadAppraiseReputation");
                int score = 0;
                var action3 = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                int rankscore = (ShopSettings.GetValue("MyMessageRankSorce") == string.Empty)
                                    ? 0
                                    : int.Parse(ShopSettings.GetValue("MyMessageRankSorce"));
                int num4 = (ShopSettings.GetValue("MyMessageSorce") == string.Empty)
                               ? 0
                               : int.Parse(ShopSettings.GetValue("MyMessageSorce"));
                for (int i = 0; i < commentTypeByGuid.Rows.Count; i++)
                {
                    if (commentTypeByGuid.Rows[i]["IsAudit"].ToString() != "1")
                    {
                        if (commentTypeByGuid.Rows[i]["CommentType"].ToString() == "0")
                        {
                            score = int.Parse(s);
                        }
                        else if (commentTypeByGuid.Rows[i]["CommentType"].ToString() == "1")
                        {
                            score = int.Parse(str);
                        }
                        else if (commentTypeByGuid.Rows[i]["CommentType"].ToString() == "2")
                        {
                            score = int.Parse(str2);
                        }
                        action2.UpdateShopReputationByMemLoginID(commentTypeByGuid.Rows[i]["ShopID"].ToString(), score);
                        action3.UpdateMemberScore(commentTypeByGuid.Rows[i]["MemLoginID"].ToString(), rankscore, num4);
                    }
                }
                if (action.UpdateProductAudit(CheckGuid.Value, "1") > 0)
                {
                    BindGrid();
                    MessageShow.ShowMessage("Audit1Yes");
                    MessageShow.Visible = true;
                }
                else
                {
                    MessageShow.ShowMessage("Audit1No");
                    MessageShow.Visible = true;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        protected void ButtonCancelAudit_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_ProductComment_Action)LogicFactory.CreateShopNum1_ProductComment_Action();
            if (action.UpdateProductAudit(CheckGuid.Value, "0") > 0)
            {
                BindGrid();
                MessageShow.ShowMessage("Audit2Yes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("Audit2No");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_ProductComment_Action)LogicFactory.CreateShopNum1_ProductComment_Action();
            if (action.DeleteProduct(CheckGuid.Value) > 0)
            {
                  HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                    
                var operateLog = new ShopNum1_OperateLog
                {
                    Record = "管理员删除商品评论",
                    OperatorID = cookie2.Values["LoginID"].ToString(),
                    IP = Globals.IPAddress,
                    PageName = "ShopProductComment_List.aspx",
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

        protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
        {
            var button = (LinkButton)sender;
            string guids = "'" + button.CommandArgument + "'";
            var action = (ShopNum1_ProductComment_Action)LogicFactory.CreateShopNum1_ProductComment_Action();
            if (action.DeleteProduct(guids) > 0)
            {
                  HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                   
                var operateLog = new ShopNum1_OperateLog
                {
                    Record = "管理员删除商品评论",
                    OperatorID = cookie2.Values["LoginID"].ToString(),
                    IP = Globals.IPAddress,
                    PageName = "ShopProductComment_List.aspx",
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

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void ButtonSearchDetail_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ShopProductComment_Detail.aspx?Guid=" + CheckGuid.Value + "&Type=List");
        }

        public string Is(object object_0)
        {
            if (object_0.ToString() == "1")
            {
                return "已审核";
            }
            if (object_0.ToString() == "0")
            {
                return "未审核";
            }
            if (object_0.ToString() == "2")
            {
                return "审核未通过";
            }
            return "非法状态";
        }

        private void BindData()
        {
            var item = new ListItem
            {
                Text = "已审核",
                Value = "1"
            };
            DropDownListIsAudit.Items.Add(item);
        }


    }
}