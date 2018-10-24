using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SA45Team02_SSIS;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DisbursementService" in code, svc and config file together.
public class DisbursementService : IDisbursementService
{
    
    public void EditRetriveItem(string item_No, string b, string number)
    {
        DisbursementController.EditRetriveItem(item_No, Convert.ToInt32(b), Convert.ToInt32(number) );
    }

    public string FindItem(string item_name)
    {
       return DisbursementController.FindItem(item_name);
    }

    public List<WCFDisbursementViewDTO> GetDisbursementByDep(string depID)
    {
        List<DisbursementViewDTO> d=DisbursementController.GetDisbursementByDep(depID);
        
        return null;
    }

    public WCFEmployee GetEmployeeByEmpId(string empId)
    {
        Employee e = DisbursementController.GetEmployeeByEmpId(Convert.ToInt32(empId));
       WCFEmployee wcfemp= EmployeeConverter.ChangeEmpToWCFEmp(e);
        return wcfemp;
    }

    public WCFEmployee GetRepresentativeByDepartmentID(string depId)
    {
        Employee e = DisbursementController.GetRepresentativeByDepartmentID(depId);
        WCFEmployee wcfemp = EmployeeConverter.ChangeEmpToWCFEmp(e);
        return wcfemp;
    }

    public List<WCFDepartment> RetrieveDepartmentList()
    {
        List<Department> depList = DisbursementController.RetrieveDepartmentList();
       List<WCFDepartment> wcfDepList= DepartementConverter.ChangeDepListToWCFDepList(depList);
        return wcfDepList;
    }

    public WCFDepartment RetrieveDeptByDepID(string id)
    {
       Department d= DisbursementController.RetrieveDeptByDepID(id);
       WCFDepartment wcfDep= DepartementConverter.ChangeDepToWcfDep(d);
        return wcfDep;
    }

    public WCFDisbursementItemView RetrieveInformation(string departmentName)
    {
        DisbursementItemView dbItemView = DisbursementController.RetrieveInformation(departmentName);
        return DisbursementItemViewConverter.ChangeDbiViewToWcfDbiView(dbItemView) ;
    }

    //Change from DataTable in Utility
    public List<WCFDataTable> Retrieveitem(string departmentName)
    {
       DataTable dataTable= DisbursementController.Retrieveitem(departmentName);


        return DataTableConverter.ChangeDTToWcfDT(dataTable);
    }

    public List<string> SelectDepartmentName()
    {
        return DisbursementController.SelectDepartmentName();
    }

    public void UpdateCompletedStatus()
    {
         DisbursementController.UpdateCompletedStatus();
    }

    public void UpdateDisbursementStatusAndDate(string depID)
    {
        DisbursementController.UpdateDisbursementStatusAndDate(depID);
    }

    public List<WCFDataTable> ViewDisbursementIndex(string department)
    {
        DataTable dataTable = DisbursementController.ViewDisbursementIndex(department);


        return DataTableConverter.ChangeDTToWcfDT(dataTable);
       
    }

    public List<WCFDataTable> ViewPastDisbursementItem(string departmentName, string number)
    {
        DataTable dataTable = DisbursementController.ViewPastDisbursementItem(departmentName, Convert.ToInt32(number));


        return DataTableConverter.ChangeDTToWcfDT(dataTable);
       
    }
}
