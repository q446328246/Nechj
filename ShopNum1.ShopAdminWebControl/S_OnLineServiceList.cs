using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_OnLineServiceList : BaseShopWebControl
    {
        private Button Btn_OK;
        private LinkButton LinkDelete;
        private Repeater Rep_NoValue;
        private Repeater RepeaterShow;
        private HtmlInputCheckBox checkbox_Phone;
        private HtmlInputCheckBox checkbox_QQ;
        private HtmlInputCheckBox checkbox_WW;
        private HtmlInputHidden hid_OnOff;
        private HtmlInputHidden hid_PhoneOff;
        private HiddenField hid_SelectGuid;
        private HtmlGenericControl pageDiv;
        private string skinFilename = "S_OnLineServiceList.ascx";
        private string string_1 = string.Empty;
        private HtmlInputText txt_Phone;

        public S_OnLineServiceList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string pageid { get; set; }

        public string PageSize { get; set; }

        private string ShopSite { get; set; }

        public string StrPath { get; set; }

        protected void Btn_OK_Click(object sender, EventArgs e)
        {
            var action = (Shop_OnLineService_Action) LogicFactory.CreateShop_OnLineService_Action();
            var strArray = new string[2];
            var isshow = new string[2];
            for (int i = 0; i < 2; i++)
            {
                strArray[i] = (i + 1).ToString();
                isshow[i] = "0";
            }
            if (checkbox_QQ.Checked)
            {
                isshow[0] = "1";
            }
            if (checkbox_WW.Checked)
            {
                isshow[1] = "1";
            }
            int num2 = action.Update(strArray, isshow, StrPath, base.MemLoginID);
            var set = new DataSet();
            set.ReadXml(Page.Server.MapPath(ShopSite));
            DataRow row = set.Tables["Setting"].Rows[0];
            if (hid_OnOff.Value == "1")
            {
                row["ShowCustomer"] = "1";
            }
            else
            {
                row["ShowCustomer"] = "0";
            }
            if (checkbox_Phone.Checked)
            {
                row["IsOpenServicePhone"] = "1";
                row["ServicePhone"] = txt_Phone.Value;
            }
            else
            {
                row["IsOpenServicePhone"] = "0";
            }
            set.AcceptChanges();
            try
            {
                set.WriteXml(Page.Server.MapPath(ShopSite));
            }
            catch
            {
                MessageBox.Show("文件读写权限不够");
                return;
            }
            if (num2 > 0)
            {
                MessageBox.Show("修改成功！");
            }
            else
            {
                MessageBox.Show("修改失败！");
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            hid_OnOff = (HtmlInputHidden) skin.FindControl("hid_OnOff");
            checkbox_QQ = (HtmlInputCheckBox) skin.FindControl("checkbox_QQ");
            checkbox_WW = (HtmlInputCheckBox) skin.FindControl("checkbox_WW");
            checkbox_Phone = (HtmlInputCheckBox) skin.FindControl("checkbox_Phone");
            Btn_OK = (Button) skin.FindControl("Btn_OK");
            Btn_OK.Click += Btn_OK_Click;
            hid_SelectGuid = (HiddenField) skin.FindControl("hid_SelectGuid");
            hid_PhoneOff = (HtmlInputHidden) skin.FindControl("hid_PhoneOff");
            LinkDelete = (LinkButton) skin.FindControl("LinkDelete");
            LinkDelete.Click += LinkDelete_Click;
            txt_Phone = (HtmlInputText) skin.FindControl("txt_Phone");
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            RepeaterShow.ItemCommand += RepeaterShow_ItemCommand;
            Rep_NoValue = (Repeater) skin.FindControl("Rep_NoValue");
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            pageid = (Common.Common.ReqStr("PageID") == "") ? "1" : Common.Common.ReqStr("PageID");
            DataTable memLoginInfo =
                ((Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action()).GetMemLoginInfo(base.MemLoginID);
            var action2 = (Shop_OnLineService_Action) LogicFactory.CreateShop_OnLineService_Action();
            string str = memLoginInfo.Rows[0]["ShopID"].ToString();
            string str2 = DateTime.Parse(memLoginInfo.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
            action2.StrPath = "~/Shop/Shop/" + str2.Replace("-", "/") + "/" + ShopSettings.GetValue("PersonShopUrl") +
                              str + "/xml/OnLineServer.xml";
            ShopSite = "~/Shop/Shop/" + str2.Replace("-", "/") + "/" + ShopSettings.GetValue("PersonShopUrl") + str +
                       "/Site_Settings.xml";
            StrPath = action2.StrPath;
            BindData();
            method_1();
        }

        public static string IsShow(object object_0)
        {
            switch (object_0.ToString())
            {
                case "0":
                    return "否";

                case "1":
                    return "是";
            }
            return "";
        }

        protected void LinkDelete_Click(object sender, EventArgs e)
        {
            string guid = hid_SelectGuid.Value;
            var action = (Shop_OnLineService_Action) LogicFactory.CreateShop_OnLineService_Action();
            if (action.DeleteOnLineService(guid) > 0)
            {
                MessageBox.Show("删除成功！");
                Page.Response.Redirect("S_OnLineServiceList.aspx?type=1");
            }
        }

        protected void BindData()
        {
            DataTable table = ((Shop_OnLineService_Action) LogicFactory.CreateShop_OnLineService_Action()).Search("-1",
                "-1",
                StrPath);
            if ((table != null) && (table.Rows.Count > 0))
            {
                foreach (DataRow row2 in table.Rows)
                {
                    string str = row2["id"] + row2["IsShow"].ToString();
                    if (str != null)
                    {
                        if (!(str == "11"))
                        {
                            if (str == "21")
                            {
                                checkbox_WW.Checked = true;
                            }
                        }
                        else
                        {
                            checkbox_QQ.Checked = true;
                        }
                    }
                }
            }
            var set = new DataSet();
            set.ReadXml(Page.Server.MapPath(ShopSite));
            DataRow row = set.Tables["Setting"].Rows[0];
            txt_Phone.Value = row["ServicePhone"].ToString();
            if (row["ShowCustomer"].ToString() == "1")
            {
                hid_OnOff.Value = "1";
            }
            else if (row["ShowCustomer"].ToString() == "0")
            {
                hid_OnOff.Value = "0";
            }
            if (row["IsOpenServicePhone"].ToString() == "1")
            {
                checkbox_Phone.Checked = true;
            }
        }

        protected void method_1()
        {
            var action = (Shop_OnLineService_Action) LogicFactory.CreateShop_OnLineService_Action();
            string str = string.Empty;
            if (!string.IsNullOrEmpty(base.MemLoginID))
            {
                str = str + "  AND  MemLoginID=  '" + base.MemLoginID + "' ";
            }
            var commonModel = new CommonPageModel
            {
                Condition = "   " + str + "  ",
                Currentpage = pageid,
                Tablename = "ShopNum1_Shop_OnlineService",
                Resultnum = "0",
                PageSize = PageSize
            };
            DataTable table2 = action.SelectOnLineService_List(commonModel);
            var pl = new PageList1
            {
                PageSize = Convert.ToInt32(PageSize),
                PageID = Convert.ToInt32(pageid)
            };
            if ((table2 != null) && (table2.Rows.Count > 0))
            {
                pl.RecordCount = Convert.ToInt32(table2.Rows[0][0]);
            }
            else
            {
                pl.RecordCount = 0;
            }
            pageDiv.InnerHtml =
                new PageListBll("/Shop/ShopAdmin/S_OnLineServiceList.aspx", true).GetPageListNew(pl);
            commonModel.Resultnum = "1";
            DataTable table = action.SelectOnLineService_List(commonModel);
            if (table.Rows.Count > 0)
            {
                Rep_NoValue.Visible = false;
                RepeaterShow.DataSource = table;
                RepeaterShow.DataBind();
            }
            else
            {
                Rep_NoValue.Visible = true;
                RepeaterShow.Visible = false;
                var table3 = new DataTable();
                table3.Columns.Add("NoValue", typeof (string));
                DataRow row = table3.NewRow();
                row["NoValue"] = "暂无信息";
                table3.Rows.Add(row);
                Rep_NoValue.DataSource = table3;
                Rep_NoValue.DataBind();
            }
        }

        private int method_2()
        {
            return Common.Common.ReturnMaxID("OrderID", "MemLoginID", base.MemLoginID, "ShopNum1_Shop_OnlineService");
        }

        protected void RepeaterShow_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            var hidden = (HtmlInputHidden) e.Item.FindControl("HiddenField_Guid");
            string str = hidden.Value;
            if (e.CommandName == "delete")
            {
                ((Shop_OnLineService_Action) LogicFactory.CreateShop_OnLineService_Action()).DeleteOnLineService("'" +
                                                                                                                 str +
                                                                                                                 "'");
                Page.Response.Redirect("S_OnLineServiceList.aspx?type=1");
            }
        }
    }
}