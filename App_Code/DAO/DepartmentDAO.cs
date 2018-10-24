using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DepartmentDAO
/// </summary>
public class DepartmentDAO
{
   
    public DepartmentDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /*
 * HanSu's codes starts
 */

    public static List<Department> RetrieveDepartmentList()
    {
        Model entities = new Model();
        return entities.Departments.ToList();
    }

    public static Department GetDepartmentByEmployeeID(Employee e)
    {
        Model entities = new Model();
        return entities.Departments.Where(x => x.Department_ID == e.Department_ID).First();
    }


    /*
     * HanSu's codes ends
     */

    /*
* JW's codes starts
*/
    public static Department RetrieveDeptByDepID(string id)
    {
        Model entities = new Model();
        return entities.Departments.Where(x => x.Department_ID == id).First();
    }

    public static void UpdateCollectionPoint(Department dept, CollectionPoint collect)
    {
        Model entities = new Model();
        dept.CollectionPoint_ID = collect.CollectionPoint_ID;
        entities.SaveChanges();
    }

    public static void UpdateDeptRep(Department dept, Employee emp)
    {
        Model entities = new Model();
        dept.Representative_ID = emp.Employee_ID;
        entities.SaveChanges();
    }
    /*
* JW's codes ends
*/

    /*
* Jerry's codes ends
*/


    public static List<string> ViewDepartmentName()
    {
        Model entities = new Model();
        return entities.Departments.Select(x => x.Department_Name).ToList();
    }

    /*
* Jerry's codes ends
*/


}