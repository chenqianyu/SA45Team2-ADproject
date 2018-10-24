using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EmployeeDAO
/// </summary>
public class EmployeeDAO
{
    
    public EmployeeDAO()
    {

    }

    /*
   * Thin's code starts
   */
    public static Employee RetrieveEmpByName(String empName)
    {
        Model entities = new Model();
        Employee e=entities.Employees.Where(x => x.Employee_Name == empName).ToList().FirstOrDefault();
        return e;
    }

    /*
* Thin's code ends
*/


    /*
    * Yex's code starts
    */

    /// <summary>
    /// Get All StoreClerk List for supervisor
    /// </summary>
    /// <returns></returns>
    public static List<Employee> GetStoreClerk()
    {
        Model entities = new Model();
        return entities.Employees.Where(u => u.Role == "StoreClerk").ToList<Employee>();
    }

    /// <summary>
    /// Get Currently Delegate Store Clerk List for Supervisor
    /// </summary>
    /// <returns></returns>
    public static Employee GetDelegateStoreClerk(string depID)
    {
        Model entities = new Model();
        return entities.Employees.Where(u =>/* u.Role == "Delegate" && */u.Department_ID == depID).First();
    }

    /// <summary>
    /// Relinquish for Supervisor
    /// </summary>
    /// <param name="empid"></param>
    public static void RelinquishStoreClerk(int empid)
    {
        using (Model entities = new Model())
        {
            Employee emp = entities.Employees.Where(p => p.Employee_ID == empid).First<Employee>();
            emp.Delegate_ID = null;
            emp.Role = "StoreClerk";
            entities.SaveChanges();
        }
    }

    /// <summary>
    /// For One Department, Get all Employee List for departmentHead
    /// </summary>
    /// <returns></returns>
    public static List<Employee> GetEmployeeByDep(string deptID)
    {
        Model entities = new Model();
        return entities.Employees.Where(u => u.Department_ID == deptID && u.Role == "Employee").ToList<Employee>();

    }

    public static Employee GetEmpDept(string empmail)
    {
        Model entities = new Model();
        return entities.Employees.Where(x => x.Email == empmail).First();
    }

    /// <summary>
    /// Get Currently Delegate Employee List for departmentHead
    /// </summary>
    /// <returns></returns>
    public static Employee GetDelegateEmp(string depID)
    {
        Model entities = new Model();
        return entities.Employees.Where(u => u.Department_ID == depID && u.Role == "Delegate").ToList<Employee>().First();
    }

    /// <summary>
    /// Relinquish for Department Head
    /// </summary>
    /// <param name="empid"></param>
    public static void RelinquishEmployee(int empid)
    {
        using (Model entities = new Model())
        {
            Employee emp = entities.Employees.Where(p => p.Employee_ID == empid).First<Employee>();
            emp.Delegate_ID = null;
            emp.Role = "Employee";
            entities.SaveChanges();
        }
    }

    /// <summary>
    /// Change delegate role of Employee for DepartmentHead/StoreClerk
    /// </summary>
    /// <param name="empid"></param>
    public static void ChangeDelegateRole(int empid)

    {
        using (Model entities = new Model())
        {
            int delegateId = entities.DelegateAuthorities.Select(x => x.Delegate_ID).Max();
            Employee emp = entities.Employees.Where(p => p.Employee_ID == empid).First<Employee>();
            //Employee dr = new Employee();
            emp.Role = "Delegate";
            emp.Delegate_ID = delegateId;
            //DelegateDAO.DelegateR(emp);
            entities.SaveChanges();
        }
    }

    /// <summary>
    /// Retrieve currently Delegated Employee who has same role
    /// </summary>
    /// <param name="empID"></param>
    /// <returns></returns>
    public static Employee RetrieveCurrentDelegateEmployee(int empID)
    {
        using (Model entities = new Model())
        {
            Employee e = entities.Employees.Where(x => x.Employee_ID == empID).ToList().First();
            return entities.Employees.Where(x => x.Department_ID == e.Department_ID && x.Delegate_ID != null).ToList().FirstOrDefault();
        }

    }

    public static Employee RetrieveEmployeeByEmployeeID(int empID)
    {
        using (Model entities = new Model())
        {
            Employee e = entities.Employees.Where(x => x.Employee_ID == empID).ToList().FirstOrDefault();
            return e;
        }

    }

    /*
   * Yex's code ends
   */

    /*
    * HanSu's code starts
    */
    public static Employee GetEmployeeByEmpId(int empId)
    {
        Model entities = new Model();
        return entities.Employees.Where(u => u.Employee_ID == empId).ToList<Employee>().First();
    }
  

    
  public static Employee GetRepresentativeByDepartmentID(string depID)
    {
        Model entities = new Model();
        return entities.Employees.Where(x => x.Department_ID == depID).Where(y => y.Role == "Representative").First<Employee>();
    }

   

    /*
    * HanSu's code ends
    */


    /*
* JW's codes starts
*/
    public static List<Employee> RetrieveEmployeeListInDept(string DeptCode)
    {
        Model entities = new Model();
        return entities.Employees.Where(x => x.Department_ID == DeptCode && x.Role == "Employee").ToList<Employee>();
    }

   

    public static Employee GetSupervisor()
    {
        Model entities = new Model();
        return entities.Employees.Where(x => x.Role == "SuperVisor").First();
    }

    public static Employee GetManager()
    {
        Model entities = new Model();
        return entities.Employees.Where(x => x.Role == "Manager").First();
    }

    public static Employee GetEmployeeByEmployeeID(int id)
    {
        Model entities = new Model();
        return entities.Employees.Where(x => x.Employee_ID == id).First();
    }

    public static void UpdateEmpRep(Employee emp)
    {
        Model entities = new Model();
        emp.Role = "Representative";
        entities.SaveChanges();
    }

    public static void RemoveEmpRep(Employee emp)
    {
        Model entities = new Model();
        emp.Role = "Employee";
        entities.SaveChanges();
    }

    /*
* JW's codes ends
*/

}