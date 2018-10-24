using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DisbursementController
/// </summary>
public class DisbursementController
{
    DisbursementDAO disDAO = new DisbursementDAO();
    DepartmentDAO depDAO = new DepartmentDAO();
    EmployeeDAO empDAO = new EmployeeDAO();
    ItemCatalogDAO icDAO = new ItemCatalogDAO();
    RetrievalDAO retDAO = new RetrievalDAO();
    public DisbursementController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    /*
    * HanSu's codes starts
    */
    //get Disbursement List for Each Department from Latest Retrieval ID
    public static List<DisbursementViewDTO> GetDisbursementByDep(string depID)
    {
        return DisbursementDAO.GetAllDisbursementListByDep1(DisbursementDAO.GetLatestRetrivalID(), depID);
    }

    public static void UpdateDisbursementStatusAndDate(string depID)
    {
        DisbursementDAO.UpdateForDisbursementStatusAndDate(depID);
    }

    public static void UpdateCompletedStatus()
    {
        DisbursementDAO.UpdateStatusForCompletedRequest();
    }

    public static List<Department> RetrieveDepartmentList()
    {
        return DepartmentDAO.RetrieveDepartmentList();
    }

    public static Employee GetRepresentativeByDepartmentID(string depId)
    {
        return EmployeeDAO.GetRepresentativeByDepartmentID(depId);
    }


    public static Employee GetEmployeeByEmpId(int empId)
    {
        return EmployeeDAO.GetEmployeeByEmpId(empId);
    }

    

    public static Department RetrieveDeptByDepID(string id)
    {
        return DepartmentDAO.RetrieveDeptByDepID(id);
    }

    /*
    * HanSu's codes ends
    */

    /*
        * Jerry's codes starts
        */
    public static List<string> SelectDepartmentName()
    {
        return DepartmentDAO.ViewDepartmentName();
    }
    public static DisbursementItemView RetrieveInformation(string DepartmentName)
    {
        return DisbursementDAO.ViewDisbursementByDep(DepartmentName);
    }
    public static DataTable Retrieveitem(string DepartmentName)
    {
        return DisbursementDAO.ViewDisbursementItem(DepartmentName);
    }
    public static string FindItem(string item_name)
    {
        return ItemCatalogDAO.FindItemByDescription(item_name);
    }
    public static void EditRetriveItem(string item_No, int b, int number)
    {
        RetrievalDAO.EditRetriveItem(item_No, b, number);
    }
    public static DataTable ViewDisbursementIndex(string department)
    {
        return DisbursementDAO.ViewDisbursementIndex(department);
    }
    public static DataTable ViewPastDisbursementItem(string DepartmentName, int number)
    {
        return DisbursementDAO.ViewPastDisbursementItem(DepartmentName, number);
    }

    /*
        * Jerry's codes ends
        */
}