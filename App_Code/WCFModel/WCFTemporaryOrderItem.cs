using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for WCFTemporaryOrderItem
/// </summary>
public class WCFTemporaryOrderItem
{
    public static WCFTemporaryOrderItem Make(string itemNo,string itemDescription,
    string supplierID, string supplierName, int qty,   string exceptedDeliveryDate,
    string remark)
    {
        WCFTemporaryOrderItem orderItem = new WCFTemporaryOrderItem();
        orderItem.ItemNo = itemNo;
        orderItem.ItemDescription = itemDescription;
        orderItem.SupplierID = supplierID;
        orderItem.SupplierName = supplierName;
        orderItem.Qty = qty;
        orderItem.ExceptedDeliveryDate = exceptedDeliveryDate;
        orderItem.Remark = remark;



        return orderItem;
    }


    string itemNo;
    string itemDescription;
    string supplierID;
    string supplierName;
    int qty;
    string exceptedDeliveryDate;
    string remark;

    public string ItemNo
    {
        get
        {
            return itemNo;
        }

        set
        {
            itemNo = value;
        }
    }

    public string ItemDescription
    {
        get
        {
            return itemDescription;
        }

        set
        {
            itemDescription = value;
        }
    }

    public string SupplierID
    {
        get
        {
            return supplierID;
        }

        set
        {
            supplierID = value;
        }
    }

    public string SupplierName
    {
        get
        {
            return supplierName;
        }

        set
        {
            supplierName = value;
        }
    }

    public int Qty
    {
        get
        {
            return qty;
        }

        set
        {
            qty = value;
        }
    }

    public string ExceptedDeliveryDate
    {
        get
        {
            return exceptedDeliveryDate;
        }

        set
        {
            exceptedDeliveryDate = value;
        }
    }

    public string Remark
    {
        get
        {
            return remark;
        }

        set
        {
            remark = value;
        }
    }

   
}