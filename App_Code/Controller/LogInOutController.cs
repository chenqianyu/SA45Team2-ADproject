using SA45Team02_SSIS;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Security.Principal;
using System.Web.Security;

/// <summary>
/// Summary description for LogInOutController
/// </summary>
public class LogInOutController
{
    public LogInOutController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    /*
* Thin's code starts
*/
    public static LoginUserInfo CheckSuccessLogin(String username, String password)
    {

        Boolean status = Membership.ValidateUser(username, password);
        LoginUserInfo info = new LoginUserInfo();
        if (status)
        {
            info = RetrieveCurrentlyLoginUserInfo(username);
            info.LoginStatus = Utility.LoginSuccess;
        }
        else
        {
            info.LoginStatus = Utility.LoginFailed;
        }


        return info;

    }

    public static LoginUserInfo RetrieveCurrentlyLoginUserInfo(String username)
    {
        LoginUserInfo info = new LoginUserInfo();
        Employee e = EmployeeDAO.RetrieveEmpByName(username);

        info.UserName = e.Employee_Name;
        info.EmpId = Convert.ToString(e.Employee_ID);
        info.DepartmentId = e.Department_ID;

        info.DepartmentName = DepartmentDAO.RetrieveDeptByDepID(e.Department_ID).Department_Name;
        info.Role = Convert.ToString(Roles.GetRolesForUser(username).GetValue(0));
        return info;

    }

    /*
* Thin's code ends
*/
}