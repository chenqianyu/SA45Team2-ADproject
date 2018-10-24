using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SA45Team02_SSIS;

/// <summary>
/// Summary description for SupplierDAO
/// </summary>
public class SupplierDAO
{
    public SupplierDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    /*
* Thin's Codes Start
*/

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static List<Supplier> GetAllSuppliers()
    {
        Model entities = new Model();
        return entities.Suppliers.ToList<Supplier>();

    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="itemID"></param>
    /// <returns></returns>
    public static Supplier GetSupplierByItemNo(string itemID)
    {
        Model entities = new Model();
        entities.Suppliers.Join(entities.SupplierItems, c => c.Supplier_ID, o => o.Supplier_ID, (c, o) => o)
             .Where(k => k.Item_No == itemID && k.PreferenceRank == 1);
        var s = entities.SupplierItems.Where(k => k.Item_No == itemID && k.PreferenceRank == 1).
            Join(entities.Suppliers, c => c.Supplier_ID, o => o.Supplier_ID,
            (c, o) => o);
        return s.ToList<Supplier>()[0];

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="supplierID"></param>
    /// <returns></returns>
    public static Supplier GetSupplierBySupplierID(string supplierID)
    {
        Model entities = new Model();
        return entities.Suppliers.Where(x => x.Supplier_ID.Equals(supplierID)).ToList<Supplier>().FirstOrDefault();

    }

    /*
* Thin's Codes End
*/

    /*
* Charlotte's Codes Start
*/


    public static List<SupplierItem> Item()
    {
        Model entities = new Model();
        return entities.SupplierItems.ToList<SupplierItem>();

    }
    public static List<string> GetID()
    {
        Model entities = new Model();
        return entities.Suppliers.Select(x => x.Supplier_ID).ToList();

    }
    public static List<Supplier> GetSupplierListBySupplierID(string supplier_ID)
    {
        Model entities = new Model();
        return entities.Suppliers.Where(p => p.Supplier_ID.Equals(supplier_ID)).ToList();

    }





    public static void EditSupplier(string supplier_Name, string supplier_ID,
        string contact_Name, int phone, string address, string email)
    {
        Model entities = new Model();
        Supplier supplier = entities.Suppliers.Where(p => p.Supplier_ID.Equals(supplier_ID)).First();
        supplier.Supplier_ID = supplier_ID;
        supplier.Supplier_Name = supplier_Name;
        supplier.Contact_Name = contact_Name;
        supplier.Phone = phone;
        supplier.Address = address;
        supplier.Email = email;
        entities.SaveChanges();

    }
    public static void DeleteSupplier(string supplier_ID)
    {
        Model entities = new Model();
        Supplier supplier = entities.Suppliers.Where(p => p.Supplier_ID.Equals(supplier_ID)).First<Supplier>();
        entities.Suppliers.Remove(supplier);
        entities.SaveChanges();

    }

    /*
* Charlotte's Codes End
*/

}