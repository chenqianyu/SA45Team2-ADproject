using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EmployeeConverter
/// </summary>
public class EmployeeConverter
{
    public EmployeeConverter()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static WCFEmployee ChangeEmpToWCFEmp(Employee emp)
    {
        return WCFEmployee.Make(emp.Employee_ID, emp.Employee_Name, emp.Email, emp.Phone, emp.Address,
            emp.Role, Convert.ToInt32(emp.Delegate_ID), emp.Department_ID);
           
 
    }
    public static List<WCFEmployee> ChangeEmpListToWCFEmpList(List<Employee> empList)
    {

        List<WCFEmployee> wcfEmpList = new List<WCFEmployee>();
        foreach (Employee e in empList)
        {

            WCFEmployee wcfEmp = WCFEmployee.Make(e.Employee_ID, e.Employee_Name, e.Email,
                e.Phone, e.Address, e.Role,Convert.ToInt32(e.Delegate_ID), e.Department_ID);
            wcfEmpList.Add(wcfEmp);
        }
        return wcfEmpList;
    }
}