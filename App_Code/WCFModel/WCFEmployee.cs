using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for WCFEmployee
/// </summary>
public class WCFEmployee
{
  

    int employeeId;
    string employeeName;
    string email;
    int phone;
    string address;
    string role;
    int delegateId;
    string departmentId;

    public static WCFEmployee Make(int employeeId,
    string employeeName,
    string email,
    int phone,
    string address,
    string role,
    int delegateId,
    string departmentId)
    {
        WCFEmployee c = new WCFEmployee();
        c.EmployeeId = employeeId;
        c.EmployeeName = employeeName;
        c.Email = email;
        c.Phone = phone;
        c.Address = address;
        c.Role = role;
        c.DelegateId = delegateId;
        c.DepartmentId = departmentId;




        return c;
    }


    public int EmployeeId
    {
        get
        {
            return employeeId;
        }

        set
        {
            employeeId = value;
        }
    }

    public string EmployeeName
    {
        get
        {
            return employeeName;
        }

        set
        {
            employeeName = value;
        }
    }

    public string Email
    {
        get
        {
            return email;
        }

        set
        {
            email = value;
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

    public string Address
    {
        get
        {
            return address;
        }

        set
        {
            address = value;
        }
    }

    public string Role
    {
        get
        {
            return role;
        }

        set
        {
            role = value;
        }
    }

    public int DelegateId
    {
        get
        {
            return delegateId;
        }

        set
        {
            delegateId = value;
        }
    }

    public string DepartmentId
    {
        get
        {
            return departmentId;
        }

        set
        {
            departmentId = value;
        }
    }
}