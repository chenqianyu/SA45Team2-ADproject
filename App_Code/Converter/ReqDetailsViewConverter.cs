using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ReqDetailsViewConverter
/// </summary>
public class ReqDetailsViewConverter
{
    public ReqDetailsViewConverter()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static WCFReqDetailsView ChangeReqDetailsViewToWCFReqDetailsView(ReqDetailsView req)
    {
        return WCFReqDetailsView.Make(req.RequisitionNumber, req.ItemNumber, req.RequestedQty, req.ItemDescription);

    }


    public static List<WCFReqDetailsView> ChangeReqDVListToWCFReqDVList(List<ReqDetailsView> reqList)
    {

        List<WCFReqDetailsView> wcfReqViewList = new List<WCFReqDetailsView>();
        foreach (ReqDetailsView req in reqList)
        {

            WCFReqDetailsView wcfreq = WCFReqDetailsView.Make(req.RequisitionNumber, req.ItemNumber, req.RequestedQty, req.ItemDescription);
        }
        return wcfReqViewList;
    }
}