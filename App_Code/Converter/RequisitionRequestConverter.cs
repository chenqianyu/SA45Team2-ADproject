using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RequisitionRequestConverter
/// </summary>
public class RequisitionRequestConverter
{
    public RequisitionRequestConverter()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static List<WCFRequisitionRequest> ChangeReqRequestListToWCFReqRequestList(List<RequisitionRequest> reqList)
    {

        List<WCFRequisitionRequest> wcfReqList = new List<WCFRequisitionRequest>();
        foreach (RequisitionRequest r in reqList)
        {

            WCFRequisitionRequest wcfReq = WCFRequisitionRequest.Make(r.Description, r.Requisition_No, r.Item_No, r.Requested_Qty, r.Status);
            wcfReqList.Add(wcfReq);
        }
        return wcfReqList;
    }

}