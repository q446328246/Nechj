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

using System.Text;
using ShopNum1.Common.ShopNum1.Common;
using ShopNum1.Standard;
using ShopNum1.Webservice.CreateOrderTJ88;



namespace ShopNum1.Deploy.Main.Admin
{
    public partial class MemberShip_List : PageBase, IRequiresSessionState
    {

        protected void BindGrid()
        {
            if (this.Page.Request.QueryString["ShipID"] != null)
            {
                this.ShipObjectDataSourceDate.SelectParameters["Shipstatu"].DefaultValue = this.Page.Request.QueryString["ShipID"].ToString();
            }
            ShipNum1GridViewShow.DataBind();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();

            string text = (this.Page.Request.QueryString["ShipState"] == null) ? "1" : this.Page.Request.QueryString["ShipState"].ToString();
            switch (text)
            {
                case "1":
                    this.method_6(this.LinkButtonAll);
                    this.ShipNum1GridViewShow.Columns[8].Visible = false;

                    break;
                case "2":
                    this.method_6(this.LinkButtonPayment);
                    this.ShipNum1GridViewShow.Columns[7].Visible = false;
                    this.ShipNum1GridViewShow.Columns[3].Visible = false;
                    this.ShipNum1GridViewShow.Columns[4].Visible = false;
                    this.ShipNum1GridViewShow.Columns[8].Visible = false;

                    break;
                //case "3":
                //    this.method_6(this.LinkButtonNopayment);
                //    this.ShipNum1GridViewShow.Columns[8].Visible = false;


                //    break;
                //case "4":
                //    this.method_6(this.LinkButtonQDone);
                //    this.ShipNum1GridViewShow.Columns[7].Visible = false;
                //    this.ShipNum1GridViewShow.Columns[3].Visible = false;
                //    this.ShipNum1GridViewShow.Columns[4].Visible = false;

                //    break;
                case "0":
                    this.method_6(this.LinkButtonDeleted);
                    this.ShipNum1GridViewShow.Columns[8].Visible = false;
                    this.ShipNum1GridViewShow.Columns[7].Visible = false;
                    break;


            }


            BindGrid();

        }
        private void method_6(LinkButton linkButton_0)
        {
            this.LinkButtonAll.CssClass = "";
            //this.LinkButtonNopayment.CssClass = "";
            this.LinkButtonPayment.CssClass = "";


            linkButton_0.CssClass = "cur";
        }
        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            string shipidall = CheckShipID.Value;
            String[] id = shipidall.Split(new char[] { ',' });

            for (int i = 0; i < id.Length; i++)
            {
                var action = (ShopNum1_MemberShip_Action)LogicFactory.CreateShopNum1_MemberShip_Action();
                int num = action.Delete(id[i].ToString());

                if (num == -1)
                {
                    MessageBox.Show("没有此条记录！");
                }
                else if (num > 0)
                {
                    var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员删除会员等级申请列表",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "MemberShip_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                    base.OperateLog(operateLog);

                    BindGrid();
                    MesShow.ShowMessage("DelYes");
                    MesShow.Visible = true;
                }
                else
                {
                    MesShow.ShowMessage("DelNo");
                    MesShow.Visible = true;
                }
            }





        }

        protected void LinkButtonAll_Click(object sender, EventArgs e)
        {
            string id = "1";
            base.Response.Redirect("MemberShip_List.aspx?ShipState=" + id);
        }

        protected void LinkButtonNopayment_Click(object sender, EventArgs e)
        {
            string id = "3";
            base.Response.Redirect("MemberShip_List.aspx?ShipState=" + id);
        }

        protected void LinkButtonPayment_Click(object sender, EventArgs e)
        {
            string id = "2";
            base.Response.Redirect("MemberShip_List.aspx?ShipState=" + id);
        }

        protected void LinkButtonQDone_Click(object sender, EventArgs e)
        {
            string id = "4";
            base.Response.Redirect("MemberShip_List.aspx?ShipState=" + id);
        }
        protected void LinkButtonDeleted_Click(object sender, EventArgs e)
        {
            string id = "0";
            base.Response.Redirect("MemberShip_List.aspx?ShipState=" + id);
        }



        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            string text = (this.Page.Request.QueryString["ShipState"] == null) ? "1" : this.Page.Request.QueryString["ShipState"].ToString();
            int shipStaue = Convert.ToInt32(text);
            var action = (ShopNum1_MemberShip_Action)LogicFactory.CreateShopNum1_MemberShip_Action();
            if (txtMemLoginID.Value == "")
            {
                Response.Write("<Script Language=JavaScript>alert('请输入用户编号！');</Script>");
            }
            else
            {

                DataTable SearchShip = action.SearchShipMemLoginNO(txtMemLoginID.Value, shipStaue);

                ShipNum1GridViewShow.DataSourceID = null;
                ShipNum1GridViewShow.DataSource = SearchShip;
                ShipNum1GridViewShow.DataBind();





            }
        }
        protected void ButtonPassByShip_Click(object sender, EventArgs e)
        {

            var button = (LinkButton)sender;
            string ShipID = button.CommandArgument;
            ShopNum1_Member_Action Memaction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            ShopNum1_MemberShip_Action action = (ShopNum1_MemberShip_Action)LogicFactory.CreateShopNum1_MemberShip_Action();
            DataTable table = action.SearchShipID(ShipID);
            
            string NewRankID = table.Rows[0]["NewRankID"].ToString();
            string MemLoginID = table.Rows[0]["MemLoginID"].ToString();

            string Outmessage = string.Empty;
            string Belongs = table.Rows[0]["Belongs"].ToString();
            string ShopNames = table.Rows[0]["ShopNames"].ToString();
            string LastRankID = table.Rows[0]["LastRankID"].ToString();
            DateTime ExamineTime = DateTime.Now;


            Outmessage = "您的" + NewRankID + "绑定成功!";
            //var builder = new StringBuilder();
            //builder.Append("<?xml version='1.0' encoding='utf-8'?>");
            //builder.Append("<Shop>");
            //builder.Append("<Ver>1.0</Ver>");
            //builder.Append("<ShopName>" + table.Rows[0]["ShopNames"].ToString() + "</ShopName>"); //区代名称
            //builder.Append("<OrgID>1000</OrgID>"); //
            //builder.Append("<ShopType>2</ShopType>"); //区代类型
            //builder.Append("<Status>1</Status>"); //
            //builder.Append("<CustomerNo>" + table.Rows[0]["MemLoginNO"].ToString() + "</CustomerNo>"); //经销商编号
            //builder.Append("<AddDate>" + DateTime.Now.ToString() + "</AddDate>"); //加入时间
            //builder.Append("<RecommendCustomerNo></RecommendCustomerNo>"); //推荐人编号
            //builder.Append("<ParentShopNo>" + table.Rows[0]["Belongs"].ToString() + "</ParentShopNo>"); //上级区代编号
            //builder.Append("<Memo></Memo>"); //备注
            //builder.Append("</Shop>");
            //string info = builder.ToString();
            //TJAPItwo.WebService webservice = new TJAPItwo.WebService();
            //string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            //string privateKey_two = "Info=" + info + md5_one;
            //string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
            //string returnResult = webservice.Operate("CHECKSHOPINPUT", info, md5Check_two);
            string returnResult = "成功";
            if (returnResult == "成功")
            {
                action.UpdatePassStatus(ShipID, ExamineTime);
                Memaction.UpdateMemberCarBand(MemLoginID, Belongs, ShopNames, LastRankID);

                DataTable gpstable = action.SearchGPSBand(Belongs);
                if (gpstable.Rows[0]["BandStatus"].ToString() == "0") 
                {
                    decimal price=Convert.ToDecimal(gpstable.Rows[0]["BandPrice"]);
                    action.UpdateGPSBandStatus(Belongs);
                    action.INsertAdvancePaymentModifyLog_Gz_BandPVA(MemLoginID, price * 5, "绑定矿机获得");
                }

                #region 发送站内信
                var messageInfo = new ShopNum1_MessageInfo
                {
                    Guid = Guid.NewGuid(),
                    Title = "车辆绑定成功",
                    Type = "1",
                    Content = "尊敬的" + MemLoginID.Trim() + ":" + Outmessage,
                    MemLoginID = MemLoginID,
                    SendTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    IsDeleted = 0
                };
                var usermessage = new List<string>
                        {
                            MemLoginID
                        };
                ((ShopNum1_MessageInfo_Action)LogicFactory.CreateShopNum1_MessageInfo_Action()).Add(messageInfo,
                                                                                                     usermessage);

                //加个通过短信
                //var sms = new SMS();
                //string retmsg = "";
                //sms.Send(Mobile, "尊敬的" + MemLoginID.Trim() + ":" + Outmessage + "【唐江宝宝】", out retmsg);

                Response.Write("<Script Language=JavaScript>alert('操作成功！');</Script>");

                BindGrid();

                #endregion
            }
            else
            {
                Response.Write("<script>alert('" + returnResult + "');</script>");
                BindGrid();
            }




            //else if (MemberRankGuid == MemberLevel.COMMUNITY_MEMBER_ID_three)
            //{

            //    Outmessage = "您的社区店II申请已经通过！";
            //    //在TJ88创建订单
            //    Qhtj88CreateOrder api = new Qhtj88CreateOrder();
            //    string md5_one2 = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            //    string privateKey_two2 = "MemloginNO=" + MemLoginNO + "&LevelType=" + 2 + md5_one2 + "";
            //    string md5Check_two2 = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two2);
            //    api.CreateOrder(md5Check_two2, MemLoginNO, 2);
            //    //string SQMemLoginNO = table.Rows[0]["MemLoginNO"].ToString();
            //    //string SHOPEDIT1 = SQMemLoginNO + "~" + SQMemLoginNO;
            //    //TJAPItwo.WebService webservice = new TJAPItwo.WebService();

            //    //string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            //    //string privateKey_two = "Info=" + SHOPEDIT1 + md5_one;
            //    //string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
            //    //string returnResult = webservice.Operate("SHOPEDIT1", SHOPEDIT1, md5Check_two);
            //    //string[] sArray = returnResult.Split(new char[2] { '~', '|' });
            //    //if (sArray[0] == "true")
            //    string sArray = "true";
            //    if (sArray == "true")
            //    {
            //        action.UpdatePassStatus(ShipID, ExamineTime);
            //        Memaction.UpdateMemberRankGuid(MemLoginID, MemberRankGuid);
            //        Tj88Rank.ServiceSlecetOrder mms = new Tj88Rank.ServiceSlecetOrder();
            //        string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            //        string privateKey_two = "RnkGuid=" + MemberLevel.COMMUNITY_MEMBER_ID_three + "&MenberId=" + MemLoginNO + md5_one + "";
            //        string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
            //        try
            //        {
            //            string fh = mms.UpdateMenberRank_GZ(MemberLevel.COMMUNITY_MEMBER_ID_three, MemLoginNO, md5Check_two);
            //            if (fh != "操作成功")
            //            {
            //                string fhh = mms.UpdateMenberRank_GZ(MemberLevel.COMMUNITY_MEMBER_ID_three, MemLoginNO, md5Check_two);
            //            }
            //        }
            //        catch (Exception)
            //        {

            //            string fh = mms.UpdateMenberRank_GZ(MemberLevel.COMMUNITY_MEMBER_ID_three, MemLoginNO, md5Check_two);
            //        }
            //        #region 发送站内信
            //        var messageInfo = new ShopNum1_MessageInfo
            //        {
            //            Guid = Guid.NewGuid(),
            //            Title = "会员升级成功",
            //            Type = "1",
            //            Content = "尊敬的" + MemLoginID.Trim() + ":" + Outmessage,
            //            MemLoginID = MemLoginID,
            //            SendTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
            //            IsDeleted = 0
            //        };
            //        var usermessage = new List<string>
            //            {
            //                MemLoginID
            //            };
            //        ((ShopNum1_MessageInfo_Action)LogicFactory.CreateShopNum1_MessageInfo_Action()).Add(messageInfo,
            //                                                                                             usermessage);


            //        //加个通过短信
            //        var sms = new SMS();
            //        string retmsg = "";
            //        sms.Send(Mobile, "尊敬的" + MemLoginID.Trim() + ":" + Outmessage + "【唐江宝宝】", out retmsg);

            //        Response.Write("<Script Language=JavaScript>alert('操作成功！');</Script>");

            //        BindGrid();

            //        #endregion
            //    }
            //    else
            //    {
            //        Response.Write("<script>alert('" + sArray[1] + "');</script>");
            //        BindGrid();
            //    }
            //}




        }

        protected void ButtonRefuseByShip_Click(object sender, EventArgs e)
        {
            var button = (LinkButton)sender;
            string ShipID = button.CommandArgument;
            var action = (ShopNum1_MemberShip_Action)LogicFactory.CreateShopNum1_MemberShip_Action();
            DataTable table = action.SearchShipID(ShipID);
            string MemberRankGuid = table.Rows[0]["NewRankID"].ToString();
            string MemLoginID = table.Rows[0]["MemLoginID"].ToString();
            string Outmessage = string.Empty;
            //string Mobile = table.Rows[0]["Mobile"].ToString();

            action.UpdateRefuseStatus(ShipID);
            action.UpdateRefuseweixinOpenid(MemLoginID);
            //action.DeleteShipAdress(MemLoginID);

            //if (MemberRankGuid == MemberLevel.AGENT_MEMBER_ID)
            //{
            Outmessage = "您车辆绑定申请已被驳回，请下次申请!";
            //}
            //if (MemberRankGuid == MemberLevel.COMMUNITY_MEMBER_ID)
            //{
            //    Outmessage = "您的临时社区店申请已被驳回，请下次申请!";
            //}
            //if (MemberRankGuid == MemberLevel.AGENT_MEMBER_ID_three)
            //{
            //    Outmessage = "您的区代理II申请已被驳回，请下次申请!";
            //}
            //if (MemberRankGuid == MemberLevel.COMMUNITY_MEMBER_ID_three)
            //{
            //    Outmessage = "您的社区店II申请已被驳回，请下次申请!";
            //}

            var messageInfo = new ShopNum1_MessageInfo
            {
                Guid = Guid.NewGuid(),
                Title = "会员升级失败",
                Type = "1",
                Content = "尊敬的" + MemLoginID.Trim() + ":" + Outmessage,
                MemLoginID = MemLoginID,
                SendTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                IsDeleted = 0
            };
            var usermessage = new List<string>
                        {
                            MemLoginID

                        };
            ((ShopNum1_MessageInfo_Action)LogicFactory.CreateShopNum1_MessageInfo_Action()).Add(messageInfo,
                                                                                               usermessage);
            //加个失败短信    内容是 Outmessage
            //var sms = new SMS();
            //string retmsg = "";
            //sms.Send(Mobile, "尊敬的" + MemLoginID.Trim() + ":" + Outmessage + "【唐江宝宝】", out retmsg);
            Response.Write("<Script Language=JavaScript>alert('操作成功！');</Script>");
            BindGrid();
        }

        //protected void ButtonSelcet_Click(object sender, EventArgs e)
        //{
        //    Int32 selectSatue = Convert.ToInt32(SelectSatue.Value);
        //    var action = (ShopNum1_MemberShip_Action)LogicFactory.CreateShopNum1_MemberShip_Action();
        //    DataTable SearchShip = action.SearchShipStatu( selectSatue);

        //    ShipNum1GridViewShow.DataSourceID = null;
        //    ShipNum1GridViewShow.DataSource = SearchShip;
        //    ShipNum1GridViewShow.DataBind();

        //    int text =Convert.ToInt32(SearchShip.Rows[0]["ShipStatus"]);
        //    switch (text)
        //    {
        //        case 0:
        //            //this.method_6(this.LinkButtonAll);
        //            this.ShipNum1GridViewShow.Columns[7].Visible = false;
        //            break;
        //        case 4:
        //            //this.method_6(this.LinkButtonNopayment);
        //            this.ShipNum1GridViewShow.Columns[7].Visible = false;

        //            break;
        //        case 2:
        //            //this.method_6(this.LinkButtonPayment);
        //            this.ShipNum1GridViewShow.Columns[7].Visible = false;
        //            break;
        //    }

        //}



    }
}