using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RetrievalController
/// </summary>
public class RetrievalController
{
    RequisitionDAO reqDAO = new RequisitionDAO();
    RetrievalDAO retDAO = new RetrievalDAO();
    ItemCatalogDAO icDAO = new ItemCatalogDAO();
    Utility utility = new Utility();
    AdjustmentDAO adjDAO = new AdjustmentDAO();
    DisbursementViewDAO disViewDAO = new DisbursementViewDAO();

    public RetrievalController()
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

    /// <summary>
    /// Check all past unfulfilled requisition against inventory level, add to retrieval items if there are available quantity in the storage. To be called after Delivery Order is acknowledged.
    /// </summary>
    public static void AddRetrievalItemForUnfulfilled()
    {
        List<RequisitionItem> allApprovedRequisitionItems = RequisitionDAO.UnfulfilledRequisitions();
        List<RetrievalItem> retrievalList = new List<RetrievalItem>();
        List<ItemCatalog> allItem = ItemCatalogDAO.RetrieveItemCatalogsList();

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
        for (int i = 0; i < retrievalList.Count; i++)
        {
            ReqListView requesterDetail = RequisitionDAO.RequesterDetails(retrievalList[i].Requisition_No, "");
            string recipientName = requesterDetail.EmployeeName;
            string recipientMail = requesterDetail.EmployeeEmail;
            List<RetrievalItem> requisitionList = RetrievalDAO.ListItemByRequisitionNumber(retrievalList[i].Requisition_No);
            DataTable dt = Utility.toDataTable(retrievalList);
            string htmlTable = Utility.toHTML_Table(dt);

            SendMailNotify(recipientMail, recipientName, htmlTable);
        }
        RequisitionDAO.SaveChanges();
        ItemCatalogDAO.SaveChanges();
        RetrievalDAO.AddToList(retrievalList);
       RetrievalDAO.SaveChanges();
    }

    /// <summary>
    /// mail to notify past requisitions fulfillment
    /// </summary>
    /// <param name="emailAddress"></param>
    /// <param name="recipientName"></param>
    /// <param name="htmlTable"></param>
    private static void SendMailNotify(string emailAddress, string recipientName, string htmlTable)
    {
        SendMail s = new SendMail();
        string message = "<div>Dear " + recipientName + ",<br \\><br \\>" +
            "The stationery inventory has just been replenished. Please find the stationery that you will receive on the next disbursement.<br \\><br \\>"
            + htmlTable + "<br \\><br \\>"
               + "Best Regards,<br \\>"
            + "Logic University Stationery Team<//div>";
        string subject = "Requisition Update";
        s.Send(message, subject, emailAddress);
    }

    /*
     * Keoh's code ends
     */

    /*
     * Balaji's code starts
     */
    public static int RetrieveMaxID()
    {
        int a = RetrievalDAO.GetMaxRetrieval();
        return a;
    }

    public static void UpdateRetrieval(int retid)
    {
        RetrievalDAO.UpdateRetrieval(retid);
    }
    public static void AddNewRetrieval(int retid)
    {
        RetrievalDAO.AddNewRetrieval(retid);
    }

    public static List<DisbursementViewDTO> GetDisbursementViewByRetrievalID(int rtr)
    {
        return DisbursementViewDAO.GetDisbursementViewByRetrievalID(rtr);
    }

    public static List<DisbursementViewDTO> GetDisbursementViewByRetrievalIDAndItemNo(int rtr, string itemno)
    {
        return DisbursementViewDAO.GetDisbursementViewByRetrievalIDAndItemNo(rtr, itemno);
    }

    public static List<DisbursementViewDTO> getlist3(int rtr)
    {
        return DisbursementViewDAO.list3(rtr);
    }

    public static void ReduceAllocatedQuantity(string itemno, int adjustment)
    {
        RetrievalDAO.ReduceAllocatedQuantity(itemno, adjustment);
    }

    public static void IncreaseAllocatedQuantity(string itemno, int adjustment)
    {
        RetrievalDAO.IncreaseAllocatedQuantity(itemno, adjustment);
    }

    public static List<int> GetRequisitionNoByItemNoAndRetrievalID(string itemno, int rtrid)
    {
        return DisbursementViewDAO.GetRequisitionNoByItemNoAndRetrievalID(itemno, rtrid);
    }

    public static List<int> GetRetrievalIDListLessThanMaxRetrievalId(int maxrtr)
    {
        return RetrievalDAO.GetRetrievalIDListLessThanMaxRetrievalId(maxrtr);
    }

    public static void AddAdjustment(string itemNo, int empID, DateTime raisedDate, string remarks, int qty)
    {
        Adjustment ad = new Adjustment();
        ad.Item_No = itemNo;
        ad.Employee_ID = empID;
        ad.Raised_Date = raisedDate;
        ad.Remarks = remarks;
        ad.Quantity = qty;
        AdjustmentDAO.AddAdjustment(ad);
       
        if (qty < 0)
        {
            decimal price = RetrievalDAO.GetPriceByItemNO(itemNo);
            decimal totprice = price * Math.Abs(qty);

            // AdjustmentController.adjMailSend(totprice); Balaji to adjust
        }
        else
        {

            AdjustmentController.adjMailSend2(itemNo);
        }
    }

    public static void ReduceItemTotalQty(List<DisbursementViewDTO> conflist)
    {
        foreach (DisbursementViewDTO vc in conflist)
        {
            string itemno = vc.item_Code;
            RetrievalDAO.ReduceItemTotalQty(itemno);
        }
    }
    public static void Reduceretrieval(List<int> reqnos, int adjustment, string itemno, int maxrtrid)
    {
        int adjustment1 = adjustment;
        Boolean check = false;
        foreach (int i in reqnos)
        {
            SA45Team02_SSIS.RetrievalItem ri = RetrievalDAO.GetMaxRetrievalByReqNoAndItemNo(i, itemno, maxrtrid);
           RequisitionItem reqi = RequisitionDAO.RetrieveRequisitionItemsByReqNoAndItemNo(i, itemno);
            if (ri.QuantityToGiveOut > adjustment1)
            {
                ri.QuantityToGiveOut = ri.QuantityToGiveOut - adjustment1;
                reqi.Actual_Qty = reqi.Actual_Qty - adjustment1;
                if (reqi.Actual_Qty != reqi.Requested_Qty)
                {
                    reqi.Status = "Unfulfilled";
                }
                adjustment1 = 0;
                check = true;
            }
            else
            {

                reqi.Actual_Qty = reqi.Actual_Qty - adjustment1;
                if (reqi.Actual_Qty != reqi.Requested_Qty)
                {
                    reqi.Status = "Unfulfilled";
                }
                if (reqi.Actual_Qty < 0)
                {
                    reqi.Actual_Qty = 0;
                }
                adjustment1 = adjustment1 - ri.QuantityToGiveOut;
                ri.QuantityToGiveOut = 0;
            }

            RetrievalDAO.SaveChanges(reqi, ri, i, itemno, maxrtrid);
            if (check == true)
            {
                break;
            }
        }
    }



    public static void IncreaseRetrieval(List<int> reqnos, int adjustment, string itemno, int maxrtrid)
    {
        int adjustment1 = adjustment;
        Boolean check = false;
        foreach (int i in reqnos)
        {
            SA45Team02_SSIS.RetrievalItem ri = RetrievalDAO.GetMaxRetrievalByReqNoAndItemNo(i, itemno, maxrtrid);
            SA45Team02_SSIS.RequisitionItem reqi = RequisitionDAO.RetrieveRequisitionItemsByReqNoAndItemNo(i, itemno);
            if (reqi.Requested_Qty == reqi.Actual_Qty)
            {
                continue;
            }
            else
            {
                int bal = (int)(reqi.Requested_Qty - reqi.Actual_Qty);
                if (bal > adjustment1 || bal == adjustment1)
                {
                    reqi.Actual_Qty = reqi.Actual_Qty + adjustment1;
                    ri.QuantityToGiveOut = ri.QuantityToGiveOut + adjustment1;
                    if (ri.QuantityToGiveOut > reqi.Requested_Qty)
                    {
                        ri.QuantityToGiveOut = reqi.Requested_Qty;
                    }
                    if (reqi.Actual_Qty == reqi.Requested_Qty)
                    {
                        reqi.Status = "Fulfilled";
                    }
                    adjustment1 = 0;
                    check = true;
                }
                else
                {

                    reqi.Actual_Qty = reqi.Actual_Qty + bal;
                    if (reqi.Actual_Qty == reqi.Requested_Qty)
                    {
                        reqi.Status = "Fulfilled";
                    }
                    adjustment1 = adjustment1 - bal;
                    if (adjustment1 <= 0)
                    {
                        adjustment1 = 0;

                    }
                    ri.QuantityToGiveOut = ri.QuantityToGiveOut + bal;
                }
            }

            RetrievalDAO.SaveChanges(reqi, ri, i, itemno, maxrtrid);
            if (check == true)
            {
                break;
            }
        }
    }
    /*
     * Balaji's code ends
     */
}