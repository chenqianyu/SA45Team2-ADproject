using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for WCFRequisitionItem
/// </summary>
public class WCFRequisitionItem
{
    int requisitionNo;
    string itemNo;
    int requestedQty;
    int actualQty;
    string status;


    public static WCFRequisitionItem Make(int requisitionNo,string itemNo, int requestedQty,
    int actualQty,string status)
    {
        WCFRequisitionItem wcfReqItem = new WCFRequisitionItem();
        wcfReqItem.RequisitionNo = requisitionNo;
        wcfReqItem.ItemNo = itemNo;
        wcfReqItem.RequestedQty = requestedQty;
        wcfReqItem.ActualQty = actualQty;
        wcfReqItem.Status = status;
        return wcfReqItem;
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

    public int ActualQty
    {
        get
        {
            return actualQty;
        }

        set
        {
            actualQty = value;
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

    public WCFRequisitionItem()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}