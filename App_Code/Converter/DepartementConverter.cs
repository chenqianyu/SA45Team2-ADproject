using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DepartementConverter
/// </summary>
public class DepartementConverter
{
    public DepartementConverter()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static List<WCFDepartment> ChangeDepListToWCFDepList(List<Department> depList)
    {

        List<WCFDepartment> wcfDepList = new List<WCFDepartment>();
        foreach (Department d in depList)
        {

           WCFDepartment wcfDep= WCFDepartment.Make(d.Department_ID, d.Department_Name, d.HeadStaff_ID, d.Representative_ID,
                d.Phone, d.CollectionPoint_ID, d.ContactStaff_ID);



            wcfDepList.Add(wcfDep);
        }
        return wcfDepList;
    }

    public static WCFDepartment ChangeDepToWcfDep(Department d)
    {

        return WCFDepartment.Make(d.Department_ID, d.Department_Name, d.HeadStaff_ID, d.Representative_ID, d.Phone, d.CollectionPoint_ID, d.ContactStaff_ID);
    }

}