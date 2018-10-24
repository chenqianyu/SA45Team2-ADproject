using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DelegateService" in code, svc and config file together.
public class DelegateService : IDelegateService
{
    public WCFDelegateAuthority GetActiveDelegateByEmpId(string empId)
    {

        DelegateAuthority d = DelegateController.GetActiveDelegateByEmpId(Convert.ToInt32(empId));
        return DelegateAuthorityConverter.ChangeDAToWcfDA(d) ;
    }

    public WCFEmployee GetDelegateEmp(string empId)
    {
       Employee emp= DelegateController.GetDelegateEmp(empId);
        return EmployeeConverter.ChangeEmpToWCFEmp(emp);
    }

    public WCFEmployee GetDelegateStoreClerk(string depID)
    {

        Employee emp = DelegateController.GetDelegateStoreClerk(depID);
       return EmployeeConverter.ChangeEmpToWCFEmp(emp);
    }

    public List<WCFEmployee> GetEmployeeName(string depId)
    {
        List<Employee> empList = DelegateController.GetEmployeeName(depId);
        List<WCFEmployee> wcfEmpList = EmployeeConverter.ChangeEmpListToWCFEmpList(empList);
        return wcfEmpList;
    }

    public List<WCFEmployee> GetStoreClerk()
    {
        List<Employee> empList = DelegateController.GetStoreClerk();
        List<WCFEmployee> wcfEmpList = EmployeeConverter.ChangeEmpListToWCFEmpList(empList);
        return wcfEmpList;
    }

    public void RelinquishEmployee(string empid)
    {
        DelegateController.RelinquishEmployee(Convert.ToInt32(empid));
    }

    public void RelinquishStoreClerk(string empid)
    {
        DelegateController.RelinquishStoreClerk(Convert.ToInt32(empid));
    }


    public bool SetDelegate(int empId, string start, string end, string remark)
    {
       return DelegateController.SetDelegate(empId, Convert.ToDateTime(start),Convert.ToDateTime( end), remark);
    }

    public bool SetDepartmentDelegate(string empId, string start, string end, string remark)
    {
        return DelegateController.SetDepartmentDelegate(Convert.ToInt32(empId), Convert.ToDateTime(start), Convert.ToDateTime(end), remark);
    }

    public bool SetSupervisorDelegate(string empId, string start, string end, string remark)
    {
        return DelegateController.SetSupervisorDelegate(Convert.ToInt32(empId), Convert.ToDateTime(start), Convert.ToDateTime(end), remark);
    }


    public WCFEmployee RetrieveDelegateEmployeeByEmpId(string empId)
    {
        Employee e=DelegateController.RetrieveDelegateEmployeeByEmpId(Convert.ToInt32(empId));
        return EmployeeConverter.ChangeEmpToWCFEmp(e);
    }

    public bool SetDelegate(string empId, string start, string end, string remark)
    {
        return DelegateController.SetDelegate(Convert.ToInt32(empId), Convert.ToDateTime(start), Convert.ToDateTime(end), remark);
    }
}
