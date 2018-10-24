using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DepartmentController
/// </summary>
public class DepartmentController
{
    RepresentativeDAO repDAO;
    DepartmentDAO depDAO;
    EmployeeDAO empDAO;

    public DepartmentController()
    {
        repDAO = new RepresentativeDAO();
        depDAO = new DepartmentDAO();
        empDAO = new EmployeeDAO();
        //
        // TODO: Add constructor logic here
        //
    }

    /*
* JW's Codes Start
*/
    public List<Employee> RetrieveEmployeeListInDept(string DeptCode)
    {
        return EmployeeDAO.RetrieveEmployeeListInDept(DeptCode);
    }

    public Employee GetCurrentRepByDepID(string departmentID)
    {
        return EmployeeDAO.GetRepresentativeByDepartmentID(departmentID);
       
    }

    public Department RetrieveDeptByDepID(string id)
    {
        return DepartmentDAO.RetrieveDeptByDepID(id);
    }

    public Employee GetEmployeeByEmpId(int empId)
    {

        return EmployeeDAO.GetEmployeeByEmployeeID(empId);
    }

    public Representative RetrieveRepByEmpID(int empID)
    {
        return RepresentativeDAO.RetrieveRepByEmpID(empID);
    }

    public void UpdateDeptRep(Department dept, Employee emp)
    {
        DepartmentDAO.UpdateDeptRep(dept, emp);
    }

    public void RemoveEmpRep(Employee e)
    {
        EmployeeDAO.RemoveEmpRep(e);
    }

    public void UpdateEmpRep(Employee emp)
    {
        EmployeeDAO.UpdateEmpRep(emp);
    }

    public void CreateNewRep(int id, DateTime startDate, string status)
    {
        RepresentativeDAO.CreateNewRep(id, startDate, status);
    }

    public void UpdateRepEndDate(Representative rep)
    {
        RepresentativeDAO.UpdateRepEndDate(rep);
    }
    /*
    * JW's Codes Start
    */
}