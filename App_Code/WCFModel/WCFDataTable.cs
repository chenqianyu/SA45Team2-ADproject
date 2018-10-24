using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for WCFDataTable
/// </summary>
public class WCFDataTable
{
    string itemNo;
    string itemDescription;
    string quantityToGiveOut;

    public static WCFDataTable Make(string itemNo, string itemDescription, string quantityToGiveOut)
    {
        WCFDataTable wcfDataTable = new WCFDataTable();
        wcfDataTable.ItemNo = itemNo;
        wcfDataTable.ItemDescription = itemDescription;
        wcfDataTable.QuantityToGiveOut = quantityToGiveOut;
        return wcfDataTable;
    }

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

    public string QuantityToGiveOut
    {
        get
        {
            return quantityToGiveOut;
        }

        set
        {
            quantityToGiveOut = value;
        }
    }

  
    
}