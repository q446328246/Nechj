﻿using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_SurveyOption_Action : IShopNum1_SurveyOption_Action
    {
        public int Add(ShopNum1_SurveyOption shopNum1_surveyoption)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "insert ShopNum1_SurveyOption(guid,surveyguid,name,count) values('",
                        shopNum1_surveyoption.Guid
                        , "',", shopNum1_surveyoption.SurveyGuid, ",'",
                        Operator.FilterString(shopNum1_surveyoption.Name), "','0')"
                    }));
        }

        public int Delete(string guids)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guids";
            parms[0].Value = guids;
            return DatabaseExcetue.RunNonQuery("delete from ShopNum1_SurveyOption where guid in (@guid)",parms);
        }

        public DataTable Search(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT Guid, Name, Count from ShopNum1_SurveyOption Where SurveyGuid= @guid ORDER BY Count DESC",parms);
        }
    }
}