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
    public partial class Specification_Operate : PageBase, IRequiresSessionState
    {
        public string strIsPic = string.Empty;
        public DataTable dt_Spec = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                if ((Common.Common.ReqStr("id") != "0") && (Common.Common.ReqStr("sign") == "del"))
                {
                    ((ShopNum1_Spec_Action)LogicFactory.CreateShopNum1_Spec_Action()).DeleteValue(
                        Common.Common.ReqStr("id"));
                }
                TextBoxOrderID.Text = Convert.ToString((method_6() + 1));
                if (base.Request.QueryString["id"] != null)
                {
                    BindData();
                    lblSpec.Text = "编辑商品规格";
                    ButtonAdd.Text = "确定编辑";
                }
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_Spec_Action) LogicFactory.CreateShopNum1_Spec_Action();
            var spec = new ShopNum1_Spec
                {
                    SpecName = TextBoxSpecificationName.Text.Trim(),
                    Memo = TextBoxMemo.Text.Trim(),
                    ShowType = Convert.ToInt32(RadioButtonListShowType.SelectedValue),
                    OrderID = int.Parse(TextBoxOrderID.Text)
                };
            var listSpecValue = new List<ShopNum1_SpecValue>();
            if (HiddenFieldValues.Value != "-1")
            {
                string str = HiddenFieldValues.Value;
                int num = 0;
                if (base.Request.QueryString["id"] != null)
                {
                    num = Convert.ToInt32(base.Request.QueryString["id"]);
                    spec.ID = num;
                }
                else
                {
                    spec.ID = action.GetMaxGuid();
                }
                string[] strArray = str.Split(new[] {'|'});
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (strArray[i] != "")
                    {
                        ShopNum1_SpecValue value2;
                        if (RadioButtonListShowType.SelectedValue == "0")
                        {
                            value2 = new ShopNum1_SpecValue
                                {
                                    OrderId = Convert.ToInt32(strArray[i].Split(new[] {','})[0]),
                                    Name = strArray[i].Split(new[] {','})[1].Replace("*", "x"),
                                    ID = Convert.ToInt32(strArray[i].Split(new[] {','})[2]),
                                    Imagepath = ""
                                };
                            listSpecValue.Add(value2);
                        }
                        else
                        {
                            value2 = new ShopNum1_SpecValue
                                {
                                    OrderId = Convert.ToInt32(strArray[i].Split(new[] {','})[0]),
                                    Name = strArray[i].Split(new[] {','})[1].Replace("*", "x"),
                                    Imagepath = strArray[i].Split(new[] {','})[2],
                                    ID = Convert.ToInt32(strArray[i].Split(new[] {','})[3])
                                };
                            listSpecValue.Add(value2);
                        }
                    }
                }
            }
            int num2 = 0;
            if (base.Request.QueryString["id"] == null)
            {
                num2 = action.Add(spec, listSpecValue);
            }
            else
            {
                num2 = action.Update(spec, listSpecValue);
            }
            if (num2 > 0)
            {
                  HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                   
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员更改商品规格",
                        OperatorID = cookie2.Values["LoginID"].ToString(),
                        IP = Globals.IPAddress,
                        PageName = "Specification_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                base.Response.Redirect("Specification_List.aspx");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("AddNo");
                MessageShow.Visible = true;
            }
        }

        protected int GetOrderID(string filed, string table)
        {
            return (1 + ShopNum1_Common_Action.ReturnMaxID(filed, table));
        }

        private void BindData()
        {
            var action = (ShopNum1_Spec_Action) LogicFactory.CreateShopNum1_Spec_Action();
            DataTable table = action.SearchName(base.Request.QueryString["Id"]);
            this.dt_Spec = action.SearchByGuid(base.Request.QueryString["Id"]);
            if ((table != null) && (table.Rows.Count != 0))
            {
                TextBoxSpecificationName.Text = table.Rows[0]["SpecName"].ToString();
                TextBoxMemo.Text = table.Rows[0]["Memo"].ToString();
                TextBoxOrderID.Text = table.Rows[0]["OrderID"].ToString();
                strIsPic = table.Rows[0]["ShowType"].ToString();
                RadioButtonListShowType.SelectedValue = table.Rows[0]["ShowType"].ToString();
            }
        }

        private int method_6()
        {
            return ShopNum1_Common_Action.ReturnMaxID("OrderID", "ShopNum1_Spec");
        }

        private void method_7()
        {
            TextBoxSpecificationName.Text = string.Empty;
            TextBoxMemo.Text = string.Empty;
            TextBoxOrderID.Text = (int.Parse(TextBoxOrderID.Text) + 1).ToString();
            MessageShow.ShowMessage("AddYes");
        }


    }
}