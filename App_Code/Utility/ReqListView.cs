using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Coding by Keoh
/// <summary>
/// Summary description for ReqListView
/// </summary>
public class ReqListView
{
    public int RequisitionNumber { get; set; }
    public string EmployeeName { get; set; }
    public string EmployeeEmail { get; set; }
    public string ApprovalStatus { get; set; }
    public string Remarks { get; set; }
    public int EmployeeID { get; set; }
    public string DepartmentID { get; set; }
    public ReqListView()
    {
        
    }
}