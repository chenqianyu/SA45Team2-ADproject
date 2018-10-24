using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LoginUserInfo
/// </summary>
public class LoginUserInfo
{
    String userName;
    String empId;
    String email;
    String departmentId;
    String departmentName;
    String role;
    String loginStatus;

    public string UserName
    {
        get
        {
            return userName;
        }

        set
        {
            userName = value;
        }
    }

    public string DepartmentName
    {
        get
        {
            return departmentName;
        }

        set
        {
            departmentName = value;
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

    public String LoginStatus
    {
        get
        {
            return loginStatus;
        }

        set
        {
            loginStatus = value;
        }
    }

    public string EmpId
    {
        get
        {
            return empId;
        }

        set
        {
            empId = value;
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

    public LoginUserInfo()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}