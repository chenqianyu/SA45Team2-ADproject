using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ReqListViewConverter
/// </summary>
public class ReqListViewConverter
{
    public ReqListViewConverter()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static WCFReqListView ChangeReqLvToWcfReqLv(ReqListView req)
    {

        return WCFReqListView.Make(req.RequisitionNumber,
                req.EmployeeName, req.EmployeeEmail, req.ApprovalStatus, req.Remarks,
                req.EmployeeID, req.DepartmentID);
    }

    public static List<WCFReqListView> ChangeReqlvListToWCFReqlvList(List<ReqListView> reqList)
    {

        List<WCFReqListView> wcfReqViewList = new List<WCFReqListView>();
        foreach (ReqListView req in reqList)
        {

            WCFReqListView wcfreq = WCFReqListView.Make(req.RequisitionNumber,
                req.EmployeeName, req.EmployeeEmail, req.ApprovalStatus, req.Remarks,
                req.EmployeeID, req.DepartmentID);
            wcfReqViewList.Add(wcfreq);
        }
        return wcfReqViewList;
    }
}