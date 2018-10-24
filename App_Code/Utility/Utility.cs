using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using SA45Team02_SSIS;
//Coding by Keoh
/// <summary>
/// Summary description for Utility
/// </summary>
public class Utility
{
    ItemCatalogDAO icDAO = new ItemCatalogDAO();
    static string approved = "Approved";
    static string rejected = "Rejected";
    static string pending = "Pending";
    static string fulfilled = "Fulfilled";
    static string unFulfilled = "Unfulfilled";
    static string yetToDisburse = "Yet to disburse";
    static string completed = "Completed";
    static string cancel = "Canceled";
    static string current = "Current";
    static string expired = "Expired";
    static string acknowledged = "Acknowledged";


    //Used by Thin Thinn
    //key for sessions
    //static string currentlyLoginUserName = "currentlyLoginUserName";
    //static string currentlyLoginUserRole = "currentlyLoginUserRole";
    //static string  currentlyLoginUserDepartment= "currentlyLoginUserDepartment";
    //static string currentlyLoginUserEmail = "currentlyLoginUserEmail";
    //static string currentlyLoginUserID= "currentlyLoginUserID";
    static string currentlyLoginUserInfo = "currentlyLoginUserInfo";
    static string tempPOList = "tempPOList";


    //Used by Thin Thinn
    //keys for viewState
    static string orderItemsList = "orderItemsList";

    //Used by Thin Thinn(Login)
    //keys for Employee Roles
    static string delegateRole = "Delegate";
    static string delegateDepartmentHead = "DelegateDepartmentHead";
    static string delegateSupervisor = "DelegateSupervisor";

    //Used by Thin Thinn(Login)
    //keys for Employee Roles
    static string departmentStore = "STORE";

    //Used by Thin Thinn(Login)
    //keys for login 
    static string loginSuccess = "SUCCESS";
    static string loginFailed = "FAILED";

    public static string Approved
    { get { return approved; } }
    public static string Rejected
    { get { return rejected; } }
    public static string Pending
    { get { return pending; } }
    public static string Fulfilled
    { get { return fulfilled; } }
    public static string UnFulfilled
    { get { return unFulfilled; } }
    public static string YetToDisburse
    { get { return yetToDisburse; } }
    public static string Completed
    { get { return completed; } }
    public static string Cancel
    { get { return cancel; } }
    public static string Current
    { get { return current; } }
    public static string Expired
    { get { return expired; } }
    public static string Acknowledged
    { get { return acknowledged; } }

    //Session
    //public static string CurrentlyLoginUserName
    //{ get { return currentlyLoginUserName; } }
    //public static string CurrentlyLoginUserRole
    //{ get { return currentlyLoginUserRole; } }
    //public static string CurrentlyLoginUserDepartment
    //{ get { return currentlyLoginUserDepartment; } }
    //public static string CurrentlyLoginUserEmail
    //{ get { return currentlyLoginUserEmail; } }
    //public static string CurrentlyLoginUserID
    //{ get { return currentlyLoginUserID; } }
    public static string TempPOList
    { get { return tempPOList; } }
    public static string CurrentlyLoginUserInfo
    { get { return currentlyLoginUserInfo; } }


    //ViewState
    public static string OrderItemsList
    { get { return orderItemsList; } }

    //Role
    public static string DelegateRole
    { get { return delegateRole; } }
    public static string DelegateDepartmentHead
    { get { return delegateDepartmentHead; } }
    public static string DelegateSupervisor
    { get { return delegateSupervisor; } }

    //DepartementId
    //Role
    public static string DepartmentStore
    { get { return departmentStore; } }

    //keys for login 
    public static string LoginSuccess
    { get { return loginSuccess; } }
    public static string LoginFailed
    { get { return loginFailed; } }


    public Utility()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary>
    /// Converts a DataTable item into a html table string
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static string toHTML_Table(DataTable dt)
    {
        if (dt.Rows.Count == 0) return ""; // enter code here

        StringBuilder builder = new StringBuilder();
        builder.Append("<html>");
        builder.Append("<head>");
        builder.Append("<title>");
        builder.Append("Page-");
        builder.Append(Guid.NewGuid());
        builder.Append("</title>");
        builder.Append("</head>");
        builder.Append("<body>");
        builder.Append("<table border='1px' cellpadding='5' cellspacing='0' ");
        builder.Append("style='border: solid 1px Silver; font-size: x-small;'>");
        builder.Append("<tr align='left' valign='top'>");
        foreach (DataColumn c in dt.Columns)
        {
            builder.Append("<td align='left' valign='top'><b>");
            builder.Append(c.ColumnName);
            builder.Append("</b></td>");
        }
        builder.Append("</tr>");
        foreach (DataRow r in dt.Rows)
        {
            builder.Append("<tr align='left' valign='top'>");
            foreach (DataColumn c in dt.Columns)
            {
                builder.Append("<td align='left' valign='top'>");
                builder.Append(r[c.ColumnName]);
                builder.Append("</td>");
            }
            builder.Append("</tr>");
        }
        builder.Append("</table>");
        builder.Append("</body>");
        builder.Append("</html>");

        return builder.ToString();
    }

    /// <summary>
    /// Converts a list of RetrievalItem into a DataTable
    /// </summary>
    /// <param name="lri"></param>
    /// <returns></returns>
    public static DataTable toDataTable(List<RetrievalItem> lri)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Item Number");
        dt.Columns.Add("Description");
        dt.Columns.Add("Quantity Assigned");

        foreach (RetrievalItem ri in lri)
        {
            dt.Rows.Add(ri.Item_No, ItemCatalogDAO.itemDescription(ri.Item_No), ri.QuantityToGiveOut);
        }
        return dt;
    }
}