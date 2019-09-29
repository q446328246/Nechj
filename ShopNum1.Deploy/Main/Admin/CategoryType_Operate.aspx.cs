using System;
using System.Collections.Generic;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System.Web;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class CategoryType_Operate : PageBase, IRequiresSessionState
    {
        private readonly ShopNum1_CategoryType shopNum1_CategoryType_0 = new ShopNum1_CategoryType();

        private readonly ShopNum1_CategoryType_Action shopNum1_CategoryType_Action_0 =
            new ShopNum1_CategoryType_Action();

        public DataTable dt_Brand = null;
        public DataTable dt_Prop = null;
        public DataTable dt_Spec = null;

        private string string_4;

        protected void butSub_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_Brand_Action)LogicFactory.CreateShopNum1_Brand_Action();
            new ShopNum1_TypeBrand();
            if (hidBrand.Value != "")
            {
                var list = new List<ShopNum1_TypeBrand>();
                int num = 0;
                if (string.IsNullOrEmpty(string_4))
                {
                    num = shopNum1_CategoryType_Action_0.Get_TypeMaxId();
                }
                else
                {
                    num = Convert.ToInt32(string_4);
                }
                action.Delete_TypeBrand(num.ToString());
                string[] strArray = hidBrand.Value.Split(new[] { ',' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (strArray[i] != "")
                    {
                        var item = new ShopNum1_TypeBrand
                            {
                                BrandGuid = new Guid(strArray[i]),
                                TypeID = num
                            };
                        list.Add(item);
                    }
                }
                action.Add_TypeBrand(list);
            }
            shopNum1_CategoryType_0.Name = Operator.FilterString(txtTypeName.Value);
            shopNum1_CategoryType_0.OrderID = 1;
            shopNum1_CategoryType_0.CreateUser = base.ShopNum1LoginID;
            shopNum1_CategoryType_0.ModifyUser = base.ShopNum1LoginID;
            shopNum1_CategoryType_0.Description = Operator.FilterString(txtDesc.Value);
            if (IsShow.Checked)
            {
                shopNum1_CategoryType_0.IsShow = 1;
            }
            else
            {
                shopNum1_CategoryType_0.IsShow = 0;
            }
            shopNum1_CategoryType_0.Spec_Ids = hidSpec.Value;
            shopNum1_CategoryType_0.Pro_Ids = hidProp.Value;
            int num2 = 0;
            if (string.IsNullOrEmpty(string_4))
            {
                num2 = shopNum1_CategoryType_Action_0.Add_CategoryType(shopNum1_CategoryType_0);
            }
            else
            {
                shopNum1_CategoryType_0.ID = Convert.ToInt32(string_4);
                num2 = shopNum1_CategoryType_Action_0.Update_CategoryType(shopNum1_CategoryType_0);
            }
            if (num2 > 0)
            {
                HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);

                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "新增或修改商品类型",
                        OperatorID = cookie2.Values["LoginID"].ToString(),
                        IP = Globals.IPAddress,
                        PageName = "CategoryType_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                base.Response.Redirect("CategoryType.aspx");
            }
            else
            {
                spanHtml.InnerHtml = "操作失败！";
            }
        }

        public string IsCheck(string strvId, int Type)
        {
            if (!string.IsNullOrEmpty(string_4))
            {
                string str = null;
                if (Type == 1)
                {
                    str = hidSpec.Value;
                }
                else
                {
                    str = hidProp.Value;
                }
                if (str.IndexOf(strvId) != -1)
                {
                    return "checked='checked'";
                }
                return "";
            }
            return "";
        }

        private string method_5()
        {
            return Common.Common.GetNameById("max(OrderID)+1", "ShopNum1_CategoryType", " and isdeleted=0");
        }

        private void method_6()
        {
            ShopNum1_CategoryType type = shopNum1_CategoryType_Action_0.Select_CategoryType(string_4);
            txtTypeName.Value = type.Name;
            txtDesc.Value = type.Description;
            txtSortId.Value = type.OrderID.ToString();
            if (type.IsShow == 1)
            {
                IsShow.Checked = true;
            }
            else
            {
                IsShow.Checked = false;
            }
            hidProp.Value = type.Pro_Ids;
            hidSpec.Value = type.Spec_Ids;
        }

        private void method_7(string string_5)
        {
            dt_Spec = ((ShopNum1_Spec_Action)LogicFactory.CreateShopNum1_Spec_Action()).Search_Type_Spec(string_5);
        }

        private void method_8(string string_5)
        {
            dt_Prop =
                ((ShopNum1_ShopProductProp_Action)LogicFactory.CreateShopNum1_ShopProductProp_Action())
                    .Search_Type_Prop(string_5);
        }

        private void method_9(string string_5)
        {
            dt_Brand = ((ShopNum1_Brand_Action)LogicFactory.CreateShopNum1_Brand_Action()).Search_Type_Brand(string_5);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            string_4 = Common.Common.ReqStr("t_id");
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(string_4))
                {
                    butSub.Text = "更新";
                    method_6();
                    lblSpec.Text = "编辑商品类型";
                }
                else
                {
                    txtSortId.Value = method_5();
                }
                method_7(string_4);
                method_8(string_4);
                method_9(string_4);
            }
        }
    }
}