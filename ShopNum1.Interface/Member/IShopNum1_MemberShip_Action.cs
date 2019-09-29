using System;
using System.Collections.Generic;
using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
	public interface IShopNum1_MemberShip_Action
	{
        int DeleteMemberShipOfMemLoginID(string MemberLoginID);
        int Add(ShopNum1_MemberShip membership);
        DataTable SearchShipMem(string memLoginID);
        object SearchHaveShip(string memLoginID, int Shipstatu);
        DataTable SearchShip(int Shipstatu);
        DataTable SearchShipMemLoginNO(string MemLoginID, int shipStatu);
        int Delete(string MembershipID);
        DataTable SearchShipID(string ShipID);
	    int UpdatePassStatus(string ShipID, DateTime ExamineTime);
        int UpdateRefuseStatus(string ShipID);
	    DataTable SearchShipAdress(string Province, string City, string District);

        int UpdateUpgradetwo(string LastRank, string NewRank, string LicenseImage, string OrganizationImage, string RegistrationImage, string ShopImageone, string ShopImagetwo, string OpeningImage, string IdentityCardImage, string memLoginID);

	    int DeleteShipAdress(string MemberLoginID);
	    DataTable SearchShipRepeatMemLoginID(string MemLoginID, int shipStatu);

	}
}
