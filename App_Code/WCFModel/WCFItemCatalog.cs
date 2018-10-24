using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for WCFItemCatalog
/// </summary>
[DataContract]
public class WCFItemCatalog
{
    public static WCFItemCatalog Make(string item_No,
    string category,
    string description,
    int reorder_Lvl,
    int reorder_Qty,
    string unit_of_Measure,
    int total_Qty,
    decimal price,
    int allocated_Qty,
    int ordered_Qty)
    {
        WCFItemCatalog c = new WCFItemCatalog();
        c.Item_No = item_No;
        c.Category = category;
        c.Description = description;
        c.Reorder_Lvl = reorder_Lvl;
        c.Reorder_Qty = reorder_Qty;
        c.Unit_of_Measure = unit_of_Measure;
        c.Total_Qty = total_Qty;
        c.Price = price;
        c.Allocated_Qty = allocated_Qty;
        c.Ordered_Qty = ordered_Qty;
        return c;
    }

    string item_No;
    string category;
    string description;
    int reorder_Lvl;
    int reorder_Qty;
    string unit_of_Measure;
    int total_Qty;
    decimal price;
    int allocated_Qty;
    int ordered_Qty;

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
    public string Category
    {
        get
        {
            return category;
        }

        set
        {
            category = value;
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
    public int Reorder_Lvl
    {
        get
        {
            return reorder_Lvl;
        }

        set
        {
            reorder_Lvl = value;
        }
    }

    [DataMember]
    public int Reorder_Qty
    {
        get
        {
            return reorder_Qty;
        }

        set
        {
            reorder_Qty = value;
        }
    }

    [DataMember]
    public string Unit_of_Measure
    {
        get
        {
            return unit_of_Measure;
        }

        set
        {
            unit_of_Measure = value;
        }
    }

    [DataMember]
    public int Total_Qty
    {
        get
        {
            return total_Qty;
        }

        set
        {
            total_Qty = value;
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
    public int Allocated_Qty
    {
        get
        {
            return allocated_Qty;
        }

        set
        {
            allocated_Qty = value;
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
}