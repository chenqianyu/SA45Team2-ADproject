using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for WCFReqDetailsView
/// </summary>
public class WCFReqDetailsView
{
    int requisitionNumber;
    string itemNumber;
    int requestedQty;
    string itemDescription;

    public static WCFReqDetailsView Make(int requisitionNumber,  string itemNumber,
    int requestedQty,  string itemDescription)
    {
        WCFReqDetailsView r= new WCFReqDetailsView();
        r.RequisitionNumber = requisitionNumber;
        r.ItemNumber = itemNumber;
        r.RequestedQty = requestedQty;
        r.ItemDescription = itemDescription;
        return r;
    }


    public int RequisitionNumber
    {
        get
        {
            return requisitionNumber;
        }

        set
        {
            requisitionNumber = value;
        }
    }

    public string ItemNumber
    {
        get
        {
            return itemNumber;
        }

        set
        {
            itemNumber = value;
        }
    }

    public int RequestedQty
    {
        get
        {
            return requestedQty;
        }

        set
        {
            requestedQty = value;
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
}