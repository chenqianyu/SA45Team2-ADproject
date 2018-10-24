using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ItemCatalogDAO
/// </summary>
public class ItemCatalogDAO
{
    
    public ItemCatalogDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary>
    ///  Returns a list of all item in catalog
    /// </summary>
    /// <returns></returns>
     /*
     * Thin's codes starts
     */
    public static List<ItemCatalog> RetrieveItemCatalogsList()
    {
        Model entities = new Model();

        return entities.ItemCatalogs.ToList<ItemCatalog>();
        
    }


    /// <summary>
    /// search Item Cataglog by Item No
    /// </summary>
    /// <param name="itemNo"></param>
    /// <returns></returns>
    public static ItemCatalog RetrieveItemCatalogByItemNo(string itemNo)
    {
        Model entities = new Model();
        return entities.ItemCatalogs.Where(x=>x.Item_No==itemNo).ToList<ItemCatalog>().First();
        
    }

    public static void UpdateOrdered_QtyInItemCatalog(OrderDetail orderDetail )
    {
        Model entities = new Model();
        ItemCatalog ic = RetrieveItemCatalogByItemNo(orderDetail.Item_No);
        ic.Ordered_Qty = orderDetail.Ordered_Qty;
        entities.SaveChanges();

    }

    /*
     * Thin's codes ends
     */


    /*
     * Keoh's codes starts
     */



    /// <summary>
    /// returns a list of item object based on a list of item number
    /// </summary>
    /// <param name="itemNumberList"></param>
    /// <returns></returns>
    public static List<ItemCatalog> SelectItems(List<string> itemNumberList)
    {
        Model entities = new Model();
        List<ItemCatalog> selectedItems = new List<ItemCatalog>();
        foreach (string itemNumber in itemNumberList)
        {
            selectedItems.Add(entities.ItemCatalogs.Where(x => x.Item_No == itemNumber).First());
        }

        return selectedItems;
    }

    /// <summary>
    /// Returns the description of an item given the item number
    /// </summary>
    /// <param name="itemNumber"></param>
    /// <returns></returns>
    public static string itemDescription(string itemNumber)
    {
        Model entities = new Model();
        return entities.ItemCatalogs.Where(x => x.Item_No == itemNumber).First().Description;
    }

    /// <summary>
    /// Save changes made into database
    /// </summary>
    public static void SaveChanges()
    {
        Model entities = new Model();
        entities.SaveChanges();
    }
    /*
     * Keoh's codes ends
     */



    


    /*
* JW's codes starts
*/
    public static void IncreaseInventory(ItemCatalog item, int addQty)
    {
        Model entities = new Model();
        item.Total_Qty += addQty;
        entities.SaveChanges();
    }

    public static void DecreaseInventory(ItemCatalog item, int deductQty)
    {
        Model entities = new Model();
        item.Total_Qty -= deductQty;
        entities.SaveChanges();
    }
    /*
* JW's codes ends
*/

    /*
   * Urmila's codes starts
   */

    public static List<string> GetDistinctItemCatalogsByCategory()
    {
        Model entities = new Model();
        return entities.ItemCatalogs.Select(x => x.Category).Distinct().ToList();

    }

    public static List<ItemCatalog> RetrieveItemCatalogByCategoryID(string categoryID)
    {
        Model entities = new Model();
        return entities.ItemCatalogs.Where(x => x.Category == categoryID).ToList();

    }

    public static ItemCatalog FindItemCatalogFromGivenListByItemNo(List<ItemCatalog> b, string itemno)
    {
        Model entities = new Model();
        return b.Where(x => x.Item_No == itemno).FirstOrDefault();
    }

    /*
* Urmila's codes ends
*/


    /*
    * Jerry's codes starts
    */

    public static List<ItemCatalog> selectAllfromItem(string Catagory)
    {
        Model entities = new Model();
        return entities.ItemCatalogs.Where(X => X.Category.Equals(Catagory)).ToList();
    }
    public static ItemCatalog selectItemByNo(string Item_No)
    {
        Model entities = new Model();
        return entities.ItemCatalogs.Where(X => X.Item_No.Equals(Item_No)).First();
    }
    public static void editItemByNo(string Item_No, int Reorder_lvl, int Reorder_qty, string Unit_of_Measure, int Total_qty, decimal Price, int AllocatedQuantity)
    {
        Model entities = new Model();
        ItemCatalog TheItem = entities.ItemCatalogs.Where(x => x.Item_No.Equals(Item_No)).First();
        TheItem.Reorder_Lvl = Reorder_lvl;
        TheItem.Reorder_Qty = Reorder_qty;
        TheItem.Unit_of_Measure = Unit_of_Measure;
        TheItem.Total_Qty = Total_qty;
        TheItem.Price = Price;
        TheItem.Allocated_Qty = AllocatedQuantity;
        entities.SaveChanges();
    }
    public static void insertNewItem(ItemCatalog newItem)
    {
        Model entities = new Model();
        List<ItemCatalog> TOTAL = RetrieveItemCatalogsList();
        TOTAL.Add(newItem);
        entities.SaveChanges();
    }
    public static List<string> SelectItemCatalog()
    {
        Model entities = new Model();
        return entities.ItemCatalogs.Select(x => x.Category).Distinct().ToList();
    }
    public static List<ItemCatalog> selectLastfromItem(string Catagory)
    {
        Model entities = new Model();
        return entities.ItemCatalogs.Where(X => X.Category.Equals(Catagory)).ToList();
    }


    public static string FindItemByDescription(string item_name)
    {
        Model entities = new Model();
        ItemCatalog first = entities.ItemCatalogs.Where(x => x.Description == item_name).First();
        return first.Item_No;
    }


    /*
    * Jerry's codes ends
    */


}