using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SupplierConverter
/// </summary>
public class SupplierConverter
{
    public SupplierConverter()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static WCFSupplier ChangeSupplierToWCFSupplier(Supplier s)
    {
        return WCFSupplier.Make(s.Supplier_ID,
      s.Supplier_Name,
      s.Contact_Name,
      s.Phone,
      s.Address,
      s.Email);

      

    }

    public static List<WCFSupplier> ChangeSupplierListToWCFSupplierList(List<Supplier> supList)
    {

        List<WCFSupplier> wcfSupplier = new List<WCFSupplier>();
        foreach (Supplier s in supList)
        {

            WCFSupplier wcfReq = WCFSupplier.Make(s.Supplier_ID,
      s.Supplier_Name,
      s.Contact_Name,
      s.Phone,
      s.Address,
      s.Email);
            wcfSupplier.Add(wcfReq);
        }
        return wcfSupplier;
    }
}