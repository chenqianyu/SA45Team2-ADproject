using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RequisitionController
/// </summary>
public class RequisitionController
{

    //DAOs
    RequisitionDAO reqDAO = new RequisitionDAO();
    ItemCatalogDAO icDAO = new ItemCatalogDAO();
    RetrievalDAO retDAO = new RetrievalDAO();
    Utility utility = new Utility();
    DepartmentDAO depDAO = new DepartmentDAO();
    EmployeeDAO empDAO = new EmployeeDAO();


    public RequisitionController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /*
    * Keoh's code starts
    */



    //status strings
    static string approved = Utility.Approved;
    static string rejected = Utility.Rejected;
    static string pending = Utility.Pending;
    static string fulfilled = Utility.Fulfilled;
    static string unFulfilled = Utility.UnFulfilled;
    static string yetToDisburse = Utility.YetToDisburse;
    static string completed = Utility.Completed;

    static string deptID;
    static public string DeptID
    {
        get { return deptID; }
        set { deptID = value; }
    }

    /// <summary>
    /// Returns a list of current requisitions by department where the status is "Pending"
    /// </summary>
    public static List<ReqListView> ReqListByDept
    {
        get { return RequisitionDAO.ReqListByDept(deptID); }
    }

    /// <summary>
    /// Returns a list of all requisitions by department
    /// </summary>
    public static List<ReqListView> AllReqListByDept
    {
        get { return RequisitionDAO.AllPastReqList(deptID); }
    }

    /// <summary>
    /// Returns a list of requisition details in ReqDetailsView class based on requisition number
    /// </summary>
    /// <param name="requisitionNumber"></param>
    /// <returns></returns>
    public static List<ReqDetailsView> RequisitionDetails(int requisitionNumber, string deptID)
    {
        return RequisitionDAO.RequisitionDetails(requisitionNumber, deptID);
    }

    /// <summary>
    /// Takes in a list of ReqListView, extracts the Requisition Number, and approves the Requisitions
    /// </summary>
    /// <param name="approvedList"></param>
    public static void ApproveRequisitions(List<ReqListView> approvedList)
    {
        List<Requisition> allApprovedRequisitionList = new List<Requisition>();
        List<RequisitionItem> allApprovedRequisitionItems = new List<RequisitionItem>();
        List<ItemCatalog> allItem = ItemCatalogDAO.RetrieveItemCatalogsList();
        List<RetrievalItem> retrievalList = new List<RetrievalItem>();


        //add all approved requisition items to list
        //add all approved requisitions to list
        foreach (ReqListView rlv in approvedList)
        {
            allApprovedRequisitionItems.AddRange(RequisitionDAO.RequisitionItemsByRequisitionNumber(rlv.RequisitionNumber));
            allApprovedRequisitionList.Add(RequisitionDAO.RequisitionByRequisitionNumber(rlv.RequisitionNumber));
        }

        //update approved requisitions' status, remarks, and date of approval
        for (int i = 0; i < allApprovedRequisitionList.Count; i++)
        {
            allApprovedRequisitionList[i].Status = approved;
            allApprovedRequisitionList[i].Remarks = approvedList[i].Remarks;
            allApprovedRequisitionList[i].Approval_Timestamp = DateTime.Now;
        }

        //add a list of retrieval items from approved requisition item, provided there is stock in inventory
        foreach (RequisitionItem ri in allApprovedRequisitionItems)
        {
            ItemCatalog q = allItem.FirstOrDefault(x => x.Item_No == ri.Item_No);

            //if cannot even fulfill partially, do not add to list
            bool addToList = true;

            //Initialize retrieval item values
            RetrievalItem rti = new RetrievalItem();
            rti.Retrieval_ID = RetrievalDAO.GetLatestRetrievalNumber();
            rti.Disbursement_Status = yetToDisburse;
            rti.Item_No = ri.Item_No;
            rti.Requisition_No = ri.Requisition_No;

            //if total available quantity more than quantity need to fulfill
            if ((q.Total_Qty - q.Allocated_Qty) > (ri.Requested_Qty - (int)ri.Actual_Qty))
            {
                //Retrieval Item
                rti.QuantityToGiveOut = ri.Requested_Qty;                           //Give out the quantity requested because available

                //Requisition Item
                ri.Actual_Qty += rti.QuantityToGiveOut;                             //Actual Quantity on requisition form updated to total number requested
                ri.Status = fulfilled;                                              //Status of requisition updated to fulfilled

                //Inventory
                q.Allocated_Qty += rti.QuantityToGiveOut;                           //Allocated quantity for item to be reflected

            }
            else if (q.Total_Qty - q.Allocated_Qty == 0)                            //Do not add to list if cannot give out anything
            {
                addToList = false;
            }
            else                                                                    //If only can fulfill partially
            {
                //Retrieval Item
                rti.QuantityToGiveOut = (q.Total_Qty - q.Allocated_Qty);            //Give out whatever is left

                //Requisition Item
                ri.Actual_Qty += rti.QuantityToGiveOut;                             //Add the quantity given out to whatever is requested

                //Inventory
                q.Allocated_Qty += rti.QuantityToGiveOut;
            }

            if (addToList)
            {
                retrievalList.Add(rti);
            }


        }

        //send email to notify requester of his status
        for (int i = 0; i < allApprovedRequisitionList.Count; i++)
        {
            ReqListView requesterDetail = RequisitionDAO.RequesterDetails(allApprovedRequisitionList[i].Requisition_No, deptID);
            string recipientName = requesterDetail.EmployeeName;
            string recipientMail = requesterDetail.EmployeeEmail;
            List<RetrievalItem> requisitionList = RetrievalDAO.ListItemByRequisitionNumber(allApprovedRequisitionList[i].Requisition_No);
            DataTable dt = Utility.toDataTable(retrievalList);
            string htmlTable = Utility.toHTML_Table(dt);

            SendMailApprove(recipientMail, recipientName, htmlTable);
        }

        RetrievalDAO.AddToList(retrievalList);
        RetrievalDAO.SaveChanges();
        RequisitionDAO.SaveChanges();
        ItemCatalogDAO.SaveChanges();

    }

    /// <summary>
    /// Rejects all selected requisitions
    /// </summary>
    /// <param name="rejectedList"></param>
    public static void RejectRequisitions(List<ReqListView> rejectedList)
    {

        foreach (ReqListView rejectedRequisition in rejectedList)
        {
            int requisitionNumber = rejectedRequisition.RequisitionNumber;
            List<RequisitionItem> lri = RequisitionDAO.RequisitionItemsByRequisitionNumber(requisitionNumber);
            foreach (RequisitionItem ri in lri)
            {
                ri.Status = rejected; //code to check itemcatalog quantity
            }

            Requisition r = RequisitionDAO.RequisitionByRequisitionNumber(requisitionNumber);
            r.Status = rejected;
            r.Remarks = rejectedRequisition.Remarks;
            SendMailReject(rejectedRequisition.EmployeeEmail, rejectedRequisition.EmployeeName);
            RequisitionDAO.SaveChanges();
        }
    }

    /// <summary>
    /// Send notification to requester to notify requisition is rejected
    /// </summary>
    /// <param name="emailAddress"></param>
    /// <param name="recipientName"></param>
    private static void SendMailReject(string emailAddress, string recipientName)
    {
        SendMail s = new SendMail();
        string message = "Dear " + recipientName + ",<br \\><br \\>" +
            "Unfortunately, your requisition has been rejected. Please login to the system to view the details.<br \\><br \\>"
            + "Best Regards,<br \\>"
            + "Logic University Stationery Team";
        string subject = "Requisition Rejected";
        s.Send(message, subject, emailAddress);
    }

    /// <summary>
    /// Send notification to requester to notify that the requisition is approved, and the items on his requisition that he will receive.
    /// </summary>
    /// <param name="emailAddress"></param>
    /// <param name="recipientName"></param>
    /// <param name="htmlTable"></param>
    private static void SendMailApprove(string emailAddress, string recipientName, string htmlTable)
    {
        SendMail s = new SendMail();
        string message = "<div>Dear " + recipientName + ",<br \\><br \\>" +
            "Your requisition form has been approved. Please find the details of the stationery you will receive on the next disbursement.<br \\><br \\>"
            + htmlTable + "<br \\><br \\>"
               + "Best Regards,<br \\>"
            + "Logic University Stationery Team<//div>";
        string subject = "Requisition Approved";
        s.Send(message, subject, emailAddress);
    }

    /// <summary>
    /// returns the detail of the requester in ReqListView class based on requisition number
    /// </summary>
    /// <param name="requisitionNumber"></param>
    /// <returns></returns>
    public static ReqListView RequesterDetails(int requisitionNumber, string deptID)
    {
        return RequisitionDAO.RequesterDetails(requisitionNumber, deptID);
    }

    /// <summary>
    /// Returns requisition status of a requisition number
    /// </summary>
    /// <param name="requisitionNumber"></param>
    /// <returns></returns>
    public static string RequisitionStatus(int requisitionNumber)
    {
        return RequisitionDAO.RequisitionByRequisitionNumber(requisitionNumber).Status;
    }


    /*
     * Keoh's code ends
     */

    /*
    * Han Su's code starts
    */
    ////Han Su
    //public List<Requisition> retrieveAllRequisitionList()
    //{
    //    List<Requisition> allRList = reqDAO.retrieveAllRequisitionList();
    //    List<Requisition> toShow = new List<Requisition>();
    //    foreach (Requisition loop in allRList)
    //    {
    //        if (loop.Status == "Approved" || loop.Status == "Completed")
    //        {
    //            toShow.Add(loop);
    //        }            
    //    }
    //    return toShow;                       
    //}

    ////Han Su
    //public List<Requisition> retrieveApproveRequisitionList()
    //{
    //    List<Requisition> allRList = reqDAO.retrieveAllRequisitionList();
    //    List<Requisition> toShow = new List<Requisition>();
    //    foreach (Requisition loop in allRList)
    //    {
    //        if (loop.Status == "Approved")
    //        {
    //            toShow.Add(loop);
    //        }
    //    }
    //    return toShow;
    //}

    //Han Su
    public static Employee GetEmployee(int rid)
    {
        Requisition reqList = RequisitionDAO.GetRequisitionByRequisitionNumber(rid);
        Employee e = EmployeeDAO.GetEmployeeByEmpId(reqList.Employee_ID);
        return e;
    }

    //Han Su
    public static ItemCatalog GetItemByIemNo(string itemNo)
    {
        return ItemCatalogDAO.RetrieveItemCatalogByItemNo(itemNo);
    }
    //Han Su
    public static Department GetDepartment(Employee e)
    {
        return DepartmentDAO.GetDepartmentByEmployeeID(e);
    }
    //Han Su
    public static List<RequisitionItem> GetRequisitionItemsByReqID(int rqID)
    {
        return RequisitionDAO.RequisitionItemsByRequisitionNumber(rqID);
    }
    //Han Su
    public static List<Requisition> RetrieveRequisitionByDateWithAll(DateTime startDate, DateTime endDate)
    {
        return RequisitionDAO.RetrieveRequisitionByDateWithAll(startDate, endDate);
    }
    //Han Su
    public static List<Requisition> RetrieveApprovedRequisitionByDate(DateTime startDate, DateTime endDate)
    {
        return RequisitionDAO.RetrieveApprovedRequisitionByDate(startDate, endDate);
    }

    ////HanSu
    //public List<Requisition> retrieveUnfulfilledRequisitionByDate(DateTime startDate, DateTime endDate)
    //{
    //    return reqDAO.retrieveUnfulfilledRequisitionByDate(startDate, endDate);
    //}
    /*
     * Han Su's code ends
     */

    /*
    * Urmila's Codes Start
    */



    public static List<string> GetDistinctItemCatalogsByCategory()
    {
        return ItemCatalogDAO.GetDistinctItemCatalogsByCategory();

    }

    public static List<ItemCatalog> RetrieveItemCatalogsList()
    {
        return ItemCatalogDAO.RetrieveItemCatalogsList();
    }

    public static List<ItemCatalog> RetrieveItemCatalogByCategoryID(string categoryID)
    {
        return ItemCatalogDAO.RetrieveItemCatalogByCategoryID(categoryID);

    }

    public static ItemCatalog FindItemCatalogFromGivenListByItemNo(List<ItemCatalog> a, string b)
    {
        return ItemCatalogDAO.FindItemCatalogFromGivenListByItemNo(a, b);
    }

    public static Requisition RetrieveMaxReqNo()
    {
        return RequisitionDAO.RetrieveMaxReqNo();
    }

    public static int GetCountByReqNo()
    {
        return RequisitionDAO.GetCountByReqNo();
    }



    public static void AddRequisition(int reqno, int empId, DateTime d, string status)
    {


        Requisition req = new Requisition();
        req.Requisition_No = reqno;
        req.Employee_ID = empId;
        req.Status = status;
        req.Submission_Timestamp = d;
        RequisitionDAO.AddRequisition(req);
    }

    public static void AddRequisitionItems(List<SA45Team02_SSIS.ItemCatalog> b, int reqno)
    {
        RequisitionDAO.AddRequisitionItems(b, reqno);
    }

    public static List<Requisition> GetRequisitionByEmpID(int emp)
    {
        return RequisitionDAO.GetRequisitionByEmpID(emp);
    }

    public static void CancelRequisition(int reqNo)
    {
        RequisitionDAO.CancelRequisition(reqNo);
    }


    public static void DeleteRequisitionItem(int reqNo)
    {
        RequisitionDAO.DeleteRequisitionItem(reqNo);
    }

    public static List<RequisitionRequest> GetRequisitionRequestByReqNo(int reqNo)
    {
        return RequisitionDAO.GetRequisitionRequestByReqNo(reqNo);
    }

    public static void UpdateRequisitionItemsByReqNoAndItemNo(string itemNo, int reqno, int q)
    {
        RequisitionDAO.UpdateRequisitionItemsByReqNoAndItemNo(itemNo, reqno, q);
    }

    public static void DeleteRequisitionItemsByReqNoAndItemNo(string itemNo, int reqNo)
    {
        RequisitionDAO.DeleteRequisitionItemsByReqNoAndItemNo(itemNo, reqNo);
    }


    /*
    * Urmila's Codes End
    */
}