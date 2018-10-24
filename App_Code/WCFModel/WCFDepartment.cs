using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for WCFDepartment
/// </summary>
public class WCFDepartment
{
    
    string department_ID;
    string department_Name;
    int headStaff_ID;
    int representative_ID;
    int phone;
    int collectionPoint_ID;
    int contactStaff_ID;


    public static WCFDepartment Make(string department_ID,
    string department_Name,
    int headStaff_ID,
    int representative_ID,
    int phone,
    int collectionPoint_ID,
    int contactStaff_ID)
    {
        WCFDepartment c = new WCFDepartment();
        c.Department_ID = department_ID;
        c.Department_Name = department_Name;
        c.HeadStaff_ID = headStaff_ID;
        c.Representative_ID = representative_ID;
        c.Phone = phone;
        c.CollectionPoint_ID = collectionPoint_ID;
        c.ContactStaff_ID = contactStaff_ID;




        return c;
    }


    public string Department_ID
    {
        get
        {
            return department_ID;
        }

        set
        {
            department_ID = value;
        }
    }

    public string Department_Name
    {
        get
        {
            return department_Name;
        }

        set
        {
            department_Name = value;
        }
    }

    public int HeadStaff_ID
    {
        get
        {
            return headStaff_ID;
        }

        set
        {
            headStaff_ID = value;
        }
    }

    public int Representative_ID
    {
        get
        {
            return representative_ID;
        }

        set
        {
            representative_ID = value;
        }
    }

    public int Phone
    {
        get
        {
            return phone;
        }

        set
        {
            phone = value;
        }
    }

    public int CollectionPoint_ID
    {
        get
        {
            return collectionPoint_ID;
        }

        set
        {
            collectionPoint_ID = value;
        }
    }

    public int ContactStaff_ID
    {
        get
        {
            return contactStaff_ID;
        }

        set
        {
            contactStaff_ID = value;
        }
    }
}