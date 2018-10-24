using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RelinquishController
/// </summary>
public class RelinquishController
{
    
    public RelinquishController()
    {
        
    }


    /*
     * Yex's code starts
     */

    public static DelegateAuthority GetDelegateAuthorityByEmpId(int empID)

    {
        return DelegateDAO.GetDelegateAuthorityByEmpId(empID);
    }

    /*
   * Yex's code ends
   */
}