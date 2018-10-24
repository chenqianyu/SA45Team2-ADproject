using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AdjustmentController
/// </summary>
public class AdjustmentController
{
    //EmployeeDAO empDAO = new EmployeeDAO();
    //AdjustmentDAO adjDAO = new AdjustmentDAO();
    //ItemCatalogDAO icDAO = new ItemCatalogDAO();
    public AdjustmentController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /*
    * JW's code starts
    */

    /// <summary>
    /// To generate email to be sent to either Supervisor or Manager depending on the adjustment value
    /// </summary>
    /// <param name="value"></param>

    public static void AdjMailSend(decimal value, string submitter, string remarks)
    {
        if (value < 250m)
        {
            string supervisorName = EmployeeDAO.GetSupervisor().Employee_Name;
            string supervisorEmail = EmployeeDAO.GetSupervisor().Email;
            SendMail s = new SendMail();
            s.Send("<p>Dear " + supervisorName + ",</p><p> Please note a new item adjustment voucher of $" + value + " due to Remarks:[ " + remarks + " ] has been submitted by " + submitter + " for your acknowledgement.</p><p> Thank you.</p><p>**This is an automatically generated email, please do not reply **</p>", "New adjustment for your acknowledgement", supervisorEmail);
        }
        else
        {
            string managerName = EmployeeDAO.GetManager().Employee_Name;
            string managerEmail = EmployeeDAO.GetManager().Email;
            SendMail s = new SendMail();
            s.Send("<p>Dear " + managerName + ",</p><p> Please note a new item adjustment voucher of $" + value + " due to Remarks:[ " + remarks + " ] has been submitted by " + submitter + " for your acknowledgement.</p><p> Thank you.</p><p>**This is an automatically generated email, please do not reply **</p>", "New adjustment for your acknowledgement", managerEmail);
        }
    }

    public static void AdjMailSendCancel(decimal value, string name, string remarks)
    {
        if (value < 250m)
        {
            string supervisorName = EmployeeDAO.GetSupervisor().Employee_Name;
            string supervisorEmail = EmployeeDAO.GetSupervisor().Email;
            SendMail s = new SendMail();
            s.Send("<p>Dear " + supervisorName + ",</p><p> Please note previously submitted item adjustment voucher of $" + value + " due to Remarks:[ " + remarks + " ] has been withdrawn by " + name + ".</p><p> Thank you.</p><p>**This is an automatically generated email, please do not reply **</p>", "Withdrawal of Item Adjustment Voucher", supervisorEmail);
        }
        else
        {
            string managerName = EmployeeDAO.GetManager().Employee_Name;
            string managerEmail = EmployeeDAO.GetManager().Email;
            SendMail s = new SendMail();
            s.Send("<p>Dear " + managerName + ",</p><p> </p><p> Please note previously submitted item adjustment voucher of $" + value + " due to Remarks:[ " + remarks + " ] has been withdrawn by " + name + ".</p><p> Thank you.</p><p>**This is an automatically generated email, please do not reply **</p>", "Withdrawal of Item Adjustment Voucher", managerEmail);
        }
    }

    public static dynamic PendingAdjustmentsList(string role)
    {
        return AdjustmentDAO.PendingAdjustmentsList(role);
    }

    public static void AcknowledgeAdjustment(string itemNo, int empID, DateTime date, int acknowledgeID)
    {
        Adjustment adj = new Adjustment();
        adj.Acknowledged_By = acknowledgeID;
        adj.Raised_Date = date;
        AdjustmentDAO.AcknowledgeAdjustment(itemNo, empID,adj);
    }

    public static dynamic AcknowledgedAdjustmentsList()
    {
     

        return AdjustmentDAO.AcknowledgedAdjustmentsList();
    }

    public static List<ItemCatalog> RetrieveItemCatalogsList()
    {
        return ItemCatalogDAO.RetrieveItemCatalogsList();

    }

    public static void IncreaseInventory(ItemCatalog item, int addQty)
    {
        ItemCatalogDAO.IncreaseInventory(item, addQty);
    }


    public static void RemoveAdjustment(string itemNo, int empID, DateTime date)
    {
        AdjustmentDAO.RemoveAdjustment(itemNo, empID, date);
    }


   public static Employee GetEmployeeByEmpId(int empID)
    {
        return EmployeeDAO.GetEmployeeByEmpId(empID);
    }

    public static List<Adjustment> AdjustmentsPending(int empID)
    {
        return AdjustmentDAO.AdjustmentsPending(empID);
    }

    public static void AddAdjustment(string itemNo, int empID, DateTime raisedDate, string remarks, int qty)
    {
        Adjustment adj = new Adjustment();
        adj.Item_No = itemNo;
        adj.Employee_ID = empID;
        adj.Raised_Date = raisedDate;
        adj.Remarks = remarks;
        adj.Quantity = qty;

        AdjustmentDAO.AddAdjustment(adj);
    }

    public static  void DecreaseInventory(ItemCatalog item, int deductQty)
    {
        ItemCatalogDAO.DecreaseInventory(item, deductQty);
    }

    public static ItemCatalog RetrieveItemCatalogByItemNo(string itemNo)
    {

        return ItemCatalogDAO.RetrieveItemCatalogByItemNo(itemNo);

    }


    /*
    * JW's code ends
    */

    /*
* Balaji's code starts
*/
    public static void adjMailSend2(string itemno)
    {


        string supervisorName = EmployeeDAO.GetSupervisor().Employee_Name;
        string supervisorEmail = EmployeeDAO.GetSupervisor().Email;
        SendMail s = new SendMail();
        s.Send("<p>Dear " + supervisorName + ",</p><p> Please note a new item adjustment voucher has been updated to rectify the mistakes done in the previous voucher for the item " + itemno + ".</p><p> Thank you.</p><p>*This is an automatically generated email, please do not reply *</p>", "Rectification of adjustment", supervisorEmail);


    }
    /*
* Balaji's code ends
*/
}