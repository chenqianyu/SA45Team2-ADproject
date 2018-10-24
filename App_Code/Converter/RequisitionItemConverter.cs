using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RequisitionItemConverter
/// </summary>
public class RequisitionItemConverter
{
    public RequisitionItemConverter()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static WCFRequisitionItem ChangeRequisitionItemToWCFRequisitionItem(RequisitionItem req)
    {
        return WCFRequisitionItem.Make(req.Requisition_No, req.Item_No, req.Requested_Qty,Convert.ToInt32( req.Actual_Qty), req.Status);
    }

    public static List<WCFRequisitionItem> ChangeReqItemListToWCFReqItemList(List<RequisitionItem> reqList)
    {

        List<WCFRequisitionItem> wcfReqList = new List<WCFRequisitionItem>();
        foreach (RequisitionItem req in reqList)
        {
            WCFRequisitionItem wcfReq= WCFRequisitionItem.Make(req.Requisition_No, req.Item_No, req.Requested_Qty, Convert.ToInt32(req.Actual_Qty), req.Status);
            wcfReqList.Add(wcfReq);
        }
        return wcfReqList;
    }

}