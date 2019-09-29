using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class storeOrder_Report : PageBase, IRequiresSessionState
    {

        private void exc( DataTable table)
        { 
            if (table.Rows.Count>0)
	{
		 base.Response.Write("<tr style=\"color:#FFF;font-weight:bold; text-align:center\">");
         base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" > </td>");
         base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" > </td>");
         base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >区代进货单</td>");
         base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" ></td>");
         base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" ></td>");
                    base.Response.Write("</tr>");

                    base.Response.Write("<tr style=\"color:#FFF;font-weight:bold; text-align:center\">");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >发货日期 </td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" > {DispatchTime}</td>".Replace("{DispatchTime}", table.Rows[0]["DispatchTime"].ToString()));
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" ></td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" ></td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" ></td>");
                    base.Response.Write("</tr>");


                    base.Response.Write("<tr style=\"color:#FFF;font-weight:bold; text-align:center\">");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >商品名称</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >购买数量</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >收货人</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >收获地址</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >手机号码</td>");
                    base.Response.Write("</tr>");
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        base.Response.Write("<tr>");
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {ProductName}</td>".Replace("{ProductName}", table.Rows[i]["ProductName"].ToString()));
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {BuyNumber}</td>".Replace("{BuyNumber}", table.Rows[i]["BuyNumber"].ToString()));
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {Name}</td>".Replace("{Name}", table.Rows[i]["Name"].ToString()));
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {Address}</td>".Replace("{Address}", table.Rows[i]["Address"].ToString()));
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {Mobile}</td>".Replace("{Mobile}", table.Rows[i]["Mobile"].ToString()));
                        base.Response.Write("</tr>");
                    }

                    for (int i = 0; i < 37 - 3 - table.Rows.Count; i++)
                    {
                        base.Response.Write("<tr style=\"color:#FFF;font-weight:bold; text-align:center\">");

                        base.Response.Write("<td  style=\"background-color:#FFF;text-align:center\" ></td>");
                        base.Response.Write("<td  style=\"background-color:#FFF;text-align:center\" ></td>");
                        base.Response.Write("<td  style=\"background-color:#FFF;text-align:center\" ></td>");
                        base.Response.Write("<td  style=\"background-color:#FFF;text-align:center\" ></td>");
                        base.Response.Write("<td  style=\"background-color:#FFF;text-align:center\" ></td>");
                        base.Response.Write("</tr>");
                    }
                    
	}

          
            
        }

        private void exctwo(DataTable table)
        {
            if (table.Rows.Count>0)
            {
                long sumNum = 0;
                base.Response.Write("<tr style=\"color:#FFF;font-weight:bold; text-align:center\">");
                base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" ></td>");
                base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >发货单</td>");
                base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" ></td>");
                //base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" ></td>");
                base.Response.Write("</tr>");
                base.Response.Write("<tr style=\"color:#FFF;font-weight:bold; text-align:center\">");

                base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >日期</td>");
                base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" > {DispatchTime}</td>".Replace("{DispatchTime}", table.Rows[0]["DispatchTime"].ToString()));
                base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" ></td>");

                base.Response.Write("</tr>");
                base.Response.Write("<tr style=\"color:#FFF;font-weight:bold; text-align:center\">");
               
                base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >收货人</td>");
                base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >手机号码</td>");
                base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >收获地址</td>");
               
                base.Response.Write("</tr>");
                
                 base.Response.Write("<tr>");

                 base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {Name}</td>".Replace("{Name}", table.Rows[0]["Name"].ToString()));
                 base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {Mobile}</td>".Replace("{Mobile}", table.Rows[0]["Mobile"].ToString()));
                 base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {Address}</td>".Replace("{Address}", table.Rows[0]["Address"].ToString()));
                base.Response.Write("</tr>");
                base.Response.Write("<tr style=\"color:#FFF;font-weight:bold; text-align:center\">");
                base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >商品名称</td>");
                base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >购买数量</td>");
                base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >备注</td>");
                //base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" ></td>");
                base.Response.Write("</tr>");
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    base.Response.Write("<tr>");
                    base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {ProductName}</td>".Replace("{ProductName}", table.Rows[i]["ProductName"].ToString()));
                    base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {BuyNumber}</td>".Replace("{BuyNumber}", table.Rows[i]["BuyNumber"].ToString()));
                    base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"></td>");
                    //base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"></td>");
                    base.Response.Write("</tr>");
                    sumNum += long.Parse(table.Rows[i]["BuyNumber"].ToString());
                }



                base.Response.Write("<tr>");
                base.Response.Write("<td style=\"background-color:#FFF;text-align:center\">货品数量合计</td>");
                base.Response.Write("<td style=\"background-color:#FFF;text-align:center\">{sumNum}</td>".Replace("{sumNum}", sumNum.ToString()));
                base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"></td>");
                base.Response.Write("</tr>");



                base.Response.Write("<tr>");
                base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" >制单人</td>");
                base.Response.Write("<td colspan=\"2\" style=\"background-color:#FFF;text-align:center\"></td>");
                base.Response.Write("<td align=\"center\">");


                base.Response.Write("<tr style=\"color:#FFF;font-weight:bold; text-align:center\">");
                base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >审查</td>");
                base.Response.Write("<td  colspan=\"2\" style=\"background-color:#6699cc;text-align:center\" >经办人</td>");
                base.Response.Write("</tr>");
                base.Response.Write("<tr>");
                base.Response.Write("<td  style=\"background-color:#FFF;text-align:center\"></td>");
                base.Response.Write("<td colspan=\"2\"  style=\"background-color:#FFF;text-align:center\"></td>");
                base.Response.Write("</tr>");


                base.Response.Write("</td>");
                base.Response.Write("</tr>");




                base.Response.Write("<tr>");
                base.Response.Write("<td style=\"background-color:#6699cc;text-align:center\">包裹数量</td>");
                base.Response.Write("<td colspan=\"2\" style=\"background-color:#FFF;text-align:center\"></td>");




                base.Response.Write("</tr>");

                base.Response.Write("<tr>");

                base.Response.Write("<td colspan=\"3\" style=\"background-color:#FFF;\"><b>关于色差：</b>商品颜色受太多因素影响（如：每个人的颜色感知能力，相机的颜色再现能力，电脑硬件设置，系统软件设置，应用软件设置，周围环境的颜色复杂程度以及周围环境亮度等）</td>");
                base.Response.Write("</tr>");

                base.Response.Write("<tr>");

                base.Response.Write("<td  colspan=\"3\" style=\"background-color:#FFF;\"><b>关于交易：</b>拍下付款后为成功交易，付款后24小时内发货，如遇上促销活动、新品预定款等，则根据商城实际发货期安排发货。      </td>");
                base.Response.Write("</tr>");

                base.Response.Write("<tr>");

                base.Response.Write("<td  colspan=\"3\" style=\"background-color:#FFF;\"><b>关于物流：</b>商城默认为中通快递，中通不到的地方改为邮政，如需特殊要求需要在拍下时候在买家留言处留言或拨打400电话。</td>");
                base.Response.Write("</tr>");

                base.Response.Write("<tr>");

                base.Response.Write("<td  colspan=\"3\" style=\"background-color:#FFF;\"><b>关于售后：</b>发货前，我们都会用心检查每件商品的质量及核对订单，但毕竟是人工检查，还是会有小小的疏忽。收到货品发现有不满意，请您第一时间拨打我们的客服热线，第一时间为您安排处理。7天内无条件退换货，您不喜欢不满意都可以直接拨打我们的客服热线。15天内如有质量问题无条件换货，质量问题指非人为损坏的、使用不当的，产品本身出现的问题，如鞋子的断根、断底、断面，家用电器的不转、线路问题等。</td>");
                base.Response.Write("</tr>");

                base.Response.Write("<tr>");

                base.Response.Write("<td  colspan=\"3\" style=\"background-color:#FFF;text-align:center;font-weight:bold;\">如需要进行退换货处理，请您务必保留这张发货单作为凭证。</td>");
                base.Response.Write("</tr>");

                base.Response.Write("<tr>");

                base.Response.Write("<td colspan=\"3\" style=\"background-color:#FFF;text-align:center;font-weight:bold;\"> 商城网址：www.tj88.com 全国统一客服热线为：400-8777-181 请按照提示语音选择您所需要的服务。 </td>");
                base.Response.Write("</tr>");


                //base.Response.Write("<tr style=\"color:#FFF;font-weight:bold; text-align:center\">");
                //base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >审查</td>");
                //base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >经办人</td>");
                //base.Response.Write("</tr>");
                //base.Response.Write("<tr>");
                //base.Response.Write("<td  style=\"background-color:#FFF;text-align:center\" ></td>");
                //base.Response.Write("<td  style=\"background-color:#FFF;text-align:center\" ></td>");
                //base.Response.Write("</tr>");

                //base.Response.Write("</table>");
                for (int i = 0; i < 37 - 10 - table.Rows.Count; i++)
                {
                    base.Response.Write("<tr style=\"color:#FFF;font-weight:bold; text-align:center\">");

                    base.Response.Write("<td  style=\"background-color:#FFF;text-align:center\" ></td>");
                    base.Response.Write("<td  style=\"background-color:#FFF;text-align:center\" ></td>");
                    base.Response.Write("<td  style=\"background-color:#FFF;text-align:center\" ></td>");

                    base.Response.Write("</tr>");
                }
            }
           
            

           
        }

        private void ExportReport()
        {
            var action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
            string startdate = (Page.Request.QueryString["DispatchTime1"] == "")
                                   ? ""
                                   : Page.Request.QueryString["DispatchTime1"];
            string enddate = (Page.Request.QueryString["DispatchTime2"] == "")
                                 ? ""
                                 : Page.Request.QueryString["DispatchTime2"];
            string flag = Page.Request.QueryString["flag"];

            DataTable table = null;
            if (flag == "1")
            {
                table = action.SearchCusOrder(startdate, enddate);
                if ((table != null) && (table.Rows.Count > 0))
                {
                    base.Response.Write("<table width=\"100%\" border=\"1\" cellspacing=\"1\" cellpadding=\"0\" style=\"background-color:#999\">");

                    DataTable table2=new   DataTable();
                    table2 = table.Copy();
                    table2.Rows.Clear();
                    string num="";

                  
                        for (int i = 0; i <  table.Rows.Count; i++)
		             	{
                            if (i == 0)
                            {
                                DataRow row = table.Rows[0];
                                table2.ImportRow(row);
                                num = table.Rows[0]["number"].ToString();
                            }
                            else
                            {
                                if (table.Rows[i]["number"].ToString() == num)
                                {
                                   DataRow row = table.Rows[i];
                                   table2.ImportRow(row);
                                   num = table.Rows[i]["number"].ToString();
                                }
                                else
                                {
                                   
                                    exc(table2);
                                   
                                    table2.Rows.Clear();
                                    DataRow row = table.Rows[i];
                                    table2.ImportRow(row);
                                    num = table.Rows[i]["number"].ToString();
                            }
			               
                      }
		         	}
                        base.Response.Write("</table>"); 
                   
                  
  
                }
            }

            else
            {
                table = action.SeachStoreOrder(startdate, enddate);
                if ((table != null) && (table.Rows.Count > 0))
                {
                    if (flag == "2")
                    {

                        base.Response.Write("<table width=\"100%\" border=\"1\" cellspacing=\"1\" cellpadding=\"0\" style=\"background-color:#999\">");
                        base.Response.Write("<tr style=\"color:#FFF;font-weight:bold; text-align:center\">");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >商品名称</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >购买数量</td>");;
                        base.Response.Write("</tr>");
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            base.Response.Write("<tr>");
                            base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {ProductName}</td>".Replace("{ProductName}", table.Rows[i]["ProductName"].ToString()));
                            base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {BuyNumber}</td>".Replace("{BuyNumber}", table.Rows[i]["BuyNumber"].ToString()));
                            base.Response.Write("</tr>");
                        }
                        base.Response.Write("</table>");


                    }
                    else
                    {
                      
                      
                        table = action.SearchCusOrder(startdate, enddate);
                        if ((table != null) && (table.Rows.Count > 0))
                        {
                            base.Response.Write("<table width=\"100%\" border=\"1\" cellspacing=\"1\" cellpadding=\"0\" style=\"background-color:#999\">");

                            DataTable table2 = new DataTable();
                            table2 = table.Copy();
                            table2.Rows.Clear();
                            string num = "";


                            for (int i = 0; i < table.Rows.Count; i++)
                            {
                                if (i == 0)
                                {
                                    DataRow row = table.Rows[0];
                                    table2.ImportRow(row);
                                    num = table.Rows[0]["number"].ToString();
                                }
                                else
                                {
                                    if (table.Rows[i]["number"].ToString() == num)
                                    {
                                        DataRow row = table.Rows[i];
                                        table2.ImportRow(row);
                                        num = table.Rows[i]["number"].ToString();
                                    }
                                    else
                                    {

                                        exctwo(table2); 

                                        table2.Rows.Clear();
                                        DataRow row = table.Rows[i];
                                        table2.ImportRow(row);
                                        num = table.Rows[i]["number"].ToString();
                                    }

                                }
                            }
                            base.Response.Write("</table>");



                        }
                        
                        
                    }
                }
            }
           
                  

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack && ((Page.Request["DispatchTime1"] != null) && (Page.Request["DispatchTime2"] != null)))
            {
                base.Response.Clear();
                string str = base.Request.QueryString["Type"];
                if (str == "xls")
                {
                    base.Response.ContentType = "Application/ms-excel";
                    base.Response.ContentEncoding = Encoding.UTF8;
                }
                else
                {
                    base.Response.ContentEncoding = Encoding.GetEncoding("gb2312");
                }
                base.Response.AppendHeader("Content-Disposition", "attachment;filename=\"storeOrderReport_" + DateTime.Now.ToString("yyyymmddhhmm") + "." + str + "\"");
                ExportReport();
                base.Response.Flush();
                base.Response.Close();
                base.Response.End();
            }
        }
    }
}