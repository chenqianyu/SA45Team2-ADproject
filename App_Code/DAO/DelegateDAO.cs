using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DelegateDAO
/// </summary>
public class DelegateDAO
{
    
    public DelegateDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    /*
   * Yex's code starts
   */
    public static void Delegate(DelegateAuthority d)

    {
        Model entities = new Model();

        DelegateAuthority d1 = d;
            entities.DelegateAuthorities.Add(d);
            entities.SaveChanges();
        
    }

   

    public static DelegateAuthority GetDelegateAuthorityByEmpId(int empID)

    {
        Model entities = new Model();
        return entities.DelegateAuthorities.Where(x => x.Employee_ID == empID).FirstOrDefault<DelegateAuthority>();
        
    }

    public static DelegateAuthority GetDelegateAuthorityByEmpIdAndDelegateID(int empID, int delegateID)

    {
        Model entities = new Model();
        return entities.DelegateAuthorities.Where(x => x.Employee_ID == empID && x.Delegate_ID == delegateID).First<DelegateAuthority>();
        
    }

    public static void ChangeStatus(int empID)
    {
        Model entities = new Model();
        DelegateAuthority da = entities.DelegateAuthorities.Where(x => x.Employee_ID == empID && x.Remarks == Utility.Current).FirstOrDefault<DelegateAuthority>();
        da.Remarks = Utility.Expired;
        entities.SaveChanges();

    }


    /*
   * Yex's code ends
   */
}