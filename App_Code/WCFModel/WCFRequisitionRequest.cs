using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for WCFRequisitionRequest
/// </summary>
public class WCFRequisitionRequest
{
    string description;
    int requisitionNo;
    string itemNo;
    int requestedQty;
    string status;


    public static WCFRequisitionRequest Make(string description, int requisitionNo,
   string itemNo, int requestedQty, string status)
    {
        WCFRequisitionRequest req = new WCFRequisitionRequest();
        req.Description = description;
        req.RequisitionNo = requisitionNo;
        req.ItemNo = itemNo;
        req.RequestedQty = requestedQty;
        req.Status = status;
        return req;
    }


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

    public int RequisitionNo
    {
        get
        {
            return requisitionNo;
        }

        set
        {
            requisitionNo = value;
        }
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

    public string Status
    {
        get
        {
            return status;
        }

        set
        {
            status = value;
        }
    }

   



   
}