using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1.ShopFeeTemplate;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_LogisticsTemplateOperate : BaseShopWebControl
    {
        private Repeater RepeaterEMS;
        private Repeater RepeaterExpress;
        private Repeater RepeaterPost;
        private Button btnSub;
        private HtmlInputCheckBox checkboxEMS;
        private HtmlInputCheckBox checkboxExpress;
        private HtmlInputCheckBox checkboxPost;
        private DataTable dt;
        private HtmlInputText ems_postage_0;
        private HtmlInputText ems_postageplus_0;
        private HtmlInputText express_postage_0;
        private HtmlInputText express_postageplus_0;
        private HtmlGenericControl feeTemplateDiv;
        private HtmlInputHidden hidEms;
        private HtmlInputHidden hidExpress;
        private HtmlInputHidden hidPost;
        private HtmlTableCell postEms;
        private HtmlTableCell postExpress;
        private HtmlTableCell postPost;
        private HtmlInputText post_postage_0;
        private HtmlInputText post_postageplus_0;
        private string skinFilename = "S_LogisticsTemplateOperate.ascx";
        private HtmlInputText texttemplateName;

        public S_LogisticsTemplateOperate()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected void btnSub_Click(object sender, EventArgs e)
        {
            ButtonAddEvent();
        }

        protected void ButtonAddEvent()
        {
            int num;
            string[] strArray;
            int num2;
            Shop_FeeTemplate template;
            var action = new Shop_FeeTemplate_Action();
            string path = method_1();
            string str2 = Page.Server.MapPath(path);
            string templateID = string.Empty;
            if (Common.Common.ReqStr("templateid") != "")
            {
                templateID = Common.Common.ReqStr("templateid");
                if (!action.DelByTemplateID(templateID, str2))
                {
                    return;
                }
            }
            else
            {
                templateID = action.GetMaxFeeTemplateId(str2).ToString();
            }
            string str4 = texttemplateName.Value.Trim();
            var feetemplates = new List<Shop_FeeTemplate>();
            if (checkboxExpress.Checked)
            {
                string text1 = express_postage_0.Value;
                string text2 = express_postageplus_0.Value;
                var item = new Shop_FeeTemplate();
                if ((hidExpress.Value != "0") && (hidExpress.Value != ""))
                {
                    num2 = 1;
                    if (hidExpress.Value.IndexOf("*") != -1)
                    {
                        strArray = hidExpress.Value.Split(new[] {'*'});
                        for (num = 0; num < strArray.Length; num++)
                        {
                            if (strArray[num].Split(new[] {'.'})[1] != "")
                            {
                                template = new Shop_FeeTemplate
                                {
                                    createtime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                                    altertime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                                    feetype = "2",
                                    groupid = num2.ToString(),
                                    oneadd = strArray[num].Split(new[] {'.'})[2].Replace("-", ".")
                                };
                                template.fee = strArray[num].Split(new[] {'.'})[1];
                                template.orderid = "2";
                                template.templateid = templateID;
                                template.templatename = str4;
                                template.regioncode = "";
                                template.regionname = "";
                                template.groupregioncodes = strArray[num].Split(new[] {'.'})[0].Split(new[] {'|'})[0];
                                template.groupregionnames = strArray[num].Split(new[] {'.'})[0].Split(new[] {'|'})[1];
                                feetemplates.Add(template);
                                num2++;
                            }
                        }
                    }
                    else
                    {
                        strArray = hidExpress.Value.Split(new[] {'.'});
                        if ((strArray[1] != "") && (strArray[0].IndexOf("全国") == -1))
                        {
                            template = new Shop_FeeTemplate
                            {
                                createtime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                                altertime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                                feetype = "2",
                                groupid = num2.ToString(),
                                oneadd = strArray[2].Replace("-", ".")
                            };
                            template.fee = strArray[1];
                            template.orderid = "2";
                            template.templateid = templateID;
                            template.templatename = str4;
                            template.regioncode = "";
                            template.regionname = "";
                            template.groupregioncodes = strArray[0].Split(new[] {'|'})[0];
                            template.groupregionnames = strArray[0].Split(new[] {'|'})[1];
                            feetemplates.Add(template);
                            num2++;
                        }
                        else
                        {
                            item.createtime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                            item.altertime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                            item.feetype = "2";
                            item.groupid = "0";
                            item.oneadd = strArray[2].Replace("-", ".");
                            item.fee = strArray[1];
                            item.orderid = "2";
                            item.templateid = templateID;
                            item.templatename = str4;
                            item.regioncode = "000";
                            item.regionname = "全国";
                            item.groupregioncodes = "000";
                            item.groupregionnames = "全国";
                            feetemplates.Add(item);
                        }
                    }
                }
            }
            if (checkboxEMS.Checked)
            {
                string text3 = ems_postage_0.Value;
                string text4 = ems_postageplus_0.Value;
                var template2 = new Shop_FeeTemplate();
                if ((hidEms.Value != "0") && (hidEms.Value != ""))
                {
                    num2 = 1;
                    if (hidEms.Value.IndexOf("*") != -1)
                    {
                        strArray = hidEms.Value.Split(new[] {'*'});
                        for (num = 0; num < strArray.Length; num++)
                        {
                            template = new Shop_FeeTemplate
                            {
                                createtime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                                altertime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                                feetype = "3",
                                groupid = num2.ToString(),
                                oneadd = strArray[num].Split(new[] {'.'})[2].Replace("-", ".")
                            };
                            template.fee = strArray[num].Split(new[] {'.'})[1];
                            template.orderid = "3";
                            template.templateid = templateID;
                            template.templatename = str4;
                            template.regioncode = "";
                            template.regionname = "";
                            template.groupregioncodes = strArray[num].Split(new[] {'.'})[0].Split(new[] {'|'})[0];
                            template.groupregionnames = strArray[num].Split(new[] {'.'})[0].Split(new[] {'|'})[1];
                            feetemplates.Add(template);
                            num2++;
                        }
                    }
                    else
                    {
                        strArray = hidEms.Value.Split(new[] {'.'});
                        if ((strArray[1] != "") && (strArray[0].IndexOf("全国") == -1))
                        {
                            template = new Shop_FeeTemplate
                            {
                                createtime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                                altertime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                                feetype = "3",
                                groupid = num2.ToString(),
                                oneadd = strArray[2].Replace("-", ".")
                            };
                            template.fee = strArray[1];
                            template.orderid = "3";
                            template.templateid = templateID;
                            template.templatename = str4;
                            template.regioncode = "";
                            template.regionname = "";
                            template.groupregioncodes = strArray[0].Split(new[] {'|'})[0];
                            template.groupregionnames = strArray[0].Split(new[] {'|'})[1];
                            feetemplates.Add(template);
                            num2++;
                        }
                        else
                        {
                            template2.createtime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                            template2.altertime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                            template2.feetype = "3";
                            template2.groupid = "0";
                            template2.oneadd = strArray[2].Replace("-", ".");
                            template2.fee = strArray[1];
                            template2.orderid = "3";
                            template2.templateid = templateID;
                            template2.templatename = str4;
                            template2.regioncode = "000";
                            template2.regionname = "全国";
                            template2.groupregioncodes = "000";
                            template2.groupregionnames = "全国";
                            feetemplates.Add(template2);
                        }
                    }
                }
            }
            if (checkboxPost.Checked)
            {
                string text5 = post_postage_0.Value;
                string text6 = post_postageplus_0.Value;
                var template3 = new Shop_FeeTemplate();
                if ((hidPost.Value != "0") && (hidPost.Value != ""))
                {
                    num2 = 1;
                    if (hidPost.Value.IndexOf("*") != -1)
                    {
                        strArray = hidPost.Value.Split(new[] {'*'});
                        for (num = 0; num < strArray.Length; num++)
                        {
                            template = new Shop_FeeTemplate
                            {
                                createtime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                                altertime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                                feetype = "1",
                                groupid = num2.ToString(),
                                oneadd = strArray[num].Split(new[] {'.'})[2].Replace("-", ".")
                            };
                            template.fee = strArray[num].Split(new[] {'.'})[1];
                            template.orderid = "1";
                            template.templateid = templateID;
                            template.templatename = str4;
                            template.regioncode = "";
                            template.regionname = "";
                            template.groupregioncodes = strArray[num].Split(new[] {'.'})[0].Split(new[] {'|'})[0];
                            template.groupregionnames = strArray[num].Split(new[] {'.'})[0].Split(new[] {'|'})[1];
                            feetemplates.Add(template);
                            num2++;
                        }
                    }
                    else
                    {
                        strArray = hidPost.Value.Split(new[] {'.'});
                        if ((strArray[1] != "") && (strArray[0].IndexOf("全国") == -1))
                        {
                            template = new Shop_FeeTemplate
                            {
                                createtime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                                altertime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                                feetype = "1",
                                groupid = num2.ToString(),
                                oneadd = strArray[2].Replace("-", ".")
                            };
                            template.fee = strArray[1];
                            template.orderid = "1";
                            template.templateid = templateID;
                            template.templatename = str4;
                            template.regioncode = "";
                            template.regionname = "";
                            template.groupregioncodes = strArray[0].Split(new[] {'|'})[0];
                            template.groupregionnames = strArray[0].Split(new[] {'|'})[1];
                            feetemplates.Add(template);
                            num2++;
                        }
                        else
                        {
                            template3.createtime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                            template3.altertime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                            template3.feetype = "1";
                            template3.groupid = "0";
                            template3.oneadd = strArray[2].Replace("-", ".");
                            template3.fee = strArray[1];
                            template3.orderid = "1";
                            template3.templateid = templateID;
                            template3.templatename = str4;
                            template3.regioncode = "000";
                            template3.regionname = "全国";
                            template3.groupregioncodes = "000";
                            template3.groupregionnames = "全国";
                            feetemplates.Add(template3);
                        }
                    }
                }
            }
            try
            {
                string strerror = string.Empty;
                if (action.AddFeeTemplates(feetemplates, str2, out strerror))
                {
                    Page.Response.Redirect("S_Logistics.aspx", false);
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(),"msg", "<script>alert(\"" + strerror + "\");</script>");
                }
            }
            catch (Exception)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(),"msg", "<script>alert(\"店铺邮费文件不存在，未能找到路径" + str2 + "邮费文件！\");</script>");
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            postPost = (HtmlTableCell) skin.FindControl("postPost");
            postEms = (HtmlTableCell) skin.FindControl("postEms");
            postExpress = (HtmlTableCell) skin.FindControl("postExpress");
            checkboxExpress = (HtmlInputCheckBox) skin.FindControl("checkboxExpress");
            checkboxEMS = (HtmlInputCheckBox) skin.FindControl("checkboxEMS");
            checkboxPost = (HtmlInputCheckBox) skin.FindControl("checkboxPost");
            btnSub = (Button) skin.FindControl("btnSub");
            express_postage_0 = (HtmlInputText) skin.FindControl("express_postage_0");
            express_postageplus_0 = (HtmlInputText) skin.FindControl("express_postageplus_0");
            ems_postage_0 = (HtmlInputText) skin.FindControl("ems_postage_0");
            ems_postageplus_0 = (HtmlInputText) skin.FindControl("ems_postageplus_0");
            post_postage_0 = (HtmlInputText) skin.FindControl("post_postage_0");
            post_postageplus_0 = (HtmlInputText) skin.FindControl("post_postageplus_0");
            btnSub.Click += btnSub_Click;
            texttemplateName = (HtmlInputText) skin.FindControl("texttemplateName");
            feeTemplateDiv = (HtmlGenericControl) skin.FindControl("feeTemplateDiv");
            RepeaterPost = (Repeater) skin.FindControl("RepeaterPost");
            RepeaterEMS = (Repeater) skin.FindControl("RepeaterEMS");
            RepeaterExpress = (Repeater) skin.FindControl("RepeaterExpress");
            hidExpress = (HtmlInputHidden) skin.FindControl("hidExpress");
            hidEms = (HtmlInputHidden) skin.FindControl("hidEms");
            hidPost = (HtmlInputHidden) skin.FindControl("hidPost");
            if (!Page.IsPostBack && (Common.Common.ReqStr("templateid") != ""))
            {
                BindData();
            }
        }

        protected void BindData()
        {
            var action = new Shop_FeeTemplate_Action();
            string path = method_1();
            string templateid = Page.Request.QueryString["templateid"];
            string strerror = string.Empty;
            dt = action.GetFeesByIDRegion(Page.Server.MapPath(path), templateid, "-1", "-1", out strerror);
            if ((dt != null) && (dt.Rows.Count != 0))
            {
                string str5;
                DataRow[] rowArray;
                texttemplateName.Value = dt.Rows[0]["templatename"].ToString();
                bool flag = false;
                bool flag2 = false;
                bool flag3 = false;
                DataTable table3 = null;
                foreach (DataRow row in dt.Rows)
                {
                    if (row["feetype"].ToString() == "2")
                    {
                        flag = true;
                    }
                    else if (row["feetype"].ToString() == "1")
                    {
                        flag3 = true;
                    }
                    else
                    {
                        flag2 = true;
                    }
                    if ((flag2 && flag) && flag3)
                    {
                        break;
                    }
                }
                string innerHtml = feeTemplateDiv.InnerHtml;
                if (flag)
                {
                    checkboxExpress.Checked = true;
                    rowArray = dt.Select("feetype='2'");
                    if ((rowArray != null) && (rowArray.Length > 0))
                    {
                        table3 = rowArray.CopyToDataTable();
                        if ((table3 != null) && (table3.Rows.Count > 0))
                        {
                            DataTable table6 = table3;
                            RepeaterExpress.DataSource = table6;
                            RepeaterExpress.DataBind();
                            if (RepeaterExpress.Controls[0] != null)
                            {
                                var cell1 = (HtmlTableCell) RepeaterExpress.Controls[0].FindControl("postTd");
                                str5 =
                                    innerHtml.Replace("{delivery}", "express")
                                        .Replace("{value}", table6.Rows[0]["fee"].ToString())
                                        .Replace("{plusvalue}", table6.Rows[0]["oneadd"].ToString())
                                        .Replace("{postnumvalue}", table6.Rows.Count.ToString());
                                postExpress.InnerHtml = str5;
                            }
                        }
                    }
                }
                if (flag2)
                {
                    checkboxEMS.Checked = true;
                    rowArray = dt.Select("feetype=3 ");
                    if ((rowArray != null) && (rowArray.Length > 0))
                    {
                        DataTable table4 = rowArray.CopyToDataTable();
                        if ((table4 != null) && (table4.Rows.Count > 0))
                        {
                            DataTable table5 = table4;
                            RepeaterEMS.DataSource = table5;
                            RepeaterEMS.DataBind();
                            if (RepeaterEMS.Controls[0] != null)
                            {
                                var cell2 = (HtmlTableCell) RepeaterEMS.Controls[0].FindControl("postTd");
                                str5 =
                                    innerHtml.Replace("{delivery}", "ems")
                                        .Replace("{value}", table5.Rows[0]["fee"].ToString())
                                        .Replace("{plusvalue}", table5.Rows[0]["oneadd"].ToString())
                                        .Replace("{postnumvalue}", table5.Rows.Count.ToString());
                                postEms.InnerHtml = str5;
                            }
                        }
                    }
                }
                if (flag3)
                {
                    checkboxPost.Checked = true;
                    rowArray = dt.Select("feetype=1");
                    if ((rowArray != null) && (rowArray.Length > 0))
                    {
                        DataTable table = rowArray.CopyToDataTable();
                        if ((table != null) && (table.Rows.Count > 0))
                        {
                            DataTable table2 = table;
                            RepeaterPost.DataSource = table2;
                            RepeaterPost.DataBind();
                            if (RepeaterPost.Controls[0] != null)
                            {
                                var cell3 = (HtmlTableCell) RepeaterPost.Controls[0].FindControl("postTd");
                                str5 =
                                    innerHtml.Replace("{delivery}", "post")
                                        .Replace("{value}", table2.Rows[0]["fee"].ToString())
                                        .Replace("{plusvalue}", table2.Rows[0]["oneadd"].ToString())
                                        .Replace("{postnumvalue}", table2.Rows.Count.ToString());
                                postPost.InnerHtml = str5;
                            }
                        }
                    }
                }
            }
        }

        private string method_1()
        {
            DataTable memLoginInfo =
                ((Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action()).GetMemLoginInfo(base.MemLoginID);
            string str = memLoginInfo.Rows[0]["ShopID"].ToString();
            string str2 = DateTime.Parse(memLoginInfo.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
            return ("~/Shop/Shop/" + str2.Replace("-", "/") + "/shop" + str + "/xml/PostageTemplate.xml");
        }

        private string method_2(string string_1, string string_2)
        {
            string str;
            if (string_2 == "get")
            {
                try
                {
                    str = Page.Request.QueryString[string_1];
                    if (str == string.Empty)
                    {
                        return "-1";
                    }
                    return str;
                }
                catch
                {
                    return "-1";
                }
            }
            try
            {
                str = Page.Request.Form[string_1];
                if (str == string.Empty)
                {
                    return "-1";
                }
                return str;
            }
            catch
            {
                return "-1";
            }
        }
    }
}