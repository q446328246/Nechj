using System;
using System.Data;
using System.Text;
using ShopNum1.DataAccess;

namespace ShopNum1.Second
{
    public class ShopNum1_SecondTypeAccess
    {
        public bool Add(ShopNum1_SecondType model)
        {
            var builder = new StringBuilder();
            builder.Append("insert into ShopNum1_SecondType(");
            builder.Append("TypeName,AppID,AppSecret,content,redirectURL,isAvabile,OrderID,Imgsrc)");
            builder.Append(" values (");
            builder.Append("@TypeName,@AppID,@AppSecret,@content,@redirectURL,@isAvabile,@OrderID,@Imgsrc)");
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@TypeName";
            paraName[1] = "@AppID";
            paraName[2] = "@AppSecret";
            paraName[3] = "@content";
            paraName[4] = "@redirectURL";
            paraName[5] = "@isAvabile";
            paraName[6] = "@OrderID";
            paraName[7] = "@Imgsrc";
            paraValue[0] = model.TypeName;
            paraValue[1] = model.AppID;
            paraValue[2] = model.AppSecret;
            paraValue[3] = model.content;
            paraValue[4] = model.redirectURL;
            paraValue[5] = model.isAvabile.ToString();
            paraValue[6] = model.OrderID.ToString();
            paraValue[7] = model.ImgSrc;
            return (DatabaseExcetue.RunNonQuery(builder.ToString(), paraName, paraValue) > 0);
        }

        public bool Delete(int ID)
        {
            var builder = new StringBuilder();
            builder.Append("delete from ShopNum1_SecondType ");
            builder.Append(" where ID=@ID ");
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@ID";
            paraValue[0] = ID.ToString();
            return (DatabaseExcetue.RunNonQuery(builder.ToString(), paraName, paraValue) > 0);
        }

        public bool Exists(int ID)
        {
            var builder = new StringBuilder();
            builder.Append("select count(1) from ShopNum1_SecondType");
            builder.Append(" where ID=@ID ");
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@ID";
            paraValue[0] = ID.ToString();
            return (Convert.ToInt32(DatabaseExcetue.ReturnObject(builder.ToString(), paraName, paraValue)) > 0);
        }

        public DataTable GetList(string strWhere)
        {
            var builder = new StringBuilder();
            builder.Append("select ID,TypeName,AppID,AppSecret,content,redirectURL,isAvabile,createTime,OrderID,Imgsrc ");
            builder.Append(" FROM ShopNum1_SecondType ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public int GetMaxOrderId()
        {
            return (DatabaseExcetue.ReturnMaxID("OrderID", "ShopNum1_SecondType") + 1);
        }

        public DataTable GetModel(int ID)
        {
            var builder = new StringBuilder();
            builder.Append(
                "select  top 1 ID,TypeName,AppID,AppSecret,content,redirectURL,isAvabile,createTime,OrderID,Imgsrc from ShopNum1_SecondType ");
            builder.Append(" where ID=@ID ");
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@ID";
            paraValue[0] = ID.ToString();
            return DatabaseExcetue.ReturnDataTable(builder.ToString(), paraName, paraValue);
        }

        public DataTable GetSecondByCount(string count, string isAvabile)
        {
            string format = string.Empty;
            format = "select  top ({0}) ID,TypeName,Imgsrc from ShopNum1_SecondType where isAvabile={1}";
            return DatabaseExcetue.ReturnDataTable(string.Format(format, count, isAvabile));
        }

        public bool Update(ShopNum1_SecondType model)
        {
            var builder = new StringBuilder();
            builder.Append("update ShopNum1_SecondType set ");
            builder.Append("TypeName=@TypeName,");
            builder.Append("AppID=@AppID,");
            builder.Append("AppSecret=@AppSecret,");
            builder.Append("content=@content,");
            builder.Append("redirectURL=@redirectURL,");
            builder.Append("isAvabile=@isAvabile,OrderID=@OrderID,ImgSrc=@ImgSrc");
            builder.Append(" where ID=@ID ");
            var paraName = new string[9];
            var paraValue = new string[9];
            paraName[0] = "@TypeName";
            paraName[1] = "@AppID";
            paraName[2] = "@AppSecret";
            paraName[3] = "@content";
            paraName[4] = "@redirectURL";
            paraName[5] = "@isAvabile";
            paraName[6] = "@ID";
            paraName[7] = "@OrderID";
            paraName[8] = "@ImgSrc";
            paraValue[0] = model.TypeName;
            paraValue[1] = model.AppID;
            paraValue[2] = model.AppSecret;
            paraValue[3] = model.content;
            paraValue[4] = model.redirectURL;
            paraValue[5] = model.isAvabile.ToString();
            paraValue[6] = model.ID.ToString();
            paraValue[7] = model.OrderID.ToString();
            paraValue[8] = model.ImgSrc;
            return (DatabaseExcetue.RunNonQuery(builder.ToString(), paraName, paraValue) > 0);
        }
    }
}