using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RequisitionConverter
/// </summary>
public class RequisitionConverter
{
    public RequisitionConverter()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static WCFRequisition ChangeReqToWcfReq(Requisition r)
    {

        return WCFRequisition.Make(r.Requisition_No, r.Employee_ID, Convert.ToString(r.Approval_Timestamp),
                r.Status, Convert.ToString(r.Submission_Timestamp), r.Remarks);
    }

    public static List<WCFRequisition> ChangeReqListToWCFReqList(List<Requisition> reqList)
    {

        List<WCFRequisition> wcfReqList = new List<WCFRequisition>();
        foreach (Requisition r in reqList)
        {

            WCFRequisition wcfreq = WCFRequisition.Make(r.Requisition_No, r.Employee_ID,Convert.ToString( r.Approval_Timestamp),
                r.Status,Convert.ToString( r.Submission_Timestamp), r.Remarks);



            wcfReqList.Add(wcfreq);
        }
        return wcfReqList;
    }
}