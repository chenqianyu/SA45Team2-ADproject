using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RequisitionDAO
/// </summary>
public class RequisitionDAO
{
    public RequisitionDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /*
     * Keoh's Codes Start
     */

    static string approved = Utility.Approved;
    static string rejected = Utility.Rejected;
    static string pending = Utility.Pending;
    static string fulfilled = Utility.Fulfilled;
    static string unFulfilled = Utility.UnFulfilled;
    static string cancelled = Utility.Cancel;

    /// <summary>
    /// Returns a list of current requisitions by department where the status is "Pending"
    /// </summary>
    /// <param name="deptID"></param>
    /// <returns></returns>
    public static List<ReqListView> ReqListByDept(string deptID)
    {
        Model entities = new Model();
        var x = from r in entities.Requisitions
                join e in entities.Employees on r.Employee_ID equals e.Employee_ID
                where e.Department_ID.Contains(deptID)
                where r.Status == pending
                orderby r.Submission_Timestamp
                select new ReqListView
                {
                    RequisitionNumber = r.Requisition_No,
                    EmployeeName = e.Employee_Name,
                    EmployeeEmail = e.Email,
                    ApprovalStatus = r.Status,
                    Remarks = r.Remarks,
                    EmployeeID = r.Employee_ID,
                    DepartmentID = e.Department_ID
                };
        return x.ToList();
    }

    /// <summary>
    /// returns ReqListView for requisition number selected to extract requester details
    /// </summary>
    /// <param name="requisitionNumber"></param>
    /// <returns></returns>
    public static ReqListView RequesterDetails(int requisitionNumber, string deptID)
    {
        Model entities = new Model();
        var x = from r in entities.Requisitions
                join e in entities.Employees on r.Employee_ID equals e.Employee_ID
                where r.Requisition_No == requisitionNumber
                where e.Department_ID.Contains(deptID)
                orderby r.Submission_Timestamp
                select new ReqListView
                {
                    RequisitionNumber = r.Requisition_No,
                    EmployeeName = e.Employee_Name,
                    EmployeeEmail = e.Email,
                    ApprovalStatus = r.Status,
                    Remarks = r.Remarks,
                    EmployeeID = r.Employee_ID,
                    DepartmentID = e.Department_ID
                };
        return x.FirstOrDefault();
    }

    /// <summary>
    /// Returns data to populate requisition details gridview
    /// </summary>
    /// <param name="requisitionNumber"></param>
    /// <returns></returns>
    public static List<ReqDetailsView> RequisitionDetails(int requisitionNumber, string deptID)
    {
        Model entities = new Model();
        var x = from ri in entities.RequisitionItems
                join ic in entities.ItemCatalogs on ri.Item_No equals ic.Item_No
                join r in entities.Requisitions on ri.Requisition_No equals r.Requisition_No
                join e in entities.Employees on r.Employee_ID equals e.Employee_ID
                where ri.Requisition_No == requisitionNumber
                where e.Department_ID == deptID
                orderby ri.Item_No
                select new ReqDetailsView
                {
                    RequisitionNumber = ri.Requisition_No,
                    ItemNumber = ri.Item_No,
                    ItemDescription = ic.Description,
                    RequestedQty = ri.Requested_Qty
                };
        return x.ToList();
    }

    /// <summary>
    /// Returns a list of all requisitions by department
    /// </summary>
    /// <param name="deptID"></param>
    /// <returns></returns>
    public static List<ReqListView> AllPastReqList(string deptID)
    {
        Model entities = new Model();
        var x = from r in entities.Requisitions
                join e in entities.Employees on r.Employee_ID equals e.Employee_ID
                where e.Department_ID.Contains(deptID)
                where r.Status != cancelled
                orderby r.Submission_Timestamp
                select new ReqListView
                {
                    RequisitionNumber = r.Requisition_No,
                    EmployeeName = e.Employee_Name,
                    EmployeeEmail = e.Email,
                    ApprovalStatus = r.Status,
                    Remarks = r.Remarks,
                    EmployeeID = r.Employee_ID,
                    DepartmentID = e.Department_ID
                };
        return x.ToList();
    }

    /// <summary>
    /// Returns  requisitions given the requisition number
    /// </summary>
    /// <param name="requisitionNumber"></param>
    /// <returns></returns>
    public static Requisition RequisitionByRequisitionNumber(int requisitionNumber)
    {
        Model entities = new Model();
        return entities.Requisitions.Where(x => x.Requisition_No == requisitionNumber).First();
    }

    /// <summary>
    /// Returns a list of requisition items given the requisition number
    /// </summary>
    /// <param name="requisitionNumber"></param>
    /// <returns></returns>
    public static List<RequisitionItem> RequisitionItemsByRequisitionNumber(int requisitionNumber)
    {
        Model entities = new Model();
        return entities.RequisitionItems.Where(x => x.Requisition_No == requisitionNumber).ToList();
    }

    /// <summary>
    /// returns a list of requisition items where the status is unfulfilled
    /// </summary>
    /// <returns></returns>
    public static List<RequisitionItem> UnfulfilledRequisitions()
    {
        Model entities = new Model();
        return entities.RequisitionItems.Where(x => x.Status == unFulfilled).ToList();
    }

    /// <summary>
    /// save changes made into database
    /// </summary>
    public static void SaveChanges()
    {
        Model entities = new Model();
        entities.SaveChanges();
    }
    /*
     * Keoh's Codes ends
     */

    /*
     * HanSu's Codes starts
     */


    public static List<Requisition> RetrieveRequisitionByDateWithAll(DateTime startDate, DateTime endDate)
    {
        Model entities = new Model();
        return entities.Requisitions.Where(m => (m.Status == Utility.Approved || m.Status == Utility.Completed ) && m.Approval_Timestamp >= startDate && m.Approval_Timestamp <= endDate).ToList<Requisition>();
    }

    public static List<Requisition> RetrieveApprovedRequisitionByDate(DateTime startDate, DateTime endDate)
    {
        Model entities = new Model();
        return entities.Requisitions.Where(m => (m.Status == Utility.Approved) && m.Approval_Timestamp >= startDate && m.Approval_Timestamp <= endDate).ToList<Requisition>();
    }

    public static Requisition GetRequisitionByRequisitionNumber(int requisitionNumber)
    {
        Model entities = new Model();
        return entities.Requisitions.Where(x => x.Requisition_No == requisitionNumber).ToList().First();
    }
    /*
     * HanSu's Codes ends
     */

    /*
   * Urmila's Codes Start
   */










    public static Requisition RetrieveMaxReqNo()
    {
        Model entities = new Model();
        return entities.Requisitions.OrderByDescending(x => x.Requisition_No).First();

    }

    public static int GetCountByReqNo()
    {
        Model entities = new Model();
        return entities.Requisitions.Select(x => new { x.Requisition_No }).Count();

    }

    public static void AddRequisition(Requisition req)
    {
        Model entities = new Model();
        entities.Requisitions.Add(req);
        entities.SaveChanges();

    }

    public static void AddRequisitionItems(List<ItemCatalog> b, int reqno)

    {
        Model entities = new Model();
        foreach (ItemCatalog c in b)
        {
            RequisitionItem reqItems = new RequisitionItem();
            reqItems.Requisition_No = reqno;
            reqItems.Item_No = c.Item_No.ToString();
            reqItems.Requested_Qty = c.Allocated_Qty;
            reqItems.Actual_Qty = 0;
            reqItems.Status = Utility.UnFulfilled;
            entities.RequisitionItems.Add(reqItems);
            entities.SaveChanges();
        }
    }

    public static List<Requisition> GetRequisitionByEmpID(int EmployeeNumber)
    {
        Model entities = new Model();
        return entities.Requisitions.Where(x => x.Employee_ID == EmployeeNumber && x.Status != Utility.Cancel).OrderByDescending(x => x.Submission_Timestamp).ToList();
    }

    public static void CancelRequisition(int reqNo)
    {
        Model entities = new Model();
        Requisition req = entities.Requisitions.Where(x => x.Requisition_No == reqNo).First();
        req.Status = Utility.Cancel;
        entities.SaveChanges();
    }

    public static void DeleteRequisitionItem(int reqNo)
    {
        Model entities = new Model();
        List<RequisitionItem> reqItems = entities.RequisitionItems.Where(x => x.Requisition_No == reqNo).ToList();
        foreach (RequisitionItem r in reqItems)
        {
            entities.RequisitionItems.Remove(r);

        }
        entities.SaveChanges();

    }

    public static List<RequisitionRequest> GetRequisitionRequestByReqNo(int reqNo)
    {
        Model entities = new Model();
        return entities.RequisitionRequests.Where(x => x.Requisition_No == reqNo).ToList();
    }



    public static void UpdateRequisitionItemsByReqNoAndItemNo(string itemNo, int reqno, int q)
    {
        Model entities = new Model();
        RequisitionItem req = entities.RequisitionItems.Where(x => x.Item_No == itemNo && x.Requisition_No == reqno).First();
        req.Requested_Qty = q;

        entities.SaveChanges();

    }

    public static void DeleteRequisitionItemsByReqNoAndItemNo(string itemNo, int reqno)
    {
        Model entities = new Model();
        RequisitionItem req = entities.RequisitionItems.Where(x => x.Item_No == itemNo && x.Requisition_No == reqno).First();
        entities.RequisitionItems.Remove(req);
        entities.SaveChanges();
    }
    /*
    * Urmila's Codes End
    */




    /*
     * 
* Balaji's Codes Start
*/
    public static RequisitionItem RetrieveRequisitionItemsByReqNoAndItemNo(int reqno, string itemno)
    {
        Model entities = new Model();
        return entities.RequisitionItems.Where(x => x.Requisition_No == reqno && x.Item_No == itemno).First();

    }

    /*
    * Balaji's Codes Ends
    */

}

