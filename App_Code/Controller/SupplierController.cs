using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SupplierController
/// </summary>
public class SupplierController
{
    SupplierDAO supDAO = new SupplierDAO();
    public SupplierController()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    /*
* Charlotte's Codes Start
*/
    public List<Supplier> SupplierList()
    {
        List<Supplier> SupplierList = new List<Supplier>();
        SupplierList = SupplierDAO.GetAllSuppliers();
        return SupplierList;
    }
    public List<SupplierItem> Item()
    {
        List<SupplierItem> item = new List<SupplierItem>();
        item = SupplierDAO.Item();
        return item;
    }
    public List<string> id()
    {
        List<string> id = new List<string>();
        id = SupplierDAO.GetID();
        return id;
    }
    public List<Supplier> SearchSupplierByID(string supplier_ID)
    {
        List<Supplier> detail = new List<Supplier>();
        detail = SupplierDAO.GetSupplierListBySupplierID(supplier_ID);
        return detail;
    }

    public static Supplier SelectSupplierByID(string supplier_ID)
    {
        Supplier detail = new Supplier();
        detail = SupplierDAO.GetSupplierBySupplierID(supplier_ID);
        return detail;
    }

    public static void EditSupplier(string supplier_Name, string supplier_ID, string contact_Name, int phone, string address, string email)
    {
        SupplierDAO.EditSupplier(supplier_Name, supplier_ID, contact_Name, phone, address, email);
    }


    /*
* Charlotte's Codes End
*/

}