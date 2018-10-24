using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Coding by Keoh
/// <summary>
/// Summary description for ReqDetailsView
/// </summary>
public class ReqDetailsView
{
    public int RequisitionNumber { get; set; }
    public string ItemNumber { get; set; }
    public int RequestedQty { get; set; }
    public string ItemDescription { get; set; }
    public ReqDetailsView()
    {
    }
}