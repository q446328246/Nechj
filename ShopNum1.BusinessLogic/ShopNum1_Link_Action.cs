using System;
using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_Link_Action : IShopNum1_Link_Action
    {
        public DataTable CheckIsDuplication(string link)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@link";
            paraValue[0] = link;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_CheckIsDuplication", paraName, paraValue);
        }

        public DataTable GetLinkListImage(string showCount)
        {
            string strProcedureName = "[dbo].[Pro_ShopNum1_GetLinkListImage]";
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@showCount";
            paraValue[0] = showCount;
            return DatabaseExcetue.RunProcedureReturnDataTable(strProcedureName, paraName, paraValue);
        }

        int IShopNum1_Link_Action.Add(ShopNum1_Link Service_Link)
        {
            throw new NotImplementedException();
        }

        int IShopNum1_Link_Action.Delete(string guids)
        {
            throw new NotImplementedException();
        }

        DataTable IShopNum1_Link_Action.GetEditInfo(string guid)
        {
            throw new NotImplementedException();
        }

        DataTable IShopNum1_Link_Action.GetLink()
        {
            throw new NotImplementedException();
        }

        DataTable IShopNum1_Link_Action.Search(int isDeleted)
        {
            throw new NotImplementedException();
        }

        DataTable IShopNum1_Link_Action.Search(string name, int isShow)
        {
            throw new NotImplementedException();
        }

        int IShopNum1_Link_Action.Update(string guid, ShopNum1_Link Service_Link)
        {
            throw new NotImplementedException();
        }

        public int Add(ShopNum1_Link Service_Link)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "INSERT ShopNum1_Link(Guid,Name,ImgADD,Href,OrderID,ImgType,LinkType,Description,Memo,IsShow,CreateTime, CreateUser, ModifyUser, ModifyTime, IsDeleted ) values('"
                , Service_Link.Guid, "','", Operator.FilterString(Service_Link.Name), "','",
                Operator.FilterString(Service_Link.ImgADD), "','", Operator.FilterString(Service_Link.Href), "',",
                Service_Link.OrderID, ",'", Operator.FilterString(Service_Link.ImgType), "',", Service_Link.LinkType
                , ",'", Operator.FilterString(Service_Link.Description),
                "','", Operator.FilterString(Service_Link.Memo), "',", Service_Link.IsShow, ", '",
                Service_Link.CreateTime, "',  '", Operator.FilterString(Service_Link.CreateUser), "', '",
                Operator.FilterString(Service_Link.ModifyUser), "' , '", Service_Link.ModifyTime, "',  '",
                Service_Link.IsDeleted, "' )"
            }));
        }

        public int Delete(string guids)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guids";
            parms[0].Value = guids;

            return DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_Link WHERE Guid IN (@guids)",parms);
        }

        public DataTable GetEditInfo(string guid)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guids";
            parms[0].Value = guid;
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT  Name, ImgADD, Href, ImgType, OrderID, Description, Memo, LinkType,IsShow FROM ShopNum1_Link Where Guid=@guids",parms);
        }

        public DataTable GetLink()
        {
            string strProcedureName = "Pro_ShopNum1_GetLinkList";
            return DatabaseExcetue.RunProcedureReturnDataTable(strProcedureName);
        }

        public DataTable Search(int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@isDeleted";
            parms[0].Value = isDeleted;
            string str = string.Empty;
            str =
                "SELECT  Name, ImgADD, Href, ImgType, OrderID, Description, Memo, LinkType,IsDeleted,IsShow FROM ShopNum1_Link Where 0=0 and IsShow=1";
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                str = string.Concat(new object[] { str, " AND IsDeleted=@isDeleted" });
            }
            return DatabaseExcetue.ReturnDataTable(str + " ORDER BY OrderID DESC",parms);
        }

        public DataTable Search(string name, int isShow)
        {
            string str = string.Empty;
            str =
                "SELECT Guid, Name, ImgADD, Href, ImgType, OrderID, Description, Memo,CreateTime, LinkType,IsShow FROM ShopNum1_Link Where 0=0";
            if (Operator.FormatToEmpty(name) != string.Empty)
            {
                str = str + " AND Name LIKE '%" + Operator.FilterString(name) + "%'";
            }
            if (isShow != -1)
            {
                str = str + " AND IsShow=" + isShow;
            }
            return DatabaseExcetue.ReturnDataTable(str + " ORDER BY OrderID DESC");
        }

        public int Update(string guid, ShopNum1_Link Service_Link)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "update  ShopNum1_Link set Href='", Operator.FilterString(Service_Link.Href), "',ImgADD='",
                Operator.FilterString(Service_Link.ImgADD), "',Memo='", Operator.FilterString(Service_Link.Memo),
                "',[Name]='", Operator.FilterString(Service_Link.Name), "',OrderID=", Service_Link.OrderID,
                ",LinkType=", Service_Link.LinkType, ",ImgType=", Service_Link.ImgType, ",Description='",
                Operator.FilterString(Service_Link.Description),
                "',IsShow=", Service_Link.IsShow, " where Guid=", guid
            }));
        }
    }
}