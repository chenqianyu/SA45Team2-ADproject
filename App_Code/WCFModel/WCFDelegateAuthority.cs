using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for WCFDelegateAuthority
/// </summary>
public class WCFDelegateAuthority
{

    public static WCFDelegateAuthority Make(int delegateID,  int employeeID,
    string startDate, string endDate, string remarks)
    {
        WCFDelegateAuthority da = new WCFDelegateAuthority();
        da.DelegateID = delegateID;
        da.EmployeeID = employeeID;
        da.StartDate = startDate;
        da.EndDate = endDate;
        da.Remarks = remarks;
        return da;
    }

    int delegateID;
    int employeeID;
    string startDate;
    string endDate;
    string remarks;

    public int DelegateID
    {
        get
        {
            return delegateID;
        }

        set
        {
            delegateID = value;
        }
    }

    public int EmployeeID
    {
        get
        {
            return employeeID;
        }

        set
        {
            employeeID = value;
        }
    }

    public string StartDate
    {
        get
        {
            return startDate;
        }

        set
        {
            startDate = value;
        }
    }

    public string EndDate
    {
        get
        {
            return endDate;
        }

        set
        {
            endDate = value;
        }
    }

    public string Remarks
    {
        get
        {
            return remarks;
        }

        set
        {
            remarks = value;
        }
    }
}