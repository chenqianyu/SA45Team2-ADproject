using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DelegateAuthorityConverter
/// </summary>
public class DelegateAuthorityConverter
{
    public DelegateAuthorityConverter()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static WCFDelegateAuthority ChangeDAToWcfDA(DelegateAuthority d)
    {

        return WCFDelegateAuthority.Make(d.Delegate_ID,d.Employee_ID,Convert.ToString(d.Start_Date),Convert.ToString(d.End_Date),d.Remarks);
    }

}