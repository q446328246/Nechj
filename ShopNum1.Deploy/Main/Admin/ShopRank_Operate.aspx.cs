using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopRank_Operate : PageBase, IRequiresSessionState
    {
        protected void BindGrid()
        {
            DataTable table =
                ((ShopNum1_ShopTemplate_Action) LogicFactory.CreateShopNum1_ShopTemplate_Action()).Search();
            RepeatershopTemplate.DataSource = table;
            RepeatershopTemplate.DataBind();
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            ShopNum1_OperateLog log;
            if (HiddenFieldGuid.Value == "0")
            {
                log = new ShopNum1_OperateLog
                    {
                        Record = "管理员添加店铺等级",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopRank_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(log);
                method_7();
            }
            else
            {
                log = new ShopNum1_OperateLog
                    {
                        Record = "管理员修改店铺等级",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopRank_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(log);
                method_6();
            }
        }

        private void BindData()
        {
            DataTable table =
                ((Shop_Rank_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Rank_Action()).Search(HiddenFieldGuid.Value, 0);
            TextBoxName.Text = table.Rows[0]["name"].ToString();
            TextBoxMaxProduct.Text = table.Rows[0]["MaxProductCount"].ToString();
            TextBoxStartTime.Text = table.Rows[0]["StartTime"].ToString();
            HiddenFieldPic.Value = table.Rows[0]["Pic"].ToString();
            image.Src = table.Rows[0]["Pic"].ToString();
            TextBoxPrice.Text = table.Rows[0]["price"].ToString();
            CheckGuid.Value = table.Rows[0]["shopTemplate"].ToString();
            DropDownListIsSetSEO.SelectedValue = table.Rows[0]["IsSetSEO"].ToString();
            TextBoxMaxArticleCout.Text = table.Rows[0]["MaxArticleCout"].ToString();
            TextBoxMaxVedioCount.Text = table.Rows[0]["MaxVedioCount"].ToString();
            TextBoxRankValue.Text = table.Rows[0]["RankValue"].ToString();
            HiddenFieldIsDefault.Value = table.Rows[0]["IsDefault"].ToString();
            foreach (RepeaterItem item in RepeatershopTemplate.Items)
            {
                var box = (HtmlInputCheckBox) item.FindControl("checkboxItem");
                string[] strArray = CheckGuid.Value.Split(new[] {','});
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (box.Value == strArray[i])
                    {
                        box.Checked = true;
                    }
                }
            }
        }

        private void method_6()
        {
            var shopRank = new ShopNum1_ShopRank
                {
                    Name = TextBoxName.Text,
                    MaxProductCount = int.Parse(TextBoxMaxProduct.Text.Trim()),
                    MaxFileCount = 0x1869f,
                    StartTime = Convert.ToDateTime("1900-1-1"),
                    validityDate = "",
                    price = Convert.ToDecimal(TextBoxPrice.Text.Trim())
                };
            string str = HiddenFieldPic.Value;
            shopRank.Pic = str;
            shopRank.IsSetSEO = int.Parse(DropDownListIsSetSEO.SelectedValue);
            shopRank.shopTemplate = CheckGuid.Value.Replace("'", "");
            shopRank.IsOverrideDomain = 1;
            shopRank.MaxPanicBuyCount = 0x1869f;
            shopRank.MaxSpellBuyCount = 0x1869f;
            shopRank.MaxArticleCout = int.Parse(TextBoxMaxArticleCout.Text.Trim());
            shopRank.MaxVedioCount = int.Parse(TextBoxMaxVedioCount.Text.Trim());
            if (HiddenFieldIsDefault.Value == "0")
            {
                shopRank.IsDefault = 0;
            }
            else
            {
                shopRank.IsDefault = 1;
            }
            shopRank.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            shopRank.ModifyUser = "admin";
            shopRank.RankValue = Convert.ToInt32(TextBoxRankValue.Text.Trim());
            shopRank.Guid = new Guid(HiddenFieldGuid.Value.Replace("'", ""));
            var action = (Shop_Rank_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Rank_Action();
            if (action.Update(shopRank) == 1)
            {
                base.Response.Redirect("ShopRank_List.aspx");
            }
            else
            {
                MessageShow.ShowMessage("EditNo");
                MessageShow.Visible = true;
            }
        }

        private void method_7()
        {
            var shopRank = new ShopNum1_ShopRank
                {
                    Name = TextBoxName.Text,
                    MaxProductCount = int.Parse(TextBoxMaxProduct.Text.Trim()),
                    MaxFileCount = 0x3e7,
                    StartTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    validityDate = "",
                    price = Convert.ToDecimal(TextBoxPrice.Text.Trim())
                };
            string path = HiddenFieldPic.Value;
            if ((path != "") && (path.IndexOf("20x20") == -1))
            {
                string str2 = "/ImgUpload/Main/Rank/";
                if (!Directory.Exists(HttpContext.Current.Server.MapPath(str2)))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(str2));
                }
                str2 = str2 + DateTime.Now.ToString("yyyyMMddhhmmss") + ".jpg_20x20.jpg";
                try
                {
                    ImageOperator.CreateThumbnailAuto(HttpContext.Current.Server.MapPath(path),
                                                      HttpContext.Current.Server.MapPath(str2), 20, 20);
                }
                catch
                {
                }
                path = str2;
            }
            shopRank.Pic = path;
            shopRank.IsSetSEO = int.Parse(DropDownListIsSetSEO.SelectedValue);
            shopRank.shopTemplate = CheckGuid.Value.Replace("'", "");
            shopRank.IsOverrideDomain = 1;
            shopRank.MaxPanicBuyCount = 0x1869f;
            shopRank.MaxSpellBuyCount = 0x1869f;
            shopRank.MaxArticleCout = int.Parse(TextBoxMaxArticleCout.Text.Trim());
            shopRank.MaxVedioCount = int.Parse(TextBoxMaxVedioCount.Text.Trim());
            shopRank.IsDefault = 1;
            shopRank.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            shopRank.CreateUser = "admin";
            shopRank.Guid = Guid.NewGuid();
            shopRank.RankValue = Convert.ToInt32(TextBoxRankValue.Text.Trim());
            var action = (Shop_Rank_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Rank_Action();
            if (action.Add(shopRank) > 0)
            {
                method_8();
                MessageShow.ShowMessage("AddYes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("AddNo");
                MessageShow.Visible = true;
            }
        }

        private void method_8()
        {
            TextBoxName.Text = string.Empty;
            TextBoxMaxProduct.Text = string.Empty;
            TextBoxStartTime.Text = string.Empty;
            HiddenFieldPic.Value = string.Empty;
            TextBoxPrice.Text = string.Empty;
            TextBoxMaxArticleCout.Text = string.Empty;
            TextBoxMaxVedioCount.Text = string.Empty;
            DropDownListIsSetSEO.SelectedValue = "-1";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                BindGrid();
                HiddenFieldGuid.Value = (Page.Request.QueryString["guid"] == null)
                                            ? "0"
                                            : ("'" + base.Request.QueryString["guid"] + "'");
                if (HiddenFieldGuid.Value != "0")
                {
                    LabelPageTitle.Text = "修改店铺等级";
                    BindData();
                    ButtonConfirm.Text = "更新";
                }
            }
        }
    }
}