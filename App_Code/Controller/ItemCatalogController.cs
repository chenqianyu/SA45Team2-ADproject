using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ItemCatalogController
/// </summary>
public class ItemCatalogController
{
    
   static List<ItemCatalog> aa;
   static DataTable Item_Catalog;

    public ItemCatalogController()
    { }


    /*
     * Jerry's codes starts
     */

    public static DataTable Someting(String Catagory)
    {

        Item_Catalog = new DataTable();
        if (Catagory.Equals("All"))
        {
            aa = ItemCatalogDAO.RetrieveItemCatalogsList();
        }
        else
            aa = ItemCatalogDAO.selectAllfromItem(Catagory);

        Item_Catalog.Columns.Add("ItemNo", typeof(String));
        Item_Catalog.Columns.Add("Category", typeof(String));
        Item_Catalog.Columns.Add("Description", typeof(String));
        Item_Catalog.Columns.Add("Reorder Level", typeof(int));
        Item_Catalog.Columns.Add("Reorder Quantity", typeof(int));
        Item_Catalog.Columns.Add("Unit of measure", typeof(String));
        Item_Catalog.Columns.Add("Total Quantity", typeof(int));
        Item_Catalog.Columns.Add("Price", typeof(int));
        Item_Catalog.Columns.Add("Allocated Quantity", typeof(int));
        for (int i = 0; i < aa.Count; i++)
        {
            ItemCatalog element = aa[i];
            Item_Catalog.Rows.Add(element.Item_No, element.Category, element.Description, element.Reorder_Lvl,
                element.Reorder_Qty, element.Unit_of_Measure, element.Total_Qty, element.Price, element.Allocated_Qty);
        }
        return Item_Catalog;
    }

    public static ItemCatalog SearchByItemNo(String Item_No)
    {
        return ItemCatalogDAO.RetrieveItemCatalogByItemNo(Item_No);
    }
    public static void insertNewItem(ItemCatalog newItem)
    {
        ItemCatalogDAO.insertNewItem(newItem);
    }

    public static void editItemByNo(string Item_No, int Reorder_lvl, int Reorder_qty, string Unit_of_Measure, int Total_qty, decimal Price, int AllocatedQuantity)
    {
        ItemCatalogDAO.editItemByNo(Item_No, Reorder_lvl, Reorder_qty, Unit_of_Measure, Total_qty, Price, AllocatedQuantity);
    }
    public static List<string> SelectItemCatalog()
    {
        return ItemCatalogDAO.SelectItemCatalog();
    }
    public static string createNewItem_no(string catalog)
    {

        List<ItemCatalog> item = ItemCatalogDAO.selectAllfromItem(catalog);
        ItemCatalog LastItem = item[item.Count - 1];
        string lastitem = LastItem.Item_No.ToString();
        int number = Convert.ToInt32(lastitem.Substring(1, 3)) + 1;
        string a = lastitem.Substring(0, 1) + String.Format("{0:000}", number);
        return a;

    }


    /*
     * Jerry's codes ends
     */
}