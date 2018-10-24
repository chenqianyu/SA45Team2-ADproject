using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for WCFOrderDetailsView
/// </summary>
[DataContract]
public class WCFOrderDetailsView
{
    public static WCFOrderDetailsView Make(string item_No,
    string description,
    decimal price,
    string supplier_Name,
    int ordered_Qty,
    int pO_No)
    {
        WCFOrderDetailsView c = new WCFOrderDetailsView();
        c.Item_No = item_No;
        c.Description = description;
        c.Price = price;
        c.Supplier_Name = supplier_Name;
        c.Ordered_Qty = ordered_Qty;
        c.PO_No = pO_No;
        return c;
    }
    string item_No;
    string description;
    decimal price;
    string supplier_Name;
    int ordered_Qty;
    int pO_No;

    [DataMember]
    public string Item_No
    {
        get
        {
            return item_No;
        }

        set
        {
            item_No = value;
        }
    }

    [DataMember]
    public string Description
    {
        get
        {
            return description;
        }

        set
        {
            description = value;
        }
    }

    [DataMember]
    public decimal Price
    {
        get
        {
            return price;
        }

        set
        {
            price = value;
        }
    }

    [DataMember]
    public string Supplier_Name
    {
        get
        {
            return supplier_Name;
        }

        set
        {
            supplier_Name = value;
        }
    }

    [DataMember]
    public int Ordered_Qty
    {
        get
        {
            return ordered_Qty;
        }

        set
        {
            ordered_Qty = value;
        }
    }

    [DataMember]
    public int PO_No
    {
        get
        {
            return pO_No;
        }

        set
        {
            pO_No = value;
        }
    }
}