using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DelegateController
/// </summary>
public class DelegateController
{

    //EmployeeDAO empDAO;
    //DelegateDAO delDAO;
    public DelegateController()
    {
       
    }
    /*
   * Yex's code starts
   */

    public static List<Employee> GetEmployeeName(string depID)
    {
        return EmployeeDAO.GetEmployeeByDep(depID);
    }

    public static bool SetDelegate(int empId, DateTime start,
     DateTime end, string remark)
    {
        DelegateAuthority d = new DelegateAuthority();
        d.Employee_ID = empId;
        d.Start_Date = start;
        d.End_Date = end;
        d.Remarks = remark;

        Employee currentDelegatedEmp = EmployeeDAO.RetrieveCurrentDelegateEmployee(empId);
        if (currentDelegatedEmp != null)
        {
            DelegateAuthority da = DelegateDAO.GetDelegateAuthorityByEmpIdAndDelegateID(currentDelegatedEmp.Employee_ID, (int)currentDelegatedEmp.Delegate_ID);
            DelegateDAO.ChangeStatus(da.Employee_ID);
            EmployeeDAO.RelinquishEmployee(da.Employee_ID);

        }

        //add row to DelegateAuthority
        DelegateDAO.Delegate(d);

        //Change delegate role of Employee for DepartmentHead/StoreClerk
        EmployeeDAO.ChangeDelegateRole(empId);
        return true;


        
    }

    public static bool SetSupervisorDelegate(int empId, DateTime start,
    DateTime end, string remark)
    {

        DelegateAuthority d = new DelegateAuthority();
        d.Employee_ID = empId;
        d.Start_Date = start;
        d.End_Date = end;
        d.Remarks = remark;

        Employee currentDelegatedEmp = EmployeeDAO.RetrieveCurrentDelegateEmployee(empId);
        if (currentDelegatedEmp != null)
        {
            DelegateAuthority da = DelegateDAO.GetDelegateAuthorityByEmpIdAndDelegateID(currentDelegatedEmp.Employee_ID, (int)currentDelegatedEmp.Delegate_ID);
            DelegateDAO.ChangeStatus(da.Employee_ID);
            EmployeeDAO.RelinquishStoreClerk(da.Employee_ID);
        }

        //add row to DelegateAuthority
        DelegateDAO.Delegate(d);

        //Change delegate role of Employee for DepartmentHead/StoreClerk
        EmployeeDAO.ChangeDelegateRole(empId);
        return true;


    }


    //Relinquish for Department Head
    public static void RelinquishEmployee(int empid)
    {
        DelegateDAO.ChangeStatus(empid);
        EmployeeDAO.RelinquishEmployee(empid);
    }


    //Relinquish for Supervisor
    public static void RelinquishStoreClerk(int empid)
    {
        DelegateDAO.ChangeStatus(empid);
        EmployeeDAO.RelinquishStoreClerk(empid);
    }

    public static Employee GetDelegateEmp(string depID)
    {
        return EmployeeDAO.GetDelegateEmp(depID);
    }

    public static Employee GetDelegateStoreClerk(string depID)
    {
        return EmployeeDAO.GetDelegateStoreClerk(depID);
    }



    public static List<Employee> GetStoreClerk()
    {
        return EmployeeDAO.GetStoreClerk();
    }

    public static DelegateAuthority GetActiveDelegateByEmpId(int empId)
    {
        Employee e = EmployeeDAO.RetrieveCurrentDelegateEmployee(empId);
        DelegateAuthority da = DelegateDAO.GetDelegateAuthorityByEmpId(empId);
        return da;


    }

    public static Employee RetrieveDelegateEmployeeByEmpId(int empId)
    {
        return EmployeeDAO.RetrieveCurrentDelegateEmployee(empId);
    }


    
 public static bool SetDepartmentDelegate(int empId, DateTime start,
DateTime end, string remark)
    {

        DelegateAuthority d = new DelegateAuthority();
        d.Employee_ID = empId;
        d.Start_Date = start;
        d.End_Date = end;
        d.Remarks = remark;

        Employee currentDelegatedEmp = EmployeeDAO.RetrieveCurrentDelegateEmployee(empId);
        if (currentDelegatedEmp != null)
        {
            DelegateAuthority da = DelegateDAO.GetDelegateAuthorityByEmpIdAndDelegateID(currentDelegatedEmp.Employee_ID, (int)currentDelegatedEmp.Delegate_ID);
            DelegateDAO.ChangeStatus(da.Employee_ID);
            EmployeeDAO.RelinquishEmployee(da.Employee_ID);

        }

        //add row to DelegateAuthority
        DelegateDAO.Delegate(d);

        //Change delegate role of Employee for DepartmentHead/StoreClerk
        EmployeeDAO.ChangeDelegateRole(empId);
        return true;


    }


    /*
   * Yex's code ends
   */



}