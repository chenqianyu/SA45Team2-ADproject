using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Coding by Thin Thinn
/// <summary>
/// Summary description for TemporaryOrderItem
/// </summary>
[Serializable]
public class TemporaryOrderItem
{
    public string itemNo;
    public string itemDescription;
    public string supplierID;
    public string supplierName;
    public int qty;
    public DateTime exceptedDeliveryDate;
    public string remark;

     
    public TemporaryOrderItem()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string ItemNo
    {
        get{
            return itemNo;
        }
        set{
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

    public DateTime ExceptedDeliveryDate
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